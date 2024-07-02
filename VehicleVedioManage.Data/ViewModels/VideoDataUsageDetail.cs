namespace VehicleVedioManage.Data.ViewModels
{
    /// <summary>
    /// 视频数据使用情况详情
    /// </summary>
    public class VideoDataUsageDetail
    {
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// sim卡号
        /// </summary>
        public string SimNo
        {
            get;
            set;
        }
        /// <summary>
        /// 通道号
        /// </summary>
        public int ChannelId
        {
            get;
            set;
        }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime StartTime
        {
            get;
            set;
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime
        {
            get;
            set;
        }
        /// <summary>
        /// 使用情况
        /// </summary>
        public int DataUsage
        {
            get;
            set;
        }

        public DateTime UpdateDate
        {
            get;
            set;
        }

        public DateTime CreateDate
        {
            get;
            set;
        }
        /// <summary>
        /// 总时间
        /// </summary>
        public double TotalTime
        {
            get;
            set;
        }
        /// <summary>
        /// 使用类型
        /// </summary>
        public string UsageType
        {
            get;
            set;
        }

    }
}
