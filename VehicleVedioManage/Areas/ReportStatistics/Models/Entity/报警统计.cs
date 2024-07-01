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
    [BindIndex("IU_AlarmStatic_PlateNo", true, "PlateNo")]
    [BindTable("AlarmStatic", Description = "报警统计", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class AlarmStatic
    {
        #region 属性
        private Int32 _StatisticsId;
        /// <summary>统计编码</summary>
        [DisplayName("统计编码")]
        [Description("统计编码")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("StatisticsId", "统计编码", "")]
        public Int32 StatisticsId { get => _StatisticsId; set { if (OnPropertyChanging("StatisticsId", value)) { _StatisticsId = value; OnPropertyChanged("StatisticsId"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("PlateNo", "车牌号", "")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private String _AlarmType;
        /// <summary>报警类型</summary>
        [DisplayName("报警类型")]
        [Description("报警类型")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("AlarmType", "报警类型", "")]
        public String AlarmType { get => _AlarmType; set { if (OnPropertyChanging("AlarmType", value)) { _AlarmType = value; OnPropertyChanged("AlarmType"); } } }

        private Int32 _AlarmNum;
        /// <summary>报警数</summary>
        [DisplayName("报警数")]
        [Description("报警数")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AlarmNum", "报警数", "")]
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
        [DataObjectField(false, false, true, 0)]
        [BindColumn("StatisticsType", "统计类型", "")]
        public Int32 StatisticsType { get => _StatisticsType; set { if (OnPropertyChanging("StatisticsType", value)) { _StatisticsType = value; OnPropertyChanged("StatisticsType"); } } }

        private Int32 _DepID;
        /// <summary>部门ID</summary>
        [DisplayName("部门ID")]
        [Description("部门ID")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("DepID", "部门ID", "int")]
        public Int32 DepID { get => _DepID; set { if (OnPropertyChanging("DepID", value)) { _DepID = value; OnPropertyChanged("DepID"); } } }

        private String _DepName;
        /// <summary>部门名称</summary>
        [DisplayName("部门名称")]
        [Description("部门名称")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("DepName", "部门名称", "nvarchar(30)")]
        public String DepName { get => _DepName; set { if (OnPropertyChanging("DepName", value)) { _DepName = value; OnPropertyChanged("DepName"); } } }
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
                    case "DepID": return _DepID;
                    case "DepName": return _DepName;
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
                    case "DepID": _DepID = value.ToInt(); break;
                    case "DepName": _DepName = Convert.ToString(value); break;
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
            /// <summary>部门ID</summary>
            public static readonly Field DepID = FindByName("DepID");

            /// <summary>部门名称</summary>
            public static readonly Field DepName = FindByName("DepName");
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

            /// <summary>部门ID</summary>
            public const String DepID = "DepID";

            /// <summary>部门名称</summary>
            public const String DepName = "DepName";
        }
        #endregion
    }
}