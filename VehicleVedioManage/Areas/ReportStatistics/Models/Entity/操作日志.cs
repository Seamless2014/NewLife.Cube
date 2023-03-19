using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.ReportStatistics.Entity
{
    /// <summary>操作日志</summary>
    [Serializable]
    [DataObject]
    [Description("操作日志")]
    [BindTable("OperationLog", Description = "操作日志", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class OperationLog
    {
        #region 属性
        private Int32 _LogId;
        /// <summary>日志编号</summary>
        [DisplayName("日志编号")]
        [Description("日志编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("LogId", "日志编号", "int")]
        public Int32 LogId { get => _LogId; set { if (OnPropertyChanging("LogId", value)) { _LogId = value; OnPropertyChanged("LogId"); } } }

        private Int32 _UserId;
        /// <summary>用户编码</summary>
        [DisplayName("用户编码")]
        [Description("用户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("UserId", "用户编码", "int")]
        public Int32 UserId { get => _UserId; set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } } }

        private String _Detail;
        /// <summary>详情</summary>
        [DisplayName("详情")]
        [Description("详情")]
        [DataObjectField(false, false, true, 250)]
        [BindColumn("Detail", "详情", "nvarchar(250)")]
        public String Detail { get => _Detail; set { if (OnPropertyChanging("Detail", value)) { _Detail = value; OnPropertyChanged("Detail"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [DisplayName("拥有者")]
        [Description("拥有者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "拥有者", "nvarchar(50)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Remark", "备注", "nvarchar(50)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private String _IP;
        /// <summary>IP</summary>
        [DisplayName("IP")]
        [Description("IP")]
        [DataObjectField(false, false, true, 250)]
        [BindColumn("IP", "IP", "nvarchar(250)")]
        public String IP { get => _IP; set { if (OnPropertyChanging("IP", value)) { _IP = value; OnPropertyChanged("IP"); } } }

        private String _Url;
        /// <summary>URL</summary>
        [DisplayName("URL")]
        [Description("URL")]
        [DataObjectField(false, false, true, 250)]
        [BindColumn("URL", "URL", "nvarchar(250)")]
        public String Url { get => _Url; set { if (OnPropertyChanging("Url", value)) { _Url = value; OnPropertyChanged("Url"); } } }
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
                    case "LogId": return _LogId;
                    case "UserId": return _UserId;
                    case "Detail": return _Detail;
                    case "Deleted": return _Deleted;
                    case "TenantId": return _TenantId;
                    case "CreateTime": return _CreateTime;
                    case "Owner": return _Owner;
                    case "Remark": return _Remark;
                    case "IP": return _IP;
                    case "Url": return _Url;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "LogId": _LogId = value.ToInt(); break;
                    case "UserId": _UserId = value.ToInt(); break;
                    case "Detail": _Detail = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "IP": _IP = Convert.ToString(value); break;
                    case "Url": _Url = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得操作日志字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>日志编号</summary>
            public static readonly Field LogId = FindByName("LogId");

            /// <summary>用户编码</summary>
            public static readonly Field UserId = FindByName("UserId");

            /// <summary>用户名称</summary>
            public static readonly Field UserName = FindByName("UserName");

            /// <summary>详情</summary>
            public static readonly Field Detail = FindByName("Detail");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>IP</summary>
            public static readonly Field IP = FindByName("IP");

            /// <summary>URL</summary>
            public static readonly Field Url = FindByName("Url");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得操作日志字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>日志编号</summary>
            public const String LogId = "LogId";

            /// <summary>用户编码</summary>
            public const String UserId = "UserId";

            /// <summary>用户名称</summary>
            public const String UserName = "UserName";

            /// <summary>详情</summary>
            public const String Detail = "Detail";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>IP</summary>
            public const String IP = "IP";

            /// <summary>URL</summary>
            public const String Url = "Url";
        }
        #endregion
    }
}