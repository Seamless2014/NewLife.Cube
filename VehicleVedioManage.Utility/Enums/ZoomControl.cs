using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 变倍控制
    /// </summary>
    public enum ZoomControl:byte
    {
        /// <summary>
        /// 调大
        /// </summary>
        [Description("调大")]
        TurnUp,
        /// <summary>
        /// 调小
        /// </summary>
        [Description("调小")]
        Reduce
    }
}
