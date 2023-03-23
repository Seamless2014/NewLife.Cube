//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using GpsNET.Dao;
//using GpsNET.Domain;
//using System.Collections;
//using System.Threading;
//using System.Collections.Concurrent;
//using GpsNET.MapService;
//using GpsNET.Util;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 电子围栏报警服务
//    /// </summary>
//    public class AreaAlarmService : IAreaAlarmService
//    {
//        /// <summary>
//        /// 报警开
//        /// </summary>
//        public static string TURN_ON = "1";
//        /// <summary>
//        /// 报警关
//        /// </summary>
//        public static string TURN_OFF = "0";

//        /// <summary>
//        /// 偏离路线报警
//        /// </summary>
//        private Hashtable offsetRouteWarn = new Hashtable();
//        /// <summary>
//        /// 在路线上报警
//        /// </summary>
//        private Hashtable onRouteWarn = new Hashtable();
//        /// <summary>
//        /// 超速
//        /// </summary>
//        private Hashtable overSpeedMap = new Hashtable();
//        /// <summary>
//        /// 路线点
//        /// </summary>
//        public Hashtable routePointMap = new Hashtable();
//        /// <summary>
//        /// 报警
//        /// </summary>
//        public Hashtable alarmMap = new Hashtable();
//        /// <summary>
//        /// ORM
//        /// </summary>
//        public IBaseDao BaseDao { get; set; }
//        /// <summary>
//        /// 终端报警服务
//        /// </summary>
//        public INewAlarmService NewAlarmService { get; set; }
//        /// <summary>
//        /// 查询服务
//        /// </summary>
//        public IQueryService QueryService { get; set; }
//        /// <summary>
//        /// 实时数据服务
//        /// </summary>
//        public IRealDataService RealDataService { get; set; }

//        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AlarmService));
//        /// <summary>
//        /// 区域信息
//        /// </summary>
//        public List<MapArea> AreaInfos = new List<MapArea>();
//        /// <summary>
//        /// 区域信息映射
//        /// </summary>
//        private ConcurrentDictionary<string, MapArea> AreaInfoMap = new ConcurrentDictionary<string, MapArea>();
//        /// <summary>
//        /// 报警状态映射
//        /// </summary>
//        public ConcurrentDictionary<string, String> alarmStateMap = new ConcurrentDictionary<string, String>();
//        /// <summary>
//        /// 实时数据映射
//        /// </summary>
//        public Dictionary<String, GPSRealData> realDataMap = new Dictionary<String, GPSRealData>();
//        /// <summary>
//        /// 报警项
//        /// </summary>
//        public ConcurrentQueue<AlarmItem> alarmItemQueue = new ConcurrentQueue<AlarmItem>();
//        /// <summary>
//        /// 是否继续
//        /// </summary>
//        private bool IsContinue = true;
//        /// <summary>
//        /// 处理线程
//        /// </summary>
//        private Thread processThread;
//        /// <summary>
//        /// 间隔
//        /// </summary>
//        public int Interval { get; set; }
//        /// <summary>
//        /// 是否区域报警
//        /// </summary>
//        public bool areaAlarmEnabled { get; set; }

//        public AreaAlarmService()
//        {
//            Interval = 100;
//        }

//        /// <summary>
//        /// 启动区域报警分析服务
//        /// </summary>
//        public void Start()
//        {
//            if (areaAlarmEnabled)
//            {
//                logger.Info("启动区域报警分析服务");
//                processThread = new Thread(new ThreadStart(ProcessAlarmThreadFunc));
//                processThread.Start();
//            }
//        }


//        /// <summary>
//        /// 处理报警队列
//        /// </summary>
//        private void ProcessAlarmThreadFunc()
//        {
//            logger.Info("处理报警队列");
//            int k = 0;
//            while (IsContinue)
//            {
//                try
//                {

//                    this.analyze();
//                }
//                catch (Exception ex)
//                {
//                    logger.Error(ex.Message);
//                    logger.Error(ex.StackTrace);
//                }

//                k++;
//                Thread.Sleep(Interval);
//            }

//        }

//        /// <summary>
//        /// 停止服务
//        /// </summary>
//        public void Stop()
//        {
//            IsContinue = false;
//            processThread.Join();
//        }

//        /// <summary>
//        /// 报警分析
//        /// </summary>
//        private void analyze()
//        {
//            Hashtable param = new Hashtable();
//            DateTime d = DateTime.Now.AddMinutes(-5);
//            param.Add("onlineDate", d);
//            String queryId = "selectAllBindAreas";
//            IList bindings = this.QueryService.QueryForList(queryId, param);
//            Dictionary<int, MapArea> areaMap = new Dictionary<int, MapArea>();
//            foreach (Hashtable eb in bindings)
//            {
//                int areaId = (int)eb["areaId"];
//                int bindId = (int)eb["bindId"];
//                String simNo = "" + eb["simNo"];
//                String key = bindId + "_" + simNo;

//                GPSRealData rd = this.RealDataService.Get(simNo);
//                if (rd != null)
//                {
//                    GPSRealData oldRd = null;
//                    if (realDataMap.ContainsKey(key))
//                    {
//                        oldRd = realDataMap[key];
//                        //如果坐标没变化，没必要分析区域
//                        if (oldRd.Latitude == rd.Latitude && oldRd.Longitude == rd.Longitude)
//                        {
//                            continue;
//                        }
//                    }
//                    else
//                    {
//                        oldRd = new GPSRealData();
//                    }

//                    oldRd.Latitude = (rd.Latitude);
//                    oldRd.Longitude = (rd.Longitude);
//                    realDataMap[key] = oldRd;

//                    String hql = "from MapArea where areaId = ? and Deleted = ?";
//                    MapArea ec = (MapArea)this.BaseDao.find(hql, new Object[] { areaId, false });

//                    if (ec != null)
//                    {
//                        this.AnalyzeAreaAlarm(rd, ec);
//                    }

//                    /**
//                    if (areaMap.ContainsKey(areaId) == false)
//                    {
//                        ec = (MapArea)this.BaseDao.load(typeof(MapArea), areaId);
//                        areaMap[areaId] = ec;
//                    }
//                    else
//                        ec = areaMap[areaId];
//                    */
//                }
//            }
//        }

//        /// <summary>
//        /// 分析区域报警
//        /// </summary>
//        /// <param name="rd"></param>
//        /// <param name="ec"></param>
//        private void AnalyzeAreaAlarm(GPSRealData rd, MapArea ec)
//        {

//            double lat = rd.Latitude;
//            double lng = rd.Longitude;

//            MyPointLatLng mp = new MyPointLatLng(rd.Latitude, rd.Longitude);

//            if (String.IsNullOrEmpty(ec.Points))
//                return;
//            /**
//            if (Constants.MAP_BAIDU.Equals(ec.MapType))
//            {
//                if (pointForBaidu == null)
//                {
//                    pointForBaidu = MapFix
//                            .Fix(lng, lat, Constants.MAP_BAIDU);
//                }
//                mp = pointForBaidu;
//            }
//            else
//            {

//                if (pointForGoogle == null)
//                {
//                    pointForGoogle = MapFix
//                            .Fix(lng,lat,
//                            Constants.MAP_GOOGLE);
//                }
//                mp = pointForGoogle;
//            }*/

//            if (MapArea.ROUTE.Equals(ec.AreaType))
//            {
//                AnalyzeOffsetRoute(rd, ec, mp);
//            }
//            else
//            {
//                if (ec.KeyPoint == 1)
//                {
//                    if (ec.ByTime)
//                        monitorKeyPointArrvie(rd, ec, mp);
//                    else
//                        monitorKeyPointLeave(rd, ec, mp); // 监控在规定的时间段内离开
//                }
//                else
//                {
//                    bool inMapArea = IsInArea(ec, mp);
//                    CrossBorder(ec, rd, inMapArea);
//                }
//            }
//        }

//        /// <summary>
//        /// 监控关键点到达
//        /// </summary>
//        /// <param name="rd"></param>
//        /// <param name="ec"></param>
//        /// <param name="mp"></param>
//        private void monitorKeyPointArrvie(GPSRealData rd, MapArea ec,
//                MyPointLatLng mp)
//        {
//            String alarmType = AlarmRecord.TYPE_ARRIVE_NOT_ON_TIME;
//            String alarmSource = AlarmRecord.ALARM_FROM_PLATFORM;
//            String key = rd.PlateNo + "_" + ec.EntityId + "_" + alarmType;
//            AlarmItem item = (AlarmItem)alarmMap[key];

//            DateTime now = DateTime.Now;
//            if (now.CompareTo(ec.EndDate) <= 0)
//            {
//                if (item == null)
//                {
//                    bool inMapArea = this.IsInArea(ec, mp);
//                    if (inMapArea)
//                    {
//                        logger.Error("进入关键点:" + ec.Name);
//                        item = new AlarmItem(rd, alarmType, alarmSource);
//                        alarmMap[key] = item;
//                    }
//                }
//            }
//            else if (now.CompareTo(ec.EndDate) > 0)
//            {
//                if (item == null)
//                {
//                    bool inMapArea = IsInArea(ec, mp);
//                    if (inMapArea == false)
//                    {
//                        this.insertAlarm(alarmSource, alarmType, rd, ec.Name);
//                        // 第一次报警
//                    }
//                    else
//                    {
//                        item = new AlarmItem(rd, alarmType, alarmSource);
//                        item.Status = (AlarmRecord.STATUS_OLD);
//                        alarmMap[key] = item;
//                    }
//                }
//            }

//        }

//        /// <summary>
//        /// 监控关键点离开
//        /// </summary>
//        /// <param name="rd"></param>
//        /// <param name="ec"></param>
//        /// <param name="mp"></param>
//        private void monitorKeyPointLeave(GPSRealData rd, MapArea ec,
//                MyPointLatLng mp)
//        {
//            String alarmSource = AlarmRecord.ALARM_FROM_PLATFORM;
//            String alarmType = AlarmRecord.TYPE_LEAVE_NOT_ON_TIME;
//            String key = rd.PlateNo + "_" + ec.EntityId + "_" + alarmType;
//            AlarmItem item = (AlarmItem)alarmMap[key];
//            DateTime now = DateTime.Now;
//            if (now.CompareTo(ec.StartDate) < 0
//                    && now.CompareTo(ec.EndDate) > 0)
//            {

//                if (item == null)
//                {
//                    // 判断是否在规定的时间离开关键点
//                    bool inMapArea = IsInArea(ec, mp);
//                    if (inMapArea)
//                    {
//                        this.insertAlarm(alarmSource, alarmType, rd, ec.Name);
//                    }
//                    else
//                    {
//                        // 关闭报警
//                        item = new AlarmItem(rd, alarmType, alarmSource);
//                        // item.setOpen(false);
//                        alarmMap[key] = item;
//                    }
//                }
//            }

//        }

//        /// <summary>
//        /// 判断是否在区域内
//        /// </summary>
//        /// <param name="ec"></param>
//        /// <param name="mp"></param>
//        /// <returns></returns>
//        public bool IsInArea(MapArea ec, MyPointLatLng mp)
//        {

//            List<MyPointLatLng> points = ec.GetNodes();

//            if (ec.AreaType == MapArea.POLYGON && points.Count > 2)
//            {
//                return MapFix.IsInPolygon(mp, points);
//            }
//            else if (ec.AreaType == MapArea.CIRCLE && points.Count > 0)
//            {
//                MyPointLatLng pl = points[0];
//                double radius = ec.Radius;
//                return MapFix.IsInCircle(mp, pl, radius);
//            }
//            else if (ec.AreaType == MapArea.RECT && points.Count > 1)
//            {
//                MyPointLatLng p1 = points[0];
//                MyPointLatLng p2 = points[2];

//                return MapFix.IsInRect(mp.Lng, mp.Lat, p1.Lng, p1.Lat, p2.Lng, p2.Lat);
//            }

//            return false;
//        }

//        /// <summary>
//        /// 分析偏离路线
//        /// </summary>
//        /// <param name="rd"></param>
//        /// <param name="ec"></param>
//        /// <param name="mp"></param>
//        public void AnalyzeOffsetRoute(GPSRealData rd, MapArea ec, MyPointLatLng mp)
//        {
//            //Date start = new Date();
//            String alarmType = AlarmRecord.TYPE_OFFSET_ROUTE;
//            String alarmSource = AlarmRecord.ALARM_FROM_PLATFORM;
//            int maxAllowedOffsetTime = ec.OffsetDelay; // 最长偏移时间

//            // 判断是否在班线中
//            LineSegment seg = IsInLineSegment(mp, ec);
//            bool isOnRoute = seg != null;
//            logger.Info(rd.PlateNo + ",班线" + ec.Name + ","
//                    + (seg == null ? "偏移" : "在路线上") + rd.SendTime);
//            String alarmKey = rd.PlateNo + "_" + ec.EntityId;
//            AlarmItem offsetAlarm = (AlarmItem)offsetRouteWarn[alarmKey];
//            AlarmItem onRouteAlarm = (AlarmItem)onRouteWarn[alarmKey];
//            if (isOnRoute == false)
//            {
//                if (offsetAlarm == null)
//                {
//                    this.AnalyzeOverSpeed(rd, null, ec);
//                    offsetAlarm = new AlarmItem(rd, alarmType, alarmSource);
//                    offsetRouteWarn[alarmKey] = offsetAlarm;
//                    offsetAlarm.Status = ("");
//                }
//                DateTime offsetTime = offsetAlarm.AlarmTime;
//                TimeSpan span = rd.SendTime - offsetTime;
//                double ts = span.TotalSeconds;
//                if (ts > maxAllowedOffsetTime
//                        && offsetAlarm.Status.Equals(""))
//                {
//                    offsetAlarm.Status = (AlarmRecord.STATUS_NEW); // 设置为报警状态
//                    this.insertAlarm(alarmSource, alarmType, rd, ec.Name);
//                    DateTime originTime = rd.SendTime;
//                    rd.SendTime = (offsetTime);
//                    AlarmRecord sr = this.CreateAreaAlarmRecord(
//                            AlarmRecord.ALARM_FROM_PLATFORM,
//                            AlarmRecord.TYPE_OFFSET_ROUTE, TURN_ON, rd,
//                            ec.EntityId, ec.Name);
//                    // 关闭进入线路报警记录
//                    sr = CreateAreaAlarmRecord(AlarmRecord.ALARM_FROM_PLATFORM,
//                            AlarmRecord.TYPE_ON_ROUTE, TURN_OFF, rd,
//                            ec.EntityId, ec.Name);
//                    rd.SendTime = (originTime);
//                    onRouteWarn.Remove(alarmKey);
//                }

//            }
//            else
//            {
//                AnalyzeOverSpeed(rd, seg, ec);
//                if (offsetAlarm != null)
//                {
//                    offsetAlarm.Status = (AlarmRecord.STATUS_OLD);// 报警关闭
//                    logger.Info(rd.PlateNo + "重回路线," + rd.SendTime);
//                    CreateAreaAlarmRecord(AlarmRecord.ALARM_FROM_PLATFORM,
//                            AlarmRecord.TYPE_OFFSET_ROUTE, TURN_OFF, rd,
//                            ec.EntityId, ec.Name);
//                    offsetRouteWarn.Remove(alarmKey);
//                }
//                if (onRouteAlarm == null)
//                {
//                    onRouteAlarm = new AlarmItem(rd, AlarmRecord.TYPE_ON_ROUTE,
//                            alarmSource);
//                    onRouteWarn[alarmKey] = onRouteAlarm;
//                    AlarmRecord sr = CreateAreaAlarmRecord(
//                            AlarmRecord.ALARM_FROM_PLATFORM,
//                            AlarmRecord.TYPE_ON_ROUTE, TURN_ON, rd,
//                            ec.EntityId, ec.Name);
//                }
//            }

//        }

//        /// <summary>
//        /// 判断是否在限速路段
//        /// </summary>
//        /// <param name="pointId"></param>
//        /// <param name="route"></param>
//        /// <returns></returns>
//        private RouteSegment isInLimitSpeedRouteSegment(int pointId, MapArea route)
//        {
//            int routeId = route.EntityId;
//            String hql = "from RouteSegment where RouteId = ? and StartSegId <= ? and EndSegId >= ? ";

//            RouteSegment rs = (RouteSegment)this.BaseDao.find(hql, new Object[] {
//                routeId, pointId, pointId + 1 });

//            return rs;
//        }
//        /// <summary>
//        /// 分析超速报警
//        /// </summary>
//        /// <param name="rd"></param>
//        /// <param name="seg"></param>
//        /// <param name="ec"></param>
//        private void AnalyzeOverSpeed(GPSRealData rd, LineSegment seg, MapArea ec)
//        {
//            String key = rd.PlateNo;
//            AlarmItem alarmItem = (AlarmItem)overSpeedMap[key];

//            if (seg == null && alarmItem != null)
//            {
//                this.overSpeedMap.Remove(key);
//                this.CreateAreaAlarmRecord(AlarmRecord.ALARM_FROM_PLATFORM,
//                        AlarmRecord.TYPE_OVER_SPEED_ON_ROUTE, TURN_OFF, rd,
//                        alarmItem.AreaId, null);
//            }

//            if (seg == null)
//                return;

//            logger.Error("分段限速检测:" + ec.Name + ",拐点:" + seg.PointId);
//            RouteSegment rs = this.isInLimitSpeedRouteSegment(seg.PointId, ec);
//            if (rs == null)
//                return;

//            logger.Error("进入分段，线路:" + ec.Name + ",分段:" + rs.Name + "，车速:"
//                    + rd.Velocity);
//            if (rd.Velocity > rs.MaxSpeed)
//            {
//                double alarmDelay = 0;
//                if (alarmItem != null)
//                {
//                    DateTime offsetTime = alarmItem.AlarmTime;
//                    TimeSpan ts = rd.SendTime - offsetTime;
//                    alarmDelay = ts.TotalSeconds;

//                }
//                else
//                {
//                    alarmItem = new AlarmItem(rd, AlarmRecord.ALARM_FROM_PLATFORM,
//                            AlarmRecord.TYPE_OVER_SPEED_ON_ROUTE);
//                    alarmItem.Status = (AlarmRecord.STATUS_NEW);
//                    alarmItem.AreaId = ec.EntityId;
//                    this.overSpeedMap[key] = alarmItem;
//                }
//                if (alarmDelay >= rs.Delay)
//                {
//                    logger.Error("分段超速报警，线路:" + ec.Name + ",分段:"
//                            + rs.Name + "，车速:" + rd.Velocity);
//                    insertAlarm(AlarmRecord.ALARM_FROM_PLATFORM,
//                            AlarmRecord.TYPE_OVER_SPEED_ON_ROUTE, rd, ec.Name
//                                    + ",分段点:" + rs.Name);
//                    if (AlarmRecord.STATUS_NEW.Equals(alarmItem.Status))
//                    {
//                        // 第一次报警
//                        CreateAreaAlarmRecord(AlarmRecord.ALARM_FROM_PLATFORM,
//                                AlarmRecord.TYPE_OVER_SPEED_ON_ROUTE, TURN_ON, rd,
//                                seg.EntityId,
//                                ec.Name + ",路段:" + seg.Name);
//                        alarmItem.Status = (AlarmRecord.STATUS_OLD);
//                        // this.overSpeedMap.put(key, rs);
//                    }
//                }

//            }
//            else
//            {
//                if (alarmItem != null)
//                {
//                    // 报警消除
//                    this.overSpeedMap.Remove(key);
//                    CreateAreaAlarmRecord(AlarmRecord.ALARM_FROM_PLATFORM,
//                            AlarmRecord.TYPE_OVER_SPEED_ON_ROUTE, TURN_OFF, rd,
//                            seg.EntityId, null);
//                }
//            }

//        }
//        /// <summary>
//        /// 获取线段列表
//        /// </summary>
//        /// <param name="RouteId"></param>
//        /// <returns></returns>
//        private List<LineSegment> GetLineSegments(int RouteId)
//        {
//            String hsql = "from LineSegment where RouteId = ? order by PointId";
//            IList ls = this.BaseDao.query(hsql, RouteId);
//            List<LineSegment> result = new List<LineSegment>();
//            foreach (LineSegment se in ls)
//            {
//                result.Add(se);
//            }
//            return result;
//        }


//        /// <summary>
//        /// 判断是否在班线中
//        /// </summary>
//        /// <param name="mp"></param>
//        /// <param name="ec"></param>
//        /// <returns></returns>
//        private LineSegment IsInLineSegment(MyPointLatLng mp, MapArea ec)
//        {
//            List<LineSegment> segments = GetLineSegments(ec.EntityId);
//            LineSegment prevSegment = null;
//            foreach (LineSegment seg in segments)
//            {
//                if (prevSegment != null && (prevSegment.Latitude1 != seg.Latitude1 || prevSegment.Longitude1 != seg.Longitude1))
//                {
//                    MyPointLatLng p1 = MapFix.Reverse(prevSegment.Longitude1,
//                            prevSegment.Latitude1, ec.MapType);
//                    MyPointLatLng p2 = MapFix.Reverse(seg.Longitude1,
//                            seg.Latitude1, ec.MapType);

//                    Boolean result = MapFix.isPointOnRouteSegment(p1, p2,
//                            mp, seg.LineWidth);
//                    if (result)
//                        return seg;
//                }
//                prevSegment = seg;
//            }
//            return null;
//        }

//        /// <summary>
//        /// 判断是否在路上
//        /// </summary>
//        /// <param name="rd"></param>
//        /// <returns></returns>
//        public bool IsInRoute(GPSRealData rd)
//        {
//            DateTime start = DateTime.Now;
//            string hql = "from VehicleData where PlateNo = ?";
//            VehicleData vd = (VehicleData)BaseDao.find(hql, rd.PlateNo);

//            if (vd == null || string.IsNullOrEmpty(vd.Routes))
//                return true;

//            bool result = false;

//            double lat = rd.Latitude;
//            double lng = rd.Longitude;

//            MyPointLatLng mp = new MyPointLatLng(lat, lng);
//            string[] routeIds = vd.Routes.Split(',');
//            foreach (string strRouteId in routeIds)
//            {
//                if (string.IsNullOrEmpty(strRouteId) == false)
//                {
//                    int routeId = int.Parse(strRouteId);
//                    //List<MyPointLatLng> bps = GetBufferPoints(routeId);

//                    //result = MapFix.IsInPolygon(mp, bps);
//                    if (result)
//                        return result;
//                }
//            }
//            TimeSpan ts = DateTime.Now - start;
//            if (ts.TotalSeconds > 0.2)
//                logger.Info("偏移计算耗时:" + ts.TotalSeconds);
//            return result;
//        }


//        /// <summary>
//        /// 获取旧得区域信息
//        /// </summary>
//        /// <param name="plateNo"></param>
//        /// <returns></returns>
//        private MapArea getOldAreaInfo(string plateNo)
//        {
//            MapArea oldEc = null;
//            if (AreaInfoMap.ContainsKey(plateNo))
//            {
//                oldEc = AreaInfoMap[plateNo];
//            }
//            return oldEc;
//        }
//        /// <summary>
//        /// 写入终端报警
//        /// </summary>
//        /// <param name="alarmSource"></param>
//        /// <param name="alarmType"></param>
//        /// <param name="rd"></param>
//        /// <param name="areaName"></param>

//        private void insertAlarm(String alarmSource, String alarmType,
//                GPSRealData rd, String areaName)
//        {
//            rd.Location = ("区域:" + areaName);
//            this.NewAlarmService.insertAlarm(alarmSource, alarmType, rd);
//        }

//        /// <summary>
//        /// 跨境(跨区域)
//        /// </summary>
//        /// <param name="ec"></param>
//        /// <param name="rd"></param>
//        /// <param name="isInMapArea"></param>
//        private void CrossBorder(MapArea ec, GPSRealData rd, bool isInMapArea)
//        {
//            MapArea oldEc = getOldAreaInfo(rd.PlateNo);

//            if (isInMapArea && (oldEc == null || oldEc.EntityId != ec.EntityId))
//            {
//                //说明进入一个新的围栏
//                AreaInfoMap[rd.PlateNo] = ec;
//                insertAlarm(AlarmRecord.ALARM_FROM_PLATFORM,
//                         AlarmRecord.TYPE_IN_AREA, rd, ec.Name);
//                CreateAreaAlarmRecord(AlarmRecord.ALARM_FROM_PLATFORM, AlarmRecord.TYPE_IN_AREA, AlarmRecord.TURN_ON, rd, ec.EntityId, ec.Name);
//                //CreateAreaAlarmRecord(AlarmRecord.ALARM_FROM_PLATFORM, AlarmRecord.TYPE_CROSS_BORDER, AlarmRecord.TURN_OFF, rd, ec);
//                //CheckAreaInfoGather();//检测聚集
//            }
//            else if (isInMapArea == false && oldEc != null)
//            {
//                bool res = AreaInfoMap.TryRemove(rd.PlateNo, out oldEc);
//                if (res == false)
//                {
//                    logger.Error("删除围栏报警集合失败");
//                }
//                insertAlarm(AlarmRecord.ALARM_FROM_PLATFORM,
//                     AlarmRecord.TYPE_CROSS_BORDER, rd, ec.Name);
//                CreateAreaAlarmRecord(AlarmRecord.ALARM_FROM_PLATFORM, AlarmRecord.TYPE_IN_AREA, AlarmRecord.TURN_OFF, rd, oldEc.EntityId, oldEc.Name);
//                //CreateAreaAlarmRecord(AlarmRecord.ALARM_FROM_PLATFORM, AlarmRecord.TYPE_CROSS_BORDER, AlarmRecord.TURN_ON, rd, oldEc);
//                logger.Info(rd.PlateNo + "离开围栏" + oldEc.Name + ",系统开始重新计算聚集");

//            }

//        }
//        /// <summary>
//        /// 创建区域报警记录
//        /// </summary>
//        /// <param name="AlarmSrc"></param>
//        /// <param name="AlarmType"></param>
//        /// <param name="alarmState"></param>
//        /// <param name="rd"></param>
//        /// <param name="areaId"></param>
//        /// <param name="areaName"></param>
//        /// <returns></returns>
//        private AlarmRecord CreateAreaAlarmRecord(string AlarmSrc, string AlarmType, string alarmState, GPSRealData rd, int areaId, String areaName)
//        {
//            string hsql = "from AlarmRecord rec where rec.PlateNo = ? and rec.Status = ?" +
//            " and rec.AlarmSource = ? and rec.AlarmType = ? and Station = ?";
//            //查看是否有未消除的报警记录
//            AlarmRecord sr = (AlarmRecord)BaseDao.find(hsql, new Object[] { rd.PlateNo,
//                AlarmRecord.STATUS_NEW, AlarmSrc, AlarmType, ""+areaId });

//            if (sr == null)
//            {
//                if (alarmState == AlarmRecord.TURN_OFF)
//                    return null;

//                sr = new AlarmRecord();
//                sr.Station = areaId;
//                sr.PlateNo = rd.PlateNo;
//                sr.StartTime = rd.SendTime;
//                sr.Status = AlarmRecord.STATUS_NEW;
//                sr.EndTime = System.DateTime.Now;
//                sr.Latitude = rd.Latitude;
//                sr.Longitude = rd.Longitude;
//                sr.Location = MapFix.GetLocation(sr.Longitude, sr.Latitude);
//                sr.Velocity = rd.Velocity;
//                sr.Location = areaName;
//            }
//            else
//            {
//                sr.EndTime = System.DateTime.Now;
//                TimeSpan t = rd.SendTime - sr.StartTime;
//                sr.TimeSpan = t.TotalMinutes;
//                if (alarmState == AlarmRecord.TURN_OFF)
//                {
//                    sr.Status = AlarmRecord.STATUS_OLD;
//                    sr.EndTime = rd.SendTime;

//                    sr.Latitude1 = rd.Latitude;
//                    sr.Longitude1 = rd.Longitude;
//                }
//                else
//                    return null;

//            }

//            if (sr != null)
//            {
//                sr.AlarmSource = AlarmSrc;
//                sr.AlarmType = AlarmType;
//                BaseDao.saveOrUpdate(sr);
//            }
//            return sr;
//        }



//    }
//}
