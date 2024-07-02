using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 码流类型
    /// </summary>
    public enum BitStreamType:byte
    {
        /// <summary>
        /// 所有码流
        /// </summary>
        [Description("所有码流")]
        AllBitStream,
        /// <summary>
        /// 主码流
        /// </summary>
        [Description("主码流")]
        MainBitStream,
        /// <summary>
        /// 子码流
        /// </summary>
        [Description("子码流")]
        SubBitStream,
        /// <summary>
        /// 主码流或者子码流
        /// </summary>
        [Description("主码流或子码流")]
        MainOrSubStream,
    }
}
