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
    /// <summary>视频服务配置</summary>
    [Serializable]
    [DataObject]
    [Description("视频服务配置")]
    [BindIndex("PK_VideoServerConfig", true, "ID")]
    [BindTable("VideoServerConfig", Description = "视频服务配置", ConnName = "VehicleVedioManage", DbType = DatabaseType.SqlServer)]
    public partial class VideoServerConfig
    {
        #region 属性
        private Int32 _ID;
        /// <summary></summary>
        [DisplayName("ID")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("ID", "", "int")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private String _VideoServerIp;
        /// <summary>视频服务IP</summary>
        [DisplayName("视频服务IP")]
        [Description("视频服务IP")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("VideoServerIp", "视频服务IP", "nvarchar(30)")]
        public String VideoServerIp { get => _VideoServerIp; set { if (OnPropertyChanging("VideoServerIp", value)) { _VideoServerIp = value; OnPropertyChanged("VideoServerIp"); } } }

        private Int32 _VideoServerTcpPort;
        /// <summary>视频服务TCP端口</summary>
        [DisplayName("视频服务TCP端口")]
        [Description("视频服务TCP端口")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VideoServerTcpPort", "视频服务TCP端口", "int")]
        public Int32 VideoServerTcpPort { get => _VideoServerTcpPort; set { if (OnPropertyChanging("VideoServerTcpPort", value)) { _VideoServerTcpPort = value; OnPropertyChanged("VideoServerTcpPort"); } } }

        private Int32 _VideoServerPlaybackTcpPort;
        /// <summary>回放TCP端口</summary>
        [DisplayName("回放TCP端口")]
        [Description("回放TCP端口")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VideoServerPlaybackTcpPort", "回放TCP端口", "int")]
        public Int32 VideoServerPlaybackTcpPort { get => _VideoServerPlaybackTcpPort; set { if (OnPropertyChanging("VideoServerPlaybackTcpPort", value)) { _VideoServerPlaybackTcpPort = value; OnPropertyChanged("VideoServerPlaybackTcpPort"); } } }

        private Int32 _BroadcastTcpPort;
        /// <summary>广播TCP端口</summary>
        [DisplayName("广播TCP端口")]
        [Description("广播TCP端口")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("BroadcastTcpPort", "广播TCP端口", "int")]
        public Int32 BroadcastTcpPort { get => _BroadcastTcpPort; set { if (OnPropertyChanging("BroadcastTcpPort", value)) { _BroadcastTcpPort = value; OnPropertyChanged("BroadcastTcpPort"); } } }

        private Int32 _VideoServerUdpPort;
        /// <summary>UDP端口</summary>
        [DisplayName("UDP端口")]
        [Description("UDP端口")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VideoServerUdpPort", "UDP端口", "int")]
        public Int32 VideoServerUdpPort { get => _VideoServerUdpPort; set { if (OnPropertyChanging("VideoServerUdpPort", value)) { _VideoServerUdpPort = value; OnPropertyChanged("VideoServerUdpPort"); } } }

        private Int32 _RtmpPort;
        /// <summary>RTMP端口</summary>
        [DisplayName("RTMP端口")]
        [Description("RTMP端口")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("RtmpPort", "RTMP端口", "int")]
        public Int32 RtmpPort { get => _RtmpPort; set { if (OnPropertyChanging("RtmpPort", value)) { _RtmpPort = value; OnPropertyChanged("RtmpPort"); } } }

        private String _FtpServerIp;
        /// <summary>FTP服务器IP</summary>
        [DisplayName("FTP服务器IP")]
        [Description("FTP服务器IP")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("FtpServerIp", "FTP服务器IP", "nvarchar(30)")]
        public String FtpServerIp { get => _FtpServerIp; set { if (OnPropertyChanging("FtpServerIp", value)) { _FtpServerIp = value; OnPropertyChanged("FtpServerIp"); } } }

        private Int32 _FtpPort;
        /// <summary>FTP端口</summary>
        [DisplayName("FTP端口")]
        [Description("FTP端口")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("FtpPort", "FTP端口", "int")]
        public Int32 FtpPort { get => _FtpPort; set { if (OnPropertyChanging("FtpPort", value)) { _FtpPort = value; OnPropertyChanged("FtpPort"); } } }

        private String _FtpUserName;
        /// <summary>FTP用户名</summary>
        [DisplayName("FTP用户名")]
        [Description("FTP用户名")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("FtpUserName", "FTP用户名", "nvarchar(20)")]
        public String FtpUserName { get => _FtpUserName; set { if (OnPropertyChanging("FtpUserName", value)) { _FtpUserName = value; OnPropertyChanged("FtpUserName"); } } }

        private String _FtpPassword;
        /// <summary>FTP密码</summary>
        [DisplayName("FTP密码")]
        [Description("FTP密码")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("FtpPassword", "FTP密码", "nvarchar(20)")]
        public String FtpPassword { get => _FtpPassword; set { if (OnPropertyChanging("FtpPassword", value)) { _FtpPassword = value; OnPropertyChanged("FtpPassword"); } } }

        private String _FtpPath;
        /// <summary>FTP路径</summary>
        [DisplayName("FTP路径")]
        [Description("FTP路径")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn("FtpPath", "FTP路径", "nvarchar(200)")]
        public String FtpPath { get => _FtpPath; set { if (OnPropertyChanging("FtpPath", value)) { _FtpPath = value; OnPropertyChanged("FtpPath"); } } }

        private Int32 _DiskCapacity;
        /// <summary>磁盘容量</summary>
        [DisplayName("磁盘容量")]
        [Description("磁盘容量")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("DiskCapacity", "磁盘容量", "int")]
        public Int32 DiskCapacity { get => _DiskCapacity; set { if (OnPropertyChanging("DiskCapacity", value)) { _DiskCapacity = value; OnPropertyChanged("DiskCapacity"); } } }

        private String _ActionOnDiskFull;
        /// <summary>磁盘满后动作</summary>
        [DisplayName("磁盘满后动作")]
        [Description("磁盘满后动作")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("ActionOnDiskFull", "磁盘满后动作", "nvarchar(30)")]
        public String ActionOnDiskFull { get => _ActionOnDiskFull; set { if (OnPropertyChanging("ActionOnDiskFull", value)) { _ActionOnDiskFull = value; OnPropertyChanged("ActionOnDiskFull"); } } }

        private Int32 _MinAvailableCapacity;
        /// <summary>最小可用容量</summary>
        [DisplayName("最小可用容量")]
        [Description("最小可用容量")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("MinAvailableCapacity", "最小可用容量", "int")]
        public Int32 MinAvailableCapacity { get => _MinAvailableCapacity; set { if (OnPropertyChanging("MinAvailableCapacity", value)) { _MinAvailableCapacity = value; OnPropertyChanged("MinAvailableCapacity"); } } }

        private Int32 _WebIdleTime;
        /// <summary>空闲时间</summary>
        [DisplayName("空闲时间")]
        [Description("空闲时间")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("WebIdleTime", "空闲时间", "int")]
        public Int32 WebIdleTime { get => _WebIdleTime; set { if (OnPropertyChanging("WebIdleTime", value)) { _WebIdleTime = value; OnPropertyChanged("WebIdleTime"); } } }

        private Int32 _VideoConnectionIdleTime;
        /// <summary>连接空闲时间</summary>
        [DisplayName("连接空闲时间")]
        [Description("连接空闲时间")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VideoConnectionIdleTime", "连接空闲时间", "int")]
        public Int32 VideoConnectionIdleTime { get => _VideoConnectionIdleTime; set { if (OnPropertyChanging("VideoConnectionIdleTime", value)) { _VideoConnectionIdleTime = value; OnPropertyChanged("VideoConnectionIdleTime"); } } }

        private String _FFMpegPath;
        /// <summary>FFMpeg路径</summary>
        [DisplayName("FFMpeg路径")]
        [Description("FFMpeg路径")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn("FFMpegPath", "FFMpeg路径", "nvarchar(200)")]
        public String FFMpegPath { get => _FFMpegPath; set { if (OnPropertyChanging("FFMpegPath", value)) { _FFMpegPath = value; OnPropertyChanged("FFMpegPath"); } } }

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
                    case "VideoServerIp": return _VideoServerIp;
                    case "VideoServerTcpPort": return _VideoServerTcpPort;
                    case "VideoServerPlaybackTcpPort": return _VideoServerPlaybackTcpPort;
                    case "BroadcastTcpPort": return _BroadcastTcpPort;
                    case "VideoServerUdpPort": return _VideoServerUdpPort;
                    case "RtmpPort": return _RtmpPort;
                    case "FtpServerIp": return _FtpServerIp;
                    case "FtpPort": return _FtpPort;
                    case "FtpUserName": return _FtpUserName;
                    case "FtpPassword": return _FtpPassword;
                    case "FtpPath": return _FtpPath;
                    case "DiskCapacity": return _DiskCapacity;
                    case "ActionOnDiskFull": return _ActionOnDiskFull;
                    case "MinAvailableCapacity": return _MinAvailableCapacity;
                    case "WebIdleTime": return _WebIdleTime;
                    case "VideoConnectionIdleTime": return _VideoConnectionIdleTime;
                    case "FFMpegPath": return _FFMpegPath;
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
                    case "VideoServerIp": _VideoServerIp = Convert.ToString(value); break;
                    case "VideoServerTcpPort": _VideoServerTcpPort = value.ToInt(); break;
                    case "VideoServerPlaybackTcpPort": _VideoServerPlaybackTcpPort = value.ToInt(); break;
                    case "BroadcastTcpPort": _BroadcastTcpPort = value.ToInt(); break;
                    case "VideoServerUdpPort": _VideoServerUdpPort = value.ToInt(); break;
                    case "RtmpPort": _RtmpPort = value.ToInt(); break;
                    case "FtpServerIp": _FtpServerIp = Convert.ToString(value); break;
                    case "FtpPort": _FtpPort = value.ToInt(); break;
                    case "FtpUserName": _FtpUserName = Convert.ToString(value); break;
                    case "FtpPassword": _FtpPassword = Convert.ToString(value); break;
                    case "FtpPath": _FtpPath = Convert.ToString(value); break;
                    case "DiskCapacity": _DiskCapacity = value.ToInt(); break;
                    case "ActionOnDiskFull": _ActionOnDiskFull = Convert.ToString(value); break;
                    case "MinAvailableCapacity": _MinAvailableCapacity = value.ToInt(); break;
                    case "WebIdleTime": _WebIdleTime = value.ToInt(); break;
                    case "VideoConnectionIdleTime": _VideoConnectionIdleTime = value.ToInt(); break;
                    case "FFMpegPath": _FFMpegPath = Convert.ToString(value); break;
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
        /// <summary>取得视频服务配置字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>视频服务IP</summary>
            public static readonly Field VideoServerIp = FindByName("VideoServerIp");

            /// <summary>视频服务TCP端口</summary>
            public static readonly Field VideoServerTcpPort = FindByName("VideoServerTcpPort");

            /// <summary>回放TCP端口</summary>
            public static readonly Field VideoServerPlaybackTcpPort = FindByName("VideoServerPlaybackTcpPort");

            /// <summary>广播TCP端口</summary>
            public static readonly Field BroadcastTcpPort = FindByName("BroadcastTcpPort");

            /// <summary>UDP端口</summary>
            public static readonly Field VideoServerUdpPort = FindByName("VideoServerUdpPort");

            /// <summary>RTMP端口</summary>
            public static readonly Field RtmpPort = FindByName("RtmpPort");

            /// <summary>FTP服务器IP</summary>
            public static readonly Field FtpServerIp = FindByName("FtpServerIp");

            /// <summary>FTP端口</summary>
            public static readonly Field FtpPort = FindByName("FtpPort");

            /// <summary>FTP用户名</summary>
            public static readonly Field FtpUserName = FindByName("FtpUserName");

            /// <summary>FTP密码</summary>
            public static readonly Field FtpPassword = FindByName("FtpPassword");

            /// <summary>FTP路径</summary>
            public static readonly Field FtpPath = FindByName("FtpPath");

            /// <summary>磁盘容量</summary>
            public static readonly Field DiskCapacity = FindByName("DiskCapacity");

            /// <summary>磁盘满后动作</summary>
            public static readonly Field ActionOnDiskFull = FindByName("ActionOnDiskFull");

            /// <summary>最小可用容量</summary>
            public static readonly Field MinAvailableCapacity = FindByName("MinAvailableCapacity");

            /// <summary>空闲时间</summary>
            public static readonly Field WebIdleTime = FindByName("WebIdleTime");

            /// <summary>连接空闲时间</summary>
            public static readonly Field VideoConnectionIdleTime = FindByName("VideoConnectionIdleTime");

            /// <summary>FFMpeg路径</summary>
            public static readonly Field FFMpegPath = FindByName("FFMpegPath");

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

        /// <summary>取得视频服务配置字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String ID = "ID";

            /// <summary>视频服务IP</summary>
            public const String VideoServerIp = "VideoServerIp";

            /// <summary>视频服务TCP端口</summary>
            public const String VideoServerTcpPort = "VideoServerTcpPort";

            /// <summary>回放TCP端口</summary>
            public const String VideoServerPlaybackTcpPort = "VideoServerPlaybackTcpPort";

            /// <summary>广播TCP端口</summary>
            public const String BroadcastTcpPort = "BroadcastTcpPort";

            /// <summary>UDP端口</summary>
            public const String VideoServerUdpPort = "VideoServerUdpPort";

            /// <summary>RTMP端口</summary>
            public const String RtmpPort = "RtmpPort";

            /// <summary>FTP服务器IP</summary>
            public const String FtpServerIp = "FtpServerIp";

            /// <summary>FTP端口</summary>
            public const String FtpPort = "FtpPort";

            /// <summary>FTP用户名</summary>
            public const String FtpUserName = "FtpUserName";

            /// <summary>FTP密码</summary>
            public const String FtpPassword = "FtpPassword";

            /// <summary>FTP路径</summary>
            public const String FtpPath = "FtpPath";

            /// <summary>磁盘容量</summary>
            public const String DiskCapacity = "DiskCapacity";

            /// <summary>磁盘满后动作</summary>
            public const String ActionOnDiskFull = "ActionOnDiskFull";

            /// <summary>最小可用容量</summary>
            public const String MinAvailableCapacity = "MinAvailableCapacity";

            /// <summary>空闲时间</summary>
            public const String WebIdleTime = "WebIdleTime";

            /// <summary>连接空闲时间</summary>
            public const String VideoConnectionIdleTime = "VideoConnectionIdleTime";

            /// <summary>FFMpeg路径</summary>
            public const String FFMpegPath = "FFMpegPath";

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