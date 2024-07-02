using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 启停标识
    /// </summary>
    public enum StartStopFlag:byte
    {
        /// <summary>
        /// 停止
        /// </summary>
        [Description("停止")]
        Stop,
        /// <summary>
        /// 启动
        /// </summary>
        [Description("启动")]
        Start,
    }
}
