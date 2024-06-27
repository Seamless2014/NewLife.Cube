//using System.Collections;
//using NewLife.Log;
//using VehicleVedioManage.Web.IService;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 查询服务
//    /// </summary>
//    public class QueryService : IQueryService
//    {
//        #region IQueryService 成员

//        public string SqlMapPath { get; set; }

//        private readonly ITracer _tracer;
//        public QueryService(ITracer tracer)
//        {
//            _tracer = tracer;
//        }

//        /// <summary>
//        /// 查询列表
//        /// </summary>
//        /// <param name="QueryId"></param>
//        /// <param name="Parameters"></param>
//        /// <returns></returns>
//        public IList QueryForList(string QueryId, Hashtable Parameters)
//        {
//            return Mapper().QueryForList(QueryId, Parameters);
//        }
//        /// <summary>
//        /// 查询列表
//        /// </summary>
//        /// <param name="QueryId"></param>
//        /// <param name="Parameters"></param>
//        /// <param name="SkipRows"></param>
//        /// <param name="MaxRows"></param>
//        /// <returns></returns>
//        public Pagination QueryForList(string QueryId, Hashtable Parameters, int SkipRows, int MaxRows)
//        {
//            return Mapper().QueryForPaginateList(QueryId, Parameters, SkipRows, MaxRows);
//        }
//        /// <summary>
//        /// 更新
//        /// </summary>
//        /// <param name="stateId"></param>
//        /// <param name="objMap"></param>
//        public void update(String stateId, Object objMap)
//        {
//            Mapper().Update(stateId, objMap);
//        }

//        /// <summary>
//        /// 查询对象
//        /// </summary>
//        /// <param name="QueryId"></param>
//        /// <param name="Parameters"></param>
//        /// <returns></returns>
//        public Object QueryObject(string QueryId, Hashtable Parameters)
//        {
//            return Mapper().QueryForObject(QueryId, Parameters);
//        }
//        /// <summary>
//        /// 插入
//        /// </summary>
//        /// <param name="queryId"></param>
//        /// <param name="data"></param>
//        public void Insert(String queryId, Object data)
//        {
//            Mapper().Insert(queryId, data);

//        }
//        /// <summary>
//        /// 查询表是否存在
//        /// </summary>
//        /// <param name="tableName"></param>
//        /// <returns></returns>
//        public bool checkTableExist(String tableName)
//        {
//            Hashtable param = new Hashtable();
//            param.Add("tableName", tableName);
//            IList result = this.QueryForList("checkTableExist", param);
//            return result.Count > 0;
//        }
//        /// <summary>
//        /// 如果不存在创建GPS信息表
//        /// </summary>
//        /// <param name="tableName"></param>
//        public void createGpsInfoTableIsNotExist(String tableName)
//        {
//            if (checkTableExist(tableName) == false)
//            {
//                Hashtable param = new Hashtable();
//                param.Add("tableName", tableName);
//                update("createTableForGpsInfo", param);
//            }
//        }
//        /// <summary>
//        /// 如果不存在创建终端报警表
//        /// </summary>
//        /// <param name="tableName"></param>
//        public void createNewAlarmTableIfNotExist(String tableName)
//        {
//            if (checkTableExist(tableName) == false)
//            {
//                Hashtable param = new Hashtable();
//                param.Add("tableName", tableName);
//                update("createTableForNewAlarm", param);
//            }
//        }
//        #endregion
//    }
//}
