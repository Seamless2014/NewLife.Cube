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
    /// <summary>报警记录</summary>
    [Serializable]
    [DataObject]
    [Description("报警记录")]
    [BindIndex("IU_AlarmRecord_PlateNo_StartTime_EndTime_AlarmType", true, "PlateNo,StartTime,EndTime,AlarmType")]
    [BindIndex("IX_AlarmRecord_PlateNo_StartTime_EndTime", false, "PlateNo,StartTime,EndTime")]
    [BindIndex("IX_AlarmRecord_PlateNo", false, "PlateNo")]
    [BindIndex("IX_AlarmRecord_StartTime_EndTime", false, "StartTime,EndTime")]
    [BindTable("AlarmRecord", Description = "报警记录", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class AlarmRecord
    {
        #region 属性
        private Int32 _AlarmId;
        /// <summary>报警编码</summary>
        [DisplayName("报警编码")]
        [Description("报警编码")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("AlarmId", "报警编码", "")]
        public Int32 AlarmId { get => _AlarmId; set { if (OnPropertyChanging("AlarmId", value)) { _AlarmId = value; OnPropertyChanged("AlarmId"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn("PlateNo", "车牌号", "")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private DateTime _StartTime;
        /// <summary>起始时间</summary>
        [DisplayName("起始时间")]
        [Description("起始时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("StartTime", "起始时间", "", Precision = 0, Scale = 3)]
        public DateTime StartTime { get => _StartTime; set { if (OnPropertyChanging("StartTime", value)) { _StartTime = value; OnPropertyChanged("StartTime"); } } }

        private DateTime _EndTime;
        /// <summary>结束时间</summary>
        [DisplayName("结束时间")]
        [Description("结束时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("EndTime", "结束时间", "", Precision = 0, Scale = 3)]
        public DateTime EndTime { get => _EndTime; set { if (OnPropertyChanging("EndTime", value)) { _EndTime = value; OnPropertyChanged("EndTime"); } } }

        private Double _TimeSpan;
        /// <summary>持续时间</summary>
        [DisplayName("持续时间")]
        [Description("持续时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TimeSpan", "持续时间", "")]
        public Double TimeSpan { get => _TimeSpan; set { if (OnPropertyChanging("TimeSpan", value)) { _TimeSpan = value; OnPropertyChanged("TimeSpan"); } } }

        private Double _Velocity;
        /// <summary>速度</summary>
        [DisplayName("速度")]
        [Description("速度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Velocity", "速度", "")]
        public Double Velocity { get => _Velocity; set { if (OnPropertyChanging("Velocity", value)) { _Velocity = value; OnPropertyChanged("Velocity"); } } }

        private String _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 55)]
        [BindColumn("Status", "状态", "")]
        public String Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

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

        private String _Location;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Location", "位置", "")]
        public String Location { get => _Location; set { if (OnPropertyChanging("Location", value)) { _Location = value; OnPropertyChanged("Location"); } } }

        private Double _Latitude1;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Latitude1", "纬度", "")]
        public Double Latitude1 { get => _Latitude1; set { if (OnPropertyChanging("Latitude1", value)) { _Latitude1 = value; OnPropertyChanged("Latitude1"); } } }

        private Double _Longitude1;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Longitude1", "经度", "")]
        public Double Longitude1 { get => _Longitude1; set { if (OnPropertyChanging("Longitude1", value)) { _Longitude1 = value; OnPropertyChanged("Longitude1"); } } }

        private String _Location1;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Location1", "位置", "")]
        public String Location1 { get => _Location1; set { if (OnPropertyChanging("Location1", value)) { _Location1 = value; OnPropertyChanged("Location1"); } } }

        private Int32 _Processed;
        /// <summary>处理</summary>
        [DisplayName("处理")]
        [Description("处理")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Processed", "处理", "")]
        public Int32 Processed { get => _Processed; set { if (OnPropertyChanging("Processed", value)) { _Processed = value; OnPropertyChanged("Processed"); } } }

        private DateTime _ProcessedTime;
        /// <summary>处理时间</summary>
        [DisplayName("处理时间")]
        [Description("处理时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("ProcessedTime", "处理时间", "", Precision = 0, Scale = 3)]
        public DateTime ProcessedTime { get => _ProcessedTime; set { if (OnPropertyChanging("ProcessedTime", value)) { _ProcessedTime = value; OnPropertyChanged("ProcessedTime"); } } }

        private String _Type;
        /// <summary>类型</summary>
        [DisplayName("类型")]
        [Description("类型")]
        [DataObjectField(false, false, true, 25)]
        [BindColumn("Type", "类型", "")]
        public String Type { get => _Type; set { if (OnPropertyChanging("Type", value)) { _Type = value; OnPropertyChanged("Type"); } } }

        private String _ChildType;
        /// <summary>子类型</summary>
        [DisplayName("子类型")]
        [Description("子类型")]
        [DataObjectField(false, false, true, 25)]
        [BindColumn("ChildType", "子类型", "")]
        public String ChildType { get => _ChildType; set { if (OnPropertyChanging("ChildType", value)) { _ChildType = value; OnPropertyChanged("ChildType"); } } }

        private Int32 _Station;
        /// <summary>站点</summary>
        [DisplayName("站点")]
        [Description("站点")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Station", "站点", "")]
        public Int32 Station { get => _Station; set { if (OnPropertyChanging("Station", value)) { _Station = value; OnPropertyChanged("Station"); } } }

        private String _ValveState;
        /// <summary>阀门状态</summary>
        [DisplayName("阀门状态")]
        [Description("阀门状态")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("ValveState", "阀门状态", "")]
        public String ValveState { get => _ValveState; set { if (OnPropertyChanging("ValveState", value)) { _ValveState = value; OnPropertyChanged("ValveState"); } } }

        private String _ValveState1;
        /// <summary>阀门状态1</summary>
        [DisplayName("阀门状态1")]
        [Description("阀门状态1")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("ValveState1", "阀门状态1", "")]
        public String ValveState1 { get => _ValveState1; set { if (OnPropertyChanging("ValveState1", value)) { _ValveState1 = value; OnPropertyChanged("ValveState1"); } } }

        private Double _Gas1;
        /// <summary>油气1</summary>
        [DisplayName("油气1")]
        [Description("油气1")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Gas1", "油气1", "")]
        public Double Gas1 { get => _Gas1; set { if (OnPropertyChanging("Gas1", value)) { _Gas1 = value; OnPropertyChanged("Gas1"); } } }

        private Double _Gas2;
        /// <summary>油气2</summary>
        [DisplayName("油气2")]
        [Description("油气2")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Gas2", "油气2", "")]
        public Double Gas2 { get => _Gas2; set { if (OnPropertyChanging("Gas2", value)) { _Gas2 = value; OnPropertyChanged("Gas2"); } } }

        private Double _Mileage1;
        /// <summary>里程1</summary>
        [DisplayName("里程1")]
        [Description("里程1")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Mileage1", "里程1", "")]
        public Double Mileage1 { get => _Mileage1; set { if (OnPropertyChanging("Mileage1", value)) { _Mileage1 = value; OnPropertyChanged("Mileage1"); } } }

        private Double _Mileage2;
        /// <summary>里程2</summary>
        [DisplayName("里程2")]
        [Description("里程2")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Mileage2", "里程2", "")]
        public Double Mileage2 { get => _Mileage2; set { if (OnPropertyChanging("Mileage2", value)) { _Mileage2 = value; OnPropertyChanged("Mileage2"); } } }

        private String _VideoFileName;
        /// <summary>视频文件名称</summary>
        [DisplayName("视频文件名称")]
        [Description("视频文件名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("VideoFileName", "视频文件名称", "")]
        public String VideoFileName { get => _VideoFileName; set { if (OnPropertyChanging("VideoFileName", value)) { _VideoFileName = value; OnPropertyChanged("VideoFileName"); } } }

        private String _Flag;
        /// <summary>标识</summary>
        [DisplayName("标识")]
        [Description("标识")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Flag", "标识", "")]
        public String Flag { get => _Flag; set { if (OnPropertyChanging("Flag", value)) { _Flag = value; OnPropertyChanged("Flag"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TenantId", "租户编码", "")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "物主", "")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("VehicleId", "车辆编码", "")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private Int32 _ResponseSN;
        /// <summary>响应序号</summary>
        [DisplayName("响应序号")]
        [Description("响应序号")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("ResponseSN", "响应序号", "")]
        public Int32 ResponseSN { get => _ResponseSN; set { if (OnPropertyChanging("ResponseSN", value)) { _ResponseSN = value; OnPropertyChanged("ResponseSN"); } } }

        private Int32 _ProcessedUserId;
        /// <summary>处理用户编码</summary>
        [DisplayName("处理用户编码")]
        [Description("处理用户编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("ProcessedUserId", "处理用户编码", "")]
        public Int32 ProcessedUserId { get => _ProcessedUserId; set { if (OnPropertyChanging("ProcessedUserId", value)) { _ProcessedUserId = value; OnPropertyChanged("ProcessedUserId"); } } }

        private String _ProcessedUserName;
        /// <summary>处理用户名称</summary>
        [DisplayName("处理用户名称")]
        [Description("处理用户名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("ProcessedUserName", "处理用户名称", "")]
        public String ProcessedUserName { get => _ProcessedUserName; set { if (OnPropertyChanging("ProcessedUserName", value)) { _ProcessedUserName = value; OnPropertyChanged("ProcessedUserName"); } } }

        private String _AlarmSource;
        /// <summary>报警源</summary>
        [DisplayName("报警源")]
        [Description("报警源")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("AlarmSource", "报警源", "")]
        public String AlarmSource { get => _AlarmSource; set { if (OnPropertyChanging("AlarmSource", value)) { _AlarmSource = value; OnPropertyChanged("AlarmSource"); } } }

        private String _AlarmType;
        /// <summary>报警类型</summary>
        [DisplayName("报警类型")]
        [Description("报警类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("AlarmType", "报警类型", "")]
        public String AlarmType { get => _AlarmType; set { if (OnPropertyChanging("AlarmType", value)) { _AlarmType = value; OnPropertyChanged("AlarmType"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
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
                    case "AlarmId": return _AlarmId;
                    case "PlateNo": return _PlateNo;
                    case "StartTime": return _StartTime;
                    case "EndTime": return _EndTime;
                    case "TimeSpan": return _TimeSpan;
                    case "Velocity": return _Velocity;
                    case "Status": return _Status;
                    case "Latitude": return _Latitude;
                    case "Longitude": return _Longitude;
                    case "Location": return _Location;
                    case "Latitude1": return _Latitude1;
                    case "Longitude1": return _Longitude1;
                    case "Location1": return _Location1;
                    case "Processed": return _Processed;
                    case "ProcessedTime": return _ProcessedTime;
                    case "Type": return _Type;
                    case "ChildType": return _ChildType;
                    case "Station": return _Station;
                    case "ValveState": return _ValveState;
                    case "ValveState1": return _ValveState1;
                    case "Gas1": return _Gas1;
                    case "Gas2": return _Gas2;
                    case "Mileage1": return _Mileage1;
                    case "Mileage2": return _Mileage2;
                    case "VideoFileName": return _VideoFileName;
                    case "Flag": return _Flag;
                    case "Remark": return _Remark;
                    case "CreateTime": return _CreateTime;
                    case "TenantId": return _TenantId;
                    case "Owner": return _Owner;
                    case "VehicleId": return _VehicleId;
                    case "ResponseSN": return _ResponseSN;
                    case "ProcessedUserId": return _ProcessedUserId;
                    case "ProcessedUserName": return _ProcessedUserName;
                    case "AlarmSource": return _AlarmSource;
                    case "AlarmType": return _AlarmType;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "AlarmId": _AlarmId = value.ToInt(); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "StartTime": _StartTime = value.ToDateTime(); break;
                    case "EndTime": _EndTime = value.ToDateTime(); break;
                    case "TimeSpan": _TimeSpan = value.ToDouble(); break;
                    case "Velocity": _Velocity = value.ToDouble(); break;
                    case "Status": _Status = Convert.ToString(value); break;
                    case "Latitude": _Latitude = value.ToDouble(); break;
                    case "Longitude": _Longitude = value.ToDouble(); break;
                    case "Location": _Location = Convert.ToString(value); break;
                    case "Latitude1": _Latitude1 = value.ToDouble(); break;
                    case "Longitude1": _Longitude1 = value.ToDouble(); break;
                    case "Location1": _Location1 = Convert.ToString(value); break;
                    case "Processed": _Processed = value.ToInt(); break;
                    case "ProcessedTime": _ProcessedTime = value.ToDateTime(); break;
                    case "Type": _Type = Convert.ToString(value); break;
                    case "ChildType": _ChildType = Convert.ToString(value); break;
                    case "Station": _Station = value.ToInt(); break;
                    case "ValveState": _ValveState = Convert.ToString(value); break;
                    case "ValveState1": _ValveState1 = Convert.ToString(value); break;
                    case "Gas1": _Gas1 = value.ToDouble(); break;
                    case "Gas2": _Gas2 = value.ToDouble(); break;
                    case "Mileage1": _Mileage1 = value.ToDouble(); break;
                    case "Mileage2": _Mileage2 = value.ToDouble(); break;
                    case "VideoFileName": _VideoFileName = Convert.ToString(value); break;
                    case "Flag": _Flag = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "ResponseSN": _ResponseSN = value.ToInt(); break;
                    case "ProcessedUserId": _ProcessedUserId = value.ToInt(); break;
                    case "ProcessedUserName": _ProcessedUserName = Convert.ToString(value); break;
                    case "AlarmSource": _AlarmSource = Convert.ToString(value); break;
                    case "AlarmType": _AlarmType = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得报警记录字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>报警编码</summary>
            public static readonly Field AlarmId = FindByName("AlarmId");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>起始时间</summary>
            public static readonly Field StartTime = FindByName("StartTime");

            /// <summary>结束时间</summary>
            public static readonly Field EndTime = FindByName("EndTime");

            /// <summary>时间跨度</summary>
            public static readonly Field TimeSpan = FindByName("TimeSpan");

            /// <summary>速度</summary>
            public static readonly Field Velocity = FindByName("Velocity");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>纬度</summary>
            public static readonly Field Latitude = FindByName("Latitude");

            /// <summary>经度</summary>
            public static readonly Field Longitude = FindByName("Longitude");

            /// <summary>位置</summary>
            public static readonly Field Location = FindByName("Location");

            /// <summary>纬度</summary>
            public static readonly Field Latitude1 = FindByName("Latitude1");

            /// <summary>经度</summary>
            public static readonly Field Longitude1 = FindByName("Longitude1");

            /// <summary>位置</summary>
            public static readonly Field Location1 = FindByName("Location1");

            /// <summary>处理</summary>
            public static readonly Field Processed = FindByName("Processed");

            /// <summary>处理时间</summary>
            public static readonly Field ProcessedTime = FindByName("ProcessedTime");

            /// <summary>类型</summary>
            public static readonly Field Type = FindByName("Type");

            /// <summary>子类型</summary>
            public static readonly Field ChildType = FindByName("ChildType");

            /// <summary>站点</summary>
            public static readonly Field Station = FindByName("Station");

            /// <summary>阀门状态</summary>
            public static readonly Field ValveState = FindByName("ValveState");

            /// <summary>阀门状态1</summary>
            public static readonly Field ValveState1 = FindByName("ValveState1");

            /// <summary>油气1</summary>
            public static readonly Field Gas1 = FindByName("Gas1");

            /// <summary>油气2</summary>
            public static readonly Field Gas2 = FindByName("Gas2");

            /// <summary>里程1</summary>
            public static readonly Field Mileage1 = FindByName("Mileage1");

            /// <summary>里程2</summary>
            public static readonly Field Mileage2 = FindByName("Mileage2");

            /// <summary>视频文件名称</summary>
            public static readonly Field VideoFileName = FindByName("VideoFileName");

            /// <summary>标识</summary>
            public static readonly Field Flag = FindByName("Flag");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>响应序号</summary>
            public static readonly Field ResponseSN = FindByName("ResponseSN");

            /// <summary>处理用户编码</summary>
            public static readonly Field ProcessedUserId = FindByName("ProcessedUserId");

            /// <summary>处理用户名称</summary>
            public static readonly Field ProcessedUserName = FindByName("ProcessedUserName");

            /// <summary>报警源</summary>
            public static readonly Field AlarmSource = FindByName("AlarmSource");

            /// <summary>报警类型</summary>
            public static readonly Field AlarmType = FindByName("AlarmType");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得报警记录字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>报警编码</summary>
            public const String AlarmId = "AlarmId";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>起始时间</summary>
            public const String StartTime = "StartTime";

            /// <summary>结束时间</summary>
            public const String EndTime = "EndTime";

            /// <summary>时间跨度</summary>
            public const String TimeSpan = "TimeSpan";

            /// <summary>速度</summary>
            public const String Velocity = "Velocity";

            /// <summary>状态</summary>
            public const String Status = "Status";

            /// <summary>纬度</summary>
            public const String Latitude = "Latitude";

            /// <summary>经度</summary>
            public const String Longitude = "Longitude";

            /// <summary>位置</summary>
            public const String Location = "Location";

            /// <summary>纬度</summary>
            public const String Latitude1 = "Latitude1";

            /// <summary>经度</summary>
            public const String Longitude1 = "Longitude1";

            /// <summary>位置</summary>
            public const String Location1 = "Location1";

            /// <summary>处理</summary>
            public const String Processed = "Processed";

            /// <summary>处理时间</summary>
            public const String ProcessedTime = "ProcessedTime";

            /// <summary>类型</summary>
            public const String Type = "Type";

            /// <summary>子类型</summary>
            public const String ChildType = "ChildType";

            /// <summary>站点</summary>
            public const String Station = "Station";

            /// <summary>阀门状态</summary>
            public const String ValveState = "ValveState";

            /// <summary>阀门状态1</summary>
            public const String ValveState1 = "ValveState1";

            /// <summary>油气1</summary>
            public const String Gas1 = "Gas1";

            /// <summary>油气2</summary>
            public const String Gas2 = "Gas2";

            /// <summary>里程1</summary>
            public const String Mileage1 = "Mileage1";

            /// <summary>里程2</summary>
            public const String Mileage2 = "Mileage2";

            /// <summary>视频文件名称</summary>
            public const String VideoFileName = "VideoFileName";

            /// <summary>标识</summary>
            public const String Flag = "Flag";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>响应序号</summary>
            public const String ResponseSN = "ResponseSN";

            /// <summary>处理用户编码</summary>
            public const String ProcessedUserId = "ProcessedUserId";

            /// <summary>处理用户名称</summary>
            public const String ProcessedUserName = "ProcessedUserName";

            /// <summary>报警源</summary>
            public const String AlarmSource = "AlarmSource";

            /// <summary>报警类型</summary>
            public const String AlarmType = "AlarmType";
        }
        #endregion
    }
}