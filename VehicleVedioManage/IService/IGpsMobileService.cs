using VehicleVedioManage.BackManagement.Entity;
using VehicleVedioManage.BasicData.Entity;
using VehicleVedioManage.FenceManagement.Entity;
using VehicleVedioManage.ReportStatistics.Entity;
using VehicleVedioManage.Web.Models;
using VehicleVedioManage.Web.ViewModels;
using XCode.Membership;
using User = XCode.Membership.User;

namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// gps 手机服务
    /// </summary>
    public interface IGpsMobileService
    {
        /// <summary>
        /// 心跳
        /// </summary>
        /// <param name="userId"></param>
        void HeartBeatTest(int userId);
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        ClientUser Login(String UserName, String Password);
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        void UpdateUserPassword(int UserId, string Password);

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUser(int userId);
        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Role GetRole(int roleId);

        /// <summary>
        /// 得到用户列表
        /// </summary>
        /// <param name="qp"></param>
        /// <returns></returns>
        PageData<ClientUser> GetUserListByPage(QueryParam qp);
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<ClientRole> GetRoleList(int UserId);
        /// <summary>
        /// 得到上线率统计数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="TenantId"></param>
        /// <param name="DepId"></param>
        /// <returns></returns>
        List<OnlineStatic> GetOnlineStat(DateTime start, DateTime end, int TenantId, int DepId);

        /// <summary>
        /// 得到最新的报警
        /// </summary>
        /// <param name="StartDate"></param>
        /// <returns></returns>
        List<Alarm> GetNewAlarm(DateTime StartDate);
        /// <summary>
        /// 获取终端参数
        /// </summary>
        /// <param name="GpsId"></param>
        /// <returns></returns>
        List<TerminalParam> GetTerminalParam(int GpsId);
        /// <summary>
        /// 获得报警配置
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        List<AlarmConfig> GetAlarmConfig(int TenantId);

        /// <summary>
        /// 报警统计
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<AlarmStatic> GetAlarmStatic(QueryParam param);

        /// <summary>
        /// 下拉树控件节点数据
        /// </summary>
        /// <param name="queryId"></param>
        /// <returns></returns>
        
        List<NodeItem> GetNodeItemList(String queryId);
        /// <summary>
        /// 获取部门下的车辆
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="DepId"></param>
        /// <returns></returns>
        
        List<VehicleTreeNode> GetVehicleTreeNodes(int UserId, int DepId);
        //****************更新数据*****************************************

        /// <summary>
        /// 保存部门
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        
        Department SaveDepartment(Department dep);
        /// <summary>
        /// 保存车辆数据
        /// </summary>
        /// <param name="vd"></param>
        /// <returns></returns>
        
        Vehicle SaveVehicleData(Vehicle vd);
        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="cu"></param>
        
        void SaveClientUser(ClientUser cu);
        //处理报警记录
        
        void  ProcessAlarmRecord(int alarmId, string userName, string processedWay);
        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="cr"></param>
        
        void SaveClientRole(ClientRole cr);
        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="u"></param>
        
        void SaveUser(User u);

        /// <summary>
        /// 保存图层
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        
        MapLayer SaveMapLayer(MapLayer layer);

        /// <summary>
        /// 保存基础数据
        /// </summary>
        /// <param name="basicDatas"></param>
        
        void SaveBasicData(List<BasicInfo> basicDatas);

        /// <summary>
        /// 保存报警配置数据
        /// </summary>
        /// <param name="alarmList"></param>
        
        void SaveAlarmConfig(List<AlarmConfig> alarmList);

        /// <summary>
        /// 保存基础数据
        /// </summary>
        /// <param name="tc"></param>
        /// <returns></returns>
        
        TerminalCommand SaveTerminalCommand(TerminalCommand tc);
        /// <summary>
        /// 保存809指令
        /// </summary>
        /// <param name="tc"></param>
        /// <returns></returns>
        
        JT809Command SaveJT809Command(JT809Command tc);

        /// <summary>
        /// 保存电子围栏
        /// </summary>
        /// <param name="ec"></param>
        /// <returns></returns>
        
        MapArea SaveEnclosure(MapArea ec);

        //保存线路缓冲区
        //
        //void SaveLineBuffer(List<LineBufferPoint> lineBufferPoints);
        /// <summary>
        /// 保存电子围栏
        /// </summary>
        /// <param name="ec"></param>
        /// <param name="segs"></param>
        /// <returns></returns>
        
        MapArea SaveRoute(MapArea ec, List<LineSegment> segs);
        /// <summary>
        /// 绑定路线
        /// </summary>
        /// <param name="PlateNoList"></param>
        /// <param name="routeIdList"></param>
        
        void BindRoute(List<string> PlateNoList, string routeIdList);


        /// <summary>
        /// 绑定区域和车辆
        /// </summary>
        /// <param name="bindingList"></param>
        
        void BindTerminalWithArea(List<AreaBindingInfo> bindingList);

        //****************************分页查询**********************************

        /// <summary>
        /// 获取区域内gps实时数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        
        PageData<GPSRealData> GetGpsRealDataInArea(QueryParam param);
        /// <summary>
        /// 下拉框数据
        /// </summary>
        /// <param name="queryId"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        
        List<BasicInfo> GetDropDownList(String queryId, QueryParam param);

        /// <summary>
        /// 车辆列表查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        
        PageData<Vehicle> GetVehiclesByPage(QueryParam param);

        /// <summary>
        /// 围栏列表查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        
        PageData<MapArea> GetEnclosureByPage(QueryParam param);

        /// <summary>
        /// 围栏列表查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        
        PageData<AreaBindingInfo> GetAreaBindingInfoByPage(QueryParam param);

        /// <summary>
        /// 报警记录查询
        /// </summary>
        /// <param name="qp"></param>
        /// <returns></returns>
        PageData<AlarmRecord> GetAlarmList(QueryParam qp);

        /// <summary>
        /// 聚集报警记录查询
        /// </summary>
        /// <param name="qp"></param>
        /// <returns></returns>
        PageData<AlarmRecord> GetGatherInfo(QueryParam qp);
        /// <summary>
        /// 得到路线的所有路段
        /// </summary>
        /// <param name="EnclosureId"></param>
        /// <returns></returns>
        List<LineSegment> GetLineSegments(int EnclosureId);
        //得到路线的缓冲区的所有点
        //
        // List<LineBufferPoint> GetLineBuffer(int EnclosureId);
        /// <summary>
        /// 油量和里程统计
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        PageData<FuelConsumption> GetFuelConsumption(QueryParam param);
        /// <summary>
        /// 获取终端指令
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        PageData<TerminalCommand> GetTerminalCommandByPage(QueryParam param);
        /// <summary>
        /// 获取车辆照片
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        PageData<MediaItem> GetVehiclePhotoByPage(QueryParam param);
        /// <summary>
        /// 获取区域列表
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<MapArea> GetAreaList(int UserId);
        /// <summary>
        /// 获取电子围栏
        /// </summary>
        /// <param name="AreaId"></param>
        /// <returns></returns>
        MapArea GetEnclosure(int AreaId);
        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        List<FuncModel> GetFunctionList(int TenantId);
        /// <summary>
        /// 获取实时数据
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<GPSRealData> GetRealDatas(int UserId);
        /// <summary>
        /// 获取实时数据
        /// </summary>
        /// <param name="plateNo"></param>
        /// <returns></returns>
        GPSRealData GetRealData(String plateNo);
        /// <summary>
        /// 获取多媒体数据
        /// </summary>
        /// <param name="commandId"></param>
        /// <returns></returns>
        MediaItem GetMediaData(int commandId);
        /// <summary>
        /// 获取基础数据
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        List<BasicInfo> GetBasicData(int TenantId);

        /// <summary>
        /// 得到组织机构
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<Department> GetDepartments(int UserId);

        /// <summary>
        /// 得到车辆信息
        /// </summary>
        /// <param name="PlateNo"></param>
        /// <returns></returns>
        Vehicle GetVehicle(String PlateNo);

        /// <summary>
        /// 获取gps信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        PageData<GpsInfo> GetGpsInfoByPage(QueryParam param);
        //List<GpsInfo> GetVehicleRoutes(string PlateNo, DateTime start, DateTime end);

        /// <summary>
        /// 查询终端参数
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="GpsId"></param>
        /// <returns></returns>
        List<TerminalParam> GetTermianlParam(int UserId, string GpsId);
        /// <summary>
        /// 获取多媒体项
        /// </summary>
        /// <param name="commandId"></param>
        /// <returns></returns>
        List<MediaItem> GetMeidaItem(int commandId);

        /// <summary>
        /// 查询终端命令
        /// </summary>
        /// <param name="commandId"></param>
        /// <returns></returns>
        TerminalCommand GetTerminalCommand(int commandId);

        /// <summary>
        /// 查询新车记录仪采集数据
        /// </summary>
        /// <param name="commandId"></param>
        /// <returns></returns>
        VehicleRecord GetRecorderInfo(int commandId);

        /// <summary>
        /// 获取所有图层
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        List<MapLayer> GetMapLayers(int TenantId);

        
    }
}
