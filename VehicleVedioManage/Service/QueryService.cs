//using System.Collections;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 查询服务
//    /// </summary>
//    public class QueryService : IQueryService
//    {
//        #region IQueryService 成员

//        public string SqlMapPath { get; set; }

//        private static ISqlMapper SqlMapper;
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
//            this.Mapper().Update(stateId, objMap);
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
//        /// <summary>
//        /// 配置
//        /// </summary>
//        /// <param name="obj"></param>
//        protected static void Configure(object obj)
//        {
//            SqlMapper = null;
//        }
//        /// <summary>
//        /// sqlmap 配置
//        /// </summary>
//        /// <returns></returns>
//        protected IBatisNet.DataMapper.ISqlMapper Mapper()
//        {
//            if (SqlMapper != null)
//                return SqlMapper;

//            DomSqlMapBuilder d = new DomSqlMapBuilder();//初始化一个DomSqlMapBuilder
//            ConfigureHandler handler = new ConfigureHandler(Configure);

//            SqlMapper = d.ConfigureAndWatch("sqlmap.config", handler);

//            return SqlMapper;


//        }

//    }
//}
