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
    /// <summary>车辆上线率</summary>
    [Serializable]
    [DataObject]
    [Description("车辆上线率")]
    [BindTable("VehicleOnlineRate", Description = "车辆上线率", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class VehicleOnlineRate
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("ID", "编号", "int")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(255)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private String _IntervalDescr;
        /// <summary>间隔描述</summary>
        [DisplayName("间隔描述")]
        [Description("间隔描述")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("IntervalDescr", "间隔描述", "nvarchar(255)")]
        public String IntervalDescr { get => _IntervalDescr; set { if (OnPropertyChanging("IntervalDescr", value)) { _IntervalDescr = value; OnPropertyChanged("IntervalDescr"); } } }

        private Double _Hour;
        /// <summary>小时</summary>
        [DisplayName("小时")]
        [Description("小时")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Hour", "小时", "float")]
        public Double Hour { get => _Hour; set { if (OnPropertyChanging("Hour", value)) { _Hour = value; OnPropertyChanged("Hour"); } } }

        private DateTime _StaticDate;
        /// <summary>静态时间</summary>
        [DisplayName("静态时间")]
        [Description("静态时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("StaticDate", "静态时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime StaticDate { get => _StaticDate; set { if (OnPropertyChanging("StaticDate", value)) { _StaticDate = value; OnPropertyChanged("StaticDate"); } } }

        private Decimal _OnlineTime;
        /// <summary>上线时间</summary>
        [DisplayName("上线时间")]
        [Description("上线时间")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn("OnlineTime", "上线时间", "decimal(18, 2)", Precision = 0, Scale = 2)]
        public Decimal OnlineTime { get => _OnlineTime; set { if (OnPropertyChanging("OnlineTime", value)) { _OnlineTime = value; OnPropertyChanged("OnlineTime"); } } }

        private Int32 _IntervalType;
        /// <summary>间隔类型</summary>
        [DisplayName("间隔类型")]
        [Description("间隔类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("IntervalType", "间隔类型", "int")]
        public Int32 IntervalType { get => _IntervalType; set { if (OnPropertyChanging("IntervalType", value)) { _IntervalType = value; OnPropertyChanged("IntervalType"); } } }

        private Decimal _OfflineTime;
        /// <summary>离线时间</summary>
        [DisplayName("离线时间")]
        [Description("离线时间")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn("OfflineTime", "离线时间", "decimal(18, 2)", Precision = 0, Scale = 2)]
        public Decimal OfflineTime { get => _OfflineTime; set { if (OnPropertyChanging("OfflineTime", value)) { _OfflineTime = value; OnPropertyChanged("OfflineTime"); } } }

        private Double _TotalTime;
        /// <summary>总计时间</summary>
        [DisplayName("总计时间")]
        [Description("总计时间")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("TotalTime", "总计时间", "float")]
        public Double TotalTime { get => _TotalTime; set { if (OnPropertyChanging("TotalTime", value)) { _TotalTime = value; OnPropertyChanged("TotalTime"); } } }

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

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private Decimal _OnlineRate;
        /// <summary>上线日期</summary>
        [DisplayName("上线日期")]
        [Description("上线日期")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn("OnlineRate", "上线日期", "decimal(18, 2)", Precision = 0, Scale = 2)]
        public Decimal OnlineRate { get => _OnlineRate; set { if (OnPropertyChanging("OnlineRate", value)) { _OnlineRate = value; OnPropertyChanged("OnlineRate"); } } }

        private String _CreateUser;
        /// <summary>创建者</summary>
        [DisplayName("创建者")]
        [Description("创建者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateUser", "创建者", "nvarchar(50)")]
        public String CreateUser { get => _CreateUser; set { if (OnPropertyChanging("CreateUser", value)) { _CreateUser = value; OnPropertyChanged("CreateUser"); } } }

        private Int32 _CreateUserID;
        /// <summary>创建人</summary>
        [DisplayName("创建人")]
        [Description("创建人")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("CreateUserID", "创建人", "int")]
        public Int32 CreateUserID { get => _CreateUserID; set { if (OnPropertyChanging("CreateUserID", value)) { _CreateUserID = value; OnPropertyChanged("CreateUserID"); } } }

        private String _CreateIP;
        /// <summary>创建地址</summary>
        [DisplayName("创建地址")]
        [Description("创建地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateIP", "创建地址", "nvarchar(50)")]
        public String CreateIP { get => _CreateIP; set { if (OnPropertyChanging("CreateIP", value)) { _CreateIP = value; OnPropertyChanged("CreateIP"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _UpdateUser;
        /// <summary>更新者</summary>
        [DisplayName("更新者")]
        [Description("更新者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateUser", "更新者", "nvarchar(50)")]
        public String UpdateUser { get => _UpdateUser; set { if (OnPropertyChanging("UpdateUser", value)) { _UpdateUser = value; OnPropertyChanged("UpdateUser"); } } }

        private Int32 _UpdateUserID;
        /// <summary>更新人</summary>
        [DisplayName("更新人")]
        [Description("更新人")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("UpdateUserID", "更新人", "int")]
        public Int32 UpdateUserID { get => _UpdateUserID; set { if (OnPropertyChanging("UpdateUserID", value)) { _UpdateUserID = value; OnPropertyChanged("UpdateUserID"); } } }

        private String _UpdateIP;
        /// <summary>更新地址</summary>
        [DisplayName("更新地址")]
        [Description("更新地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateIP", "更新地址", "nvarchar(50)")]
        public String UpdateIP { get => _UpdateIP; set { if (OnPropertyChanging("UpdateIP", value)) { _UpdateIP = value; OnPropertyChanged("UpdateIP"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateTime", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private String _Remark;
        /// <summary>备注</summary>
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
                    case "ID": return _ID;
                    case "PlateNo": return _PlateNo;
                    case "IntervalDescr": return _IntervalDescr;
                    case "Hour": return _Hour;
                    case "StaticDate": return _StaticDate;
                    case "OnlineTime": return _OnlineTime;
                    case "IntervalType": return _IntervalType;
                    case "OfflineTime": return _OfflineTime;
                    case "TotalTime": return _TotalTime;
                    case "Deleted": return _Deleted;
                    case "Owner": return _Owner;
                    case "TenantId": return _TenantId;
                    case "OnlineRate": return _OnlineRate;
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
                    case "ID": _ID = value.ToInt(); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "IntervalDescr": _IntervalDescr = Convert.ToString(value); break;
                    case "Hour": _Hour = value.ToDouble(); break;
                    case "StaticDate": _StaticDate = value.ToDateTime(); break;
                    case "OnlineTime": _OnlineTime = Convert.ToDecimal(value); break;
                    case "IntervalType": _IntervalType = value.ToInt(); break;
                    case "OfflineTime": _OfflineTime = Convert.ToDecimal(value); break;
                    case "TotalTime": _TotalTime = value.ToDouble(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "OnlineRate": _OnlineRate = Convert.ToDecimal(value); break;
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
        /// <summary>取得车辆上线率字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>间隔描述</summary>
            public static readonly Field IntervalDescr = FindByName("IntervalDescr");

            /// <summary>小时</summary>
            public static readonly Field Hour = FindByName("Hour");

            /// <summary>静态时间</summary>
            public static readonly Field StaticDate = FindByName("StaticDate");

            /// <summary>上线时间</summary>
            public static readonly Field OnlineTime = FindByName("OnlineTime");

            /// <summary>间隔类型</summary>
            public static readonly Field IntervalType = FindByName("IntervalType");

            /// <summary>离线时间</summary>
            public static readonly Field OfflineTime = FindByName("OfflineTime");

            /// <summary>总计时间</summary>
            public static readonly Field TotalTime = FindByName("TotalTime");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>上线日期</summary>
            public static readonly Field OnlineRate = FindByName("OnlineRate");

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

        /// <summary>取得车辆上线率字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String ID = "ID";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>间隔描述</summary>
            public const String IntervalDescr = "IntervalDescr";

            /// <summary>小时</summary>
            public const String Hour = "Hour";

            /// <summary>静态时间</summary>
            public const String StaticDate = "StaticDate";

            /// <summary>上线时间</summary>
            public const String OnlineTime = "OnlineTime";

            /// <summary>间隔类型</summary>
            public const String IntervalType = "IntervalType";

            /// <summary>离线时间</summary>
            public const String OfflineTime = "OfflineTime";

            /// <summary>总计时间</summary>
            public const String TotalTime = "TotalTime";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>上线日期</summary>
            public const String OnlineRate = "OnlineRate";

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