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
    /// <summary>实时数据</summary>
    [Serializable]
    [DataObject]
    [Description("实时数据")]
    [BindIndex("IU_GPSRealData_PlateNo", true, "PlateNo")]
    [BindIndex("IX_GPSRealData_PlateNo_SendTime", false, "PlateNo,SendTime")]
    [BindTable("GPSRealData", Description = "实时数据", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class GPSRealData
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "编号", "")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private String _SimNo;
        /// <summary>Sim卡</summary>
        [DisplayName("Sim卡")]
        [Description("Sim卡")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("SimNo", "Sim卡", "")]
        public String SimNo { get => _SimNo; set { if (OnPropertyChanging("SimNo", value)) { _SimNo = value; OnPropertyChanged("SimNo"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("PlateNo", "车牌号", "")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private String _Location;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn("Location", "位置", "")]
        public String Location { get => _Location; set { if (OnPropertyChanging("Location", value)) { _Location = value; OnPropertyChanged("Location"); } } }

        private DateTime _SendTime;
        /// <summary>发送时间</summary>
        [DisplayName("发送时间")]
        [Description("发送时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("SendTime", "发送时间", "", Precision = 0, Scale = 3)]
        public DateTime SendTime { get => _SendTime; set { if (OnPropertyChanging("SendTime", value)) { _SendTime = value; OnPropertyChanged("SendTime"); } } }

        private double _Longitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Longitude", "经度", "numeric(18, 6)", Precision = 0, Scale = 6)]
        public double Longitude { get => _Longitude; set { if (OnPropertyChanging("Longitude", value)) { _Longitude = value; OnPropertyChanged("Longitude"); } } }

        private double _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Latitude", "纬度", "numeric(18, 6)", Precision = 0, Scale = 6)]
        public double Latitude { get => _Latitude; set { if (OnPropertyChanging("Latitude", value)) { _Latitude = value; OnPropertyChanged("Latitude"); } } }

        private double _Velocity;
        /// <summary>速度</summary>
        [DisplayName("速度")]
        [Description("速度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Velocity", "速度", "numeric(18, 1)", Precision = 0, Scale = 1)]
        public double Velocity { get => _Velocity; set { if (OnPropertyChanging("Velocity", value)) { _Velocity = value; OnPropertyChanged("Velocity"); } } }

        private Int32 _Direction;
        /// <summary>方向</summary>
        [DisplayName("方向")]
        [Description("方向")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Direction", "方向", "")]
        public Int32 Direction { get => _Direction; set { if (OnPropertyChanging("Direction", value)) { _Direction = value; OnPropertyChanged("Direction"); } } }

        private String _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("Status", "状态", "")]
        public String Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private double _Gas;
        /// <summary>油气</summary>
        [DisplayName("油气")]
        [Description("油气")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Gas", "油气", "numeric(18, 1)", Precision = 0, Scale = 1)]
        public double Gas { get => _Gas; set { if (OnPropertyChanging("Gas", value)) { _Gas = value; OnPropertyChanged("Gas"); } } }

        private double _Mileage;
        /// <summary>里程</summary>
        [DisplayName("里程")]
        [Description("里程")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Mileage", "里程", "numeric(18, 1)", Precision = 0, Scale = 1)]
        public double Mileage { get => _Mileage; set { if (OnPropertyChanging("Mileage", value)) { _Mileage = value; OnPropertyChanged("Mileage"); } } }

        private double _RecordVelocity;
        /// <summary>行车记录仪速度</summary>
        [DisplayName("行车记录仪速度")]
        [Description("行车记录仪速度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("RecordVelocity", "行车记录仪速度", "numeric(18, 1)", Precision = 0, Scale = 1)]
        public double RecordVelocity { get => _RecordVelocity; set { if (OnPropertyChanging("RecordVelocity", value)) { _RecordVelocity = value; OnPropertyChanged("RecordVelocity"); } } }

        private Double _Remain;
        /// <summary>剩余</summary>
        [DisplayName("剩余")]
        [Description("剩余")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Remain", "剩余", "")]
        public Double Remain { get => _Remain; set { if (OnPropertyChanging("Remain", value)) { _Remain = value; OnPropertyChanged("Remain"); } } }

        private Boolean _Online;
        /// <summary>在线</summary>
        [DisplayName("在线")]
        [Description("在线")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Online", "在线", "")]
        public Boolean Online { get => _Online; set { if (OnPropertyChanging("Online", value)) { _Online = value; OnPropertyChanged("Online"); } } }

        private Int32 _Signal;
        /// <summary>信号</summary>
        [DisplayName("信号")]
        [Description("信号")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Signal", "信号", "")]
        public Int32 Signal { get => _Signal; set { if (OnPropertyChanging("Signal", value)) { _Signal = value; OnPropertyChanged("Signal"); } } }

        private String _AlarmState;
        /// <summary>报警状态</summary>
        [DisplayName("报警状态")]
        [Description("报警状态")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("AlarmState", "报警状态", "")]
        public String AlarmState { get => _AlarmState; set { if (OnPropertyChanging("AlarmState", value)) { _AlarmState = value; OnPropertyChanged("AlarmState"); } } }

        private String _DVRStatus;
        /// <summary>DVR状态</summary>
        [DisplayName("DVR状态")]
        [Description("DVR状态")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("DVRStatus", "DVR状态", "")]
        public String DVRStatus { get => _DVRStatus; set { if (OnPropertyChanging("DVRStatus", value)) { _DVRStatus = value; OnPropertyChanged("DVRStatus"); } } }

        private Double _Altitude;
        /// <summary>海拔高度</summary>
        [DisplayName("海拔高度")]
        [Description("海拔高度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Altitude", "海拔高度", "")]
        public Double Altitude { get => _Altitude; set { if (OnPropertyChanging("Altitude", value)) { _Altitude = value; OnPropertyChanged("Altitude"); } } }

        private Boolean _IsValid;
        /// <summary>有效</summary>
        [DisplayName("有效")]
        [Description("有效")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("IsValid", "有效", "")]
        public Boolean IsValid { get => _IsValid; set { if (OnPropertyChanging("IsValid", value)) { _IsValid = value; OnPropertyChanged("IsValid"); } } }

        private Int32 _DepId;
        /// <summary>部门</summary>
        [DisplayName("部门")]
        [Description("部门")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("DepId", "部门", "")]
        public Int32 DepId { get => _DepId; set { if (OnPropertyChanging("DepId", value)) { _DepId = value; OnPropertyChanged("DepId"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("VehicleId", "车辆编码", "")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("UpdateTime", "更新时间", "", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Int32 _EnclosureId;
        /// <summary>围栏编码</summary>
        [DisplayName("围栏编码")]
        [Description("围栏编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("EnclosureId", "围栏编码", "")]
        public Int32 EnclosureId { get => _EnclosureId; set { if (OnPropertyChanging("EnclosureId", value)) { _EnclosureId = value; OnPropertyChanged("EnclosureId"); } } }

        private Int32 _EnclosureType;
        /// <summary>围栏类型</summary>
        [DisplayName("围栏类型")]
        [Description("围栏类型")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("EnclosureType", "围栏类型", "")]
        public Int32 EnclosureType { get => _EnclosureType; set { if (OnPropertyChanging("EnclosureType", value)) { _EnclosureType = value; OnPropertyChanged("EnclosureType"); } } }

        private Int32 _EnclosureAlarm;
        /// <summary>围栏报警</summary>
        [DisplayName("围栏报警")]
        [Description("围栏报警")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("EnclosureAlarm", "围栏报警", "")]
        public Int32 EnclosureAlarm { get => _EnclosureAlarm; set { if (OnPropertyChanging("EnclosureAlarm", value)) { _EnclosureAlarm = value; OnPropertyChanged("EnclosureAlarm"); } } }

        private Int32 _OverSpeedAreaType;
        /// <summary>超速区域类型</summary>
        [DisplayName("超速区域类型")]
        [Description("超速区域类型")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("OverSpeedAreaType", "超速区域类型", "")]
        public Int32 OverSpeedAreaType { get => _OverSpeedAreaType; set { if (OnPropertyChanging("OverSpeedAreaType", value)) { _OverSpeedAreaType = value; OnPropertyChanged("OverSpeedAreaType"); } } }

        private Int32 _OverSpeedAreaId;
        /// <summary>超速区域编码</summary>
        [DisplayName("超速区域编码")]
        [Description("超速区域编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("OverSpeedAreaId", "超速区域编码", "")]
        public Int32 OverSpeedAreaId { get => _OverSpeedAreaId; set { if (OnPropertyChanging("OverSpeedAreaId", value)) { _OverSpeedAreaId = value; OnPropertyChanged("OverSpeedAreaId"); } } }

        private Int32 _RouteSegmentId;
        /// <summary>路线段编码</summary>
        [DisplayName("路线段编码")]
        [Description("路线段编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("RouteSegmentId", "路线段编码", "")]
        public Int32 RouteSegmentId { get => _RouteSegmentId; set { if (OnPropertyChanging("RouteSegmentId", value)) { _RouteSegmentId = value; OnPropertyChanged("RouteSegmentId"); } } }

        private Int32 _RunTimeOnRoute;
        /// <summary>在路线上运行时间</summary>
        [DisplayName("在路线上运行时间")]
        [Description("在路线上运行时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("RunTimeOnRoute", "在路线上运行时间", "")]
        public Int32 RunTimeOnRoute { get => _RunTimeOnRoute; set { if (OnPropertyChanging("RunTimeOnRoute", value)) { _RunTimeOnRoute = value; OnPropertyChanged("RunTimeOnRoute"); } } }

        private Int32 _RouteAlarmType;
        /// <summary>路线报警类型</summary>
        [DisplayName("路线报警类型")]
        [Description("路线报警类型")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("RouteAlarmType", "路线报警类型", "")]
        public Int32 RouteAlarmType { get => _RouteAlarmType; set { if (OnPropertyChanging("RouteAlarmType", value)) { _RouteAlarmType = value; OnPropertyChanged("RouteAlarmType"); } } }

        private DateTime _OnlineDate;
        /// <summary>上线时间</summary>
        [DisplayName("上线时间")]
        [Description("上线时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("OnlineDate", "上线时间", "", Precision = 0, Scale = 3)]
        public DateTime OnlineDate { get => _OnlineDate; set { if (OnPropertyChanging("OnlineDate", value)) { _OnlineDate = value; OnPropertyChanged("OnlineDate"); } } }

        private String _FuelLevelData;
        /// <summary>燃料等级数据</summary>
        [DisplayName("燃料等级数据")]
        [Description("燃料等级数据")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("FuelLevelData", "燃料等级数据", "")]
        public String FuelLevelData { get => _FuelLevelData; set { if (OnPropertyChanging("FuelLevelData", value)) { _FuelLevelData = value; OnPropertyChanged("FuelLevelData"); } } }

        private String _FuelData;
        /// <summary>燃料数据</summary>
        [DisplayName("燃料数据")]
        [Description("燃料数据")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("FuelData", "燃料数据", "")]
        public String FuelData { get => _FuelData; set { if (OnPropertyChanging("FuelData", value)) { _FuelData = value; OnPropertyChanged("FuelData"); } } }

        private Int32 _AreaId;
        /// <summary>区域编码</summary>
        [DisplayName("区域编码")]
        [Description("区域编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AreaId", "区域编码", "")]
        public Int32 AreaId { get => _AreaId; set { if (OnPropertyChanging("AreaId", value)) { _AreaId = value; OnPropertyChanged("AreaId"); } } }

        private Int32 _AreaAlarm;
        /// <summary>区域报警</summary>
        [DisplayName("区域报警")]
        [Description("区域报警")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AreaAlarm", "区域报警", "")]
        public Int32 AreaAlarm { get => _AreaAlarm; set { if (OnPropertyChanging("AreaAlarm", value)) { _AreaAlarm = value; OnPropertyChanged("AreaAlarm"); } } }

        private Int32 _AreaType;
        /// <summary>区域类型</summary>
        [DisplayName("区域类型")]
        [Description("区域类型")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AreaType", "区域类型", "")]
        public Int32 AreaType { get => _AreaType; set { if (OnPropertyChanging("AreaType", value)) { _AreaType = value; OnPropertyChanged("AreaType"); } } }

        private Int32 _PlatformId;
        /// <summary>平台编码</summary>
        [DisplayName("平台编码")]
        [Description("平台编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("PlatformId", "平台编码", "")]
        public Int32 PlatformId { get => _PlatformId; set { if (OnPropertyChanging("PlatformId", value)) { _PlatformId = value; OnPropertyChanged("PlatformId"); } } }
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
                    case "SimNo": return _SimNo;
                    case "PlateNo": return _PlateNo;
                    case "Location": return _Location;
                    case "SendTime": return _SendTime;
                    case "Longitude": return _Longitude;
                    case "Latitude": return _Latitude;
                    case "Velocity": return _Velocity;
                    case "Direction": return _Direction;
                    case "Status": return _Status;
                    case "Gas": return _Gas;
                    case "Mileage": return _Mileage;
                    case "RecordVelocity": return _RecordVelocity;
                    case "Remain": return _Remain;
                    case "Online": return _Online;
                    case "Signal": return _Signal;
                    case "AlarmState": return _AlarmState;
                    case "DVRStatus": return _DVRStatus;
                    case "Altitude": return _Altitude;
                    case "IsValid": return _IsValid;
                    case "DepId": return _DepId;
                    case "VehicleId": return _VehicleId;
                    case "UpdateTime": return _UpdateTime;
                    case "CreateTime": return _CreateTime;
                    case "EnclosureId": return _EnclosureId;
                    case "EnclosureType": return _EnclosureType;
                    case "EnclosureAlarm": return _EnclosureAlarm;
                    case "OverSpeedAreaType": return _OverSpeedAreaType;
                    case "OverSpeedAreaId": return _OverSpeedAreaId;
                    case "RouteSegmentId": return _RouteSegmentId;
                    case "RunTimeOnRoute": return _RunTimeOnRoute;
                    case "RouteAlarmType": return _RouteAlarmType;
                    case "OnlineDate": return _OnlineDate;
                    case "FuelLevelData": return _FuelLevelData;
                    case "FuelData": return _FuelData;
                    case "AreaId": return _AreaId;
                    case "AreaAlarm": return _AreaAlarm;
                    case "AreaType": return _AreaType;
                    case "PlatformId": return _PlatformId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = value.ToInt(); break;
                    case "SimNo": _SimNo = Convert.ToString(value); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "Location": _Location = Convert.ToString(value); break;
                    case "SendTime": _SendTime = value.ToDateTime(); break;
                    case "Longitude": _Longitude = Convert.ToDouble(value); break;
                    case "Latitude": _Latitude = Convert.ToDouble(value); break;
                    case "Velocity": _Velocity = Convert.ToDouble(value); break;
                    case "Direction": _Direction = value.ToInt(); break;
                    case "Status": _Status = Convert.ToString(value); break;
                    case "Gas": _Gas = Convert.ToDouble(value); break;
                    case "Mileage": _Mileage = Convert.ToDouble(value); break;
                    case "RecordVelocity": _RecordVelocity = Convert.ToDouble(value); break;
                    case "Remain": _Remain = value.ToDouble(); break;
                    case "Online": _Online = value.ToBoolean(); break;
                    case "Signal": _Signal = value.ToInt(); break;
                    case "AlarmState": _AlarmState = Convert.ToString(value); break;
                    case "DVRStatus": _DVRStatus = Convert.ToString(value); break;
                    case "Altitude": _Altitude = value.ToDouble(); break;
                    case "IsValid": _IsValid = value.ToBoolean(); break;
                    case "DepId": _DepId = value.ToInt(); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "EnclosureId": _EnclosureId = value.ToInt(); break;
                    case "EnclosureType": _EnclosureType = value.ToInt(); break;
                    case "EnclosureAlarm": _EnclosureAlarm = value.ToInt(); break;
                    case "OverSpeedAreaType": _OverSpeedAreaType = value.ToInt(); break;
                    case "OverSpeedAreaId": _OverSpeedAreaId = value.ToInt(); break;
                    case "RouteSegmentId": _RouteSegmentId = value.ToInt(); break;
                    case "RunTimeOnRoute": _RunTimeOnRoute = value.ToInt(); break;
                    case "RouteAlarmType": _RouteAlarmType = value.ToInt(); break;
                    case "OnlineDate": _OnlineDate = value.ToDateTime(); break;
                    case "FuelLevelData": _FuelLevelData = Convert.ToString(value); break;
                    case "FuelData": _FuelData = Convert.ToString(value); break;
                    case "AreaId": _AreaId = value.ToInt(); break;
                    case "AreaAlarm": _AreaAlarm = value.ToInt(); break;
                    case "AreaType": _AreaType = value.ToInt(); break;
                    case "PlatformId": _PlatformId = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得实时数据字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>Sim卡</summary>
            public static readonly Field SimNo = FindByName("SimNo");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>位置</summary>
            public static readonly Field Location = FindByName("Location");

            /// <summary>发送时间</summary>
            public static readonly Field SendTime = FindByName("SendTime");

            /// <summary>经度</summary>
            public static readonly Field Longitude = FindByName("Longitude");

            /// <summary>纬度</summary>
            public static readonly Field Latitude = FindByName("Latitude");

            /// <summary>速度</summary>
            public static readonly Field Velocity = FindByName("Velocity");

            /// <summary>方向</summary>
            public static readonly Field Direction = FindByName("Direction");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>油气</summary>
            public static readonly Field Gas = FindByName("Gas");

            /// <summary>里程</summary>
            public static readonly Field Mileage = FindByName("Mileage");

            /// <summary>行车记录仪速度</summary>
            public static readonly Field RecordVelocity = FindByName("RecordVelocity");

            /// <summary>剩余</summary>
            public static readonly Field Remain = FindByName("Remain");

            /// <summary>在线</summary>
            public static readonly Field Online = FindByName("Online");

            /// <summary>信号</summary>
            public static readonly Field Signal = FindByName("Signal");

            /// <summary>报警状态</summary>
            public static readonly Field AlarmState = FindByName("AlarmState");

            /// <summary>DVR状态</summary>
            public static readonly Field DVRStatus = FindByName("DVRStatus");

            /// <summary>海拔高度</summary>
            public static readonly Field Altitude = FindByName("Altitude");

            /// <summary>有效</summary>
            public static readonly Field IsValid = FindByName("IsValid");

            /// <summary>部门</summary>
            public static readonly Field DepId = FindByName("DepId");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>围栏编码</summary>
            public static readonly Field EnclosureId = FindByName("EnclosureId");

            /// <summary>围栏类型</summary>
            public static readonly Field EnclosureType = FindByName("EnclosureType");

            /// <summary>围栏报警</summary>
            public static readonly Field EnclosureAlarm = FindByName("EnclosureAlarm");

            /// <summary>超速区域类型</summary>
            public static readonly Field OverSpeedAreaType = FindByName("OverSpeedAreaType");

            /// <summary>超速区域编码</summary>
            public static readonly Field OverSpeedAreaId = FindByName("OverSpeedAreaId");

            /// <summary>路线段编码</summary>
            public static readonly Field RouteSegmentId = FindByName("RouteSegmentId");

            /// <summary>在路线上运行时间</summary>
            public static readonly Field RunTimeOnRoute = FindByName("RunTimeOnRoute");

            /// <summary>路线报警类型</summary>
            public static readonly Field RouteAlarmType = FindByName("RouteAlarmType");

            /// <summary>上线时间</summary>
            public static readonly Field OnlineDate = FindByName("OnlineDate");

            /// <summary>燃料等级数据</summary>
            public static readonly Field FuelLevelData = FindByName("FuelLevelData");

            /// <summary>燃料数据</summary>
            public static readonly Field FuelData = FindByName("FuelData");

            /// <summary>区域编码</summary>
            public static readonly Field AreaId = FindByName("AreaId");

            /// <summary>区域报警</summary>
            public static readonly Field AreaAlarm = FindByName("AreaAlarm");

            /// <summary>区域类型</summary>
            public static readonly Field AreaType = FindByName("AreaType");

            /// <summary>平台编码</summary>
            public static readonly Field PlatformId = FindByName("PlatformId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得实时数据字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String ID = "ID";

            /// <summary>Sim卡</summary>
            public const String SimNo = "SimNo";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>位置</summary>
            public const String Location = "Location";

            /// <summary>发送时间</summary>
            public const String SendTime = "SendTime";

            /// <summary>经度</summary>
            public const String Longitude = "Longitude";

            /// <summary>纬度</summary>
            public const String Latitude = "Latitude";

            /// <summary>速度</summary>
            public const String Velocity = "Velocity";

            /// <summary>方向</summary>
            public const String Direction = "Direction";

            /// <summary>状态</summary>
            public const String Status = "Status";

            /// <summary>油气</summary>
            public const String Gas = "Gas";

            /// <summary>里程</summary>
            public const String Mileage = "Mileage";

            /// <summary>行车记录仪速度</summary>
            public const String RecordVelocity = "RecordVelocity";

            /// <summary>剩余</summary>
            public const String Remain = "Remain";

            /// <summary>在线</summary>
            public const String Online = "Online";

            /// <summary>信号</summary>
            public const String Signal = "Signal";

            /// <summary>报警状态</summary>
            public const String AlarmState = "AlarmState";

            /// <summary>DVR状态</summary>
            public const String DVRStatus = "DVRStatus";

            /// <summary>海拔高度</summary>
            public const String Altitude = "Altitude";

            /// <summary>有效</summary>
            public const String IsValid = "IsValid";

            /// <summary>部门</summary>
            public const String DepId = "DepId";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>围栏编码</summary>
            public const String EnclosureId = "EnclosureId";

            /// <summary>围栏类型</summary>
            public const String EnclosureType = "EnclosureType";

            /// <summary>围栏报警</summary>
            public const String EnclosureAlarm = "EnclosureAlarm";

            /// <summary>超速区域类型</summary>
            public const String OverSpeedAreaType = "OverSpeedAreaType";

            /// <summary>超速区域编码</summary>
            public const String OverSpeedAreaId = "OverSpeedAreaId";

            /// <summary>路线段编码</summary>
            public const String RouteSegmentId = "RouteSegmentId";

            /// <summary>在路线上运行时间</summary>
            public const String RunTimeOnRoute = "RunTimeOnRoute";

            /// <summary>路线报警类型</summary>
            public const String RouteAlarmType = "RouteAlarmType";

            /// <summary>上线时间</summary>
            public const String OnlineDate = "OnlineDate";

            /// <summary>燃料等级数据</summary>
            public const String FuelLevelData = "FuelLevelData";

            /// <summary>燃料数据</summary>
            public const String FuelData = "FuelData";

            /// <summary>区域编码</summary>
            public const String AreaId = "AreaId";

            /// <summary>区域报警</summary>
            public const String AreaAlarm = "AreaAlarm";

            /// <summary>区域类型</summary>
            public const String AreaType = "AreaType";

            /// <summary>平台编码</summary>
            public const String PlatformId = "PlatformId";
        }
        #endregion
    }
}