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
    /// <summary>报警信息响应</summary>
    [Serializable]
    [DataObject]
    [Description("报警信息响应")]
    [BindTable("WarnMsgUrgTodoReq", Description = "报警信息响应", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class WarnMsgUrgTodoReq
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("ID", "编号", "int")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private Int32 _AckFlag;
        /// <summary>应答标识</summary>
        [DisplayName("应答标识")]
        [Description("应答标识")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("AckFlag", "应答标识", "int")]
        public Int32 AckFlag { get => _AckFlag; set { if (OnPropertyChanging("AckFlag", value)) { _AckFlag = value; OnPropertyChanged("AckFlag"); } } }

        private DateTime _AckTime;
        /// <summary>应答时间</summary>
        [DisplayName("应答时间")]
        [Description("应答时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("AckTime", "应答时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime AckTime { get => _AckTime; set { if (OnPropertyChanging("AckTime", value)) { _AckTime = value; OnPropertyChanged("AckTime"); } } }

        private DateTime _CreateDate;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateDate", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateDate { get => _CreateDate; set { if (OnPropertyChanging("CreateDate", value)) { _CreateDate = value; OnPropertyChanged("CreateDate"); } } }

        private Int32 _Origin;
        /// <summary>原始</summary>
        [DisplayName("原始")]
        [Description("原始")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Origin", "原始", "int")]
        public Int32 Origin { get => _Origin; set { if (OnPropertyChanging("Origin", value)) { _Origin = value; OnPropertyChanged("Origin"); } } }

        private Int32 _Result;
        /// <summary>结果</summary>
        [DisplayName("结果")]
        [Description("结果")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Result", "结果", "int")]
        public Int32 Result { get => _Result; set { if (OnPropertyChanging("Result", value)) { _Result = value; OnPropertyChanged("Result"); } } }

        private Int32 _SupervicsionId;
        /// <summary>监督编码</summary>
        [DisplayName("监督编码")]
        [Description("监督编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("SupervicsionId", "监督编码", "int")]
        public Int32 SupervicsionId { get => _SupervicsionId; set { if (OnPropertyChanging("SupervicsionId", value)) { _SupervicsionId = value; OnPropertyChanged("SupervicsionId"); } } }

        private DateTime _SupervisionEndTime;
        /// <summary>监督结束时间</summary>
        [DisplayName("监督结束时间")]
        [Description("监督结束时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("SupervisionEndTime", "监督结束时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime SupervisionEndTime { get => _SupervisionEndTime; set { if (OnPropertyChanging("SupervisionEndTime", value)) { _SupervisionEndTime = value; OnPropertyChanged("SupervisionEndTime"); } } }

        private Int32 _SupervisionLevel;
        /// <summary>监督级别</summary>
        [DisplayName("监督级别")]
        [Description("监督级别")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("SupervisionLevel", "监督级别", "int")]
        public Int32 SupervisionLevel { get => _SupervisionLevel; set { if (OnPropertyChanging("SupervisionLevel", value)) { _SupervisionLevel = value; OnPropertyChanged("SupervisionLevel"); } } }

        private String _Supervisor;
        /// <summary>监督人</summary>
        [DisplayName("监督人")]
        [Description("监督人")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Supervisor", "监督人", "varchar(255)")]
        public String Supervisor { get => _Supervisor; set { if (OnPropertyChanging("Supervisor", value)) { _Supervisor = value; OnPropertyChanged("Supervisor"); } } }

        private String _SupervisorEmail;
        /// <summary>监督邮件</summary>
        [DisplayName("监督邮件")]
        [Description("监督邮件")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("SupervisorEmail", "监督邮件", "varchar(255)")]
        public String SupervisorEmail { get => _SupervisorEmail; set { if (OnPropertyChanging("SupervisorEmail", value)) { _SupervisorEmail = value; OnPropertyChanged("SupervisorEmail"); } } }

        private String _SupervisorTel;
        /// <summary>监督电话</summary>
        [DisplayName("监督电话")]
        [Description("监督电话")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("SupervisorTel", "监督电话", "varchar(255)")]
        public String SupervisorTel { get => _SupervisorTel; set { if (OnPropertyChanging("SupervisorTel", value)) { _SupervisorTel = value; OnPropertyChanged("SupervisorTel"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VehicleId", "车辆编码", "int")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private Int32 _WarnSrc;
        /// <summary>报警源</summary>
        [DisplayName("报警源")]
        [Description("报警源")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("WarnSrc", "报警源", "int")]
        public Int32 WarnSrc { get => _WarnSrc; set { if (OnPropertyChanging("WarnSrc", value)) { _WarnSrc = value; OnPropertyChanged("WarnSrc"); } } }

        private DateTime _WarnTime;
        /// <summary>报警时间</summary>
        [DisplayName("报警时间")]
        [Description("报警时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("WarnTime", "报警时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime WarnTime { get => _WarnTime; set { if (OnPropertyChanging("WarnTime", value)) { _WarnTime = value; OnPropertyChanged("WarnTime"); } } }

        private Int32 _WarnType;
        /// <summary>报警类型</summary>
        [DisplayName("报警类型")]
        [Description("报警类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("WarnType", "报警类型", "int")]
        public Int32 WarnType { get => _WarnType; set { if (OnPropertyChanging("WarnType", value)) { _WarnType = value; OnPropertyChanged("WarnType"); } } }

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

        private String _Owner;
        /// <summary>拥有者</summary>
        [DisplayName("拥有者")]
        [Description("拥有者")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Owner", "拥有者", "nvarchar(10)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Remark", "备注", "nvarchar(50)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(50)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private String _PlateColor;
        /// <summary>车牌颜色</summary>
        [DisplayName("车牌颜色")]
        [Description("车牌颜色")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("PlateColor", "车牌颜色", "nvarchar(50)")]
        public String PlateColor { get => _PlateColor; set { if (OnPropertyChanging("PlateColor", value)) { _PlateColor = value; OnPropertyChanged("PlateColor"); } } }
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
                    case "AckFlag": return _AckFlag;
                    case "AckTime": return _AckTime;
                    case "CreateDate": return _CreateDate;
                    case "Origin": return _Origin;
                    case "Result": return _Result;
                    case "SupervicsionId": return _SupervicsionId;
                    case "SupervisionEndTime": return _SupervisionEndTime;
                    case "SupervisionLevel": return _SupervisionLevel;
                    case "Supervisor": return _Supervisor;
                    case "SupervisorEmail": return _SupervisorEmail;
                    case "SupervisorTel": return _SupervisorTel;
                    case "VehicleId": return _VehicleId;
                    case "WarnSrc": return _WarnSrc;
                    case "WarnTime": return _WarnTime;
                    case "WarnType": return _WarnType;
                    case "Deleted": return _Deleted;
                    case "TenantId": return _TenantId;
                    case "Owner": return _Owner;
                    case "Remark": return _Remark;
                    case "PlateNo": return _PlateNo;
                    case "PlateColor": return _PlateColor;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = value.ToInt(); break;
                    case "AckFlag": _AckFlag = value.ToInt(); break;
                    case "AckTime": _AckTime = value.ToDateTime(); break;
                    case "CreateDate": _CreateDate = value.ToDateTime(); break;
                    case "Origin": _Origin = value.ToInt(); break;
                    case "Result": _Result = value.ToInt(); break;
                    case "SupervicsionId": _SupervicsionId = value.ToInt(); break;
                    case "SupervisionEndTime": _SupervisionEndTime = value.ToDateTime(); break;
                    case "SupervisionLevel": _SupervisionLevel = value.ToInt(); break;
                    case "Supervisor": _Supervisor = Convert.ToString(value); break;
                    case "SupervisorEmail": _SupervisorEmail = Convert.ToString(value); break;
                    case "SupervisorTel": _SupervisorTel = Convert.ToString(value); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "WarnSrc": _WarnSrc = value.ToInt(); break;
                    case "WarnTime": _WarnTime = value.ToDateTime(); break;
                    case "WarnType": _WarnType = value.ToInt(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "PlateColor": _PlateColor = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得报警信息响应字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>应答标识</summary>
            public static readonly Field AckFlag = FindByName("AckFlag");

            /// <summary>应答时间</summary>
            public static readonly Field AckTime = FindByName("AckTime");

            /// <summary>创建时间</summary>
            public static readonly Field CreateDate = FindByName("CreateDate");

            /// <summary>原始</summary>
            public static readonly Field Origin = FindByName("Origin");

            /// <summary>结果</summary>
            public static readonly Field Result = FindByName("Result");

            /// <summary>监督编码</summary>
            public static readonly Field SupervicsionId = FindByName("SupervicsionId");

            /// <summary>监督结束时间</summary>
            public static readonly Field SupervisionEndTime = FindByName("SupervisionEndTime");

            /// <summary>监督级别</summary>
            public static readonly Field SupervisionLevel = FindByName("SupervisionLevel");

            /// <summary>监督人</summary>
            public static readonly Field Supervisor = FindByName("Supervisor");

            /// <summary>监督邮件</summary>
            public static readonly Field SupervisorEmail = FindByName("SupervisorEmail");

            /// <summary>监督电话</summary>
            public static readonly Field SupervisorTel = FindByName("SupervisorTel");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>报警源</summary>
            public static readonly Field WarnSrc = FindByName("WarnSrc");

            /// <summary>报警时间</summary>
            public static readonly Field WarnTime = FindByName("WarnTime");

            /// <summary>报警类型</summary>
            public static readonly Field WarnType = FindByName("WarnType");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>车牌颜色</summary>
            public static readonly Field PlateColor = FindByName("PlateColor");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得报警信息响应字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String ID = "ID";

            /// <summary>应答标识</summary>
            public const String AckFlag = "AckFlag";

            /// <summary>应答时间</summary>
            public const String AckTime = "AckTime";

            /// <summary>创建时间</summary>
            public const String CreateDate = "CreateDate";

            /// <summary>原始</summary>
            public const String Origin = "Origin";

            /// <summary>结果</summary>
            public const String Result = "Result";

            /// <summary>监督编码</summary>
            public const String SupervicsionId = "SupervicsionId";

            /// <summary>监督结束时间</summary>
            public const String SupervisionEndTime = "SupervisionEndTime";

            /// <summary>监督级别</summary>
            public const String SupervisionLevel = "SupervisionLevel";

            /// <summary>监督人</summary>
            public const String Supervisor = "Supervisor";

            /// <summary>监督邮件</summary>
            public const String SupervisorEmail = "SupervisorEmail";

            /// <summary>监督电话</summary>
            public const String SupervisorTel = "SupervisorTel";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>报警源</summary>
            public const String WarnSrc = "WarnSrc";

            /// <summary>报警时间</summary>
            public const String WarnTime = "WarnTime";

            /// <summary>报警类型</summary>
            public const String WarnType = "WarnType";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>车牌颜色</summary>
            public const String PlateColor = "PlateColor";
        }
        #endregion
    }
}