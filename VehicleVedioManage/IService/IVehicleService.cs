using VehicleVedioManage.BackManagement.Entity;
using VehicleVedioManage.BasicData.Entity;
using XCode.Membership;

namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 车辆服务接口
    /// </summary>
    public interface IVehicleService
    {
        /// <summary>
        /// 根据部门获取车辆
        /// </summary>
        /// <param name="depIdList"></param>
        /// <returns></returns>
        List<Vehicle> getVehicleListByDepId(
            List<int> depIdList);

        /// <summary>
        /// 根据车辆编号获取车辆
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        Vehicle getVehicleData(int vehicleId);
        /// <summary>
        /// 根据车牌号获取部门
        /// </summary>
        /// <param name="plateNo"></param>
        /// <returns></returns>
        Department getDepartmentByPlateNo(String plateNo);
        /// <summary>
        /// 保存车辆数据
        /// </summary>
        /// <param name="vd"></param>
        void saveVehicleData(Vehicle vd);
        /// <summary>
        /// 保存车辆
        /// </summary>
        /// <param name="vd"></param>
        /// <param name="modifyRecordList"></param>
        void saveVehicleData(Vehicle vd, List<VehicleInfoModifyRecord> modifyRecordList);
        /// <summary>
        /// 根据sim卡号获取车辆
        /// </summary>
        /// <param name="simNo"></param>
        /// <returns></returns>
        Vehicle getVehicleBySimNo(String simNo);
        /// <summary>
        /// 根据终端ID获取终端
        /// </summary>
        /// <param name="terminalId"></param>
        /// <returns></returns>
        TerminalInfo getTerminal(int terminalId);
        /// <summary>
        /// 根据终端编号获取终端
        /// </summary>
        /// <param name="terminalNo"></param>
        /// <returns></returns>
        TerminalInfo getTerminalByTermNo(String terminalNo);
        /// <summary>
        /// 根据车牌号获取车辆
        /// </summary>
        /// <param name="plateNo"></param>
        /// <returns></returns>
        Vehicle getVehicleByPlateNo(String plateNo);
        /// <summary>
        /// 保存终端
        /// </summary>
        /// <param name="t"></param>
        void saveTerminal(TerminalInfo t);
        /// <summary>
        /// 根据车辆Id删除车辆
        /// </summary>
        /// <param name="vehicleId"></param>
        void delete(int vehicleId);
    }
}
