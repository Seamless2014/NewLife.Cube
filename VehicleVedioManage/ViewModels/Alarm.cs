using VehicleVedioManage.Web.Models;

namespace VehicleVedioManage.Web.ViewModels
{
    /// <summary>
    /// 报警
    /// </summary>
    [Serializable]
    public class Alarm : TenantEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Alarm()
        {
            CreateDate = DateTime.Now;
            ProcessedTime = DateTime.Now;
        }
        /// <summary>
        /// 车辆id
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string PlateNo { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public string AlarmType { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Descr { get; set; }
        /// <summary>
        /// 报警源
        /// </summary>
        public string AlarmSource { get; set; }
        /// <summary>
        /// 报警时间
        /// </summary>
        public DateTime AlarmTime { get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        public double Speed { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime ProcessedTime { get; set; }
        /// <summary>
        /// 处理人id
        /// </summary>
        public int ProcessedUserId { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        public string ProcessedUserName { get; set; }
        /// <summary>
        /// 确认序号
        /// </summary>
        public int AckSn { get; set; }
        /// <summary>
        /// 处理
        /// </summary>
        public int Processed { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public String tableName { get; set; }
    }
}
