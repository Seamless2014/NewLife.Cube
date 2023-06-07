using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.BasicData.Entity
{
    /// <summary>车辆信息.车辆基本信息</summary>
    [Serializable]
    [DataObject]
    [Description("车辆信息.车辆基本信息")]
    [BindIndex("IU_Vehicle_PlateNo", true, "PlateNo")]
    [BindIndex("IX_Vehicle_DepartmentName_PlateNo", false, "DepartmentName,PlateNo")]
    [BindIndex("IX_Vehicle_SimNo", false, "SimNo")]
    [BindTable("Vehicle", Description = "车辆信息.车辆基本信息", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class Vehicle
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "编号", "")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("PlateNo", "车牌号", "", Master = true)]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private Int32 _VehicleType;
        /// <summary>车辆类型</summary>
        [DisplayName("车辆类型")]
        [Description("车辆类型")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("VehicleTypeCode", "车辆类型", "")]
        public Int32 VehicleTypeCode { get => _VehicleType; set { if (OnPropertyChanging("VehicleTypeCode", value)) { _VehicleType = value; OnPropertyChanged("VehicleTypeCode"); } } }

        private Int32 _PlateColor;
        /// <summary>车牌颜色</summary>
        [DisplayName("车牌颜色")]
        [Description("车牌颜色")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("PlateColorCode", "车牌颜色", "")]
        public Int32 PlateColorCode { get => _PlateColor; set { if (OnPropertyChanging("PlateColorCode", value)) { _PlateColor = value; OnPropertyChanged("PlateColorCode"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("扩展信息")]
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private Int32 _TenantId;
        /// <summary>租户编号</summary>
        [Category("扩展信息")]
        [DisplayName("租户编号")]
        [Description("租户编号")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TenantId", "租户编号", "")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private DateTime _InstallDate;
        /// <summary>安装日期</summary>
        [DisplayName("安装日期")]
        [Description("安装日期")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("InstallDate", "安装日期", "", Precision = 0, Scale = 3)]
        public DateTime InstallDate { get => _InstallDate; set { if (OnPropertyChanging("InstallDate", value)) { _InstallDate = value; OnPropertyChanged("InstallDate"); } } }

        private String _SimNo;
        /// <summary>Sim卡号</summary>
        [DisplayName("Sim卡号")]
        [Description("Sim卡号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("SimNo", "Sim卡号", "")]
        public String SimNo { get => _SimNo; set { if (OnPropertyChanging("SimNo", value)) { _SimNo = value; OnPropertyChanged("SimNo"); } } }

        private String _Driver;
        /// <summary>驾驶员</summary>
        [DisplayName("驾驶员")]
        [Description("驾驶员")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Driver", "驾驶员", "")]
        public String Driver { get => _Driver; set { if (OnPropertyChanging("Driver", value)) { _Driver = value; OnPropertyChanged("Driver"); } } }

        private Int32 _DepartmentID;
        /// <summary>部门编码</summary>
        [DisplayName("部门编码")]
        [Description("部门编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("DepartmentID", "部门编码", "")]
        public Int32 DepartmentID { get => _DepartmentID; set { if (OnPropertyChanging("DepartmentID", value)) { _DepartmentID = value; OnPropertyChanged("DepartmentID"); } } }

        private Int32 _Region;
        /// <summary>区域</summary>
        [DisplayName("区域")]
        [Description("区域")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Region", "区域", "")]
        public Int32 Region { get => _Region; set { if (OnPropertyChanging("Region", value)) { _Region = value; OnPropertyChanged("Region"); } } }

        private Int32 _Industry;
        /// <summary>行业</summary>
        [DisplayName("行业")]
        [Description("行业")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Industry", "行业", "")]
        public Int32 Industry { get => _Industry; set { if (OnPropertyChanging("Industry", value)) { _Industry = value; OnPropertyChanged("Industry"); } } }

        private String _PlateformId;
        /// <summary>平台编码</summary>
        [DisplayName("平台编码")]
        [Description("平台编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("PlateformId", "平台编码", "varchar(255)")]
        public String PlateformId { get => _PlateformId; set { if (OnPropertyChanging("PlateformId", value)) { _PlateformId = value; OnPropertyChanged("PlateformId"); } } }

        private String _TerminalId;
        /// <summary>终端编码</summary>
        [DisplayName("终端编码")]
        [Description("终端编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("TerminalId", "终端编码", "varchar(255)")]
        public String TerminalId { get => _TerminalId; set { if (OnPropertyChanging("TerminalId", value)) { _TerminalId = value; OnPropertyChanged("TerminalId"); } } }

        private String _TerminalModel;
        /// <summary>终端型号</summary>
        [DisplayName("终端型号")]
        [Description("终端型号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("TerminalModel", "终端型号", "varchar(255)")]
        public String TerminalModel { get => _TerminalModel; set { if (OnPropertyChanging("TerminalModel", value)) { _TerminalModel = value; OnPropertyChanged("TerminalModel"); } } }

        private String _TerminalVendorId;
        /// <summary>终端供应商编码</summary>
        [DisplayName("终端供应商编码")]
        [Description("终端供应商编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("TerminalVendorId", "终端供应商编码", "varchar(255)")]
        public String TerminalVendorId { get => _TerminalVendorId; set { if (OnPropertyChanging("TerminalVendorId", value)) { _TerminalVendorId = value; OnPropertyChanged("TerminalVendorId"); } } }

        private String _DriverMobile;
        /// <summary>驾驶员手机号</summary>
        [DisplayName("驾驶员手机号")]
        [Description("驾驶员手机号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("DriverMobile", "驾驶员手机号", "")]
        public String DriverMobile { get => _DriverMobile; set { if (OnPropertyChanging("DriverMobile", value)) { _DriverMobile = value; OnPropertyChanged("DriverMobile"); } } }

        private DateTime _BuyDate;
        /// <summary>购买日期</summary>
        [DisplayName("购买日期")]
        [Description("购买日期")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("BuyDate", "购买日期", "", Precision = 0, Scale = 3)]
        public DateTime BuyDate { get => _BuyDate; set { if (OnPropertyChanging("BuyDate", value)) { _BuyDate = value; OnPropertyChanged("BuyDate"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [Category("扩展信息")]
        [DisplayName("拥有者")]
        [Description("拥有者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "拥有者", "")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

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
        [DataObjectField(false, false, true, 0)]
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
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
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
        [DataObjectField(false, false, true, 0)]
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
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("UpdateTime", "更新时间", "", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Remark", "备注", "")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Int32 _RunStatusCode;
        /// <summary>运行状态</summary>
        [DisplayName("运行状态")]
        [Description("运行状态")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("RunStatusCode", "运行状态", "")]
        public Int32 RunStatusCode { get => _RunStatusCode; set { if (OnPropertyChanging("RunStatusCode", value)) { _RunStatusCode = value; OnPropertyChanged("RunStatusCode"); } } }

        private String _UseTypeCode;
        /// <summary>使用性质</summary>
        [DisplayName("使用性质")]
        [Description("使用性质")]
        [DataObjectField(false, false, true, 25)]
        [BindColumn("UseTypeCode", "使用性质", "")]
        public String UseTypeCode { get => _UseTypeCode; set { if (OnPropertyChanging("UseTypeCode", value)) { _UseTypeCode = value; OnPropertyChanged("UseTypeCode"); } } }
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
                    case "ID": return _ID;
                    case "PlateNo": return _PlateNo;
                    case "VehicleTypeCode": return _VehicleType;
                    case "PlateColorCode": return _PlateColor;
                    case "Deleted": return _Deleted;
                    case "TenantId": return _TenantId;
                    case "InstallDate": return _InstallDate;
                    case "SimNo": return _SimNo;
                    case "Driver": return _Driver;
                    case "DepartmentID": return _DepartmentID;
                    case "Region": return _Region;
                    case "Industry": return _Industry;
                    case "PlateformId": return _PlateformId;
                    case "TerminalId": return _TerminalId;
                    case "TerminalModel": return _TerminalModel;
                    case "TerminalVendorId": return _TerminalVendorId;
                    case "DriverMobile": return _DriverMobile;
                    case "BuyDate": return _BuyDate;
                    case "Owner": return _Owner;
                    case "CreateUser": return _CreateUser;
                    case "CreateUserID": return _CreateUserID;
                    case "CreateIP": return _CreateIP;
                    case "CreateTime": return _CreateTime;
                    case "UpdateUser": return _UpdateUser;
                    case "UpdateUserID": return _UpdateUserID;
                    case "UpdateIP": return _UpdateIP;
                    case "UpdateTime": return _UpdateTime;
                    case "Remark": return _Remark;
                    case "RunStatusCode": return _RunStatusCode;
                    case "UseTypeCode": return _UseTypeCode;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = value.ToInt(); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "VehicleTypeCode": _VehicleType = value.ToInt(); break;
                    case "PlateColorCode": _PlateColor = value.ToInt(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "InstallDate": _InstallDate = value.ToDateTime(); break;
                    case "SimNo": _SimNo = Convert.ToString(value); break;
                    case "Driver": _Driver = Convert.ToString(value); break;
                    case "DepartmentID": _DepartmentID = value.ToInt(); break;
                    case "Region": _Region = value.ToInt(); break;
                    case "Industry": _Industry = value.ToInt(); break;
                    case "PlateformId": _PlateformId = Convert.ToString(value); break;
                    case "TerminalId": _TerminalId = Convert.ToString(value); break;
                    case "TerminalModel": _TerminalModel = Convert.ToString(value); break;
                    case "TerminalVendorId": _TerminalVendorId = Convert.ToString(value); break;
                    case "DriverMobile": _DriverMobile = Convert.ToString(value); break;
                    case "BuyDate": _BuyDate = value.ToDateTime(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "CreateUser": _CreateUser = Convert.ToString(value); break;
                    case "CreateUserID": _CreateUserID = value.ToInt(); break;
                    case "CreateIP": _CreateIP = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "UpdateUser": _UpdateUser = Convert.ToString(value); break;
                    case "UpdateUserID": _UpdateUserID = value.ToInt(); break;
                    case "UpdateIP": _UpdateIP = Convert.ToString(value); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "RunStatusCode": _RunStatusCode = value.ToInt(); break;
                    case "UseTypeCode": _UseTypeCode = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得车辆信息字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>车辆类型</summary>
            public static readonly Field VehicleTypeCode = FindByName("VehicleTypeCode");

            /// <summary>车牌颜色</summary>
            public static readonly Field PlateColorCode = FindByName("PlateColorCode");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>租户编号</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>安装日期</summary>
            public static readonly Field InstallDate = FindByName("InstallDate");

            /// <summary>Sim卡号</summary>
            public static readonly Field SimNo = FindByName("SimNo");

            /// <summary>驾驶员</summary>
            public static readonly Field Driver = FindByName("Driver");

            /// <summary>部门编码</summary>
            public static readonly Field DepartmentID = FindByName("DepartmentID");

            /// <summary>部门名称</summary>
            public static readonly Field DepartmentName = FindByName("DepartmentName");

            /// <summary>区域</summary>
            public static readonly Field Region = FindByName("Region");

            /// <summary>行业</summary>
            public static readonly Field Industry = FindByName("Industry");

            /// <summary>使用性质</summary>
            public static readonly Field UseType = FindByName("UseType");

            /// <summary>平台编码</summary>
            public static readonly Field PlateformId = FindByName("PlateformId");

            /// <summary>终端编码</summary>
            public static readonly Field TerminalId = FindByName("TerminalId");

            /// <summary>终端型号</summary>
            public static readonly Field TerminalModel = FindByName("TerminalModel");

            /// <summary>终端供应商编码</summary>
            public static readonly Field TerminalVendorId = FindByName("TerminalVendorId");

            /// <summary>驾驶员手机号</summary>
            public static readonly Field DriverMobile = FindByName("DriverMobile");

            /// <summary>购买日期</summary>
            public static readonly Field BuyDate = FindByName("BuyDate");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

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

            /// <summary>车辆运行状态</summary>
            public static readonly Field RunStatusCode = FindByName("RunStatusCode");

            /// <summary>使用性质</summary>
            public static readonly Field UseTypeCode = FindByName("UseTypeCode");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得车辆信息字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String ID = "ID";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>车辆类型</summary>
            public const String VehicleTypeCode = "VehicleTypeCode";

            /// <summary>车牌颜色</summary>
            public const String PlateColorCode = "PlateColorCode";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>租户编号</summary>
            public const String TenantId = "TenantId";

            /// <summary>安装日期</summary>
            public const String InstallDate = "InstallDate";

            /// <summary>Sim卡号</summary>
            public const String SimNo = "SimNo";

            /// <summary>驾驶员</summary>
            public const String Driver = "Driver";

            /// <summary>部门编码</summary>
            public const String DepartmentID = "DepartmentID";

            /// <summary>部门名称</summary>
            public const String DepartmentName = "DepartmentName";

            /// <summary>区域</summary>
            public const String Region = "Region";

            /// <summary>行业</summary>
            public const String Industry = "Industry";

            /// <summary>使用性质</summary>
            public const String UseType = "UseType";

            /// <summary>平台编码</summary>
            public const String PlateformId = "PlateformId";

            /// <summary>终端编码</summary>
            public const String TerminalId = "TerminalId";

            /// <summary>终端型号</summary>
            public const String TerminalModel = "TerminalModel";

            /// <summary>终端供应商编码</summary>
            public const String TerminalVendorId = "TerminalVendorId";

            /// <summary>驾驶员手机号</summary>
            public const String DriverMobile = "DriverMobile";

            /// <summary>购买日期</summary>
            public const String BuyDate = "BuyDate";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";

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

            /// <summary>车辆运行状态</summary>
            public const String RunStatusCode = "RunStatusCode";

            /// <summary>使用性质</summary>
            public const String UseTypeCode = "UseTypeCode";
        }
        #endregion
    }
}