using System.Collections;

namespace VehicleVedioManage.Utility
{
    /// <summary>
    /// 自定义Hash
    /// </summary>
    public class CustomHashtable : Hashtable
    {
        /// <summary>
        /// 重载 object
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override object this[object key]
        {
            get
            {
                if (key != null && key.GetType() == typeof(String))
                {
                    string strKey = (String)key;
                    return base[strKey.ToUpper()];
                }
                return base[key];

            }

            set
            {
                if (key != null && key.GetType() == typeof(String))
                {
                    string strKey = (String)key;
                    key = strKey.ToUpper();
                }
                base[key] = value;
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public override void Add(object key, object value)
        {
            if (key != null && key.GetType() == typeof(String))
            {
                string strKey = (String)key;
                key = strKey.ToUpper();
            }
            base.Add(key, value);
        }

        /// <summary>
        /// 整型数值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int IntValue(object key)
        {
            Object obj = this[key];
            return obj != null ? int.Parse("" + obj) : 0;
        }

        /// <summary>
        /// double数值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public double DoubleValue(object key)
        {
            Object obj = this[key];
            return obj != null ? Double.Parse("" + obj) : 0;
        }
        /// <summary>
        /// 字符串数值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public String StringValue(object key)
        {
            Object obj = this[key];
            return "" + obj;
        }


    }
}
