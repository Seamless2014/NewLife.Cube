using System.Collections;
using System.Collections.Concurrent;
using VehicleVedioManage.BasicData.Entity;
using VehicleVedioManage.Web.IService;
using XCode;

namespace VehicleVedioManage.Web.Service
{
    /// <summary>
    /// 基础数据服务
    /// </summary>
    public class BasicDataService : IBasicDataService
    {

        public static ConcurrentDictionary<String, BasicInfo> basicDataMap = new ConcurrentDictionary<String, BasicInfo>();

        #region IBasicDataService 成员
        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            var exp = new WhereExpression();
            IList<BasicInfo> result = BasicInfo.FindAllByWhereExpress(exp); ;
            foreach (BasicInfo bd in result)
            {
                String key = bd.ParentName + "_" + bd.Code;
                basicDataMap[key] = bd;
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="bdList"></param>
        public void save(List<BasicInfo> bdList)
        {
            bdList.Insert();
            foreach (BasicInfo bd in bdList)
            {
                String key = bd.ParentName + "_" + bd.Code;
                basicDataMap[key] = bd;
            }
        }
        /// <summary>
        /// 保存基础数据并更新缓存
        /// </summary>
        /// <param name="bd"></param>
        public void save(BasicInfo bd)
        {
            bd.Update();
            String key = bd.ParentID + "_" + bd.Code;
            basicDataMap[key] = bd;
        }
        /// <summary>
        /// 通过编码获取基础数据
        /// </summary>
        /// <param name="code"></param>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        public BasicInfo getBasicDataByCode(String code, String parentCode)
        {
            String key = parentCode + "_" + code;
            BasicInfo bd = null;
            if (basicDataMap.ContainsKey(key))
                bd = basicDataMap[key];
            if (bd == null)
            {
                var exp = new WhereExpression();
                exp &= BasicInfo._.Code == code;
                exp &=BasicInfo._.ParentID == parentCode;
                bd= BasicInfo.FindByWhereExpress(exp);
            }
            return bd;
        }

        /// <summary>
        /// 通过父编码获取基础数据
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        public List<BasicInfo> getBasicDataByParentCode(String parentCode)
        {
            var exp=new WhereExpression();
            exp &= BasicInfo._.ParentID == parentCode;
            var rs = BasicInfo.FindAllByWhereExpress(exp);
            var result = new List<BasicInfo>();
            foreach (Object obj in rs)
            {
                result.Add((BasicInfo)obj);
            }
            return result;
        }
        #endregion
    }
}
