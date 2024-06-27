using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using NewLife.Log;
using VehicleVedioManage.BasicData.Entity;
using VehicleVedioManage.ReportStatistics.Entity;
using VehicleVedioManage.Utility.Extends;
using VehicleVedioManage.Utility.MapService;
using VehicleVedioManage.Web.Enums;
using VehicleVedioManage.Web.IService;

namespace VehicleVedioManage.Web.Service
{
    /// <summary>
    /// 上线记录分析服务
    /// </summary>
    public class OnlineRecordService : IOnlineRecordService
    {
        public ConcurrentQueue<OnlineRecord> dataQueue = new ConcurrentQueue<OnlineRecord>();
        /// <summary>
        /// 终端报警服务
        /// </summary>
        public INewAlarmService NewAlarmService { get; set; }
        /// <summary>
        /// 报警配置映射
        /// </summary>
        public Hashtable alarmConfigMap { get; set; }
        /// <summary>
        /// 在线字典
        /// </summary>
        private ConcurrentDictionary<string, bool> onlineMap = new ConcurrentDictionary<string, bool>();
        /// <summary>
        /// 处理线程
        /// </summary>
        private Thread processThread;
        /// <summary>
        /// 离线时间
        /// </summary>
        private double MaxOfflineTime = 120 * 1;
        /// <summary>
        /// 是否继续
        /// </summary>
        private bool IsContinue = true;
        private readonly ITracer tracer;
         public OnlineRecordService(ITracer _tracer)
        {
            tracer = _tracer;
        }
        /// <summary>
        /// 启动上线记录分析服务
        /// </summary>
        public void Start()
        {
            tracer.NewSpan("处理服务已经启动");
            processThread = new Thread(new ThreadStart(ProcessRealDataThreadFunc));
            processThread.Start();

        }
        /// <summary>
        /// 停止上线记录分析服务
        /// </summary>
        public void Stop()
        {
            IsContinue = false;

            try
            {
                if (processThread != null)
                    processThread.Join();
            }
            catch (Exception ex)
            {
                tracer.NewSpan(ex.Message, ex);
            }
        }

        /// <summary>
        /// 处理实时数据
        /// </summary>
        private void ProcessRealDataThreadFunc()
        {
            int k = 0;
            while (IsContinue)
            {
                try
                {
                    int queueCount = dataQueue.Count;
                    if (queueCount > 200)
                    {
                        tracer.NewSpan("上线记录队列堵塞" + queueCount);
                    }
                    OnlineRecord tm = null;
                    this.dataQueue.TryDequeue(out tm);
                    List<OnlineRecord> msgList = new List<OnlineRecord>();
                    while (tm != null)
                    {
                        try
                        {
                            if (tm.AlarmType == AlarmRecordExtend.TYPE_ONLINE)
                            {
                                CreateOnlineChangeRecord(tm);
                            }
                            else
                            {
                                String alarmType = tm.AlarmType.Equals(
                                        AlarmRecordExtend.TYPE_ONLINE) ? AlarmRecordExtend.TYPE_OFFLINE
                                        : AlarmRecordExtend.TYPE_ONLINE;
                                tm.AlarmType = (alarmType);
                                tm.Status = (AlarmRecordExtend.STATUS_OLD);
                                CreateOnlineChangeRecord(tm);
                            }
                            dataQueue.TryDequeue(out tm);
                        }
                        catch (Exception ex)
                        {
                            tracer.NewSpan(ex.Message, ex);
                        }
                    }
                    if (msgList.Count > 0)
                    {
                        //saveAlarmRecord(msgList);
                    }

                }
                catch (Exception ex)
                {
                    tracer.NewSpan(ex.Message+System.Environment.NewLine+ex.StackTrace);
                }

                k++;
                Thread.Sleep(500);
            }

        }
        /// <summary>
        /// 核查是否在线
        /// </summary>
        /// <param name="rd"></param>
        public void checkOnline(GPSRealData rd)
        {
            Boolean oldOnlineState = false;
            if (onlineMap.ContainsKey(rd.PlateNo))
            {
                oldOnlineState = onlineMap[rd.PlateNo];
            }
            if (oldOnlineState == rd.Online)
                return;

            if (NewAlarmService.isAlarmEnabled(AlarmRecordExtend.TYPE_ONLINE, AlarmRecordExtend.ALARM_FROM_PLATFORM)
                == false && NewAlarmService.isAlarmEnabled(AlarmRecordExtend.TYPE_OFFLINE, AlarmRecordExtend.ALARM_FROM_PLATFORM) == false)
            {
                return;//没有使用
            }

            onlineMap[rd.PlateNo] = rd.Online;

            String alarmType = rd.Online ? AlarmRecordExtend.TYPE_ONLINE: AlarmRecordExtend.TYPE_OFFLINE;
            OnlineRecord r = new OnlineRecord(rd, alarmType, AlarmRecordExtend.ALARM_FROM_PLATFORM,AlarmRecordExtend.STATUS_NEW);
            if (NewAlarmService.isAlarmEnabled(alarmType, AlarmRecordExtend.ALARM_FROM_PLATFORM))
            {
                NewAlarmService.insertAlarm(AlarmRecordExtend.ALARM_FROM_PLATFORM,
                        alarmType, rd);
            }
            else
                return;

            if (dataQueue.Count > 500)
            {
                tracer.NewSpan("上线记录队列堵塞，堵塞队列:" + dataQueue.Count);
                //dataQueue.TryDequeue();
            }
            dataQueue.Enqueue(r);
        }
        /// <summary>
        /// 创建在线变化记录
        /// </summary>
        /// <param name="rd"></param>
        public void CreateOnlineChangeRecord(OnlineRecord rd)
        {
            var OperateType = rd.AlarmType;
            //查看是否有未消除的报警记录
            var sr = OnlineRecord.FindByPlateNoStatusAlarmType(rd.PlateNo,AlarmRecordExtend.STATUS_NEW, OperateType );

            if (sr == null && AlarmRecordExtend.STATUS_NEW.Equals(rd.Status))
            {
                //createAlarm(AlarmRecord.ALARM_FROM_PLATFORM, OperateType, rd);//创建报警，等待推送到前台
                sr = new OnlineRecord();
                sr.PlateNo = rd.PlateNo;
                sr.StartTime = rd.StartTime;
                sr.Status = AlarmRecordExtend.STATUS_NEW;
                sr.EndTime = System.DateTime.Now;
                sr.Latitude = rd.Latitude;
                sr.Longitude = rd.Longitude;
                sr.Location = rd.Location;
                //sr.Acc = rd.GetAccState();
                if (String.IsNullOrEmpty(sr.Location))
                {
                    MapFix mapFix = new MapFix(tracer);
                    sr.Location = mapFix.GetLocation(sr.Longitude, sr.Latitude);
                }
                sr.AlarmType = OperateType;
                sr.AlarmSource = AlarmRecordExtend.ALARM_FROM_PLATFORM;
                sr.Update();
            }
            else if (sr != null && AlarmRecordExtend.STATUS_OLD.Equals(rd.Status))
            {
                sr.EndTime = rd.StartTime;
                TimeSpan t = sr.EndTime - sr.StartTime;
                sr.TimeSpan = t.TotalMinutes;

                sr.Status = AlarmRecordExtend.STATUS_OLD;
                sr.EndTime = DateTime.Now;// rd.SendTime;
                sr.Latitude1 = rd.Latitude;
                sr.Longitude1 = rd.Longitude;

                sr.AlarmType = OperateType;
                sr.Update();
            }
        }

    }
}
