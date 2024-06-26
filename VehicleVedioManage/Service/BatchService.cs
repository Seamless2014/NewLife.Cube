using System.Collections.Concurrent;
using VehicleVedioManage.ReportStatistics.Entity;
using VehicleVedioManage.Web.IService;
using NewLife.Log;
using XCode;

namespace VehicleVedioManage.Web.Service
{
    /// <summary>
    /// 批量服务
    /// </summary>
    public class BatchService : IBatchService
    {
        /// <summary>
        /// 链接字符串
        /// </summary>
        public String connectionString { get; set; }
        /// <summary>
        /// 808处理线程
        /// </summary>
        private Thread processT808MsgThread;
        /// <summary>
        /// gpsinfo队列
        /// </summary>
        public ConcurrentQueue<GpsInfo> gpsInfoQueue = new ConcurrentQueue<GpsInfo>();
        /// <summary>
        /// 是否继续
        /// </summary>
        private Boolean isContinue = true;
        /// <summary>
        /// 当前队列数量
        /// </summary>
        public int QueueNum { get; set; }
        /// <summary>
        /// 批量插入间隔
        /// </summary>
        public int batchInsertInterval { get; set; }
        /// <summary>
        /// 批量插入数量
        /// </summary>
        public int batchInsertNum { get; set; }
        private readonly ITracer tracer;

        public BatchService(ITracer _tracer)
        {
            batchInsertNum = 2000;
            batchInsertInterval = 30000;
            tracer = _tracer;
        }
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="g"></param>
        public void EnQueue(GpsInfo g)
        {
            gpsInfoQueue.Enqueue(g);
        }
        /// <summary>
        /// 获取队列数
        /// </summary>
        /// <returns></returns>
        public int GetQueueNum()
        {
            return QueueNum;
        }
        /// <summary>
        /// 处理消息线程
        /// </summary>
        private void ProcessMsgThreadFunc()
        {
            while (isContinue)
            {
                try
                {
                    int m = 0;
                    List<GpsInfo> result = new List<GpsInfo>();
                    Boolean res = true;
                    while (res && m < batchInsertNum)
                    {
                        GpsInfo rd = null;
                        res = gpsInfoQueue.TryDequeue(out rd);
                        if (rd != null)
                            result.Add(rd);
                        else
                            break;
                        m++;
                    }

                    if (result.Count > 0)
                    {
                        DateTime start = DateTime.Now;
                        insertData(result);
                        if (result.Count > 500)
                        {
                            DateTime end = DateTime.Now;
                            TimeSpan ts = end - start;
                            if (ts.TotalSeconds > 0.8)
                            {
                                tracer.NewSpan("队列数:" + QueueNum + "插入历史数据,条数:" + result.Count + ",耗时:" + ts.TotalSeconds);
                            }
                        }
                    }
                    this.QueueNum = gpsInfoQueue.Count;
                }
                catch (Exception ex)
                {
                    tracer.NewSpan(ex.Message, ex);
                }
                Thread.Sleep(batchInsertInterval);
            }


        }
        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            isContinue = false;
            if (processT808MsgThread != null)
                processT808MsgThread.Join();
        }
        /// <summary>
        /// 开始服务
        /// </summary>
        public void Start()
        {
            try
            {
                processT808MsgThread = new Thread(new ThreadStart(ProcessMsgThreadFunc));
                processT808MsgThread.Start();
                tracer.NewSpan("批量插入服务启动成功");
            }
            catch (Exception ex)
            {
                tracer.NewSpan(ex.Message, ex);
            }
            finally
            {
            }


        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="gpsList"></param>
        public void insertData(List<GpsInfo> gpsLists)
        {
            try
            {
                gpsLists.Insert();
            }
            catch (Exception ex)
            {
                tracer.NewSpan("insertData", ex.Message);
            }
        }

        public GpsInfo DeQueue() => throw new NotImplementedException();
    }
}
