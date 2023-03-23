//using System.Collections.Generic;
//using System.Collections;
//using System;
//using System.Data;
//using log4net;
//using GpsNET.Domain;
//using GpsNET.Dao;
//using IBatisNet.DataMapper;
//using System.ServiceModel;
//using System.IO;
//using GpsNET.MapService;
//using GpsNET.ViewModel;
//using Spring.Context.Support;
//using Spring.Context;
//using System.Text;
//using GpsNET.Util;
//using System.Runtime.Serialization;
//using XCode.Membership;
//using VehicleVedioManage.FenceManagement.Entity;
//using VehicleVedioManage.Web.Models;
//using NewLife.Log;
//using VehicleVedioManage.BackManagement.Entity;
//using VehicleVedioManage.BasicData.Entity;
//using VehicleVedioManage.ReportStatistics.Entity;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// GPS Web服务
//    /// </summary>
//    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerSession)]

//    public class GpsWebService : IGpsWebService
//    {
//        /// <summary>
//        /// 心跳测试
//        /// </summary>
//        #region IGpsWebService 成员变量
//        private static List<Department> AllDep = new List<Department>();
//        private static Hashtable AllDepMap = new Hashtable();

//        public IQueryService QueryService { get; set; }
//        public IBaseDao BaseDao { get; set; }

//        public Boolean NeedMapFix {get;set;}

//        public IRealDataService RealDataService { get; set; }

//        protected static ILog logger = log4net.LogManager.GetLogger(typeof(GpsWebService));
//        //设置的照片目录
//        public string VehiclePhotoDir { get; set; }

//        public IDepartmentService DepartmentService { get; set; }

//        private Dictionary<int, VehicleTreeNode> treeNodeMap = new Dictionary<int, VehicleTreeNode>();

//        private UserInfo onlineUser = null;

//        #endregion
//        public void HeartBeatTest(int userId)
//        {

//            if (onlineUser == null)
//            {
//                onlineUser = GetUser(userId);
//            }
//        }
//        /// <summary>
//        /// 在线用户
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <returns></returns>
//        public  UserInfo GetUser(int userId)
//        {
//            try
//            {
//                UserInfo user = (UserInfo)BaseDao.load(typeof(UserInfo), userId);
//                return user;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }
//        /// <summary>
//        /// 获取角色
//        /// </summary>
//        /// <param name="roleId"></param>
//        /// <returns></returns>
//        public Role GetRole(int roleId)
//        {
//            try
//            {
//                Role r = (Role)BaseDao.load(typeof(Role), roleId);
//                return r;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }

//        /// <summary>
//        /// 设置用户密码
//        /// </summary>
//        /// <param name="UserId"></param>
//        /// <param name="Password"></param>
//        public void UpdateUserPassword(int UserId, string Password)
//        {
//            if (this.onlineUser == null || this.onlineUser.EntityId != UserId || UserId == 0)
//            {
//                throw new FaultException("你没有权限修改用户的密码");
//            }
//            UserInfo u = (UserInfo)BaseDao.load(typeof(UserInfo), UserId);
//            if (u != null)
//            {
//                string strPass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1");
//                u.Password = strPass;
//                BaseDao.saveOrUpdate(u);
//            }
//            else
//                throw new FaultException("没有此用户");

//        }

//        /// <summary>
//        /// 用户设置自己所用的地图的地图中心
//        /// </summary>
//        /// <param name="lng"></param>
//        /// <param name="lat"></param>
//        /// <param name="zoom"></param>
//        public void SetMapCenter(double lng, double lat, int zoom)
//        {
//            try
//            {
//                UserInfo user = this.onlineUser;
//                if (user != null)
//                {
//                    user = (UserInfo)this.BaseDao.load(typeof(UserInfo),
//                            user.EntityId);
//                    user.MapCenterLng = (lng);
//                    user.MapCenterLat = (lat);
//                    user.MapLevel = (zoom);
//                    this.BaseDao.saveOrUpdate(user);// 保存到用户信息中
//                    this.onlineUser = (user);
//                }
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }

//        }
//        /// <summary>
//        /// 用户登录
//        /// </summary>
//        /// <param name="UserName"></param>
//        /// <param name="Password"></param>
//        /// <returns></returns>
//        public ClientUser Login(String UserName, String Password)
//        {
//            try
//            {
//                //Console.WriteLine("Instance Object : {0}", OperationContext.Current.InstanceContext.GetHashCode());
//                //Console.WriteLine("Service Object : {0}", OperationContext.Current.InstanceContext.GetServiceInstance().GetHashCode());
//                // Console.WriteLine("Session Id  : {0}", OperationContext.Current.SessionId);
//                //Console.WriteLine();

//                string hsql = "from UserInfo where LoginName = ? and Deleted = ? ";

//                UserInfo u = (UserInfo)BaseDao.find(hsql, new Object[] { UserName, false });

                
//                if (u == null)
//                    return null;
//                string strPass = u.Password;// 
                
//                String encrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(u.Password, "SHA1");

//                if (strPass != Password && encrypt != Password)
//                    return null;

//                this.onlineUser = u;

//                ClientUser onlineUser = new ClientUser();
//                onlineUser.LoginName = u.LoginName;
//                onlineUser.Password = u.Password;
//                onlineUser.TenantId = u.TenantId;
//                onlineUser.Name = u.Name;
//                onlineUser.UserType = u.UserType;
//                onlineUser.UserId = u.EntityId;
//                onlineUser.DepId = u.RegionId;
//                SystemConfig sc = (SystemConfig)this.BaseDao.load(
//                       typeof(SystemConfig), 1);
//                if (u.MapCenterLat == 0 || u.MapCenterLng == 0)
//                {
//                    onlineUser.MapCenterLat = (sc.InitLat);
//                    onlineUser.MapCenterLng = (sc.InitLng);
//                    onlineUser.MapLevel = (sc.InitZoomLevel);
//                }
//                else
//                {
//                    onlineUser.MapCenterLat = u.MapCenterLat;
//                    onlineUser.MapCenterLng = u.MapCenterLng;
//                    onlineUser.MapLevel = u.MapLevel;
//                }

//                if (u.IsAdmin())
//                {
//                    //如果是超级用户，就加载所有的权限;
//                    IList il = BaseDao.loadAll(typeof(FuncModel));
//                    foreach (FuncModel f in il)
//                        onlineUser.Permissions.Add(f);
//                }
//                else
//                    onlineUser.Permissions = u.GetPermissions();

//                return onlineUser;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }

//        public List<AlarmConfig> GetAlarmConfig()
//        {
//            try
//            {
//                String hql = "from AlarmConfig order by alarmSource,alarmType";
//                IList ls = BaseDao.query(hql, null);
//                List<AlarmConfig> result = new List<AlarmConfig>();
//                foreach (AlarmConfig bd in ls)
//                {
//                    result.Add(bd);
//                }
//                return result;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }

//        public ReportModel GetReportModelByName(String Name)
//        {
//            try
//            {
//                String hql = "from ReportModel where Name = ? and Deleted = ?";
//                ReportModel rm = (ReportModel)BaseDao.find(hql, new Object[]{Name, false});
//                return rm;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
            
//        }

//        public List<ReportModel> GetReportModelList()
//        {
//             try
//             {
//                IList ls = BaseDao.loadAll(typeof(ReportModel));
//                List<ReportModel> result = new List<ReportModel>();
//                foreach (ReportModel bd in ls)
//                {
//                    if (bd.Deleted == false)
//                        result.Add(bd);
//                }
//                return result;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }

//        }

//        public List<BasicData> GetBasicData()
//        {
//            try
//            {
//                IList ls = BaseDao.loadAll(typeof(BasicData));
//                List<BasicData> result = new List<BasicData>();
//                foreach (BasicData bd in ls)
//                {
//                    if (bd.Deleted == false)
//                        result.Add(bd);
//                }
//                return result;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }
//        //得到线段
//        public List<LineSegment> GetLineSegments(int RouteId)
//        {
//            try
//            {
//                string hsql = "from LineSegment where RouteId = ? order by PointId";
//                IList nodes = (ArrayList)BaseDao.query(hsql, new object[] { RouteId });

//                List<LineSegment> result = new List<LineSegment>();
//                foreach (LineSegment bd in nodes)
//                {
//                    result.Add(bd);
//                }
//                return result;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                logger.Error(ex.StackTrace);
//                throw new FaultException(ex.Message);
//            }
//        }



//        //统计上线率
//        public List<OnlineStatic> GetOnlineStat(DateTime start, DateTime end, int TenantId, int DepId)
//        {
//            string hsql = "from OnlineStatic where StatisticDate >= ? and StatisticDate <= ? and DepId = ? ";

//            IList results = BaseDao.query(hsql, new object[] { start, end, DepId });

//            List<OnlineStatic> ls = new List<OnlineStatic>();
//            foreach (OnlineStatic vx in results)
//            {
//                ls.Add(vx);
//            }
//            return ls;
//        }





//        //查询历史轨迹
//        public List<GpsInfo> GetGpsInfoList(QueryParam param)
//        {
//            if (param.Limit < 10)
//                param.Limit = 10;

//            List<GpsInfo> vds = new List<GpsInfo>();
//            try
//            {
//                Hashtable ht = new Hashtable();
//                //设置查询参数
//                foreach (string key in param.Param.Keys)
//                {
//                    ht[key] = param.Param[key];
//                }
//                UserInfo user = this.onlineUser;
//                if (user == null)
//                {
//                    throw new FaultException("用户没有登录，无法查询!");
//                }
//                DateTime start = (DateTime)ht["startTime"];
//                DateTime end = (DateTime)ht["endTime"];
//                String strStart = start.ToString("yyyyMMdd");
//                end = end.CompareTo(DateTime.Now) > 0 ? DateTime.Now : end;
//                String strEnd = end.ToString("yyyyMMdd");
//                String tableName1 = "gpsInfo" + strStart;
//                ht["tableName1"] = tableName1;
//                String tableName2 = "gpsInfo" + strEnd;
//                ht["tableName2"] = tableName2;
//                string queryId = "selectHisotryGpsInfos";
//                if (tableName1.Equals(tableName2) == false)
//                {
//                    queryId = "selectGpsInfosIn2Days";
//                }

//                int skipRows = (param.StartPageNo - 1) * param.Limit;
//                IList ls = QueryService.QueryForList(queryId, ht);

//                foreach (Hashtable item in ls)
//                {
//                    GpsInfo vd = new GpsInfo();
//                    //vd.VehicleId = (int)item["VehicleId"];
//                    vd.PlateNo = "" + item["plateNo"];
//                    vd.Direction = (int)item["direction"];
//                    vd.Status = (int)item["status"];
//                    vd.AlarmState = (int)item["alarmState"];
//                    vd.Signal = (int)(item["signal"] == null ? 0 : item["signal"]);
//                    vd.Valid = (Boolean)item["valid"];
//                    vd.Location = "" + item["location"];
//                    vd.Latitude = Double.Parse("" + item["latitude"]);
//                    vd.Longitude = Double.Parse("" + item["longitude"]);
//                    vd.Altitude = Double.Parse("" + item["altitude"]);
//                    vd.Velocity = Double.Parse("" + item["velocity"]);
//                    vd.Mileage = Double.Parse("" + item["mileage"]);
//                    vd.Gas = Double.Parse("" + item["gas"]);
//                    vd.SendTime = (DateTime)item["sendTime"];

//                    vds.Add(vd);
//                }
//                return vds;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }

//        //分页查询车辆列表
//        public PageData<GpsInfo> GetGpsInfoByPage(QueryParam param)
//        {
//            if (param.Limit < 10)
//                param.Limit = 10;

//            PageData<GpsInfo> pd = new PageData<GpsInfo>();
//            try
//            {
//                List<GpsInfo> vds = new List<GpsInfo>();
//                pd.Data = vds;
//                Hashtable ht = new Hashtable();
//                //设置查询参数
//                foreach (string key in param.Param.Keys)
//                {
//                    ht[key] = param.Param[key];
//                }
//                UserInfo user = this.onlineUser;
//                if (user == null)
//                {
//                    throw new FaultException("用户没有登录，无法查询!");
//                }
//                DateTime start = (DateTime)ht["startTime"];
//                DateTime end = (DateTime)ht["endTime"];
//                String strStart = start.ToString("yyyyMMdd");
//                end = end.CompareTo(DateTime.Now) > 0 ? DateTime.Now : end;
//                String strEnd = end.ToString("yyyyMMdd");
//                String tableName1 = "gpsInfo" + strStart;
//                ht["tableName1"] = tableName1;
//                String tableName2 = "gpsInfo" + strEnd;
//                ht["tableName2"] = tableName2;
//                string queryId = "selectHisotryGpsInfos";
//                if (tableName1.Equals(tableName2) == false)
//                {
//                    queryId = "selectGpsInfosIn2Days";
//                }

//                int skipRows = (param.StartPageNo - 1) * param.Limit;
//                Pagination ls = QueryService.QueryForList(queryId, ht, skipRows, param.Limit);

//                foreach (Hashtable item in ls.results)
//                {
//                    GpsInfo vd = new GpsInfo();
//                    //vd.VehicleId = (int)item["VehicleId"];
//                    vd.PlateNo = "" + item["plateNo"];
//                    vd.Direction = (int)item["direction"];
//                    vd.Status = (int)item["status"];
//                    vd.AlarmState = (int)item["alarmState"];
//                    vd.Signal = (int)(item["signal"] == null ? 0 : item["signal"]);
//                    vd.Valid = (Boolean)item["valid"];
//                    vd.Location = "" + item["location"];
//                    vd.Latitude = Double.Parse(""+item["latitude"]);
//                    vd.Longitude = Double.Parse(""+item["longitude"]);
//                    vd.Altitude = Double.Parse(""+item["altitude"]);
//                    vd.Velocity = Double.Parse(""+item["velocity"]);
//                    vd.Mileage = Double.Parse(""+item["mileage"]);
//                    vd.Gas = Double.Parse(""+item["gas"]);
//                    vd.SendTime = (DateTime)item["sendTime"];

//                    vds.Add(vd);
//                }
//                pd.TotalRecord = ls.totalCount;
//                pd.PageNo = param.StartPageNo;
//                pd.Limit = param.Limit;
//                int startRows = (param.StartPageNo - 1) * param.Limit;
//                pd.Start = startRows;
//                //pd.TotalPage = 1 + pd.TotolRecord / pd.Limit;
//                return pd;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                logger.Error(ex.StackTrace);
//                throw new FaultException(ex.Message);
//            }

//        }

     

//        /// <summary>
//        /// 得到最新的报警记录
//        /// </summary>
//        /// <param name="StartDate">开始时间</param>
//        /// <returns></returns>
//        public List<Alarm> GetNewAlarm(int userId, Boolean isAdmin, DateTime StartDate)
//        {
//            List<Alarm> result = new List<Alarm>();
//            try
//            {
//                String queryId = "selectNewAlarms";
//                Hashtable ht = new Hashtable();
//                String tableName = "NewAlarm" + DateTime.Now.ToString("yyyyMM");
//                ht["startTime"] = StartDate;
//                ht["tableName"] = tableName;

//                if(isAdmin == false)
//                ht["userId"] = userId;
//                IList ls = QueryService.QueryForList(queryId, ht);

//                foreach (Hashtable rowData in ls)
//                {
//                    Alarm a = new Alarm();
//                    a.EntityId = (int)rowData["id"];
//                    a.AlarmSource = "" + rowData["alarmSource"];
//                    a.PlateNo = "" + rowData["plateNo"];
//                    a.AlarmType = "" + rowData["alarmType"];
//                    a.Location = "" + rowData["location"];
//                    a.AlarmTime = (DateTime)rowData["alarmTime"];
//                    a.Latitude = (Double)rowData["latitude"];
//                    a.Longitude = (Double)rowData["longitude"];
//                    a.Descr = ""+rowData["descr"];
//                    a.Speed = Double.Parse(""+rowData["speed"]);
//                    result.Add(a);
//                }
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//            }

//            return result;
//        }
//        //分页查询报警时长统计记录
//        private PageData<AlarmRecord> GetAlarmRecord(string queryId, Hashtable parameters, int skipRows, int rowNum)
//        {
//             Pagination  il = QueryService.QueryForList(queryId, parameters, skipRows, rowNum);

//            List<AlarmRecord> vds = new List<AlarmRecord>();
//            PageData<AlarmRecord> pd = new PageData<AlarmRecord>();
//            pd.Data = vds;
//            foreach (Hashtable ht in il.results)
//            {
//                AlarmRecord se = new AlarmRecord();
//                se.EntityId = (int)ht["alarmId"];
//                object obj = ht["timeSpan"];
//                if (obj != null)
//                    se.TimeSpan = Double.Parse(""+obj);

//                se.StartTime = (DateTime)ht["startTime"];
//                if(ht["endTime"]!= null)
//                se.EndTime = (DateTime)ht["endTime"];
//                se.Location = "" + ht["location"];
//                obj = ht["latitude"];
//                if (obj != null)
//                    se.Latitude = Double.Parse(""+obj);

//                obj = ht["longitude"];
//                if (obj != null)
//                    se.Longitude = Double.Parse(""+obj);

//                se.PlateNo = "" + ht["plateNo"];
//                if (ht["station"] != null)
//                se.Station = int.Parse("" + ht["station"]);
//                se.Status = "" + ht["status"];
//                se.AlarmSource = "" + ht["alarmSource"];
//                se.Flag = "" + ht["flag"];
//                se.AlarmType = "" + ht["alarmType"];

//                //此处需要纠偏
//                if (NeedMapFix)
//                {
//                    //double lng1 = 0, lat1 = 0;
//                    //MapFix.Fix(se.Longitude, se.Latitude, out lng1, out lat1);
//                    //se.Latitude = lat1;
//                    //se.Longitude = lng1;
//                }

//                obj = ht["velocity"];
//                if (obj != null)
//                   se.Velocity = Double.Parse(""+ht["velocity"]);

//                vds.Add(se);
//            } 

//            pd.TotalRecord = il.totalCount;
//            return pd;
//        }

//        public PageData<OnlineRecord> GetOnlineRecord(QueryParam qp)
//        {
//            try
//            {
//                String queryId = "selectOnlineRecord";

//                Hashtable param = new Hashtable();
//                param["userId"] = this.onlineUser.EntityId;
//                //设置查询参数
//                foreach (string key in qp.Param.Keys)
//                {
//                    param[key] = qp.Param[key];
//                }
//                int depId = 0;
//                if (param.ContainsKey("depId"))
//                    depId = int.Parse("" + param["depId"]);
//                if (depId > 0)
//                {
//                    List<int> depIdList = this.DepartmentService
//                            .getDepIdList(depId);
//                    param["depIdList"] = depIdList;
//                }
//                int skipRows = (qp.StartPageNo - 1) * qp.Limit;
//                int rowNum = qp.Limit;

//                Pagination il = QueryService.QueryForList(queryId, param, skipRows, rowNum);
//                List<OnlineRecord> vds = new List<OnlineRecord>();
//                PageData<OnlineRecord> pd = new PageData<OnlineRecord>();
//                pd.Data = vds;
//                foreach (Hashtable ht in il.results)
//                {
//                    OnlineRecord se = new OnlineRecord();
//                    se.EntityId = (int)ht["alarmId"];
//                    object obj = ht["timeSpan"];
//                    if (obj != null)
//                        se.TimeSpan = Double.Parse("" + obj);

//                    se.StartTime = (DateTime)ht["startTime"];
//                    se.EndTime = (DateTime)ht["endTime"];
//                    se.Location = "" + ht["location"];
//                    obj = ht["latitude"];
//                    if (obj != null)
//                        se.Latitude = Double.Parse("" + obj);

//                    obj = ht["longitude"];
//                    if (obj != null)
//                        se.Longitude = Double.Parse("" + obj);

//                    se.PlateNo = "" + ht["plateNo"];
//                    se.Status = "" + ht["status"];
//                    se.AlarmSource = "" + ht["alarmSource"];
//                    se.AlarmType = "" + ht["alarmType"];


//                    obj = ht["velocity"];
//                    if (obj != null)
//                        se.Velocity = Double.Parse("" + ht["velocity"]);

//                    vds.Add(se);
//                }

//                pd.TotalRecord = il.totalCount;
//                return pd;
//            }
//            catch (Exception ex)
//            {
//                throw new FaultException(ex.Message);
//            }
//        }


//        //分页查询报警时长统计记录
//        private PageData<AlarmRecord> GetProcessedAlarms(QueryParam qp)
//        {
//            String queryId = "selectProcessedAlarms";
//            Hashtable param = new Hashtable();
//            //设置查询参数
//            foreach (string key in qp.Param.Keys)
//            {
//                param[key] = qp.Param[key];
//            }

//            String startTime = "" + param["startTime"];
//            String endTime = "" + param["endTime"];
//            if (param["startTime"] == null)
//            {
//                startTime = DateTime.Now.ToString("yyyyMM");
//                endTime = DateTime.Now.ToString("yyyyMM");
//            }
//            else
//            {
//                startTime = startTime.Substring(0, 7).Replace("-", "");
//                endTime = endTime.Substring(0, 7).Replace("-", "");
//            }
//            String today = DateTime.Now.ToString("yyyyMM");
//            if (endTime.CompareTo(today) > 0)
//                endTime = today;
//            String tableName1 = "NewAlarm" + startTime;
//            param["tableName1"] = tableName1;
//            String tableName2 = "NewAlarm" + endTime;
//            param["tableName2"] = tableName2;

//            if (tableName1.Equals(tableName2) == false)
//            {
//                queryId = "selectProcessedAlarmsIn2Months";
//            }

//            int skipRows = (qp.StartPageNo - 1) * qp.Limit;

//            int rowNum = qp.Limit;

//            Pagination il = QueryService.QueryForList(queryId, param, skipRows, rowNum);


//            List<AlarmRecord> vds = new List<AlarmRecord>();
//            PageData<AlarmRecord> pd = new PageData<AlarmRecord>();
//            pd.Data = vds;
//            foreach (Hashtable ht in il.results)
//            {
//                AlarmRecord se = new AlarmRecord();
//                se.EntityId = (int)ht["alarmId"];
//                object obj = ht["timeSpan"];
//                if (obj != null)
//                    se.TimeSpan = Double.Parse("" + obj);

//                se.StartTime = (DateTime)ht["startTime"];
//                se.EndTime = (DateTime)ht["endTime"];
//                se.Location = "" + ht["location"];
//                obj = ht["latitude"];
//                if (obj != null)
//                    se.Latitude = Double.Parse("" + obj);

//                obj = ht["longitude"];
//                if (obj != null)
//                    se.Longitude = Double.Parse("" + obj);

//                se.PlateNo = "" + ht["plateNo"];
//                se.Station = int.Parse("" + ht["station"]);
//                se.Status = "" + ht["status"];
//                se.AlarmSource = "" + ht["AlarmSource"];
//                se.Flag = "" + ht["flag"];
//                se.AlarmType = "" + ht["alarmType"];

//                //此处需要纠偏
//                if (NeedMapFix)
//                {
//                    //double lng1 = 0, lat1 = 0;
//                    //MapFix.Fix(se.Longitude, se.Latitude, out lng1, out lat1);
//                    //se.Latitude = lat1;
//                    //se.Longitude = lng1;
//                }

//                obj = ht["velocity"];
//                if (obj != null)
//                    se.Velocity = Double.Parse("" + ht["velocity"]);

//                vds.Add(se);
//            }

//            pd.TotalRecord = il.totalCount;
//            return pd;
//        }


//        public void ProcessAlarmRecords(List<int> alarmIds, int processedState, string processedWay, DateTime
//            alarmTime)
//        {
//            foreach (int alarmId in alarmIds)
//            {
//                this.ProcessAlarmRecord(alarmId,processedState, processedWay, alarmTime);
//            }

//        }

//        public void ProcessAlarmRecord(int alarmId, int processedState, string processedWay,DateTime
//            alarmTime)
//        {
//            try
//            {
//                Hashtable ht = new Hashtable();
//                ht["alarmId"] = alarmId;
//                String tableName = "NewAlarm" + alarmTime.ToString("yyyyMMdd");
//                ht["tableName"] = tableName;
//                Alarm sr = (Alarm)this.QueryService.QueryObject("getAlarmById", ht);
//                //sr.Flag = reason;
//                //sr.Driver = userName;
//                sr.ProcessedTime = DateTime.Now;
//                sr.Processed = processedState;
//                sr.ProcessedUserId = this.onlineUser.EntityId;
//                sr.ProcessedUserName = this.onlineUser.Name;
//                if (String.IsNullOrEmpty(processedWay))
//                {
//                    processedWay = "未处理";
//                    if (processedState == 1)
//                        processedWay = "已处理";
//                    else if (processedState == 2)
//                        processedWay = "处理中";
//                }
//                sr.Remark = processedWay;
//                sr.Owner = this.onlineUser.Name;
//                //sr.Processed = 1;
//                sr.tableName = tableName;

//                this.QueryService.update("updateAlarmProcessedState", sr);

//                Vehicle vd = this.GetVehicleById(sr.VehicleId);
//                BaseDao.saveOrUpdate(sr);
//                try
//                {
//                    TerminalCommand tc = new TerminalCommand();
//                    tc.CmdType = (JT808Constants.CMD_CLEAR_ALARM);
//                    int msgId = 0x0200;
//                    int ackResult = 4;// 报警处理确认
//                    tc.CmdData = ("" + sr.AckSn + ";" + msgId + ";" + 4);
//                    tc.VehicleId = sr.VehicleId;
//                    tc.PlateNo = vd.PlateNo;
//                    tc.SimNo = vd.SimNo;
//                    tc.UserId = this.onlineUser.EntityId;
//                    tc.Owner = this.onlineUser.Name;
//                    BaseDao.saveOrUpdate(tc);
//                }
//                catch (Exception ex)
//                {
//                    logger.Error(ex.Message, ex);
//                }

//                JT809Command jc = new JT809Command();
//                try
//                {
//                    int subCmd = 0x1403;
//                    jc.Cmd = (0x1400);
//                    jc.SubCmd = (subCmd);
//                    int result = 1;
//                    jc.CmdData = (sr.EntityId + ";" + result);
//                    jc.PlateNo = vd.PlateNo;
//                    jc.PlateColor = (byte)vd.PlateColor;

//                    jc.UserId = this.onlineUser.EntityId;
//                    jc.Owner = this.onlineUser.Name;
//                    BaseDao.saveOrUpdate(jc);
//                }
//                catch (Exception ex)
//                {
//                    logger.Error(ex.Message, ex);
//                }


//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                //throw new FaultException(ex.Message);
//            }
//        }

//        //查询报警记录
//        public PageData<AlarmRecord> GetAlarmList(QueryParam qp)
//        {
//            try
//            {
//                PageData<AlarmRecord> pd = new PageData<AlarmRecord>();
//                pd.Data = new List<AlarmRecord>();
//                Hashtable parameters = new Hashtable();
               
//                parameters["userId"] = this.onlineUser.EntityId;
//                //设置查询参数
//                foreach (string key in qp.Param.Keys)
//                {
//                    parameters[key] = qp.Param[key];
//                }
//                int depId = 0;
//                if (parameters.ContainsKey("depId"))
//                    depId = int.Parse("" + parameters["depId"]);
//                if (depId > 0)
//                {
//                    List<int> depIdList = this.DepartmentService
//                            .getDepIdList(depId);
//                    parameters["depIdList"] = depIdList;
//                }

//                //报警子类型的查询条件
//                if (qp.Param.ContainsKey("WarnFilter"))
//                {
//                    string filter = "" + qp.Param["WarnFilter"];
//                    if (string.IsNullOrEmpty(filter) == false)
//                    {
//                        string[] warnFilter = filter.Split(',');
//                        List<string> warnFilters = new List<string>();
//                        foreach (string wf in warnFilter)
//                        {
//                            if (string.IsNullOrEmpty(wf.Trim()) == false)
//                                warnFilters.Add(wf);
//                        }
//                        parameters["WarnFilter"] = warnFilters;
//                    }
//                    else
//                        parameters.Remove("WarnFilter");
//                }

//                int skipRows = (qp.StartPageNo - 1) * qp.Limit;
//                pd = GetAlarmRecord("selectAlarms", parameters, skipRows, qp.Limit);

//                int startRows = (qp.StartPageNo - 1) * qp.Limit;
//                pd.Start = startRows;
//                pd.Limit = qp.Limit;
//                //pd.TotalPage = 1 + pd.TotolRecord / pd.Limit;
//                pd.PageNo = qp.StartPageNo;
//                return pd;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }
//        //查询报警记录
//        public PageData<AlarmRecord> GetGatherInfo(QueryParam qp)
//        {
//            try
//            {
//                PageData<AlarmRecord> pd = new PageData<AlarmRecord>();
//                pd.Data = new List<AlarmRecord>();
//                Hashtable parameters = new Hashtable();
//                if (qp.UserId > 0)
//                {
//                    //parameters["UserId"] = qp.UserId;
//                    //车辆权限
//                    //User user = (UserInfo)BaseDao.load(typeof(UserInfo), qp.UserId);
//                    //List<int> depList = getDepIdList();
//                    //if (depList.Count == 0)
//                      //  return pd;
//                   // parameters["depList"] = depList;
//                }
//                //设置查询参数
//                foreach (string key in qp.Param.Keys)
//                {
//                    parameters[key] = qp.Param[key];
//                }

//                int skipRows = (qp.StartPageNo - 1) * qp.Limit;
//                pd = GetAlarmRecord("selectAlarms", parameters, skipRows, qp.Limit);

//                int startRows = (qp.StartPageNo - 1) * qp.Limit;
//                pd.Start = startRows;
//                pd.Limit = qp.Limit;
//                //pd.TotalPage = 1 + pd.TotolRecord / pd.Limit;
//                pd.PageNo = qp.StartPageNo;
//                return pd;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }      


//        //得到停车记录
//        public List<AlarmRecord> GetAlarmRecords(int UserId, string PlateNo, DateTime start, DateTime end, int minutes, string station){
//            string hsql = "from StopRecord  s where s.StartTime >= ? and s.StartTime <= ?  and s.PlateNo = ?   and s.Type = ? and s.Interval >= ? ";
//            start = start.AddMinutes(-1);
//            end = end.AddMinutes(1);
//            IList ls = BaseDao.query(hsql, new object[] { start, end, PlateNo, "Stop", minutes });
//            List<AlarmRecord> results = new List<AlarmRecord>();
//            foreach (AlarmRecord s in ls)
//            {
//                results.Add(s);
//            }
//            return results;
//        }

//        private List<Department> LoadDeparments(int parentId)
//        {
//            if (AllDepMap.Contains(parentId))
//                return (List<Department>)AllDepMap[parentId];

//            List<Department> results = new List<Department>();
//            string hsql = "from Department where ParentId = ? and Deleted = ?";
//            IList il = BaseDao.query(hsql, new object[] { parentId, false });
//            foreach (Department dep in il)
//            {
//                results.Add(dep);
//                results.AddRange(LoadDeparments(dep.EntityId));
//            }
//            AllDepMap[parentId] = results;
//            return results;
//        }

//        public PageData<Department> GetDepartmentByPage(QueryParam qp)
//        {

//            UserInfo user = this.onlineUser;
//            if (user == null)
//                throw new FaultException("用户没有登录");
//            try
//            {

//                PageData<Department> pd = new PageData<Department>();
//                pd.Data = new List<Department>();
//                Hashtable parameters = new Hashtable();
//                //设置查询参数
//                foreach (string key in qp.Param.Keys)
//                {
//                    parameters[key] = qp.Param[key];
//                }
//                parameters["userId"] = this.onlineUser.EntityId;
//                String queryId = "selectDeps";
//                int skipRows = (qp.StartPageNo - 1) * qp.Limit; 
//                Pagination ls = QueryService.QueryForList(queryId, parameters, skipRows, qp.Limit);

//                foreach (Hashtable item in ls.results)
//                {
//                    Department cu = new Department();
//                    cu.Name = "" + item["name"];
//                    cu.EntityId = (int)item["depId"];
//                    cu.ParentId = (int)item["parentId"];
//                    cu.ParentDepName =""+item["parentDepName"];
//                    cu.Type = ""+item["type"];
//                    cu.AssoMan = "" + item["assoMan"];
//                    cu.AssoTel = "" + item["assoTel"];
//                    cu.Address = "" + item["address"];
//                    cu.CreateDate = (DateTime)item["createDate"];
//                    pd.Data.Add(cu);

//                }

//                int startRows = (qp.StartPageNo - 1) * qp.Limit;

//                pd.TotalRecord = ls.totalCount;
//                pd.Start = startRows;
//                pd.Limit = qp.Limit;
//                //pd.TotalPage = 1 + pd.TotolRecord / pd.Limit;
//                pd.PageNo = qp.StartPageNo;
//                return pd;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }

//        }



        
//        /// <summary>
//        /// 获得用户权限下的所有部门
//        /// </summary>
//        /// <returns></returns>
//        public List<Department> GetDepartments()
//        {
//            try
//            {
//                UserInfo user = this.onlineUser;
//                List<Department> results = new List<Department>();
//                if (user.UserFlag == UserInfo.USER_TYPE_ADMIN)
//                {
//                    IList il = BaseDao.loadAll(typeof(Department));
//                    foreach (Department dep in il)
//                    {
//                        if (dep.Deleted == false)
//                            results.Add(dep);
//                    }
//                    return results;
//                }
//                else
//                {
//                    Hashtable depMap = new Hashtable();
//                    foreach (Department dep in user.Departments)
//                    {
//                        if (depMap.Contains(dep.EntityId) == false && dep.Deleted == false)
//                        {
//                            results.Add(dep);
//                        }
//                        depMap[dep.EntityId] = dep;
//                    }
//                }
//                return results;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }

//        //得到组织架构
//        public List<FuncModel> GetFunctionList()
//        {
//            try
//            {
//                string hsql = "from FuncModel where Deleted = ? order by Name ";
//                IList ls = BaseDao.query(hsql, new object[] { false });

//                List<FuncModel> results = new List<FuncModel>();
//                foreach (FuncModel s in ls)
//                {
//                    results.Add(s);
//                }
//                return results;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }


//        //得到组织架构
//        public List<ClientRole> GetRoleList(int UserId)
//        {
//            string hsql = "from Role where Deleted = ? order by Name ";

//            IList ls = BaseDao.query(hsql, new object[] { false });

//            List<ClientRole> results = new List<ClientRole>();
//            foreach (Role s in ls)
//            {
//                ClientRole cu = new ClientRole();
//                cu.Name = s.Name;
//                cu.RoleId = s.EntityId;

//                foreach (FuncModel fm in s.Funcs)
//                {
//                    cu.FunctionList.Add(fm);                    
//                }


//                results.Add(cu);
//            }
//            return results;
//        }


//        //得到组织架构
//        public PageData<ClientUser> GetUserListByPage(QueryParam qp)
//        {
//            try
//            {
//                PageData<ClientUser> pd = new PageData<ClientUser>();
//                pd.Data = new List<ClientUser>();
//                Hashtable parameters = qp.getParams();

//                int skipRows = qp.SkipRows;
//                String queryId = "selectUsers";
//                Pagination ls = QueryService.QueryForList(queryId, parameters, skipRows, qp.Limit);

//                foreach (CustomHashtable item in ls.results)
//                {
//                    ClientUser cu = new ClientUser();
//                    cu.LoginName = "" + item["loginName"];
//                    cu.Name = "" + item["name"];
//                    cu.UserId = (int)item["userId"];
//                    cu.DepId = item.IntValue("depId");
//                    cu.CreateDate = (DateTime)item["createDate"];
//                    cu.Phone = "" + item["phoneNo"];
//                    cu.RoleName = "" + item["roleName"];
//                    pd.Data.Add(cu);

//                }
//                int startRows = (qp.StartPageNo - 1) * qp.Limit;

//                pd.TotalRecord = ls.totalCount;
//                pd.Start = startRows;
//                pd.Limit = qp.Limit;
//                //pd.TotalPage = 1 + pd.TotolRecord / pd.Limit;
//                pd.PageNo = qp.StartPageNo;
//                return pd;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                logger.Error(ex.StackTrace);
//                throw new FaultException(ex.Message);
//            }

//        }



//        public List<MapLayer> GetMapLayers()
//        {
//            try
//            {
//                string hsql = "from MapLayer where  Deleted = ?";

//                IList ls = BaseDao.query(hsql, new object[] {  false });
//                List<MapLayer> results = new List<MapLayer>();
//                foreach (MapLayer s in ls)
//                {
//                    results.Add(s);
//                }
//                return results;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                logger.Error(ex.StackTrace);
//                throw new FaultException(ex.Message);
//            }
//        }


//        public MapLayer SaveMapLayer(MapLayer layer)
//        {
//            try
//            {
//                string hsql = "from MapLayer where Name = ? and Deleted = ?";
//                MapLayer c = (MapLayer)BaseDao.find(hsql, new object[] { layer.Name, false });

//                if (layer.Deleted == false)
//                {
//                    if (c != null && layer.EntityId == 0)
//                    {
//                        throw new FaultException("该图层名称已经存在，不能重复！");
//                    }

//                    if (layer.EntityId > 0)
//                        c = (MapLayer)BaseDao.load(typeof(MapLayer), layer.EntityId);

//                    if (c == null)
//                        c = new MapLayer();
//                }

//                c.Name = layer.Name;
//                c.Creator = layer.Creator;
//                c.MinIconZoom = layer.MinIconZoom;
//                c.MaxIconZoom = layer.MaxIconZoom;
//                c.MinLabelZoom = layer.MinLabelZoom;
//                c.MaxLabelZoom = layer.MaxLabelZoom;
//                c.ForeColor = layer.ForeColor;
//                c.Deleted = layer.Deleted;
//                c.Animated = layer.Animated;
//                c.Icon = layer.Icon;
//                c.Visible = layer.Visible;

//                BaseDao.saveOrUpdate(c);
//                return c;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                logger.Error(ex.StackTrace);
//                throw new FaultException(ex.Message);
//            }
//        }

//        public void SaveUser(UserInfo u)
//        {
//            try
//            {
//                BaseDao.saveOrUpdate(u);

//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                logger.Error(ex.StackTrace);
//                throw new FaultException(ex.Message);
//            }
//        }
//        /// <summary>
//        /// 保存部门信息
//        /// 同时自动将该部门分配给当前用户及拥有该上级部门的所有用户
//        /// </summary>
//        /// <param name="dep"></param>
//        /// <returns></returns>
//        public Department SaveDepartment(Department dep)
//        {
//            try
//            {
//                Boolean isNewDep = dep.EntityId == 0;//是否是新增部门
//                BaseDao.saveOrUpdate(dep);

//                UserInfo user = this.onlineUser;
//                if (isNewDep)
//                {
//                    if (dep.ParentId > 0)
//                    {
//                        //拥有上级部门权限的用户，也自然拥有上级部门下所有的用户
//                        String hql = "select u from UserInfo u inner join u.Departments f where u.Deleted=? and f.EntityId=? and f.EntityId <> ?";

//                        IList result = this.BaseDao.query(hql, new Object[] {
//							false, dep.ParentId, dep.EntityId });
//                        foreach (UserInfo u in result)
//                        {
//                            u.Departments.Add(dep);
//                            this.BaseDao.saveOrUpdate(u);
//                        }
//                    }
//                    else
//                    {
//                        UserInfo u = this.onlineUser;
//                        u = (UserInfo)this.BaseDao.load(typeof(UserInfo),
//                                u.EntityId);
//                        u.Departments.Add(dep);
//                        this.BaseDao.saveOrUpdate(u);
//                        this.onlineUser = u;
//                    }
//                }
//                else if (dep.Deleted)
//                {
//                    //如果是删除部门
//                    String hql = "select u from UserInfo u inner join u.Departments f where u.Deleted=? and f.EntityId=?";

//                    IList result = this.BaseDao.query(hql, new Object[] {
//							false,  dep.EntityId });
//                    foreach (UserInfo u in result)
//                    {
//                        //需要从用户权限中删除部门
//                        u.Departments.Remove(dep);
//                    }

//                }
//                AllDepMap.Clear();

//                return dep;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                logger.Error(ex.StackTrace);
//                throw new FaultException(ex.Message);
//            }
//        }

//        //保存电子围栏
//        public MapArea SaveMapArea(MapArea ec)
//        {
//            try
//            {
//                BaseDao.saveOrUpdate(ec);
//                if (ec.Deleted && ec.AreaType == MapArea.ROUTE)
//                {
//                    List<LineSegment> ls = GetLineSegments(ec.EntityId);
//                    foreach(LineSegment seg in ls)
//                    {

//                        BaseDao.delete(seg);
//                    }
//                }
//                return ec;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                logger.Error(ex.StackTrace);
//                throw new FaultException(ex.Message);
//            }
//        }


      

//        public void BindRoute(List<string> PlateNoList, string routeIdList)
//        {
//            List<VehicleData> vds = new List<VehicleData>();
//            string hql = "from VehicleData where PlateNo = ?";
//            foreach (string PlateNo in PlateNoList)
//            {
//                VehicleData vd = (VehicleData)BaseDao.find(hql, new object[] { PlateNo });
//                vd.Routes = routeIdList;
//                vds.Add(vd);
//            }
//            BaseDao.saveOrUpdateAll(vds);
//        }

        
       
//        public MapArea SaveRoute(MapArea ec, List<LineSegment> segs)
//        {
//            try
//            {
//                BaseDao.saveOrUpdate(ec);
//                foreach (LineSegment ls in segs)
//                {
//                    ls.RouteId = ec.EntityId;
//                }
//                BaseDao.saveOrUpdateAll(segs);
//                return ec;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }


        

//        public void SaveBasicData(List<BasicData> basicDatas)
//        {
//            try
//            {
//                BaseDao.saveOrUpdateAll(basicDatas);
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }

//        public void SaveAlarmConfig(List<AlarmConfig> alarmList)
//        {
//            try
//            {
//                BaseDao.saveOrUpdateAll(alarmList);
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }

     
//        public RequestEntity SaveEntity(RequestEntity te)
//        {
//            try
//            {
//                this.BaseDao.saveOrUpdate(te.Entity);
//                return te;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }

//        /**
//         *保存或删除用户信息,cu.Deleted = false代表删除
//         */
//        public void SaveClientUser(ClientUser cu)
//        {
//            try
//            {
//                if (cu.Deleted)
//                {
//                    this.BaseDao.removeByFake(typeof(UserInfo), cu.UserId);
//                    return;
//                }
//                string hsql = "from UserInfo u where u.LoginName = ? and EntityId <> ? ";
//                UserInfo otherUser = (UserInfo)BaseDao.find(hsql, new object[] { cu.LoginName, cu.UserId });

//                if (otherUser != null && cu.Deleted ==false)
//                    throw new FaultException("登录名已经存在！");

//                UserInfo user = null;
//                if (cu.UserId > 0)
//                    user = (UserInfo)BaseDao.load(typeof(UserInfo), cu.UserId);
//                else
//                    user = new UserInfo();


//                user.Name = cu.Name;
//                user.EntityId = cu.UserId;
//                user.LoginName = cu.LoginName;
//                user.Password = cu.Password;
//                //user.dep = cu.DepId;
//                user.Deleted = cu.Deleted;
//                //user. = cu.Job;
//                //user.Mail = cu.Mail;
//                user.Remark = cu.Remark;
//                user.Roles.Clear();
//                if (user.Deleted == false)
//                {
//                    foreach (ClientRole r in cu.Roles)
//                    {
//                        Role ro = (Role)BaseDao.load(typeof(Role), r.RoleId);
//                        user.Roles.Add(ro);
//                    }
//                }

//                BaseDao.saveOrUpdate(user);
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                logger.Error(ex.StackTrace);
//                throw new FaultException(ex.Message);
//            }
//        }

//        public void SaveClientRole(ClientRole cr)
//        {
//            try
//            {
//                Role role = null;
//                if (cr.RoleId > 0)
//                    role = (Role)BaseDao.load(typeof(Role), cr.RoleId);
//                else
//                    role = new Role();
//                role.Name = cr.Name;
//                role.Deleted = cr.Deleted;
//                role.Funcs.Clear();
//                if (role.Deleted == false)
//                {
//                    foreach (FuncModel f in cr.FunctionList)
//                    {
//                        role.Funcs.Add(f);
//                    }
//                }

//                BaseDao.saveOrUpdate(role);
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }

//        /// <summary>
//        /// 保存车辆信息
//        /// 1.确保车牌号、sim卡号和车辆编号唯一，否则抛出异常
//        /// 2.记录下车辆信息的修改日志
//        /// </summary>
//        /// <param name="vd"></param>
//        /// <returns></returns>
//        public VehicleData SaveVehicleData(VehicleData vd)
//        {
//            try
//            {
//                if (vd.Deleted == false)
//                {
//                    //判断车牌号和GPSId是否唯一，已经删除的不考虑
//                    string hsql = "from VehicleData where EntityId != ? and (SimNo = ? or PlateNo = ? ) and Deleted = ? ";
//                    VehicleData obj = (VehicleData)BaseDao.find(hsql, new object[] { vd.EntityId, vd.SimNo
//                    , vd.PlateNo, false });
//                    if (obj != null)
//                        throw new FaultException(obj.PlateNo + "已存在，车牌号和终端卡号必须要保证唯一");

//                }

//                if (vd.EntityId > 0)
//                {

//                    VehicleData oldVd = (VehicleData)BaseDao.load(typeof(VehicleData), vd.EntityId);
//                    List<VehicleInfoModifyRecord> mrList = new List<VehicleInfoModifyRecord>();

//                    if (vd.Deleted)
//                    {
//                        VehicleInfoModifyRecord mr = new VehicleInfoModifyRecord();
//                        mr.VehicleId = oldVd.EntityId;
//                        mr.UserName = this.onlineUser.Name;
//                        mr.Type = VehicleInfoModifyRecord.MODIFY_DELETE;
//                        mr.Detail = "删除车辆";
//                        mrList.Add(mr);
//                    }
//                    else
//                    {
//                        if (oldVd.PlateNo != vd.PlateNo)
//                        {
//                            VehicleInfoModifyRecord mr = new VehicleInfoModifyRecord();
//                            mr.VehicleId = oldVd.EntityId;
//                            mr.UserName = this.onlineUser.Name;
//                            mr.Type = VehicleInfoModifyRecord.MODIFY_PLATENO;
//                            StringBuilder detail = new StringBuilder();
//                            detail.Append("车牌号由[").Append(oldVd.PlateNo)
//                                .Append("]变更为[").Append(vd.PlateNo)
//                                .Append("]");
//                            mr.Detail = detail.ToString();
//                            mrList.Add(mr);
//                        }
//                        if (oldVd.PlateColor != vd.PlateColor)
//                        {
//                            VehicleInfoModifyRecord mr = new VehicleInfoModifyRecord();
//                            mr.VehicleId = oldVd.EntityId;
//                            mr.UserName = this.onlineUser.Name;
//                            mr.Type = VehicleInfoModifyRecord.MODIFY_SIMNO;
//                            StringBuilder detail = new StringBuilder();
//                            detail.Append("sim卡号由[").Append(oldVd.SimNo)
//                            .Append("]变更为[").Append(vd.SimNo).Append("]");
//                            mr.Detail = detail.ToString();
//                            mrList.Add(mr);
//                        }
//                        if (oldVd.DepId != vd.DepId)
//                        {
//                            VehicleInfoModifyRecord mr = new VehicleInfoModifyRecord();
//                            mr.VehicleId = oldVd.EntityId;
//                            mr.UserName = this.onlineUser.Name;
//                            mr.Type = VehicleInfoModifyRecord.MODIFY_SIMNO;
//                            StringBuilder detail = new StringBuilder();
//                            Department oldDep = (Department)this.BaseDao.load(typeof(Department), oldVd.DepId);
//                            Department dep = (Department)this.BaseDao.load(typeof(Department), vd.DepId);
//                            detail.Append("过户由[").Append(oldDep.Name).Append("]变更为[")
//                            .Append(dep.Name).Append("]");
//                            mr.Detail = detail.ToString();
//                            mrList.Add(mr);
//                        }
//                    }
                    

//                    if (mrList.Count > 0)
//                    {
//                        this.BaseDao.saveOrUpdateAll(mrList);
//                    }
//                }
//                if (vd.Deleted == false)
//                {
//                    /**
//                    Terminal t = null;
//                    if (vd.TermId > 0)
//                    {
//                        try
//                        {
//                            t = (Terminal)this.BaseDao.load(typeof(Terminal),
//                                    vd.TermId);
//                        }
//                        catch (Exception e)
//                        {
//                            logger.Error(e.Message, e);
//                        }
//                    }
//                    else
//                    {
//                        String hql = "from Terminal where EntityId = ? and Deleted = ?";
//                        Object obj = BaseDao.find(hql, new Object[] { vd.TermId, false });
//                        if (obj != null)
//                            throw new FaultException("终端编号对应的终端已经存在，请重新录入");
//                        t = new Terminal();
//                    }
//                    if (t != null)
//                    {                        
//                        t.Bind = true;
//                        BaseDao.saveOrUpdate(t);
//                        vd.TermId = t.EntityId;
//                    }*/
//                    //删除掉不一致的实时数据表
//                    string hsql2 = "from GPSRealData where PlateNo = ? and SimNo != ?";
//                    BaseDao.Delete(hsql2, new object[] { vd.PlateNo, vd.SimNo });

//                    hsql2 = "from GPSRealData where PlateNo != ? and SimNo = ?";
//                    GPSRealData rd = (GPSRealData)BaseDao.find(hsql2, new object[] { vd.PlateNo, vd.SimNo });
//                    if (rd != null)
//                    {
//                        rd.PlateNo = vd.PlateNo;
//                        BaseDao.saveOrUpdate(rd);
//                    }

                    
//                }
//                else
//                {
//                    vd.TermId = 0;
//                    string hsql1 = "from GPSRealData where  SimNo = ?";
//                    BaseDao.Delete(hsql1, new object[] { vd.SimNo });

//                }
//                BaseDao.saveOrUpdate(vd);
//                if (vd.Driver != null || vd.Monitor != null || vd.DriverMobile != null)
//                {
//                    DriverInfo d = this.GetMainDriverByVehicleId(vd.EntityId);
//                    if (vd.Deleted == false)
//                    {
//                        if (d == null)
//                        {
//                            d = new DriverInfo();
//                            d.MainDriver = true;
//                            d.VehicleId = vd.EntityId;
//                            d.TenantId = this.onlineUser.RegionId;
//                        }
//                        d.DriverName = vd.Driver;
//                        d.Monitor = vd.Monitor;
//                        d.Telephone = vd.DriverMobile;
                        
                       
//                    }
//                    else
//                    {
//                        d.VehicleId = 0;
//                    }
//                    BaseDao.saveOrUpdate(d);
//                }
//                try
//                {
//                    RealDataService.updateVehicleData(vd.SimNo, vd);
//                }
//                catch (Exception ex)
//                {
//                    logger.Error(ex.Message, ex);
//                }

//                return vd;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                logger.Error(ex.StackTrace);
//                throw new FaultException(ex.Message);
//            }
//        }



//        //分页查询油量和里程统计
//        public PageData<FuelConsumption> GetFuelConsumption(QueryParam param)
//        {
//            PageData<FuelConsumption> pd = new PageData<FuelConsumption>();
//            List<FuelConsumption> vds = new List<FuelConsumption>();
//            pd.Data = vds;
//            try
//            {
//                if (param.Limit < 10)
//                    param.Limit = 10;

//                Hashtable ht = new Hashtable();
//                ht["UserId"] = param.UserId;
//                //设置查询参数
//                foreach (string key in param.Param.Keys)
//                {
//                    ht[key] = param.Param[key];
//                }
//                UserInfo user = (UserInfo)BaseDao.load(typeof(UserInfo), param.UserId);

//                List<int> depList = getDepIdList();
//                if (depList.Count == 0)
//                    return pd;
//                ht["depList"] = depList;
//                int IntervalType = 0;
//                try
//                {
//                    IntervalType = (int)param.Param["IntervalType"];
//                }
//                catch (Exception ex)
//                {
//                }
//                //string queryId = "selectFuelConsumption";
//                string queryId = "selectMileageStatic";
//                /**
//                if (IntervalType == FuelConsumption.STATIC_TIME_SPAN)
//                {
//                    //按时间端进行累计计算
//                    queryId = "selectMileageStatic";
//                    ht["IntervalType"] = FuelConsumption.STATIC_BY_HOUR;
//                }*/

//                int skipRows = (param.StartPageNo - 1) * param.Limit;
//                Pagination ls = QueryService.QueryForList(queryId, ht, skipRows, param.Limit);

//                foreach (Hashtable item in ls.results)
//                {
//                    FuelConsumption vd = new FuelConsumption();
//                    vd.EntityId = (int)item["ID"];
//                    vd.PlateNo = "" + item["plateNo"];
//                    vd.DepName = "" + item["depName"];
//                    //vd.Hour = item["Hour"];
//                    vd.Mileage = Double.Parse("" + item["mileage"]);
//                    vd.Gas = Double.Parse("" + item["gas"]);
//                    vd.IntervalType = (int)item["intervalType"];
//                    vd.StaticDate = (DateTime)item["staticDate"];
//                    try
//                    {
//                        if (IntervalType != FuelConsumption.STATIC_TIME_SPAN)
//                        {
//                            vd.Mileage1 = (Double)item["mileage1"];
//                            vd.Mileage2 = (Double)item["mileage2"];
//                            vd.Gas1 = (Double)item["gas1"];
//                            vd.Gas2 = (Double)item["gas2"];
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        //logger.Error(ex.Message);
//                    }

//                    vds.Add(vd);
//                }
//                pd.TotalRecord = ls.totalCount;
//                pd.PageNo = param.StartPageNo;
//                pd.Limit = param.Limit;
//                int startRows = (param.StartPageNo - 1) * param.Limit;
//                pd.Start = startRows;
//                //pd.TotalPage = 1 + pd.TotolRecord / pd.Limit;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                logger.Error(ex.StackTrace);
//                if(ex.Message.IndexOf("无效读取") < 0)
//                  throw new FaultException(ex.Message);
//            }
//            return pd;
//        }

//        //根据下发的命令Id,得到照片、录像等多媒体数据
//        public MediaItem GetMediaData(int commandId)
//        {
//            try
//            {
//                String hql = "from MediaItem where CommandId = ?";

//                MediaItem mi =  (MediaItem)BaseDao.find(hql, commandId);
//                if (mi != null)
//                {
//                    //得到照片、录像等多媒体数据
//                    mi.MediaData = getImageBytesFromFile(mi);
//                }
//                return mi;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }


//        //分页查询车辆定时上传的照片
//        public PageData<MediaItem> GetVehiclePhotoByPage(QueryParam param)
//        {
//            try
//            {
//                if (param.Limit < 10)
//                    param.Limit = 10;

//                PageData<MediaItem> pd = new PageData<MediaItem>();

//                List<MediaItem> vds = new List<MediaItem>();
//                pd.Data = vds;
//                Hashtable ht = new Hashtable();
//                ht["UserId"] = param.UserId;
//                //设置查询参数
//                foreach (string key in param.Param.Keys)
//                {
//                    ht[key] = param.Param[key];
//                }
//                UserInfo user = (UserInfo)BaseDao.load(typeof(UserInfo), param.UserId);

//                List<int> depList = getDepIdList();
//                if (depList.Count == 0)
//                    return pd;
//                ht["depList"] = depList;

//                string queryId = "selectMediaItems";
//                int skipRows = (param.StartPageNo - 1) * param.Limit;
//                Pagination ls = QueryService.QueryForList(queryId, ht, skipRows, param.Limit);

//                foreach (Hashtable item in ls.results)
//                {
//                    MediaItem mi = new MediaItem();
//                    mi.MediaType = (byte)item["mediaType"];
//                    mi.PlateNo = "" + item["plateNo"];
//                    mi.FileName = "" + item["fileName"];
//                    mi.SimNo = "" + item["GpsId"];
//                    mi.EntityId = (int)item["mediaItemId"];
//                    mi.Latitude = (double)item["latitude"];
//                    mi.Longitude = (double)item["longitude"];
//                    mi.Speed = (double)item["speed"];
//                    mi.Owner = "" + item["owner"];
//                    mi.Location = "" + item["cocation"];
//                    mi.CodeFormat = (byte)item["codeFormat"];
//                    mi.MediaDataId = (int)item["mediaDataId"];
//                    mi.CreateDate = (DateTime)item["createDate"];
//                    if(item["sendTime"]!=null)
//                    mi.SendTime = (DateTime)item["sendTime"];

//                    mi.MediaData = getImageBytesFromFile(mi);

//                    vds.Add(mi);
//                }
//                pd.TotalRecord = ls.totalCount;
//                pd.PageNo = param.StartPageNo;
//                pd.Limit = param.Limit;
//                int startRows = (param.StartPageNo - 1) * param.Limit;
//                pd.Start = startRows;
//                //pd.TotalPage = 1 + pd.TotolRecord / pd.Limit;
//                return pd;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                logger.Error(ex.StackTrace);
//                throw new FaultException(ex.Message);
//            }

//        }
//        /**
//         * 根据多媒体记录找到媒体文件的实际路径，并读入到内存当中
//         */
//        private byte[] getImageBytesFromFile(MediaItem mi)
//        {
//            if (string.IsNullOrEmpty(mi.FileName))
//                return null;

//            if (string.IsNullOrEmpty(VehiclePhotoDir))
//                VehiclePhotoDir = System.Environment.CurrentDirectory;
//            try
//            {
//                string fullPath = VehiclePhotoDir + "//" + mi.FileName;
//                byte[] bytes = File.ReadAllBytes(fullPath);
//                return bytes;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                return null;
//            }
//        }


//        public List<Dictionary<String, Object>> QueryList(QueryParam qp)
//        {
//            try
//            {
//                this.isValidUser();
//                List<Dictionary<String, Object>> vds = new List<Dictionary<String, Object>>();
//                Hashtable ht = qp.getParams();
//                ht["userId"] = this.onlineUser.EntityId;

//                //设置查询参数
//                /**
//                List<int> depList = getDepIdList();
//                if (depList.Count == 0)
//                    return pd;
//                ht["depList"] = depList;
//                */
//                IList ls = QueryService.QueryForList(qp.QueryId, ht);
//                foreach (CustomHashtable rowData in ls)
//                {
//                    Dictionary<String, Object> d = new Dictionary<string, object>();
//                    ICollection keys = rowData.Keys;
//                    foreach (String key in keys)
//                    {
//                        d[key] = rowData[key];
//                    }
//                    vds.Add(d);

//                }
//                return vds;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }

//        } 

//        public PageData<Dictionary<String, Object>> QueryListByPage(QueryParam qp)
//        {
//            try
//            {
//                this.isValidUser();
//                PageData<Dictionary<String, Object>> pd = new PageData<Dictionary<String, Object>>();
//                List<Dictionary<String, Object>> vds = new List<Dictionary<String, Object>>();
//                pd.Data = vds;
//                Hashtable ht = qp.getParams();
//                ht["userId"] = this.onlineUser.EntityId;

//                if (this.onlineUser.RegionId > 0 && this.onlineUser.IsAdmin() == false)
//                {
//                   List<int> tenantIdList =  this.DepartmentService.getDepIdList(this.onlineUser.RegionId);
//                   ht["tenantIdList"] = tenantIdList;
//                }

//                if (qp.QueryId == "selectProcessedAlarms")
//                {
//                    String startTime = "";
//                    String endTime = "";
//                    if (ht["startTime"] == null)
//                    {
//                        startTime = DateTime.Now.ToString("yyyyMMdd");
//                        endTime = DateTime.Now.ToString("yyyyMMdd");
//                    }
//                    else
//                    {
//                        startTime = ((DateTime)ht["startTime"]).ToString("yyyyMMdd");
//                        if (ht["endTime"] == null)
//                            endTime = DateTime.Now.ToString("yyyyMMdd");
//                        else
//                            endTime = ((DateTime)ht["endTime"]).ToString("yyyyMMdd");
//                        //startTime = startTime.Substring(0, 10).Replace("-", "").Replace("/","");
//                        //endTime = endTime.Substring(0, 10).Replace("-", "").Replace("/", "");
//                    }
//                    String today = DateTime.Now.ToString("yyyyMMdd");
//                    if (endTime.CompareTo(today) > 0)
//                        endTime = today;
//                    String tableName1 = "NewAlarm" + startTime;
//                    ht["tableName1"] = tableName1;
//                    String tableName2 = "NewAlarm" + endTime;
//                    ht["tableName2"] = tableName2;

//                    if (tableName1.Equals(tableName2) == false)
//                    {
//                        qp.QueryId = "selectProcessedAlarmsIn2Months";
//                    }
                    

//                }

//                //设置查询参数
//                /**
//                List<int> depList = getDepIdList();
//                if (depList.Count == 0)
//                    return pd;
//                ht["depList"] = depList;
//                */
//                Pagination ls = QueryService.QueryForList(qp.QueryId, ht, qp.SkipRows, qp.Limit);
//                foreach(CustomHashtable rowData in ls.results)
//                {
//                    Dictionary<String, Object> d = new Dictionary<string, object>();
//                    ICollection keys = rowData.Keys;
//                    foreach (String key in keys)
//                    {
//                        d[key] = rowData[key];
//                    }
//                    vds.Add(d);

//                }
//                pd.TotalRecord = ls.totalCount;
//                pd.PageNo = qp.StartPageNo;
//                pd.Limit = qp.Limit;
//                pd.Start = qp.SkipRows;
//                pd.Data = vds;
//                return pd;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }

//        }


//        //分页查询终端命令
//        public PageData<TerminalCommand> GetTerminalCommandByPage(QueryParam param)
//        {
//            try
//            {
//                if (param.Limit < 10)
//                    param.Limit = 10;

//                PageData<TerminalCommand> pd = new PageData<TerminalCommand>();

//                List<TerminalCommand> vds = new List<TerminalCommand>();
//                pd.Data = vds;
//                Hashtable ht = new Hashtable();
//                ht["UserId"] = this.onlineUser.EntityId;
//                //设置查询参数
//                foreach (string key in param.Param.Keys)
//                {
//                    ht[key] = param.Param[key];
//                }
                
//                string queryId = "selectTerminalCommand";
//                int skipRows = (param.StartPageNo - 1) * param.Limit;
//                Pagination ls = QueryService.QueryForList(queryId, ht, skipRows, param.Limit);

//                foreach (Hashtable item in ls.results)
//                {
//                    TerminalCommand vd = new TerminalCommand();
//                    vd.CmdType = (int)item["cmdType"];
//                    vd.PlateNo = "" + item["plateNo"];
//                    vd.CmdData = "" + item["cmdData"];
//                    vd.SimNo = "" + item["simNo"];
//                    vd.Status = "" + item["status"];
//                    vd.Owner = "" + item["owner"];
//                    vd.Status = "" + item["status"];
//                    vd.SN = (int)item["SN"];
//                    vd.UserId = (int)(item["UserId"] == null ? 0 : item["UserId"]);
//                    vd.CreateDate = (DateTime)item["createDate"];

//                    vds.Add(vd);
//                }
//                pd.TotalRecord = ls.totalCount;
//                pd.PageNo = param.StartPageNo;
//                pd.Limit = param.Limit;
//                int startRows = (param.StartPageNo - 1) * param.Limit;
//                pd.Start = startRows;
//                //pd.TotalPage = 1 + pd.TotolRecord / pd.Limit;
//                return pd;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }

//        }

//        //分页查询车辆列表
//        public PageData<VehicleData> GetVehiclesByPage(QueryParam param)
//        {

//            PageData<VehicleData> pd = new PageData<VehicleData>();
//            try
//            {
//                List<VehicleData> vds = new List<VehicleData>();
//                pd.Data = vds;
//                Hashtable ht = param.getParams();
//                UserInfo user = this.onlineUser;
//                if (user == null)
//                    throw new FaultException("用户没有登录");

//                List<int> depList = getDepIdList();
//                if (depList.Count == 0)
//                    return pd;
//                ht["depList"] = depList;
//                ht["sortBy"] = "plateNo";
//                ht["userId"] = user.EntityId;

//                int depId = 0;
//                if (ht.ContainsKey("depId"))
//                    depId = int.Parse("" + ht["depId"]);
//                if (depId > 0)
//                {
//                    List<int> depIdList = this.DepartmentService
//                            .getDepIdList(depId);
//                    ht["depIdList"]= depIdList;
//                }
//                string queryId = "selectOnlineVehicles";
//                //int skipRows = (param.StartPageNo - 1) * param.Limit;
//                Pagination ls = QueryService.QueryForList(queryId, ht, param.SkipRows, param.Limit);
//                foreach (CustomHashtable item in ls.results)
//                {
//                    VehicleData vd = new VehicleData();
//                    vd.EntityId = (int)item["vehicleId"];
//                    vd.PlateNo = "" + item["plateNo"];
//                    vd.DepId = (int)item["depId"];
//                    vd.DepName = "" + item["depName1"];
//                    vd.DriverMobile = "" + item["DriverMobile"];
//                    vd.Driver = "" + item["Driver"];
//                    vd.VehicleType = "" + item["vehicleType"];
//                    vd.Routes = "" + item["Routes"];
//                    vd.OnlineTime = (DateTime?)item["sendTime"];
//                    vd.Status = ""+item["online"];
//                    vd.RunStatus = "" + item["runStatus"];
//                    vd.PlateColor = item.IntValue("plateColor");
//                    vd.GpsTerminalType = "" + item["termType"];
//                    vd.SimNo = "" + item["simNo"];
//                    vd.CreateDate = (DateTime)item["CreateDate"];
//                    vds.Add(vd);
//                }
//                pd.TotalRecord = ls.totalCount;
//                pd.PageNo = param.StartPageNo;
//                pd.Limit = param.Limit;
//                pd.Start = param.SkipRows;
//                return pd;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }

//        }

//        private TerminalCommand createAreaCommand(AreaBindingInfo area,Vehicle vd)
//        {
//            TerminalCommand tc = new TerminalCommand();
//            tc.CmdData = ""+area.AreaId;
//            tc.Cmd = "" + area.ConfigType;
//            tc.PlateNo = vd.PlateNo;
//            tc.SimNo = vd.SimNo;
//            if (onlineUser != null)
//            {
//                tc.Owner = onlineUser.Name;
//                tc.UserId = onlineUser.EntityId;
//            }
//            if (area.AreaType== MapArea.CIRCLE)
//            {
//                tc.CmdType = JT808Constants.CMD_CIRCLE_CONFIG;
//                if (area.ConfigType == 3)
//                {
//                    tc.CmdType = JT808Constants.CMD_DELETE_CIRCLE;
//                }
//            }
//            else if (area.AreaType == MapArea.RECT)
//            {
//                tc.CmdType = JT808Constants.CMD_RECT_CONFIG;
//                if (area.ConfigType == 3)
//                {
//                    tc.CmdType = JT808Constants.CMD_DELETE_RECT;
//                }
//            }
//            else if (area.AreaType == MapArea.POLYGON)
//            {
//                tc.CmdType = JT808Constants.CMD_POLYGON_CONFIG;
//                if (area.ConfigType == 3)
//                {
//                    tc.CmdType = JT808Constants.CMD_DELETE_POLYGON;
//                }
//            }
//            else if (area.AreaType == MapArea.ROUTE)
//            {
//                tc.CmdType = JT808Constants.CMD_ROUTE_CONFIG;
//                if (area.ConfigType == 3)
//                {
//                    tc.CmdType = JT808Constants.CMD_DELETE_ROUTE;
//                }
//            }


//            return tc;
//        }
//        /**
//         * 对终端绑定区域
//         */
//        public void BindTerminalWithArea(List<AreaBindingInfo> bindingList)
//        {
//            try
//            {
//                List<MapAreaBinding> areaBindingList = new List<MapAreaBinding>();
//                foreach (AreaBindingInfo a in bindingList)
//                {
//                    Vehicle vd = this.GetVehicleById(a.VehicleId);

//                    MapAreaBinding eb = new MapAreaBinding(); 
//                    if (a.BindId > 0)
//                    {
//                        eb = (MapAreaBinding)this.BaseDao.load(typeof(MapAreaBinding), a.BindId);
//                    }
//                    if (a.BindingType != MapAreaBinding.BINDING_PLATFORM)
//                    {
//                        //如果不是由平台报警，就下发给终端，让终端报警
//                        MapArea area = (MapArea)BaseDao.load(typeof(MapArea), a.AreaId);
//                        a.AreaType = area.AreaType;
//                        TerminalCommand tc = this.createAreaCommand(a, vd);
//                        this.BaseDao.saveOrUpdate(tc);
//                        eb.CommandId = tc.EntityId;
//                    }
//                    try
//                    {                        
//                        eb.AreaId = a.AreaId;
//                        eb.VehicleId = a.VehicleId;
//                        eb.BindType = a.BindingType;
//                        eb.ConfigType = a.ConfigType;
//                        eb.CreateDate = DateTime.Now;
//                        areaBindingList.Add(eb);
//                    }
//                    catch (Exception ex)
//                    {
//                        logger.Error(vd.PlateNo + "下发命令失败, 异常原因:" + ex.Message);
//                        return;
//                    }
//                }

//                this.BaseDao.saveOrUpdateAll(areaBindingList);
//            }
//            catch (Exception ex)
//            {
//                XTrace.WriteException(ex);
//                throw new FaultException(ex.Message);
//            }
//        }


//        private object getNumber(object obj)
//        {
//            int x = 0;
//            obj = obj == null ? x : obj;
//            return obj;
//        }

//        //分页查询查询电子围栏列表
//        public PageData<AreaBindingInfo> GetAreaBindingInfoByPage(QueryParam param)
//        {
//            try
//            {
//                if (param.Limit < 10)
//                    param.Limit = 10;

//                PageData<AreaBindingInfo> pd = new PageData<AreaBindingInfo>();

//                List<AreaBindingInfo> vds = new List<AreaBindingInfo>();
//                pd.Data = vds;
//                Hashtable ht = new Hashtable();
//                ht["UserId"] = param.UserId;
//                //设置查询参数
//                foreach (string key in param.Param.Keys)
//                {
//                    ht[key] = param.Param[key];
//                }
//                UserInfo user = (UserInfo)BaseDao.load(typeof(UserInfo), param.UserId);

//                List<int> depList = getDepIdList();
//                if (depList.Count == 0)
//                    return pd;
//                ht["depList"] = depList;

//                //if (ht["OnlineStatus"] == null)
//                   // ht["OnlineStatus"] = "";

//               // if (ht["BindState"] == null)
//                    //ht["BindState"] = "none";

//                string queryId = "selectBindVehicles";
//                int skipRows = (param.StartPageNo - 1) * param.Limit;
//                Pagination ls = QueryService.QueryForList(queryId, ht, skipRows, param.Limit);

//                foreach (Hashtable item in ls.results)
//                {
//                    AreaBindingInfo vd = new AreaBindingInfo();
//                    vd.AreaId = (int)this.getNumber(item["AreaId"]);
//                    vd.AreaName= "" + item["AreaName"];
//                    vd.AreaType = "" + item["AreaType"];
//                    vd.ConfigType = (int)this.getNumber(item["ConfigType"]);
//                    vd.DepId = (int)this.getNumber(item["DepId"]);
//                    vd.CommandStatus = "" + item["CommandStatus"];
//                    vd.BindingType = "" + item["BindType"];
//                    vd.PlateNo = "" + item["PlateNo"];
//                    vd.VehicleId = (int)item["VehicleId"];
//                    vd.DepName = "" + item["DepName"];
//                    vd.UpdateDate = (DateTime?)item["UpdateDate"];
//                    if (vd.BindingType == MapAreaBinding.BINDING_PLATFORM)
//                    {
//                        vd.UpdateDate = (DateTime?)item["CreateDate"];
//                    }
//                    vd.BindId = (int)getNumber(item["BindId"]);

//                    vds.Add(vd);
//                }
//                pd.TotalRecord = ls.totalCount;
//                pd.PageNo = param.StartPageNo;
//                pd.Limit = param.Limit;
//                int startRows = (param.StartPageNo - 1) * param.Limit;
//                pd.Start = startRows;
//                //pd.TotalPage = 1 + pd.TotolRecord / pd.Limit;
//                return pd;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }



//        //分页查询查询电子围栏列表
//        public PageData<MapArea> GetMapAreaByPage(QueryParam param)
//        {
//            try
//            {
//                if (param.Limit < 10)
//                    param.Limit = 10;

//                PageData<MapArea> pd = new PageData<MapArea>();

//                List<MapArea> vds = new List<MapArea>();
//                pd.Data = vds;
//                Hashtable ht = new Hashtable();
//                ht["UserId"] = param.UserId;
//                //设置查询参数
//                foreach (string key in param.Param.Keys)
//                {
//                    ht[key] = param.Param[key];
//                }
//                User user = (User)BaseDao.load(typeof(User), param.UserId);

//                List<int> depList = getDepIdList();
//                if (depList.Count == 0)
//                    return pd;
//                ht["depList"] = depList;

//                string queryId = "selectMapAreas";
//                int skipRows = (param.StartPageNo - 1) * param.Limit;
//                Pagination ls = QueryService.QueryForList(queryId, ht, skipRows, param.Limit);

//                foreach (Hashtable item in ls.results)
//                {
//                    MapArea vd = new MapArea();
//                    vd.EntityId = (int)item["AreaId"];
//                    vd.Name = "" + item["Name"];
//                    vd.AreaType = "" + item["AreaType"];
//                    vd.AlarmType = "" + item["AlarmType"];
//                    vd.StartDate = (DateTime)item["StartDate"];
//                    vd.EndDate = (DateTime)item["EndDate"];
//                    if (item["MaxSpeed"] != null)
//                        vd.MaxSpeed = (Double)(item["MaxSpeed"]);
//                    vd.Status = "" + item["Status"];
//                    vd.CreateDate = (DateTime)item["CreateDate"];

//                    vds.Add(vd);
//                }
//                pd.TotalRecord = ls.totalCount;
//                pd.PageNo = param.StartPageNo;
//                pd.Limit = param.Limit;
//                int startRows = (param.StartPageNo - 1) * param.Limit;
//                pd.Start = startRows;
//                //pd.TotalPage = 1 + pd.TotolRecord / pd.Limit;
//                return pd;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }


//        /**
//         * 报警统计查询
//         */
//        public List<AlarmStatic> GetAlarmStatic(QueryParam param)
//        {
//            List<AlarmStatic> vds = new List<AlarmStatic>();
//            int UserId = param.UserId;
//            Hashtable parameters = new Hashtable();
//            parameters["UserId"] = param.UserId;
//            //设置查询参数
//            foreach (string key in param.Param.Keys)
//            {
//                parameters[key] = param.Param[key];
//            }
//            UserInfo user = (UserInfo)BaseDao.load(typeof(UserInfo), UserId);

//            List<int> depList = getDepIdList();
//            if (depList.Count == 0)
//                return vds;
//            parameters["depList"] = depList;

//            string queryId = "selectAlarmStatic";
//            IList ls = QueryService.QueryForList(queryId, parameters);
//            Hashtable itemMap = new Hashtable();
//            foreach (Hashtable item in ls)
//            {
//                string plateNo = "" + item["PlateNo"];
//                AlarmStatic vd = (AlarmStatic)itemMap[plateNo];
//                if(vd == null)
//                {
//                    vd = new AlarmStatic();
//                    itemMap[plateNo] = vd;
//                    vd.PlateNo = plateNo;
//                    vd.DepName = "" + item["DepName"];
//                    vd.StaticItem = new List<AlarmStaticItem>();
//                    vds.Add(vd);
//                }
//                AlarmStaticItem alarmItem = new AlarmStaticItem();
//                alarmItem.AlarmCount = (int)item["AlarmCount"];
//                alarmItem.AlarmSrc = "" + item["AlarmSource"];
//                alarmItem.AlarmType = "" + item["AlarmType"];
//                vd.StaticItem.Add(alarmItem);
//            }

//            return vds;
//        }

//        public VehicleData GetVehicle(String PlateNo)
//        {
//            try
//            {
//                string hsql = "from VehicleData where PlateNo = ? and Deleted = ?";
//                VehicleData vd = (VehicleData)BaseDao.find(hsql, new object[] { PlateNo , false});
//                if (vd != null )
//                {
//                    try
//                    {
//                        if (vd.TermId > 0)
//                        {
//                            Terminal t = (Terminal)BaseDao.load(typeof(Terminal), vd.TermId);
//                            vd.TermId = t.EntityId;
//                            vd.GpsTerminalType = t.TermType;
//                        }
//                        else
//                        {
//                            vd.TermId = 0;
//                            vd.GpsTerminalType = null;
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        logger.Error(ex.Message, ex);
//                    }
//                }
//                return vd;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }
//        private VehicleData GetVehicleById(int VehicleId)
//        {
//            //string hsql = "from VehicleData where EntityId = ?";
//            VehicleData vd = (VehicleData)BaseDao.load(typeof(VehicleData), VehicleId);
//            return vd;
//        }
//        /// <summary>
//        /// 根据车辆ID获取车辆绑定的主驾驶信息
//        /// </summary>
//        /// <param name="vehicleId"></param>
//        /// <returns></returns>
//        public DriverInfo GetMainDriverByVehicleId(int vehicleId)
//        {
//            try
//            {
//                String hql = "from DriverInfo where VehicleId = ? and Deleted = ? and MainDriver = ?";
//                DriverInfo d = (DriverInfo)BaseDao.find(hql, new Object[] { vehicleId, false, true });
//                return d;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }

//        }

//        /**
//         * 得到前端所需要的下拉框数据
//         */
//        public List<BasicData> GetDropDownList(String queryId, QueryParam param)
//        {
//            try
//            {
//                List<BasicData> vds = new List<BasicData>();
//                Hashtable ht = new Hashtable();
//                ht["UserId"] = this.onlineUser.EntityId;
//                //设置查询参数
//                if (param != null)
//                {
//                    foreach (string key in param.Param.Keys)
//                    {
//                        ht[key] = param.Param[key];
//                    }
//                }
                
//                IList ls = QueryService.QueryForList(queryId, ht);

//                foreach (Hashtable item in ls)
//                {
//                    BasicData vd = new BasicData();
//                    vd.name = "" + item["name"];
//                    vd.code = "" + item["code"];
//                    vds.Add(vd);
//                }

//                return vds;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }
//        /// <summary>
//        /// 得到用户所分配的所有的部门Id,如果分配了上级部门，则自动也加载所有的下级部门
//        /// </summary>
//        /// <returns></returns>
//        private List<int> getDepIdList()
//        {
//            if (onlineUser == null)
//                return new List<int>();

//            List<Department> depList = this.GetDepartments();

//            System.Collections.Generic.List<int> depIdList = new System.Collections.Generic.List<int>();

//            foreach (Department dep in depList)
//            {
//                depIdList.Add(dep.EntityId);
//            }

//            return depIdList;
//        }


//        private double convertDouble(object obj)
//        {
//            return obj != null ? Double.Parse(""+obj) : 0;
//        }

//        private void isValidUser()
//        {
//            if (this.onlineUser == null)
//                throw new FaultException("用户没有登录");
//        }

       

//        /// <summary>
//        /// 得到车辆树节点
//        /// </summary>
//        /// <returns></returns>
//        public List<VehicleTreeNode> GetVehicleTreeNodes()
//        {
//            isValidUser();
//            try
//            {
//                List<VehicleTreeNode> vds = new List<VehicleTreeNode>();

//                Hashtable ht = new Hashtable();
//                UserInfo user = this.onlineUser;
//                ht["userId"] = user.EntityId;
//                string queryId = "selectVehicleTree";
//                IList ls = QueryService.QueryForList(queryId, ht);

//                foreach (CustomHashtable item in ls)
//                {
//                    VehicleTreeNode vd = new VehicleTreeNode();
//                    vd.VehicleId = item.IntValue("vehicleId");
//                    vd.PlateNo = "" + item["plateNo"];
//                    //vd.VehicleNo = "" + item["vehicleNo"];
//                    vd.DepId = item.IntValue("depId");
//                    vd.Speed = item.DoubleValue("velocity");// == null ? 0 : Double.Parse("" + item["velocity"]);
//                    vd.DepName = "" + item["depName1"];
//                    vd.SimNo = "" + item["simNo"];
//                    vd.Lat = item.DoubleValue("latitude");
//                    vd.Lng = item.DoubleValue("longitude");
//                    vd.MonitorName = item.StringValue("monitor");
//                    vd.DriverName = item.StringValue("driverName");
//                    vd.Telephone = item.StringValue("telephone");
//                    //vd.ShippingId = item.IntValue("shippingId");
//                    //vd.TaskName = item.StringValue("taskName");
//                    vd.IconIndex = VehicleStatus.OFFLINE;
//                    vd.Online = false;
//                    try
//                    {
//                        if (RealDataService != null)
//                        {
//                            GPSRealData rd = RealDataService.Get(vd.SimNo);
//                            vd.Online = rd != null ? rd.Online : false;
//                            if (rd != null)
//                            {
//                                vd.Speed = rd.Velocity;
//                                //vd.IconIndex = rd.RunStatus;
//                                //vd.LocationProgress = rd.LocationProgress;
//                                //vd.LocationStatus = rd.DirectionStatus;
//                            }
//                        }
//                       // else
//                           // vd.Online = false;
//                    }
//                    catch (Exception ex)
//                    {
//                        logger.Error(ex.Message);
//                    }
//                    if (vd.Online)
//                    {
//                        vd.IconIndex = vd.Speed > 1 ? VehicleStatus.RUNNING : VehicleStatus.PARKING;
//                    }
//                    String runStatus = "" + item["runStatus"];
//                    //如果车辆不在运行状态，就强行归入到休息状态
                    

//                    VehicleTreeNode oldVd = null;
//                    if (treeNodeMap.TryGetValue(vd.VehicleId, out oldVd))
//                    {
//                        if (oldVd.IconIndex == vd.IconIndex )
//                        {
//                            continue;//状态没有发生改变，不更新
//                        }
//                    }

//                    treeNodeMap[vd.VehicleId] = vd;
//                    vds.Add(vd);
//                }

//                return vds;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }

//        }
//        /**
//         *查询某一个级联的数据，用于前端下拉树控件数据显示
//         */
//        public List<NodeItem> GetNodeItemList(String queryId)
//        {
//            List<NodeItem> rds = new List<NodeItem>();
//            try
//            {
//                 Hashtable parameters = new Hashtable();
//                IList il = QueryService.QueryForList(queryId, parameters);
//                foreach (Hashtable ht in il)
//                {
//                    NodeItem ni = new NodeItem();
//                    ni.Id = (int)ht["id"];
//                    ni.Name = "" + ht["name"];
//                    ni.ParentId = (int)ht["pId"];
//                    rds.Add(ni);
//                }

//                return rds;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }

        
//        //根据租户获取所有的实时数据
//        public List<GPSRealData> GetRealDatas()
//        {
//            try
//            {
//                isValidUser();
//                List<GPSRealData> rds = new List<GPSRealData>();
//                int UserId = this.onlineUser.EntityId;
//                System.Collections.Generic.List<int> depIdList = this.getDepIdList();

//                //加载管理权限
//                if (depIdList.Count == 0)
//                    return rds;
//                Hashtable parameters = new Hashtable();
//                parameters["UserId"] = UserId;
//                parameters["depList"] = depIdList;
//                IList il = QueryService.QueryForList("selectGpsRealData", parameters);
//                foreach (Hashtable ht in il)
//                {
//                    GPSRealData rd = new GPSRealData();
//                    rd.ID = (int)ht["ID"];
//                    rd.PlateNo = "" + ht["plateNo"];
//                    double lat = double.Parse(""+ht["latitude"]);
//                    double lng = double.Parse(""+ht["longitude"]);
//                    rd.Latitude = lat;
//                    rd.Longitude = lng;
//                    String strAlarmState = ""+ht["alarmState"];
//                    rd.AlarmState = strAlarmState;// Convert.ToInt32(strAlarmState, 2);

//                    String strStatus = "" + ht["status"];
//                    rd.Status = strStatus;// Convert.ToInt32(strStatus, 2);

//                    rd.VehicleId = (int)this.getNumber(ht["vehicleId"]);
//                    rd.Gas = double.Parse(""+ht["gas"]);
//                    rd.Mileage = double.Parse(""+ht["mileage"]);

//                    rd.SendTime = (DateTime)ht["sendTime"];

//                    rd.Online = (Boolean)ht["online"];
//                    TimeSpan ts = DateTime.Now - rd.SendTime;
//                    if (ts.TotalMinutes > 5)
//                        rd.Online = false;

//                    rd.SimNo = "" + ht["simNo"];
//                    rd.Location = "" + ht["location"];
//                    rd.Velocity = double.Parse(""+ht["velocity"]);
//                    rd.Valid = (Boolean)ht["valid"];
                    
//                    rds.Add(rd);
//                }

//                return rds;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }


//        public void DeleteEntityById(String type, int entityId)
//        {
//            try
//            {
//                Type t = System.Type.GetType(type);
//                BaseDao.removeByFake(t, entityId);
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                logger.Error(ex.StackTrace);
//                throw new FaultException(ex.Message);
//            }
//        }
//        /// <summary>
//        /// 根据实体类的类型和实体类id获取数据
//        /// </summary>
//        /// <param name="type">实体类的类型的字符串表示如：typeof(VehicleData).ToString()</param>
//        /// <param name="entityId">实体类id</param>
//        /// <returns></returns>
//        public RequestEntity GetEntityById(String type, int entityId)
//        {
//            try
//            {
//                Type t = System.Type.GetType(type);
//                Object obj = BaseDao.load(t, entityId);
//                RequestEntity re = new RequestEntity(obj);
//                return re;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message);
//                logger.Error(ex.StackTrace);
//                throw new FaultException(ex.Message);
//            }
//        }



//        //根据车牌号，获取车辆的实时数据
//        public GPSRealData GetRealData(String plateNo)
//        {
//            try
//            {
//                String hql = "from GPSRealData where plateNo = ?";
//                return (GPSRealData)BaseDao.find
//                    (hql, plateNo);
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }


//        //根据下发的命令ID，查询到终端命令信息
//        public TerminalCommand GetTerminalCommand(int commandId)
//        {
//            try
//            {
//                return (TerminalCommand)BaseDao.load(typeof(TerminalCommand), commandId);
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }

//        //根据采集命令ID，得到行车记录仪数据采集数据
//        public VehicleRecorder GetRecorderInfo(int commandId)
//        {
//            string hsql = "from VehicleRecorder where CommandId = ? ";
//            VehicleRecorder vr = (VehicleRecorder)BaseDao.find(hsql, commandId);
//            return vr;
//        }

//        //根据媒体检索或上传命令ID，得到终端发送的媒体检索数据
//        public List<MediaItem> GetMeidaItem(int commandId)
//        {
//            string hsql = "from MediaItem where CommandId = ? ";
//            IList vr = BaseDao.query
//                (hsql, new object[]{commandId});
//            List<MediaItem> result = new List<MediaItem>();
//            foreach (MediaItem mi in vr)
//            {
//                result.Add(mi);
//            }
//            return result;
//        }

//        //查询终端参数
//        public List<TerminalParam> GetTermianlParam(string SimNo)
//        {
//            try
//            {
//                List<TerminalParam> result = new List<TerminalParam>();

//                string hql = "from TerminalParam where SimNo = ? ";
//                IList ls = BaseDao.query(hql, new object[] { SimNo });

//                foreach (TerminalParam tp in ls)
//                {
//                    result.Add(tp);
//                }

//                return result;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }

//        /// <summary>
//        /// 查询用户权限下所有的区域
//        /// </summary>
//        /// <returns></returns>
//        public List<MapArea> GetAreaList()
//        {
//            try
//            {
//                List<MapArea> result = new List<MapArea>();
//                List<int> depIdList = this.getDepIdList();
//                string hql = "from MapArea where  Deleted = false";

//                IList ls = BaseDao.query(hql);
//                foreach (MapArea tp in ls)
//                {
//                    result.Add(tp);
//                }

//                return result;
//            }
//            catch (Exception ex)
//            {
//                logger.Error(ex.Message, ex);
//                throw new FaultException(ex.Message);
//            }
//        }

//        public void Stop()
//        {
//        }


        
//    }
//}
