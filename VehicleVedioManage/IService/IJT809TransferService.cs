using VehicleVedioManage.Models;

namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 809转发服务
    /// </summary>
    public interface IJT809TransferService
    {
        /// <summary>
        /// 是否转发
        /// </summary>
        Boolean TransferEnabled { get; set; }
        /// <summary>
        /// 停止线程服务
        /// </summary>
        void Stop();
        /// <summary>
        /// 是否主链路
        /// </summary>
        /// <returns></returns>
        Boolean IsMainLinked();
        /// <summary>
        /// 是否从链路
        /// </summary>
        /// <returns></returns>
        Boolean IsSubLinked();
        /// <summary>
        /// 交换历史定位
        /// </summary>
        /// <param name="PlateNo"></param>
        /// <param name="PlateColor"></param>
        /// <param name="gnssData"></param>
        void UpExgMsgHisLocation(string PlateNo, int PlateColor, List<GpsData> gnssData);
        /// <summary>
        /// 实时数据
        /// </summary>
        /// <param name="gnssData"></param>
        void UpExgMsgRealLocation(GpsData gnssData);
        /// <summary>
        /// 上传监控车辆应答
        /// </summary>
        /// <param name="plateNo"></param>
        /// <param name="plateColor"></param>
        /// <param name="result"></param>
        void UpCtrlMsgMonitorVehicleAck(String plateNo,
                int plateColor, byte result);
        /// <summary>
        /// 上传紧急监控确认
        /// </summary>
        /// <param name="plateNo"></param>
        /// <param name="plateColor"></param>
        /// <param name="result"></param>
        void UpCtrlMsgEmergencyMonitoringAck(String plateNo,
                int plateColor, byte result);
        /// <summary>
        /// 上传文本确认
        /// </summary>
        /// <param name="plateNo"></param>
        /// <param name="plateColor"></param>
        /// <param name="msgId"></param>
        /// <param name="result"></param>
        void UpCtrlMsgTextInfoAck(String plateNo, int plateColor,
                int msgId, byte result);
        /// <summary>
        /// 跟踪应答
        /// </summary>
        /// <param name="plateNo"></param>
        /// <param name="plateColor"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdData"></param>
        void UpCtrlMsgTakeTravelAck(String plateNo, int plateColor,
                byte cmdType, byte[] cmdData);
        /// <summary>
        /// 上报电子运单
        /// </summary>
        /// <param name="plateNo"></param>
        /// <param name="plateColor"></param>
        /// <param name="eContent"></param>
        void UpExgMsgReportTakeEWayBill(String plateNo,
                int plateColor, String eContent);
        /// <summary>
        /// 拍照应答
        /// </summary>
        /// <param name="_photo"></param>
        //void UpCtrlMsgTakePhotoAck(PhotoData _photo);
        ///// <summary>
        ///// 上报车辆注册信息
        ///// </summary>
        ///// <param name="vm"></param>
        //void UpExgMsgRegister(VehicleRegister vm);
        ///// <summary>
        ///// 上报驾驶员信息
        ///// </summary>
        ///// <param name="dm"></param>
        //void UpExgMsgReportDriverInfo(DriverModel dm);
        ///// <summary>
        ///// 上报报警信息
        ///// </summary>
        ///// <param name="wd"></param>
        //void UpWarnMsgAdptInfo(WarnData wd);
    }
}
