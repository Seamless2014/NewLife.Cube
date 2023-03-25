using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using VehicleVedioManage.Enums;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.BasicData.Entity
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
        [BindColumn("VehicleID", "车辆编号", "Int32")]
        public Int32 VehicleID { get => _vehicleId; set { if (OnPropertyChanging("VehicleID", value)) { _vehicleId = value; OnPropertyChanged("VehicleID"); } } }

        private String _plateNo;
        /// <summary>车牌号</summary>
        [Category("基本信息")]
        [DisplayName("车牌号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(255)")]
        public String PlateNo { get => _plateNo; set { if (OnPropertyChanging("PlateNo", value)) { _plateNo = value; OnPropertyChanged("PlateNo"); } } }

        private Int32 _parameterID;
        /// <summary>车牌类型</summary>
        [Category("基本信息")]
        [DisplayName("车辆类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("ParameterID", "车辆类型", "Int32")]
        public Int32 ParameterID { get => _parameterID; set { if (OnPropertyChanging("ParameterID", value)) { _parameterID = value; OnPropertyChanged("ParameterID"); } } }

        private Int32 _plateColor;
        /// <summary>车牌颜色</summary>
        [Category("基本信息")]
        [DisplayName("车牌颜色")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("PlateColor", "车牌颜色", "Int32")]
        public Int32 PlateColor { get => _plateColor; set { if (OnPropertyChanging("PlateColor", value)) { _plateColor = value; OnPropertyChanged("PlateColor"); } } }


        private String _Driver;
        /// <summary>驾驶员</summary>
        [Category("车辆档案")]
        [DisplayName("驾驶员")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Driver", "驾驶员", "nvarchar(255)")]
        public String Driver { get => _Driver; set { if (OnPropertyChanging("Driver", value)) { _Driver = value; OnPropertyChanged("Driver"); } } }

        private Int32 _runStatus;
        /// <summary>车辆运行状态</summary>
        [Category("基本信息")]
        [DisplayName("车辆运行状态")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("RunStatus", "车辆运行状态", "Int32")]
        public Int32 RunStatus { get => _runStatus; set { if (OnPropertyChanging("RunStatus", value)) { _runStatus = value; OnPropertyChanged("RunStatus"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("基本信息")]
        [DisplayName("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private Int32 _tenantId;
        /// <summary>租户编号</summary>
        [Category("车辆档案")]
        [DisplayName("租户编号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantID", "租户编号", "int")]
        public Int32 TenantID { get => _tenantId; set { if (OnPropertyChanging("TenantID", value)) { _tenantId = value; OnPropertyChanged("TenantID"); } } }

        private DateTime _installDate;
        /// <summary>安装日期</summary>
        [Category("车辆档案")]
        [DisplayName("安装日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("InstallDate", "安装日期", "datetime", Precision = 0, Scale = 3)]
        public DateTime InstallDate { get => _installDate; set { if (OnPropertyChanging("InstallDate", value)) { _installDate = value; OnPropertyChanged("InstallDate"); } } }

        private String _simNo;
        /// <summary>Sim卡号</summary>
        [Category("基本信息")]
        [DisplayName("Sim卡号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("SimNo", "Sim卡号", "nvarchar(50)")]
        public String SimNo { get => _simNo; set { if (OnPropertyChanging("SimNo", value)) { _simNo = value; OnPropertyChanged("SimNo"); } } }

        private String _DriverMobile;
        /// <summary>驾驶员手机号</summary>
        [Category("车辆档案")]
        [DisplayName("驾驶员手机号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("DriverMobile", "驾驶员手机号", "nvarchar(50)")]
        public String DriverMobile { get => _DriverMobile; set { if (OnPropertyChanging("DriverMobile", value)) { _DriverMobile = value; OnPropertyChanged("DriverMobile"); } } }

        private DateTime _buyDate;
        /// <summary>购买日期</summary>
        [Category("车辆档案")]
        [DisplayName("购买日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("BuyDate", "购买日期", "datetime", Precision = 0, Scale = 3)]
        public DateTime BuyDate { get => _buyDate; set { if (OnPropertyChanging("BuyDate", value)) { _buyDate = value; OnPropertyChanged("BuyDate"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [Category("车辆档案")]
        [DisplayName("拥有者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "拥有者", "nvarchar(50)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private Int32 _departmentID;
        /// <summary>部门名称</summary>
        [Category("基本信息")]
        [DisplayName("部门名称")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("DepartmentID", "部门名称", "int")]
        public Int32 DepartmentID { get => _departmentID; set { if (OnPropertyChanging("DepartmentID", value)) { _departmentID = value; OnPropertyChanged("DepartmentID"); } } }

        private Int32 _industryID;
        /// <summary>行业</summary>
        [Category("基本信息")]
        [DisplayName("行业类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("IndustryID", "行业类型", "Int32")]
        public Int32 IndustryID { get => _industryID; set { if (OnPropertyChanging("IndustryID", value)) { _industryID = value; OnPropertyChanged("IndustryID"); } } }


        private String _useType;
        /// <summary>使用性质</summary>
        [Category("基本信息")]
        [DisplayName("使用性质")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UseType", "使用性质", "nvarchar(50)")]
        public String UseType { get => _useType; set { if (OnPropertyChanging("UseType", value)) { _useType = value; OnPropertyChanged("UseType"); } } }

        private Int32 _Region;
        /// <summary>区域</summary>
        [Category("基本信息")]
        [DisplayName("区域")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Region", "区域", "Int32")]
        public Int32 Region { get => _Region; set { if (OnPropertyChanging("Region", value)) { _Region = value; OnPropertyChanged("Region"); } } }

        private String _CreateUser;
        /// <summary>创建者</summary>
        [Category("扩展信息")]
        [DisplayName("创建者")]
        [Description("创建者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateUser", "创建者", "")]
        public String CreateUser { get => _CreateUser; set { if (OnPropertyChanging("CreateUser", value)) { _CreateUser = value; OnPropertyChanged("CreateUser"); } } }

        private Int32 _CreateUserID;
        /// <summary>创建人</summary>
        [Category("扩展信息")]
        [DisplayName("创建人")]
        [Description("创建人")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("CreateUserID", "创建人", "")]
        public Int32 CreateUserID { get => _CreateUserID; set { if (OnPropertyChanging("CreateUserID", value)) { _CreateUserID = value; OnPropertyChanged("CreateUserID"); } } }

        private String _CreateIP;
        /// <summary>创建地址</summary>
        [Category("扩展信息")]
        [DisplayName("创建地址")]
        [Description("创建地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateIP", "创建地址", "")]
        public String CreateIP { get => _CreateIP; set { if (OnPropertyChanging("CreateIP", value)) { _CreateIP = value; OnPropertyChanged("CreateIP"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "")]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _UpdateUser;
        /// <summary>更新者</summary>
        [Category("扩展信息")]
        [DisplayName("更新者")]
        [Description("更新者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateUser", "更新者", "")]
        public String UpdateUser { get => _UpdateUser; set { if (OnPropertyChanging("UpdateUser", value)) { _UpdateUser = value; OnPropertyChanged("UpdateUser"); } } }

        private Int32 _UpdateUserID;
        /// <summary>更新人</summary>
        [Category("扩展信息")]
        [DisplayName("更新人")]
        [Description("更新人")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("UpdateUserID", "更新人", "")]
        public Int32 UpdateUserID { get => _UpdateUserID; set { if (OnPropertyChanging("UpdateUserID", value)) { _UpdateUserID = value; OnPropertyChanged("UpdateUserID"); } } }

        private String _UpdateIP;
        /// <summary>更新地址</summary>
        [Category("扩展信息")]
        [DisplayName("更新地址")]
        [Description("更新地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateIP", "更新地址", "")]
        public String UpdateIP { get => _UpdateIP; set { if (OnPropertyChanging("UpdateIP", value)) { _UpdateIP = value; OnPropertyChanged("UpdateIP"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [Category("扩展信息")]
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("UpdateTime", "更新时间", "")]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Remark", "备注", "")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }
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
                    case "VehicleID": return _vehicleId;
                    case "PlateNo": return _plateNo;
                    case "ParameterID": return _parameterID;
                    case "PlateColor": return _plateColor;
                    case "Driver": return _Driver;
                    case "RunStatus": return _runStatus;
                    case "Deleted": return _Deleted;
                    case "TenantID": return _tenantId;
                    case "InstallDate": return _installDate;
                    case "SimNo": return _simNo;
                    case "BuyDate": return _buyDate;
                    case "Owner": return _Owner;
                    case "DepartmentID": return _departmentID;
                    case "UseType": return _useType;
                    case "IndustryID": return _industryID;
                    case "CreateUser": return _CreateUser;
                    case "CreateUserID": return _CreateUserID;
                    case "CreateIP": return _CreateIP;
                    case "CreateTime": return _CreateTime;
                    case "UpdateUser": return _UpdateUser;
                    case "UpdateUserID": return _UpdateUserID;
                    case "UpdateIP": return _UpdateIP;
                    case "UpdateTime": return _UpdateTime;
                    case "Remark": return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "VehicleID": _vehicleId = value.ToInt(); break;
                    case "PlateNo": _plateNo = Convert.ToString(value); break;
                    case "ParameterID": _parameterID = value.ToInt(); break;
                    case "PlateColor": _plateColor = value.ToInt(); break;
                    case "RunStatus": _runStatus = value.ToInt(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "TenantId": _tenantId = value.ToInt(); break;
                    case "SimNo": _simNo = Convert.ToString(value); break;
                    case "DriverMobile": _DriverMobile = Convert.ToString(value); break;
                    case "BuyDate": _buyDate = value.ToDateTime(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "DepartmentID": _departmentID = value.ToInt(); break;
                    case "UseType": _useType = Convert.ToString(value); break;
                    case "IndustryID": _industryID = value.ToInt(); break;
                    case "CreateUser": _CreateUser = Convert.ToString(value); break;
                    case "CreateUserID": _CreateUserID = value.ToInt(); break;
                    case "CreateIP": _CreateIP = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "UpdateUser": _UpdateUser = Convert.ToString(value); break;
                    case "UpdateUserID": _UpdateUserID = value.ToInt(); break;
                    case "UpdateIP": _UpdateIP = Convert.ToString(value); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
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
            public static readonly Field VehicleId = FindByName("VehicleID");

            /// <summary></summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary></summary>
            public static readonly Field ParameterID = FindByName("ParameterID");

            /// <summary></summary>
            public static readonly Field PlateColor = FindByName("PlateColor");

            /// <summary></summary>
            public static readonly Field Driver = FindByName("Driver");

            /// <summary></summary>
            public static readonly Field RunStatus = FindByName("RunStatus");

            /// <summary></summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary></summary>
            public static readonly Field tenantId = FindByName("TenantID");

            /// <summary></summary>
            public static readonly Field InstallDate = FindByName("InstallDate");

            /// <summary></summary>
            public static readonly Field SimNo = FindByName("SimNo");

            /// <summary></summary>
            public static readonly Field DriverMobile = FindByName("DriverMobile");

            /// <summary></summary>
            public static readonly Field BuyDate = FindByName("BuyDate");

            /// <summary></summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary></summary>
            public static readonly Field DepartmentID = FindByName("DepartmentID");

            /// <summary></summary>
            public static readonly Field UseType = FindByName("UseType");

            /// <summary></summary>
            public static readonly Field IndustryID = FindByName("IndustryID");

            /// <summary></summary>
            public static readonly Field IndustryTypeName = FindByName("IndustryTypeName");

            /// <summary></summary>
            public static readonly Field Region = FindByName("Region");

            /// <summary></summary>
            public static readonly Field DepartmentName = FindByName("DepartmentName");

            /// <summary>创建者</summary>
            public static readonly Field CreateUser = FindByName("CreateUser");

            /// <summary>创建人</summary>
            public static readonly Field CreateUserID = FindByName("CreateUserID");

            /// <summary>创建地址</summary>
            public static readonly Field CreateIP = FindByName("CreateIP");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>更新者</summary>
            public static readonly Field UpdateUser = FindByName("UpdateUser");

            /// <summary>更新人</summary>
            public static readonly Field UpdateUserID = FindByName("UpdateUserID");

            /// <summary>更新地址</summary>
            public static readonly Field UpdateIP = FindByName("UpdateIP");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得Vehicle字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String VehicleId = "VehicleID";

            /// <summary></summary>
            public const String PlateNo = "PlateNo";

            /// <summary></summary>
            public const String ParameterID = "ParameterID";

            /// <summary></summary>
            public const String PlateColor = "PlateColor";

            /// <summary></summary>
            public const String Driver = "Driver";

            /// <summary></summary>
            public const String RunStatus = "RunStatus";

            /// <summary></summary>
            public const String Deleted = "Deleted";

            /// <summary></summary>
            public const String TenantId = "TenantID";

            /// <summary></summary>
            public const String InstallDate = "InstallDate";

            /// <summary></summary>
            public const String SimNo = "SimNo";

            /// <summary></summary>
            public const String DriverMobile = "DriverMobile";

            /// <summary></summary>
            public const String BuyDate = "BuyDate";

            /// <summary></summary>
            public const String Owner = "Owner";

            /// <summary></summary>
            public const String DepartmentID = "DepartmentID";

            /// <summary></summary>
            public const String UseType = "UseType";

            /// <summary></summary>
            public const String IndustryID = "IndustryID";

            /// <summary></summary>
            public const String IndustryTypeName = "IndustryTypeName";

            /// <summary></summary>
            public const String Region = "Region";

            /// <summary></summary>
            public const String DepartmentName = "DepartmentName";

            /// <summary>创建者</summary>
            public const String CreateUser = "CreateUser";

            /// <summary>创建人</summary>
            public const String CreateUserID = "CreateUserID";

            /// <summary>创建地址</summary>
            public const String CreateIP = "CreateIP";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>更新者</summary>
            public const String UpdateUser = "UpdateUser";

            /// <summary>更新人</summary>
            public const String UpdateUserID = "UpdateUserID";

            /// <summary>更新地址</summary>
            public const String UpdateIP = "UpdateIP";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            /// <summary>备注</summary>
            public const String Remark = "Remark";
        }
        #endregion
    }
}