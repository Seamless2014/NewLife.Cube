namespace VehicleVedioManage.Web.ViewModels
{
    /// <summary>
    /// 报警统计项
    /// </summary>
    public class AlarmStaticItem
    {
        /// <summary>
        /// 报警来源
        /// </summary>
        public string AlarmSrc { get; set; }
        /// <summary>
        /// 子类型
        /// </summary>
        public string AlarmType { get; set; }
        /// <summary>
        /// 报警数量
        /// </summary>
        public int AlarmCount { get; set; }

    }
}
