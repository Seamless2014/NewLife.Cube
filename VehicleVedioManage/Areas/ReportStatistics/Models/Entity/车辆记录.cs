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
    [Serializable]
    [DataObject]
    [Description("行车记录仪")]
    [BindIndex("IU_VehicleRecorder_PlateNo", true, "PlateNo")]
    [BindIndex("IX_VehicleRecorder_StartTime_EndTime", false, "StartTime,EndTime")]
    [BindTable("VehicleRecorder", Description = "行车记录仪", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class VehicleRecord
    {
        #region 属性
        private Int32 _RecorderID;
        /// <summary>记录仪编码</summary>
        [DisplayName("记录仪编码")]
        [Description("记录仪编码")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("RecorderID", "记录仪编码", "")]
        public Int32 RecorderID { get => _RecorderID; set { if (OnPropertyChanging("RecorderID", value)) { _RecorderID = value; OnPropertyChanged("RecorderID"); } } }

        private Int32 _CommandID;
        /// <summary>命令编码</summary>
        [DisplayName("命令编码")]
        [Description("命令编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CommandID", "命令编码", "")]
        public Int32 CommandID { get => _CommandID; set { if (OnPropertyChanging("CommandID", value)) { _CommandID = value; OnPropertyChanged("CommandID"); } } }

        private Int32 _Cmd;
        /// <summary>指令</summary>
        [DisplayName("指令")]
        [Description("指令")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Cmd", "指令", "")]
        public Int32 Cmd { get => _Cmd; set { if (OnPropertyChanging("Cmd", value)) { _Cmd = value; OnPropertyChanged("Cmd"); } } }

        private String _CmdData;
        /// <summary>指令数据</summary>
        [DisplayName("指令数据")]
        [Description("指令数据")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("CmdData", "指令数据", "")]
        public String CmdData { get => _CmdData; set { if (OnPropertyChanging("CmdData", value)) { _CmdData = value; OnPropertyChanged("CmdData"); } } }

        private String _DriverCode;
        /// <summary>驱动程序代码</summary>
        [Category("扩展信息")]
        [DisplayName("驱动程序代码")]
        [Description("驱动程序代码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("DriverCode", "驱动程序代码", "")]
        public String DriverCode { get => _DriverCode; set { if (OnPropertyChanging("DriverCode", value)) { _DriverCode = value; OnPropertyChanged("DriverCode"); } } }

        private String _DriverLicense;
        /// <summary>驱动许可证</summary>
        [Category("扩展信息")]
        [DisplayName("驱动许可证")]
        [Description("驱动许可证")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("DriverLicense", "驱动许可证", "")]
        public String DriverLicense { get => _DriverLicense; set { if (OnPropertyChanging("DriverLicense", value)) { _DriverLicense = value; OnPropertyChanged("DriverLicense"); } } }

        private String _VinNo;
        /// <summary>VIN编号</summary>
        [Category("扩展信息")]
        [DisplayName("VIN编号")]
        [Description("VIN编号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("VinNo", "VIN编号", "")]
        public String VinNo { get => _VinNo; set { if (OnPropertyChanging("VinNo", value)) { _VinNo = value; OnPropertyChanged("VinNo"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("PlateNo", "车牌号", "")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private String _PlateType;
        /// <summary>车辆类型</summary>
        [DisplayName("车辆类型")]
        [Description("车辆类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("PlateType", "车辆类型", "")]
        public String PlateType { get => _PlateType; set { if (OnPropertyChanging("PlateType", value)) { _PlateType = value; OnPropertyChanged("PlateType"); } } }

        private String _FeatureFactor;
        /// <summary>特征因数</summary>
        [DisplayName("特征因数")]
        [Description("特征因数")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("FeatureFactor", "特征因数", "")]
        public String FeatureFactor { get => _FeatureFactor; set { if (OnPropertyChanging("FeatureFactor", value)) { _FeatureFactor = value; OnPropertyChanged("FeatureFactor"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("扩展信息")]
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private Int32 _TenantID;
        /// <summary>租户编码</summary>
        [Category("扩展信息")]
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TenantID", "租户编码", "")]
        public Int32 TenantID { get => _TenantID; set { if (OnPropertyChanging("TenantID", value)) { _TenantID = value; OnPropertyChanged("TenantID"); } } }

        private Byte _PlateColor;
        /// <summary>车牌颜色</summary>
        [DisplayName("车牌颜色")]
        [Description("车牌颜色")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("PlateColor", "车牌颜色", "")]
        public Byte PlateColor { get => _PlateColor; set { if (OnPropertyChanging("PlateColor", value)) { _PlateColor = value; OnPropertyChanged("PlateColor"); } } }

        private DateTime _StartTime;
        /// <summary>开始时间</summary>
        [DisplayName("开始时间")]
        [Description("开始时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("StartTime", "开始时间", "", Precision = 0, Scale = 3)]
        public DateTime StartTime { get => _StartTime; set { if (OnPropertyChanging("StartTime", value)) { _StartTime = value; OnPropertyChanged("StartTime"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [Category("扩展信息")]
        [DisplayName("拥有者")]
        [Description("拥有者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "拥有者", "")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private Double _Speed;
        /// <summary>速度</summary>
        [DisplayName("速度")]
        [Description("速度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Speed", "速度", "")]
        public Double Speed { get => _Speed; set { if (OnPropertyChanging("Speed", value)) { _Speed = value; OnPropertyChanged("Speed"); } } }

        private Int32 _Signal;
        /// <summary>信号</summary>
        [DisplayName("信号")]
        [Description("信号")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Signal", "信号", "")]
        public Int32 Signal { get => _Signal; set { if (OnPropertyChanging("Signal", value)) { _Signal = value; OnPropertyChanged("Signal"); } } }

        private Int32 _SortID;
        /// <summary>排序</summary>
        [Category("扩展信息")]
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("SortID", "排序", "")]
        public Int32 SortID { get => _SortID; set { if (OnPropertyChanging("SortID", value)) { _SortID = value; OnPropertyChanged("SortID"); } } }

        private DateTime _EndTime;
        /// <summary>结束时间</summary>
        [DisplayName("结束时间")]
        [Description("结束时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("EndTime", "结束时间", "", Precision = 0, Scale = 3)]
        public DateTime EndTime { get => _EndTime; set { if (OnPropertyChanging("EndTime", value)) { _EndTime = value; OnPropertyChanged("EndTime"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("VehicleId", "车辆编码", "")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private Double _Altitude;
        /// <summary>海拔高度</summary>
        [DisplayName("海拔高度")]
        [Description("海拔高度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Altitude", "海拔高度", "")]
        public Double Altitude { get => _Altitude; set { if (OnPropertyChanging("Altitude", value)) { _Altitude = value; OnPropertyChanged("Altitude"); } } }

        private Double _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Latitude", "纬度", "")]
        public Double Latitude { get => _Latitude; set { if (OnPropertyChanging("Latitude", value)) { _Latitude = value; OnPropertyChanged("Latitude"); } } }

        private Double _Longitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Longitude", "经度", "")]
        public Double Longitude { get => _Longitude; set { if (OnPropertyChanging("Longitude", value)) { _Longitude = value; OnPropertyChanged("Longitude"); } } }

        private String _RecorderData;
        /// <summary>记录仪数据</summary>
        [DisplayName("记录仪数据")]
        [Description("记录仪数据")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("RecorderData", "记录仪数据", "")]
        public String RecorderData { get => _RecorderData; set { if (OnPropertyChanging("RecorderData", value)) { _RecorderData = value; OnPropertyChanged("RecorderData"); } } }

        private DateTime _RecorderDate;
        /// <summary>记录仪日期</summary>
        [DisplayName("记录仪日期")]
        [Description("记录仪日期")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("RecorderDate", "记录仪日期", "", Precision = 0, Scale = 3)]
        public DateTime RecorderDate { get => _RecorderDate; set { if (OnPropertyChanging("RecorderDate", value)) { _RecorderDate = value; OnPropertyChanged("RecorderDate"); } } }

        private Int32 _SpeedList;
        /// <summary>速度列表</summary>
        [DisplayName("速度列表")]
        [Description("速度列表")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("SpeedList", "速度列表", "")]
        public Int32 SpeedList { get => _SpeedList; set { if (OnPropertyChanging("SpeedList", value)) { _SpeedList = value; OnPropertyChanged("SpeedList"); } } }
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
                    case "RecorderID": return _RecorderID;
                    case "CommandID": return _CommandID;
                    case "Cmd": return _Cmd;
                    case "CmdData": return _CmdData;
                    case "DriverCode": return _DriverCode;
                    case "DriverLicense": return _DriverLicense;
                    case "VinNo": return _VinNo;
                    case "PlateNo": return _PlateNo;
                    case "PlateType": return _PlateType;
                    case "FeatureFactor": return _FeatureFactor;
                    case "Deleted": return _Deleted;
                    case "TenantID": return _TenantID;
                    case "PlateColor": return _PlateColor;
                    case "StartTime": return _StartTime;
                    case "Owner": return _Owner;
                    case "Speed": return _Speed;
                    case "Signal": return _Signal;
                    case "SortID": return _SortID;
                    case "EndTime": return _EndTime;
                    case "VehicleId": return _VehicleId;
                    case "Altitude": return _Altitude;
                    case "Latitude": return _Latitude;
                    case "Longitude": return _Longitude;
                    case "RecorderData": return _RecorderData;
                    case "RecorderDate": return _RecorderDate;
                    case "SpeedList": return _SpeedList;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "RecorderID": _RecorderID = value.ToInt(); break;
                    case "CommandID": _CommandID = value.ToInt(); break;
                    case "Cmd": _Cmd = value.ToInt(); break;
                    case "CmdData": _CmdData = Convert.ToString(value); break;
                    case "DriverCode": _DriverCode = Convert.ToString(value); break;
                    case "DriverLicense": _DriverLicense = Convert.ToString(value); break;
                    case "VinNo": _VinNo = Convert.ToString(value); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "PlateType": _PlateType = Convert.ToString(value); break;
                    case "FeatureFactor": _FeatureFactor = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "TenantID": _TenantID = value.ToInt(); break;
                    case "PlateColor": _PlateColor = Convert.ToByte(value); break;
                    case "StartTime": _StartTime = value.ToDateTime(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Speed": _Speed = value.ToDouble(); break;
                    case "Signal": _Signal = value.ToInt(); break;
                    case "SortID": _SortID = value.ToInt(); break;
                    case "EndTime": _EndTime = value.ToDateTime(); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "Altitude": _Altitude = value.ToDouble(); break;
                    case "Latitude": _Latitude = value.ToDouble(); break;
                    case "Longitude": _Longitude = value.ToDouble(); break;
                    case "RecorderData": _RecorderData = Convert.ToString(value); break;
                    case "RecorderDate": _RecorderDate = value.ToDateTime(); break;
                    case "SpeedList": _SpeedList = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得记录仪字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>记录仪编码</summary>
            public static readonly Field RecorderID = FindByName("RecorderID");

            /// <summary>命令编码</summary>
            public static readonly Field CommandID = FindByName("CommandID");

            /// <summary>指令</summary>
            public static readonly Field Cmd = FindByName("Cmd");

            /// <summary>指令数据</summary>
            public static readonly Field CmdData = FindByName("CmdData");

            /// <summary>驱动程序代码</summary>
            public static readonly Field DriverCode = FindByName("DriverCode");

            /// <summary>驱动许可证</summary>
            public static readonly Field DriverLicense = FindByName("DriverLicense");

            /// <summary>VIN编号</summary>
            public static readonly Field VinNo = FindByName("VinNo");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>车辆类型</summary>
            public static readonly Field PlateType = FindByName("PlateType");

            /// <summary>特征因数</summary>
            public static readonly Field FeatureFactor = FindByName("FeatureFactor");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>租户编码</summary>
            public static readonly Field TenantID = FindByName("TenantID");

            /// <summary>车牌颜色</summary>
            public static readonly Field PlateColor = FindByName("PlateColor");

            /// <summary>开始时间</summary>
            public static readonly Field StartTime = FindByName("StartTime");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>速度</summary>
            public static readonly Field Speed = FindByName("Speed");

            /// <summary>信号</summary>
            public static readonly Field Signal = FindByName("Signal");

            /// <summary>排序</summary>
            public static readonly Field SortID = FindByName("SortID");

            /// <summary>结束时间</summary>
            public static readonly Field EndTime = FindByName("EndTime");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>海拔高度</summary>
            public static readonly Field Altitude = FindByName("Altitude");

            /// <summary>纬度</summary>
            public static readonly Field Latitude = FindByName("Latitude");

            /// <summary>经度</summary>
            public static readonly Field Longitude = FindByName("Longitude");

            /// <summary>记录仪数据</summary>
            public static readonly Field RecorderData = FindByName("RecorderData");

            /// <summary>记录仪日期</summary>
            public static readonly Field RecorderDate = FindByName("RecorderDate");

            /// <summary>速度列表</summary>
            public static readonly Field SpeedList = FindByName("SpeedList");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得记录仪字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>记录仪编码</summary>
            public const String RecorderID = "RecorderID";

            /// <summary>命令编码</summary>
            public const String CommandID = "CommandID";

            /// <summary>指令</summary>
            public const String Cmd = "Cmd";

            /// <summary>指令数据</summary>
            public const String CmdData = "CmdData";

            /// <summary>驱动程序代码</summary>
            public const String DriverCode = "DriverCode";

            /// <summary>驱动许可证</summary>
            public const String DriverLicense = "DriverLicense";

            /// <summary>VIN编号</summary>
            public const String VinNo = "VinNo";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>车辆类型</summary>
            public const String PlateType = "PlateType";

            /// <summary>特征因数</summary>
            public const String FeatureFactor = "FeatureFactor";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>租户编码</summary>
            public const String TenantID = "TenantID";

            /// <summary>车牌颜色</summary>
            public const String PlateColor = "PlateColor";

            /// <summary>开始时间</summary>
            public const String StartTime = "StartTime";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";

            /// <summary>速度</summary>
            public const String Speed = "Speed";

            /// <summary>信号</summary>
            public const String Signal = "Signal";

            /// <summary>排序</summary>
            public const String SortID = "SortID";

            /// <summary>结束时间</summary>
            public const String EndTime = "EndTime";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>海拔高度</summary>
            public const String Altitude = "Altitude";

            /// <summary>纬度</summary>
            public const String Latitude = "Latitude";

            /// <summary>经度</summary>
            public const String Longitude = "Longitude";

            /// <summary>记录仪数据</summary>
            public const String RecorderData = "RecorderData";

            /// <summary>记录仪日期</summary>
            public const String RecorderDate = "RecorderDate";

            /// <summary>速度列表</summary>
            public const String SpeedList = "SpeedList";
        }
        #endregion
    }
}