//using System.Collections;
//using System.Collections.Concurrent;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 车辆服务
//    /// </summary>
//    public class VehicleService : GpsNET.Service.IVehicleService
//    {
//        /// <summary>
//        /// ORM
//        /// </summary>
//        public IBaseDao BaseDao { get; set; }

//        /// <summary>
//        /// 部门服务
//        /// </summary>
//        public IDepartmentService DepartmentService { get; set; }
//        /// <summary>
//        ///  车辆映射
//        /// </summary>
//        public static ConcurrentDictionary<int, VehicleData> vehicleMap = new ConcurrentDictionary<int, VehicleData>();
//        /// <summary>
//        /// 实时数据
//        /// </summary>
//        public static ConcurrentDictionary<String, GPSRealData> realDataMap = new ConcurrentDictionary<String, GPSRealData>();
//        /// <summary>
//        /// 获取车辆数据
//        /// </summary>
//        /// <param name="vehicleId"></param>
//        /// <returns></returns>
//        public VehicleData getVehicleData(int vehicleId)
//        {
//            if (vehicleMap.ContainsKey(vehicleId))
//            {
//                return vehicleMap[vehicleId];
//            }
//            VehicleData vd = (VehicleData)BaseDao.load(typeof(VehicleData),
//                    vehicleId);
//            vehicleMap[vehicleId] = vd;
//            return vd;
//        }
//        /// <summary>
//        /// 根据车牌号获取车辆
//        /// </summary>
//        /// <param name="PlateNo"></param>
//        /// <returns></returns>
//        public VehicleData getVehicleByPlateNo(String PlateNo)
//        {
//            String hql = "from VehicleData v where v.PlateNo =  ? and Deleted = ?";

//            VehicleData v = (VehicleData)BaseDao.find(hql,
//                    new Object[] { PlateNo, false });
//            return v;
//        }
//        /// <summary>
//        /// 根据sim卡号获取车辆
//        /// </summary>
//        /// <param name="SimNo"></param>
//        /// <returns></returns>
//        public VehicleData getVehicleBySimNo(String SimNo)
//        {
//            String hql = "from VehicleData v where v.SimNo =  ? and Deleted = ?";

//            VehicleData v = (VehicleData)BaseDao.find(hql,
//                    new Object[] { SimNo, false });
//            return v;
//        }
//        /// <summary>
//        /// 获取终端
//        /// </summary>
//        /// <param name="terminalId"></param>
//        /// <returns></returns>
//        public TerminalInfo getTerminal(int terminalId)
//        {
//            return (TerminalInfo)BaseDao.load(typeof(TerminalInfo), terminalId);
//        }
//        /// <summary>
//        /// 根据终端编号获取终端
//        /// </summary>
//        /// <param name="terminalNo"></param>
//        /// <returns></returns>
//        public TerminalInfo getTerminalByTermNo(String terminalNo)
//        {
//            String hql = "from TerminalInfo where TermNo = ? and Deleted = ?";
//            return (TerminalInfo)BaseDao.find(hql, new Object[] { terminalNo, false });
//        }

//        /// <summary>
//        /// 查询车辆的车辆部门
//        /// </summary>
//        /// <param name="PlateNo"></param>
//        /// <returns></returns>
//        public Department getDepartmentByPlateNo(String PlateNo)
//        {
//            VehicleData vd = getVehicleData(PlateNo);
//            if (vd != null && vd.DepId > 0)
//            {
//                return DepartmentService.getDepartment(vd.DepId);
//            }
//            return null;
//        }
//        /// <summary>
//        /// 获取车辆数据
//        /// </summary>
//        /// <param name="PlateNo"></param>
//        /// <returns></returns>
//        public VehicleData getVehicleData(String PlateNo)
//        {
//            String hsql = "from VehicleData where PlateNo = ?";

//            VehicleData vd = (VehicleData)BaseDao.find(hsql, PlateNo);
//            return vd;
//        }

//        /// <summary>
//        /// 保存终端
//        /// </summary>
//        /// <param name="t"></param>
//        public void saveTerminal(TerminalInfo t)
//        {
//            String hsql = "from TerminalInfo where TermNo = ? and EntityId <> ? and Deleted = ? ";
//            TerminalInfo otherVd = (TerminalInfo)BaseDao.find(hsql,
//                    new Object[] { t.TermNo, t.EntityId, false });
//            if (otherVd != null)
//            {
//                String msg = "终端ID重复,无法保存!";
//                throw new Exception(msg);
//            }
//            this.BaseDao.saveOrUpdate(t);
//        }
//        /// <summary>
//        /// 假删除车辆
//        /// </summary>
//        /// <param name="vehicleId"></param>
//        public void delete(int vehicleId)
//        {
//            this.BaseDao.removeByFake(typeof(VehicleData), vehicleId);
//            String hsql = "from GPSRealData where vehicleId = ?";
//            GPSRealData rd = (GPSRealData)BaseDao.find(hsql, vehicleId);
//            if (rd != null)
//            {
//                BaseDao.delete(rd);
//            }
//        }

//        /// <summary>
//        /// 保存车辆信息
//        /// </summary>
//        /// <param name="vd"></param>
//        public void saveVehicleData(VehicleData vd)
//        {
//            String hsql = "from VehicleData where (PlateNo= ? or SimNo = ?) and EntityId <> ? and Deleted = ? ";
//            VehicleData otherVd = (VehicleData)BaseDao.find(hsql, new Object[] {
//                vd.PlateNo, vd.SimNo, vd.EntityId, false });
//            if (otherVd != null)
//            {
//                String msg = otherVd.PlateNo.Equals(vd.PlateNo) ? "车牌号重复,"
//                        : "";
//                msg += otherVd.SimNo.Equals(vd.SimNo) ? "卡号重复," : "";
//                msg += "无法保存!";
//                throw new Exception(msg);
//            }

//            if (vd.EntityId > 0)
//            {
//                hsql = "from GPSRealData where vehicleId = ?";
//                GPSRealData rd = (GPSRealData)BaseDao.find(hsql, vd.EntityId);
//                if (rd != null)
//                {
//                    if (vd.Deleted)
//                    {
//                        BaseDao.delete(rd);
//                    }
//                    else
//                    {
//                        rd.SimNo = (vd.SimNo);
//                        rd.PlateNo = (vd.PlateNo);
//                        this.BaseDao.saveOrUpdate(rd);
//                    }

//                }
//            }
//            this.BaseDao.saveOrUpdate(vd);
//            vehicleMap[vd.EntityId] = vd;
//        }
//        /// <summary>
//        /// 保存车辆数据
//        /// </summary>
//        /// <param name="vd"></param>
//        /// <param name="modifyRecordList"></param>
//        public void saveVehicleData(VehicleData vd, List<VehicleInfoModifyRecord> modifyRecordList)
//        {
//            String hsql = "from VehicleData where (PlateNo= ? or SimNo = ?) and EntityId <> ? and Deleted = ? ";
//            VehicleData otherVd = (VehicleData)BaseDao.find(hsql, new Object[] {
//                vd.PlateNo, vd.SimNo, vd.EntityId, false });
//            if (otherVd != null)
//            {
//                String msg = otherVd.PlateNo.Equals(vd.PlateNo) ? "车牌号重复,"
//                        : "";
//                msg += otherVd.SimNo.Equals(vd.SimNo) ? "卡号重复," : "";
//                msg += "无法保存!";
//                throw new Exception(msg);
//            }

//            if (vd.EntityId > 0)
//            {

//                hsql = "from GPSRealData where vehicleId = ?";
//                GPSRealData rd = (GPSRealData)BaseDao.find(hsql, vd.EntityId);
//                if (rd != null)
//                {
//                    if (vd.Deleted)
//                    {
//                        BaseDao.delete(rd);
//                    }
//                    else
//                    {
//                        rd.SimNo = (vd.SimNo);
//                        rd.PlateNo = (vd.PlateNo);
//                        this.BaseDao.saveOrUpdate(rd);
//                    }

//                }
//            }
//            this.BaseDao.saveOrUpdate(vd);
//            if (modifyRecordList.Count > 0)
//                this.BaseDao.saveOrUpdateAll(modifyRecordList);
//            vehicleMap[vd.EntityId] = vd;
//        }

//        /// <summary>
//        /// 根据部门id列表，查询出部门所辖车辆列表
//        /// </summary>
//        /// <param name="depIdList"></param>
//        /// <returns></returns>
//        public List<VehicleData> getVehicleListByDepId(List<int> depIdList)
//        {
//            String hql = "from VehicleData where depId in (:depIdList) and Deleted = 0 order by PlateNo";
//            if (depIdList.Count == 0)
//            {
//                depIdList.Add(0);
//            }
//            IList ls = BaseDao.queryByNamedParam(hql, "depIdList",
//                    depIdList.ToArray());
//            List<VehicleData> result = new List<VehicleData>();
//            foreach (Object o in ls)
//            {
//                result.Add((VehicleData)o);
//            }
//            return result;
//        }
//    }
//}
