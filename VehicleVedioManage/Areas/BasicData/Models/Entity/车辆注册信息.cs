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
    /// <summary>车辆注册信息</summary>
    [Serializable]
    [DataObject]
    [Description("车辆注册信息")]
    [BindTable("VehicleRegisterInfo", Description = "车辆注册信息", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class VehicleRegisterInfo
    {
        #region 属性
        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [Category("基本信息")]
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("VehicleId", "车辆编码", "int")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private Int32 _DepId;
        /// <summary>部门编码</summary>
        [Category("基本信息")]
        [DisplayName("部门编码")]
        [Description("部门编码")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("DepId", "部门编码", "int")]
        public Int32 DepId { get => _DepId; set { if (OnPropertyChanging("DepId", value)) { _DepId = value; OnPropertyChanged("DepId"); } } }

        private Int32 _PlateColor;
        /// <summary>车牌颜色</summary>
        [Category("基本信息")]
        [DisplayName("车牌颜色")]
        [Description("车牌颜色")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("PlateColor", "车牌颜色", "int")]
        public Int32 PlateColor { get => _PlateColor; set { if (OnPropertyChanging("PlateColor", value)) { _PlateColor = value; OnPropertyChanged("PlateColor"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [Category("基本信息")]
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("PlateNo", "车牌号", "varchar(255)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private String _PlateformId;
        /// <summary>平台编码</summary>
        [Category("基本信息")]
        [DisplayName("平台编码")]
        [Description("平台编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("PlateformId", "平台编码", "varchar(255)")]
        public String PlateformId { get => _PlateformId; set { if (OnPropertyChanging("PlateformId", value)) { _PlateformId = value; OnPropertyChanged("PlateformId"); } } }

        private String _SimNo;
        /// <summary>Sim卡</summary>
        [Category("基本信息")]
        [DisplayName("Sim卡")]
        [Description("Sim卡")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("SimNo", "Sim卡", "varchar(255)")]
        public String SimNo { get => _SimNo; set { if (OnPropertyChanging("SimNo", value)) { _SimNo = value; OnPropertyChanged("SimNo"); } } }

        private String _TerminalId;
        /// <summary>终端编码</summary>
        [Category("基本信息")]
        [DisplayName("终端编码")]
        [Description("终端编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("TerminalId", "终端编码", "varchar(255)")]
        public String TerminalId { get => _TerminalId; set { if (OnPropertyChanging("TerminalId", value)) { _TerminalId = value; OnPropertyChanged("TerminalId"); } } }

        private String _TerminalModel;
        /// <summary>终端型号</summary>
        [Category("基本信息")]
        [DisplayName("终端型号")]
        [Description("终端型号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("TerminalModel", "终端型号", "varchar(255)")]
        public String TerminalModel { get => _TerminalModel; set { if (OnPropertyChanging("TerminalModel", value)) { _TerminalModel = value; OnPropertyChanged("TerminalModel"); } } }

        private String _TerminalVendorId;
        /// <summary>终端供应商编码</summary>
        [Category("基本信息")]
        [DisplayName("终端供应商编码")]
        [Description("终端供应商编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("TerminalVendorId", "终端供应商编码", "varchar(255)")]
        public String TerminalVendorId { get => _TerminalVendorId; set { if (OnPropertyChanging("TerminalVendorId", value)) { _TerminalVendorId = value; OnPropertyChanged("TerminalVendorId"); } } }

        private String _CreateUser;
        /// <summary>创建者</summary>
        [Category("扩展信息")]
        [DisplayName("创建者")]
        [Description("创建者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateUser", "创建者", "nvarchar(50)")]
        public String CreateUser { get => _CreateUser; set { if (OnPropertyChanging("CreateUser", value)) { _CreateUser = value; OnPropertyChanged("CreateUser"); } } }

        private Int32 _CreateUserID;
        /// <summary>创建人</summary>
        [Category("扩展信息")]
        [DisplayName("创建人")]
        [Description("创建人")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("CreateUserID", "创建人", "int")]
        public Int32 CreateUserID { get => _CreateUserID; set { if (OnPropertyChanging("CreateUserID", value)) { _CreateUserID = value; OnPropertyChanged("CreateUserID"); } } }

        private String _CreateIP;
        /// <summary>创建地址</summary>
        [Category("扩展信息")]
        [DisplayName("创建地址")]
        [Description("创建地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateIP", "创建地址", "nvarchar(50)")]
        public String CreateIP { get => _CreateIP; set { if (OnPropertyChanging("CreateIP", value)) { _CreateIP = value; OnPropertyChanged("CreateIP"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _UpdateUser;
        /// <summary>更新者</summary>
        [Category("扩展信息")]
        [DisplayName("更新者")]
        [Description("更新者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateUser", "更新者", "nvarchar(50)")]
        public String UpdateUser { get => _UpdateUser; set { if (OnPropertyChanging("UpdateUser", value)) { _UpdateUser = value; OnPropertyChanged("UpdateUser"); } } }

        private Int32 _UpdateUserID;
        /// <summary>更新人</summary>
        [Category("扩展信息")]
        [DisplayName("更新人")]
        [Description("更新人")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("UpdateUserID", "更新人", "int")]
        public Int32 UpdateUserID { get => _UpdateUserID; set { if (OnPropertyChanging("UpdateUserID", value)) { _UpdateUserID = value; OnPropertyChanged("UpdateUserID"); } } }

        private String _UpdateIP;
        /// <summary>更新地址</summary>
        [Category("扩展信息")]
        [DisplayName("更新地址")]
        [Description("更新地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateIP", "更新地址", "nvarchar(50)")]
        public String UpdateIP { get => _UpdateIP; set { if (OnPropertyChanging("UpdateIP", value)) { _UpdateIP = value; OnPropertyChanged("UpdateIP"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [Category("扩展信息")]
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateTime", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Remark", "备注", "nvarchar(500)")]
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
                    case "VehicleId": return _VehicleId;
                    case "DepId": return _DepId;
                    case "PlateColor": return _PlateColor;
                    case "PlateNo": return _PlateNo;
                    case "PlateformId": return _PlateformId;
                    case "SimNo": return _SimNo;
                    case "TerminalId": return _TerminalId;
                    case "TerminalModel": return _TerminalModel;
                    case "TerminalVendorId": return _TerminalVendorId;
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
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "DepId": _DepId = value.ToInt(); break;
                    case "PlateColor": _PlateColor = value.ToInt(); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "PlateformId": _PlateformId = Convert.ToString(value); break;
                    case "SimNo": _SimNo = Convert.ToString(value); break;
                    case "TerminalId": _TerminalId = Convert.ToString(value); break;
                    case "TerminalModel": _TerminalModel = Convert.ToString(value); break;
                    case "TerminalVendorId": _TerminalVendorId = Convert.ToString(value); break;
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
        /// <summary>取得VehicleRegisterInfo字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>部门编码</summary>
            public static readonly Field DepId = FindByName("DepId");

            /// <summary>车牌颜色</summary>
            public static readonly Field PlateColor = FindByName("PlateColor");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>平台编码</summary>
            public static readonly Field PlateformId = FindByName("PlateformId");

            /// <summary>Sim卡</summary>
            public static readonly Field SimNo = FindByName("SimNo");

            /// <summary>终端编码</summary>
            public static readonly Field TerminalId = FindByName("TerminalId");

            /// <summary>终端型号</summary>
            public static readonly Field TerminalModel = FindByName("TerminalModel");

            /// <summary>终端供应商编码</summary>
            public static readonly Field TerminalVendorId = FindByName("TerminalVendorId");

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

        /// <summary>取得VehicleRegisterInfo字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>部门编码</summary>
            public const String DepId = "DepId";

            /// <summary>车牌颜色</summary>
            public const String PlateColor = "PlateColor";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>平台编码</summary>
            public const String PlateformId = "PlateformId";

            /// <summary>Sim卡</summary>
            public const String SimNo = "SimNo";

            /// <summary>终端编码</summary>
            public const String TerminalId = "TerminalId";

            /// <summary>终端型号</summary>
            public const String TerminalModel = "TerminalModel";

            /// <summary>终端供应商编码</summary>
            public const String TerminalVendorId = "TerminalVendorId";

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