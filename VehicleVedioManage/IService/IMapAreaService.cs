using VehicleVedioManage.FenceManagement.Entity;
namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 地图区域服务
    /// </summary>
    public  interface IMapAreaService
    {
        /// <summary>
        /// 保存路线
        /// </summary>
        /// <param name="ec"></param>
        /// <param name="segments"></param>
        void saveRoute(MapArea ec, List<LineSegment> segments);
        /// <summary>
        /// 获取线路线段
        /// </summary>
        /// <param name="enclosureId"></param>
        /// <returns></returns>
        List<LineSegment> getLineSegments(int enclosureId);
        /// <summary>
        /// 获取路段
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        List<RouteSegment> getRouteSegments(int routeId);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="ec"></param>
        void saveOrUpdate(MapArea ec);
	
    }
}
