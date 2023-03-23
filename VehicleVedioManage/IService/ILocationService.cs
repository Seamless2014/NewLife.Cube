using System;
namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 坐标转换成位置信息服务
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// 根据坐标转换成位置信息
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        string GetLocation(double lng, double lat, string type = "wgs84ll");
    }
}
