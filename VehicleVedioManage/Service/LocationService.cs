using System.Net;
using System.Text;
using NewLife.Log;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VehicleVedioManage.BackManagement.Entity;
using VehicleVedioManage.Web.IService;
using XCode;

namespace VehicleVedioManage.Web.Service
{
    /// <summary>
    /// 定位服务
    /// </summary>
    public class LocationService : ILocationService
    {
        /// <summary>
        /// 百度地图API key，需要到百度地图SDK官方网站上注册
        /// </summary>
        private String BaiduWebServiceKey { get; set; }
        private readonly ITracer _tracer;
        public LocationService(ITracer tracer)
        {
            _tracer=tracer;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            var exp = new WhereExpression();
            var sc = SystemConfig.FindByWhereExpress(exp);
            BaiduWebServiceKey = sc.BaiduWebServiceKey;
        }
        /// <summary>
        /// 获取位置
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetLocation(double lng, double lat, string type = "wgs84ll")
        {
            DateTime start = DateTime.Now;

            string url = string.Format("http://api.map.baidu.com/geocoder/v2/?ak={0}&coordtype={1}&location={2},{3}&output=json&pois=1",
                BaiduWebServiceKey, type, lat, lng);
            String responseString = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 3000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                StringBuilder sb = new StringBuilder();
                String res = null;
                while ((res = sr.ReadLine()) != null)
                {
                    sb.Append(res.Trim());
                }
                //byte[] bytes = new byte[1024];
                //int n = stream.Read(bytes, 0, 1024);
                response.Close();
                //string s = System.Text.Encoding.UTF8.GetString(bytes,0,n);
                responseString = sb.ToString();
                TimeSpan ts = DateTime.Now - start;
                if (ts.TotalSeconds > 1)
                    _tracer.NewSpan("查询百度位置耗时:" + ts.TotalSeconds + "," + responseString);

                JContainer obj = (JContainer)JsonConvert.DeserializeObject(responseString);
                String status = "" + obj["status"];
                if ("0".Equals(status))
                {
                    JObject result = (JObject)obj["result"];
                    sb = new StringBuilder();
                    String address = (String)result["formatted_address"];
                    sb.Append(address);
                    JArray array = (JArray)result["pois"];
                    if (array != null && array.Count > 0)
                    {
                        JObject a = (JObject)array[0];
                        sb.Append((String)a["name"]).Append((String)a["direction"]).Append((String)a["distance"]).Append("米");
                    }

                    return sb.ToString();
                }
                else
                {
                    _tracer.NewSpan("解析错误:" + responseString);
                }
                return "";

            }
            catch (Exception ex)
            {
                _tracer.NewSpan("解析错误：" + ex.Message + ",请求URL:" + url);
                if (responseString != null)
                    _tracer.NewSpan(responseString);
                return "";
            }
        }
    }
}
