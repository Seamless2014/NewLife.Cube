using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 焦距调整方向
    /// </summary>
    public enum AdjustFocusDirection:byte
    {
        /// <summary>
        /// 焦距调大
        /// </summary>
        [Description("焦距调大")]
        AdjustBig,
        /// <summary>
        /// 焦距调小
        /// </summary>
        [Description("焦距调小")]
        AdjustSmall, 
    }
}
