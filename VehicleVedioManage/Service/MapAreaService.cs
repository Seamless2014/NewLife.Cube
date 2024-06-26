using System.Collections;
using VehicleVedioManage.FenceManagement.Entity;
using VehicleVedioManage.Web.IService;
using XCode;

namespace VehicleVedioManage.Web.Service
{
    /// <summary>
    /// 地图区域服务
    /// </summary>
    public class MapAreaService : IMapAreaService
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="ec"></param>
        public void saveOrUpdate(MapArea ec)
        {
            ec.Update();
        }
        /// <summary>
        /// 保存路线
        /// </summary>
        /// <param name="ec"></param>
        /// <param name="segments"></param>
        public void saveRoute(MapArea ec, List<LineSegment> segments)
        {
            ec.Update();
            foreach (LineSegment ls in segments)
            {
                ls.RouteId = (ec.AreaId);
            }
            segments.Insert();
            /**
            int m = 0;
            for (LineBufferPoint b : bufferPoints) {
                LineSegment seg = segments.get(b.getNodeNo());
                b.setEnclosureId(seg.getEntityId());
            }
            this.saveOrUpdateAll(bufferPoints);
            */
        }
        /// <summary>
        /// 获取线段
        /// </summary>
        /// <param name="enclosureId"></param>
        /// <returns></returns>
        public List<LineSegment> getLineSegments(int enclosureId)
        {
            var exp = new WhereExpression();
            exp &= LineSegment._.RouteId == enclosureId;
            exp &= LineSegment._.Deleted == false;
            var ls = LineSegment.FindAllByWhereExpress(exp);
            var result = new List<LineSegment>();
            foreach (var s in ls)
            {
                result.Add(s);
            }

            return result;
        }

        /// <summary>
        /// 根据线路id,得到线路下面的所有分段限速线段
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public List<RouteSegment> getRouteSegments(int routeId)
        {
            var exp = new WhereExpression();
            exp &= RouteSegment._.RouteId == routeId;
            var ls = RouteSegment.FindAllByWhereExpress(exp);
            var result = new List<RouteSegment>();
            foreach (RouteSegment s in ls)
            {
                result.Add(s);
            }
            return result;
        }
        List<LineSegment> IMapAreaService.getLineSegments(Int32 enclosureId) => throw new NotImplementedException();
        List<RouteSegment> IMapAreaService.getRouteSegments(Int32 routeId) => throw new NotImplementedException();
    }
}
