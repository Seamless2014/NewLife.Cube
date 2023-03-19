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
    /// <summary>里程统计</summary>
    [Serializable]
    [DataObject]
    [Description("里程统计")]
    [BindTable("MileageStatistic", Description = "里程统计", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class MileageStatistic
    {
        #region 属性
        private Int32 _FunctionId;
        /// <summary>功能编码</summary>
        [DisplayName("功能编码")]
        [Description("功能编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("FunctionId", "功能编码", "int")]
        public Int32 FunctionId { get => _FunctionId; set { if (OnPropertyChanging("FunctionId", value)) { _FunctionId = value; OnPropertyChanged("FunctionId"); } } }

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
        /// <summary>静态日期</summary>
        [DisplayName("静态日期")]
        [Description("静态日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("StaticDate", "静态日期", "datetime", Precision = 0, Scale = 3)]
        public DateTime StaticDate { get => _StaticDate; set { if (OnPropertyChanging("StaticDate", value)) { _StaticDate = value; OnPropertyChanged("StaticDate"); } } }

        private Int32 _IntervalType;
        /// <summary>间隔类型</summary>
        [DisplayName("间隔类型")]
        [Description("间隔类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("IntervalType", "间隔类型", "int")]
        public Int32 IntervalType { get => _IntervalType; set { if (OnPropertyChanging("IntervalType", value)) { _IntervalType = value; OnPropertyChanged("IntervalType"); } } }

        private Double _Mileage;
        /// <summary>里程</summary>
        [DisplayName("里程")]
        [Description("里程")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Mileage", "里程", "float")]
        public Double Mileage { get => _Mileage; set { if (OnPropertyChanging("Mileage", value)) { _Mileage = value; OnPropertyChanged("Mileage"); } } }

        private Double _Oil;
        /// <summary>油气</summary>
        [DisplayName("油气")]
        [Description("油气")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Oil", "油气", "float")]
        public Double Oil { get => _Oil; set { if (OnPropertyChanging("Oil", value)) { _Oil = value; OnPropertyChanged("Oil"); } } }

        private Double _Oil1;
        /// <summary>油气1</summary>
        [DisplayName("油气1")]
        [Description("油气1")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Oil1", "油气1", "float")]
        public Double Oil1 { get => _Oil1; set { if (OnPropertyChanging("Oil1", value)) { _Oil1 = value; OnPropertyChanged("Oil1"); } } }

        private Double _Oil2;
        /// <summary>油气2</summary>
        [DisplayName("油气2")]
        [Description("油气2")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Oil2", "油气2", "float")]
        public Double Oil2 { get => _Oil2; set { if (OnPropertyChanging("Oil2", value)) { _Oil2 = value; OnPropertyChanged("Oil2"); } } }

        private Double _Mileage1;
        /// <summary>里程1</summary>
        [DisplayName("里程1")]
        [Description("里程1")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Mileage1", "里程1", "float")]
        public Double Mileage1 { get => _Mileage1; set { if (OnPropertyChanging("Mileage1", value)) { _Mileage1 = value; OnPropertyChanged("Mileage1"); } } }

        private Double _Mileage2;
        /// <summary>里程2</summary>
        [DisplayName("里程2")]
        [Description("里程2")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Mileage2", "里程2", "float")]
        public Double Mileage2 { get => _Mileage2; set { if (OnPropertyChanging("Mileage2", value)) { _Mileage2 = value; OnPropertyChanged("Mileage2"); } } }

        private String _DepName;
        /// <summary>部门名称</summary>
        [DisplayName("部门名称")]
        [Description("部门名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("DepName", "部门名称", "nvarchar(255)")]
        public String DepName { get => _DepName; set { if (OnPropertyChanging("DepName", value)) { _DepName = value; OnPropertyChanged("DepName"); } } }

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
        /// <summary>物主</summary>
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Owner", "物主", "nvarchar(255)")]
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
                    case "FunctionId": return _FunctionId;
                    case "PlateNo": return _PlateNo;
                    case "IntervalDescr": return _IntervalDescr;
                    case "Hour": return _Hour;
                    case "StaticDate": return _StaticDate;
                    case "IntervalType": return _IntervalType;
                    case "Mileage": return _Mileage;
                    case "Oil": return _Oil;
                    case "Oil1": return _Oil1;
                    case "Oil2": return _Oil2;
                    case "Mileage1": return _Mileage1;
                    case "Mileage2": return _Mileage2;
                    case "DepName": return _DepName;
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
                    case "FunctionId": _FunctionId = value.ToInt(); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "IntervalDescr": _IntervalDescr = Convert.ToString(value); break;
                    case "Hour": _Hour = value.ToDouble(); break;
                    case "StaticDate": _StaticDate = value.ToDateTime(); break;
                    case "IntervalType": _IntervalType = value.ToInt(); break;
                    case "Mileage": _Mileage = value.ToDouble(); break;
                    case "Oil": _Oil = value.ToDouble(); break;
                    case "Oil1": _Oil1 = value.ToDouble(); break;
                    case "Oil2": _Oil2 = value.ToDouble(); break;
                    case "Mileage1": _Mileage1 = value.ToDouble(); break;
                    case "Mileage2": _Mileage2 = value.ToDouble(); break;
                    case "DepName": _DepName = Convert.ToString(value); break;
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
        /// <summary>取得里程统计字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>功能编码</summary>
            public static readonly Field FunctionId = FindByName("FunctionId");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>间隔描述</summary>
            public static readonly Field IntervalDescr = FindByName("IntervalDescr");

            /// <summary>小时</summary>
            public static readonly Field Hour = FindByName("Hour");

            /// <summary>静态日期</summary>
            public static readonly Field StaticDate = FindByName("StaticDate");

            /// <summary>间隔类型</summary>
            public static readonly Field IntervalType = FindByName("IntervalType");

            /// <summary>里程</summary>
            public static readonly Field Mileage = FindByName("Mileage");

            /// <summary>油气</summary>
            public static readonly Field Oil = FindByName("Oil");

            /// <summary>油气1</summary>
            public static readonly Field Oil1 = FindByName("Oil1");

            /// <summary>油气2</summary>
            public static readonly Field Oil2 = FindByName("Oil2");

            /// <summary>里程1</summary>
            public static readonly Field Mileage1 = FindByName("Mileage1");

            /// <summary>里程2</summary>
            public static readonly Field Mileage2 = FindByName("Mileage2");

            /// <summary>部门名称</summary>
            public static readonly Field DepName = FindByName("DepName");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得里程统计字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>功能编码</summary>
            public const String FunctionId = "FunctionId";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>间隔描述</summary>
            public const String IntervalDescr = "IntervalDescr";

            /// <summary>小时</summary>
            public const String Hour = "Hour";

            /// <summary>静态日期</summary>
            public const String StaticDate = "StaticDate";

            /// <summary>间隔类型</summary>
            public const String IntervalType = "IntervalType";

            /// <summary>里程</summary>
            public const String Mileage = "Mileage";

            /// <summary>油气</summary>
            public const String Oil = "Oil";

            /// <summary>油气1</summary>
            public const String Oil1 = "Oil1";

            /// <summary>油气2</summary>
            public const String Oil2 = "Oil2";

            /// <summary>里程1</summary>
            public const String Mileage1 = "Mileage1";

            /// <summary>里程2</summary>
            public const String Mileage2 = "Mileage2";

            /// <summary>部门名称</summary>
            public const String DepName = "DepName";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>物主</summary>
            public const String Owner = "Owner";
        }
        #endregion
    }
}