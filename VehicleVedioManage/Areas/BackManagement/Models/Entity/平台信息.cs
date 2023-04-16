using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.BackManagement.Entity
{
    /// <summary>平台信息。主要用于转发809信号的，涉及到主链路、从链路等信息</summary>
    [Serializable]
    [DataObject]
    [Description("平台信息。主要用于转发809信号的，涉及到主链路、从链路等信息")]
    [BindIndex("IU_PlatformInfo_Name", true, "Name")]
    [BindTable("PlatformInfo", Description = "平台信息。主要用于转发809信号的，涉及到主链路、从链路等信息", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class PlatformInfo
    {
        #region 属性
        private Int32 _ID;
        /// <summary>平台编号</summary>
        [DisplayName("平台编号")]
        [Description("平台编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "平台编号", "")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Byte _Deleted;
        /// <summary>删除</summary>
        [Category("扩展信息")]
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "")]
        public Byte Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [Category("扩展信息")]
        [DisplayName("拥有者")]
        [Description("拥有者")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Owner", "拥有者", "varchar(255)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Remark", "备注", "varchar(255)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [Category("扩展信息")]
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TenantId", "租户编码", "")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private String _CheckEndTime;
        /// <summary>检查结束时间</summary>
        [DisplayName("检查结束时间")]
        [Description("检查结束时间")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("CheckEndTime", "检查结束时间", "varchar(255)")]
        public String CheckEndTime { get => _CheckEndTime; set { if (OnPropertyChanging("CheckEndTime", value)) { _CheckEndTime = value; OnPropertyChanged("CheckEndTime"); } } }

        private Int32 _CheckInterval;
        /// <summary>检查间隔</summary>
        [DisplayName("检查间隔")]
        [Description("检查间隔")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("CheckInterval", "检查间隔", "")]
        public Int32 CheckInterval { get => _CheckInterval; set { if (OnPropertyChanging("CheckInterval", value)) { _CheckInterval = value; OnPropertyChanged("CheckInterval"); } } }

        private String _CheckStartTime;
        /// <summary>检查起始时间</summary>
        [DisplayName("检查起始时间")]
        [Description("检查起始时间")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("CheckStartTime", "检查起始时间", "varchar(255)")]
        public String CheckStartTime { get => _CheckStartTime; set { if (OnPropertyChanging("CheckStartTime", value)) { _CheckStartTime = value; OnPropertyChanged("CheckStartTime"); } } }

        private String _MainLinkState;
        /// <summary>主链路状态</summary>
        [DisplayName("主链路状态")]
        [Description("主链路状态")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("MainLinkState", "主链路状态", "varchar(255)")]
        public String MainLinkState { get => _MainLinkState; set { if (OnPropertyChanging("MainLinkState", value)) { _MainLinkState = value; OnPropertyChanged("MainLinkState"); } } }

        private String _Name;
        /// <summary>平台名称</summary>
        [DisplayName("平台名称")]
        [Description("平台名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Name", "平台名称", "varchar(255)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _Password;
        /// <summary>密码</summary>
        [DisplayName("密码")]
        [Description("密码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Password", "密码", "varchar(255)")]
        public String Password { get => _Password; set { if (OnPropertyChanging("Password", value)) { _Password = value; OnPropertyChanged("Password"); } } }

        private Int32 _SublinkPort;
        /// <summary>从链路端口</summary>
        [DisplayName("从链路端口")]
        [Description("从链路端口")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("SublinkPort", "从链路端口", "")]
        public Int32 SublinkPort { get => _SublinkPort; set { if (OnPropertyChanging("SublinkPort", value)) { _SublinkPort = value; OnPropertyChanged("SublinkPort"); } } }

        private String _SublinkServerIp;
        /// <summary>从链路IP</summary>
        [DisplayName("从链路IP")]
        [Description("从链路IP")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("SublinkServerIp", "从链路IP", "varchar(255)")]
        public String SublinkServerIp { get => _SublinkServerIp; set { if (OnPropertyChanging("SublinkServerIp", value)) { _SublinkServerIp = value; OnPropertyChanged("SublinkServerIp"); } } }

        private String _SublinkState;
        /// <summary>从链路状态</summary>
        [DisplayName("从链路状态")]
        [Description("从链路状态")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("SublinkState", "从链路状态", "varchar(255)")]
        public String SublinkState { get => _SublinkState; set { if (OnPropertyChanging("SublinkState", value)) { _SublinkState = value; OnPropertyChanged("SublinkState"); } } }

        private String _UserId;
        /// <summary>用户名</summary>
        [DisplayName("用户名")]
        [Description("用户名")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("UserId", "用户名", "varchar(255)")]
        public String UserId { get => _UserId; set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } } }

        private String _CheckQuestion;
        /// <summary>检查问题</summary>
        [DisplayName("检查问题")]
        [Description("检查问题")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("CheckQuestion", "检查问题", "varchar(255)")]
        public String CheckQuestion { get => _CheckQuestion; set { if (OnPropertyChanging("CheckQuestion", value)) { _CheckQuestion = value; OnPropertyChanged("CheckQuestion"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [Category("扩展信息")]
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("UpdateTime", "更新时间", "", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }
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
                    case "CreateTime": return _CreateTime;
                    case "Deleted": return _Deleted;
                    case "Owner": return _Owner;
                    case "Remark": return _Remark;
                    case "TenantId": return _TenantId;
                    case "CheckEndTime": return _CheckEndTime;
                    case "CheckInterval": return _CheckInterval;
                    case "CheckStartTime": return _CheckStartTime;
                    case "MainLinkState": return _MainLinkState;
                    case "Name": return _Name;
                    case "Password": return _Password;
                    case "SublinkPort": return _SublinkPort;
                    case "SublinkServerIp": return _SublinkServerIp;
                    case "SublinkState": return _SublinkState;
                    case "UserId": return _UserId;
                    case "CheckQuestion": return _CheckQuestion;
                    case "UpdateTime": return _UpdateTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Deleted": _Deleted = Convert.ToByte(value); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "CheckEndTime": _CheckEndTime = Convert.ToString(value); break;
                    case "CheckInterval": _CheckInterval = value.ToInt(); break;
                    case "CheckStartTime": _CheckStartTime = Convert.ToString(value); break;
                    case "MainLinkState": _MainLinkState = Convert.ToString(value); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Password": _Password = Convert.ToString(value); break;
                    case "SublinkPort": _SublinkPort = value.ToInt(); break;
                    case "SublinkServerIp": _SublinkServerIp = Convert.ToString(value); break;
                    case "SublinkState": _SublinkState = Convert.ToString(value); break;
                    case "UserId": _UserId = Convert.ToString(value); break;
                    case "CheckQuestion": _CheckQuestion = Convert.ToString(value); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得平台信息字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>平台编号</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>检查结束时间</summary>
            public static readonly Field CheckEndTime = FindByName("CheckEndTime");

            /// <summary>检查间隔</summary>
            public static readonly Field CheckInterval = FindByName("CheckInterval");

            /// <summary>检查起始时间</summary>
            public static readonly Field CheckStartTime = FindByName("CheckStartTime");

            /// <summary>主链路状态</summary>
            public static readonly Field MainLinkState = FindByName("MainLinkState");

            /// <summary>平台名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>密码</summary>
            public static readonly Field Password = FindByName("Password");

            /// <summary>从链路端口</summary>
            public static readonly Field SublinkPort = FindByName("SublinkPort");

            /// <summary>从链路IP</summary>
            public static readonly Field SublinkServerIp = FindByName("SublinkServerIp");

            /// <summary>从链路状态</summary>
            public static readonly Field SublinkState = FindByName("SublinkState");

            /// <summary>用户名</summary>
            public static readonly Field UserId = FindByName("UserId");

            /// <summary>检查问题</summary>
            public static readonly Field CheckQuestion = FindByName("CheckQuestion");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得平台信息字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>平台编号</summary>
            public const String ID = "ID";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>检查结束时间</summary>
            public const String CheckEndTime = "CheckEndTime";

            /// <summary>检查间隔</summary>
            public const String CheckInterval = "CheckInterval";

            /// <summary>检查起始时间</summary>
            public const String CheckStartTime = "CheckStartTime";

            /// <summary>主链路状态</summary>
            public const String MainLinkState = "MainLinkState";

            /// <summary>平台名称</summary>
            public const String Name = "Name";

            /// <summary>密码</summary>
            public const String Password = "Password";

            /// <summary>从链路端口</summary>
            public const String SublinkPort = "SublinkPort";

            /// <summary>从链路IP</summary>
            public const String SublinkServerIp = "SublinkServerIp";

            /// <summary>从链路状态</summary>
            public const String SublinkState = "SublinkState";

            /// <summary>用户名</summary>
            public const String UserId = "UserId";

            /// <summary>检查问题</summary>
            public const String CheckQuestion = "CheckQuestion";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";
        }
        #endregion
    }
}