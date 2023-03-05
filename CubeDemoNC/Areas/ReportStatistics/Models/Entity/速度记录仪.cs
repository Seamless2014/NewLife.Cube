using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace GPSPlatform.ReportStatistics.Entity
{
    /// <summary>速度记录仪</summary>
    [Serializable]
    [DataObject]
    [Description("速度记录仪")]
    [BindTable("SpeedRecorder", Description = "速度记录仪", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class SpeedRecorder
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("Id", "编号", "int")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private Int32 _RecorderId;
        /// <summary>记录仪编码</summary>
        [DisplayName("记录仪编码")]
        [Description("记录仪编码")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("RecorderId", "记录仪编码", "int")]
        public Int32 RecorderId { get => _RecorderId; set { if (OnPropertyChanging("RecorderId", value)) { _RecorderId = value; OnPropertyChanged("RecorderId"); } } }

        private Double _Speed;
        /// <summary>速度</summary>
        [DisplayName("速度")]
        [Description("速度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Speed", "速度", "float")]
        public Double Speed { get => _Speed; set { if (OnPropertyChanging("Speed", value)) { _Speed = value; OnPropertyChanged("Speed"); } } }

        private Int32 _Signal;
        /// <summary>信号</summary>
        [DisplayName("信号")]
        [Description("信号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Signal", "信号", "int")]
        public Int32 Signal { get => _Signal; set { if (OnPropertyChanging("Signal", value)) { _Signal = value; OnPropertyChanged("Signal"); } } }

        private Int32 _SN;
        /// <summary>序号</summary>
        [DisplayName("序号")]
        [Description("序号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("SN", "序号", "int")]
        public Int32 SN { get => _SN; set { if (OnPropertyChanging("SN", value)) { _SN = value; OnPropertyChanged("SN"); } } }

        private DateTime _RecorderDate;
        /// <summary>记录日期</summary>
        [DisplayName("记录日期")]
        [Description("记录日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("RecorderDate", "记录日期", "datetime", Precision = 0, Scale = 3)]
        public DateTime RecorderDate { get => _RecorderDate; set { if (OnPropertyChanging("RecorderDate", value)) { _RecorderDate = value; OnPropertyChanged("RecorderDate"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }
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
                    case "RecorderId": return _RecorderId;
                    case "Speed": return _Speed;
                    case "Signal": return _Signal;
                    case "SN": return _SN;
                    case "RecorderDate": return _RecorderDate;
                    case "CreateTime": return _CreateTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "RecorderId": _RecorderId = value.ToInt(); break;
                    case "Speed": _Speed = value.ToDouble(); break;
                    case "Signal": _Signal = value.ToInt(); break;
                    case "SN": _SN = value.ToInt(); break;
                    case "RecorderDate": _RecorderDate = value.ToDateTime(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得速度记录仪字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary>记录仪编码</summary>
            public static readonly Field RecorderId = FindByName("RecorderId");

            /// <summary>速度</summary>
            public static readonly Field Speed = FindByName("Speed");

            /// <summary>信号</summary>
            public static readonly Field Signal = FindByName("Signal");

            /// <summary>序号</summary>
            public static readonly Field SN = FindByName("SN");

            /// <summary>记录日期</summary>
            public static readonly Field RecorderDate = FindByName("RecorderDate");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得速度记录仪字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String Id = "Id";

            /// <summary>记录仪编码</summary>
            public const String RecorderId = "RecorderId";

            /// <summary>速度</summary>
            public const String Speed = "Speed";

            /// <summary>信号</summary>
            public const String Signal = "Signal";

            /// <summary>序号</summary>
            public const String SN = "SN";

            /// <summary>记录日期</summary>
            public const String RecorderDate = "RecorderDate";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";
        }
        #endregion
    }
}