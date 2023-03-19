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
    /// <summary>报警统计</summary>
    [Serializable]
    [DataObject]
    [Description("报警统计")]
    [BindTable("AlarmStatic", Description = "报警统计", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class AlarmStatic
    {
        #region 属性
        private Int32 _StatisticsId;
        /// <summary>统计编码</summary>
        [DisplayName("统计编码")]
        [Description("统计编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("StatisticsId", "统计编码", "int")]
        public Int32 StatisticsId { get => _StatisticsId; set { if (OnPropertyChanging("StatisticsId", value)) { _StatisticsId = value; OnPropertyChanged("StatisticsId"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(20)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private String _AlarmType;
        /// <summary>报警类型</summary>
        [DisplayName("报警类型")]
        [Description("报警类型")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("AlarmType", "报警类型", "nvarchar(50)")]
        public String AlarmType { get => _AlarmType; set { if (OnPropertyChanging("AlarmType", value)) { _AlarmType = value; OnPropertyChanged("AlarmType"); } } }

        private Int32 _AlarmNum;
        /// <summary>报警数</summary>
        [DisplayName("报警数")]
        [Description("报警数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("AlarmNum", "报警数", "int")]
        public Int32 AlarmNum { get => _AlarmNum; set { if (OnPropertyChanging("AlarmNum", value)) { _AlarmNum = value; OnPropertyChanged("AlarmNum"); } } }

        private String _StatisticsDate;
        /// <summary>统计日期</summary>
        [DisplayName("统计日期")]
        [Description("统计日期")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("StatisticsDate", "统计日期", "nchar(10)")]
        public String StatisticsDate { get => _StatisticsDate; set { if (OnPropertyChanging("StatisticsDate", value)) { _StatisticsDate = value; OnPropertyChanged("StatisticsDate"); } } }

        private Int32 _StatisticsType;
        /// <summary>统计类型</summary>
        [DisplayName("统计类型")]
        [Description("统计类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("StatisticsType", "统计类型", "int")]
        public Int32 StatisticsType { get => _StatisticsType; set { if (OnPropertyChanging("StatisticsType", value)) { _StatisticsType = value; OnPropertyChanged("StatisticsType"); } } }
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
                    case "StatisticsId": return _StatisticsId;
                    case "PlateNo": return _PlateNo;
                    case "AlarmType": return _AlarmType;
                    case "AlarmNum": return _AlarmNum;
                    case "StatisticsDate": return _StatisticsDate;
                    case "StatisticsType": return _StatisticsType;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "StatisticsId": _StatisticsId = value.ToInt(); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "AlarmType": _AlarmType = Convert.ToString(value); break;
                    case "AlarmNum": _AlarmNum = value.ToInt(); break;
                    case "StatisticsDate": _StatisticsDate = Convert.ToString(value); break;
                    case "StatisticsType": _StatisticsType = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得报警统计字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>统计编码</summary>
            public static readonly Field StatisticsId = FindByName("StatisticsId");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>报警类型</summary>
            public static readonly Field AlarmType = FindByName("AlarmType");

            /// <summary>报警数</summary>
            public static readonly Field AlarmNum = FindByName("AlarmNum");

            /// <summary>统计日期</summary>
            public static readonly Field StatisticsDate = FindByName("StatisticsDate");

            /// <summary>统计类型</summary>
            public static readonly Field StatisticsType = FindByName("StatisticsType");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得报警统计字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>统计编码</summary>
            public const String StatisticsId = "StatisticsId";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>报警类型</summary>
            public const String AlarmType = "AlarmType";

            /// <summary>报警数</summary>
            public const String AlarmNum = "AlarmNum";

            /// <summary>统计日期</summary>
            public const String StatisticsDate = "StatisticsDate";

            /// <summary>统计类型</summary>
            public const String StatisticsType = "StatisticsType";
        }
        #endregion
    }
}