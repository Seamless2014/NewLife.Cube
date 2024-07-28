using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 视频请求类型
    /// </summary>
    public enum VideoRequestType
    {
        /// <summary>
        /// 播放
        /// </summary>
        [Description("播放")]
        PLAY,
        /// <summary>
        /// 停止
        /// </summary>
        [Description("停止")]
        STOP,
    }
}
