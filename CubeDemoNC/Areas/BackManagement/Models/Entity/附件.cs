using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace GPSPlatform.BackManagement.Entity
{
    /// <summary>附件</summary>
    [Serializable]
    [DataObject]
    [Description("附件")]
    [BindTable("FileData", Description = "附件", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class FileData
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("ID", "编码", "int")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private String _UserName;
        /// <summary>用户名</summary>
        [DisplayName("用户名")]
        [Description("用户名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UserName", "用户名", "nvarchar(50)")]
        public String UserName { get => _UserName; set { if (OnPropertyChanging("UserName", value)) { _UserName = value; OnPropertyChanged("UserName"); } } }

        private String _FileName;
        /// <summary>文件名</summary>
        [DisplayName("文件名")]
        [Description("文件名")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn("FileName", "文件名", "nvarchar(200)")]
        public String FileName { get => _FileName; set { if (OnPropertyChanging("FileName", value)) { _FileName = value; OnPropertyChanged("FileName"); } } }

        private String _UserIp;
        /// <summary>用户IP</summary>
        [DisplayName("用户IP")]
        [Description("用户IP")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UserIp", "用户IP", "nvarchar(50)")]
        public String UserIp { get => _UserIp; set { if (OnPropertyChanging("UserIp", value)) { _UserIp = value; OnPropertyChanged("UserIp"); } } }

        private Int32 _FileSize;
        /// <summary>文件大小</summary>
        [DisplayName("文件大小")]
        [Description("文件大小")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("FileSize", "文件大小", "int")]
        public Int32 FileSize { get => _FileSize; set { if (OnPropertyChanging("FileSize", value)) { _FileSize = value; OnPropertyChanged("FileSize"); } } }

        private Int32 _RecvedBytes;
        /// <summary>接收字节</summary>
        [DisplayName("接收字节")]
        [Description("接收字节")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("RecvedBytes", "接收字节", "int")]
        public Int32 RecvedBytes { get => _RecvedBytes; set { if (OnPropertyChanging("RecvedBytes", value)) { _RecvedBytes = value; OnPropertyChanged("RecvedBytes"); } } }

        private String _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Status", "状态", "nvarchar(50)")]
        public String Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateTime", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private String _DirName;
        /// <summary>路径名</summary>
        [DisplayName("路径名")]
        [Description("路径名")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("DirName", "路径名", "nvarchar(500)")]
        public String DirName { get => _DirName; set { if (OnPropertyChanging("DirName", value)) { _DirName = value; OnPropertyChanged("DirName"); } } }

        private Decimal _ConsumTime;
        /// <summary>消费时间</summary>
        [DisplayName("消费时间")]
        [Description("消费时间")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn("ConsumTime", "消费时间", "decimal(18, 2)", Precision = 0, Scale = 2)]
        public Decimal ConsumTime { get => _ConsumTime; set { if (OnPropertyChanging("ConsumTime", value)) { _ConsumTime = value; OnPropertyChanged("ConsumTime"); } } }
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
                    case "UserName": return _UserName;
                    case "FileName": return _FileName;
                    case "UserIp": return _UserIp;
                    case "FileSize": return _FileSize;
                    case "RecvedBytes": return _RecvedBytes;
                    case "Status": return _Status;
                    case "CreateTime": return _CreateTime;
                    case "UpdateTime": return _UpdateTime;
                    case "DirName": return _DirName;
                    case "ConsumTime": return _ConsumTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = value.ToInt(); break;
                    case "UserName": _UserName = Convert.ToString(value); break;
                    case "FileName": _FileName = Convert.ToString(value); break;
                    case "UserIp": _UserIp = Convert.ToString(value); break;
                    case "FileSize": _FileSize = value.ToInt(); break;
                    case "RecvedBytes": _RecvedBytes = value.ToInt(); break;
                    case "Status": _Status = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    case "DirName": _DirName = Convert.ToString(value); break;
                    case "ConsumTime": _ConsumTime = Convert.ToDecimal(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得附件字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编码</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>用户名</summary>
            public static readonly Field UserName = FindByName("UserName");

            /// <summary>文件名</summary>
            public static readonly Field FileName = FindByName("FileName");

            /// <summary>用户IP</summary>
            public static readonly Field UserIp = FindByName("UserIp");

            /// <summary>文件大小</summary>
            public static readonly Field FileSize = FindByName("FileSize");

            /// <summary>接收字节</summary>
            public static readonly Field RecvedBytes = FindByName("RecvedBytes");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            /// <summary>路径名</summary>
            public static readonly Field DirName = FindByName("DirName");

            /// <summary>消费时间</summary>
            public static readonly Field ConsumTime = FindByName("ConsumTime");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得附件字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编码</summary>
            public const String ID = "ID";

            /// <summary>用户名</summary>
            public const String UserName = "UserName";

            /// <summary>文件名</summary>
            public const String FileName = "FileName";

            /// <summary>用户IP</summary>
            public const String UserIp = "UserIp";

            /// <summary>文件大小</summary>
            public const String FileSize = "FileSize";

            /// <summary>接收字节</summary>
            public const String RecvedBytes = "RecvedBytes";

            /// <summary>状态</summary>
            public const String Status = "Status";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            /// <summary>路径名</summary>
            public const String DirName = "DirName";

            /// <summary>消费时间</summary>
            public const String ConsumTime = "ConsumTime";
        }
        #endregion
    }
}