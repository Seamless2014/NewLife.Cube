using VehicleVedioManage.ReportStatistics.Entity;

namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 批量服务
    /// </summary>
    public interface IBatchService
    {
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="g"></param>
        void EnQueue(GpsInfo g);
        /// <summary>
        /// /停止服务
        /// </summary>
        void Stop();
        /// <summary>
        /// 队列数
        /// </summary>
        int QueueNum { get; set; }
    }
}
