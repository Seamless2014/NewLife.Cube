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
    /// <summary>上线统计。统计企业在线车辆数、在线率等信息</summary>
    [Serializable]
    [DataObject]
    [Description("上线统计。统计企业在线车辆数、在线率等信息")]
    [BindIndex("IU_OnlineStatic_DepName", true, "DepName")]
    [BindTable("OnlineStatic", Description = "上线统计。统计企业在线车辆数、在线率等信息", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class OnlineStatic
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "编号", "")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private Int32 _DepId;
        /// <summary>部门编码</summary>
        [DisplayName("部门编码")]
        [Description("部门编码")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("DepId", "部门编码", "")]
        public Int32 DepId { get => _DepId; set { if (OnPropertyChanging("DepId", value)) { _DepId = value; OnPropertyChanged("DepId"); } } }

        private Int32 _OnlineNum;
        /// <summary>在线数</summary>
        [DisplayName("在线数")]
        [Description("在线数")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("OnlineNum", "在线数", "")]
        public Int32 OnlineNum { get => _OnlineNum; set { if (OnPropertyChanging("OnlineNum", value)) { _OnlineNum = value; OnPropertyChanged("OnlineNum"); } } }

        private Int32 _VehicleNum;
        /// <summary>车辆数</summary>
        [DisplayName("车辆数")]
        [Description("车辆数")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("VehicleNum", "车辆数", "")]
        public Int32 VehicleNum { get => _VehicleNum; set { if (OnPropertyChanging("VehicleNum", value)) { _VehicleNum = value; OnPropertyChanged("VehicleNum"); } } }

        private Decimal _OnlineRate;
        /// <summary>在线率</summary>
        [DisplayName("在线率")]
        [Description("在线率")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("OnlineRate", "在线率", "decimal(10, 2)", Precision = 0, Scale = 2)]
        public Decimal OnlineRate { get => _OnlineRate; set { if (OnPropertyChanging("OnlineRate", value)) { _OnlineRate = value; OnPropertyChanged("OnlineRate"); } } }

        private DateTime _StatisticDate;
        /// <summary>统计日期</summary>
        [DisplayName("统计日期")]
        [Description("统计日期")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("StatisticDate", "统计日期", "", Precision = 0, Scale = 3)]
        public DateTime StatisticDate { get => _StatisticDate; set { if (OnPropertyChanging("StatisticDate", value)) { _StatisticDate = value; OnPropertyChanged("StatisticDate"); } } }

        private Int32 _IntervalType;
        /// <summary>间隔类型</summary>
        [DisplayName("间隔类型")]
        [Description("间隔类型")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("IntervalType", "间隔类型", "")]
        public Int32 IntervalType { get => _IntervalType; set { if (OnPropertyChanging("IntervalType", value)) { _IntervalType = value; OnPropertyChanged("IntervalType"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TenantId", "租户编码", "")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [DisplayName("拥有者")]
        [Description("拥有者")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("Owner", "拥有者", "")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Int32 _ParentDepId;
        /// <summary>上级部门编码</summary>
        [DisplayName("上级部门编码")]
        [Description("上级部门编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("ParentDepId", "上级部门编码", "")]
        public Int32 ParentDepId { get => _ParentDepId; set { if (OnPropertyChanging("ParentDepId", value)) { _ParentDepId = value; OnPropertyChanged("ParentDepId"); } } }

        private DateTime _StatisticTime;
        /// <summary>统计时间</summary>
        [DisplayName("统计时间")]
        [Description("统计时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("StatisticTime", "统计时间", "", Precision = 0, Scale = 3)]
        public DateTime StatisticTime { get => _StatisticTime; set { if (OnPropertyChanging("StatisticTime", value)) { _StatisticTime = value; OnPropertyChanged("StatisticTime"); } } }

        private Int32 _Interval;
        /// <summary>间隔</summary>
        [DisplayName("间隔")]
        [Description("间隔")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Interval", "间隔", "")]
        public Int32 Interval { get => _Interval; set { if (OnPropertyChanging("Interval", value)) { _Interval = value; OnPropertyChanged("Interval"); } } }

        private String _Remark;
        /// <summary>备注</summary>
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
                    case "Id": return _Id;
                    case "DepId": return _DepId;
                    case "OnlineNum": return _OnlineNum;
                    case "VehicleNum": return _VehicleNum;
                    case "OnlineRate": return _OnlineRate;
                    case "StatisticDate": return _StatisticDate;
                    case "IntervalType": return _IntervalType;
                    case "TenantId": return _TenantId;
                    case "Remark": return _Remark;
                    case "Owner": return _Owner;
                    case "CreateTime": return _CreateTime;
                    case "ParentDepId": return _ParentDepId;
                    case "StatisticTime": return _StatisticTime;
                    case "Interval": return _Interval;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "DepId": _DepId = value.ToInt(); break;
                    case "OnlineNum": _OnlineNum = value.ToInt(); break;
                    case "VehicleNum": _VehicleNum = value.ToInt(); break;
                    case "OnlineRate": _OnlineRate = Convert.ToDecimal(value); break;
                    case "StatisticDate": _StatisticDate = value.ToDateTime(); break;
                    case "IntervalType": _IntervalType = value.ToInt(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "ParentDepId": _ParentDepId = value.ToInt(); break;
                    case "StatisticTime": _StatisticTime = value.ToDateTime(); break;
                    case "Interval": _Interval = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得上线统计字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary>部门编码</summary>
            public static readonly Field DepId = FindByName("DepId");

            /// <summary>部门名称</summary>
            public static readonly Field DepName = FindByName("DepName");

            /// <summary>在线数</summary>
            public static readonly Field OnlineNum = FindByName("OnlineNum");

            /// <summary>车辆数</summary>
            public static readonly Field VehicleNum = FindByName("VehicleNum");

            /// <summary>在线率</summary>
            public static readonly Field OnlineRate = FindByName("OnlineRate");

            /// <summary>统计日期</summary>
            public static readonly Field StatisticDate = FindByName("StatisticDate");

            /// <summary>间隔类型</summary>
            public static readonly Field IntervalType = FindByName("IntervalType");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>上级部门编码</summary>
            public static readonly Field ParentDepId = FindByName("ParentDepId");

            /// <summary>统计时间</summary>
            public static readonly Field StatisticTime = FindByName("StatisticTime");

            /// <summary>间隔</summary>
            public static readonly Field Interval = FindByName("Interval");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得上线统计字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String Id = "Id";

            /// <summary>部门编码</summary>
            public const String DepId = "DepId";

            /// <summary>部门名称</summary>
            public const String DepName = "DepName";

            /// <summary>在线数</summary>
            public const String OnlineNum = "OnlineNum";

            /// <summary>车辆数</summary>
            public const String VehicleNum = "VehicleNum";

            /// <summary>在线率</summary>
            public const String OnlineRate = "OnlineRate";

            /// <summary>统计日期</summary>
            public const String StatisticDate = "StatisticDate";

            /// <summary>间隔类型</summary>
            public const String IntervalType = "IntervalType";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>上级部门编码</summary>
            public const String ParentDepId = "ParentDepId";

            /// <summary>统计时间</summary>
            public const String StatisticTime = "StatisticTime";

            /// <summary>间隔</summary>
            public const String Interval = "Interval";
        }
        #endregion
    }
}