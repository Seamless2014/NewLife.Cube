using System.Collections;
using NewLife.Log;
using VehicleVedioManage.ReportStatistics.Entity;
using VehicleVedioManage.Utility.Extends;
using VehicleVedioManage.Web.IService;
using XCode;
using XCode.Membership;

namespace VehicleVedioManage.Web.Service
{
    /// <summary>
    /// 定时统计服务
    /// </summary>
    public class StatisticService : IStatisticService
    {
        /// <summary>
        /// 查询服务
        /// </summary>
        public IQueryService QueryService { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        private readonly ITracer tracer;
        /// <summary>
        /// 油量变化的最大值,单位升
        /// </summary>
        public double MaxGas { get; set; }

        public StatisticService(IQueryService queryService, String userName, ITracer tracer, Double maxGas)
        {
            QueryService = queryService;
            UserName = userName;
            this.tracer = tracer;
            MaxGas = maxGas;
        }


        //protected override void ExecuteInternal(JobExecutionContext context)
        //{
        //    string msg = string.Format("{0}: 回家吃饭时间, 姓名: {1}, 下次吃饭时间 {2}",
        //        DateTime.Now, UserName,
        //        context.NextFireTimeUtc.Value.ToLocalTime());

        //    Console.WriteLine(msg);
        //}

        /// <summary>
        /// 如果不存在创建表
        /// </summary>
        public void createTableIfNotExists()
        {
            try
            {
                for (int m = 0; m < 4; m++)
                {
                    String nextDay = DateTime.Now.AddDays(m + 1).ToString("yyyyMMdd");
                    String tableName = "gpsInfo"
                            + nextDay;

                    QueryService.createGpsInfoTableIsNotExist(tableName);
                }

                String nextMonth = DateTime.Now.AddMonths(1).ToString("yyyyMM");
                //每月创建一个报警记录表
                String tableName2 = "newAlarm"
                        + nextMonth;
                QueryService.createNewAlarmTableIfNotExist(tableName2);
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message, ex);
            }
        }
        /// <summary>
        /// 获取最新的里程数据
        /// </summary>
        /// <param name="PlateNo"></param>
        /// <returns></returns>
        private GpsMileage GetLastMileageData(string PlateNo)
        {
            var gm = GpsMileage.FindByPlateNo(PlateNo);

            if (gm == null)
            {
                gm = new GpsMileage();
                gm.PlateNo = PlateNo;
            }
            return gm;
        }
        //每小时统计一次
        public void StaticByHour()
        {
            IList<GPSRealData> result = null;
            try
            {
                var where = new WhereExpression();
                result = GPSRealData.FindAllBy(where);
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message+System.Environment.NewLine+ex.StackTrace,ex);
                return;
            }
            var exp = new WhereExpression();
            IList<GpsMileage> gmList =GpsMileage.FindAllGpsMileage(exp);
            Hashtable gpsMileageMap = new Hashtable();
            foreach (GpsMileage gm in gmList)
            {
                gpsMileageMap[gm.PlateNo] = gm;
            }

            tracer.NewSpan("**********************static by hour");
            List<GpsMileage> alGas = new List<GpsMileage>();
            List<FuelConsumption> fuelConsumptions = new List<FuelConsumption>();
            foreach (GPSRealData rd in result)
            {
                try
                {
                    GpsMileage gm = (GpsMileage)gpsMileageMap[rd.PlateNo];
                    if (gm == null)
                    {
                        if (gm == null)
                        {
                            gm = new GpsMileage();
                            gm.PlateNo = rd.PlateNo;
                        }
                    }
                    FuelConsumption fc = new FuelConsumption();
                    fc.PlateNo = rd.PlateNo;
                    fc.Mileage1 = (decimal)gm.MileageLastHour;
                    fc.Mileage2 = (decimal)rd.Mileage;
                    fc.Gas1 = (decimal)gm.GasLastHour;
                    fc.Gas2 = (decimal)rd.Gas;
                    fc.Mileage = fc.Mileage2 - fc.Mileage1;
                    fc.Gas = fc.Gas2 - fc.Gas1;
                    fc.StatisticsDate = DateTime.Now;
                    fc.Hour = DateTime.Now.Hour;
                    fc.IntervalType = FuelConsumptionExtend.STATIC_BY_HOUR; //按小时统计
                    fuelConsumptions.Add(fc);
                    gm.MileageLastHour = rd.Mileage;
                    gm.GasLastHour = rd.Gas;
                    alGas.Add(gm);
                    if (alGas.Count > 10)
                    {
                        fuelConsumptions.Insert();
                        fuelConsumptions.Clear();
                        alGas.Insert();
                        alGas.Clear();
                    }
                }
                catch (Exception ex)
                {
                    tracer.NewError(ex.Message+System.Environment.NewLine+ex.StackTrace,ex);
                }

            }
        }
        /// <summary>
        /// 每天统计一次
        /// </summary>
        public void StaticByDay()
        {
            IList<GPSRealData> result = null;
            try
            {
                var where = new WhereExpression();
                result = GPSRealData.FindAllBy(where);
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message + System.Environment.NewLine + ex.StackTrace, ex);
                return;
            }

            //logger.Info("**********************static by hour");
            List<GpsMileage> alGas = new List<GpsMileage>();
            List<FuelConsumption> fuelConsumptions = new List<FuelConsumption>();
            foreach (GPSRealData rd in result)
            {
                try
                {
                    GpsMileage gm = GetLastMileageData(rd.PlateNo);
                    FuelConsumption fc = new FuelConsumption();
                    fc.PlateNo = rd.PlateNo;
                    fc.Mileage2 = (Decimal)rd.Mileage;
                    fc.Mileage1 = (Decimal)gm.MileageLastDay;
                    fc.Gas2 = (Decimal)rd.Gas;
                    fc.Gas1 = (Decimal)gm.GasLastDay;
                    fc.Mileage = fc.Mileage2 - fc.Mileage1;
                    fc.Gas = fc.Gas2 - fc.Gas1;
                    fc.StatisticsDate = DateTime.Now;
                    fc.Hour = DateTime.Now.Hour;
                    fc.IntervalType = FuelConsumptionExtend.STATIC_BY_DAY; //按天统计
                    fuelConsumptions.Add(fc);
                    gm.MileageLastDay = rd.Mileage;
                    gm.GasLastDay = rd.Gas;
                    alGas.Add(gm);
                    if (alGas.Count > 10)
                    {
                        alGas.Insert();
                        alGas.Clear();
                        fuelConsumptions.Insert();
                        fuelConsumptions.Clear();
                    }
                }
                catch (Exception ex)
                {
                    tracer.NewError(ex.Message + System.Environment.NewLine + ex.StackTrace, ex);
                }

            }

        }
        /// <summary>
        /// 五分钟记录一次油量记录，每五分钟比较一次油量变化
        /// </summary>
        public void StaticByMinute()
        {
            IList<GPSRealData> result = null;
            try
            {
                var where = new WhereExpression();
                result = GPSRealData.FindAllBy(where);
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message + System.Environment.NewLine + ex.StackTrace, ex);
                return;
            }
            //logger.Info("static by minute");
            List<GpsMileage> alGas = new List<GpsMileage>();
            List<FuelChangeRecord> fuelConsumptions = new List<FuelChangeRecord>();
            List<FuelRecord> fuelRecords = new List<FuelRecord>();
            foreach (GPSRealData rd in result)
            {
                GpsMileage gm = GetLastMileageData(rd.PlateNo);
                double changeGas = rd.Gas - gm.GasLastComp;
                //如果油量出现剧烈变化的时候，就记录到油量变化表当中
                try
                {
                    if (changeGas >= MaxGas)
                    {
                        FuelChangeRecord fcr = new FuelChangeRecord();

                        fcr.PlateNo = rd.PlateNo;
                        fcr.Latitude = rd.Latitude;
                        fcr.Longitude = rd.Longitude;
                        fcr.Mileage = rd.Mileage;
                        fcr.HappenTime = rd.SendTime;
                        fcr.Fuel = changeGas;
                        fcr.Location = rd.Location;
                        fuelConsumptions.Add(fcr);
                    }
                    //如果油量发生了变化，就更新到LastComp字段里.
                    if (gm.GasLastComp != rd.Gas || gm.MileageLastComp != rd.Mileage)
                    {
                        gm.LastCompTime = DateTime.Now;
                        gm.GasLastComp = rd.Gas;
                        gm.MileageLastComp = rd.Mileage;
                        //BaseDao.saveOrUpdate(gm);
                        alGas.Add(gm);
                    }

                    FuelRecord vi = new FuelRecord();
                    vi.VehicleId = rd.VehicleId;
                    vi.Mileage = rd.Mileage;
                    vi.Gas = rd.Gas;
                    vi.Latitude = rd.Latitude;
                    vi.Longitude = rd.Longitude;
                    vi.SendTime = rd.SendTime;
                    vi.RecordVelocity = rd.RecordVelocity;
                    vi.Velocity = rd.Velocity;
                    vi.Location = rd.Location;
                    vi.Direction = rd.Direction;
                    vi.Status = "" + rd.Status;
                    vi.AlarmState = "" + rd.AlarmState;
                    fuelRecords.Add(vi);
                    alGas.Insert();
                    fuelRecords.Insert();
                    fuelConsumptions.Insert();
                    alGas.Clear();
                    fuelConsumptions.Clear();
                    fuelRecords.Clear();
                }
                catch (Exception ex)
                {
                    tracer.NewError(ex.Message + System.Environment.NewLine + ex.StackTrace, ex);
                }

            }
        }
        /// <summary>
        /// 统计上线率,在quartz.xml文件中定时配置，每小时统计一次
        /// </summary>
        public void StaticOnlineRate()
        {
            tracer.NewSpan("统计上线率 by hour");
            List<OnlineStatic> result = new List<OnlineStatic>();
            Hashtable parameters = new Hashtable();

            Hashtable onlineMap = new Hashtable();
            try
            {
                IList<Department> departments = Department.Search(-1,null,null,null,null);

                //Dictionary<int, Department> departmentMap = new Dictionary<int, Department>();
                foreach (Department dep in departments)
                {
                    OnlineStatic rc = new OnlineStatic();
                    rc.DepId = dep.ID;
                    rc.StatisticDate = DateTime.Now;
                    rc.ParentDepId = dep.ParentID;
                    onlineMap[rc.DepId] = rc;
                    //departmentMap[rc.DepId] = dep;
                }
                /**
                 * 统计所有部门的上线率
                 */
                OnlineStatic rootStatic = new OnlineStatic();
                rootStatic.DepId = 0;
                rootStatic.StatisticDate = DateTime.Now;
                rootStatic.ParentDepId = -1;
                onlineMap[rootStatic.DepId] = rootStatic;
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message + System.Environment.NewLine + ex.StackTrace, ex);
            }

            //查询基层车管部门的上线率
            try
            {
                IList il = QueryService.QueryForList("selectOnlineRate", parameters);
                foreach (Hashtable ht in il)
                {
                    int DepId = (int)ht["DepId"];
                    if (onlineMap.ContainsKey(DepId))
                    {
                        OnlineStatic rc = (OnlineStatic)onlineMap[DepId];
                        while (rc != null)
                        {
                            rc.OnlineNum += (int)ht["OnlineNum"];
                            rc.VehicleNum += (int)ht["VehicleNum"];
                            if (rc.VehicleNum > 0)
                                rc.OnlineRate = (Decimal)((100.00 * rc.OnlineNum) / rc.VehicleNum);

                            if (rc.ParentDepId != DepId)
                                //对上级部门进行累计运算
                                rc = (OnlineStatic)onlineMap[rc.ParentDepId];
                            else
                                rc = null;
                        }
                    }
                }
                if (onlineMap.Values != null)
                {
                    IList<OnlineStatic> onlineStatic = onlineMap.Values as IList<OnlineStatic>;
                    onlineStatic.Insert();
                }
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message + System.Environment.NewLine + ex.StackTrace, ex);
            }
        }

        public void StaticByMonth() => throw new NotImplementedException();
        public void StaticByYear() => throw new NotImplementedException();
    }
}
