using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 编码类型
    /// </summary>
    public enum CodeCType
    {
        /// <summary>
        /// G711A
        /// </summary>
        [Description("G711A")]
        eG711A,
        /// <summary>
        /// G711U
        /// </summary>
        [Description("G711U")]
        eG711U,
        /// <summary>
        /// AAC
        /// </summary>
        [Description("AAC")]
        eAAC,
        /// <summary>
        /// Adpcm
        /// </summary>
        [Description("Adpcm")]
        eAdpcm,
        /// <summary>
        /// H264
        /// </summary>
        [Description("H264")]
        eH264,
        /// <summary>
        /// H265
        /// </summary>
        [Description("H265")]
        eH265,
        /// <summary>
        /// 不支持编码类型
        /// </summary>
        [Description("不支持数据类型")]
        eUnSupportCodingType,
    }
}
