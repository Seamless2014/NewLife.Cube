namespace VehicleVedioManage.Models
{
    /// <summary>
    /// 记录仪参数
    /// </summary>
    public class RecorderParam
    {
        /// <summary>
        /// 指令
        /// </summary>
        public String cmd { get; set; }
        /// <summary>
        /// 驾驶员编码
        /// </summary>
        public String driverNo { get; set; }
        /// <summary>
        /// 驾驶证
        /// </summary>
        public String driverLicense { get; set; }
        /// <summary>
        /// /VIN
        /// </summary>
        public String vin { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public String vehicleNo { get; set; }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public String vehicleType { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public String clock { get; set; }

        public String feature { get; set; }

        public double mileageIn2d { get; set; }

        public double mileageIn360h { get; set; }
    }
}
