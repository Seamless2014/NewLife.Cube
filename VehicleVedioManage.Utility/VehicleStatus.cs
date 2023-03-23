namespace VehicleVedioManage.Utility
{
    /// <summary>
    /// 车辆状态
    /// </summary>
    public enum VehicleStatus
    {
        /// <summary>
        /// 0: 绿色 行驶 
        /// </summary>
        RUNNING = 0,
        /// <summary>
        /// 1：红色 停车
        /// </summary>
        PARKING = 1,
        /// <summary>
        /// 2：紫色 卸料
        /// </summary>
        UNLOADING = 2,
        /// <summary>
        /// 3：蓝色 卸过料
        /// </summary>
        UNLOADED = 3,
        /// <summary>
        /// 4:灰色 未定位
        /// </summary>
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
        LEAVING = 0,
        /// <summary>
        /// 离开工地返回工厂中
        /// </summary>
        RETURNING = 1,
        /// <summary>
        /// 在工地
        /// </summary>
        ON_SITE = 2,
        /// <summary>
        /// 在工厂
        /// </summary>
        IN_FACTORY = 3,
        /// <summary>
        /// 休息或检测
        /// </summary>
        SLEEP = 4
    }
}
