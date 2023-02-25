using System.ComponentModel;
using System.Reflection;
using GPSPlatform.ViewModels;
using XCode.Membership;

namespace GPSPlatform.Enums
{
    /// <summary>
    /// 公共枚举方法
    /// </summary>
    public static class CommonEnumFunc
    {
        /// <summary>
        /// 获取所有枚举
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<SelectPlateColor> GetAllEnums(this Type type)
        {
            var result = new List<SelectPlateColor>();
            if (type.IsEnum)
            {
                var fields = type.GetFields(BindingFlags.Static | BindingFlags.Public) ?? new FieldInfo[] { };
                foreach (var field in fields)
                {
                    var info = new SelectPlateColor();
                    info.Name = field.Name;
                    info.Value = (int)field.GetValue(null);
                    var atts = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    info.Description = atts != null && atts.Length > 0
                            ? ((DescriptionAttribute[])atts)[0].Description
                            : string.Empty;
                    result.Add(info);
                }
            }
            return result;
        }

        public static IList<Parameter> GetDictionary(string category,int userId) 
        {
            return Parameter.FindAllByUserID(userId, category);
        }
    }
}
