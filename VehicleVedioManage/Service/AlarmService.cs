//using System.Collections;
//using System.Collections.Concurrent;
//using NewLife.Log;
//using VehicleVedioManage.FenceManagement.Entity;
//using VehicleVedioManage.IService;
//using VehicleVedioManage.ReportStatistics.Entity;
//using VehicleVedioManage.Web.Enums;
//using VehicleVedioManage.Web.IService;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 报警服务
//    /// </summary>
//    public class AlarmService : IAlarmService
//    {
//        /// <summary>
//        /// ORM
//        /// </summary>
//        public IBaseDao BaseDao { get; set; }
//        /// <summary>
//        /// 电子围栏
//        /// </summary>
//        public List<MapArea> Enclosures = new List<MapArea>();
//        /// <summary>
//        /// 偏离路线报警
//        /// </summary>
//        private Hashtable offsetRouteWarn = new Hashtable();
//        /// <summary>
//        /// 路线点映射
//        /// </summary>
//        public Hashtable routePointMap = new Hashtable();
//        /// <summary>
//        /// 报警映射
//        /// </summary>
//        public Hashtable alarmMap = new Hashtable();
//        /// <summary>
//        /// 上线记录服务
//        /// </summary>
//        public IOnlineRecordService OnlineRecordService { get; set; }

//        /// <summary>
//        /// 是否开始报警
//        /// </summary>
//        public bool StartAreaAlarm { get; set; }

//        /// <summary>
//        /// 区域信息映射
//        /// </summary>
//        private ConcurrentDictionary<string, MapArea> AreaInfoMap = new ConcurrentDictionary<string, MapArea>();
//        /// <summary>
//        /// 实时数据队列
//        /// </summary>
//        public ConcurrentQueue<AlarmRecord> realDataQueue = new ConcurrentQueue<AlarmRecord>();
//        /// <summary>
//        /// 809转发服务
//        /// </summary>
//        public IJT809TransferService JT809TransferService { get; set; }
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
//        /// 聚合报警
//        /// </summary>
//        public bool GatherAlarm { get; set; }
//        /// <summary>
//        /// 终端报警
//        /// </summary>
//        public INewAlarmService NewAlarmService { get; set; }



//        public AlarmService()
//        {
//            Interval = 100;
//        }

//        /// <summary>
//        /// 启动报警分析服务
//        /// </summary>
//        public void Start()
//        {
//            XTrace.Log.Info("启动报警分析服务");
//            processThread = new Thread(new ThreadStart(ProcessRealDataThreadFunc));
//            processThread.Start();

//            try
//            {
//                String hql = "from AlarmRecord where status = ?";
//                IList ls = this.BaseDao.query(hql, AlarmRecordEnum.STATUS_NEW);
//                foreach (AlarmRecord r in ls)
//                {
//                    String key = r.PlateNo + "_" + r.AlarmType + "_"
//                            + r.AlarmSource;
//                    this.alarmMap[key] = r;
//                }
//            }
//            catch (Exception ex)
//            {
//                XTrace.Log.Error(ex.Message);
//            }
//        }


//        /// <summary>
//        /// 处理实时数据
//        /// </summary>
//        private void ProcessRealDataThreadFunc()
//        {
//            //XTrace.Log.Info("处理报警队列");
//            int k = 0;
//            while (IsContinue)
//            {
//                try
//                {
//                    AlarmRecord tm = null;
//                    realDataQueue.TryDequeue(out tm);
//                    List<AlarmRecord> msgList = new List<AlarmRecord>();
//                    while (tm != null)
//                    {
//                        msgList.Add(tm);
//                        if (msgList.Count > 30)
//                            break;
//                        realDataQueue.TryDequeue(out tm);
//                    }
//                    if (msgList.Count > 0)
//                    {
//                        saveAlarmRecord(msgList);
//                    }
//                    int alarmQueueNum = realDataQueue.Count;

//                }
//                catch (Exception ex)
//                {
//                    XTrace.Log.Error(ex.Message);
//                }


//                Thread.Sleep(Interval);
//            }

//        }
//        /// <summary>
//        /// 保存报警记录
//        /// </summary>
//        /// <param name="msgList"></param>
//        private void saveAlarmRecord(List<AlarmRecord> msgList)
//        {

//            foreach (AlarmRecord r in msgList)
//            {
//                try
//                {
//                    if (r.Status.Equals(AlarmRecordEnum.STATUS_NEW))
//                    {
//                        this.BaseDao.saveOrUpdate(r);
//                    }
//                    else
//                    {
//                        this.BaseDao.saveOrUpdate(r);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    XTrace.Log.Error(ex.Message, ex);
//                }
//            }

//        }
//        /// <summary>
//        /// 停止服务
//        /// </summary>
//        public void Stop()
//        {
//            IsContinue = false;
//            try
//            {
//                if (processThread != null)
//                    processThread.Join();

//                if (NewAlarmService != null)
//                    NewAlarmService.Stop();
//            }
//            catch (Exception ex)
//            {
//                XTrace.Log.Error(ex.Message, ex);
//            }
//        }


//        /// <summary>
//        /// 获取旧的区域信息
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
//        /// 处理实时数据
//        /// </summary>
//        /// <param name="rd"></param>
//        public void processRealData(GPSRealData rd)
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(rd.PlateNo))
//                {
//                    return;
//                }

//                string newStatus = rd.Status;
//                string newAlarmState = rd.AlarmState;

//                CreateChangeRecord(AlarmRecordEnum.STATE_FROM_TERM, newStatus, rd);
//                CreateChangeRecord(AlarmRecord.ALARM_FROM_TERM, newAlarmState, rd);
//                // 停车报警
//                if (this.NewAlarmService.isAlarmEnabled(AlarmRecord.TYPE_PARKING,
//                        AlarmRecord.ALARM_FROM_PLATFORM))
//                {
//                    String alarmState = rd.Velocity < 1 ? AlarmRecord.TURN_ON
//                            : AlarmRecord.TURN_OFF;
//                    if (alarmState == AlarmRecord.TURN_ON)
//                        this.NewAlarmService.insertAlarm(AlarmRecord.ALARM_FROM_PLATFORM, AlarmRecord.TYPE_PARKING, rd);

//                    analyzeAlarm(rd, AlarmRecord.TYPE_PARKING,
//                            AlarmRecord.ALARM_FROM_PLATFORM, alarmState);
//                }
//            }
//            catch (Exception ex)
//            {
//                XTrace.Log.Error(ex.Message, ex);
//            }
//        }
//        /// <summary>
//        /// 创建停车记录
//        /// </summary>
//        /// <param name="rd"></param>
//        /// <param name="oldRd"></param>
//        public void CreateParkingRecord(GPSRealData rd, GPSRealData oldRd)
//        {
//            int minVelocity = 2;
//            if (rd.Velocity < minVelocity && oldRd.Velocity < minVelocity)
//                return;
//            if (rd.Velocity >= minVelocity && oldRd.Velocity >= minVelocity)
//                return;

//            string hsql = "from AlarmRecord rec where rec.PlateNo = ? and rec.Status = ? and rec.AlarmType = ?";
//            AlarmRecord sr = (AlarmRecord)BaseDao.find(hsql, new String[] { rd.PlateNo,
//                AlarmRecord.STATUS_NEW, AlarmRecord.TYPE_PARKING});

//            if (sr == null)
//            {
//                if (rd.Velocity >= minVelocity)
//                    return;

//                sr = new AlarmRecord();
//                sr.PlateNo = rd.PlateNo;
//                sr.StartTime = rd.SendTime;
//                sr.Status = AlarmRecord.STATUS_NEW;
//                sr.EndTime = System.DateTime.Now;
//                sr.AlarmSource = AlarmRecord.ALARM_FROM_PLATFORM;//平台报警

//                sr.Location = MapFix.GetLocation(rd.Longitude, rd.Latitude);
//                sr.Latitude = rd.Latitude;
//                sr.Longitude = rd.Longitude;
//                //记录下油量和里程
//                //sr.Oil1 = rd.Oil;
//                sr.Mileage1 = rd.Mileage;
//            }
//            else
//            {
//                sr.EndTime = System.DateTime.Now;
//                TimeSpan t = rd.SendTime - sr.StartTime;
//                sr.TimeSpan = t.TotalMinutes;
//                sr.EndTime = rd.SendTime;

//                if (rd.Velocity >= minVelocity)
//                {
//                    sr.Status = AlarmRecord.STATUS_OLD;
//                    sr.Latitude1 = rd.Latitude;
//                    sr.Longitude1 = rd.Longitude;

//                    //记录下油量和里程
//                    //sr.Oil2 = rd.Oil;
//                    sr.Mileage2 = rd.Mileage;
//                }
//                else
//                {
//                    return;
//                }

//            }
//            sr.AlarmType = AlarmRecord.TYPE_PARKING;
//            BaseDao.saveOrUpdate(sr);
//        }
//        /// <summary>
//        /// 创建报警变化记录
//        /// </summary>
//        /// <param name="alarmSource"></param>
//        /// <param name="newStatus"></param>
//        /// <param name="rd"></param>
//        private void CreateChangeRecord(string alarmSource, string newStatus, GPSRealData rd)
//        {
//            char[] newChars = (char[])newStatus.ToCharArray();

//            for (int m = 0; m < newChars.Length; m++)
//            {
//                int alarmId = 31 - m;
//                String alarmType = "" + alarmId;
//                String alarmState = "" + newChars[m];

//                if (alarmSource.Equals(AlarmRecord.ALARM_FROM_TERM))
//                {
//                    if (alarmId == 20)
//                    {
//                        alarmType = rd.AreaAlarm == 0 ? AlarmRecord.TYPE_IN_AREA
//                                : AlarmRecord.TYPE_CROSS_BORDER;
//                    }
//                    else if (alarmId == 21)
//                    {
//                        alarmType = rd.AreaAlarm == 0 ? AlarmRecord.TYPE_ON_ROUTE
//                                : AlarmRecord.TYPE_OFFSET_ROUTE;
//                    }

//                    if ((alarmId == 20 || alarmId == 21) && rd.AreaId > 0)
//                    {
//                        String hql = "from Enclosure where enclosureId = ?";
//                        MapArea e = (MapArea)BaseDao.find(hql, rd.AreaId);
//                        if (e != null)
//                            rd.Location = "区域:" + e.Name;
//                    }
//                }

//                // 转发报警信息
//                if (alarmSource.Equals(AlarmRecord.ALARM_FROM_TERM)
//                        && alarmState.Equals(AlarmRecord.TURN_ON)
//                        && this.NewAlarmService.isAlarmEnabled(alarmType, alarmSource))
//                {
//                    if (alarmId == 20)
//                    {
//                        alarmType = rd.AreaAlarm == 0 ? AlarmRecord.TYPE_IN_AREA
//                                : AlarmRecord.TYPE_CROSS_BORDER;
//                    }
//                    else if (alarmId == 21)
//                    {
//                        alarmType = rd.AreaAlarm == 0 ? AlarmRecord.TYPE_ON_ROUTE
//                                : AlarmRecord.TYPE_OFFSET_ROUTE;
//                    }
//                    if ((alarmId == 20 || alarmId == 21) && rd.AreaId > 0)
//                    {
//                        try
//                        {
//                            String hql = "from MapArea where areaId = ? ";
//                            MapArea area = (MapArea)this.BaseDao.find(hql,
//                                    rd.AreaId);
//                            if (area != null)
//                            {
//                                String location = alarmId == 20 ? "区域：" : "线路:";
//                                location += area.Name;
//                                rd.Location = (location);
//                            }
//                        }
//                        catch (Exception ex)
//                        {
//                            XTrace.Log.Error(ex.Message, ex);
//                        }
//                    }
//                    NewAlarmService.insertAlarm(alarmSource, alarmType, rd);
//                    // }
//                }

//                if (this.NewAlarmService.isAlarmEnabled(alarmType, alarmSource))
//                {
//                    if (alarmId == 20)
//                    {
//                        alarmType = AlarmRecord.TYPE_IN_AREA;
//                        if (rd.AreaAlarm == 1)
//                            alarmState = AlarmRecord.TURN_OFF;
//                    }
//                    else if (alarmId == 21)
//                    {
//                        alarmType = AlarmRecord.TYPE_ON_ROUTE;
//                        if (rd.AreaAlarm == 1)
//                            alarmState = AlarmRecord.TURN_OFF;
//                    }

//                    this.analyzeAlarm(rd, alarmType, alarmSource, alarmState);
//                }
//            }
//        }
//        /// <summary>
//        /// 报警分析
//        /// </summary>
//        /// <param name="rd"></param>
//        /// <param name="alarmType"></param>
//        /// <param name="alarmSource"></param>
//        /// <param name="alarmState"></param>
//        private void analyzeAlarm(GPSRealData rd, String alarmType,
//            String alarmSource, String alarmState)
//        {
//            if (this.NewAlarmService.isAlarmStatisticEnabled(alarmType, alarmSource) == false)
//                return;
//            String alarmKey = rd.PlateNo + "_" + alarmType + "_" + alarmSource;
//            if (alarmState.Equals(AlarmRecord.TURN_ON))
//            {
//                // 发生报警
//                if (alarmMap.ContainsKey(alarmKey) == false)
//                {
//                    AlarmRecord item = new AlarmRecord(rd, alarmType, alarmSource);

//                    this.realDataQueue.Enqueue(item);
//                    alarmMap[alarmKey] = item;
//                }
//                else
//                {
//                    AlarmRecord item = (AlarmRecord)alarmMap[alarmKey];
//                    if (item.Status.Equals(AlarmRecord.STATUS_OLD))
//                    {
//                        AlarmRecord itemNew = new AlarmRecord(rd, alarmType,
//                                alarmSource);
//                        this.realDataQueue.Enqueue(itemNew);
//                        alarmMap[alarmKey] = item;
//                    }
//                }
//            }
//            else if (alarmState.Equals(AlarmRecord.TURN_OFF))
//            {
//                if (alarmMap.ContainsKey(alarmKey))
//                {
//                    AlarmRecord item = (AlarmRecord)alarmMap[alarmKey];
//                    // item.setOpen(false);
//                    alarmMap.Remove(alarmKey);

//                    item.Status = AlarmRecord.STATUS_OLD;
//                    item.EndTime = DateTime.Now;
//                    item.Latitude1 = rd.Latitude;
//                    item.Longitude1 = rd.Longitude;
//                    TimeSpan t = item.EndTime - item.StartTime;
//                    item.TimeSpan = t.TotalMinutes;
//                    this.realDataQueue.Enqueue(item);
//                    // this.CreateWarnRecord(AlarmRecord.ALARM_FROM_TERM, alarmType,
//                    // alarmState, rd);
//                }
//            }
//        }
//        /// <summary>
//        /// 创建报警记录
//        /// </summary>
//        /// <param name="AlarmSrc"></param>
//        /// <param name="AlarmType"></param>
//        /// <param name="warnState"></param>
//        /// <param name="rd"></param>
//        private void CreateAlarmRecord(string AlarmSrc, string AlarmType, string warnState, GPSRealData rd)
//        {
//            AlarmRecord sr = CreateRecord(AlarmSrc, AlarmType, warnState, rd);
//            if (sr != null)
//                BaseDao.saveOrUpdate(sr);
//        }

//        /// <summary>
//        /// 创建记录
//        /// </summary>
//        /// <param name="AlarmSrc"></param>
//        /// <param name="AlarmType"></param>
//        /// <param name="alarmStatus"></param>
//        /// <param name="rd"></param>
//        /// <returns></returns>
//        private AlarmRecord CreateRecord(string AlarmSrc, string AlarmType, string alarmStatus, GPSRealData rd)
//        {


//            string hsql = "from AlarmRecord rec where rec.PlateNo = ? and rec.Status = ? and rec.AlarmSource = ? and rec.AlarmType = ?";
//            AlarmRecord sr = (AlarmRecord)BaseDao.find(hsql, new String[] { rd.PlateNo,
//                AlarmRecord.STATUS_NEW, AlarmSrc, AlarmType });

//            if (sr == null)
//            {
//                if (alarmStatus == AlarmRecord.TURN_OFF)
//                    return null;

//                sr = new AlarmRecord();
//                if (AlarmType == "19")
//                {
//                    /**
//                    Enclosure ec = IsInAreaInfo(rd);
//                    if (ec != null)
//                    {
//                        sr.Station = ec.EntityId;
//                        sr.Location = ec.Name;
//                    }*/
//                }

//                sr.PlateNo = rd.PlateNo;
//                sr.StartTime = rd.SendTime;
//                sr.Status = AlarmRecord.STATUS_NEW;
//                sr.EndTime = System.DateTime.Now;
//                sr.Latitude = rd.Latitude;
//                sr.Longitude = rd.Longitude;
//                sr.Location = rd.Location;
//                if (String.IsNullOrEmpty(sr.Location))
//                    sr.Location = MapFix.GetLocation(sr.Longitude, sr.Latitude);
//                sr.Velocity = rd.Velocity;
//            }
//            else
//            {
//                sr.EndTime = System.DateTime.Now;
//                TimeSpan t = rd.SendTime - sr.StartTime;
//                sr.TimeSpan = t.TotalMinutes;
//                if (alarmStatus == AlarmRecord.TURN_OFF)
//                {
//                    sr.Status = AlarmRecord.STATUS_OLD;
//                    sr.EndTime = rd.SendTime;

//                    sr.Latitude1 = rd.Latitude;
//                    sr.Longitude1 = rd.Longitude;
//                }
//                else
//                    return null;

//            }

//            sr.AlarmSource = AlarmSrc;
//            sr.AlarmType = AlarmType;
//            return sr;
//        }
//    }
//}
