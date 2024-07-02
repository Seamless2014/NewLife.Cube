using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 响应结果
    /// </summary>
    public enum ResponseResult:byte
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail,
        /// <summary>
        /// 不支持
        /// </summary>
        [Description("不支持")]
        UpSupport,
        /// <summary>
        /// 会话结束
        /// </summary>
        [Description("会话结束")]
        SessionEnd,
        /// <summary>
        /// 时效口令错误
        /// </summary>
        [Description("时效口令错误")]
        PasswordError,
        /// <summary>
        /// 不满足跨域条件
        /// </summary>
        [Description("不满足跨域条件")]
        NotCross,
    }
}
