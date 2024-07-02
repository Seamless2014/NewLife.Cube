using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.Data.Entity
{
    /// <summary>视频文件项</summary>
    [Serializable]
    [DataObject]
    [Description("视频文件项")]
    [BindIndex("PK_VideoFileItem", true, "ID")]
    [BindTable("VideoFileItem", Description = "视频文件项", ConnName = "VehicleVedioManage", DbType = DatabaseType.SqlServer)]
    public partial class VideoFileItem
    {
        #region 属性
        private Int32 _ID;
        /// <summary></summary>
        [DisplayName("ID")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("ID", "", "int")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private Int32 _CommandId;
        /// <summary>命令ID</summary>
        [DisplayName("命令ID")]
        [Description("命令ID")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("CommandId", "命令ID", "int")]
        public Int32 CommandId { get => _CommandId; set { if (OnPropertyChanging("CommandId", value)) { _CommandId = value; OnPropertyChanged("CommandId"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆ID</summary>
        [DisplayName("车辆ID")]
        [Description("车辆ID")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VehicleId", "车辆ID", "int")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(20)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private String _SimNo;
        /// <summary>Sim卡号</summary>
        [DisplayName("Sim卡号")]
        [Description("Sim卡号")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("SimNo", "Sim卡号", "nvarchar(30)")]
        public String SimNo { get => _SimNo; set { if (OnPropertyChanging("SimNo", value)) { _SimNo = value; OnPropertyChanged("SimNo"); } } }

        private Int16 _ChannelId;
        /// <summary>通道号</summary>
        [DisplayName("通道号")]
        [Description("通道号")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn("ChannelId", "通道号", "smallint")]
        public Int16 ChannelId { get => _ChannelId; set { if (OnPropertyChanging("ChannelId", value)) { _ChannelId = value; OnPropertyChanged("ChannelId"); } } }

        private DateTime _StartDate;
        /// <summary>起始时间</summary>
        [DisplayName("起始时间")]
        [Description("起始时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("StartDate", "起始时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime StartDate { get => _StartDate; set { if (OnPropertyChanging("StartDate", value)) { _StartDate = value; OnPropertyChanged("StartDate"); } } }

        private DateTime _EndDate;
        /// <summary>结束时间</summary>
        [DisplayName("结束时间")]
        [Description("结束时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("EndDate", "结束时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime EndDate { get => _EndDate; set { if (OnPropertyChanging("EndDate", value)) { _EndDate = value; OnPropertyChanged("EndDate"); } } }

        private Double _Longitude2;
        /// <summary>经度2</summary>
        [DisplayName("经度2")]
        [Description("经度2")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Longitude2", "经度2", "float")]
        public Double Longitude2 { get => _Longitude2; set { if (OnPropertyChanging("Longitude2", value)) { _Longitude2 = value; OnPropertyChanged("Longitude2"); } } }

        private Double _Latitude2;
        /// <summary>纬度2</summary>
        [DisplayName("纬度2")]
        [Description("纬度2")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Latitude2", "纬度2", "float")]
        public Double Latitude2 { get => _Latitude2; set { if (OnPropertyChanging("Latitude2", value)) { _Latitude2 = value; OnPropertyChanged("Latitude2"); } } }

        private Double _Longitude1;
        /// <summary>经度1</summary>
        [DisplayName("经度1")]
        [Description("经度1")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Longitude1", "经度1", "float")]
        public Double Longitude1 { get => _Longitude1; set { if (OnPropertyChanging("Longitude1", value)) { _Longitude1 = value; OnPropertyChanged("Longitude1"); } } }

        private Double _Latitude1;
        /// <summary>纬度1</summary>
        [DisplayName("纬度1")]
        [Description("纬度1")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Latitude1", "纬度1", "float")]
        public Double Latitude1 { get => _Latitude1; set { if (OnPropertyChanging("Latitude1", value)) { _Latitude1 = value; OnPropertyChanged("Latitude1"); } } }

        private DateTime _UploadDate;
        /// <summary>上传时间</summary>
        [DisplayName("上传时间")]
        [Description("上传时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UploadDate", "上传时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UploadDate { get => _UploadDate; set { if (OnPropertyChanging("UploadDate", value)) { _UploadDate = value; OnPropertyChanged("UploadDate"); } } }

        private Double _AlarmStatus;
        /// <summary>报警状态</summary>
        [DisplayName("报警状态")]
        [Description("报警状态")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("AlarmStatus", "报警状态", "float")]
        public Double AlarmStatus { get => _AlarmStatus; set { if (OnPropertyChanging("AlarmStatus", value)) { _AlarmStatus = value; OnPropertyChanged("AlarmStatus"); } } }

        private Int32 _Status;
        /// <summary>状态，枚举值</summary>
        [DisplayName("状态")]
        [Description("状态，枚举值")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Status", "状态，枚举值", "int")]
        public Int32 Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private String _FileSource;
        /// <summary>文件源</summary>
        [DisplayName("文件源")]
        [Description("文件源")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("FileSource", "文件源", "nvarchar(20)")]
        public String FileSource { get => _FileSource; set { if (OnPropertyChanging("FileSource", value)) { _FileSource = value; OnPropertyChanged("FileSource"); } } }

        private String _FilePath;
        /// <summary>文件路径</summary>
        [DisplayName("文件路径")]
        [Description("文件路径")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn("FilePath", "文件路径", "nvarchar(200)")]
        public String FilePath { get => _FilePath; set { if (OnPropertyChanging("FilePath", value)) { _FilePath = value; OnPropertyChanged("FilePath"); } } }

        private Int16 _DataType;
        /// <summary>类型,枚举值</summary>
        [DisplayName("类型")]
        [Description("类型,枚举值")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn("DataType", "类型,枚举值", "smallint")]
        public Int16 DataType { get => _DataType; set { if (OnPropertyChanging("DataType", value)) { _DataType = value; OnPropertyChanged("DataType"); } } }

        private Int16 _StreamType;
        /// <summary>流类型</summary>
        [DisplayName("流类型")]
        [Description("流类型")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn("StreamType", "流类型", "smallint")]
        public Int16 StreamType { get => _StreamType; set { if (OnPropertyChanging("StreamType", value)) { _StreamType = value; OnPropertyChanged("StreamType"); } } }

        private Int16 _StoreType;
        /// <summary>存储类型</summary>
        [DisplayName("存储类型")]
        [Description("存储类型")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn("StoreType", "存储类型", "smallint")]
        public Int16 StoreType { get => _StoreType; set { if (OnPropertyChanging("StoreType", value)) { _StoreType = value; OnPropertyChanged("StoreType"); } } }

        private Int32 _FileLength;
        /// <summary>文件长度</summary>
        [DisplayName("文件长度")]
        [Description("文件长度")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("FileLength", "文件长度", "int")]
        public Int32 FileLength { get => _FileLength; set { if (OnPropertyChanging("FileLength", value)) { _FileLength = value; OnPropertyChanged("FileLength"); } } }

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
                    case "CommandId": return _CommandId;
                    case "VehicleId": return _VehicleId;
                    case "PlateNo": return _PlateNo;
                    case "SimNo": return _SimNo;
                    case "ChannelId": return _ChannelId;
                    case "StartDate": return _StartDate;
                    case "EndDate": return _EndDate;
                    case "Longitude2": return _Longitude2;
                    case "Latitude2": return _Latitude2;
                    case "Longitude1": return _Longitude1;
                    case "Latitude1": return _Latitude1;
                    case "UploadDate": return _UploadDate;
                    case "AlarmStatus": return _AlarmStatus;
                    case "Status": return _Status;
                    case "FileSource": return _FileSource;
                    case "FilePath": return _FilePath;
                    case "DataType": return _DataType;
                    case "StreamType": return _StreamType;
                    case "StoreType": return _StoreType;
                    case "FileLength": return _FileLength;
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
                    case "CommandId": _CommandId = value.ToInt(); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "SimNo": _SimNo = Convert.ToString(value); break;
                    case "ChannelId": _ChannelId = Convert.ToInt16(value); break;
                    case "StartDate": _StartDate = value.ToDateTime(); break;
                    case "EndDate": _EndDate = value.ToDateTime(); break;
                    case "Longitude2": _Longitude2 = value.ToDouble(); break;
                    case "Latitude2": _Latitude2 = value.ToDouble(); break;
                    case "Longitude1": _Longitude1 = value.ToDouble(); break;
                    case "Latitude1": _Latitude1 = value.ToDouble(); break;
                    case "UploadDate": _UploadDate = value.ToDateTime(); break;
                    case "AlarmStatus": _AlarmStatus = value.ToDouble(); break;
                    case "Status": _Status = value.ToInt(); break;
                    case "FileSource": _FileSource = Convert.ToString(value); break;
                    case "FilePath": _FilePath = Convert.ToString(value); break;
                    case "DataType": _DataType = Convert.ToInt16(value); break;
                    case "StreamType": _StreamType = Convert.ToInt16(value); break;
                    case "StoreType": _StoreType = Convert.ToInt16(value); break;
                    case "FileLength": _FileLength = value.ToInt(); break;
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
        /// <summary>取得视频文件项字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>命令ID</summary>
            public static readonly Field CommandId = FindByName("CommandId");

            /// <summary>车辆ID</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>Sim卡号</summary>
            public static readonly Field SimNo = FindByName("SimNo");

            /// <summary>通道号</summary>
            public static readonly Field ChannelId = FindByName("ChannelId");

            /// <summary>起始时间</summary>
            public static readonly Field StartDate = FindByName("StartDate");

            /// <summary>结束时间</summary>
            public static readonly Field EndDate = FindByName("EndDate");

            /// <summary>经度2</summary>
            public static readonly Field Longitude2 = FindByName("Longitude2");

            /// <summary>纬度2</summary>
            public static readonly Field Latitude2 = FindByName("Latitude2");

            /// <summary>经度1</summary>
            public static readonly Field Longitude1 = FindByName("Longitude1");

            /// <summary>纬度1</summary>
            public static readonly Field Latitude1 = FindByName("Latitude1");

            /// <summary>上传时间</summary>
            public static readonly Field UploadDate = FindByName("UploadDate");

            /// <summary>报警状态</summary>
            public static readonly Field AlarmStatus = FindByName("AlarmStatus");

            /// <summary>状态，枚举值</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>文件源</summary>
            public static readonly Field FileSource = FindByName("FileSource");

            /// <summary>文件路径</summary>
            public static readonly Field FilePath = FindByName("FilePath");

            /// <summary>类型,枚举值</summary>
            public static readonly Field DataType = FindByName("DataType");

            /// <summary>流类型</summary>
            public static readonly Field StreamType = FindByName("StreamType");

            /// <summary>存储类型</summary>
            public static readonly Field StoreType = FindByName("StoreType");

            /// <summary>文件长度</summary>
            public static readonly Field FileLength = FindByName("FileLength");

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

        /// <summary>取得视频文件项字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String ID = "ID";

            /// <summary>命令ID</summary>
            public const String CommandId = "CommandId";

            /// <summary>车辆ID</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>Sim卡号</summary>
            public const String SimNo = "SimNo";

            /// <summary>通道号</summary>
            public const String ChannelId = "ChannelId";

            /// <summary>起始时间</summary>
            public const String StartDate = "StartDate";

            /// <summary>结束时间</summary>
            public const String EndDate = "EndDate";

            /// <summary>经度2</summary>
            public const String Longitude2 = "Longitude2";

            /// <summary>纬度2</summary>
            public const String Latitude2 = "Latitude2";

            /// <summary>经度1</summary>
            public const String Longitude1 = "Longitude1";

            /// <summary>纬度1</summary>
            public const String Latitude1 = "Latitude1";

            /// <summary>上传时间</summary>
            public const String UploadDate = "UploadDate";

            /// <summary>报警状态</summary>
            public const String AlarmStatus = "AlarmStatus";

            /// <summary>状态，枚举值</summary>
            public const String Status = "Status";

            /// <summary>文件源</summary>
            public const String FileSource = "FileSource";

            /// <summary>文件路径</summary>
            public const String FilePath = "FilePath";

            /// <summary>类型,枚举值</summary>
            public const String DataType = "DataType";

            /// <summary>流类型</summary>
            public const String StreamType = "StreamType";

            /// <summary>存储类型</summary>
            public const String StoreType = "StoreType";

            /// <summary>文件长度</summary>
            public const String FileLength = "FileLength";

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