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
    /// <summary>GPS里程</summary>
    [Serializable]
    [DataObject]
    [Description("GPS里程")]
    [BindTable("GpsMileage", Description = "GPS里程", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class GpsMileage
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("Id", "编码", "int")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Byte _Deleted;
        /// <summary>删除</summary>
        [Category("扩展信息")]
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("Deleted", "删除", "tinyint")]
        public Byte Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [Category("扩展信息")]
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Owner", "物主", "varchar(255)")]
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
        [DataObjectField(false, false, false, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private Double _GasLastComp;
        /// <summary>油气最后比较</summary>
        [DisplayName("油气最后比较")]
        [Description("油气最后比较")]
        [DataObjectField(false, false, false, 53)]
        [BindColumn("GasLastComp", "油气最后比较", "float")]
        public Double GasLastComp { get => _GasLastComp; set { if (OnPropertyChanging("GasLastComp", value)) { _GasLastComp = value; OnPropertyChanged("GasLastComp"); } } }

        private Double _GasLastDay;
        /// <summary>油气最后天数</summary>
        [DisplayName("油气最后天数")]
        [Description("油气最后天数")]
        [DataObjectField(false, false, false, 53)]
        [BindColumn("GasLastDay", "油气最后天数", "float")]
        public Double GasLastDay { get => _GasLastDay; set { if (OnPropertyChanging("GasLastDay", value)) { _GasLastDay = value; OnPropertyChanged("GasLastDay"); } } }

        private Double _GasLastHour;
        /// <summary>油气最后小时数</summary>
        [DisplayName("油气最后小时数")]
        [Description("油气最后小时数")]
        [DataObjectField(false, false, false, 53)]
        [BindColumn("GasLastHour", "油气最后小时数", "float")]
        public Double GasLastHour { get => _GasLastHour; set { if (OnPropertyChanging("GasLastHour", value)) { _GasLastHour = value; OnPropertyChanged("GasLastHour"); } } }

        private Double _GasLastMonth;
        /// <summary>油气最后月数</summary>
        [DisplayName("油气最后月数")]
        [Description("油气最后月数")]
        [DataObjectField(false, false, false, 53)]
        [BindColumn("GasLastMonth", "油气最后月数", "float")]
        public Double GasLastMonth { get => _GasLastMonth; set { if (OnPropertyChanging("GasLastMonth", value)) { _GasLastMonth = value; OnPropertyChanged("GasLastMonth"); } } }

        private DateTime _LastCompTime;
        /// <summary>最后比较时间</summary>
        [DisplayName("最后比较时间")]
        [Description("最后比较时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("LastCompTime", "最后比较时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime LastCompTime { get => _LastCompTime; set { if (OnPropertyChanging("LastCompTime", value)) { _LastCompTime = value; OnPropertyChanged("LastCompTime"); } } }

        private Double _MileageLastComp;
        /// <summary>最后比较里程</summary>
        [DisplayName("最后比较里程")]
        [Description("最后比较里程")]
        [DataObjectField(false, false, false, 53)]
        [BindColumn("MileageLastComp", "最后比较里程", "float")]
        public Double MileageLastComp { get => _MileageLastComp; set { if (OnPropertyChanging("MileageLastComp", value)) { _MileageLastComp = value; OnPropertyChanged("MileageLastComp"); } } }

        private Double _MileageLastDay;
        /// <summary>里程最后天数</summary>
        [DisplayName("里程最后天数")]
        [Description("里程最后天数")]
        [DataObjectField(false, false, false, 53)]
        [BindColumn("MileageLastDay", "里程最后天数", "float")]
        public Double MileageLastDay { get => _MileageLastDay; set { if (OnPropertyChanging("MileageLastDay", value)) { _MileageLastDay = value; OnPropertyChanged("MileageLastDay"); } } }

        private Double _MileageLastHour;
        /// <summary>里程最后小时数</summary>
        [DisplayName("里程最后小时数")]
        [Description("里程最后小时数")]
        [DataObjectField(false, false, false, 53)]
        [BindColumn("MileageLastHour", "里程最后小时数", "float")]
        public Double MileageLastHour { get => _MileageLastHour; set { if (OnPropertyChanging("MileageLastHour", value)) { _MileageLastHour = value; OnPropertyChanged("MileageLastHour"); } } }

        private Double _MileageLastMonth;
        /// <summary>里程最后月数</summary>
        [DisplayName("里程最后月数")]
        [Description("里程最后月数")]
        [DataObjectField(false, false, false, 53)]
        [BindColumn("MileageLastMonth", "里程最后月数", "float")]
        public Double MileageLastMonth { get => _MileageLastMonth; set { if (OnPropertyChanging("MileageLastMonth", value)) { _MileageLastMonth = value; OnPropertyChanged("MileageLastMonth"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("PlateNo", "车牌号", "varchar(255)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }
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
                    case "CreateTime": return _CreateTime;
                    case "Deleted": return _Deleted;
                    case "Owner": return _Owner;
                    case "Remark": return _Remark;
                    case "TenantId": return _TenantId;
                    case "GasLastComp": return _GasLastComp;
                    case "GasLastDay": return _GasLastDay;
                    case "GasLastHour": return _GasLastHour;
                    case "GasLastMonth": return _GasLastMonth;
                    case "LastCompTime": return _LastCompTime;
                    case "MileageLastComp": return _MileageLastComp;
                    case "MileageLastDay": return _MileageLastDay;
                    case "MileageLastHour": return _MileageLastHour;
                    case "MileageLastMonth": return _MileageLastMonth;
                    case "PlateNo": return _PlateNo;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Deleted": _Deleted = Convert.ToByte(value); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "GasLastComp": _GasLastComp = value.ToDouble(); break;
                    case "GasLastDay": _GasLastDay = value.ToDouble(); break;
                    case "GasLastHour": _GasLastHour = value.ToDouble(); break;
                    case "GasLastMonth": _GasLastMonth = value.ToDouble(); break;
                    case "LastCompTime": _LastCompTime = value.ToDateTime(); break;
                    case "MileageLastComp": _MileageLastComp = value.ToDouble(); break;
                    case "MileageLastDay": _MileageLastDay = value.ToDouble(); break;
                    case "MileageLastHour": _MileageLastHour = value.ToDouble(); break;
                    case "MileageLastMonth": _MileageLastMonth = value.ToDouble(); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得GPS里程字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编码</summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>油气最后比较</summary>
            public static readonly Field GasLastComp = FindByName("GasLastComp");

            /// <summary>油气最后天数</summary>
            public static readonly Field GasLastDay = FindByName("GasLastDay");

            /// <summary>油气最后小时数</summary>
            public static readonly Field GasLastHour = FindByName("GasLastHour");

            /// <summary>油气最后月数</summary>
            public static readonly Field GasLastMonth = FindByName("GasLastMonth");

            /// <summary>最后比较时间</summary>
            public static readonly Field LastCompTime = FindByName("LastCompTime");

            /// <summary>最后比较里程</summary>
            public static readonly Field MileageLastComp = FindByName("MileageLastComp");

            /// <summary>里程最后天数</summary>
            public static readonly Field MileageLastDay = FindByName("MileageLastDay");

            /// <summary>里程最后小时数</summary>
            public static readonly Field MileageLastHour = FindByName("MileageLastHour");

            /// <summary>里程最后月数</summary>
            public static readonly Field MileageLastMonth = FindByName("MileageLastMonth");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得GPS里程字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编码</summary>
            public const String Id = "Id";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>油气最后比较</summary>
            public const String GasLastComp = "GasLastComp";

            /// <summary>油气最后天数</summary>
            public const String GasLastDay = "GasLastDay";

            /// <summary>油气最后小时数</summary>
            public const String GasLastHour = "GasLastHour";

            /// <summary>油气最后月数</summary>
            public const String GasLastMonth = "GasLastMonth";

            /// <summary>最后比较时间</summary>
            public const String LastCompTime = "LastCompTime";

            /// <summary>最后比较里程</summary>
            public const String MileageLastComp = "MileageLastComp";

            /// <summary>里程最后天数</summary>
            public const String MileageLastDay = "MileageLastDay";

            /// <summary>里程最后小时数</summary>
            public const String MileageLastHour = "MileageLastHour";

            /// <summary>里程最后月数</summary>
            public const String MileageLastMonth = "MileageLastMonth";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";
        }
        #endregion
    }
}