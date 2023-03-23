namespace VehicleVedioManage.Models
{
    /// <summary>
    /// GPS车辆实时数据，专用于手机客户端显示
    /// </summary>
    public class GpsData
    {
        /// <summary>
        /// 在线
        /// </summary>
        public static String ONLINE = "online";
        /// <summary>
        /// 离线
        /// </summary>
        public static String OFFLINE = "offline";
        /// <summary>
        /// 车辆编码
        /// </summary>
        public int vehicleId { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public String plateNo { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public String depName { get; set; }
        /// <summary>
        /// Sim 卡号
        /// </summary>
        public String simNo { get; set; }
        /// <summary>
        /// 在线
        /// </summary>
        public Boolean online { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double lng { get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        public double speed { get; set; }
        /// <summary>
        /// 方向
        /// </summary>
        public int direction { get; set; }
        /**
         * 终端报警状态 参见808协议
         */
        public String alarm { get; set; }
        /**
         * 终端状态位
         */
        public String status { get; set; }
        /**
         * 记录仪状态位参见808协议 0200定位包的扩展状态位
         */
        public String signal { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public String location { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public String sendTime { get; set; }
        /// <summary>
        /// 里程
        /// </summary>
        public double mileage { get; set; }
        /// <summary>
        /// 油量
        /// </summary>
        public double oil { get; set; }
    }
}
