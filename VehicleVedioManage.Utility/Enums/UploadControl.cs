using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 上传控制
    /// </summary>
    public enum UploadControl:byte
    {
        /// <summary>
        /// 暂停
        /// </summary>
        [Description("暂停")]
        Pause,
        /// <summary>
        /// 继续
        /// </summary>
        [Description("继续")]
        Continue,
        /// <summary>
        /// 取消
        /// </summary>
        [Description("取消")]
        Cancel,
    }
}
