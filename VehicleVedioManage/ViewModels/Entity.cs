using NewLife.Log;

namespace VehicleVedioManage.Web.ViewModels
{
    /// <summary>
    /// 数据实体类 表头使用
    /// </summary>
    public class Entity : Dictionary<string, object>
    {
        /// <summary>
        /// 获取Int 型数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        public int GetInt(string name)
        {
            return TypeConverter.ObjectToInt(GetString(name), 0);

        }
        public bool GetBoolean(string name, bool def)
        {
            return TypeConverter.ObjectToBool(GetString(name), def);
        }
        /// <summary>
        /// 获取 int
        /// </summary>
        /// <param name="name"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public int GetInt(string name, int def)
        {
            return TypeConverter.BitToInt(GetString(name), def);

        }
        /// <summary>
        /// 覆盖式加入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public void Put(string key, object val)
        {
            if (this.ContainsKey(key)) this[key] = val;
            else this.Add(key, val);
        }
        /// <summary>
        /// 转实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ToModel<T>()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(ToJson());
        }
        /// <summary>
        /// 转json字符串
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// 获取float
        /// </summary>
        /// <param name="name"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public float GetFloat(string name, float def)
        {
            return TypeConverter.ObjectToFloat(GetString(name), def);

        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Exist(string name)
        {
            if (this.ContainsKey(name)) return true;
            if (this.ContainsKey(name.ToLower())) return true;
            if (this.ContainsKey(name.ToUpper())) return true;

            return false;
        }
        /// <summary>
        /// 获取String
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetString(string name)
        {
            if (this.ContainsKey(name) && this[name] != null) return this[name].ToString();
            if (this.ContainsKey(name.ToUpper()) && this[name.ToUpper()] != null) return this[name.ToUpper()].ToString();
            if (this.ContainsKey(name.ToUpper()) && this[name.ToUpper()] != null) return this[name.ToUpper()].ToString();
            return "";
        }
        public string GetString(string name, string def)
        {
            string str = GetString(name);
            if (str == "") return def;
            return str;
        }
        /// <summary>
        /// 获取日期
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DateTime GetDateTime(string name)
        {
            try
            {
                return DateTime.Parse(GetString(name));
            }
            catch (Exception ex)
            {
                XTrace.WriteLine(ex.Message);
                return DateTime.Now;
            }
        }
        /// <summary>
        /// 获取可空的日期
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DateTime? GetDateTimeNull(string name)
        {
            try
            {
                return DateTime.Parse(GetString(name));
            }
            catch (Exception ex)
            {
                XTrace.WriteLine(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetObject(string name)
        {
            if (this.ContainsKey(name) && this[name] != null) return this[name];
            if (this.ContainsKey(name.ToUpper()) && this[name.ToUpper()] != null) return this[name.ToUpper()];
            if (this.ContainsKey(name.ToUpper()) && this[name.ToUpper()] != null) return this[name.ToUpper()];
            return "";
        }


    }
}
