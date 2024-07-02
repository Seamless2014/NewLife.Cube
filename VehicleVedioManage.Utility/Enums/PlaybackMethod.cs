using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 回放方式
    /// </summary>
    public enum PlaybackMethod:byte
    {
        /// <summary>
        /// 正常回放
        /// </summary>
        [Description("正常回放")]
        Normal,
        /// <summary>
        /// 快速回放
        /// </summary>
        [Description("快速回放")]
        FastForwardPlayback,
        /// <summary>
        /// 关键帧快退回放
        /// </summary>
        [Description("关键帧快退回放")]
        FastRewindPlayback,
        /// <summary>
        /// 关键帧播放
        /// </summary>
        [Description("关键帧播放")]
        Play,
        /// <summary>
        /// 单帧上传
        /// </summary>
        [Description("单帧上传")]
        SingleFrameUpload
    }
}
