namespace VehicleVedioManage.Web.Models
{
    /// <summary>
    /// 租户
    /// </summary>
    [Serializable]
    public class TenantEntity
    {
        /// <summary>
        /// 租户ID
        /// </summary>
        public int TenantId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean Deleted { get; set; }
        /// <summary>
        /// 所有者
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 实体ID
        /// </summary>
        public int EntityId { get; set; }
    }
}