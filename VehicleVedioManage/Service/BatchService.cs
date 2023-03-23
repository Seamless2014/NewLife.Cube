//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Diagnostics;
//using System.Data;
//using System.Data.SqlClient;
//using GpsNET.Domain;
//using System.Configuration;
//using System.Threading;
//using System.Collections.Concurrent;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 批量服务
//    /// </summary>
//    public class BatchService : IBatchService
//    {
//        /// <summary>
//        /// 链接字符串
//        /// </summary>
//        public String connectionString { get; set; }

//        private  log4net.ILog logger = log4net.LogManager.GetLogger(typeof(BatchService));
//        /// <summary>
//        /// sql连接
//        /// </summary>
//        private  SqlConnection destinationConnection;
//        /// <summary>
//        /// sql 批量copy
//        /// </summary>
//        private  SqlBulkCopy sqlBulkCopy ;
//        /// <summary>
//        /// 808处理线程
//        /// </summary>
//        private  Thread processT808MsgThread;
//        /// <summary>
//        /// gpsinfo队列
//        /// </summary>
//        public  ConcurrentQueue<GpsInfo> gpsInfoQueue = new ConcurrentQueue<GpsInfo>();
//        /// <summary>
//        /// 是否继续
//        /// </summary>
//        private  Boolean isContinue = true;
//        /// <summary>
//        /// 当前队列数量
//        /// </summary>
//        public int QueueNum { get; set; }
//        /// <summary>
//        /// 批量插入间隔
//        /// </summary>
//        public int batchInsertInterval { get; set; }
//        /// <summary>
//        /// 批量插入数量
//        /// </summary>
//        public int batchInsertNum { get; set; }

//        public BatchService()
//        {
//            batchInsertNum = 2000;
//            batchInsertInterval = 30000;
//        }
//        /// <summary>
//        /// 入队
//        /// </summary>
//        /// <param name="g"></param>
//        public  void EnQueue(GpsInfo g)
//        {
//            gpsInfoQueue.Enqueue(g);
//        }
//        /// <summary>
//        /// 获取队列数
//        /// </summary>
//        /// <returns></returns>
//        public int GetQueueNum()
//        {
//            return QueueNum;
//        }
//        /// <summary>
//        /// 处理消息线程
//        /// </summary>
//        private  void ProcessMsgThreadFunc()
//        {
//            while (isContinue)
//            {
//                try
//                {
//                    int m = 0;
//                    List<GpsInfo> result = new List<GpsInfo>();
//                    Boolean res = true;
//                    while (res && m < batchInsertNum)
//                    {
//                        GpsInfo rd = null;
//                        res = gpsInfoQueue.TryDequeue(out rd);
//                        if (rd != null)
//                            result.Add(rd);
//                        else
//                            break;
//                        m++;
//                    }

//                    if (result.Count > 0)
//                    {
//                        DateTime start = DateTime.Now;
//                        insert(result);
//                        if (result.Count > 500)
//                        {
//                            DateTime end = DateTime.Now;
//                            TimeSpan ts = end - start;
//                            if (ts.TotalSeconds > 0.8)
//                            {
//                                logger.Info("队列数:" + QueueNum + "插入历史数据,条数:" + result.Count + ",耗时:" + ts.TotalSeconds);
//                            }
//                        }
//                    }
//                    this.QueueNum = gpsInfoQueue.Count;
//                }
//                catch (Exception ex)
//                {
//                    logger.Error(ex.Message, ex);
//                }
//                Thread.Sleep(batchInsertInterval);
//            }

            
//        }
//        /// <summary>
//        /// 停止服务
//        /// </summary>
//        public  void Stop()
//        {
//            try
//            {
//                if(sqlBulkCopy!=null)
//                   sqlBulkCopy.Close();
//                destinationConnection.Close();
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//            }

//            isContinue = false;
//            if(processT808MsgThread!=null)
//            processT808MsgThread.Join();
//        }
//        /// <summary>
//        /// 开始服务
//        /// </summary>
//        public  void Start()
//        {
//            try
//            {
//                //connectionString = ConfigurationManager.ConnectionStrings["hisDBConnection"].ToString();
//                destinationConnection = new SqlConnection(connectionString);
//                destinationConnection.Open();

//                sqlBulkCopy = new SqlBulkCopy(destinationConnection);
//                //sqlBulkCopy = new SqlBulkCopy(destinationConnection);
//                sqlBulkCopy.ColumnMappings.Add("VehicleId", "vehicleId");
//                sqlBulkCopy.ColumnMappings.Add("SimNo", "simNo");
//                sqlBulkCopy.ColumnMappings.Add("Valid", "valid");
//                sqlBulkCopy.ColumnMappings.Add("PlateNo", "plateNo");
//                sqlBulkCopy.ColumnMappings.Add("Signal", "signal");
//                sqlBulkCopy.ColumnMappings.Add("SendTime", "sendTime");
//                sqlBulkCopy.ColumnMappings.Add("Longitude", "longitude");
//                sqlBulkCopy.ColumnMappings.Add("Latitude", "latitude");
//                sqlBulkCopy.ColumnMappings.Add("Altitude", "altitude");
//                sqlBulkCopy.ColumnMappings.Add("Velocity", "velocity");
//                sqlBulkCopy.ColumnMappings.Add("Direction", "direction");
//                sqlBulkCopy.ColumnMappings.Add("Status", "status");
//                sqlBulkCopy.ColumnMappings.Add("AlarmState", "alarmState");
//                sqlBulkCopy.ColumnMappings.Add("Mileage", "mileage");
//                sqlBulkCopy.ColumnMappings.Add("Gas", "gas");
//                sqlBulkCopy.ColumnMappings.Add("RecordVelocity", "recordVelocity");
//                sqlBulkCopy.ColumnMappings.Add("Location", "location");
//                sqlBulkCopy.ColumnMappings.Add("CreateDate", "createDate");
//                //sqlBulkCopy.ColumnMappings.Add("FuelData", "fuelData");


//                processT808MsgThread = new Thread(new ThreadStart(ProcessMsgThreadFunc));
//                processT808MsgThread.Start();
//                logger.Error("批量插入服务启动成功");
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//            }
//            finally
//            {
//            }


//        }

//        /// <summary>
//        /// 批量插入
//        /// </summary>
//        /// <param name="tableName"></param>
//        /// <param name="dataTable"></param>
//        private  void SqlBulkCopyInsert(String tableName, DataTable dataTable)
//        {
//            sqlBulkCopy.DestinationTableName = tableName;
//            sqlBulkCopy.BatchSize = dataTable.Rows.Count;
//            if (dataTable != null && dataTable.Rows.Count != 0)
//            {
//                sqlBulkCopy.WriteToServer(dataTable);
//            }
//            // stopwatch.ElapsedMilliseconds;


//        }
//       /// <summary>
//       /// 插入数据
//       /// </summary>
//       /// <param name="gpsList"></param>
//        public  void insert(List<GpsInfo> gpsList)
//        {
//            DataTable dt = new DataTable();
//            dt.Columns.Add("VehicleId");
//            dt.Columns.Add("SimNo");
//            dt.Columns.Add("Valid");
//            dt.Columns.Add("PlateNo");
//            dt.Columns.Add("Signal");
//            dt.Columns.Add("SendTime");
//            dt.Columns.Add("Longitude");
//            dt.Columns.Add("Latitude");
//            dt.Columns.Add("Altitude");
//            dt.Columns.Add("Velocity");
//            dt.Columns.Add("Direction");
//            dt.Columns.Add("Status");
//            dt.Columns.Add("AlarmState");
//            dt.Columns.Add("Mileage");
//            dt.Columns.Add("Gas");
//            dt.Columns.Add("RecordVelocity");
//            dt.Columns.Add("Location");
//            dt.Columns.Add("CreateDate");
//            //dt.Columns.Add("FuelData");
//            //dt.Columns.Add("FuelLevelData");
//            foreach(GpsInfo g in gpsList)
//            {
//                dt.Rows.Add(g.VehicleId, g.SimNo, g.Valid,g.PlateNo,g.Signal,g.SendTime,
//                g.Longitude,g.Latitude,g.Altitude,g.Velocity,g.Direction,g.Status,
//                g.AlarmState,g.Mileage,g.Gas,g.RecordVelocity,g.Location,g.CreateDate);
//            }
//            String tableName = "gpsInfo" + DateTime.Now.ToString("yyyyMMdd");
//            try
//            {
//                SqlBulkCopyInsert(tableName, dt);
//            }
//            catch (Exception ex)
//            {
//                logger.Error("批量插入异常失败，条数:" + gpsList.Count);
//                logger.Error(ex.Message, ex);
//            }
//        }
//    }
//}
