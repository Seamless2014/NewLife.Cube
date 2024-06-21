using System.ComponentModel;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 车辆类型
    /// </summary>
    public enum VehicleType
    {
        /// <summary>
        /// 小汽车/轿车
        /// </summary>
        [Description("轿车")]
        轿车 = 14,
        /// <summary>
        /// 小型客车
        /// </summary>
        [Description("小型客车")]
        小型客车 = 13,
        /// <summary>
        /// 中型客车
        /// </summary>
        [Description("中型客车")]
        中型客车 = 12,
        /// <summary>
        /// 大型客车
        /// </summary>
        [Description("大型客车")]
        大型客车 = 11,
        /// <summary>
        /// 普通货车
        /// </summary>
        [Description("普通货车")]
        普通货车 = 21,
        /// <summary>
        /// 危险品运输车
        /// </summary>
        [Description("危险品运输车")]
        危险品运输车 = 41
    }
}
