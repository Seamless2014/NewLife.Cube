using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewLife;
using NewLife.Log;
using NewLife.Threading;
using VehicleVedioManage.FenceManagement.Entity;
using VehicleVedioManage.IService;
using VehicleVedioManage.ReportStatistics.Entity;
using VehicleVedioManage.Utility.Extends;
using VehicleVedioManage.Utility.MapService;
using VehicleVedioManage.Web.Enums;
using VehicleVedioManage.Web.IService;
using VehicleVedioManage.Web.Models;
using XCode;

namespace VehicleVedioManage.Web.Service
{
    /// <summary>
    /// 报警服务
    /// </summary>
    public class AlarmService : IAlarmService
    {
        /// <summary>
        /// ORM
        /// </summary>
        public IBaseDao BaseDao { get; set; }
        /// <summary>
        /// 电子围栏
        /// </summary>
        public List<MapArea> Enclosures = new List<MapArea>();
        /// <summary>
        /// 偏离路线报警
        /// </summary>
        private Hashtable offsetRouteWarn = new Hashtable();
        /// <summary>
        /// 路线点映射
        /// </summary>
        public Hashtable routePointMap = new Hashtable();
        /// <summary>
        /// 报警映射
        /// </summary>
        public Hashtable alarmMap = new Hashtable();
        /// <summary>
        /// 上线记录服务
        /// </summary>
        public IOnlineRecordService OnlineRecordService { get; set; }

        /// <summary>
        /// 是否开始报警
        /// </summary>
        public bool StartAreaAlarm { get; set; }

        /// <summary>
        /// 区域信息映射
        /// </summary>
        private ConcurrentDictionary<string, MapArea> AreaInfoMap = new ConcurrentDictionary<string, MapArea>();
        /// <summary>
        /// 实时数据队列
        /// </summary>
        public ConcurrentQueue<AlarmRecordVM> realDataQueue = new ConcurrentQueue<AlarmRecordVM>();
        /// <summary>
        /// 809转发服务
        /// </summary>
        public IJT809TransferService JT809TransferService { get; set; }
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
        /// 聚合报警
        /// </summary>
        public bool GatherAlarm { get; set; }
        /// <summary>
        /// 终端报警
        /// </summary>
        public INewAlarmService NewAlarmService { get; set; }

        private readonly ITracer _tracer;
        private TimerX _timer;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        public AlarmService(IServiceProvider provider)
        {
            _tracer = provider?.GetService<ITracer>();
        }
        /// <summary>
        /// 
        /// </summary>
        public AlarmService()
        {
            Interval = 100;
        }

        /// <summary>
        /// 启动报警分析服务
        /// </summary>
        public  Task StartAsync()
        {
            XTrace.Log.Info("启动报警分析服务");
            _timer = new TimerX(ProcessRealDataThreadFunc, null, 5_000, 30_000) { Async = true };
            try
            {
                var ls= AlarmRecord.FindAllByStatus(AlarmRecordExtend.STATUS_NEW);
                foreach (var r in ls)
                {
                    var key = r.PlateNo + "_" + r.AlarmType + "_"
                            + r.AlarmSource;
                    alarmMap[key] = r;
                }
            }
            catch (Exception ex)
            {
                XTrace.Log.Error(ex.Message);
            }
            return Task.CompletedTask;
        }


        /// <summary>
        /// 处理实时数据
        /// </summary>
        private void ProcessRealDataThreadFunc(object state)
        {
            //XTrace.Log.Info("处理报警队列");
            int k = 0;
            while (IsContinue)
            {
                try
                {
                    AlarmRecordVM tm = null;
                    realDataQueue.TryDequeue(out tm);
                    var  msgList = new List<AlarmRecord>();
                    while (tm != null)
                    {
                        var ar = (AlarmRecord)tm;
                        msgList.Add(ar);
                        if (msgList.Count > 30)
                            break;
                        realDataQueue.TryDequeue(out tm);
                    }
                    if (msgList.Count > 0)
                    {
                        saveAlarmRecord(msgList);
                    }
                    var alarmQueueNum = realDataQueue.Count;

                }
                catch (Exception ex)
                {
                    XTrace.Log.Error(ex.Message);
                }


                Thread.Sleep(Interval);
            }

        }
        /// <summary>
        /// 保存报警记录
        /// </summary>
        /// <param name="msgList"></param>
        private void saveAlarmRecord(List<AlarmRecord> msgList)
        {

            foreach (var r in msgList)
            {
                try
                {
                    if (r.Status.Equals(AlarmRecordExtend.STATUS_NEW))
                    {
                        r.Update();
                    }
                    else
                    {
                        r.Upsert();
                    }
                }
                catch (Exception ex)
                {
                    XTrace.Log.Error(ex.Message, ex);
                }
            }

        }
        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            IsContinue = false;
            try
            {
                if (processThread != null)
                    processThread.Join();

                if (NewAlarmService != null)
                    NewAlarmService.Stop();
            }
            catch (Exception ex)
            {
                XTrace.Log.Error(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取旧的区域信息
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
        /// 处理实时数据
        /// </summary>
        /// <param name="rd"></param>
        public void processRealData(GPSRealData rd)
        {
            try
            {
                if (string.IsNullOrEmpty(rd.PlateNo))
                {
                    return;
                }

                string newStatus = rd.Status;
                string newAlarmState = rd.AlarmState;

                CreateChangeRecord(AlarmRecordExtend.STATE_FROM_TERM, newStatus, rd);
                CreateChangeRecord(AlarmRecordExtend.ALARM_FROM_TERM, newAlarmState, rd);
                // 停车报警
                if (NewAlarmService.isAlarmEnabled(AlarmRecordExtend.TYPE_PARKING,
                        AlarmRecordExtend.ALARM_FROM_PLATFORM))
                {
                    String alarmState = rd.Velocity < 1 ? AlarmRecordExtend.TURN_ON
                            : AlarmRecordExtend.TURN_OFF;
                    if (alarmState == AlarmRecordExtend.TURN_ON)
                        NewAlarmService.insertAlarm(AlarmRecordExtend.ALARM_FROM_PLATFORM, AlarmRecordExtend.TYPE_PARKING, rd);

                    analyzeAlarm(rd, AlarmRecordExtend.TYPE_PARKING,
                            AlarmRecordExtend.ALARM_FROM_PLATFORM, alarmState);
                }
            }
            catch (Exception ex)
            {
                XTrace.Log.Error(ex.Message, ex);
            }
        }
        /// <summary>
        /// 创建停车记录
        /// </summary>
        /// <param name="rd"></param>
        /// <param name="oldRd"></param>
        public void CreateParkingRecord(GPSRealData rd, GPSRealData oldRd)
        {
            int minVelocity = 2;
            if (rd.Velocity < minVelocity && oldRd.Velocity < minVelocity)
                return;
            if (rd.Velocity >= minVelocity && oldRd.Velocity >= minVelocity)
                return;
            var exp = new WhereExpression();
            if (!rd.PlateNo.IsNullOrEmpty()) exp &= AlarmRecord._.PlateNo == rd.PlateNo;
            if (!AlarmRecordEnum.TYPE_PARKING.ToString().IsNullOrEmpty()) exp &= AlarmRecord._.AlarmType == AlarmRecordEnum.TYPE_PARKING;
            if (!AlarmRecordEnum.STATUS_NEW.ToString().IsNullOrEmpty()) exp &=AlarmRecord._.Status == AlarmRecordEnum.STATUS_NEW;
            var sr = AlarmRecord.FindAllByWhereExpress(exp);

            if (sr == null)
            {
                if (rd.Velocity >= minVelocity)
                    return;

                sr = new AlarmRecord();
                sr.PlateNo = rd.PlateNo;
                sr.StartTime = rd.SendTime;
                sr.Status = AlarmRecordEnum.STATUS_NEW.ToString();
                sr.EndTime = System.DateTime.Now;
                sr.AlarmSource = AlarmRecordExtend.ALARM_FROM_PLATFORM;//平台报警
                MapFix mapFix = new MapFix(_tracer);
                sr.Location = mapFix.GetLocation(rd.Longitude, rd.Latitude);
                sr.Latitude = rd.Latitude;
                sr.Longitude = rd.Longitude;
                //记录下油量和里程
                //sr.Oil1 = rd.Oil;
                sr.Mileage1 = rd.Mileage;
            }
            else
            {
                sr.EndTime = System.DateTime.Now;
                TimeSpan t = rd.SendTime - sr.StartTime;
                sr.TimeSpan = t.TotalMinutes;
                sr.EndTime = rd.SendTime;

                if (rd.Velocity >= minVelocity)
                {
                    sr.Status = AlarmRecordExtend.STATUS_OLD;
                    sr.Latitude1 = rd.Latitude;
                    sr.Longitude1 = rd.Longitude;

                    //记录下油量和里程
                    //sr.Oil2 = rd.Oil;
                    sr.Mileage2 = rd.Mileage;
                }
                else
                {
                    return;
                }

            }
            sr.AlarmType = AlarmRecordExtend.TYPE_PARKING;
            sr.Upsert();
        }
        /// <summary>
        /// 创建报警变化记录
        /// </summary>
        /// <param name="alarmSource"></param>
        /// <param name="newStatus"></param>
        /// <param name="rd"></param>
        private void CreateChangeRecord(string alarmSource, string newStatus, GPSRealData rd)
        {
            char[] newChars = (char[])newStatus.ToCharArray();

            for (int m = 0; m < newChars.Length; m++)
            {
                int alarmId = 31 - m;
                String alarmType = "" + alarmId;
                String alarmState = "" + newChars[m];

                if (alarmSource.Equals(AlarmRecordExtend.ALARM_FROM_TERM))
                {
                    if (alarmId == 20)
                    {
                        alarmType = rd.AreaAlarm == 0 ? AlarmRecordExtend.TYPE_IN_AREA
                                : AlarmRecordExtend.TYPE_CROSS_BORDER;
                    }
                    else if (alarmId == 21)
                    {
                        alarmType = rd.AreaAlarm == 0 ? AlarmRecordExtend.TYPE_ON_ROUTE
                                : AlarmRecordExtend.TYPE_OFFSET_ROUTE;
                    }

                    if ((alarmId == 20 || alarmId == 21) && rd.AreaId > 0)
                    {
                        //String hql = "from Enclosure where enclosureId = ?";
                        //MapArea e = (MapArea)BaseDao.find(hql, rd.AreaId);
                        //if (e != null)
                        //    rd.Location = "区域:" + e.Name;
                    }
                }

                // 转发报警信息
                if (alarmSource.Equals(AlarmRecordExtend.ALARM_FROM_TERM)
                        && alarmState.Equals(AlarmRecordExtend.TURN_ON)
                        && NewAlarmService.isAlarmEnabled(alarmType, alarmSource))
                {
                    if (alarmId == 20)
                    {
                        alarmType = rd.AreaAlarm == 0 ? AlarmRecordExtend.TYPE_IN_AREA
                                : AlarmRecordExtend.TYPE_CROSS_BORDER;
                    }
                    else if (alarmId == 21)
                    {
                        alarmType = rd.AreaAlarm == 0 ? AlarmRecordExtend.TYPE_ON_ROUTE
                                : AlarmRecordExtend.TYPE_OFFSET_ROUTE;
                    }
                    if ((alarmId == 20 || alarmId == 21) && rd.AreaId > 0)
                    {
                        try
                        {
                            var area = MapArea.FindByAreaId(rd.AreaId);
                            if (area != null)
                            {
                                var location = alarmId == 20 ? "区域：" : "线路:";
                                location += area.Name;
                                rd.Location = (location);
                            }
                        }
                        catch (Exception ex)
                        {
                            XTrace.Log.Error(ex.Message, ex);
                        }
                    }
                    NewAlarmService.insertAlarm(alarmSource, alarmType, rd);
                }

                if (NewAlarmService.isAlarmEnabled(alarmType, alarmSource))
                {
                    if (alarmId == 20)
                    {
                        alarmType = AlarmRecordExtend.TYPE_IN_AREA;
                        if (rd.AreaAlarm == 1)
                            alarmState = AlarmRecordExtend.TURN_OFF;
                    }
                    else if (alarmId == 21)
                    {
                        alarmType = AlarmRecordExtend.TYPE_ON_ROUTE;
                        if (rd.AreaAlarm == 1)
                            alarmState = AlarmRecordExtend.TURN_OFF;
                    }
                    analyzeAlarm(rd, alarmType, alarmSource, alarmState);
                }
            }
        }
        /// <summary>
        /// 报警分析
        /// </summary>
        /// <param name="rd"></param>
        /// <param name="alarmType"></param>
        /// <param name="alarmSource"></param>
        /// <param name="alarmState"></param>
        private void analyzeAlarm(GPSRealData rd, String alarmType,String alarmSource, String alarmState)
        {
            if (this.NewAlarmService.isAlarmStatisticEnabled(alarmType, alarmSource) == false)
                return;
            String alarmKey = rd.PlateNo + "_" + alarmType + "_" + alarmSource;
            if (alarmState.Equals(AlarmRecordExtend.TURN_ON))
            {
                // 发生报警
                if (alarmMap.ContainsKey(alarmKey) == false)
                {
                    AlarmRecordVM item = new AlarmRecordVM(rd, alarmType, alarmSource);
                    realDataQueue.Enqueue(item);
                    alarmMap[alarmKey] = item;
                }
                else
                {
                    AlarmRecordVM item = (AlarmRecordVM)alarmMap[alarmKey];
                    if (item.Status.Equals(AlarmRecordExtend.STATUS_OLD))
                    {
                        AlarmRecordVM itemNew = new AlarmRecordVM(rd, alarmType,alarmSource);
                        realDataQueue.Enqueue(itemNew);
                        alarmMap[alarmKey] = item;
                    }
                }
            }
            else if (alarmState.Equals(AlarmRecordExtend.TURN_OFF))
            {
                if (alarmMap.ContainsKey(alarmKey))
                {
                    AlarmRecordVM item = (AlarmRecordVM)alarmMap[alarmKey];
                    // item.setOpen(false);
                    alarmMap.Remove(alarmKey);
                    item.Status = AlarmRecordExtend.STATUS_OLD;
                    item.EndTime = DateTime.Now;
                    item.Latitude1 = rd.Latitude;
                    item.Longitude1 = rd.Longitude;
                    TimeSpan t = item.EndTime - item.StartTime;
                    item.TimeSpan = t.TotalMinutes;
                    realDataQueue.Enqueue(item);
                    // this.CreateWarnRecord(AlarmRecord.ALARM_FROM_TERM, alarmType,
                    // alarmState, rd);
                }
            }
        }
        /// <summary>
        /// 创建报警记录
        /// </summary>
        /// <param name="AlarmSrc"></param>
        /// <param name="AlarmType"></param>
        /// <param name="warnState"></param>
        /// <param name="rd"></param>
        private void CreateAlarmRecord(string AlarmSrc, string AlarmType, string warnState, GPSRealData rd)
        {
            AlarmRecord sr = CreateRecord(AlarmSrc, AlarmType, warnState, rd);
            if (sr != null)
                sr.Upsert();
        }

        /// <summary>
        /// 创建记录
        /// </summary>
        /// <param name="AlarmSrc"></param>
        /// <param name="AlarmType"></param>
        /// <param name="alarmStatus"></param>
        /// <param name="rd"></param>
        /// <returns></returns>
        private AlarmRecord CreateRecord(string AlarmSrc, string AlarmType, string alarmStatus, GPSRealData rd)
        {

            var exp = new WhereExpression();
            if (!rd.PlateNo.IsNullOrEmpty()) exp &= AlarmRecord._.PlateNo == rd.PlateNo;
            if (!AlarmSrc.IsNullOrEmpty()) exp &= AlarmRecord._.AlarmSource == AlarmSrc;
            if (!AlarmRecordExtend.STATUS_NEW.IsNullOrEmpty()) exp &= AlarmRecord._.Status == AlarmRecordEnum.STATUS_NEW;
            if (!AlarmType.IsNullOrEmpty()) exp &= AlarmRecord._.AlarmType == AlarmType;
            var sr = AlarmRecord.FindAllByWhereExpress(exp);

            if (sr == null)
            {
                if (alarmStatus == AlarmRecordExtend.TURN_OFF)
                    return null;
                sr = new AlarmRecord();
                if (AlarmType == "19")
                {
                    /**
                    Enclosure ec = IsInAreaInfo(rd);
                    if (ec != null)
                    {
                        sr.Station = ec.EntityId;
                        sr.Location = ec.Name;
                    }*/
                }

                sr.PlateNo = rd.PlateNo;
                sr.StartTime = rd.SendTime;
                sr.Status = AlarmRecordExtend.STATUS_NEW;
                sr.EndTime = System.DateTime.Now;
                sr.Latitude = rd.Latitude;
                sr.Longitude = rd.Longitude;
                sr.Location = rd.Location;
                if (String.IsNullOrEmpty(sr.Location))
                {
                    var mapFix = new MapFix(_tracer);
                    sr.Location = mapFix.GetLocation(sr.Longitude, sr.Latitude);
                }
                sr.Velocity = rd.Velocity;
            }
            else
            {
                sr.EndTime = System.DateTime.Now;
                var t = rd.SendTime - sr.StartTime;
                sr.TimeSpan = t.TotalMinutes;
                if (alarmStatus == AlarmRecordExtend.TURN_OFF)
                {
                    sr.Status = AlarmRecordExtend.STATUS_OLD;
                    sr.EndTime = rd.SendTime;

                    sr.Latitude1 = rd.Latitude;
                    sr.Longitude1 = rd.Longitude;
                }
                else
                    return null;
            }
            sr.AlarmSource = AlarmSrc;
            sr.AlarmType = AlarmType;
            return sr;
        }
    }
}
