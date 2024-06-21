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
        /// <summary>
        /// 按月统计
        /// </summary>
        void StaticByMonth();
        /// <summary>
        /// 按年统计
        /// </summary>
        void StaticByYear();

    }
}
