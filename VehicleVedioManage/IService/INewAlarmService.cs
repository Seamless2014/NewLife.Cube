using VehicleVedioManage.ReportStatistics.Entity;

namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 终端报警服务
    /// </summary>
    public interface INewAlarmService
    {
        /// <summary>
        /// 插入报警
        /// </summary>
        /// <param name="alarmSource"></param>
        /// <param name="alarmType"></param>
        /// <param name="rd"></param>
        void insertAlarm(String alarmSource, String alarmType,
           GPSRealData rd);
        /// <summary>
        /// 是否报警
        /// </summary>
        /// <param name="alarmType"></param>
        /// <param name="alarmSource"></param>
        /// <returns></returns>
        bool isAlarmEnabled(String alarmType, String alarmSource);
        /// <summary>
        /// 是否报警统计
        /// </summary>
        /// <param name="alarmType"></param>
        /// <param name="alarmSource"></param>
        /// <returns></returns>
        bool isAlarmStatisticEnabled(String alarmType, String alarmSource);
        /// <summary>
        /// 停止报警服务
        /// </summary>
        void Stop();
    }
}
