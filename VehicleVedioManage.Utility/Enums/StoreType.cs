using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 存储类型
    /// </summary>
    public enum StoreType:byte
    {
        /// <summary>
        /// 所有存储器
        /// </summary>
        [Description("所有存储器")]
        All,
        /// <summary>
        /// 主存储器
        /// </summary>
        [Description("主存储器")]
        MainStore,
        /// <summary>
        /// 灾备存储器
        /// </summary>
        [Description("灾备存储器")]
        DisasterRecovery,
    }
}
