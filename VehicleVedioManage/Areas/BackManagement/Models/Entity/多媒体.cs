using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.BackManagement.Entity
{
    /// <summary>多媒体</summary>
    [Serializable]
    [DataObject]
    [Description("多媒体")]
    [BindTable("MediaItem", Description = "多媒体", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class MediaItem
    {
        #region 属性
        private Int32 _MediaItemId;
        /// <summary>多媒体项编码</summary>
        [DisplayName("多媒体项编码")]
        [Description("多媒体项编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("MediaItemId", "多媒体项编码", "int")]
        public Int32 MediaItemId { get => _MediaItemId; set { if (OnPropertyChanging("MediaItemId", value)) { _MediaItemId = value; OnPropertyChanged("MediaItemId"); } } }

        private Int32 _CommandId;
        /// <summary>指令编码</summary>
        [DisplayName("指令编码")]
        [Description("指令编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("CommandId", "指令编码", "int")]
        public Int32 CommandId { get => _CommandId; set { if (OnPropertyChanging("CommandId", value)) { _CommandId = value; OnPropertyChanged("CommandId"); } } }

        private String _CommandType;
        /// <summary>指令类型</summary>
        [DisplayName("指令类型")]
        [Description("指令类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("CommandType", "指令类型", "nvarchar(255)")]
        public String CommandType { get => _CommandType; set { if (OnPropertyChanging("CommandType", value)) { _CommandType = value; OnPropertyChanged("CommandType"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(255)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private String _SimNo;
        /// <summary>Sim卡号</summary>
        [DisplayName("Sim卡号")]
        [Description("Sim卡号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("SimNo", "Sim卡号", "nvarchar(255)")]
        public String SimNo { get => _SimNo; set { if (OnPropertyChanging("SimNo", value)) { _SimNo = value; OnPropertyChanged("SimNo"); } } }

        private DateTime _SendTime;
        /// <summary>发送时间</summary>
        [DisplayName("发送时间")]
        [Description("发送时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("SendTime", "发送时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime SendTime { get => _SendTime; set { if (OnPropertyChanging("SendTime", value)) { _SendTime = value; OnPropertyChanged("SendTime"); } } }

        private Int32 _MediaDataId;
        /// <summary>多媒体数据编码</summary>
        [DisplayName("多媒体数据编码")]
        [Description("多媒体数据编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("MediaDataId", "多媒体数据编码", "int")]
        public Int32 MediaDataId { get => _MediaDataId; set { if (OnPropertyChanging("MediaDataId", value)) { _MediaDataId = value; OnPropertyChanged("MediaDataId"); } } }

        private Byte _MediaType;
        /// <summary>多媒体类型</summary>
        [DisplayName("多媒体类型")]
        [Description("多媒体类型")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("MediaType", "多媒体类型", "tinyint")]
        public Byte MediaType { get => _MediaType; set { if (OnPropertyChanging("MediaType", value)) { _MediaType = value; OnPropertyChanged("MediaType"); } } }

        private Byte _CodeFormat;
        /// <summary>编码格式</summary>
        [DisplayName("编码格式")]
        [Description("编码格式")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CodeFormat", "编码格式", "tinyint")]
        public Byte CodeFormat { get => _CodeFormat; set { if (OnPropertyChanging("CodeFormat", value)) { _CodeFormat = value; OnPropertyChanged("CodeFormat"); } } }

        private Byte _ChannelId;
        /// <summary>通道编码</summary>
        [DisplayName("通道编码")]
        [Description("通道编码")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("ChannelId", "通道编码", "tinyint")]
        public Byte ChannelId { get => _ChannelId; set { if (OnPropertyChanging("ChannelId", value)) { _ChannelId = value; OnPropertyChanged("ChannelId"); } } }

        private Byte _EventCode;
        /// <summary>事件代码</summary>
        [DisplayName("事件代码")]
        [Description("事件代码")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("EventCode", "事件代码", "tinyint")]
        public Byte EventCode { get => _EventCode; set { if (OnPropertyChanging("EventCode", value)) { _EventCode = value; OnPropertyChanged("EventCode"); } } }

        private String _FileName;
        /// <summary>文件名称</summary>
        [DisplayName("文件名称")]
        [Description("文件名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("FileName", "文件名称", "nvarchar(255)")]
        public String FileName { get => _FileName; set { if (OnPropertyChanging("FileName", value)) { _FileName = value; OnPropertyChanged("FileName"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

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
        [DataObjectField(false, false, true, 45)]
        [BindColumn("Owner", "物主", "nvarchar(45)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 55)]
        [BindColumn("Remark", "备注", "nvarchar(55)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private String _Location;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Location", "位置", "nvarchar(50)")]
        public String Location { get => _Location; set { if (OnPropertyChanging("Location", value)) { _Location = value; OnPropertyChanged("Location"); } } }

        private String _GPSId;
        /// <summary>GPS编码</summary>
        [DisplayName("GPS编码")]
        [Description("GPS编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("GPSId", "GPS编码", "nvarchar(255)")]
        public String GPSId { get => _GPSId; set { if (OnPropertyChanging("GPSId", value)) { _GPSId = value; OnPropertyChanged("GPSId"); } } }

        private Int32 _MultimediaDataId;
        /// <summary>多媒体数据编码</summary>
        [DisplayName("多媒体数据编码")]
        [Description("多媒体数据编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("MultimediaDataId", "多媒体数据编码", "int")]
        public Int32 MultimediaDataId { get => _MultimediaDataId; set { if (OnPropertyChanging("MultimediaDataId", value)) { _MultimediaDataId = value; OnPropertyChanged("MultimediaDataId"); } } }

        private Byte _MultimediaType;
        /// <summary>多媒体类型</summary>
        [DisplayName("多媒体类型")]
        [Description("多媒体类型")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("MultimediaType", "多媒体类型", "tinyint")]
        public Byte MultimediaType { get => _MultimediaType; set { if (OnPropertyChanging("MultimediaType", value)) { _MultimediaType = value; OnPropertyChanged("MultimediaType"); } } }

        private Byte _MultidediaCodeFormat;
        /// <summary>多媒体编码格式</summary>
        [DisplayName("多媒体编码格式")]
        [Description("多媒体编码格式")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("MultidediaCodeFormat", "多媒体编码格式", "tinyint")]
        public Byte MultidediaCodeFormat { get => _MultidediaCodeFormat; set { if (OnPropertyChanging("MultidediaCodeFormat", value)) { _MultidediaCodeFormat = value; OnPropertyChanged("MultidediaCodeFormat"); } } }
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
                    case "MediaItemId": return _MediaItemId;
                    case "CommandId": return _CommandId;
                    case "CommandType": return _CommandType;
                    case "PlateNo": return _PlateNo;
                    case "SimNo": return _SimNo;
                    case "SendTime": return _SendTime;
                    case "MediaDataId": return _MediaDataId;
                    case "MediaType": return _MediaType;
                    case "CodeFormat": return _CodeFormat;
                    case "ChannelId": return _ChannelId;
                    case "EventCode": return _EventCode;
                    case "FileName": return _FileName;
                    case "CreateTime": return _CreateTime;
                    case "TenantId": return _TenantId;
                    case "Latitude": return _Latitude;
                    case "Longitude": return _Longitude;
                    case "Speed": return _Speed;
                    case "Deleted": return _Deleted;
                    case "Owner": return _Owner;
                    case "Remark": return _Remark;
                    case "Location": return _Location;
                    case "GPSId": return _GPSId;
                    case "MultimediaDataId": return _MultimediaDataId;
                    case "MultimediaType": return _MultimediaType;
                    case "MultidediaCodeFormat": return _MultidediaCodeFormat;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "MediaItemId": _MediaItemId = value.ToInt(); break;
                    case "CommandId": _CommandId = value.ToInt(); break;
                    case "CommandType": _CommandType = Convert.ToString(value); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "SimNo": _SimNo = Convert.ToString(value); break;
                    case "SendTime": _SendTime = value.ToDateTime(); break;
                    case "MediaDataId": _MediaDataId = value.ToInt(); break;
                    case "MediaType": _MediaType = Convert.ToByte(value); break;
                    case "CodeFormat": _CodeFormat = Convert.ToByte(value); break;
                    case "ChannelId": _ChannelId = Convert.ToByte(value); break;
                    case "EventCode": _EventCode = Convert.ToByte(value); break;
                    case "FileName": _FileName = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Latitude": _Latitude = value.ToDouble(); break;
                    case "Longitude": _Longitude = value.ToDouble(); break;
                    case "Speed": _Speed = value.ToDouble(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Location": _Location = Convert.ToString(value); break;
                    case "GPSId": _GPSId = Convert.ToString(value); break;
                    case "MultimediaDataId": _MultimediaDataId = value.ToInt(); break;
                    case "MultimediaType": _MultimediaType = Convert.ToByte(value); break;
                    case "MultidediaCodeFormat": _MultidediaCodeFormat = Convert.ToByte(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得多媒体字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>多媒体项编码</summary>
            public static readonly Field MediaItemId = FindByName("MediaItemId");

            /// <summary>指令编码</summary>
            public static readonly Field CommandId = FindByName("CommandId");

            /// <summary>指令类型</summary>
            public static readonly Field CommandType = FindByName("CommandType");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>Sim卡号</summary>
            public static readonly Field SimNo = FindByName("SimNo");

            /// <summary>发送时间</summary>
            public static readonly Field SendTime = FindByName("SendTime");

            /// <summary>多媒体数据编码</summary>
            public static readonly Field MediaDataId = FindByName("MediaDataId");

            /// <summary>多媒体类型</summary>
            public static readonly Field MediaType = FindByName("MediaType");

            /// <summary>编码格式</summary>
            public static readonly Field CodeFormat = FindByName("CodeFormat");

            /// <summary>通道编码</summary>
            public static readonly Field ChannelId = FindByName("ChannelId");

            /// <summary>事件代码</summary>
            public static readonly Field EventCode = FindByName("EventCode");

            /// <summary>文件名称</summary>
            public static readonly Field FileName = FindByName("FileName");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>纬度</summary>
            public static readonly Field Latitude = FindByName("Latitude");

            /// <summary>经度</summary>
            public static readonly Field Longitude = FindByName("Longitude");

            /// <summary>速度</summary>
            public static readonly Field Speed = FindByName("Speed");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>位置</summary>
            public static readonly Field Location = FindByName("Location");

            /// <summary>GPS编码</summary>
            public static readonly Field GPSId = FindByName("GPSId");

            /// <summary>多媒体数据编码</summary>
            public static readonly Field MultimediaDataId = FindByName("MultimediaDataId");

            /// <summary>多媒体类型</summary>
            public static readonly Field MultimediaType = FindByName("MultimediaType");

            /// <summary>多媒体编码格式</summary>
            public static readonly Field MultidediaCodeFormat = FindByName("MultidediaCodeFormat");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得多媒体字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>多媒体项编码</summary>
            public const String MediaItemId = "MediaItemId";

            /// <summary>指令编码</summary>
            public const String CommandId = "CommandId";

            /// <summary>指令类型</summary>
            public const String CommandType = "CommandType";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>Sim卡号</summary>
            public const String SimNo = "SimNo";

            /// <summary>发送时间</summary>
            public const String SendTime = "SendTime";

            /// <summary>多媒体数据编码</summary>
            public const String MediaDataId = "MediaDataId";

            /// <summary>多媒体类型</summary>
            public const String MediaType = "MediaType";

            /// <summary>编码格式</summary>
            public const String CodeFormat = "CodeFormat";

            /// <summary>通道编码</summary>
            public const String ChannelId = "ChannelId";

            /// <summary>事件代码</summary>
            public const String EventCode = "EventCode";

            /// <summary>文件名称</summary>
            public const String FileName = "FileName";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>纬度</summary>
            public const String Latitude = "Latitude";

            /// <summary>经度</summary>
            public const String Longitude = "Longitude";

            /// <summary>速度</summary>
            public const String Speed = "Speed";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>位置</summary>
            public const String Location = "Location";

            /// <summary>GPS编码</summary>
            public const String GPSId = "GPSId";

            /// <summary>多媒体数据编码</summary>
            public const String MultimediaDataId = "MultimediaDataId";

            /// <summary>多媒体类型</summary>
            public const String MultimediaType = "MultimediaType";

            /// <summary>多媒体编码格式</summary>
            public const String MultidediaCodeFormat = "MultidediaCodeFormat";
        }
        #endregion
    }
}