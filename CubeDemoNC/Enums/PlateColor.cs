using System.ComponentModel;

namespace GPSPlatform.Enums
{
    /// <summary>
    /// 车牌颜色枚举
    /// </summary>
    public enum PlateColor
    {
        /// <summary>
        /// 蓝色
        /// </summary>
        [Description("蓝色")]
        蓝色=1,
        /// <summary>
        /// 黄色
        /// </summary>
        [Description("黄色")]
        黄色=2,
        /// <summary>
        /// 黑色
        /// </summary>
        [Description("黑色")]
        黑色 =3,
        /// <summary>
        /// 白色
        /// </summary>
        [Description("白色")]
        白色 =4,
        /// <summary>
        /// 绿色
        /// </summary>
        [Description("绿色")]
        绿色 =5,
        /// <summary>
        /// 未输入
        /// </summary>
        [Description("未录入")]
        未录入 =0
    }
}
