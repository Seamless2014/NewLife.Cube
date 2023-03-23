//using System.Collections;
//using System.Collections.Concurrent;
//using NewLife.Log;
//using VehicleVedioManage.BackManagement.Entity;
//using VehicleVedioManage.ReportStatistics.Entity;
//using VehicleVedioManage.Web.ViewModels;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 终端报警
//    /// </summary>
//    public class NewAlarmService : INewAlarmService
//    {
//        public IQueryService QueryService { get; set; }
//        /// <summary>
//        /// 数据队列
//        /// </summary>
//        private ConcurrentQueue<Alarm> dataQueue = new ConcurrentQueue<Alarm>();
//        /// <summary>
//        /// 是否继续处理
//        /// </summary>
//        private bool continueProcess = true;
//        /// <summary>
//        /// 处理报警线程
//        /// </summary>
//        private Thread processAlarmThread;

//        /// <summary>
//        /// ORM
//        /// </summary>
//        public IBaseDao BaseDao { get; set; }
//        /// <summary>
//        /// 报警配置字典
//        /// </summary>
//        public Hashtable alarmConfigMap = new Hashtable();
//        /// <summary>
//        /// 开始服务
//        /// </summary>
//        public void Start()
//        {
//            try
//            {
//                DateTime today = DateTime.Now;
//                String alarmTableName = "NewAlarm" + today.ToString("yyyyMM");
//                QueryService.createNewAlarmTableIfNotExist(alarmTableName);
//            }
//            catch (Exception ex)
//            {
//                XTrace.WriteException(ex);
//            }

//            processAlarmThread = new Thread(new ThreadStart(processRealDataThreadFunc));
//            processAlarmThread.Start();

//            getAlarmConfig();
//        }

//        /// <summary>
//        /// 停止服务
//        /// </summary>
//        public void Stop()
//        {
//            continueProcess = false;
//            try
//            {
//                if (processAlarmThread != null)
//                    processAlarmThread.Join(50000);
//            }
//            catch (Exception ex)
//            {
//                XTrace.WriteException(ex);
//            }
//            // processRealDataThread.stop();
//        }

//        /// <summary>
//        /// 获取报警配置
//        /// </summary>
//        private void getAlarmConfig()
//        {
//            try
//            {
//                IList ls = this.BaseDao.query("from AlarmConfig");
//                foreach (AlarmConfig a in ls)
//                {
//                    alarmConfigMap[a.alarmType + "_" + a.alarmSource] = a;
//                }
//            }
//            catch (Exception ex)
//            {
//                XTrace.WriteException(ex);
//            }
//        }
//        /// <summary>
//        /// 是否报警配置
//        /// </summary>
//        /// <param name="alarmType"></param>
//        /// <param name="alarmSource"></param>
//        /// <returns></returns>
//        public bool isAlarmEnabled(String alarmType, String alarmSource)
//        {
//            String key = alarmType + "_" + alarmSource;
//            if (alarmConfigMap.ContainsKey(key))
//            {
//                AlarmConfig a = (AlarmConfig)alarmConfigMap[key];
//                return a.Enabled;
//            }
//            return false;
//        }
//        /// <summary>
//        /// 是否启用报警统计
//        /// </summary>
//        /// <param name="alarmType"></param>
//        /// <param name="alarmSource"></param>
//        /// <returns></returns>
//        public bool isAlarmStatisticEnabled(String alarmType, String alarmSource)
//        {
//            String key = alarmType + "_" + alarmSource;
//            if (alarmConfigMap.ContainsKey(key))
//            {
//                AlarmConfig a = (AlarmConfig)alarmConfigMap[key];
//                return a.statisticEnabled;
//            }
//            return false;
//        }
//        /// <summary>
//        /// 入队
//        /// </summary>
//        /// <param name="newAlarm"></param>
//        public void enQueue(Alarm newAlarm)
//        {
//            dataQueue.Enqueue(newAlarm);
//        }

//        /// <summary>
//        /// 处理实时数据
//        /// </summary>
//        private void processRealDataThreadFunc()
//        {
//            int k = 0;
//            while (continueProcess)
//            {
//                try
//                {
//                    Alarm tm = null;
//                    dataQueue.TryDequeue(out tm);
//                    List<Alarm> msgList = new List<Alarm>();
//                    while (tm != null)
//                    {
//                        if (tm.AlarmTime.CompareTo(DateTime.Now.AddDays(-2)) < 0)
//                            continue;
//                        msgList.Add(tm);
//                        if (msgList.Count > 30)
//                            break;

//                        tm.tableName = "NewAlarm" + tm.AlarmTime.ToString("yyyyMM");
//                        this.QueryService.Insert("insertNewAlarm", tm);
//                        dataQueue.TryDequeue(out tm);
//                    }
//                    //batchInsertAlarm(msgList);
//                }
//                catch (Exception e)
//                {
//                    XTrace.WriteException(e);
//                }

//                k++;

//                if (k % 300 == 0)
//                {
//                    getAlarmConfig();
//                }
//                if (k > short.MaxValue)
//                    k = 0;
//                try
//                {
//                    Thread.Sleep(100);
//                }
//                catch (Exception e1)
//                {
//                }
//            }
//        }
//        /// <summary>
//        /// 批量插入
//        /// </summary>
//        /// <param name="alarmList"></param>
//        private void batchInsertAlarm(List<Alarm> alarmList)
//        {
//            if (alarmList.Count == 0)
//                return;
//            String statementName = "insertNewAlarm";
//            //.batchInsert(statementName, alarmList);
//        }

//        /// <summary>
//        /// 插入报警
//        /// </summary>
//        /// <param name="alarmSource"></param>
//        /// <param name="alarmType"></param>
//        /// <param name="rd"></param>
//        public void insertAlarm(String alarmSource, String alarmType, GPSRealData rd)
//        {
//            try
//            {
//                Alarm a = new Alarm();
//                a.AlarmSource = alarmSource;
//                a.AlarmTime = rd.SendTime;
//                a.AlarmType = alarmType;
//                a.Longitude = rd.Longitude;
//                a.Latitude = rd.Latitude;
//                a.PlateNo = rd.PlateNo;
//                a.VehicleId = rd.VehicleId;
//                a.Location = rd.Location;
//                a.Speed = rd.Velocity;
//                a.AckSn = rd.ResponseSn;
//                a.Location = rd.Location;
//                String alarmTalbeName = "NewAlarm"
//                        + a.AlarmTime.ToString("yyyyMM");
//                a.tableName = (alarmTalbeName);
//                this.enQueue(a);
//                // this.baseDao.saveOrUpdate(ar);
//                //String statementName = "insertNewAlarm";
//                //queryDao.insert(statementName, ar);
//            }
//            catch (Exception e)
//            {
//                XTrace.WriteException(e);
//            }
//        }
//    }
//}
