namespace VehicleVedioManage.Web.ViewModels
{
    /// <summary>
    /// 区域绑定信息
    /// </summary>
    [Serializable]
    public class AreaBindingInfo
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public String PlateNo { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public String DepName { get; set; }
        /// <summary>
        /// 指令状态
        /// </summary>
        public String CommandStatus { get; set; }
        /// <summary>
        /// 配置类型
        /// </summary>
        public int ConfigType { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// 绑定Id
        /// </summary>
        public int BindId { get; set; }
        /// <summary>
        /// 车辆id
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public int DepId { get; set; }
        /// <summary>
        /// 区域id
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public String AreaName { get; set; }
        /// <summary>
        /// 区域类型
        /// </summary>
        public String AreaType { get; set; }
        /// <summary>
        /// 绑定类型
        /// </summary>
        public String BindingType { get; set; }


    }
}