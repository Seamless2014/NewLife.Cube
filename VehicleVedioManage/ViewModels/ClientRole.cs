using VehicleVedioManage.Web.Models;
using XCode.Membership;

namespace VehicleVedioManage.Web.ViewModels
{
    /// <summary>
    /// 客户角色
    /// </summary>
    [Serializable]
    public class ClientRole
    {
        /// <summary>
        /// 
        /// </summary>
        public ClientRole()
        {
            FunctionList = new List<FuncModel>();
            DepList = new List<Department>();
        }
        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public Boolean Deleted { get; set; }
        /// <summary>
        /// 权限列表
        /// </summary>
        public List<FuncModel> FunctionList { get; set; }
        /// <summary>
        /// 部门列表
        /// </summary>
        public List<Department> DepList { get; set; }

    }
}
