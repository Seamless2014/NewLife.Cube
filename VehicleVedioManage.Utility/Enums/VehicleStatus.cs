using System.ComponentModel;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 车辆状态
    /// </summary>
    public enum VehicleStatus
    {
        /// <summary>
        /// 0: 绿色 行驶 
        /// </summary>
        [Description("行驶")]
        RUNNING = 0,
        /// <summary>
        /// 1：红色 停车
        /// </summary>
        [Description("停车")]
        PARKING = 1,
        /// <summary>
        /// 2：紫色 卸料
        /// </summary>
        [Description("卸料")]
        UNLOADING = 2,
        /// <summary>
        /// 3：蓝色 卸过料
        /// </summary>
        [Description("已经卸过料")]
        UNLOADED = 3,
        /// <summary>
        /// 4:灰色 未定位
        /// </summary>
        [Description("离线")]
        OFFLINE = 4
    }

    /// <summary>
    /// 车辆的方向状态
    /// </summary>
    public enum LocationStatus
    {
        /// <summary>
        /// 离开工厂去工地中
        /// </summary>
        [Description("离开工厂去工地中")]
        LEAVING = 0,
        /// <summary>
        /// 离开工地返回工厂中
        /// </summary>
        [Description("离开工地返回工厂中")]
        RETURNING = 1,
        /// <summary>
        /// 在工地
        /// </summary>
        [Description("在工地")]
        ON_SITE = 2,
        /// <summary>
        /// 在工厂
        /// </summary>
        [Description("在工厂")]
        IN_FACTORY = 3,
        /// <summary>
        /// 休息或检测
        /// </summary>
        [Description("休息")]
        SLEEP = 4
    }
}
