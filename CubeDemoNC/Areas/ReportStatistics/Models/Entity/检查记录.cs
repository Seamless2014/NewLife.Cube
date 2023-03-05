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
    /// <summary>检查记录</summary>
    [Serializable]
    [DataObject]
    [Description("检查记录")]
    [BindTable("CheckRecord", Description = "检查记录", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class CheckRecord
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("ID", "编号", "int")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private String _Answer;
        /// <summary>应答</summary>
        [DisplayName("应答")]
        [Description("应答")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Answer", "应答", "varchar(255)")]
        public String Answer { get => _Answer; set { if (OnPropertyChanging("Answer", value)) { _Answer = value; OnPropertyChanged("Answer"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Int32 _InfoId;
        /// <summary>信息编码</summary>
        [DisplayName("信息编码")]
        [Description("信息编码")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("InfoId", "信息编码", "int")]
        public Int32 InfoId { get => _InfoId; set { if (OnPropertyChanging("InfoId", value)) { _InfoId = value; OnPropertyChanged("InfoId"); } } }

        private String _Message;
        /// <summary>信息</summary>
        [DisplayName("信息")]
        [Description("信息")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Message", "信息", "varchar(255)")]
        public String Message { get => _Message; set { if (OnPropertyChanging("Message", value)) { _Message = value; OnPropertyChanged("Message"); } } }

        private String _ObjId;
        /// <summary>对象编码</summary>
        [DisplayName("对象编码")]
        [Description("对象编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("ObjId", "对象编码", "varchar(255)")]
        public String ObjId { get => _ObjId; set { if (OnPropertyChanging("ObjId", value)) { _ObjId = value; OnPropertyChanged("ObjId"); } } }

        private Int32 _ObjType;
        /// <summary>对象类型</summary>
        [DisplayName("对象类型")]
        [Description("对象类型")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("ObjType", "对象类型", "int")]
        public Int32 ObjType { get => _ObjType; set { if (OnPropertyChanging("ObjType", value)) { _ObjType = value; OnPropertyChanged("ObjType"); } } }

        private Int32 _PlatformId;
        /// <summary>平台编码</summary>
        [DisplayName("平台编码")]
        [Description("平台编码")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("PlatformId", "平台编码", "int")]
        public Int32 PlatformId { get => _PlatformId; set { if (OnPropertyChanging("PlatformId", value)) { _PlatformId = value; OnPropertyChanged("PlatformId"); } } }

        private Int32 _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("Status", "状态", "int")]
        public Int32 Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateTime", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }
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
                    case "Answer": return _Answer;
                    case "CreateTime": return _CreateTime;
                    case "InfoId": return _InfoId;
                    case "Message": return _Message;
                    case "ObjId": return _ObjId;
                    case "ObjType": return _ObjType;
                    case "PlatformId": return _PlatformId;
                    case "Status": return _Status;
                    case "UpdateTime": return _UpdateTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = value.ToInt(); break;
                    case "Answer": _Answer = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "InfoId": _InfoId = value.ToInt(); break;
                    case "Message": _Message = Convert.ToString(value); break;
                    case "ObjId": _ObjId = Convert.ToString(value); break;
                    case "ObjType": _ObjType = value.ToInt(); break;
                    case "PlatformId": _PlatformId = value.ToInt(); break;
                    case "Status": _Status = value.ToInt(); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得检查记录字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>应答</summary>
            public static readonly Field Answer = FindByName("Answer");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>信息编码</summary>
            public static readonly Field InfoId = FindByName("InfoId");

            /// <summary>信息</summary>
            public static readonly Field Message = FindByName("Message");

            /// <summary>对象编码</summary>
            public static readonly Field ObjId = FindByName("ObjId");

            /// <summary>对象类型</summary>
            public static readonly Field ObjType = FindByName("ObjType");

            /// <summary>平台编码</summary>
            public static readonly Field PlatformId = FindByName("PlatformId");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得检查记录字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String ID = "ID";

            /// <summary>应答</summary>
            public const String Answer = "Answer";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>信息编码</summary>
            public const String InfoId = "InfoId";

            /// <summary>信息</summary>
            public const String Message = "Message";

            /// <summary>对象编码</summary>
            public const String ObjId = "ObjId";

            /// <summary>对象类型</summary>
            public const String ObjType = "ObjType";

            /// <summary>平台编码</summary>
            public const String PlatformId = "PlatformId";

            /// <summary>状态</summary>
            public const String Status = "Status";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";
        }
        #endregion
    }
}