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
    /// <summary>终端报警</summary>
    [Serializable]
    [DataObject]
    [Description("终端报警")]
    [BindTable("TerminalAlarm", Description = "终端报警", ConnName = "VehicleGPSVideoForHisData", DbType = DatabaseType.SqlServer)]
    public partial class TerminalAlarm
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("Id", "编号", "int")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(50)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VehicleId", "车辆编码", "int")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private String _AlarmType;
        /// <summary>报警类型</summary>
        [DisplayName("报警类型")]
        [Description("报警类型")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("AlarmType", "报警类型", "nvarchar(20)")]
        public String AlarmType { get => _AlarmType; set { if (OnPropertyChanging("AlarmType", value)) { _AlarmType = value; OnPropertyChanged("AlarmType"); } } }

        private String _AlarmSource;
        /// <summary>报警源</summary>
        [DisplayName("报警源")]
        [Description("报警源")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("AlarmSource", "报警源", "nvarchar(20)")]
        public String AlarmSource { get => _AlarmSource; set { if (OnPropertyChanging("AlarmSource", value)) { _AlarmSource = value; OnPropertyChanged("AlarmSource"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private DateTime _AlarmTime;
        /// <summary>报警时间</summary>
        [DisplayName("报警时间")]
        [Description("报警时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("AlarmTime", "报警时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime AlarmTime { get => _AlarmTime; set { if (OnPropertyChanging("AlarmTime", value)) { _AlarmTime = value; OnPropertyChanged("AlarmTime"); } } }

        private Int32 _Processed;
        /// <summary>处理</summary>
        [DisplayName("处理")]
        [Description("处理")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Processed", "处理", "int")]
        public Int32 Processed { get => _Processed; set { if (OnPropertyChanging("Processed", value)) { _Processed = value; OnPropertyChanged("Processed"); } } }

        private Double _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Latitude", "纬度", "float")]
        public Double Latitude { get => _Latitude; set { if (OnPropertyChanging("Latitude", value)) { _Latitude = value; OnPropertyChanged("Latitude"); } } }

        private Double _Longitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Longitude", "经度", "float")]
        public Double Longitude { get => _Longitude; set { if (OnPropertyChanging("Longitude", value)) { _Longitude = value; OnPropertyChanged("Longitude"); } } }

        private Double _Speed;
        /// <summary>速度</summary>
        [DisplayName("速度")]
        [Description("速度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Speed", "速度", "float")]
        public Double Speed { get => _Speed; set { if (OnPropertyChanging("Speed", value)) { _Speed = value; OnPropertyChanged("Speed"); } } }

        private String _Location;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 80)]
        [BindColumn("Location", "位置", "nvarchar(80)")]
        public String Location { get => _Location; set { if (OnPropertyChanging("Location", value)) { _Location = value; OnPropertyChanged("Location"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Remark", "备注", "nvarchar(50)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("Owner", "物主", "nvarchar(20)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private Int32 _AckSN;
        /// <summary>应答序号</summary>
        [DisplayName("应答序号")]
        [Description("应答序号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("AckSN", "应答序号", "int")]
        public Int32 AckSN { get => _AckSN; set { if (OnPropertyChanging("AckSN", value)) { _AckSN = value; OnPropertyChanged("AckSN"); } } }

        private String _Descr;
        /// <summary>描述</summary>
        [DisplayName("描述")]
        [Description("描述")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Descr", "描述", "nvarchar(50)")]
        public String Descr { get => _Descr; set { if (OnPropertyChanging("Descr", value)) { _Descr = value; OnPropertyChanged("Descr"); } } }

        private DateTime _ProcessedTime;
        /// <summary>处理时间</summary>
        [DisplayName("处理时间")]
        [Description("处理时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("ProcessedTime", "处理时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime ProcessedTime { get => _ProcessedTime; set { if (OnPropertyChanging("ProcessedTime", value)) { _ProcessedTime = value; OnPropertyChanged("ProcessedTime"); } } }

        private Int32 _ProcessedUserId;
        /// <summary>处理人Id</summary>
        [DisplayName("处理人Id")]
        [Description("处理人Id")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("ProcessedUserId", "处理人Id", "int")]
        public Int32 ProcessedUserId { get => _ProcessedUserId; set { if (OnPropertyChanging("ProcessedUserId", value)) { _ProcessedUserId = value; OnPropertyChanged("ProcessedUserId"); } } }

        private String _ProcessedUserName;
        /// <summary>处理人名称</summary>
        [DisplayName("处理人名称")]
        [Description("处理人名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("ProcessedUserName", "处理人名称", "nvarchar(50)")]
        public String ProcessedUserName { get => _ProcessedUserName; set { if (OnPropertyChanging("ProcessedUserName", value)) { _ProcessedUserName = value; OnPropertyChanged("ProcessedUserName"); } } }

        private Int32 _StopId;
        /// <summary>停止编码</summary>
        [DisplayName("停止编码")]
        [Description("停止编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("StopId", "停止编码", "int")]
        public Int32 StopId { get => _StopId; set { if (OnPropertyChanging("StopId", value)) { _StopId = value; OnPropertyChanged("StopId"); } } }

        private Double _Velocity;
        /// <summary>速度</summary>
        [DisplayName("速度")]
        [Description("速度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Velocity", "速度", "float")]
        public Double Velocity { get => _Velocity; set { if (OnPropertyChanging("Velocity", value)) { _Velocity = value; OnPropertyChanged("Velocity"); } } }

        private String _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Status", "状态", "nvarchar(255)")]
        public String Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private String _ProcessedUser;
        /// <summary>处理人</summary>
        [DisplayName("处理人")]
        [Description("处理人")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("ProcessedUser", "处理人", "nvarchar(255)")]
        public String ProcessedUser { get => _ProcessedUser; set { if (OnPropertyChanging("ProcessedUser", value)) { _ProcessedUser = value; OnPropertyChanged("ProcessedUser"); } } }

        private String _AlarmSrc;
        /// <summary>报警源</summary>
        [DisplayName("报警源")]
        [Description("报警源")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("AlarmSrc", "报警源", "nvarchar(255)")]
        public String AlarmSrc { get => _AlarmSrc; set { if (OnPropertyChanging("AlarmSrc", value)) { _AlarmSrc = value; OnPropertyChanged("AlarmSrc"); } } }

        private String _Station;
        /// <summary>站点</summary>
        [DisplayName("站点")]
        [Description("站点")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Station", "站点", "nvarchar(255)")]
        public String Station { get => _Station; set { if (OnPropertyChanging("Station", value)) { _Station = value; OnPropertyChanged("Station"); } } }

        private Double _Oil1;
        /// <summary>油气</summary>
        [DisplayName("油气")]
        [Description("油气")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Oil1", "油气", "float")]
        public Double Oil1 { get => _Oil1; set { if (OnPropertyChanging("Oil1", value)) { _Oil1 = value; OnPropertyChanged("Oil1"); } } }

        private Double _Mileage1;
        /// <summary>里程</summary>
        [DisplayName("里程")]
        [Description("里程")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Mileage1", "里程", "float")]
        public Double Mileage1 { get => _Mileage1; set { if (OnPropertyChanging("Mileage1", value)) { _Mileage1 = value; OnPropertyChanged("Mileage1"); } } }
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
                    case "PlateNo": return _PlateNo;
                    case "VehicleId": return _VehicleId;
                    case "AlarmType": return _AlarmType;
                    case "AlarmSource": return _AlarmSource;
                    case "CreateTime": return _CreateTime;
                    case "AlarmTime": return _AlarmTime;
                    case "Processed": return _Processed;
                    case "Latitude": return _Latitude;
                    case "Longitude": return _Longitude;
                    case "Speed": return _Speed;
                    case "Location": return _Location;
                    case "Deleted": return _Deleted;
                    case "TenantId": return _TenantId;
                    case "Remark": return _Remark;
                    case "Owner": return _Owner;
                    case "AckSN": return _AckSN;
                    case "Descr": return _Descr;
                    case "ProcessedTime": return _ProcessedTime;
                    case "ProcessedUserId": return _ProcessedUserId;
                    case "ProcessedUserName": return _ProcessedUserName;
                    case "StopId": return _StopId;
                    case "Velocity": return _Velocity;
                    case "Status": return _Status;
                    case "ProcessedUser": return _ProcessedUser;
                    case "AlarmSrc": return _AlarmSrc;
                    case "Station": return _Station;
                    case "Oil1": return _Oil1;
                    case "Mileage1": return _Mileage1;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "AlarmType": _AlarmType = Convert.ToString(value); break;
                    case "AlarmSource": _AlarmSource = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "AlarmTime": _AlarmTime = value.ToDateTime(); break;
                    case "Processed": _Processed = value.ToInt(); break;
                    case "Latitude": _Latitude = value.ToDouble(); break;
                    case "Longitude": _Longitude = value.ToDouble(); break;
                    case "Speed": _Speed = value.ToDouble(); break;
                    case "Location": _Location = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "AckSN": _AckSN = value.ToInt(); break;
                    case "Descr": _Descr = Convert.ToString(value); break;
                    case "ProcessedTime": _ProcessedTime = value.ToDateTime(); break;
                    case "ProcessedUserId": _ProcessedUserId = value.ToInt(); break;
                    case "ProcessedUserName": _ProcessedUserName = Convert.ToString(value); break;
                    case "StopId": _StopId = value.ToInt(); break;
                    case "Velocity": _Velocity = value.ToDouble(); break;
                    case "Status": _Status = Convert.ToString(value); break;
                    case "ProcessedUser": _ProcessedUser = Convert.ToString(value); break;
                    case "AlarmSrc": _AlarmSrc = Convert.ToString(value); break;
                    case "Station": _Station = Convert.ToString(value); break;
                    case "Oil1": _Oil1 = value.ToDouble(); break;
                    case "Mileage1": _Mileage1 = value.ToDouble(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得终端报警字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>报警类型</summary>
            public static readonly Field AlarmType = FindByName("AlarmType");

            /// <summary>报警源</summary>
            public static readonly Field AlarmSource = FindByName("AlarmSource");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>报警时间</summary>
            public static readonly Field AlarmTime = FindByName("AlarmTime");

            /// <summary>处理</summary>
            public static readonly Field Processed = FindByName("Processed");

            /// <summary>纬度</summary>
            public static readonly Field Latitude = FindByName("Latitude");

            /// <summary>经度</summary>
            public static readonly Field Longitude = FindByName("Longitude");

            /// <summary>速度</summary>
            public static readonly Field Speed = FindByName("Speed");

            /// <summary>位置</summary>
            public static readonly Field Location = FindByName("Location");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>应答序号</summary>
            public static readonly Field AckSN = FindByName("AckSN");

            /// <summary>描述</summary>
            public static readonly Field Descr = FindByName("Descr");

            /// <summary>处理时间</summary>
            public static readonly Field ProcessedTime = FindByName("ProcessedTime");

            /// <summary>处理人Id</summary>
            public static readonly Field ProcessedUserId = FindByName("ProcessedUserId");

            /// <summary>处理人名称</summary>
            public static readonly Field ProcessedUserName = FindByName("ProcessedUserName");

            /// <summary>停止编码</summary>
            public static readonly Field StopId = FindByName("StopId");

            /// <summary>速度</summary>
            public static readonly Field Velocity = FindByName("Velocity");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>处理人</summary>
            public static readonly Field ProcessedUser = FindByName("ProcessedUser");

            /// <summary>报警源</summary>
            public static readonly Field AlarmSrc = FindByName("AlarmSrc");

            /// <summary>站点</summary>
            public static readonly Field Station = FindByName("Station");

            /// <summary>油气</summary>
            public static readonly Field Oil1 = FindByName("Oil1");

            /// <summary>里程</summary>
            public static readonly Field Mileage1 = FindByName("Mileage1");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得终端报警字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String Id = "Id";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>报警类型</summary>
            public const String AlarmType = "AlarmType";

            /// <summary>报警源</summary>
            public const String AlarmSource = "AlarmSource";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>报警时间</summary>
            public const String AlarmTime = "AlarmTime";

            /// <summary>处理</summary>
            public const String Processed = "Processed";

            /// <summary>纬度</summary>
            public const String Latitude = "Latitude";

            /// <summary>经度</summary>
            public const String Longitude = "Longitude";

            /// <summary>速度</summary>
            public const String Speed = "Speed";

            /// <summary>位置</summary>
            public const String Location = "Location";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>应答序号</summary>
            public const String AckSN = "AckSN";

            /// <summary>描述</summary>
            public const String Descr = "Descr";

            /// <summary>处理时间</summary>
            public const String ProcessedTime = "ProcessedTime";

            /// <summary>处理人Id</summary>
            public const String ProcessedUserId = "ProcessedUserId";

            /// <summary>处理人名称</summary>
            public const String ProcessedUserName = "ProcessedUserName";

            /// <summary>停止编码</summary>
            public const String StopId = "StopId";

            /// <summary>速度</summary>
            public const String Velocity = "Velocity";

            /// <summary>状态</summary>
            public const String Status = "Status";

            /// <summary>处理人</summary>
            public const String ProcessedUser = "ProcessedUser";

            /// <summary>报警源</summary>
            public const String AlarmSrc = "AlarmSrc";

            /// <summary>站点</summary>
            public const String Station = "Station";

            /// <summary>油气</summary>
            public const String Oil1 = "Oil1";

            /// <summary>里程</summary>
            public const String Mileage1 = "Mileage1";
        }
        #endregion
    }
}