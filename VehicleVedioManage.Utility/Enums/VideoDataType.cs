using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 数据类型
    /// </summary>
    public enum VideoDataType
    {
        /// <summary>
        /// 音视频
        /// </summary>
        [Description("音视频")]
        VIDEO_WITH_AUDIO,
        /// <summary>
        /// 视频
        /// </summary>
        [Description("视频")]
        VIDEO,
        /// <summary>
        /// 对讲
        /// </summary>
        [Description("对讲")]
        TALK ,
        /// <summary>
        /// 监听
        /// </summary>
        [Description("监听")]
        LISTEN,
        /// <summary>
        /// 广播
        /// </summary>
        [Description("广播")]
        BROADCAST,
        /// <summary>
        /// 透传
        /// </summary>
        [Description("透传")]
        TRANSPARENT_TRNSPORT,
        /// <summary>
        /// FTP
        /// </summary>
        [Description("FTP")]
        FTP,
        /// <summary>
        /// 回放
        /// </summary>
        [Description("回放")]
        PLAY_BACK,
    }
}
