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
    /// <summary>GPS</summary>
    [Serializable]
    [DataObject]
    [Description("GPS")]
    [BindTable("GpsInfo", Description = "GPS", ConnName = "VehicleGPSVideoForHisData", DbType = DatabaseType.SqlServer)]
    public partial class GpsInfo
    {
        #region 属性
        private Int32 _GpsId;
        /// <summary>GPS编码</summary>
        [DisplayName("GPS编码")]
        [Description("GPS编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("GpsId", "GPS编码", "int")]
        public Int32 GpsId { get => _GpsId; set { if (OnPropertyChanging("GpsId", value)) { _GpsId = value; OnPropertyChanged("GpsId"); } } }

        private Int32 _CommandId;
        /// <summary>指令编码</summary>
        [DisplayName("指令编码")]
        [Description("指令编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("CommandId", "指令编码", "int")]
        public Int32 CommandId { get => _CommandId; set { if (OnPropertyChanging("CommandId", value)) { _CommandId = value; OnPropertyChanged("CommandId"); } } }

        private String _SimNo;
        /// <summary>Similar卡</summary>
        [DisplayName("Similar卡")]
        [Description("Similar卡")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("SimNo", "Similar卡", "nvarchar(255)")]
        public String SimNo { get => _SimNo; set { if (OnPropertyChanging("SimNo", value)) { _SimNo = value; OnPropertyChanged("SimNo"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(255)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private Int32 _Signal;
        /// <summary>信号</summary>
        [DisplayName("信号")]
        [Description("信号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Signal", "信号", "int")]
        public Int32 Signal { get => _Signal; set { if (OnPropertyChanging("Signal", value)) { _Signal = value; OnPropertyChanged("Signal"); } } }

        private DateTime _SendTime;
        /// <summary>发送时间</summary>
        [DisplayName("发送时间")]
        [Description("发送时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("SendTime", "发送时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime SendTime { get => _SendTime; set { if (OnPropertyChanging("SendTime", value)) { _SendTime = value; OnPropertyChanged("SendTime"); } } }

        private Double _Longitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Longitude", "经度", "float")]
        public Double Longitude { get => _Longitude; set { if (OnPropertyChanging("Longitude", value)) { _Longitude = value; OnPropertyChanged("Longitude"); } } }

        private Double _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Latitude", "纬度", "float")]
        public Double Latitude { get => _Latitude; set { if (OnPropertyChanging("Latitude", value)) { _Latitude = value; OnPropertyChanged("Latitude"); } } }

        private Double _Velocity;
        /// <summary>速度</summary>
        [DisplayName("速度")]
        [Description("速度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Velocity", "速度", "float")]
        public Double Velocity { get => _Velocity; set { if (OnPropertyChanging("Velocity", value)) { _Velocity = value; OnPropertyChanged("Velocity"); } } }

        private String _Location;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Location", "位置", "nvarchar(255)")]
        public String Location { get => _Location; set { if (OnPropertyChanging("Location", value)) { _Location = value; OnPropertyChanged("Location"); } } }

        private Int32 _Direction;
        /// <summary>方向</summary>
        [DisplayName("方向")]
        [Description("方向")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Direction", "方向", "int")]
        public Int32 Direction { get => _Direction; set { if (OnPropertyChanging("Direction", value)) { _Direction = value; OnPropertyChanged("Direction"); } } }

        private Int32 _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Status", "状态", "int")]
        public Int32 Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private Int32 _AlarmState;
        /// <summary>报警状态</summary>
        [DisplayName("报警状态")]
        [Description("报警状态")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("AlarmState", "报警状态", "int")]
        public Int32 AlarmState { get => _AlarmState; set { if (OnPropertyChanging("AlarmState", value)) { _AlarmState = value; OnPropertyChanged("AlarmState"); } } }

        private Double _Mileage;
        /// <summary>里程</summary>
        [DisplayName("里程")]
        [Description("里程")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Mileage", "里程", "float")]
        public Double Mileage { get => _Mileage; set { if (OnPropertyChanging("Mileage", value)) { _Mileage = value; OnPropertyChanged("Mileage"); } } }

        private Double _Gas;
        /// <summary>油气</summary>
        [DisplayName("油气")]
        [Description("油气")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Gas", "油气", "float")]
        public Double Gas { get => _Gas; set { if (OnPropertyChanging("Gas", value)) { _Gas = value; OnPropertyChanged("Gas"); } } }

        private Double _RecordVelocity;
        /// <summary>记录仪速度</summary>
        [DisplayName("记录仪速度")]
        [Description("记录仪速度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("RecordVelocity", "记录仪速度", "float")]
        public Double RecordVelocity { get => _RecordVelocity; set { if (OnPropertyChanging("RecordVelocity", value)) { _RecordVelocity = value; OnPropertyChanged("RecordVelocity"); } } }

        private Double _Altitude;
        /// <summary>海拔高度</summary>
        [DisplayName("海拔高度")]
        [Description("海拔高度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Altitude", "海拔高度", "float")]
        public Double Altitude { get => _Altitude; set { if (OnPropertyChanging("Altitude", value)) { _Altitude = value; OnPropertyChanged("Altitude"); } } }

        private Boolean _Valid;
        /// <summary>有效</summary>
        [DisplayName("有效")]
        [Description("有效")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("IsValid", "有效", "bit")]
        public Boolean IsValid { get => _Valid; set { if (OnPropertyChanging("IsValid", value)) { _Valid = value; OnPropertyChanged("IsValid"); } } }

        private String _RunStatus;
        /// <summary>运营状态</summary>
        [DisplayName("运营状态")]
        [Description("运营状态")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("RunStatus", "运营状态", "nvarchar(255)")]
        public String RunStatus { get => _RunStatus; set { if (OnPropertyChanging("RunStatus", value)) { _RunStatus = value; OnPropertyChanged("RunStatus"); } } }

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

        private String _FuelLevelData;
        /// <summary>燃料层级数据</summary>
        [DisplayName("燃料层级数据")]
        [Description("燃料层级数据")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("FuelLevelData", "燃料层级数据", "nvarchar(255)")]
        public String FuelLevelData { get => _FuelLevelData; set { if (OnPropertyChanging("FuelLevelData", value)) { _FuelLevelData = value; OnPropertyChanged("FuelLevelData"); } } }

        private String _FuelData;
        /// <summary>燃料数据</summary>
        [DisplayName("燃料数据")]
        [Description("燃料数据")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("FuelData", "燃料数据", "nvarchar(255)")]
        public String FuelData { get => _FuelData; set { if (OnPropertyChanging("FuelData", value)) { _FuelData = value; OnPropertyChanged("FuelData"); } } }
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
                    case "GpsId": return _GpsId;
                    case "CommandId": return _CommandId;
                    case "SimNo": return _SimNo;
                    case "PlateNo": return _PlateNo;
                    case "Signal": return _Signal;
                    case "SendTime": return _SendTime;
                    case "Longitude": return _Longitude;
                    case "Latitude": return _Latitude;
                    case "Velocity": return _Velocity;
                    case "Location": return _Location;
                    case "Direction": return _Direction;
                    case "Status": return _Status;
                    case "AlarmState": return _AlarmState;
                    case "Mileage": return _Mileage;
                    case "Gas": return _Gas;
                    case "RecordVelocity": return _RecordVelocity;
                    case "Altitude": return _Altitude;
                    case "IsValid": return _Valid;
                    case "RunStatus": return _RunStatus;
                    case "TenantId": return _TenantId;
                    case "CreateTime": return _CreateTime;
                    case "Remark": return _Remark;
                    case "Deleted": return _Deleted;
                    case "Owner": return _Owner;
                    case "FuelLevelData": return _FuelLevelData;
                    case "FuelData": return _FuelData;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "GpsId": _GpsId = value.ToInt(); break;
                    case "CommandId": _CommandId = value.ToInt(); break;
                    case "SimNo": _SimNo = Convert.ToString(value); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "Signal": _Signal = value.ToInt(); break;
                    case "SendTime": _SendTime = value.ToDateTime(); break;
                    case "Longitude": _Longitude = value.ToDouble(); break;
                    case "Latitude": _Latitude = value.ToDouble(); break;
                    case "Velocity": _Velocity = value.ToDouble(); break;
                    case "Location": _Location = Convert.ToString(value); break;
                    case "Direction": _Direction = value.ToInt(); break;
                    case "Status": _Status = value.ToInt(); break;
                    case "AlarmState": _AlarmState = value.ToInt(); break;
                    case "Mileage": _Mileage = value.ToDouble(); break;
                    case "Gas": _Gas = value.ToDouble(); break;
                    case "RecordVelocity": _RecordVelocity = value.ToDouble(); break;
                    case "Altitude": _Altitude = value.ToDouble(); break;
                    case "IsValid": _Valid = value.ToBoolean(); break;
                    case "RunStatus": _RunStatus = Convert.ToString(value); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "FuelLevelData": _FuelLevelData = Convert.ToString(value); break;
                    case "FuelData": _FuelData = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得GPS字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>GPS编码</summary>
            public static readonly Field GpsId = FindByName("GpsId");

            /// <summary>指令编码</summary>
            public static readonly Field CommandId = FindByName("CommandId");

            /// <summary>Similar卡</summary>
            public static readonly Field SimNo = FindByName("SimNo");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>信号</summary>
            public static readonly Field Signal = FindByName("Signal");

            /// <summary>发送时间</summary>
            public static readonly Field SendTime = FindByName("SendTime");

            /// <summary>经度</summary>
            public static readonly Field Longitude = FindByName("Longitude");

            /// <summary>纬度</summary>
            public static readonly Field Latitude = FindByName("Latitude");

            /// <summary>速度</summary>
            public static readonly Field Velocity = FindByName("Velocity");

            /// <summary>位置</summary>
            public static readonly Field Location = FindByName("Location");

            /// <summary>方向</summary>
            public static readonly Field Direction = FindByName("Direction");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>报警状态</summary>
            public static readonly Field AlarmState = FindByName("AlarmState");

            /// <summary>里程</summary>
            public static readonly Field Mileage = FindByName("Mileage");

            /// <summary>油气</summary>
            public static readonly Field Gas = FindByName("Gas");

            /// <summary>记录仪速度</summary>
            public static readonly Field RecordVelocity = FindByName("RecordVelocity");

            /// <summary>海拔高度</summary>
            public static readonly Field Altitude = FindByName("Altitude");

            /// <summary>有效</summary>
            public static readonly Field IsValid = FindByName("IsValid");

            /// <summary>运营状态</summary>
            public static readonly Field RunStatus = FindByName("RunStatus");

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

            /// <summary>燃料层级数据</summary>
            public static readonly Field FuelLevelData = FindByName("FuelLevelData");

            /// <summary>燃料数据</summary>
            public static readonly Field FuelData = FindByName("FuelData");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得GPS字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>GPS编码</summary>
            public const String GpsId = "GpsId";

            /// <summary>指令编码</summary>
            public const String CommandId = "CommandId";

            /// <summary>Similar卡</summary>
            public const String SimNo = "SimNo";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>信号</summary>
            public const String Signal = "Signal";

            /// <summary>发送时间</summary>
            public const String SendTime = "SendTime";

            /// <summary>经度</summary>
            public const String Longitude = "Longitude";

            /// <summary>纬度</summary>
            public const String Latitude = "Latitude";

            /// <summary>速度</summary>
            public const String Velocity = "Velocity";

            /// <summary>位置</summary>
            public const String Location = "Location";

            /// <summary>方向</summary>
            public const String Direction = "Direction";

            /// <summary>状态</summary>
            public const String Status = "Status";

            /// <summary>报警状态</summary>
            public const String AlarmState = "AlarmState";

            /// <summary>里程</summary>
            public const String Mileage = "Mileage";

            /// <summary>油气</summary>
            public const String Gas = "Gas";

            /// <summary>记录仪速度</summary>
            public const String RecordVelocity = "RecordVelocity";

            /// <summary>海拔高度</summary>
            public const String Altitude = "Altitude";

            /// <summary>有效</summary>
            public const String IsValid = "IsValid";

            /// <summary>运营状态</summary>
            public const String RunStatus = "RunStatus";

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

            /// <summary>燃料层级数据</summary>
            public const String FuelLevelData = "FuelLevelData";

            /// <summary>燃料数据</summary>
            public const String FuelData = "FuelData";
        }
        #endregion
    }
}