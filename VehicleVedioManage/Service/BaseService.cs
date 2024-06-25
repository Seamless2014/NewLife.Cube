using System.Collections;
using VehicleVedioManage.BackManagement.Entity;
using VehicleVedioManage.BasicData.Entity;
using VehicleVedioManage.ReportStatistics.Entity;
using VehicleVedioManage.Web.IService;
using XCode;

namespace VehicleVedioManage.Web.Service
{
    /// <summary>
    /// 基础服务
    /// </summary>
    public class BaseService :IBaseService
    {
        /// <summary>
        /// 基本信息缓存
        /// </summary>
        public static Dictionary<String, AlarmConfig> alarmConfigMap = new Dictionary<String, AlarmConfig>();
        /// <summary>
        /// 保存报警配置
        /// </summary>
        /// <param name="alarmConfigs"></param>
        public void saveAlarmConfig(IList alarmConfigs)
        {
            foreach (AlarmConfig a in alarmConfigs)
            {
                String key = a.alarmType + "_" + a.alarmSource;
                alarmConfigMap[key] = a;
            }
            //AlarmConfig.Insert(alarmConfigs);
        }
        /// <summary>
        /// 获取报警配置
        /// </summary>
        /// <param name="alarmType"></param>
        /// <param name="alarmSource"></param>
        /// <returns></returns>
        public AlarmConfig getAlarmConfig(String alarmType, String alarmSource)
        {
            String key = alarmType + "_" + alarmSource;

            if (alarmConfigMap.Count == 0)
            {
                getAlarmConfigs();
            }
            if (alarmConfigMap.ContainsKey(key) == false)
                return null;
            return alarmConfigMap[key];
        }
        /// <summary>
        /// 获取报警配置
        /// </summary>
        /// <returns></returns>
        public List<AlarmConfig> getAlarmConfigs()
        {
            var result = new List<AlarmConfig>();
            if (alarmConfigMap.Count > 0)
            {
                ICollection ic = alarmConfigMap.Values;
                foreach (AlarmConfig a in ic)
                {
                    result.Add(a);
                }
            }
            else
            {
                var ls =AlarmConfig.LoadAll();
                foreach (var a in ls)
                {
                    var akey = a.alarmType + "_" + a.alarmSource;
                    alarmConfigMap[akey] = a;
                    result.Add(a);
                }
            }
            return result;
        }
        /// <summary>
        /// 获取基础信息
        /// </summary>
        /// <param name="inforType"></param>
        /// <returns></returns>
        public List<BasicInfo> getInformationByType(String inforType)
        {
            String hql = "from BasicInfo where parent = ? and code = ? and deleted = ?";
            var exp = new WhereExpression();
            exp &=BasicInfo._.ParentID == 1;
            exp &= BasicInfo._.Code == inforType;
            var ls =BasicInfo.FindAllByWhereExpress(exp);
            return ls?.ToList();
        }

        /// <summary>
        /// 获取平台状态
        /// </summary>
        /// <returns></returns>
        public PlatformState getPlatformState()
        {
            var exp=new WhereExpression();
            PlatformState ps = PlatformState.FindByWhereExpress(exp);
            if (ps == null)
            {
                ps = new PlatformState();
                ps.Upsert();
            }
            return ps;
        }

        PlatformState IBaseService.getPlatformState() => throw new NotImplementedException();
        List<BasicInfo> IBaseService.getInformationByType(String inforType) => throw new NotImplementedException();
    }
}
