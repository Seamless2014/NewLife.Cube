using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 云台控制
    /// </summary>
    public enum CloudDirection:byte
    {
        /// <summary>
        /// 停止
        /// </summary>
        [Description("停止")]
        Stop,
        /// <summary>
        /// 上
        /// </summary>
        [Description("上")]
        Up,
        /// <summary>
        /// 下
        /// </summary>
        [Description("下")]
        Down,
        /// <summary>
        /// 左
        /// </summary>
        [Description("左")]
        Left,
        /// <summary>
        /// 右
        /// </summary>
        [Description("右")]
        Right,
    }
}
