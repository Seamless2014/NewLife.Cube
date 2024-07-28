using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVideoManage.Video.ViewModel
{
    /// <summary>
    /// 视频请求消息
    /// </summary>
    public class VideoRequestMessage
    {
        /// <summary>
        /// 多媒体类型
        /// </summary>
        public int mediaType
        {
            get;
            set;
        }
        /// <summary>
        /// sim卡号
        /// </summary>
        public string simNo
        {
            get;
            set;
        }
        /// <summary>
        /// 通道号
        /// </summary>
        public int channelId
        {
            get;
            set;
        }
        /// <summary>
        /// 指令
        /// </summary>
        public string command
        {
            get;
            set;
        }
        /// <summary>
        /// 用户id
        /// </summary>
        public int userId
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createDate
        {
            get;
            set;
        }
    }
}
