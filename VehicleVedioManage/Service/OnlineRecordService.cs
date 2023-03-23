//using System.Collections;
//using System.Collections.Concurrent;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 上线记录分析服务
//    /// </summary>
//    public class OnlineRecordService : IOnlineRecordService
//    {
//        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(OnlineRecordService));
//        public ConcurrentQueue<OnlineRecord> dataQueue = new ConcurrentQueue<OnlineRecord>();
//        /// <summary>
//        /// 终端报警服务
//        /// </summary>
//        public INewAlarmService NewAlarmService { get; set; }
//        /// <summary>
//        /// 报警配置映射
//        /// </summary>
//        public Hashtable alarmConfigMap { get; set; }
//        /// <summary>
//        /// 在线字典
//        /// </summary>
//        private ConcurrentDictionary<string, bool> onlineMap = new ConcurrentDictionary<string, bool>();

//        public IBaseDao BaseDao { get; set; }
//        /// <summary>
//        /// 处理线程
//        /// </summary>
//        private Thread processThread;
//        /// <summary>
//        /// 离线时间
//        /// </summary>
//        private double MaxOfflineTime = 120 * 1;
//        /// <summary>
//        /// 是否继续
//        /// </summary>
//        private bool IsContinue = true;
//        /// <summary>
//        /// 启动上线记录分析服务
//        /// </summary>
//        public void Start()
//        {
//            logger.Info("启动上线记录分析服务");
//            processThread = new Thread(new ThreadStart(ProcessRealDataThreadFunc));
//            processThread.Start();

//        }
//        /// <summary>
//        /// 停止上线记录分析服务
//        /// </summary>
//        public void Stop()
//        {
//            IsContinue = false;

//            try
//            {
//                if (processThread != null)
//                    processThread.Join();
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//            }
//        }

//        /// <summary>
//        /// 处理实时数据
//        /// </summary>
//        private void ProcessRealDataThreadFunc()
//        {
//            int k = 0;
//            while (IsContinue)
//            {
//                try
//                {
//                    int queueCount = this.dataQueue.Count;
//                    if (queueCount > 200)
//                    {
//                        logger.Error("上线记录队列堵塞" + queueCount);
//                    }
//                    OnlineRecord tm = null;
//                    this.dataQueue.TryDequeue(out tm);
//                    List<OnlineRecord> msgList = new List<OnlineRecord>();
//                    while (tm != null)
//                    {
//                        try
//                        {
//                            if (tm.AlarmType == AlarmRecord.TYPE_ONLINE)
//                            {
//                                CreateOnlineChangeRecord(tm);
//                            }
//                            else
//                            {
//                                String alarmType = tm.AlarmType.Equals(
//                                        AlarmRecord.TYPE_ONLINE) ? AlarmRecord.TYPE_OFFLINE
//                                        : AlarmRecord.TYPE_ONLINE;
//                                tm.AlarmType = (alarmType);
//                                tm.Status = (AlarmRecord.STATUS_OLD);
//                                CreateOnlineChangeRecord(tm);
//                            }
//                            dataQueue.TryDequeue(out tm);
//                        }
//                        catch (Exception ex)
//                        {
//                            logger.Error(ex.Message, ex);
//                        }
//                    }
//                    if (msgList.Count > 0)
//                    {
//                        //saveAlarmRecord(msgList);
//                    }

//                }
//                catch (Exception ex)
//                {
//                    logger.Error(ex.Message);
//                    logger.Error(ex.StackTrace);
//                }

//                k++;
//                Thread.Sleep(500);
//            }

//        }
//        /// <summary>
//        /// 核查是否在线
//        /// </summary>
//        /// <param name="rd"></param>
//        public void checkOnline(GPSRealData rd)
//        {
//            Boolean oldOnlineState = false;
//            if (onlineMap.ContainsKey(rd.PlateNo))
//            {
//                oldOnlineState = onlineMap[rd.PlateNo];
//            }
//            if (oldOnlineState == rd.Online)
//                return;

//            if (this.NewAlarmService.isAlarmEnabled(AlarmRecord.TYPE_ONLINE, AlarmRecord.ALARM_FROM_PLATFORM)
//                == false && this.NewAlarmService.isAlarmEnabled(AlarmRecord.TYPE_OFFLINE, AlarmRecord.ALARM_FROM_PLATFORM) == false)
//            {
//                return;//没有使用
//            }

//            onlineMap[rd.PlateNo] = rd.Online;

//            String alarmType = rd.Online ? AlarmRecord.TYPE_ONLINE
//                    : AlarmRecord.TYPE_OFFLINE;
//            OnlineRecord r = new OnlineRecord(rd, alarmType, AlarmRecord.ALARM_FROM_PLATFORM);
//            if (this.NewAlarmService.isAlarmEnabled(alarmType, AlarmRecord.ALARM_FROM_PLATFORM))
//            {
//                this.NewAlarmService.insertAlarm(AlarmRecord.ALARM_FROM_PLATFORM,
//                        alarmType, rd);
//            }
//            else
//                return;

//            if (dataQueue.Count > 500)
//            {
//                logger.Error("上线记录队列堵塞，堵塞队列:" + dataQueue.Count);
//                //dataQueue.TryDequeue();
//            }
//            //dataQueue.Enqueue(r);
//            // }
//        }
//        /// <summary>
//        /// 创建在线变化记录
//        /// </summary>
//        /// <param name="rd"></param>
//        public void CreateOnlineChangeRecord(OnlineRecord rd)
//        {
//            string OperateType = rd.AlarmType;
//            string hsql =
//                "from OnlineRecord rec where rec.PlateNo = ? and rec.Status = ? and rec.AlarmType = ?";
//            //查看是否有未消除的报警记录
//            OnlineRecord sr = (OnlineRecord)BaseDao.find(hsql, new String[] { rd.PlateNo,
//                AlarmRecord.STATUS_NEW, OperateType });

//            if (sr == null && AlarmRecord.STATUS_NEW.Equals(rd.Status))
//            {
//                //createAlarm(AlarmRecord.ALARM_FROM_PLATFORM, OperateType, rd);//创建报警，等待推送到前台
//                sr = new OnlineRecord();
//                sr.PlateNo = rd.PlateNo;
//                sr.StartTime = rd.StartTime;
//                sr.Status = AlarmRecord.STATUS_NEW;
//                sr.EndTime = System.DateTime.Now;
//                sr.Latitude = rd.Latitude;
//                sr.Longitude = rd.Longitude;
//                sr.Location = rd.Location;
//                //sr.Acc = rd.GetAccState();
//                if (String.IsNullOrEmpty(sr.Location))
//                    sr.Location = MapFix.GetLocation(sr.Longitude, sr.Latitude);
//                sr.AlarmType = OperateType;
//                sr.AlarmSource = AlarmRecord.ALARM_FROM_PLATFORM;
//                BaseDao.saveOrUpdate(sr);
//            }
//            else if (sr != null && AlarmRecord.STATUS_OLD.Equals(rd.Status))
//            {
//                sr.EndTime = rd.StartTime;
//                TimeSpan t = sr.EndTime - sr.StartTime;
//                sr.TimeSpan = t.TotalMinutes;

//                sr.Status = AlarmRecord.STATUS_OLD;
//                sr.EndTime = DateTime.Now;// rd.SendTime;
//                sr.Latitude1 = rd.Latitude;
//                sr.Longitude1 = rd.Longitude;

//                sr.AlarmType = OperateType;
//                BaseDao.saveOrUpdate(sr);
//            }
//        }

//    }
//}
