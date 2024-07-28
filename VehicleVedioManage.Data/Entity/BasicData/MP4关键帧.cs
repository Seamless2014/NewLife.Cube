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
    /// <summary>MP4关键帧</summary>
    [Serializable]
    [DataObject]
    [Description("MP4关键帧")]
    [BindIndex("PK_VideoMp4KeyFrame", true, "ID")]
    [BindTable("VideoMp4KeyFrame", Description = "MP4关键帧", ConnName = "VehicleVedioManage", DbType = DatabaseType.SqlServer)]
    public partial class VideoMp4KeyFrame
    {
        #region 属性
        private Int32 _ID;
        /// <summary></summary>
        [DisplayName("ID")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("ID", "", "int")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private String _Mp4FilePath;
        /// <summary>MP4文件路径</summary>
        [DisplayName("MP4文件路径")]
        [Description("MP4文件路径")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn("Mp4FilePath", "MP4文件路径", "nvarchar(200)")]
        public String Mp4FilePath { get => _Mp4FilePath; set { if (OnPropertyChanging("Mp4FilePath", value)) { _Mp4FilePath = value; OnPropertyChanged("Mp4FilePath"); } } }

        private Int16 _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn("Status", "状态", "smallint")]
        public Int16 Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private String _KeyFrames;
        /// <summary>关键帧</summary>
        [DisplayName("关键帧")]
        [Description("关键帧")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("KeyFrames", "关键帧", "nvarchar(50)")]
        public String KeyFrames { get => _KeyFrames; set { if (OnPropertyChanging("KeyFrames", value)) { _KeyFrames = value; OnPropertyChanged("KeyFrames"); } } }

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
                    case "ID": return _ID;
                    case "Mp4FilePath": return _Mp4FilePath;
                    case "Status": return _Status;
                    case "KeyFrames": return _KeyFrames;
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
                    case "ID": _ID = value.ToInt(); break;
                    case "Mp4FilePath": _Mp4FilePath = Convert.ToString(value); break;
                    case "Status": _Status = Convert.ToInt16(value); break;
                    case "KeyFrames": _KeyFrames = Convert.ToString(value); break;
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
        /// <summary>取得MP4关键帧字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>MP4文件路径</summary>
            public static readonly Field Mp4FilePath = FindByName("Mp4FilePath");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>关键帧</summary>
            public static readonly Field KeyFrames = FindByName("KeyFrames");

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

        /// <summary>取得MP4关键帧字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String ID = "ID";

            /// <summary>MP4文件路径</summary>
            public const String Mp4FilePath = "Mp4FilePath";

            /// <summary>状态</summary>
            public const String Status = "Status";

            /// <summary>关键帧</summary>
            public const String KeyFrames = "KeyFrames";

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