using System.Collections;
using System.Runtime.Serialization;

namespace VehicleVedioManage.Web.Models
{
    /// <summary>
    /// 分页
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class PageData<T>
    {

        /// <summary>
        /// 数据记录
        /// </summary>
        [DataMember]
        public List<T> Data { get; set; }
        /// <summary>
        /// 开始记录数
        /// </summary>
        [DataMember]
        public int Start { get; set; }
        /// <summary>
        /// 限制数
        /// </summary>
        [DataMember]
        public int Limit { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        [DataMember]
        public int PageNo { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage
        {
            get
            {
                this.Limit = this.Limit == 0 ? 1 : this.Limit;
                return 1 + this.TotalRecord / this.Limit;
            }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        [DataMember]
        public int TotalRecord { get; set; }

    }

    /// <summary>
    /// 查询参数类，构造此类，可以使得查询条件参数动态增加或减少，而不会造成接口方法的变化
    /// </summary>

    [DataContract]
    [KnownType(typeof(List<String>))]
    public class QueryParam
    {

        public QueryParam()
        {
            Param = new Dictionary<string, object>();
            StartPageNo = 1;
            Limit = 50;
        }
        /// <summary>
        /// 用户id
        /// </summary>
        [DataMember]
        public int UserId { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        [DataMember]
        public int StartPageNo { get; set; }
        /// <summary>
        /// 限制
        /// </summary>
        private int limit;
        /// <summary>
        /// 每页显示的记录数
        /// </summary>
        [DataMember]
        public int Limit
        {
            get
            {
                if (limit <= 0)
                    limit = 10;
                return limit;
            }
            set
            {
                limit = value;
            }
        }
        /// <summary>
        /// 总记录数
        /// </summary>
        [DataMember]
        public int Total { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        [DataMember]
        public Dictionary<string, object> Param { get; set; }
        /// <summary>
        /// 查询id
        /// </summary>
        [DataMember]
        public String QueryId { get; set; }
        /// <summary>
        /// 跳过行数
        /// </summary>
        public int SkipRows
        {
            get
            {
                return (this.StartPageNo - 1) * this.Limit;
            }
        }
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <returns></returns>
        public Hashtable getParams()
        {
            Hashtable parameters = new Hashtable();
            //设置查询参数
            foreach (string key in Param.Keys)
            {
                parameters[key] = Param[key];
            }
            return parameters;

        }

    }
}
