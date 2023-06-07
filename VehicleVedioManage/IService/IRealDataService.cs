using VehicleVedioManage.BackManagement.Entity;
using VehicleVedioManage.BasicData.Entity;
using VehicleVedioManage.ReportStatistics.Entity;

namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 实时数据服务
    /// </summary>
    public interface IRealDataService
    {
        /// <summary>
        /// 获取实时数据
        /// </summary>
        /// <param name="simNo"></param>
        /// <returns></returns>
        GPSRealData Get(string simNo);
        /// <summary>
        /// 获取在线实时数据列表
        /// </summary>
        /// <returns></returns>
        System.Collections.Generic.List<GPSRealData> GetOnlineRealDataList();
        /// <summary>
        /// 获取实时数据列表
        /// </summary>
        /// <param name="simNoList"></param>
        /// <returns></returns>
        System.Collections.Generic.List<GPSRealData> GetRealDataList(System.Collections.Generic.List<string> simNoList);
        /// <summary>
        /// 更新实时数据
        /// </summary>
        /// <param name="rd"></param>
        void Update(GPSRealData rd);
        /// <summary>
        /// 更新在线时间
        /// </summary>
        /// <param name="simNo"></param>
        /// <param name="onlineDate"></param>
        void UpdateOnlineTime(string simNo,DateTime onlineDate);
        /// <summary>
        /// 获取车辆数据
        /// </summary>
        /// <param name="simNo"></param>
        /// <returns></returns>
        Vehicle getVehicleData(String simNo);
        /// <summary>
        /// 获取终端数据
        /// </summary>
        /// <param name="termNo"></param>
        /// <returns></returns>
        TerminalInfo getTerminalByTermNo(String termNo);
        /// <summary>
        /// 根据车牌号获取车辆数据
        /// </summary>
        /// <param name="plateNo"></param>
        /// <returns></returns>
        Vehicle getVehicleByPlateNo(String plateNo);
        /// <summary>
        /// 更新车辆数据
        /// </summary>
        /// <param name="simNo"></param>
        /// <param name="v"></param>
        void updateVehicleData(String simNo, Vehicle v);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="simNo"></param>
        void Remove(string simNo);
        /// <summary>
        /// 停止服务
        /// </summary>
        void Stop();
    }
}
