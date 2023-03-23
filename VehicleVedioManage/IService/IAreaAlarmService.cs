namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 区域报警服务接口
    /// </summary>
    public interface IAreaAlarmService
    {
        /// <summary>
        /// 开始服务
        /// </summary>
         void Start();
        /// <summary>
        /// 结束服务
        /// </summary>
        void Stop();

    }
}
