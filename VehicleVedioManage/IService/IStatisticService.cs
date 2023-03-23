namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 统计服务
    /// </summary>
    public interface IStatisticService
    {
        /// <summary>
        /// 按小时统计
        /// </summary>
        void StaticByHour();
        /// <summary>
        /// 按天统计
        /// </summary>
        void StaticByDay();
    }
}
