using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using NewLife;
using NewLife.Log;
using VehicleVedioManage.BasicData.Entity;
using VehicleVedioManage.FenceManagement.Entity;
using VehicleVedioManage.ReportStatistics.Entity;
using VehicleVedioManage.Utility.Extends;
using VehicleVedioManage.Utility.MapService;
using VehicleVedioManage.Web.IService;
using VehicleVedioManage.Web.Models;
using XCode;

namespace VehicleVedioManage.Web.Service
{
    /// <summary>
    /// 电子围栏报警服务
    /// </summary>
    public class AreaAlarmService : IAreaAlarmService
    {
        /// <summary>
        /// 报警开
        /// </summary>
        public static string TURN_ON = "1";
        /// <summary>
        /// 报警关
        /// </summary>
        public static string TURN_OFF = "0";

        /// <summary>
        /// 偏离路线报警
        /// </summary>
        private Hashtable offsetRouteWarn = new Hashtable();
        /// <summary>
        /// 在路线上报警
        /// </summary>
        private Hashtable onRouteWarn = new Hashtable();
        /// <summary>
        /// 超速
        /// </summary>
        private Hashtable overSpeedMap = new Hashtable();
        /// <summary>
        /// 路线点
        /// </summary>
        public Hashtable routePointMap = new Hashtable();
        /// <summary>
        /// 报警
        /// </summary>
        public Hashtable alarmMap = new Hashtable();
        /// <summary>
        /// 终端报警服务
        /// </summary>
        public INewAlarmService NewAlarmService { get; set; }
        /// <summary>
        /// 查询服务
        /// </summary>
        public IQueryService QueryService { get; set; }
        /// <summary>
        /// 实时数据服务
        /// </summary>
        public IRealDataService RealDataService { get; set; }
        /// <summary>
        /// 区域信息
        /// </summary>
        public List<MapArea> AreaInfos = new List<MapArea>();
        /// <summary>
        /// 区域信息映射
        /// </summary>
        private ConcurrentDictionary<string, MapArea> AreaInfoMap = new ConcurrentDictionary<string, MapArea>();
        /// <summary>
        /// 报警状态映射
        /// </summary>
        public ConcurrentDictionary<string, String> alarmStateMap = new ConcurrentDictionary<string, String>();
        /// <summary>
        /// 实时数据映射
        /// </summary>
        public Dictionary<String, GPSRealData> realDataMap = new Dictionary<String, GPSRealData>();
        /// <summary>
        /// 报警项
        /// </summary>
        public ConcurrentQueue<AlarmItem> alarmItemQueue = new ConcurrentQueue<AlarmItem>();
        /// <summary>
        /// 是否继续
        /// </summary>
        private bool IsContinue = true;
        /// <summary>
        /// 处理线程
        /// </summary>
        private Thread processThread;
        /// <summary>
        /// 间隔
        /// </summary>
        public int Interval { get; set; }
        /// <summary>
        /// 是否区域报警
        /// </summary>
        public bool areaAlarmEnabled { get; set; }

        private readonly ITracer _tracer;
        public AreaAlarmService(ITracer tracer)
        {
            _tracer = tracer;
            Interval = 100;
        }

        /// <summary>
        /// 启动区域报警分析服务
        /// </summary>
        public void Start()
        {
            if (areaAlarmEnabled)
            {
                _tracer.NewSpan("Start", "启动区域报警分析服务");
                processThread = new Thread(new ThreadStart(ProcessAlarmThreadFunc));
                processThread.Start();
            }
        }


        /// <summary>
        /// 处理报警队列
        /// </summary>
        private void ProcessAlarmThreadFunc()
        {
            _tracer.NewSpan("ProcessAlarmThreadFunc", "处理报警队列");
            int k = 0;
            while (IsContinue)
            {
                try
                {
                    analyze();
                }
                catch (Exception ex)
                {
                    _tracer.NewSpan("ProcessAlarmThreadFunc", ex.Message);
                }

                k++;
                Thread.Sleep(Interval);
            }

        }

        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            IsContinue = false;
            processThread.Join();
        }

        /// <summary>
        /// 报警分析
        /// </summary>
        private void analyze()
        {
            Hashtable param = new Hashtable();
            DateTime d = DateTime.Now.AddMinutes(-5);
            param.Add("onlineDate", d);
            String queryId = "selectAllBindAreas";
            IList bindings = QueryService.QueryForList(queryId, param);
            Dictionary<int, MapArea> areaMap = new Dictionary<int, MapArea>();
            foreach (Hashtable eb in bindings)
            {
                int areaId = (int)eb["areaId"];
                int bindId = (int)eb["bindId"];
                String simNo = "" + eb["simNo"];
                String key = bindId + "_" + simNo;

                GPSRealData rd = RealDataService.Get(simNo);
                if (rd != null)
                {
                    GPSRealData oldRd = null;
                    if (realDataMap.ContainsKey(key))
                    {
                        oldRd = realDataMap[key];
                        //如果坐标没变化，没必要分析区域
                        if (oldRd.Latitude == rd.Latitude && oldRd.Longitude == rd.Longitude)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        oldRd = new GPSRealData();
                    }

                    oldRd.Latitude = (rd.Latitude);
                    oldRd.Longitude = (rd.Longitude);
                    realDataMap[key] = oldRd;
                    var exp = new WhereExpression();
                    exp &= MapArea._.AreaId == areaId;
                    exp &= MapArea._.Deleted == false;
                    var ec = MapArea.FindByWhereExpress(exp);

                    if (ec != null)
                    {
                        AnalyzeAreaAlarm(rd, ec);
                    }

                    /**
                    if (areaMap.ContainsKey(areaId) == false)
                    {
                        ec = (MapArea)this.BaseDao.load(typeof(MapArea), areaId);
                        areaMap[areaId] = ec;
                    }
                    else
                        ec = areaMap[areaId];
                    */
                }
            }
        }

        /// <summary>
        /// 分析区域报警
        /// </summary>
        /// <param name="rd"></param>
        /// <param name="ec"></param>
        private void AnalyzeAreaAlarm(GPSRealData rd, MapArea ec)
        {

            double lat = rd.Latitude;
            double lng = rd.Longitude;

            PointLatLng mp = new PointLatLng(rd.Latitude, rd.Longitude);

            if (String.IsNullOrEmpty(ec.Points))
                return;
            /**
            if (Constants.MAP_BAIDU.Equals(ec.MapType))
            {
                if (pointForBaidu == null)
                {
                    pointForBaidu = MapFix
                            .Fix(lng, lat, Constants.MAP_BAIDU);
                }
                mp = pointForBaidu;
            }
            else
            {

                if (pointForGoogle == null)
                {
                    pointForGoogle = MapFix
                            .Fix(lng,lat,
                            Constants.MAP_GOOGLE);
                }
                mp = pointForGoogle;
            }*/

            if (MapAreaExtend.ROUTE.Equals(ec.AreaType))
            {
                AnalyzeOffsetRoute(rd, ec, mp);
            }
            else
            {
                if (ec.KeyPoint == 1)
                {
                    if (ec.ByTime)
                        monitorKeyPointArrvie(rd, ec, mp);
                    else
                        monitorKeyPointLeave(rd, ec, mp); // 监控在规定的时间段内离开
                }
                else
                {
                    bool inMapArea = IsInArea(ec, mp);
                    CrossBorder(ec, rd, inMapArea);
                }
            }
        }

        /// <summary>
        /// 监控关键点到达
        /// </summary>
        /// <param name="rd"></param>
        /// <param name="ec"></param>
        /// <param name="mp"></param>
        private void monitorKeyPointArrvie(GPSRealData rd, MapArea ec,
                PointLatLng mp)
        {
            String alarmType = AlarmRecordExtend.TYPE_ARRIVE_NOT_ON_TIME;
            String alarmSource = AlarmRecordExtend.ALARM_FROM_PLATFORM;
            String key = rd.PlateNo + "_" + ec.AreaId + "_" + alarmType;
            AlarmItem item = (AlarmItem)alarmMap[key];

            DateTime now = DateTime.Now;
            if (now.CompareTo(ec.EndDate) <= 0)
            {
                if (item == null)
                {
                    bool inMapArea = this.IsInArea(ec, mp);
                    if (inMapArea)
                    {
                        _tracer.NewSpan("进入关键点:" + ec.Name);
                        item = new AlarmItem(rd, alarmType, alarmSource);
                        alarmMap[key] = item;
                    }
                }
            }
            else if (now.CompareTo(ec.EndDate) > 0)
            {
                if (item == null)
                {
                    bool inMapArea = IsInArea(ec, mp);
                    if (inMapArea == false)
                    {
                        insertAlarm(alarmSource, alarmType, rd, ec.Name);
                        // 第一次报警
                    }
                    else
                    {
                        item = new AlarmItem(rd, alarmType, alarmSource);
                        item.Status = (AlarmRecordExtend.STATUS_OLD);
                        alarmMap[key] = item;
                    }
                }
            }

        }

        /// <summary>
        /// 监控关键点离开
        /// </summary>
        /// <param name="rd"></param>
        /// <param name="ec"></param>
        /// <param name="mp"></param>
        private void monitorKeyPointLeave(GPSRealData rd, MapArea ec,
                PointLatLng mp)
        {
            String alarmSource = AlarmRecordExtend.ALARM_FROM_PLATFORM;
            String alarmType = AlarmRecordExtend.TYPE_LEAVE_NOT_ON_TIME;
            String key = rd.PlateNo + "_" + ec.AreaId + "_" + alarmType;
            AlarmItem item = (AlarmItem)alarmMap[key];
            DateTime now = DateTime.Now;
            if (now.CompareTo(ec.StartDate) < 0
                    && now.CompareTo(ec.EndDate) > 0)
            {

                if (item == null)
                {
                    // 判断是否在规定的时间离开关键点
                    bool inMapArea = IsInArea(ec, mp);
                    if (inMapArea)
                    {
                        insertAlarm(alarmSource, alarmType, rd, ec.Name);
                    }
                    else
                    {
                        // 关闭报警
                        item = new AlarmItem(rd, alarmType, alarmSource);
                        // item.setOpen(false);
                        alarmMap[key] = item;
                    }
                }
            }

        }

        /// <summary>
        /// 判断是否在区域内
        /// </summary>
        /// <param name="ec"></param>
        /// <param name="mp"></param>
        /// <returns></returns>
        public bool IsInArea(MapArea ec, PointLatLng mp)
        {

            List<PointLatLng> points = ec.GetNodes();

            if (ec.AreaType == MapAreaExtend.POLYGON && points.Count > 2)
            {
                return MapFix.IsInPolygon(mp, points);
            }
            else if (ec.AreaType == MapAreaExtend.CIRCLE && points.Count > 0)
            {
                PointLatLng pl = points[0];
                double radius = ec.Radius;
                return MapFix.IsInCircle(mp, pl, radius);
            }
            else if (ec.AreaType == MapAreaExtend.RECT && points.Count > 1)
            {
                PointLatLng p1 = points[0];
                PointLatLng p2 = points[2];

                return MapFix.IsInRect(mp.Lng, mp.Lat, p1.Lng, p1.Lat, p2.Lng, p2.Lat);
            }

            return false;
        }

        /// <summary>
        /// 分析偏离路线
        /// </summary>
        /// <param name="rd"></param>
        /// <param name="ec"></param>
        /// <param name="mp"></param>
        public void AnalyzeOffsetRoute(GPSRealData rd, MapArea ec, PointLatLng mp)
        {
            //Date start = new Date();
            String alarmType = AlarmRecordExtend.TYPE_OFFSET_ROUTE;
            String alarmSource = AlarmRecordExtend.ALARM_FROM_PLATFORM;
            int maxAllowedOffsetTime = ec.OffsetDelay; // 最长偏移时间

            // 判断是否在班线中
            LineSegment seg = IsInLineSegment(mp, ec);
            bool isOnRoute = seg != null;
            _tracer.NewSpan(rd.PlateNo + ",班线" + ec.Name + ","
                    + (seg == null ? "偏移" : "在路线上") + rd.SendTime);
            String alarmKey = rd.PlateNo + "_" + ec.AreaId;
            AlarmItem offsetAlarm = (AlarmItem)offsetRouteWarn[alarmKey];
            AlarmItem onRouteAlarm = (AlarmItem)onRouteWarn[alarmKey];
            if (isOnRoute == false)
            {
                if (offsetAlarm == null)
                {
                    AnalyzeOverSpeed(rd, null, ec);
                    offsetAlarm = new AlarmItem(rd, alarmType, alarmSource);
                    offsetRouteWarn[alarmKey] = offsetAlarm;
                    offsetAlarm.Status = ("");
                }
                DateTime offsetTime = offsetAlarm.AlarmTime;
                TimeSpan span = rd.SendTime - offsetTime;
                double ts = span.TotalSeconds;
                if (ts > maxAllowedOffsetTime
                        && offsetAlarm.Status.Equals(""))
                {
                    offsetAlarm.Status = (AlarmRecordExtend.STATUS_NEW); // 设置为报警状态
                    this.insertAlarm(alarmSource, alarmType, rd, ec.Name);
                    DateTime originTime = rd.SendTime;
                    rd.SendTime = (offsetTime);
                    AlarmRecord sr = this.CreateAreaAlarmRecord(
                            AlarmRecordExtend.ALARM_FROM_PLATFORM,
                            AlarmRecordExtend.TYPE_OFFSET_ROUTE, TURN_ON, rd,
                            ec.AreaId, ec.Name);
                    // 关闭进入线路报警记录
                    sr = CreateAreaAlarmRecord(AlarmRecordExtend.ALARM_FROM_PLATFORM,
                            AlarmRecordExtend.TYPE_ON_ROUTE, TURN_OFF, rd,
                            ec.AreaId, ec.Name);
                    rd.SendTime = (originTime);
                    onRouteWarn.Remove(alarmKey);
                }

            }
            else
            {
                AnalyzeOverSpeed(rd, seg, ec);
                if (offsetAlarm != null)
                {
                    offsetAlarm.Status = (AlarmRecordExtend.STATUS_OLD);// 报警关闭
                    _tracer.NewSpan(rd.PlateNo + "重回路线," + rd.SendTime);
                    CreateAreaAlarmRecord(AlarmRecordExtend.ALARM_FROM_PLATFORM,
                            AlarmRecordExtend.TYPE_OFFSET_ROUTE, TURN_OFF, rd,
                            ec.AreaId, ec.Name);
                    offsetRouteWarn.Remove(alarmKey);
                }
                if (onRouteAlarm == null)
                {
                    onRouteAlarm = new AlarmItem(rd, AlarmRecordExtend.TYPE_ON_ROUTE,
                            alarmSource);
                    onRouteWarn[alarmKey] = onRouteAlarm;
                    AlarmRecord sr = CreateAreaAlarmRecord(
                            AlarmRecordExtend.ALARM_FROM_PLATFORM,
                            AlarmRecordExtend.TYPE_ON_ROUTE, TURN_ON, rd,
                            ec.AreaId, ec.Name);
                }
            }

        }

        /// <summary>
        /// 判断是否在限速路段
        /// </summary>
        /// <param name="pointId"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        private RouteSegment isInLimitSpeedRouteSegment(int pointId, MapArea route)
        {
            int routeId = route.AreaId;
            var exp = new WhereExpression();
            exp &= RouteSegment._.RouteId == routeId;
            exp &= RouteSegment._.StartSegId <= pointId;
            exp |= RouteSegment._.EndSegId >= pointId+1;
            RouteSegment rs = RouteSegment.FindByWhereExpress(exp);
            return rs;
        }
        /// <summary>
        /// 分析超速报警
        /// </summary>
        /// <param name="rd"></param>
        /// <param name="seg"></param>
        /// <param name="ec"></param>
        private void AnalyzeOverSpeed(GPSRealData rd, LineSegment seg, MapArea ec)
        {
            String key = rd.PlateNo;
            AlarmItem alarmItem = (AlarmItem)overSpeedMap[key];

            if (seg == null && alarmItem != null)
            {
                this.overSpeedMap.Remove(key);
                this.CreateAreaAlarmRecord(AlarmRecordExtend.ALARM_FROM_PLATFORM,
                        AlarmRecordExtend.TYPE_OVER_SPEED_ON_ROUTE, TURN_OFF, rd,
                        alarmItem.AreaId, null);
            }

            if (seg == null)
                return;

            _tracer.NewSpan("分段限速检测:" + ec.Name + ",拐点:" + seg.PointId);
            RouteSegment rs = this.isInLimitSpeedRouteSegment(seg.PointId, ec);
            if (rs == null)
                return;

            _tracer.NewSpan("进入分段，线路:" + ec.Name + ",分段:" + rs.Name + "，车速:"
                    + rd.Velocity);
            if (rd.Velocity > rs.MaxSpeed)
            {
                double alarmDelay = 0;
                if (alarmItem != null)
                {
                    DateTime offsetTime = alarmItem.AlarmTime;
                    TimeSpan ts = rd.SendTime - offsetTime;
                    alarmDelay = ts.TotalSeconds;

                }
                else
                {
                    alarmItem = new AlarmItem(rd, AlarmRecordExtend.ALARM_FROM_PLATFORM,
                            AlarmRecordExtend.TYPE_OVER_SPEED_ON_ROUTE);
                    alarmItem.Status = (AlarmRecordExtend.STATUS_NEW);
                    alarmItem.AreaId = ec.AreaId;
                    overSpeedMap[key] = alarmItem;
                }
                if (alarmDelay >= rs.Delay)
                {
                    _tracer.NewSpan("分段超速报警，线路:" + ec.Name + ",分段:"+ rs.Name + "，车速:" + rd.Velocity);
                    insertAlarm(AlarmRecordExtend.ALARM_FROM_PLATFORM,
                            AlarmRecordExtend.TYPE_OVER_SPEED_ON_ROUTE, rd, ec.Name+ ",分段点:" + rs.Name);
                    if (AlarmRecordExtend.STATUS_NEW.Equals(alarmItem.Status))
                    {
                        // 第一次报警
                        CreateAreaAlarmRecord(AlarmRecordExtend.ALARM_FROM_PLATFORM,
                                AlarmRecordExtend.TYPE_OVER_SPEED_ON_ROUTE, TURN_ON, rd,seg.SegId,ec.Name + ",路段:" + seg.Name);
                        alarmItem.Status = (AlarmRecordExtend.STATUS_OLD);
                        // this.overSpeedMap.put(key, rs);
                    }
                }

            }
            else
            {
                if (alarmItem != null)
                {
                    // 报警消除
                    this.overSpeedMap.Remove(key);
                    CreateAreaAlarmRecord(AlarmRecordExtend.ALARM_FROM_PLATFORM,
                            AlarmRecordExtend.TYPE_OVER_SPEED_ON_ROUTE, TURN_OFF, rd,seg.SegId, null);
                }
            }

        }
        /// <summary>
        /// 获取线段列表
        /// </summary>
        /// <param name="RouteId"></param>
        /// <returns></returns>
        private List<LineSegment> GetLineSegments(int RouteId)
        {
            var exp = new WhereExpression();
            exp &= LineSegment._.RouteId== RouteId;
            List<LineSegment> result = LineSegment.FindAllByWhereExpress(exp).OrderBy(e => e.PointId).ToList();
            return result;
        }


        /// <summary>
        /// 判断是否在班线中
        /// </summary>
        /// <param name="mp"></param>
        /// <param name="ec"></param>
        /// <returns></returns>
        private LineSegment IsInLineSegment(PointLatLng mp, MapArea ec)
        {
            List<LineSegment> segments = GetLineSegments(ec.AreaId);
            LineSegment prevSegment = null;
            foreach (LineSegment seg in segments)
            {
                if (prevSegment != null && (prevSegment.Latitude1 != seg.Latitude1 || prevSegment.Longitude1 != seg.Longitude1))
                {
                    MapFix mapFix = new MapFix(_tracer);
                    PointLatLng p1 = mapFix.Reverse(prevSegment.Longitude1,
                            prevSegment.Latitude1, ec.MapType);
                    PointLatLng p2 = mapFix.Reverse(seg.Longitude1,
                            seg.Latitude1, ec.MapType);

                    Boolean result = MapFix.isPointOnRouteSegment(p1, p2,
                            mp, seg.LineWidth);
                    if (result)
                        return seg;
                }
                prevSegment = seg;
            }
            return null;
        }

        /// <summary>
        /// 判断是否在路上
        /// </summary>
        /// <param name="rd"></param>
        /// <returns></returns>
        public bool IsInRoute(GPSRealData rd)
        {
            DateTime start = DateTime.Now;
            var exp = new WhereExpression();
            if (!rd.PlateNo.IsNullOrEmpty()) exp &= VehicleRoute._.PlateNo == rd.PlateNo;
            var vd = VehicleRoute.FindByWhereExpress(exp);

            if (vd == null || string.IsNullOrEmpty(vd.Routes))
                return true;

            bool result = false;

            double lat = rd.Latitude;
            double lng = rd.Longitude;

            PointLatLng mp = new PointLatLng(lat, lng);
            string[] routeIds = vd.Routes.Split(',');
            foreach (string strRouteId in routeIds)
            {
                if (string.IsNullOrEmpty(strRouteId) == false)
                {
                    int routeId = int.Parse(strRouteId);
                    //List<PointLatLng> bps = GetBufferPoints(routeId);

                    //result = MapFix.IsInPolygon(mp, bps);
                    if (result)
                        return result;
                }
            }
            TimeSpan ts = DateTime.Now - start;
            if (ts.TotalSeconds > 0.2)
                _tracer.NewSpan("偏移计算耗时:" + ts.TotalSeconds);
            return result;
        }


        /// <summary>
        /// 获取旧得区域信息
        /// </summary>
        /// <param name="plateNo"></param>
        /// <returns></returns>
        private MapArea getOldAreaInfo(string plateNo)
        {
            MapArea oldEc = null;
            if (AreaInfoMap.ContainsKey(plateNo))
            {
                oldEc = AreaInfoMap[plateNo];
            }
            return oldEc;
        }
        /// <summary>
        /// 写入终端报警
        /// </summary>
        /// <param name="alarmSource"></param>
        /// <param name="alarmType"></param>
        /// <param name="rd"></param>
        /// <param name="areaName"></param>

        private void insertAlarm(String alarmSource, String alarmType,
                GPSRealData rd, String areaName)
        {
            rd.Location = ("区域:" + areaName);
            this.NewAlarmService.insertAlarm(alarmSource, alarmType, rd);
        }

        /// <summary>
        /// 跨境(跨区域)
        /// </summary>
        /// <param name="ec"></param>
        /// <param name="rd"></param>
        /// <param name="isInMapArea"></param>
        private void CrossBorder(MapArea ec, GPSRealData rd, bool isInMapArea)
        {
            MapArea oldEc = getOldAreaInfo(rd.PlateNo);

            if (isInMapArea && (oldEc == null || oldEc.AreaId != ec.AreaId))
            {
                //说明进入一个新的围栏
                AreaInfoMap[rd.PlateNo] = ec;
                insertAlarm(AlarmRecordExtend.ALARM_FROM_PLATFORM,
                         AlarmRecordExtend.TYPE_IN_AREA, rd, ec.Name);
                CreateAreaAlarmRecord(AlarmRecordExtend.ALARM_FROM_PLATFORM, AlarmRecordExtend.TYPE_IN_AREA, AlarmRecordExtend.TURN_ON, rd, ec.AreaId, ec.Name);
                //CreateAreaAlarmRecord(AlarmRecord.ALARM_FROM_PLATFORM, AlarmRecord.TYPE_CROSS_BORDER, AlarmRecord.TURN_OFF, rd, ec);
                //CheckAreaInfoGather();//检测聚集
            }
            else if (isInMapArea == false && oldEc != null)
            {
                bool res = AreaInfoMap.TryRemove(rd.PlateNo, out oldEc);
                if (res == false)
                {
                    _tracer.NewSpan("删除围栏报警集合失败");
                }
                insertAlarm(AlarmRecordExtend.ALARM_FROM_PLATFORM,
                     AlarmRecordExtend.TYPE_CROSS_BORDER, rd, ec.Name);
                CreateAreaAlarmRecord(AlarmRecordExtend.ALARM_FROM_PLATFORM, AlarmRecordExtend.TYPE_IN_AREA, AlarmRecordExtend.TURN_OFF, rd, oldEc.AreaId, oldEc.Name);
                //CreateAreaAlarmRecord(AlarmRecord.ALARM_FROM_PLATFORM, AlarmRecord.TYPE_CROSS_BORDER, AlarmRecord.TURN_ON, rd, oldEc);
                _tracer.NewSpan(rd.PlateNo + "离开围栏" + oldEc.Name + ",系统开始重新计算聚集");

            }

        }
        /// <summary>
        /// 创建区域报警记录
        /// </summary>
        /// <param name="AlarmSrc"></param>
        /// <param name="AlarmType"></param>
        /// <param name="alarmState"></param>
        /// <param name="rd"></param>
        /// <param name="areaId"></param>
        /// <param name="areaName"></param>
        /// <returns></returns>
        private AlarmRecord CreateAreaAlarmRecord(string AlarmSrc, string AlarmType, string alarmState, GPSRealData rd, int areaId, String areaName)
        {
            string hsql = "from AlarmRecord rec where rec.PlateNo = ? and rec.Status = ?" +
            " and rec.AlarmSource = ? and rec.AlarmType = ? and Station = ?";
            var exp = new WhereExpression();
           if(!rd.PlateNo.IsNullOrEmpty()) exp &= AlarmRecord._.PlateNo == rd.PlateNo;
           if (!AlarmSrc.IsNullOrEmpty()) exp &= AlarmRecord._.AlarmSource == AlarmSrc;
           if (!AlarmType.IsNullOrEmpty()) exp &= AlarmRecord._.AlarmType == AlarmType;
            exp &= AlarmRecord._.Status == AlarmRecordExtend.STATUS_NEW;
            exp &= AlarmRecord._.Station == "" + areaId;
            var ec = MapArea.FindByWhereExpress(exp);
            //查看是否有未消除的报警记录
            AlarmRecord sr = AlarmRecord.FindAllByWhereExpress(exp);

            if (sr == null)
            {
                if (alarmState == AlarmRecordExtend.TURN_OFF)
                    return null;

                sr = new AlarmRecord();
                sr.Station = areaId;
                sr.PlateNo = rd.PlateNo;
                sr.StartTime = rd.SendTime;
                sr.Status = AlarmRecordExtend.STATUS_NEW;
                sr.EndTime = System.DateTime.Now;
                sr.Latitude = rd.Latitude;
                sr.Longitude = rd.Longitude;
                MapFix mapFix = new MapFix(_tracer);
                sr.Location = mapFix.GetLocation(sr.Longitude, sr.Latitude);
                sr.Velocity = rd.Velocity;
                sr.Location = areaName;
            }
            else
            {
                sr.EndTime = System.DateTime.Now;
                TimeSpan t = rd.SendTime - sr.StartTime;
                sr.TimeSpan = t.TotalMinutes;
                if (alarmState == AlarmRecordExtend.TURN_OFF)
                {
                    sr.Status = AlarmRecordExtend.STATUS_OLD;
                    sr.EndTime = rd.SendTime;

                    sr.Latitude1 = rd.Latitude;
                    sr.Longitude1 = rd.Longitude;
                }
                else
                    return null;
            }

            if (sr != null)
            {
                sr.AlarmSource = AlarmSrc;
                sr.AlarmType = AlarmType;
                sr.Upsert();
            }
            return sr;
        }
    }
}
