//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 实时数据服务
//    /// </summary>
//    public class RealDataServiceWrapper : IRealDataService
//    {
//        protected static ILog logger = log4net.LogManager.GetLogger(typeof(RealDataServiceWrapper));
//        /// <summary>
//        /// 实时数据服务
//        /// </summary>
//        private IRealDataService RealDataService { get; set; }
//        /// <summary>
//        /// JT808消息处理
//        /// </summary>
//        private Thread processT808MsgThread;
//        /// <summary>
//        /// 是否继续
//        /// </summary>
//        private Boolean IsContinue = true;
//        /// <summary>
//        /// 初始化
//        /// </summary>
//        public void Init()
//        {
//            CreateRealDataService();

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
//                    IClientChannel channel = (IClientChannel)RealDataService;
//                    if (channel.State == CommunicationState.Created)
//                    {
//                        channel.Open();
//                        logger.Info("断线重连接成功!");
//                    }
//                }
//                catch (EndpointNotFoundException ee)
//                {
//                    logger.Error("无法连接到实时数据服务,错误:"+ ee.Message + "，开始自动重连");
//                    try
//                    {
//                        CreateRealDataService();
//                    }
//                    catch (Exception ex)
//                    {
//                        logger.Error("重新连接时，创建服务失败:" + ex.Message, ex);
//                    }
//                    Thread.Sleep(500);
//                }
//                catch (Exception ex)
//                {
//                    logger.Error(ex.Message);
//                    try
//                    {
//                        CreateRealDataService();
//                    }
//                    catch (Exception e)
//                    {
//                        logger.Error("重新连接时，创建服务失败:" + e.Message, e);
//                    }
//                }
//                Thread.Sleep(100);
//            }
//        }
//        /// <summary>
//        /// 实时数据服务工厂
//        /// </summary>
  
//        private ChannelFactory<IRealDataService> RealDataServiceFactory = null;
//        /// <summary>
//        /// 创建实时数据服务
//        /// </summary>
//        /// <returns></returns>
//        public IRealDataService CreateRealDataService()
//        {
//            if (RealDataServiceFactory == null)
//                RealDataServiceFactory = new ChannelFactory<IRealDataService>("NetTcpBinding_IRealDataService");

//            if (RealDataService != null)
//            {
//                try
//                {
//                    ((IClientChannel)RealDataService).Abort();
//                }
//                catch (Exception ex)
//                {
//                    logger.Error("RealDataService abort时发生异常:" + ex.Message);
//                }
//            }
//            IRealDataService client = RealDataServiceFactory.CreateChannel();

//            RealDataService = (IRealDataService)client;
//            ((IClientChannel)client).Faulted += new EventHandler(ProxyServiceFactory_Faulted);
//            //((IClientChannel)client).Open();
//            IClientChannel channel = (IClientChannel)client;
            
//            return client;
//        }
//        /// <summary>
//        /// 服务代理工厂出错
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        void ProxyServiceFactory_Faulted(object sender, EventArgs e)
//        {
//            try
//            {
//                ((ICommunicationObject)sender).Abort();
//                if (sender is IRealDataService)
//                {

//                    //Thread.Sleep(10);
//                    sender = RealDataServiceFactory.CreateChannel();
//                    RealDataService = (IRealDataService)sender;
//                }
//            }
//            catch (Exception ex)
//            {
//                logger.Error("重建错误:"+ex.Message, ex);
//                //Thread.Sleep(10);
//                CreateRealDataService();
//            }
//        }
        
//        /// <summary>
//        /// 获取实时数据
//        /// </summary>
//        /// <param name="plateNo"></param>
//        /// <returns></returns>
//        public Domain.GPSRealData Get(string plateNo)
//        {
//            try
//            {
//                IClientChannel ic = (IClientChannel)RealDataService;
//                if(ic.State == CommunicationState.Opened)
//                   return RealDataService.Get(plateNo);
//                else if (ic.State == CommunicationState.Faulted)
//                {
//                    CreateRealDataService();
//                }
//            }
//            catch (CommunicationException ce)
//            {
//                logger.Error("RealDataService实时数据服务终止，开始重新连接");
//                CreateRealDataService();
//                // RealDataService = CreateRealDataService();
//            }
//            return null;
//        }
//        /// <summary>
//        /// 获取在线实时数据列表
//        /// </summary>
//        /// <returns></returns>
//        public List<Domain.GPSRealData> GetOnlineRealDataList()
//        {
//            IClientChannel ic = (IClientChannel)RealDataService;
//            if (ic.State != CommunicationState.Opened)
//            {
//                String state = ic.State == CommunicationState.Faulted ? "故障" : ("" + ic.State);
//                logger.Error("实时数据服务通道没有打开，通道状态:" + state);
//                return new List<Domain.GPSRealData>();

//            }
//            return RealDataService.GetOnlineRealDataList();
//        }
//        /// <summary>
//        /// 获取实时数据列表
//        /// </summary>
//        /// <param name="simNoList"></param>
//        /// <returns></returns>
//        public List<Domain.GPSRealData> GetRealDataList(List<string> simNoList)
//        {

//            IClientChannel ic = (IClientChannel)RealDataService;
//            if (ic.State != CommunicationState.Opened)
//            {
//                String state = ic.State == CommunicationState.Faulted ? "故障" : (""+ic.State);
//                logger.Error("实时数据服务通道没有打开，通道状态:" +state);
//                return new List<Domain.GPSRealData>();

//            }
//            try
//            {
//                return RealDataService.GetRealDataList(simNoList);
//            }
//            catch (CommunicationException ce)
//            {
//                logger.Error("GetOnlineRealDataList实时数据服务终止，开始重新连接");
//                //CreateRealDataService();
//                // RealDataService = CreateRealDataService();
//                return new List<Domain.GPSRealData>();
//            }
//        }
//        /// <summary>
//        /// 更新
//        /// </summary>
//        /// <param name="rd"></param>
//        public void Update(Domain.GPSRealData rd)
//        {
//             RealDataService.Update(rd);
//        }
//        /// <summary>
//        /// 更新在线时间
//        /// </summary>
//        /// <param name="simNo"></param>
//        /// <param name="onlineDate"></param>
//        public void UpdateOnlineTime(string simNo,DateTime onlineDate)
//        {
//            RealDataService.UpdateOnlineTime(simNo,onlineDate);
//        }
//        /// <summary>
//        /// 移除
//        /// </summary>
//        /// <param name="simNo"></param>
//        public void Remove(string simNo)
//        {
//            RealDataService.Remove(simNo);
//        }
//        /// <summary>
//        /// 停止服务
//        /// </summary>
//        public void Stop()
//        {
//            RealDataService.Stop();
//        }

//        /// <summary>
//        /// 获取车辆数据
//        /// </summary>
//        /// <param name="simNo"></param>
//        /// <returns></returns>
//        public Domain.VehicleData getVehicleData(string simNo)
//        {
//            return RealDataService.getVehicleData(simNo);
//        }
//        /// <summary>
//        /// 根据终端编号获取终端数据
//        /// </summary>
//        /// <param name="termNo"></param>
//        /// <returns></returns>
//        public Domain.Terminal getTerminalByTermNo(string termNo)
//        {
//            return RealDataService.getTerminalByTermNo(termNo);
//        }
//        /// <summary>
//        /// 根据车牌号获取车辆数据
//        /// </summary>
//        /// <param name="plateNo"></param>
//        /// <returns></returns>
//        public Domain.VehicleData getVehicleByPlateNo(string plateNo)
//        {
//            return RealDataService.getVehicleByPlateNo(plateNo);
//        }
//        /// <summary>
//        /// 更新车辆数据
//        /// </summary>
//        /// <param name="simNo"></param>
//        /// <param name="v"></param>
//        public void updateVehicleData(string simNo, Domain.VehicleData v)
//        {
//             RealDataService.updateVehicleData(simNo, v);
//        }
//    }
//}
