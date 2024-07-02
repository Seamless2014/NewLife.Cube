using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 流类型
    /// </summary>
    public enum StreamType
    {
        /// <summary>
        /// 视频I帧
        /// </summary>
        [Description("视频I帧")]
        eVideoI,
        /// <summary>
        /// 视频P帧
        /// </summary>
        [Description("视频P帧")]
        eVideoP,
        /// <summary>
        /// 视频B帧
        /// </summary>
        [Description("视频B帧")]
        eVideoB,
        /// <summary>
        /// 音频
        /// </summary>
        [Description("音频")]
        eAudio,
        /// <summary>
        /// 透传
        /// </summary>
        [Description("透传")]
        ePassthrough,
        /// <summary>
        /// 不支持类型
        /// </summary>
        [Description("不支持数据类型")]
        eUnSupportDataType,
    }
}
