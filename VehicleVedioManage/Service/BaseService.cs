//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using GpsNET.Dao;
//using GpsNET.Domain;
//using System.Collections;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 基础服务
//    /// </summary>
//    public class BaseService : BaseDao, IBaseService
//    {
//        /// <summary>
//        /// ORM
//        /// </summary>
//        public IBaseDao BaseDao { get; set; }
//        /// <summary>
//        /// 基本信息缓存
//        /// </summary>
//        public static Dictionary<String, AlarmConfig> alarmConfigMap = new Dictionary<String, AlarmConfig>();
//        /// <summary>
//        /// 保存报警配置
//        /// </summary>
//        /// <param name="alarmConfigs"></param>
//        public void saveAlarmConfig(IList alarmConfigs)
//        {
//            foreach (AlarmConfig a in alarmConfigs)
//            {
//                String key = a.alarmType + "_" + a.alarmSource;
//                alarmConfigMap[key] = a;
//            }
//            this.BaseDao.saveOrUpdateAll(alarmConfigs);
//        }
//        /// <summary>
//        /// 获取报警配置
//        /// </summary>
//        /// <param name="alarmType"></param>
//        /// <param name="alarmSource"></param>
//        /// <returns></returns>
//        public AlarmConfig getAlarmConfig(String alarmType, String alarmSource)
//        {
//            String key = alarmType + "_" + alarmSource;

//            if (alarmConfigMap.Count == 0)
//            {
//                getAlarmConfigs();
//            }
//            if (alarmConfigMap.ContainsKey(key) == false)
//                return null;
//            return alarmConfigMap[key];
//        }
//        /// <summary>
//        /// 获取报警配置
//        /// </summary>
//        /// <returns></returns>
//        public List<AlarmConfig> getAlarmConfigs()
//        {
//            List<AlarmConfig> result = new List<AlarmConfig>();
//            if (alarmConfigMap.Count > 0)
//            {
//                ICollection ic = alarmConfigMap.Values;
//                foreach (AlarmConfig a in ic)
//                {
//                    result.Add(a);
//                }
//            }
//            else
//            {
//                IList ls = this.loadAll(typeof(AlarmConfig));
//                foreach (AlarmConfig a in ls)
//                {
//                    String akey = a.alarmType + "_" + a.alarmSource;
//                    alarmConfigMap[akey] = a;
//                    result.Add(a);
//                }
//            }
//            return result;
//        }
//        /// <summary>
//        /// 获取基础信息
//        /// </summary>
//        /// <param name="inforType"></param>
//        /// <returns></returns>
//        public List<BasicData> getInformationByType(String inforType)
//        {
//            String hql = "from BasicData where parent = ? and code = ? and deleted = ?";

//            IList result = this.query(hql, new Object[] { "Information", inforType, false });
//            List<BasicData> ls = new List<BasicData>();
//            foreach (Object obj in result)
//            {
//                ls.Add((BasicData)obj);
//            }
//            return ls;
//        }

//        /// <summary>
//        /// 获取平台状态
//        /// </summary>
//        /// <returns></returns>
//        public PlatformState getPlatformState()
//        {
//            PlatformState ps = (PlatformState)this.find("from PlatformState order by CreateDate");
//            if (ps == null)
//            {
//                ps = new PlatformState();
//                //this.saveOrUpdate(ps);
//            }
//            return ps;
//        }
//    }
//}
