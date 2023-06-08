//using System.Collections;
//using System.Collections.Concurrent;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 实时数据服务
//    /// </summary>
//    public class RealDataServiceDbWrapper : IRealDataService
//    {
//        protected static ILog logger = log4net.LogManager.GetLogger(typeof(RealDataServiceWrapper));
//        /// <summary>
//        /// 实时数据服务
//        /// </summary>
//        private IRealDataService RealDataService { get; set; }
//        /// <summary>
//        /// 808消息线程
//        /// </summary>
//        private Thread processT808MsgThread;

//        public IBaseDao BaseDao { get; set; }
//        /// <summary>
//        /// 实时数据字典
//        /// </summary>
//        public ConcurrentDictionary<string, GPSRealData> realDataMap = new ConcurrentDictionary<string, GPSRealData>();


//        private Boolean IsContinue = true;
//        /// <summary>
//        /// 初始化
//        /// </summary>
//        public void Init()
//        {

//            String hql = "from GPSRealData order by SendTime ";
//            IList ls = BaseDao.query(hql);
//            foreach (GPSRealData rd in ls)
//            {
//                realDataMap[rd.SimNo] = rd;
//            }


//            processT808MsgThread = new Thread(new ThreadStart(ProcessMsgThreadFunc));
//            processT808MsgThread.Start();
//        }

//        /// <summary>
//        /// 开始监听客户端命令
//        /// </summary>
//        private void ProcessMsgThreadFunc()
//        {
//            logger.Info("开始监听客户端命令");
//            while (IsContinue)
//            {
//                try
//                {
//                    String hql = "from GPSRealData where SendTime > ? ";
//                    IList result = BaseDao.query(hql, DateTime.Now.AddMinutes(-10));
//                    foreach (GPSRealData rd in result)
//                    {
//                        realDataMap[rd.SimNo] = rd;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    logger.Error(ex.Message);
//                    logger.Error(ex.StackTrace);
//                }
//                Thread.Sleep(100);
//            }
//        }

//        /// <summary>
//        /// 获取实时数据
//        /// </summary>
//        /// <param name="simNo"></param>
//        /// <returns></returns>
//        public Domain.GPSRealData Get(string simNo)
//        {
//            GPSRealData rd = null;
//            try
//            {
//                this.realDataMap.TryGetValue(simNo, out rd);
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                // RealDataService = CreateRealDataService();
//            }
//            return rd;
//        }
//        /// <summary>
//        /// 获取实时数据列表
//        /// </summary>
//        /// <returns></returns>
//        public List<Domain.GPSRealData> GetOnlineRealDataList()
//        {
//            return new List<GPSRealData>();
//        }
//        /// <summary>
//        /// 获取实时数据列表
//        /// </summary>
//        /// <param name="simNoList"></param>
//        /// <returns></returns>
//        public List<Domain.GPSRealData> GetRealDataList(List<string> simNoList)
//        {
//            List<Domain.GPSRealData> result = new List<GPSRealData>();

//            foreach (String simNo in simNoList)
//            {
//                GPSRealData rd = this.Get(simNo);
//                if (rd != null)
//                    result.Add(rd);
//            }
//            return result;
//        }
//        /// <summary>
//        /// 更新
//        /// </summary>
//        /// <param name="rd"></param>
//        public void Update(Domain.GPSRealData rd)
//        {
//            //RealDataService.Update(rd);
//            this.BaseDao.saveOrUpdate(rd);
//        }
//        /// <summary>
//        /// 更新在线时间
//        /// </summary>
//        /// <param name="simNo"></param>
//        /// <param name="onlineDate"></param>
//        public void UpdateOnlineTime(string simNo, DateTime onlineDate)
//        {
//            //RealDataService.UpdateOnlineTime(simNo,onlineDate);
//        }
//        /// <summary>
//        /// 移除
//        /// </summary>
//        /// <param name="simNo"></param>
//        public void Remove(string simNo)
//        {
//            //RealDataService.Remove(simNo);
//        }
//        /// <summary>
//        /// 停止服务
//        /// </summary>
//        public void Stop()
//        {
//            try
//            {
//                if (processT808MsgThread != null)
//                    processT808MsgThread.Abort();
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//            }
//        }

//        /// <summary>
//        /// 获取车辆数据
//        /// </summary>
//        /// <param name="simNo"></param>
//        /// <returns></returns>
//        public VehicleData getVehicleData(string simNo)
//        {
//            throw new NotImplementedException();
//        }
//        /// <summary>
//        /// 获取终端数据
//        /// </summary>
//        /// <param name="termNo"></param>
//        /// <returns></returns>
//        public TerminalInfo getTerminalByTermNo(string termNo)
//        {
//            throw new NotImplementedException();
//        }
//        /// <summary>
//        /// 获取车辆数据
//        /// </summary>
//        /// <param name="plateNo"></param>
//        /// <returns></returns>
//        public VehicleData getVehicleByPlateNo(string plateNo)
//        {
//            throw new NotImplementedException();
//        }
//        /// <summary>
//        /// 更新车辆数据
//        /// </summary>
//        /// <param name="simNo"></param>
//        /// <param name="v"></param>
//        public void updateVehicleData(string simNo, VehicleData v)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
