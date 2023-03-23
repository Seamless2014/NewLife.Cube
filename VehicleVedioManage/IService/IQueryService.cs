using System.Collections;

namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 查询服务
    /// </summary>
    public interface IQueryService
    {
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="QueryId"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        IList QueryForList(string QueryId, Hashtable Parameters);
        /// <summary>
        /// 分页查询列表
        /// </summary>
        /// <param name="QueryId"></param>
        /// <param name="Parameters"></param>
        /// <param name="SkipRows"></param>
        /// <param name="MaxRows"></param>
        /// <returns></returns>
        //Pagination QueryForList(string QueryId, Hashtable Parameters, int SkipRows, int MaxRows);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="stateId"></param>
        /// <param name="objMap"></param>
        void update(String stateId, Object objMap);
        /// <summary>
        /// 创建gps表(如果不存在)
        /// </summary>
        /// <param name="tableName"></param>
        void createGpsInfoTableIsNotExist(String tableName);
        /// <summary>
        /// 创建终端报警表(如果不存在)
        /// </summary>
        /// <param name="tableName"></param>
        void createNewAlarmTableIfNotExist(String tableName);
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="queryId"></param>
        /// <param name="data"></param>
        void Insert(String queryId, Object data);
        /// <summary>
        /// 查询对象
        /// </summary>
        /// <param name="QueryId"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        Object QueryObject(string QueryId, Hashtable Parameters);
    }
}
