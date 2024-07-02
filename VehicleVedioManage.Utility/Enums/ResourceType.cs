using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 音视频资源类型
    /// </summary>
    public enum ResourceType:byte
    {
        /// <summary>
        /// 音视频
        /// </summary>
        [Description("音视频")]
        AudioAndVideo,
        /// <summary>
        /// 音频
        /// </summary>
        [Description("音频")]
        Audio,
        /// <summary>
        /// 视频
        /// </summary>
        [Description("视频")]
        Video,
        /// <summary>
        /// 视频或音频
        /// </summary>
        [Description("视频或者音频")]
        VideoOrAudio,
    }
}
