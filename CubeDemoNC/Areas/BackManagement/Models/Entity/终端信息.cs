using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace GPSPlatform.BackManagement.Entity
{
    /// <summary>终端信息</summary>
    [Serializable]
    [DataObject]
    [Description("终端信息")]
    [BindTable("Terminal", Description = "终端信息", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class Terminal
    {
        #region 属性
        private Int32 _TermId;
        /// <summary>终端编码</summary>
        [Category("基本信息")]
        [DisplayName("终端编码")]
        [Description("终端编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("TermId", "终端编码", "int")]
        public Int32 TermId { get => _TermId; set { if (OnPropertyChanging("TermId", value)) { _TermId = value; OnPropertyChanged("TermId"); } } }

        private String _DevNo;
        /// <summary>开发编号</summary>
        [Category("基本信息")]
        [DisplayName("开发编号")]
        [Description("开发编号")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("DevNo", "开发编号", "nvarchar(20)")]
        public String DevNo { get => _DevNo; set { if (OnPropertyChanging("DevNo", value)) { _DevNo = value; OnPropertyChanged("DevNo"); } } }

        private String _TermNo;
        /// <summary>终端编号</summary>
        [Category("基本信息")]
        [DisplayName("终端编号")]
        [Description("终端编号")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn("TermNo", "终端编号", "nvarchar(20)")]
        public String TermNo { get => _TermNo; set { if (OnPropertyChanging("TermNo", value)) { _TermNo = value; OnPropertyChanged("TermNo"); } } }

        private Int16 _VerSoftware;
        /// <summary>软件版本号</summary>
        [Category("基本信息")]
        [DisplayName("软件版本号")]
        [Description("软件版本号")]
        [DataObjectField(false, false, false, 5)]
        [BindColumn("VerSoftware", "软件版本号", "smallint")]
        public Int16 VerSoftware { get => _VerSoftware; set { if (OnPropertyChanging("VerSoftware", value)) { _VerSoftware = value; OnPropertyChanged("VerSoftware"); } } }

        private Int16 _VerHardware;
        /// <summary>硬件版本号</summary>
        [Category("基本信息")]
        [DisplayName("硬件版本号")]
        [Description("硬件版本号")]
        [DataObjectField(false, false, false, 5)]
        [BindColumn("VerHardware", "硬件版本号", "smallint")]
        public Int16 VerHardware { get => _VerHardware; set { if (OnPropertyChanging("VerHardware", value)) { _VerHardware = value; OnPropertyChanged("VerHardware"); } } }

        private Int16 _VerProtocol;
        /// <summary>协议版本号</summary>
        [Category("基本信息")]
        [DisplayName("协议版本号")]
        [Description("协议版本号")]
        [DataObjectField(false, false, false, 5)]
        [BindColumn("VerProtocol", "协议版本号", "smallint")]
        public Int16 VerProtocol { get => _VerProtocol; set { if (OnPropertyChanging("VerProtocol", value)) { _VerProtocol = value; OnPropertyChanged("VerProtocol"); } } }

        private String _MakeFactory;
        /// <summary>制造工厂</summary>
        [Category("基本信息")]
        [DisplayName("制造工厂")]
        [Description("制造工厂")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("MakeFactory", "制造工厂", "nvarchar(30)")]
        public String MakeFactory { get => _MakeFactory; set { if (OnPropertyChanging("MakeFactory", value)) { _MakeFactory = value; OnPropertyChanged("MakeFactory"); } } }

        private DateTime _MakeTime;
        /// <summary>制造时间</summary>
        [Category("基本信息")]
        [DisplayName("制造时间")]
        [Description("制造时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn("MakeTime", "制造时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime MakeTime { get => _MakeTime; set { if (OnPropertyChanging("MakeTime", value)) { _MakeTime = value; OnPropertyChanged("MakeTime"); } } }

        private String _MakeNo;
        /// <summary>制造编号</summary>
        [Category("基本信息")]
        [DisplayName("制造编号")]
        [Description("制造编号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("MakeNo", "制造编号", "nvarchar(10)")]
        public String MakeNo { get => _MakeNo; set { if (OnPropertyChanging("MakeNo", value)) { _MakeNo = value; OnPropertyChanged("MakeNo"); } } }

        private String _State;
        /// <summary>状态</summary>
        [Category("基本信息")]
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("State", "状态", "nvarchar(20)")]
        public String State { get => _State; set { if (OnPropertyChanging("State", value)) { _State = value; OnPropertyChanged("State"); } } }

        private String _Reserve;
        /// <summary>预留</summary>
        [Category("扩展信息")]
        [DisplayName("预留")]
        [Description("预留")]
        [DataObjectField(false, false, true, 4)]
        [BindColumn("Reserve", "预留", "nvarchar(4)")]
        public String Reserve { get => _Reserve; set { if (OnPropertyChanging("Reserve", value)) { _Reserve = value; OnPropertyChanged("Reserve"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Remark", "备注", "nvarchar(255)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private DateTime _InstallTime;
        /// <summary>安装时间</summary>
        [Category("基本信息")]
        [DisplayName("安装时间")]
        [Description("安装时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("InstallTime", "安装时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime InstallTime { get => _InstallTime; set { if (OnPropertyChanging("InstallTime", value)) { _InstallTime = value; OnPropertyChanged("InstallTime"); } } }

        private String _Waitor;
        /// <summary>实施员</summary>
        [Category("基本信息")]
        [DisplayName("实施员")]
        [Description("实施员")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("Waitor", "实施员", "nvarchar(30)")]
        public String Waitor { get => _Waitor; set { if (OnPropertyChanging("Waitor", value)) { _Waitor = value; OnPropertyChanged("Waitor"); } } }

        private String _InstallAddress;
        /// <summary>安装地址</summary>
        [Category("基本信息")]
        [DisplayName("安装地址")]
        [Description("安装地址")]
        [DataObjectField(false, false, true, 80)]
        [BindColumn("InstallAddress", "安装地址", "nvarchar(80)")]
        public String InstallAddress { get => _InstallAddress; set { if (OnPropertyChanging("InstallAddress", value)) { _InstallAddress = value; OnPropertyChanged("InstallAddress"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [Category("基本信息")]
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateTime", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private String _TermType;
        /// <summary>终端类型</summary>
        [Category("基本信息")]
        [DisplayName("终端类型")]
        [Description("终端类型")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("TermType", "终端类型", "nvarchar(20)")]
        public String TermType { get => _TermType; set { if (OnPropertyChanging("TermType", value)) { _TermType = value; OnPropertyChanged("TermType"); } } }

        private String _SimNo;
        /// <summary>Sim卡</summary>
        [Category("基本信息")]
        [DisplayName("Sim卡")]
        [Description("Sim卡")]
        [DataObjectField(false, false, true, 13)]
        [BindColumn("SimNo", "Sim卡", "nvarchar(13)")]
        public String SimNo { get => _SimNo; set { if (OnPropertyChanging("SimNo", value)) { _SimNo = value; OnPropertyChanged("SimNo"); } } }

        private Boolean _Bind;
        /// <summary>是否绑定</summary>
        [Category("基本信息")]
        [DisplayName("是否绑定")]
        [Description("是否绑定")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Bind", "是否绑定", "bit")]
        public Boolean Bind { get => _Bind; set { if (OnPropertyChanging("Bind", value)) { _Bind = value; OnPropertyChanged("Bind"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [Category("基本信息")]
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [Category("基本信息")]
        [DisplayName("拥有者")]
        [Description("拥有者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "拥有者", "nvarchar(50)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("基本信息")]
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _SeqNo;
        /// <summary>序列号</summary>
        [Category("基本信息")]
        [DisplayName("序列号")]
        [Description("序列号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("SeqNo", "序列号", "nvarchar(50)")]
        public String SeqNo { get => _SeqNo; set { if (OnPropertyChanging("SeqNo", value)) { _SeqNo = value; OnPropertyChanged("SeqNo"); } } }

        private String _Vendor;
        /// <summary>消失公司</summary>
        [Category("扩展信息")]
        [DisplayName("消失公司")]
        [Description("消失公司")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Vendor", "消失公司", "nvarchar(255)")]
        public String Vendor { get => _Vendor; set { if (OnPropertyChanging("Vendor", value)) { _Vendor = value; OnPropertyChanged("Vendor"); } } }

        private String _ModelNo;
        /// <summary>型号</summary>
        [Category("基本信息")]
        [DisplayName("型号")]
        [Description("型号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("ModelNo", "型号", "nvarchar(255)")]
        public String ModelNo { get => _ModelNo; set { if (OnPropertyChanging("ModelNo", value)) { _ModelNo = value; OnPropertyChanged("ModelNo"); } } }

        private String _Imei;
        /// <summary>IMEI</summary>
        [Category("基本信息")]
        [DisplayName("IMEI")]
        [Description("IMEI")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("IMEI", "IMEI", "nvarchar(255)")]
        public String Imei { get => _Imei; set { if (OnPropertyChanging("Imei", value)) { _Imei = value; OnPropertyChanged("Imei"); } } }

        private String _CertPassword;
        /// <summary>认证密码</summary>
        [Category("基本信息")]
        [DisplayName("认证密码")]
        [Description("认证密码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("CertPassword", "认证密码", "nvarchar(255)")]
        public String CertPassword { get => _CertPassword; set { if (OnPropertyChanging("CertPassword", value)) { _CertPassword = value; OnPropertyChanged("CertPassword"); } } }

        private String _CertString;
        /// <summary>认证字符串</summary>
        [Category("基本信息")]
        [DisplayName("认证字符串")]
        [Description("认证字符串")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("CertString", "认证字符串", "nvarchar(255)")]
        public String CertString { get => _CertString; set { if (OnPropertyChanging("CertString", value)) { _CertString = value; OnPropertyChanged("CertString"); } } }
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
                    case "TermId": return _TermId;
                    case "DevNo": return _DevNo;
                    case "TermNo": return _TermNo;
                    case "VerSoftware": return _VerSoftware;
                    case "VerHardware": return _VerHardware;
                    case "VerProtocol": return _VerProtocol;
                    case "MakeFactory": return _MakeFactory;
                    case "MakeTime": return _MakeTime;
                    case "MakeNo": return _MakeNo;
                    case "State": return _State;
                    case "Reserve": return _Reserve;
                    case "Remark": return _Remark;
                    case "InstallTime": return _InstallTime;
                    case "Waitor": return _Waitor;
                    case "InstallAddress": return _InstallAddress;
                    case "UpdateTime": return _UpdateTime;
                    case "TermType": return _TermType;
                    case "SimNo": return _SimNo;
                    case "Bind": return _Bind;
                    case "TenantId": return _TenantId;
                    case "CreateTime": return _CreateTime;
                    case "Owner": return _Owner;
                    case "Deleted": return _Deleted;
                    case "SeqNo": return _SeqNo;
                    case "Vendor": return _Vendor;
                    case "ModelNo": return _ModelNo;
                    case "Imei": return _Imei;
                    case "CertPassword": return _CertPassword;
                    case "CertString": return _CertString;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "TermId": _TermId = value.ToInt(); break;
                    case "DevNo": _DevNo = Convert.ToString(value); break;
                    case "TermNo": _TermNo = Convert.ToString(value); break;
                    case "VerSoftware": _VerSoftware = Convert.ToInt16(value); break;
                    case "VerHardware": _VerHardware = Convert.ToInt16(value); break;
                    case "VerProtocol": _VerProtocol = Convert.ToInt16(value); break;
                    case "MakeFactory": _MakeFactory = Convert.ToString(value); break;
                    case "MakeTime": _MakeTime = value.ToDateTime(); break;
                    case "MakeNo": _MakeNo = Convert.ToString(value); break;
                    case "State": _State = Convert.ToString(value); break;
                    case "Reserve": _Reserve = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "InstallTime": _InstallTime = value.ToDateTime(); break;
                    case "Waitor": _Waitor = Convert.ToString(value); break;
                    case "InstallAddress": _InstallAddress = Convert.ToString(value); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    case "TermType": _TermType = Convert.ToString(value); break;
                    case "SimNo": _SimNo = Convert.ToString(value); break;
                    case "Bind": _Bind = value.ToBoolean(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "SeqNo": _SeqNo = Convert.ToString(value); break;
                    case "Vendor": _Vendor = Convert.ToString(value); break;
                    case "ModelNo": _ModelNo = Convert.ToString(value); break;
                    case "Imei": _Imei = Convert.ToString(value); break;
                    case "CertPassword": _CertPassword = Convert.ToString(value); break;
                    case "CertString": _CertString = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Terminal字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>终端编码</summary>
            public static readonly Field TermId = FindByName("TermId");

            /// <summary>开发编号</summary>
            public static readonly Field DevNo = FindByName("DevNo");

            /// <summary>终端编号</summary>
            public static readonly Field TermNo = FindByName("TermNo");

            /// <summary>软件版本号</summary>
            public static readonly Field VerSoftware = FindByName("VerSoftware");

            /// <summary>硬件版本号</summary>
            public static readonly Field VerHardware = FindByName("VerHardware");

            /// <summary>协议版本号</summary>
            public static readonly Field VerProtocol = FindByName("VerProtocol");

            /// <summary>制造工厂</summary>
            public static readonly Field MakeFactory = FindByName("MakeFactory");

            /// <summary>制造时间</summary>
            public static readonly Field MakeTime = FindByName("MakeTime");

            /// <summary>制造编号</summary>
            public static readonly Field MakeNo = FindByName("MakeNo");

            /// <summary>状态</summary>
            public static readonly Field State = FindByName("State");

            /// <summary>预留</summary>
            public static readonly Field Reserve = FindByName("Reserve");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>安装时间</summary>
            public static readonly Field InstallTime = FindByName("InstallTime");

            /// <summary>实施员</summary>
            public static readonly Field Waitor = FindByName("Waitor");

            /// <summary>安装地址</summary>
            public static readonly Field InstallAddress = FindByName("InstallAddress");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            /// <summary>终端类型</summary>
            public static readonly Field TermType = FindByName("TermType");

            /// <summary>Sim卡</summary>
            public static readonly Field SimNo = FindByName("SimNo");

            /// <summary>是否绑定</summary>
            public static readonly Field Bind = FindByName("Bind");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>序列号</summary>
            public static readonly Field SeqNo = FindByName("SeqNo");

            /// <summary>消失公司</summary>
            public static readonly Field Vendor = FindByName("Vendor");

            /// <summary>型号</summary>
            public static readonly Field ModelNo = FindByName("ModelNo");

            /// <summary>IMEI</summary>
            public static readonly Field Imei = FindByName("Imei");

            /// <summary>认证密码</summary>
            public static readonly Field CertPassword = FindByName("CertPassword");

            /// <summary>认证字符串</summary>
            public static readonly Field CertString = FindByName("CertString");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得Terminal字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>终端编码</summary>
            public const String TermId = "TermId";

            /// <summary>开发编号</summary>
            public const String DevNo = "DevNo";

            /// <summary>终端编号</summary>
            public const String TermNo = "TermNo";

            /// <summary>软件版本号</summary>
            public const String VerSoftware = "VerSoftware";

            /// <summary>硬件版本号</summary>
            public const String VerHardware = "VerHardware";

            /// <summary>协议版本号</summary>
            public const String VerProtocol = "VerProtocol";

            /// <summary>制造工厂</summary>
            public const String MakeFactory = "MakeFactory";

            /// <summary>制造时间</summary>
            public const String MakeTime = "MakeTime";

            /// <summary>制造编号</summary>
            public const String MakeNo = "MakeNo";

            /// <summary>状态</summary>
            public const String State = "State";

            /// <summary>预留</summary>
            public const String Reserve = "Reserve";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>安装时间</summary>
            public const String InstallTime = "InstallTime";

            /// <summary>实施员</summary>
            public const String Waitor = "Waitor";

            /// <summary>安装地址</summary>
            public const String InstallAddress = "InstallAddress";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            /// <summary>终端类型</summary>
            public const String TermType = "TermType";

            /// <summary>Sim卡</summary>
            public const String SimNo = "SimNo";

            /// <summary>是否绑定</summary>
            public const String Bind = "Bind";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>序列号</summary>
            public const String SeqNo = "SeqNo";

            /// <summary>消失公司</summary>
            public const String Vendor = "Vendor";

            /// <summary>型号</summary>
            public const String ModelNo = "ModelNo";

            /// <summary>IMEI</summary>
            public const String Imei = "Imei";

            /// <summary>认证密码</summary>
            public const String CertPassword = "CertPassword";

            /// <summary>认证字符串</summary>
            public const String CertString = "CertString";
        }
        #endregion
    }
}