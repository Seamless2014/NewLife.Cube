using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 快进或者快退倍数
    /// </summary>
    public enum FastForwardMultiple:byte
    {
        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        Invalid,
        /// <summary>
        /// 1倍
        /// </summary>
        [Description("1倍")]
        OneMultiple,
        /// <summary>
        /// 2倍
        /// </summary>
        [Description("2倍")]
        TwoMultiple,
        /// <summary>
        /// 4倍
        /// </summary>
        [Description("4倍")]
        FourMultiple,
        /// <summary>
        /// 8倍
        /// </summary>
        [Description("8倍")]
        EightMultiple,
        /// <summary>
        /// 16倍
        /// </summary>
        [Description("16倍")]
        SixteenMultiple,
    }
}
