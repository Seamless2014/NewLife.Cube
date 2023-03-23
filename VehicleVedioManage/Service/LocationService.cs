//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Net;
//using System.IO;
//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;
//using GpsNET.Dao;
//using GpsNET.Domain;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 定位服务
//    /// </summary>
//    public class LocationService : GpsNET.Service.ILocationService
//    {
//        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(LocationService));
//        /// <summary>
//        /// 百度地图API key，需要到百度地图SDK官方网站上注册
//        /// </summary>
//        private String BaiduWebServiceKey { get; set; }
//        /// <summary>
//        /// ORM
//        /// </summary>
//        public IBaseDao BaseDao { get; set; }
//        /// <summary>
//        /// 初始化
//        /// </summary>
//        public void Init()
//        {
//            SystemConfig sc = (SystemConfig)this.BaseDao.load(
//                   typeof(SystemConfig), 1);
//            BaiduWebServiceKey = sc.BaiduWebServiceKey;
//        }
//        /// <summary>
//        /// 获取位置
//        /// </summary>
//        /// <param name="lng"></param>
//        /// <param name="lat"></param>
//        /// <param name="type"></param>
//        /// <returns></returns>
//        public string GetLocation(double lng, double lat, string type = "wgs84ll")
//        {
//            DateTime start = DateTime.Now;

//            string url = string.Format("http://api.map.baidu.com/geocoder/v2/?ak={0}&coordtype={1}&location={2},{3}&output=json&pois=1",
//                BaiduWebServiceKey, type, lat, lng);
//            String responseString = null;
//            try
//            {
//                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
//                request.Timeout = 3000;
//                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//                Stream stream = response.GetResponseStream();
//                StreamReader sr = new StreamReader(stream);
//                StringBuilder sb = new StringBuilder();
//                String res = null;
//                while ((res = sr.ReadLine()) != null)
//                {
//                    sb.Append(res.Trim());
//                }
//                //byte[] bytes = new byte[1024];
//                //int n = stream.Read(bytes, 0, 1024);
//                response.Close();
//                //string s = System.Text.Encoding.UTF8.GetString(bytes,0,n);
//                responseString = sb.ToString();
//                TimeSpan ts = DateTime.Now - start;
//                if (ts.TotalSeconds > 1)
//                    logger.Error("查询百度位置耗时:" + ts.TotalSeconds + "," + responseString);

//                JContainer obj = (JContainer)JsonConvert.DeserializeObject(responseString);
//                String status = "" + obj["status"];
//                if ("0".Equals(status))
//                {
//                    JObject result = (JObject)obj["result"];
//                    sb = new StringBuilder();
//                    String address = (String)result["formatted_address"];
//                    sb.Append(address);
//                    JArray array = (JArray)result["pois"];
//                    if (array != null &&　array.Count > 0)
//                    {
//                        JObject a = (JObject)array[0];
//                        sb.Append((String)a["name"]).Append((String)a["direction"]).Append((String)a["distance"]).Append("米");
//                    }

//                    return sb.ToString();
//                }
//                else
//                {
//                    logger.Error("解析错误:" + responseString);
//                }


//                //logger.Info("查询耗时:" + ts.TotalSeconds + "," + s);
//                return "";

//            }
//            catch (Exception ex)
//            {
//                logger.Error("解析错误：" + ex.Message +",请求URL:" + url);
//                if (responseString != null)
//                    logger.Error(responseString);
//                //logger.Error(ex.Message,ex);
//                return "";// ex.Message;
//            }
//            //保存到数据库
//            //int nOffLng = pt.X - GpsCoordinate.X, nOffLat = pt.Y - GpsCoordinate.Y;

//        }

//    }
//}
