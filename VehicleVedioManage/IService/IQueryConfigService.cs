using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 查询配置服务
    /// </summary>
    public interface IQueryConfigService
    {
        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <param name="queryId"></param>
        /// <returns></returns>
        IList getQueryCondition(String queryId);
        /// <summary>
        /// 获取查询列
        /// </summary>
        /// <param name="queryId"></param>
        /// <returns></returns>
        IList getQueryColumn(String queryId);
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="rowData"></param>
        /// <param name="queryId"></param>
         void convert(Hashtable rowData, String queryId);
        /// <summary>
        /// 加载配置
        /// </summary>
         void loadConfig();
    }
}
