//using System;
//using System.Collections;
//using GpsNET.Dao;
//using GpsNET.Domain;
//using System.Collections.Generic;
//using System.Collections.Concurrent;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 基础数据服务
//    /// </summary>
//    public class BasicDataService : BaseDao, IBasicDataService
//    {
//        /// <summary>
//        /// ORM
//        /// </summary>
//        public IBaseDao BaseDao { get; set; }

//        public static ConcurrentDictionary<String, BasicData> basicDataMap = new ConcurrentDictionary<String, BasicData>();

//        #region IBasicDataService 成员
//        /// <summary>
//        /// 初始化
//        /// </summary>
//        public void init()
//        {
//            String hql = "from BasicData where deleted = ?";
//            IList result = this.query(hql, false);
//            foreach (BasicData bd in result)
//            {
//                String key = bd.parent + "_" + bd.code;
//                basicDataMap[key] = bd;
//            }
//        }
//        /// <summary>
//        /// 保存
//        /// </summary>
//        /// <param name="bdList"></param>
//        public void save(List<BasicData> bdList)
//        {
//            this.BaseDao.saveOrUpdateAll(bdList);
//            foreach (BasicData bd in bdList)
//            {
//                String key = bd.parent + "_" + bd.code;
//                basicDataMap[key] = bd;
//            }
//        }
//        /// <summary>
//        /// 保存基础数据并更新缓存
//        /// </summary>
//        /// <param name="bd"></param>
//        public void save(BasicData bd)
//        {
//            this.BaseDao.saveOrUpdate(bd);
//            String key = bd.parent + "_" + bd.code;
//            basicDataMap[key] = bd;
//        }
//        /// <summary>
//        /// 通过编码获取基础数据
//        /// </summary>
//        /// <param name="code"></param>
//        /// <param name="parentCode"></param>
//        /// <returns></returns>
//        public BasicData getBasicDataByCode(String code, String parentCode)
//        {
//            String key = parentCode + "_" + code;
//            BasicData bd = null;
//            if (basicDataMap.ContainsKey(key))
//                bd = basicDataMap[key];
//            if (bd == null)
//                bd = (BasicData)this.find(
//                       "from BasicData a where a.code = ? and a.parent = ?", new Object[] { code, parentCode });

//            return bd;
//        }

//        /// <summary>
//        /// 通过父编码获取基础数据
//        /// </summary>
//        /// <param name="parentCode"></param>
//        /// <returns></returns>
//        public List<BasicData> getBasicDataByParentCode(String parentCode)
//        {

//            String queryString = "from BasicData b where b.parent = ?  and b.Deleted=false order by b.name ASC";

//            IList rs = this.query(queryString, parentCode);
//            List<BasicData> result = new List<BasicData>();
//            foreach (Object obj in rs)
//            {
//                result.Add((BasicData)obj);
//            }
//            return result;
//        }



//        #endregion
//    }
//}
