using System.Reflection;
using System.Runtime.Serialization;
using VehicleVedioManage.BasicData.Entity;
using XCode;

namespace VehicleVedioManage.Web.Models
{
    /// <summary>
    /// 请求实体
    /// </summary>
    [DataContract]
    [KnownType("GetKnownType")]
    public class RequestEntity
    {
        public RequestEntity(Object entity)
        {
            Entity = entity;
        }

        /// <summary>
        /// 实体
        /// </summary>
        [DataMember]
        public object Entity { get; set; }
        /// <summary>
        /// 获取已知类型
        /// </summary>
        /// <returns></returns>
        private static Type[] GetKnownType()
        {
            Type[] types = Assembly.Load("GpsNET.Service").GetTypes();
            List<Type> newTypes = new List<Type>();
            foreach (var temp in types)
            {
                var tempInterface = temp.GetInterface("IEntity");
                if (tempInterface != null && tempInterface == typeof(IEntity))
                {
                    newTypes.Add(temp);
                }
            }
            if (newTypes.Count == 0)
            {
                newTypes.Add(typeof(Vehicle));
            }
            return newTypes.ToArray();
        }
    }
}
