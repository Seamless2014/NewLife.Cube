//using System.Collections;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 地图区域服务
//    /// </summary>
//    public class MapAreaService : IMapAreaService
//    {
//        /// <summary>
//        /// ORM
//        /// </summary>
//        public IBaseDao BaseDao { get; set; }
//        /// <summary>
//        /// 保存
//        /// </summary>
//        /// <param name="ec"></param>
//        public void saveOrUpdate(MapArea ec)
//        {
//            BaseDao.saveOrUpdate(ec);
//        }
//        /// <summary>
//        /// 保存路线
//        /// </summary>
//        /// <param name="ec"></param>
//        /// <param name="segments"></param>
//        public void saveRoute(MapArea ec, List<LineSegment> segments)
//        {
//            BaseDao.saveOrUpdate(ec);
//            foreach (LineSegment ls in segments)
//            {
//                ls.RouteId = (ec.EntityId);
//            }
//            BaseDao.saveOrUpdateAll(segments);
//            /**
//            int m = 0;
//            for (LineBufferPoint b : bufferPoints) {
//                LineSegment seg = segments.get(b.getNodeNo());
//                b.setEnclosureId(seg.getEntityId());
//            }
//            this.saveOrUpdateAll(bufferPoints);
//            */
//        }
//        /// <summary>
//        /// 获取线段
//        /// </summary>
//        /// <param name="enclosureId"></param>
//        /// <returns></returns>
//        public List<LineSegment> getLineSegments(int enclosureId)
//        {
//            String hql = "from LineSegment where routeId = ? and deleted = ?";
//            IList ls = (IList)BaseDao.query(hql, new Object[] {
//				enclosureId, false });

//            List<LineSegment> result = new List<LineSegment>();
//            foreach (LineSegment s in ls)
//            {
//                result.Add(s);
//            }

//            return result;
//        }

//        /// <summary>
//        /// 根据线路id,得到线路下面的所有分段限速线段
//        /// </summary>
//        /// <param name="routeId"></param>
//        /// <returns></returns>
//        public List<RouteSegment> getRouteSegments(int routeId)
//        {
//            String hql = "from RouteSegment where RouteId = ?";
//            IList ls = this.BaseDao.query(hql, new Object[] {
//				routeId });
//            List<RouteSegment> result = new List<RouteSegment>();
//            foreach (RouteSegment s in ls)
//            {
//                result.Add(s);
//            }
//            return result;
//        }

//    }
//}
