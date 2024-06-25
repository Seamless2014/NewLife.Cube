using VehicleVedioManage.ReportStatistics.Entity;
using VehicleVedioManage.Utility.Extends;

namespace VehicleVedioManage.Web.Models
{
    public class AlarmRecordVM
    {
        /// <summary>
        /// 车辆ID
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string PlateNo { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string Location1 { get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        public double Velocity { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public double TimeSpan { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude1 { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude1 { get; set; }
        /// <summary>
        /// 驾驶员
        /// </summary>
        public string Driver { get; set; }
        /// <summary>
        /// 处理人ID
        /// </summary>
        public int Processed { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime ProcessedTime { get; set; }
        /// <summary>
        /// 报警源
        /// </summary>
        public string AlarmSource { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public string AlarmType { get; set; }
        /// <summary>
        /// 站点
        /// </summary>
        public int Station { get; set; }
        /// <summary>
        /// 标志
        /// </summary>
        public string Flag { get; set; }
        /// <summary>
        /// 视频文件名称
        /// </summary>
        public string VideoFileName { get; set; }
        /// <summary>
        /// 油气
        /// </summary>
        public double Gas1 { get; set; }
        /// <summary>
        /// 油气
        /// </summary>
        public double Gas2 { get; set; }
        /// <summary>
        /// 里程
        /// </summary>
        public double Mileage1 { get; set; }
        /// <summary>
        /// 里程
        /// </summary>
        public double Mileage2 { get; set; }
        /// <summary>
        /// 应答序号
        /// </summary>
        public int ResponseSn { get; set; }
        //报警的时候，Acc的状态
        public int Acc { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 报警记录
        /// </summary>
        /// <param name="rd"></param>
        /// <param name="alarmType"></param>
        /// <param name="alarmSource"></param>
        public AlarmRecordVM(GPSRealData rd, String alarmType, String alarmSource)
        {

            Latitude = rd.Latitude;
            Longitude = rd.Longitude;
            Location = rd.Location;
            PlateNo = rd.PlateNo;
            StartTime = rd.SendTime;
            AlarmType = alarmType;
            AlarmSource = alarmSource;
            Velocity = rd.Velocity;
            Status = AlarmRecordExtend.STATUS_NEW;
            VehicleId = rd.VehicleId;
            EndTime =StartTime;
            CreateTime = DateTime.Now;//
            ProcessedTime = DateTime.Now;
        }
    }

}
