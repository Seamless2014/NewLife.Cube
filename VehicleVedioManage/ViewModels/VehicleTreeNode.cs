using VehicleVedioManage.Utility;

namespace VehicleVedioManage.Web.ViewModels
{
    /// <summary>
    /// 车辆树节点
    /// </summary>
    [Serializable]
    public class VehicleTreeNode
    {
        /// <summary>
        /// 车辆id
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// 在线
        /// </summary>
        public Boolean Online { get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        public double Speed { get; set; }
        /// <summary>
        /// 报警
        /// </summary>
        public int Alarm { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public String PlateNo { get; set; }
        /// <summary>
        /// 车辆编号
        /// </summary>
        public String VehicleNo { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public int DepId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public String DepName { get; set; }
        /// <summary>
        /// sim卡号
        /// </summary>
        public String SimNo { get; set; }
        /// <summary>
        /// 车辆状态
        /// </summary>
        public VehicleStatus IconIndex { get; set; }
        /// <summary>
        /// 传感器
        /// </summary>
        public int Sensor { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Lng { get; set; }
        /// <summary>
        /// 运货单
        /// </summary>
        public int ShippingId { get; set; }
        /// <summary>
        /// 车辆行驶方向
        /// </summary>
        public LocationStatus LocationStatus { get; set; }
        /// <summary>
        /// 车辆行驶进度
        /// </summary>
        public double LocationProgress { get; set; }
        /// <summary>
        /// 驾驶员名称
        /// </summary>
        public String DriverName { get; set; }
        /// <summary>
        /// 监控员
        /// </summary>
        public String MonitorName { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public String Telephone { get; set; }

    }
}
