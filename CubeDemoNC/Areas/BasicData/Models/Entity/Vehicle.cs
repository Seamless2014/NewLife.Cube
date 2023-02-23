using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace NewLife.BasicData.Entity
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [BindTable("Vehicle", Description = "车辆信息", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class Vehicle
    {
        #region 属性
        private Int32 _vehicleId;
        /// <summary>车辆编号</summary>
        [Category("基本信息")]
        [DisplayName("车辆编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("vehicleId", "车辆编号", "Int32")]
        public Int32 vehicleId { get => _vehicleId; set { if (OnPropertyChanging("vehicleId", value)) { _vehicleId = value; OnPropertyChanged("vehicleId"); } } }

        private String _plateNo;
        /// <summary>车牌号</summary>
        [Category("基本信息")]
        [DisplayName("车牌号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("plateNo", "车牌号", "nvarchar(255)")]
        public String plateNo { get => _plateNo; set { if (OnPropertyChanging("plateNo", value)) { _plateNo = value; OnPropertyChanged("plateNo"); } } }

        private Int32 _vehicleType;
        /// <summary>车牌类型</summary>
        [Category("基本信息")]
        [DisplayName("车辆类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("vehicleType", "车辆类型", "Int32")]
        public Int32 vehicleType { get => _vehicleType; set { if (OnPropertyChanging("vehicleType", value)) { _vehicleType = value; OnPropertyChanged("vehicleType"); } } }

        private Int32 _plateColor;
        /// <summary>车牌颜色</summary>
        [Category("基本信息")]
        [DisplayName("车牌颜色")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("plateColor", "车牌颜色", "Int32")]
        public Int32 plateColor { get => _plateColor; set { if (OnPropertyChanging("plateColor", value)) { _plateColor = value; OnPropertyChanged("plateColor"); } } }

        private String _Monitor;
        /// <summary>监督员</summary>
        [Category("车辆档案")]
        [DisplayName("监督员")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Monitor", "监督员", "nvarchar(255)")]
        public String Monitor { get => _Monitor; set { if (OnPropertyChanging("Monitor", value)) { _Monitor = value; OnPropertyChanged("Monitor"); } } }

        private String _Driver;
        /// <summary>驾驶员</summary>
        [Category("车辆档案")]
        [DisplayName("驾驶员")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Driver", "驾驶员", "nvarchar(255)")]
        public String Driver { get => _Driver; set { if (OnPropertyChanging("Driver", value)) { _Driver = value; OnPropertyChanged("Driver"); } } }

        private Int32 _Status;
        /// <summary>服务状态</summary>
        [Category("服务信息")]
        [DisplayName("服务状态")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("status", "服务状态", "int32")]
        public Int32 Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private Int32 _runStatus;
        /// <summary>车辆运行状态</summary>
        [Category("基本信息")]
        [DisplayName("车辆运行状态")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("runStatus", "车辆运行状态", "Int32")]
        public Int32 runStatus { get => _runStatus; set { if (OnPropertyChanging("runStatus", value)) { _runStatus = value; OnPropertyChanged("runStatus"); } } }

        private Double _Total;
        /// <summary>服务总天数</summary>
        [Category("服务信息")]
        [DisplayName("总天数")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Total", "总天数", "float")]
        public Double Total { get => _Total; set { if (OnPropertyChanging("Total", value)) { _Total = value; OnPropertyChanged("Total"); } } }

        private Double _Remain;
        /// <summary>剩余天数</summary>
        [Category("服务信息")]
        [DisplayName("剩余天数")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Remain", "剩余天数", "float")]
        public Double Remain { get => _Remain; set { if (OnPropertyChanging("Remain", value)) { _Remain = value; OnPropertyChanged("Remain"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("基本信息")]
        [DisplayName("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private DateTime _CreateDate;
        /// <summary>创建时间</summary>
        [Category("基本信息")]
        [DisplayName("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateDate", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateDate { get => _CreateDate; set { if (OnPropertyChanging("CreateDate", value)) { _CreateDate = value; OnPropertyChanged("CreateDate"); } } }

        private Int32 _tenantId;
        /// <summary>租户编号</summary>
        [Category("服务信息")]
        [DisplayName("租户编号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("tenantId", "租户编号", "int")]
        public Int32 tenantId { get => _tenantId; set { if (OnPropertyChanging("tenantId", value)) { _tenantId = value; OnPropertyChanged("tenantId"); } } }

        private String _VideoDeviceId;
        /// <summary>视频设备编码</summary>
        [Category("车辆档案")]
        [DisplayName("视频设备编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("VideoDeviceId", "视频设备编码", "nvarchar(255)")]
        public String VideoDeviceId { get => _VideoDeviceId; set { if (OnPropertyChanging("VideoDeviceId", value)) { _VideoDeviceId = value; OnPropertyChanged("VideoDeviceId"); } } }

        private Int32 _SortId;
        /// <summary>排序</summary>
        [Category("基本信息")]
        [DisplayName("排序")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("SortId", "排序", "Int32")]
        public Int32 SortId { get => _SortId; set { if (OnPropertyChanging("SortId", value)) { _SortId = value; OnPropertyChanged("SortId"); } } }

        private String _VehicleDeviceType;
        /// <summary>车辆设备类型</summary>
        [Category("车辆档案")]
        [DisplayName("车辆设备类型")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("VehicleDeviceType", "车辆设备类型", "nvarchar(50)")]
        public String VehicleDeviceType { get => _VehicleDeviceType; set { if (OnPropertyChanging("VehicleDeviceType", value)) { _VehicleDeviceType = value; OnPropertyChanged("VehicleDeviceType"); } } }

        private Boolean _DvrOnline;
        /// <summary>行车记录仪在线</summary>
        [Category("基本信息")]
        [DisplayName("行车记录仪在线")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("DvrOnline", "行车记录仪在线", "bit")]
        public Boolean DvrOnline { get => _DvrOnline; set { if (OnPropertyChanging("DvrOnline", value)) { _DvrOnline = value; OnPropertyChanged("DvrOnline"); } } }

        private String _MotorID;
        /// <summary>车机编号</summary>
        [Category("车辆档案")]
        [DisplayName("车机编号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("MotorID", "车机编号", "nvarchar(50)")]
        public String MotorID { get => _MotorID; set { if (OnPropertyChanging("MotorID", value)) { _MotorID = value; OnPropertyChanged("MotorID"); } } }

        private DateTime _installDate;
        /// <summary>安装日期</summary>
        [Category("车辆档案")]
        [DisplayName("安装日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("installDate", "安装日期", "datetime", Precision = 0, Scale = 3)]
        public DateTime installDate { get => _installDate; set { if (OnPropertyChanging("installDate", value)) { _installDate = value; OnPropertyChanged("installDate"); } } }

        private String _simNo;
        /// <summary>Sim卡号</summary>
        [Category("基本信息")]
        [DisplayName("Sim卡号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("simNo", "Sim卡号", "nvarchar(50)")]
        public String simNo { get => _simNo; set { if (OnPropertyChanging("simNo", value)) { _simNo = value; OnPropertyChanged("simNo"); } } }

        private String _DVRCard;
        /// <summary>行车记录仪卡</summary>
        [Category("车辆档案")]
        [DisplayName("行车记录仪卡")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("DVRCard", "行车记录仪卡", "nvarchar(50)")]
        public String DVRCard { get => _DVRCard; set { if (OnPropertyChanging("DVRCard", value)) { _DVRCard = value; OnPropertyChanged("DVRCard"); } } }

        private String _DriverMobile;
        /// <summary>驾驶员手机号</summary>
        [Category("车辆档案")]
        [DisplayName("驾驶员手机号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("DriverMobile", "驾驶员手机号", "nvarchar(50)")]
        public String DriverMobile { get => _DriverMobile; set { if (OnPropertyChanging("DriverMobile", value)) { _DriverMobile = value; OnPropertyChanged("DriverMobile"); } } }

        private String _MonitorMobile;
        /// <summary>监督员手机号</summary>
        [Category("车辆档案")]
        [DisplayName("监督员手机号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("MonitorMobile", "监督员手机号", "nvarchar(50)")]
        public String MonitorMobile { get => _MonitorMobile; set { if (OnPropertyChanging("MonitorMobile", value)) { _MonitorMobile = value; OnPropertyChanged("MonitorMobile"); } } }

        private String _vehColor;
        /// <summary>车辆颜色</summary>
        [Category("基本信息")]
        [DisplayName("车辆颜色")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("vehColor", "车辆颜色", "nvarchar(50)")]
        public String vehColor { get => _vehColor; set { if (OnPropertyChanging("vehColor", value)) { _vehColor = value; OnPropertyChanged("vehColor"); } } }

        private String _operPermit;
        /// <summary>运营许可证</summary>
        [Category("车辆档案")]
        [DisplayName("运营许可证")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("operPermit", "运营许可证", "nvarchar(50)")]
        public String operPermit { get => _operPermit; set { if (OnPropertyChanging("operPermit", value)) { _operPermit = value; OnPropertyChanged("operPermit"); } } }

        private DateTime _LastCheckTime;
        /// <summary>最后审查时间</summary>
        [Category("车辆档案")]
        [DisplayName("最后审查时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("LastCheckTime", "最后审查时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime LastCheckTime { get => _LastCheckTime; set { if (OnPropertyChanging("LastCheckTime", value)) { _LastCheckTime = value; OnPropertyChanged("LastCheckTime"); } } }

        private DateTime _buyDate;
        /// <summary>购买日期</summary>
        [Category("车辆档案")]
        [DisplayName("购买日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("buyDate", "购买日期", "datetime", Precision = 0, Scale = 3)]
        public DateTime buyDate { get => _buyDate; set { if (OnPropertyChanging("buyDate", value)) { _buyDate = value; OnPropertyChanged("buyDate"); } } }

        private String _Vendor;
        /// <summary>卖主</summary>
        [Category("车辆档案")]
        [DisplayName("卖主")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("vendor", "卖主", "nvarchar(50)")]
        public String Vendor { get => _Vendor; set { if (OnPropertyChanging("Vendor", value)) { _Vendor = value; OnPropertyChanged("Vendor"); } } }

        private String _factoryNo;
        /// <summary>出厂编号</summary>
        [Category("车辆档案")]
        [DisplayName("出厂编号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("factoryNo", "出厂编号", "nvarchar(50)")]
        public String factoryNo { get => _factoryNo; set { if (OnPropertyChanging("factoryNo", value)) { _factoryNo = value; OnPropertyChanged("factoryNo"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [Category("车辆档案")]
        [DisplayName("拥有者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("owner", "拥有者", "nvarchar(50)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("基本信息")]
        [DisplayName("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("remark", "备注", "nvarchar(50)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Int32 _departmentID;
        /// <summary>部门编码</summary>
        [Category("基本信息")]
        [DisplayName("部门编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("DepartmentID", "部门编码", "int")]
        public Int32 DepartmentID { get => _departmentID; set { if (OnPropertyChanging("DepartmentID", value)) { _departmentID = value; OnPropertyChanged("DepartmentID"); } } }

        private String _useType;
        /// <summary>使用性质</summary>
        [Category("基本信息")]
        [DisplayName("使用性质")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("useType", "使用性质", "nvarchar(50)")]
        public String useType { get => _useType; set { if (OnPropertyChanging("useType", value)) { _useType = value; OnPropertyChanged("useType"); } } }

        private String _Industry;
        /// <summary>行业</summary>
        [Category("基本信息")]
        [DisplayName("行业")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("industry", "行业", "nvarchar(50)")]
        public String Industry { get => _Industry; set { if (OnPropertyChanging("Industry", value)) { _Industry = value; OnPropertyChanged("Industry"); } } }

        private String _Routes;
        /// <summary>路线</summary>
        [Category("车辆档案")]
        [DisplayName("路线")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("routes", "路线", "nvarchar(50)")]
        public String Routes { get => _Routes; set { if (OnPropertyChanging("Routes", value)) { _Routes = value; OnPropertyChanged("Routes"); } } }

        private Int32 _Region;
        /// <summary>区域</summary>
        [Category("基本信息")]
        [DisplayName("区域")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("region", "区域", "Int32")]
        public Int32 Region { get => _Region; set { if (OnPropertyChanging("Region", value)) { _Region = value; OnPropertyChanged("Region"); } } }

        private Int32 _termId;
        /// <summary>终端编号</summary>
        [Category("基本信息")]
        [DisplayName("终端编号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("termId", "终端编号", "int")]
        public Int32 termId { get => _termId; set { if (OnPropertyChanging("termId", value)) { _termId = value; OnPropertyChanged("termId"); } } }

        private DateTime _buyTime;
        /// <summary>购买日期</summary>
        [Category("车辆档案")]
        [DisplayName("购买日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("buyTime", "购买日期", "datetime", Precision = 0, Scale = 3)]
        public DateTime buyTime { get => _buyTime; set { if (OnPropertyChanging("buyTime", value)) { _buyTime = value; OnPropertyChanged("buyTime"); } } }

        private Int32 _memberId;
        /// <summary>成员编号</summary>
        [Category("车辆档案")]
        [DisplayName("成员编号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("memberId", "成员编号", "int")]
        public Int32 memberId { get => _memberId; set { if (OnPropertyChanging("memberId", value)) { _memberId = value; OnPropertyChanged("memberId"); } } }

        private DateTime _endDate;
        /// <summary>结束时间</summary>
        [Category("服务信息")]
        [DisplayName("服务结束时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("endDate", "服务结束时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime endDate { get => _endDate; set { if (OnPropertyChanging("endDate", value)) { _endDate = value; OnPropertyChanged("endDate"); } } }

        private DateTime _startDate;
        /// <summary>服务开始时间</summary>
        [Category("服务信息")]
        [DisplayName("服务开始时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("startDate", "服务开始时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime startDate { get => _startDate; set { if (OnPropertyChanging("startDate", value)) { _startDate = value; OnPropertyChanged("startDate"); } } }

        private String _Type;
        /// <summary>类型</summary>
        [Category("车辆档案")]
        [DisplayName("类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Type", "类型", "nvarchar(255)")]
        public String Type { get => _Type; set { if (OnPropertyChanging("Type", value)) { _Type = value; OnPropertyChanged("Type"); } } }

        private String _Unit;
        /// <summary>单位</summary>
        [Category("车辆档案")]
        [DisplayName("单位")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Unit", "单位", "nvarchar(255)")]
        public String Unit { get => _Unit; set { if (OnPropertyChanging("Unit", value)) { _Unit = value; OnPropertyChanged("Unit"); } } }

        private Double _Weight;
        /// <summary>重量</summary>
        [Category("车辆档案")]
        [DisplayName("重量")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Weight", "重量", "float")]
        public Double Weight { get => _Weight; set { if (OnPropertyChanging("Weight", value)) { _Weight = value; OnPropertyChanged("Weight"); } } }

        private Boolean _Authorize;
        /// <summary>授权</summary>
        [Category("服务信息")]
        [DisplayName("授权")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Authorize", "授权", "bit")]
        public Boolean Authorize { get => _Authorize; set { if (OnPropertyChanging("Authorize", value)) { _Authorize = value; OnPropertyChanged("Authorize"); } } }

        private String _departmentName;
        /// <summary>部门名称</summary>
        [Category("基本信息")]
        [DisplayName("部门名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("DepartmentName", "部门名称", "varchar(255)")]
        public String DepartmentName { get => _departmentName; set { if (OnPropertyChanging("DepartmentName", value)) { _departmentName = value; OnPropertyChanged("DepartmentName"); } } }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case "vehicleId": return _vehicleId;
                    case "plateNo": return _plateNo;
                    case "vehicleType": return _vehicleType;
                    case "plateColor": return _plateColor;
                    case "Monitor": return _Monitor;
                    case "Driver": return _Driver;
                    case "Status": return _Status;
                    case "runStatus": return _runStatus;
                    case "Total": return _Total;
                    case "Remain": return _Remain;
                    case "Deleted": return _Deleted;
                    case "CreateDate": return _CreateDate;
                    case "tenantId": return _tenantId;
                    case "VideoDeviceId": return _VideoDeviceId;
                    case "SortId": return _SortId;
                    case "VehicleDeviceType": return _VehicleDeviceType;
                    case "DvrOnline": return _DvrOnline;
                    case "MotorID": return _MotorID;
                    case "installDate": return _installDate;
                    case "simNo": return _simNo;
                    case "DVRCard": return _DVRCard;
                    case "DriverMobile": return _DriverMobile;
                    case "MonitorMobile": return _MonitorMobile;
                    case "vehColor": return _vehColor;
                    case "operPermit": return _operPermit;
                    case "LastCheckTime": return _LastCheckTime;
                    case "buyDate": return _buyDate;
                    case "Vendor": return _Vendor;
                    case "factoryNo": return _factoryNo;
                    case "Owner": return _Owner;
                    case "Remark": return _Remark;
                    case "DepartmentID": return _departmentID;
                    case "useType": return _useType;
                    case "Industry": return _Industry;
                    case "Routes": return _Routes;
                    case "Region": return _Region;
                    case "termId": return _termId;
                    case "buyTime": return _buyTime;
                    case "memberId": return _memberId;
                    case "endDate": return _endDate;
                    case "startDate": return _startDate;
                    case "Type": return _Type;
                    case "Unit": return _Unit;
                    case "Weight": return _Weight;
                    case "Authorize": return _Authorize;
                    case "DepartmentName": return _departmentName;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "vehicleId": _vehicleId = value.ToInt(); break;
                    case "plateNo": _plateNo = Convert.ToString(value); break;
                    case "vehicleType": _vehicleType = value.ToInt(); break;
                    case "plateColor": _plateColor = value.ToInt(); break;
                    case "Monitor": _Monitor = Convert.ToString(value); break;
                    case "Driver": _Driver = Convert.ToString(value); break;
                    case "Status": _Status = value.ToInt(); break;
                    case "runStatus": _runStatus = value.ToInt(); break;
                    case "Total": _Total = value.ToDouble(); break;
                    case "Remain": _Remain = value.ToDouble(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "CreateDate": _CreateDate = value.ToDateTime(); break;
                    case "tenantId": _tenantId = value.ToInt(); break;
                    case "VideoDeviceId": _VideoDeviceId = Convert.ToString(value); break;
                    case "SortId": _SortId = value.ToInt(); break;
                    case "VehicleDeviceType": _VehicleDeviceType = Convert.ToString(value); break;
                    case "DvrOnline": _DvrOnline = value.ToBoolean(); break;
                    case "MotorID": _MotorID = Convert.ToString(value); break;
                    case "installDate": _installDate = value.ToDateTime(); break;
                    case "simNo": _simNo = Convert.ToString(value); break;
                    case "DVRCard": _DVRCard = Convert.ToString(value); break;
                    case "DriverMobile": _DriverMobile = Convert.ToString(value); break;
                    case "MonitorMobile": _MonitorMobile = Convert.ToString(value); break;
                    case "vehColor": _vehColor = Convert.ToString(value); break;
                    case "operPermit": _operPermit = Convert.ToString(value); break;
                    case "LastCheckTime": _LastCheckTime = value.ToDateTime(); break;
                    case "buyDate": _buyDate = value.ToDateTime(); break;
                    case "Vendor": _Vendor = Convert.ToString(value); break;
                    case "factoryNo": _factoryNo = Convert.ToString(value); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "DepartmentID": _departmentID = value.ToInt(); break;
                    case "useType": _useType = Convert.ToString(value); break;
                    case "Industry": _Industry = Convert.ToString(value); break;
                    case "Routes": _Routes = Convert.ToString(value); break;
                    case "Region": _Region = value.ToInt(); break;
                    case "termId": _termId = value.ToInt(); break;
                    case "buyTime": _buyTime = value.ToDateTime(); break;
                    case "memberId": _memberId = value.ToInt(); break;
                    case "endDate": _endDate = value.ToDateTime(); break;
                    case "startDate": _startDate = value.ToDateTime(); break;
                    case "Type": _Type = Convert.ToString(value); break;
                    case "Unit": _Unit = Convert.ToString(value); break;
                    case "Weight": _Weight = value.ToDouble(); break;
                    case "Authorize": _Authorize = value.ToBoolean(); break;
                    case "DepartmentName": _departmentName = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Vehicle字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field vehicleId = FindByName("vehicleId");

            /// <summary></summary>
            public static readonly Field plateNo = FindByName("plateNo");

            /// <summary></summary>
            public static readonly Field vehicleType = FindByName("vehicleType");

            /// <summary></summary>
            public static readonly Field plateColor = FindByName("plateColor");

            /// <summary></summary>
            public static readonly Field Monitor = FindByName("Monitor");

            /// <summary></summary>
            public static readonly Field Driver = FindByName("Driver");

            /// <summary></summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary></summary>
            public static readonly Field runStatus = FindByName("runStatus");

            /// <summary></summary>
            public static readonly Field Total = FindByName("Total");

            /// <summary></summary>
            public static readonly Field Remain = FindByName("Remain");

            /// <summary></summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary></summary>
            public static readonly Field CreateDate = FindByName("CreateDate");

            /// <summary></summary>
            public static readonly Field tenantId = FindByName("tenantId");

            /// <summary></summary>
            public static readonly Field VideoDeviceId = FindByName("VideoDeviceId");

            /// <summary></summary>
            public static readonly Field SortId = FindByName("SortId");

            /// <summary></summary>
            public static readonly Field VehicleDeviceType = FindByName("VehicleDeviceType");

            /// <summary></summary>
            public static readonly Field DvrOnline = FindByName("DvrOnline");

            /// <summary></summary>
            public static readonly Field MotorID = FindByName("MotorID");

            /// <summary></summary>
            public static readonly Field installDate = FindByName("installDate");

            /// <summary></summary>
            public static readonly Field simNo = FindByName("simNo");

            /// <summary></summary>
            public static readonly Field DVRCard = FindByName("DVRCard");

            /// <summary></summary>
            public static readonly Field DriverMobile = FindByName("DriverMobile");

            /// <summary></summary>
            public static readonly Field MonitorMobile = FindByName("MonitorMobile");

            /// <summary></summary>
            public static readonly Field vehColor = FindByName("vehColor");

            /// <summary></summary>
            public static readonly Field operPermit = FindByName("operPermit");

            /// <summary></summary>
            public static readonly Field LastCheckTime = FindByName("LastCheckTime");

            /// <summary></summary>
            public static readonly Field buyDate = FindByName("buyDate");

            /// <summary></summary>
            public static readonly Field Vendor = FindByName("Vendor");

            /// <summary></summary>
            public static readonly Field factoryNo = FindByName("factoryNo");

            /// <summary></summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary></summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary></summary>
            public static readonly Field DepartmentID = FindByName("DepartmentID");

            /// <summary></summary>
            public static readonly Field useType = FindByName("useType");

            /// <summary></summary>
            public static readonly Field Industry = FindByName("Industry");

            /// <summary></summary>
            public static readonly Field Routes = FindByName("Routes");

            /// <summary></summary>
            public static readonly Field Region = FindByName("Region");

            /// <summary></summary>
            public static readonly Field termId = FindByName("termId");

            /// <summary></summary>
            public static readonly Field buyTime = FindByName("buyTime");

            /// <summary></summary>
            public static readonly Field memberId = FindByName("memberId");

            /// <summary></summary>
            public static readonly Field endDate = FindByName("endDate");

            /// <summary></summary>
            public static readonly Field startDate = FindByName("startDate");

            /// <summary></summary>
            public static readonly Field Type = FindByName("Type");

            /// <summary></summary>
            public static readonly Field Unit = FindByName("Unit");

            /// <summary></summary>
            public static readonly Field Weight = FindByName("Weight");

            /// <summary></summary>
            public static readonly Field Authorize = FindByName("Authorize");

            /// <summary></summary>
            public static readonly Field DepartmentName = FindByName("DepartmentName");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得Vehicle字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String vehicleId = "vehicleId";

            /// <summary></summary>
            public const String plateNo = "plateNo";

            /// <summary></summary>
            public const String vehicleType = "vehicleType";

            /// <summary></summary>
            public const String plateColor = "plateColor";

            /// <summary></summary>
            public const String Monitor = "Monitor";

            /// <summary></summary>
            public const String Driver = "Driver";

            /// <summary></summary>
            public const String Status = "Status";

            /// <summary></summary>
            public const String runStatus = "runStatus";

            /// <summary></summary>
            public const String Total = "Total";

            /// <summary></summary>
            public const String Remain = "Remain";

            /// <summary></summary>
            public const String Deleted = "Deleted";

            /// <summary></summary>
            public const String CreateDate = "CreateDate";

            /// <summary></summary>
            public const String tenantId = "tenantId";

            /// <summary></summary>
            public const String VideoDeviceId = "VideoDeviceId";

            /// <summary></summary>
            public const String SortId = "SortId";

            /// <summary></summary>
            public const String VehicleDeviceType = "VehicleDeviceType";

            /// <summary></summary>
            public const String DvrOnline = "DvrOnline";

            /// <summary></summary>
            public const String MotorID = "MotorID";

            /// <summary></summary>
            public const String installDate = "installDate";

            /// <summary></summary>
            public const String simNo = "simNo";

            /// <summary></summary>
            public const String DVRCard = "DVRCard";

            /// <summary></summary>
            public const String DriverMobile = "DriverMobile";

            /// <summary></summary>
            public const String MonitorMobile = "MonitorMobile";

            /// <summary></summary>
            public const String vehColor = "vehColor";

            /// <summary></summary>
            public const String operPermit = "operPermit";

            /// <summary></summary>
            public const String LastCheckTime = "LastCheckTime";

            /// <summary></summary>
            public const String buyDate = "buyDate";

            /// <summary></summary>
            public const String Vendor = "Vendor";

            /// <summary></summary>
            public const String factoryNo = "factoryNo";

            /// <summary></summary>
            public const String Owner = "Owner";

            /// <summary></summary>
            public const String Remark = "Remark";

            /// <summary></summary>
            public const String DepartmentID = "DepartmentID";

            /// <summary></summary>
            public const String useType = "useType";

            /// <summary></summary>
            public const String Industry = "Industry";

            /// <summary></summary>
            public const String Routes = "Routes";

            /// <summary></summary>
            public const String Region = "Region";

            /// <summary></summary>
            public const String termId = "termId";

            /// <summary></summary>
            public const String buyTime = "buyTime";

            /// <summary></summary>
            public const String memberId = "memberId";

            /// <summary></summary>
            public const String endDate = "endDate";

            /// <summary></summary>
            public const String startDate = "startDate";

            /// <summary></summary>
            public const String Type = "Type";

            /// <summary></summary>
            public const String Unit = "Unit";

            /// <summary></summary>
            public const String Weight = "Weight";

            /// <summary></summary>
            public const String Authorize = "Authorize";

            /// <summary></summary>
            public const String DepartmentName = "DepartmentName";
        }
        #endregion
    }
}