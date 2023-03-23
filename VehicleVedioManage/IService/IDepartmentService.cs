using XCode.Membership;
namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 部门服务
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// 获取部门
        /// </summary>
        /// <param name="depId"></param>
        /// <returns></returns>
        Department getDepartment(int depId);
        /// <summary>
        /// 保存部门
        /// </summary>
        /// <param name="dep"></param>
        void saveDepartment(Department dep);
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="depId"></param>
        /// <returns></returns>
        List<int> getDepIdList(int depId);
    }
}
