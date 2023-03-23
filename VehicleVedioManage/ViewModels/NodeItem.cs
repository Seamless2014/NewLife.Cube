namespace VehicleVedioManage.Web.ViewModels
{
    /// <summary>
    /// 节点项
    /// </summary>
    public class NodeItem
    {
        /// <summary>
        /// 节点id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 父节点id
        /// </summary>
        public int ParentId { get; set; }
    }
}