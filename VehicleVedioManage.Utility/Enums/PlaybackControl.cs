using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 回放控制
    /// </summary>
    public enum PlaybackControl
    {
        /// <summary>
        /// 开始播放
        /// </summary>
        [Description("开始播放")]
        StartPlayback,
        /// <summary>
        /// 暂停播放
        /// </summary>
        [Description("暂停播放")]
        PausePlayback,
        /// <summary>
        /// 结束播放
        /// </summary>
        [Description("结束播放")]
        EndPlayback,
        /// <summary>
        /// 快进播放
        /// </summary>
        [Description("快进播放")]
        FastForwardPlayback,
        /// <summary>
        /// 关键帧快退播放
        /// </summary>
        [Description("关键帧快退播放")]
        KeyframeFastRewindPlayback,
        /// <summary>
        /// 拖动播放
        /// </summary>
        [Description("拖动播放")]
        DragPlayback,
        /// <summary>
        /// 关键帧播放
        /// </summary>
        [Description("关键帧播放")]
        KeyframePlayback
    }
}
