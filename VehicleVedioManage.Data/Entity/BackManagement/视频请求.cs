using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.Data.Entity
{
    /// <summary>视频请求</summary>
    [Serializable]
    [DataObject]
    [Description("视频请求")]
    [BindIndex("PK_VideoRequest", true, "Id")]
    [BindTable("VideoRequest", Description = "视频请求", ConnName = "VehicleVedioManage", DbType = DatabaseType.SqlServer)]
    public partial class VideoRequest
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("Id", "", "int")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private String _SessionId;
        /// <summary>Session</summary>
        [DisplayName("Session")]
        [Description("Session")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("SessionId", "Session", "nvarchar(30)")]
        public String SessionId { get => _SessionId; set { if (OnPropertyChanging("SessionId", value)) { _SessionId = value; OnPropertyChanged("SessionId"); } } }

        private String _SimNo;
        /// <summary>Sim卡号</summary>
        [DisplayName("Sim卡号")]
        [Description("Sim卡号")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("SimNo", "Sim卡号", "nvarchar(30)")]
        public String SimNo { get => _SimNo; set { if (OnPropertyChanging("SimNo", value)) { _SimNo = value; OnPropertyChanged("SimNo"); } } }

        private String _PlateNo;
        /// <summary></summary>
        [DisplayName("PlateNo")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("PlateNo", "", "nvarchar(20)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private Int32 _Channel;
        /// <summary>通道</summary>
        [DisplayName("通道")]
        [Description("通道")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Channel", "通道", "int")]
        public Int32 Channel { get => _Channel; set { if (OnPropertyChanging("Channel", value)) { _Channel = value; OnPropertyChanged("Channel"); } } }

        private String _UserName;
        /// <summary></summary>
        [DisplayName("UserName")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("UserName", "", "nvarchar(20)")]
        public String UserName { get => _UserName; set { if (OnPropertyChanging("UserName", value)) { _UserName = value; OnPropertyChanged("UserName"); } } }

        private String _UserIp;
        /// <summary>用户IP</summary>
        [DisplayName("用户IP")]
        [Description("用户IP")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("UserIp", "用户IP", "nvarchar(20)")]
        public String UserIp { get => _UserIp; set { if (OnPropertyChanging("UserIp", value)) { _UserIp = value; OnPropertyChanged("UserIp"); } } }

        private Int16 _Status;
        /// <summary>状态,枚举值</summary>
        [DisplayName("状态")]
        [Description("状态,枚举值")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn("Status", "状态,枚举值", "smallint")]
        public Int16 Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private DateTime _StartTime;
        /// <summary>开始时间</summary>
        [DisplayName("开始时间")]
        [Description("开始时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("StartTime", "开始时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime StartTime { get => _StartTime; set { if (OnPropertyChanging("StartTime", value)) { _StartTime = value; OnPropertyChanged("StartTime"); } } }

        private String _CreateUser;
        /// <summary>创建者</summary>
        [DisplayName("创建者")]
        [Description("创建者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateUser", "创建者", "nvarchar(50)")]
        public String CreateUser { get => _CreateUser; set { if (OnPropertyChanging("CreateUser", value)) { _CreateUser = value; OnPropertyChanged("CreateUser"); } } }

        private Int32 _CreateUserID;
        /// <summary>创建人</summary>
        [DisplayName("创建人")]
        [Description("创建人")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("CreateUserID", "创建人", "int")]
        public Int32 CreateUserID { get => _CreateUserID; set { if (OnPropertyChanging("CreateUserID", value)) { _CreateUserID = value; OnPropertyChanged("CreateUserID"); } } }

        private String _CreateIP;
        /// <summary>创建地址</summary>
        [DisplayName("创建地址")]
        [Description("创建地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateIP", "创建地址", "nvarchar(50)")]
        public String CreateIP { get => _CreateIP; set { if (OnPropertyChanging("CreateIP", value)) { _CreateIP = value; OnPropertyChanged("CreateIP"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _UpdateUser;
        /// <summary>更新者</summary>
        [DisplayName("更新者")]
        [Description("更新者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateUser", "更新者", "nvarchar(50)")]
        public String UpdateUser { get => _UpdateUser; set { if (OnPropertyChanging("UpdateUser", value)) { _UpdateUser = value; OnPropertyChanged("UpdateUser"); } } }

        private Int32 _UpdateUserID;
        /// <summary>更新人</summary>
        [DisplayName("更新人")]
        [Description("更新人")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("UpdateUserID", "更新人", "int")]
        public Int32 UpdateUserID { get => _UpdateUserID; set { if (OnPropertyChanging("UpdateUserID", value)) { _UpdateUserID = value; OnPropertyChanged("UpdateUserID"); } } }

        private String _UpdateIP;
        /// <summary>更新地址</summary>
        [DisplayName("更新地址")]
        [Description("更新地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateIP", "更新地址", "nvarchar(50)")]
        public String UpdateIP { get => _UpdateIP; set { if (OnPropertyChanging("UpdateIP", value)) { _UpdateIP = value; OnPropertyChanged("UpdateIP"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateTime", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Remark", "备注", "nvarchar(500)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Boolean _Enable;
        /// <summary>启用</summary>
        [DisplayName("启用")]
        [Description("启用")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Enable", "启用", "bit")]
        public Boolean Enable { get => _Enable; set { if (OnPropertyChanging("Enable", value)) { _Enable = value; OnPropertyChanged("Enable"); } } }
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
                    case "SessionId": return _SessionId;
                    case "SimNo": return _SimNo;
                    case "PlateNo": return _PlateNo;
                    case "Channel": return _Channel;
                    case "UserName": return _UserName;
                    case "UserIp": return _UserIp;
                    case "Status": return _Status;
                    case "StartTime": return _StartTime;
                    case "CreateUser": return _CreateUser;
                    case "CreateUserID": return _CreateUserID;
                    case "CreateIP": return _CreateIP;
                    case "CreateTime": return _CreateTime;
                    case "UpdateUser": return _UpdateUser;
                    case "UpdateUserID": return _UpdateUserID;
                    case "UpdateIP": return _UpdateIP;
                    case "UpdateTime": return _UpdateTime;
                    case "Remark": return _Remark;
                    case "Enable": return _Enable;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "SessionId": _SessionId = Convert.ToString(value); break;
                    case "SimNo": _SimNo = Convert.ToString(value); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "Channel": _Channel = value.ToInt(); break;
                    case "UserName": _UserName = Convert.ToString(value); break;
                    case "UserIp": _UserIp = Convert.ToString(value); break;
                    case "Status": _Status = Convert.ToInt16(value); break;
                    case "StartTime": _StartTime = value.ToDateTime(); break;
                    case "CreateUser": _CreateUser = Convert.ToString(value); break;
                    case "CreateUserID": _CreateUserID = value.ToInt(); break;
                    case "CreateIP": _CreateIP = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "UpdateUser": _UpdateUser = Convert.ToString(value); break;
                    case "UpdateUserID": _UpdateUserID = value.ToInt(); break;
                    case "UpdateIP": _UpdateIP = Convert.ToString(value); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Enable": _Enable = value.ToBoolean(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得视频请求字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary>Session</summary>
            public static readonly Field SessionId = FindByName("SessionId");

            /// <summary>Sim卡号</summary>
            public static readonly Field SimNo = FindByName("SimNo");

            /// <summary></summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>通道</summary>
            public static readonly Field Channel = FindByName("Channel");

            /// <summary></summary>
            public static readonly Field UserName = FindByName("UserName");

            /// <summary>用户IP</summary>
            public static readonly Field UserIp = FindByName("UserIp");

            /// <summary>状态,枚举值</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>开始时间</summary>
            public static readonly Field StartTime = FindByName("StartTime");

            /// <summary>创建者</summary>
            public static readonly Field CreateUser = FindByName("CreateUser");

            /// <summary>创建人</summary>
            public static readonly Field CreateUserID = FindByName("CreateUserID");

            /// <summary>创建地址</summary>
            public static readonly Field CreateIP = FindByName("CreateIP");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>更新者</summary>
            public static readonly Field UpdateUser = FindByName("UpdateUser");

            /// <summary>更新人</summary>
            public static readonly Field UpdateUserID = FindByName("UpdateUserID");

            /// <summary>更新地址</summary>
            public static readonly Field UpdateIP = FindByName("UpdateIP");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>启用</summary>
            public static readonly Field Enable = FindByName("Enable");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得视频请求字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary>Session</summary>
            public const String SessionId = "SessionId";

            /// <summary>Sim卡号</summary>
            public const String SimNo = "SimNo";

            /// <summary></summary>
            public const String PlateNo = "PlateNo";

            /// <summary>通道</summary>
            public const String Channel = "Channel";

            /// <summary></summary>
            public const String UserName = "UserName";

            /// <summary>用户IP</summary>
            public const String UserIp = "UserIp";

            /// <summary>状态,枚举值</summary>
            public const String Status = "Status";

            /// <summary>开始时间</summary>
            public const String StartTime = "StartTime";

            /// <summary>创建者</summary>
            public const String CreateUser = "CreateUser";

            /// <summary>创建人</summary>
            public const String CreateUserID = "CreateUserID";

            /// <summary>创建地址</summary>
            public const String CreateIP = "CreateIP";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>更新者</summary>
            public const String UpdateUser = "UpdateUser";

            /// <summary>更新人</summary>
            public const String UpdateUserID = "UpdateUserID";

            /// <summary>更新地址</summary>
            public const String UpdateIP = "UpdateIP";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>启用</summary>
            public const String Enable = "Enable";
        }
        #endregion
    }
}