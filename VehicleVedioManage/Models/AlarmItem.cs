using VehicleVedioManage.ReportStatistics.Entity;

namespace VehicleVedioManage.Web.Models
{
    /// <summary>
    /// 报警项
    /// </summary>
    public class AlarmItem
    {
        public AlarmItem()
        {
        }

        public AlarmItem(GPSRealData rd, String alarmType, String alarmSource)
        {
            PlateNo = rd.PlateNo;
            VehicleId = rd.VehicleId;
            Velocity = rd.Velocity;
            AlarmTime = rd.SendTime;
            Location = rd.Location;
            Latitude = rd.Latitude;
            Longitude = rd.Longitude;
            AlarmType = alarmType;
            AlarmSource = alarmSource;
        }
        /// <summary>
        /// 车牌号
        /// </summary>
        public String PlateNo { get; set; }
        /// <summary>
        /// 车辆ID
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public String Source { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public String AlarmType { get; set; }
        /// <summary>
        /// 报警源
        /// </summary>
        public String AlarmSource { get; set; }

        /// <summary>
        /// 报警时间
        /// </summary>
        public DateTime AlarmTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public String Status { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        public double Velocity { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public String Location { get; set; }
        /// <summary>
        /// 区域id
        /// </summary>
        public int AreaId { get; set; }
    }
}
