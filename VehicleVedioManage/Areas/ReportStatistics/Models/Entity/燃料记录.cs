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
    /// <summary>燃料记录</summary>
    [Serializable]
    [DataObject]
    [Description("燃料记录")]
    [BindIndex("IU_FuelRecord_PlateNo", true, "PlateNo")]
    [BindTable("FuelRecord", Description = "燃料记录", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class FuelRecord
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "编码", "")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private String _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("VehicleId", "车辆编码", "")]
        public String VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private Int32 _CommandId;
        /// <summary>指令编码</summary>
        [DisplayName("指令编码")]
        [Description("指令编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CommandId", "指令编码", "")]
        public Int32 CommandId { get => _CommandId; set { if (OnPropertyChanging("CommandId", value)) { _CommandId = value; OnPropertyChanged("CommandId"); } } }

        private String _OrderId;
        /// <summary>命令编码</summary>
        [DisplayName("命令编码")]
        [Description("命令编码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("OrderId", "命令编码", "")]
        public String OrderId { get => _OrderId; set { if (OnPropertyChanging("OrderId", value)) { _OrderId = value; OnPropertyChanged("OrderId"); } } }

        private DateTime _SendTime;
        /// <summary>发送时间</summary>
        [DisplayName("发送时间")]
        [Description("发送时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("SendTime", "发送时间", "", Precision = 0, Scale = 3)]
        public DateTime SendTime { get => _SendTime; set { if (OnPropertyChanging("SendTime", value)) { _SendTime = value; OnPropertyChanged("SendTime"); } } }

        private Double _Longitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Longitude", "经度", "")]
        public Double Longitude { get => _Longitude; set { if (OnPropertyChanging("Longitude", value)) { _Longitude = value; OnPropertyChanged("Longitude"); } } }

        private Double _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Latitude", "纬度", "")]
        public Double Latitude { get => _Latitude; set { if (OnPropertyChanging("Latitude", value)) { _Latitude = value; OnPropertyChanged("Latitude"); } } }

        private Double _Velocity;
        /// <summary>速度</summary>
        [DisplayName("速度")]
        [Description("速度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Velocity", "速度", "")]
        public Double Velocity { get => _Velocity; set { if (OnPropertyChanging("Velocity", value)) { _Velocity = value; OnPropertyChanged("Velocity"); } } }

        private Int32 _Direction;
        /// <summary>方向</summary>
        [DisplayName("方向")]
        [Description("方向")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Direction", "方向", "")]
        public Int32 Direction { get => _Direction; set { if (OnPropertyChanging("Direction", value)) { _Direction = value; OnPropertyChanged("Direction"); } } }

        private Int32 _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Status", "状态", "")]
        public Int32 Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private Double _Mileage;
        /// <summary>里程</summary>
        [DisplayName("里程")]
        [Description("里程")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Mileage", "里程", "")]
        public Double Mileage { get => _Mileage; set { if (OnPropertyChanging("Mileage", value)) { _Mileage = value; OnPropertyChanged("Mileage"); } } }

        private Double _Oil;
        /// <summary>油气</summary>
        [DisplayName("油气")]
        [Description("油气")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Oil", "油气", "")]
        public Double Oil { get => _Oil; set { if (OnPropertyChanging("Oil", value)) { _Oil = value; OnPropertyChanged("Oil"); } } }

        private Double _RecordVelocity;
        /// <summary>记录仪速度</summary>
        [DisplayName("记录仪速度")]
        [Description("记录仪速度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("RecordVelocity", "记录仪速度", "")]
        public Double RecordVelocity { get => _RecordVelocity; set { if (OnPropertyChanging("RecordVelocity", value)) { _RecordVelocity = value; OnPropertyChanged("RecordVelocity"); } } }

        private String _Location;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn("Location", "位置", "")]
        public String Location { get => _Location; set { if (OnPropertyChanging("Location", value)) { _Location = value; OnPropertyChanged("Location"); } } }

        private String _AlarmState;
        /// <summary>报警状态</summary>
        [DisplayName("报警状态")]
        [Description("报警状态")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("AlarmState", "报警状态", "")]
        public String AlarmState { get => _AlarmState; set { if (OnPropertyChanging("AlarmState", value)) { _AlarmState = value; OnPropertyChanged("AlarmState"); } } }

        private Double _Gas;
        /// <summary>气体</summary>
        [DisplayName("气体")]
        [Description("气体")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Gas", "气体", "")]
        public Double Gas { get => _Gas; set { if (OnPropertyChanging("Gas", value)) { _Gas = value; OnPropertyChanged("Gas"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TenantId", "租户编码", "")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("Owner", "物主", "")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
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
                    case "ID": return _ID;
                    case "VehicleId": return _VehicleId;
                    case "CommandId": return _CommandId;
                    case "OrderId": return _OrderId;
                    case "SendTime": return _SendTime;
                    case "Longitude": return _Longitude;
                    case "Latitude": return _Latitude;
                    case "Velocity": return _Velocity;
                    case "Direction": return _Direction;
                    case "Status": return _Status;
                    case "Mileage": return _Mileage;
                    case "Oil": return _Oil;
                    case "RecordVelocity": return _RecordVelocity;
                    case "Location": return _Location;
                    case "AlarmState": return _AlarmState;
                    case "Gas": return _Gas;
                    case "TenantId": return _TenantId;
                    case "CreateTime": return _CreateTime;
                    case "Remark": return _Remark;
                    case "Owner": return _Owner;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = value.ToInt(); break;
                    case "VehicleId": _VehicleId = Convert.ToString(value); break;
                    case "CommandId": _CommandId = value.ToInt(); break;
                    case "OrderId": _OrderId = Convert.ToString(value); break;
                    case "SendTime": _SendTime = value.ToDateTime(); break;
                    case "Longitude": _Longitude = value.ToDouble(); break;
                    case "Latitude": _Latitude = value.ToDouble(); break;
                    case "Velocity": _Velocity = value.ToDouble(); break;
                    case "Direction": _Direction = value.ToInt(); break;
                    case "Status": _Status = value.ToInt(); break;
                    case "Mileage": _Mileage = value.ToDouble(); break;
                    case "Oil": _Oil = value.ToDouble(); break;
                    case "RecordVelocity": _RecordVelocity = value.ToDouble(); break;
                    case "Location": _Location = Convert.ToString(value); break;
                    case "AlarmState": _AlarmState = Convert.ToString(value); break;
                    case "Gas": _Gas = value.ToDouble(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得燃料记录字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编码</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>指令编码</summary>
            public static readonly Field CommandId = FindByName("CommandId");

            /// <summary>命令编码</summary>
            public static readonly Field OrderId = FindByName("OrderId");

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

            /// <summary>里程</summary>
            public static readonly Field Mileage = FindByName("Mileage");

            /// <summary>油气</summary>
            public static readonly Field Oil = FindByName("Oil");

            /// <summary>记录仪速度</summary>
            public static readonly Field RecordVelocity = FindByName("RecordVelocity");

            /// <summary>位置</summary>
            public static readonly Field Location = FindByName("Location");

            /// <summary>报警状态</summary>
            public static readonly Field AlarmState = FindByName("AlarmState");

            /// <summary>气体</summary>
            public static readonly Field Gas = FindByName("Gas");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得燃料记录字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编码</summary>
            public const String ID = "ID";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>指令编码</summary>
            public const String CommandId = "CommandId";

            /// <summary>命令编码</summary>
            public const String OrderId = "OrderId";

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

            /// <summary>里程</summary>
            public const String Mileage = "Mileage";

            /// <summary>油气</summary>
            public const String Oil = "Oil";

            /// <summary>记录仪速度</summary>
            public const String RecordVelocity = "RecordVelocity";

            /// <summary>位置</summary>
            public const String Location = "Location";

            /// <summary>报警状态</summary>
            public const String AlarmState = "AlarmState";

            /// <summary>气体</summary>
            public const String Gas = "Gas";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>物主</summary>
            public const String Owner = "Owner";
        }
        #endregion
    }
}