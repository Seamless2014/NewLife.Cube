using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NewLife.Log;
using NewLife.Reflection;
using NewLife.Serialization;

namespace VehicleVedioManage.Utility.MapService
{
    /// <summary>
    /// 
    /// </summary>
    public class BMapFix
    {
        private readonly ITracer _tracer;
        public BMapFix(ITracer tracer)
        {
            _tracer = tracer;
        }
        private int GetAreaPostion(int GpsCoordinate)
        {
            //计算"度"的部分
            int nDegree = GpsCoordinate / 1000000 * 1000000;
            //计算度后面小数部分
            int nSecond = (int)(0.000001 * (GpsCoordinate - nDegree) * 3600);
            //两者重新相加
            return nDegree + nSecond;
        }


        static double x_pi = 3.14159265358979324 * 3000.0 / 180.0;
        public PointLatLng bdToGcj(double bd_lat, double bd_lon)
        {
            double x = bd_lon - 0.0065, y = bd_lat - 0.006;
            double z = Math.Sqrt(x * x + y * y) - 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) - 0.000003 * Math.Cos(x * x_pi);
            double gg_lon = z * Math.Cos(theta);
            double gg_lat = z * Math.Sin(theta);
            return new PointLatLng(gg_lat, gg_lon);
        }

        public PointLatLng gcjToBd(double gg_lat, double gg_lon)
        {
            double bd_lat;
            double bd_lon;
            double x = gg_lon, y = gg_lat;
            double z = Math.Sqrt(x * x + y * y) + 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) + 0.000003 * Math.Cos(x * x_pi);
            bd_lon = z * Math.Cos(theta) + 0.0065;
            bd_lat = z * Math.Sin(theta) + 0.006;

            return new PointLatLng(bd_lat, bd_lon);
        }

        /**
         * @type GPS坐标类型
         */
        public PointLatLng Fix(double lng, double lat, string type)
        {

            DateTime start = DateTime.Now;
            PointLatLng pt = new PointLatLng(0, 0);
            try
            {
                String apiKey = "GT3YSZNuqHkwbGyAY4maPaVw";
                int coordtype = 1;
                String strCoords = lng + "," + lat;
                String url = "http://api.map.baidu.com/geoconv/v1/?ak=" + apiKey+ "&coords=" + strCoords + "&output=json&from=" + coordtype;

                //string url = string.Format("http://api.map.baidu.com/ag/coord/convert?from={0}&to=4&x={1}&y={2}",
                // type, lng, lat);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 3000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                byte[] bytes = new byte[1024];
                int n = stream.Read(bytes, 0, 1024);
                response.Close();
                if (n < 2)
                {
                    return pt;
                }
                else
                {
                    var s = System.Text.Encoding.UTF8.GetString(bytes, 0, n).Replace("\"", "");
                    var _json = new FastJson();
                    var _baiduCoords= _json.Read(s, typeof(BaiduCoords)) as BaiduCoords;
                    if (_baiduCoords!=null&&_baiduCoords.coords.Count > 0)
                    {
                        pt.Lng = _baiduCoords.coords[0].x;
                        pt.Lat = _baiduCoords.coords[0].y;
                        return pt;
                    }

                    foreach (string team in s.Split(','))
                    {
                        string[] infos = team.Split(':');
                        if (infos.Length < 2)
                        {
                            return pt;
                        }
                        string strValue = infos[1];
                        switch (infos[0])
                        {
                            case "error":
                                if (strValue != "0")
                                    return pt;
                                break;
                            case "x":
                                {
                                    byte[] outputb = Convert.FromBase64String(strValue);
                                    strValue = Encoding.Default.GetString(outputb);
                                    pt.Lng = double.Parse(strValue);
                                }
                                break;
                            case "y":
                                {
                                    byte[] outputb = Convert.FromBase64String(strValue);
                                    strValue = Encoding.Default.GetString(outputb);
                                    pt.Lat = double.Parse(strValue);
                                }
                                break;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                _tracer?.NewSpan("Fix", ex);
                return pt;
            }
            return pt;
        }

        public string getLocation(double lng, double lat, string type = "wgs84ll")
        {
            DateTime start = DateTime.Now;

            string url = string.Format("http://api.map.baidu.com/geocoder/v2/?ak={0}&callback=renderReverse&coordtype={1}&location={2},{3}&output=json&pois=0",
                Constants.ak, type, lat, lng);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 3000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                byte[] bytes = new byte[1024];
                int n = stream.Read(bytes, 0, 1024);
                response.Close();
                if (n < 2)
                {
                    return "";
                }
                else
                {
                    string s = System.Text.Encoding.UTF8.GetString(bytes).Substring(1, n - 2);//.Replace("\"", "");
                    TimeSpan ts = DateTime.Now - start;
                    if (ts.TotalSeconds > 1)
                        _tracer?.NewSpan("查询耗时:" + ts.TotalSeconds + "," + s);
                    int index = s.IndexOf("status");
                    string status = "";
                    if (index >= 0)
                    {
                        index = s.IndexOf(":", index);
                        int startIndex = index + 2;

                        int endIndex = s.IndexOf("\"", startIndex);

                        status = s.Substring(startIndex, endIndex - startIndex);
                    }

                    index = s.IndexOf("formatted_address");
                    if (index >= 0)
                    {
                        index = s.IndexOf(":", index);
                        int startIndex = index + 2;

                        int endIndex = s.IndexOf("\"", startIndex);

                        string location = s.Substring(startIndex, endIndex - startIndex);

                        return location;
                    }

                    //logger.Info("查询耗时:" + ts.TotalSeconds + "," + s);
                    return status;
                }
            }
            catch (Exception ex)
            {
                _tracer?.NewSpan($"Error: {ex.Message}");
                return "";// ex.Message;
            }
        }


    }
}
