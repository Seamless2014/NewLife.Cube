using VehicleVedioManage.ReportStatistics.Entity;

namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 报警服务接口
    /// </summary>
    public interface IAlarmService
    {
        /// <summary>
        /// 开始服务
        /// </summary>
         void Start();
        /// <summary>
        /// 结束服务
        /// </summary>
        void Stop();
        /// <summary>
        /// 处理实时数据
        /// </summary>
        /// <param name="rd"></param>
        void processRealData(GPSRealData rd);

    }
}
