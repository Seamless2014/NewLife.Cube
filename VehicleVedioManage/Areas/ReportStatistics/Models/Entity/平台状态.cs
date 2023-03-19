using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.ReportStatistics.Entity
{
    /// <summary>平台状态</summary>
    [Serializable]
    [DataObject]
    [Description("平台状态")]
    [BindTable("PlatformState", Description = "平台状态", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class PlatformState
    {
        #region 属性
        private Int32 _StateId;
        /// <summary>平台状态编码</summary>
        [DisplayName("平台状态编码")]
        [Description("平台状态编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("StateId", "平台状态编码", "int")]
        public Int32 StateId { get => _StateId; set { if (OnPropertyChanging("StateId", value)) { _StateId = value; OnPropertyChanged("StateId"); } } }

        private String _MainLinkState;
        /// <summary>主链路状态</summary>
        [DisplayName("主链路状态")]
        [Description("主链路状态")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("MainLinkState", "主链路状态", "nvarchar(50)")]
        public String MainLinkState { get => _MainLinkState; set { if (OnPropertyChanging("MainLinkState", value)) { _MainLinkState = value; OnPropertyChanged("MainLinkState"); } } }

        private DateTime _MainLinkDate;
        /// <summary>主链路连接日期</summary>
        [DisplayName("主链路连接日期")]
        [Description("主链路连接日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("MainLinkDate", "主链路连接日期", "datetime", Precision = 0, Scale = 3)]
        public DateTime MainLinkDate { get => _MainLinkDate; set { if (OnPropertyChanging("MainLinkDate", value)) { _MainLinkDate = value; OnPropertyChanged("MainLinkDate"); } } }

        private String _SubLinkState;
        /// <summary>从链路连接状态</summary>
        [DisplayName("从链路连接状态")]
        [Description("从链路连接状态")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("SubLinkState", "从链路连接状态", "nvarchar(50)")]
        public String SubLinkState { get => _SubLinkState; set { if (OnPropertyChanging("SubLinkState", value)) { _SubLinkState = value; OnPropertyChanged("SubLinkState"); } } }

        private DateTime _SubLinkDate;
        /// <summary>从链路连接日期</summary>
        [DisplayName("从链路连接日期")]
        [Description("从链路连接日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("SubLinkDate", "从链路连接日期", "datetime", Precision = 0, Scale = 3)]
        public DateTime SubLinkDate { get => _SubLinkDate; set { if (OnPropertyChanging("SubLinkDate", value)) { _SubLinkDate = value; OnPropertyChanged("SubLinkDate"); } } }

        private String _GPSServerState;
        /// <summary>GPS服务状态</summary>
        [DisplayName("GPS服务状态")]
        [Description("GPS服务状态")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("GPSServerState", "GPS服务状态", "nvarchar(50)")]
        public String GPSServerState { get => _GPSServerState; set { if (OnPropertyChanging("GPSServerState", value)) { _GPSServerState = value; OnPropertyChanged("GPSServerState"); } } }

        private DateTime _GPSServerDate;
        /// <summary>GPS服务日期</summary>
        [DisplayName("GPS服务日期")]
        [Description("GPS服务日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("GPSServerDate", "GPS服务日期", "datetime", Precision = 0, Scale = 3)]
        public DateTime GPSServerDate { get => _GPSServerDate; set { if (OnPropertyChanging("GPSServerDate", value)) { _GPSServerDate = value; OnPropertyChanged("GPSServerDate"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private DateTime _CreateTime;
        /// <summary>创建日期</summary>
        [DisplayName("创建日期")]
        [Description("创建日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建日期", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Remark", "备注", "nvarchar(255)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [DisplayName("拥有者")]
        [Description("拥有者")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Owner", "拥有者", "nvarchar(255)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }
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
                    case "StateId": return _StateId;
                    case "MainLinkState": return _MainLinkState;
                    case "MainLinkDate": return _MainLinkDate;
                    case "SubLinkState": return _SubLinkState;
                    case "SubLinkDate": return _SubLinkDate;
                    case "GPSServerState": return _GPSServerState;
                    case "GPSServerDate": return _GPSServerDate;
                    case "TenantId": return _TenantId;
                    case "CreateTime": return _CreateTime;
                    case "Remark": return _Remark;
                    case "Deleted": return _Deleted;
                    case "Owner": return _Owner;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "StateId": _StateId = value.ToInt(); break;
                    case "MainLinkState": _MainLinkState = Convert.ToString(value); break;
                    case "MainLinkDate": _MainLinkDate = value.ToDateTime(); break;
                    case "SubLinkState": _SubLinkState = Convert.ToString(value); break;
                    case "SubLinkDate": _SubLinkDate = value.ToDateTime(); break;
                    case "GPSServerState": _GPSServerState = Convert.ToString(value); break;
                    case "GPSServerDate": _GPSServerDate = value.ToDateTime(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得平台状态字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>平台状态编码</summary>
            public static readonly Field StateId = FindByName("StateId");

            /// <summary>主链路状态</summary>
            public static readonly Field MainLinkState = FindByName("MainLinkState");

            /// <summary>主链路连接日期</summary>
            public static readonly Field MainLinkDate = FindByName("MainLinkDate");

            /// <summary>从链路连接状态</summary>
            public static readonly Field SubLinkState = FindByName("SubLinkState");

            /// <summary>从链路连接日期</summary>
            public static readonly Field SubLinkDate = FindByName("SubLinkDate");

            /// <summary>GPS服务状态</summary>
            public static readonly Field GPSServerState = FindByName("GPSServerState");

            /// <summary>GPS服务日期</summary>
            public static readonly Field GPSServerDate = FindByName("GPSServerDate");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>创建日期</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得平台状态字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>平台状态编码</summary>
            public const String StateId = "StateId";

            /// <summary>主链路状态</summary>
            public const String MainLinkState = "MainLinkState";

            /// <summary>主链路连接日期</summary>
            public const String MainLinkDate = "MainLinkDate";

            /// <summary>从链路连接状态</summary>
            public const String SubLinkState = "SubLinkState";

            /// <summary>从链路连接日期</summary>
            public const String SubLinkDate = "SubLinkDate";

            /// <summary>GPS服务状态</summary>
            public const String GPSServerState = "GPSServerState";

            /// <summary>GPS服务日期</summary>
            public const String GPSServerDate = "GPSServerDate";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>创建日期</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";
        }
        #endregion
    }
}