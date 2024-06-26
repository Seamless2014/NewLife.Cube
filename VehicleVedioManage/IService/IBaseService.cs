using System.Collections;
using VehicleVedioManage.BackManagement.Entity;
using VehicleVedioManage.BasicData.Entity;
using VehicleVedioManage.ReportStatistics.Entity;

namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 基础服务
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// 保存报警配置
        /// </summary>
        /// <param name="alarmConfigs"></param>
        void saveAlarmConfig(IList<AlarmConfig> alarmConfigs);
        /// <summary>
        /// 获取报警配置
        /// </summary>
        /// <param name="alarmType"></param>
        /// <param name="alarmSource"></param>
        /// <returns></returns>
        AlarmConfig getAlarmConfig(String alarmType, String alarmSource);
        /// <summary>
        /// 获取平台状态
        /// </summary>
        /// <returns></returns>
        PlatformState getPlatformState();
        /// <summary>
        /// 获取报警配置
        /// </summary>
        /// <returns></returns>
        List<AlarmConfig> getAlarmConfigs();
        /// <summary>
        /// 获取基础数据信息
        /// </summary>
        /// <param name="inforType"></param>
        /// <returns></returns>
        List<BasicInfo> getInformationByType(String inforType);
    }
}
