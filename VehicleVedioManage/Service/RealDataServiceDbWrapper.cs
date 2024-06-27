using System.Collections;
using System.Collections.Concurrent;
using NewLife.Log;
using VehicleVedioManage.BackManagement.Entity;
using VehicleVedioManage.BasicData.Entity;
using VehicleVedioManage.ReportStatistics.Entity;
using VehicleVedioManage.Web.IService;
using XCode;

namespace VehicleVedioManage.Web.Service
{
    /// <summary>
    /// 实时数据服务
    /// </summary>
    public class RealDataServiceDbWrapper : IRealDataService
    {
        /// <summary>
        /// 实时数据服务
        /// </summary>
        private IRealDataService RealDataService { get; set; }
        /// <summary>
        /// 808消息线程
        /// </summary>
        private Thread processT808MsgThread;
        /// <summary>
        /// 实时数据字典
        /// </summary>
        public ConcurrentDictionary<string, GPSRealData> realDataMap = new ConcurrentDictionary<string, GPSRealData>();


        private Boolean IsContinue = true;
        private readonly ITracer tracer;
        public RealDataServiceDbWrapper(IRealDataService realDataService, Thread processT808MsgThread, ConcurrentDictionary<String, GPSRealData> realDataMap, Boolean isContinue, ITracer tracer)
        {
            RealDataService = realDataService;
            this.processT808MsgThread = processT808MsgThread;
            this.realDataMap = realDataMap;
            IsContinue = isContinue;
            this.tracer = tracer;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            IList<GPSRealData> ls =GPSRealData.FindAllBy(new XCode.WhereExpression());
            foreach (GPSRealData rd in ls)
            {
                realDataMap[rd.SimNo] = rd;
            }


            processT808MsgThread = new Thread(new ThreadStart(ProcessMsgThreadFunc));
            processT808MsgThread.Start();
        }

        /// <summary>
        /// 开始监听客户端命令
        /// </summary>
        private void ProcessMsgThreadFunc()
        {
            tracer.NewSpan("开始监听客户端命令");
            while (IsContinue)
            {
                try
                {
                    var result = GPSRealData.FindAllBySendTime(DateTime.Now.AddMinutes(-10));
                    foreach (var rd in result)
                    {
                        realDataMap[rd.SimNo] = rd;
                    }
                }
                catch (Exception ex)
                {
                    tracer.NewError(ex.Message+System.Environment.NewLine+ex.StackTrace,ex);
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 获取实时数据
        /// </summary>
        /// <param name="simNo"></param>
        /// <returns></returns>
        public GPSRealData Get(string simNo)
        {
            GPSRealData rd = null;
            try
            {
                realDataMap.TryGetValue(simNo, out rd);
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message+System.Environment.NewLine+ex.StackTrace, ex);
                // RealDataService = CreateRealDataService();
            }
            return rd;
        }
        /// <summary>
        /// 获取实时数据列表
        /// </summary>
        /// <returns></returns>
        public List<GPSRealData> GetOnlineRealDataList()
        {
            return new List<GPSRealData>();
        }
        /// <summary>
        /// 获取实时数据列表
        /// </summary>
        /// <param name="simNoList"></param>
        /// <returns></returns>
        public List<GPSRealData> GetRealDataList(List<string> simNoList)
        {
            List<GPSRealData> result = new List<GPSRealData>();

            foreach (String simNo in simNoList)
            {
                GPSRealData rd = this.Get(simNo);
                if (rd != null)
                    result.Add(rd);
            }
            return result;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="rd"></param>
        public void Update(GPSRealData rd)
        {
            rd.Upsert();
        }
        /// <summary>
        /// 更新在线时间
        /// </summary>
        /// <param name="simNo"></param>
        /// <param name="onlineDate"></param>
        public void UpdateOnlineTime(string simNo, DateTime onlineDate)
        {
            //RealDataService.UpdateOnlineTime(simNo,onlineDate);
        }
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="simNo"></param>
        public void Remove(string simNo)
        {
            //RealDataService.Remove(simNo);
        }
        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            try
            {
                if (processT808MsgThread != null)
                    processT808MsgThread.Abort();
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message+System.Environment.NewLine+ex.StackTrace, ex);
            }
        }

        /// <summary>
        /// 获取车辆数据
        /// </summary>
        /// <param name="simNo"></param>
        /// <returns></returns>
        public Vehicle getVehicleData(string simNo)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取终端数据
        /// </summary>
        /// <param name="termNo"></param>
        /// <returns></returns>
        public TerminalInfo getTerminalByTermNo(string termNo)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取车辆数据
        /// </summary>
        /// <param name="plateNo"></param>
        /// <returns></returns>
        public Vehicle getVehicleByPlateNo(string plateNo)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 更新车辆数据
        /// </summary>
        /// <param name="simNo"></param>
        /// <param name="v"></param>
        public void updateVehicleData(string simNo, Vehicle v)
        {
            throw new NotImplementedException();
        }
    }
}
