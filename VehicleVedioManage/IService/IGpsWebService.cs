using VehicleVedioManage.BackManagement.Entity;
using VehicleVedioManage.BasicData.Entity;
using VehicleVedioManage.FenceManagement.Entity;
using VehicleVedioManage.ReportStatistics.Entity;
using VehicleVedioManage.Web.Models;
using VehicleVedioManage.Web.ViewModels;
using XCode.Membership;

namespace VehicleVedioManage.IService
{
    /// <summary>
    /// gps web 服务
    /// </summary>
    public interface IGpsWebService
    {
        /// <summary>
        /// 心跳测试
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
        /// 设置地图中心
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <param name="zoom"></param>
        
        void SetMapCenter(double lng, double lat, int zoom);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="objType"></param>
        /// <param name="entityId"></param>
        
        void DeleteEntityById(String objType, int entityId);
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
        /// 根据车辆ID获取车辆绑定的主驾驶信息
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        
        DriverInfo GetMainDriverByVehicleId(int vehicleId);

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
        /// <param name="userId"></param>
        /// <param name="isAdmin"></param>
        /// <param name="StartDate"></param>
        /// <returns></returns>
        
        List<Alarm> GetNewAlarm(int userId, Boolean isAdmin, DateTime StartDate);

        /// <summary>
        /// 加载系统的报警设置
        /// </summary>
        /// <returns></returns>
        
        List<AlarmConfig> GetAlarmConfig();

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
        /// <returns></returns>
        
        List<VehicleTreeNode> GetVehicleTreeNodes();
        //****************更新数据*****************************************
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="te"></param>
        /// <returns></returns>
        
        RequestEntity SaveEntity(RequestEntity te);
        /// <summary>
        /// 获取报表模型
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        
        ReportModel GetReportModelByName(String Name);

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
        /// <summary>
        /// 处理报警记录
        /// </summary>
        /// <param name="alarmId"></param>
        /// <param name="processedState"></param>
        /// <param name="processedWay"></param>
        /// <param name="alarmTime"></param>
        
        void ProcessAlarmRecord(int alarmId, int processedState, string processedWay, DateTime alarmTime);
        /// <summary>
        /// 处理报警记录
        /// </summary>
        /// <param name="alarmIds"></param>
        /// <param name="processedState"></param>
        /// <param name="processedWay"></param>
        /// <param name="alarmTime"></param>
        
        void ProcessAlarmRecords(List<int> alarmIds, int processedState, string processedWay, DateTime
            alarmTime);
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
        /// 根据主键获取实体类
        /// </summary>
        /// <param name="type"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        
        RequestEntity GetEntityById(String type, int entityId);

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
        /// 保存电子围栏
        /// </summary>
        /// <param name="ec"></param>
        /// <returns></returns>
        
        MapArea SaveMapArea(MapArea ec);

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
        /// 分页查询
        /// 根据查询条件，查询数据库，并按分页要求返回查询结果，每行记录是存放在Dictionary当中
        /// </summary>
        /// <param name="qp"></param>
        /// <returns></returns>
        
        PageData<Dictionary<String, Object>> QueryListByPage(QueryParam qp);
        /// <summary>
        /// 根据查询条件，查询数据库，返回所有的查询结果，每行记录是存放在Dictionary当中
        /// </summary>
        /// <param name="qp"></param>
        /// <returns></returns>
        
        List<Dictionary<String, Object>> QueryList(QueryParam qp);

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
        
        PageData<MapArea> GetMapAreaByPage(QueryParam param);
        /// <summary>
        /// 分页查询gps历史轨迹数据
        /// </summary>
        /// <param name="param">查询参数</param>
        /// <returns>gps历史数据</returns>
        
        PageData<GpsInfo> GetGpsInfoByPage(QueryParam param);

        /// <summary>
        /// 查询gps历史轨迹数据
        /// </summary>
        /// <param name="param">查询参数</param>
        /// <returns>gps历史数据</returns>
        
        List<GpsInfo> GetGpsInfoList(QueryParam param);


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
        /// 上下线记录查询
        /// </summary>
        /// <param name="qp"></param>
        /// <returns></returns>
        
        PageData<OnlineRecord> GetOnlineRecord(QueryParam qp);

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
        /// 分页查询终端命令
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        
        PageData<TerminalCommand> GetTerminalCommandByPage(QueryParam param);

        /// <summary>
        /// 分页查询车辆定时上传的照片
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        
        PageData<MediaItem> GetVehiclePhotoByPage(QueryParam param);

        /// <summary>
        /// 部门分页查询
        /// </summary>
        /// <param name="qp"></param>
        /// <returns></returns>
        
        PageData<Department> GetDepartmentByPage(QueryParam qp);
        //***************************查询************************************************
        /// <summary>
        /// 电子围栏查询
        /// </summary>
        /// <returns></returns>
        
        List<MapArea> GetAreaList();
        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <returns></returns>
        
        List<FuncModel> GetFunctionList();
        /// <summary>
        /// 获取实时数据
        /// </summary>
        /// <returns></returns>
        
        List<GPSRealData> GetRealDatas();
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
        /// <returns></returns>
        
        List<BasicInfo> GetBasicData();
        /// <summary>
        /// 获取报表模型列表
        /// </summary>
        /// <returns></returns>
        
        List<ReportModel> GetReportModelList();

        /// <summary>
        /// 得到组织机构
        /// </summary>
        /// <returns></returns>
        
        List<Department> GetDepartments();

        /// <summary>
        /// 得到车辆信息
        /// </summary>
        /// <param name="PlateNo"></param>
        /// <returns></returns>
        
        Vehicle GetVehicle(String PlateNo);


        /// <summary>
        /// 查询终端参数
        /// </summary>
        /// <param name="SimNo"></param>
        /// <returns></returns>
        
        List<TerminalParam> GetTermianlParam(string SimNo);

        /// <summary>
        /// 根据媒体检索或上传命令ID，得到终端发送的媒体检索数据
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
        /// <returns></returns>
        
        List<MapLayer> GetMapLayers();
        /// <summary>
        /// 停止服务
        /// </summary>
        void Stop();
    }
}
