using VehicleVedioManage.Web.Models;

namespace VehicleVedioManage.Web.ViewModels
{
    /// <summary>
    /// 客户端用户
    /// </summary>
    [Serializable]
    public class ClientUser
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 租户Id
        /// </summary>
        public int TenantId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 登录名称
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int DepId { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public String RoleName { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 退出时间
        /// </summary>
        public DateTime LogoutTime { get; set; }
        /// <summary>
        /// 地图中心纬度
        /// </summary>
        public double MapCenterLat { get; set; }
        /// <summary>
        /// 地图中心经度
        /// </summary>
        public double MapCenterLng { get; set; }
        /// <summary>
        /// 地图层级
        /// </summary>
        public int MapLevel { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public List<FuncModel> Permissions { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserType { get; set; }
        /// <summary>
        /// 客户端角色
        /// </summary>
        public List<ClientRole> Roles { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public Boolean Deleted { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ClientUser()
        {
            Roles = new List<ClientRole>();
            Permissions = new List<FuncModel>();
        }
    }
}
