using System.ComponentModel;

namespace VehicleVedioManage.Utility.Enums
{
    public enum RunStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        正常 =1,
        /// <summary>
        /// 维修
        /// </summary>
        [Description("维修")]
        维修 =2,
        /// <summary>
        /// 停运
        /// </summary>
        [Description("停运")]
        停运 =3,
        /// <summary>
        /// 报废
        /// </summary>
        [Description("报废")]
        报废 =4,
        /// <summary>
        /// 暂停监控
        /// </summary>
        [Description("暂停监控")]
        暂停监控 =5
    }
}
