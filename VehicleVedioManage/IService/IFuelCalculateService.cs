using VehicleVedioManage.BackManagement.Entity;

namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 燃料计算服务
    /// </summary>
    public interface IFuelCalculateService
    {
        /// <summary>
        /// 获取燃料
        /// </summary>
        /// <param name="t"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        double getFuel(FuelTank t, double level);
        /// <summary>
        /// 获取燃料
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="tankNo"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        double getFuel(int vehicleId, int tankNo, double level);
        /// <summary>
        /// 获取油箱
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="tankNo"></param>
        /// <returns></returns>
        FuelTank getFuelTank(int vehicleId, int tankNo);
    }
}
