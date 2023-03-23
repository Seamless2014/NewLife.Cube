using System.Text.RegularExpressions;

namespace VehicleVedioManage.Common
{
    /// <summary>
    /// JsonHelper
    /// </summary>
    public class JsonHelper
    {
        //static JavaScriptSerializer js = new JavaScriptSerializer();
        //public static String ToJson(Object m)
        //{
        //    js.MaxJsonLength = Int32.MaxValue;
        //    string str = js.Serialize(m);
        //    str = Regex.Replace(str, @"\\/Date\((\d+)\)\\/", match =>
        //    {
        //        DateTime dt = new DateTime(1970, 1, 1);
        //        dt = dt.AddMilliseconds(long.Parse(match.Groups[1].Value));
        //        dt = dt.ToLocalTime();
        //        String value = dt.ToString("yyyy-MM-dd HH:mm:ss");
        //        value = value.Replace(" 00:00:00", "");
        //        if (value.IndexOf("00") == 0)
        //            value = "";
        //        return value;
        //    });

        //    return str;
        //}
    }
}
