using VehicleVedioManage.BasicData.Entity;

namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 基础数据服务
    /// </summary>
    public interface IBasicDataService
    {
        /// <summary>
        /// 获取基础数据
        /// </summary>
        /// <param name="code"></param>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        BasicInfo getBasicDataByCode(String code, String parentCode);

        /// <summary>
        /// 获取基础数据
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        List<BasicInfo> getBasicDataByParentCode(String parentCode);

        /// <summary>
        /// 保存基础数据
        /// </summary>
        /// <param name="bd"></param>
        void save(BasicInfo bd);

        /// <summary>
        /// 保存基础数据
        /// </summary>
        /// <param name="bdList"></param>
        void save(List<BasicInfo> bdList);

    }
}
