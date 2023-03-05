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
    /// <summary>报表模型</summary>
    [Serializable]
    [DataObject]
    [Description("报表模型")]
    [BindTable("ReportModel", Description = "报表模型", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class ReportModel
    {
        #region 属性
        private Int32 _ReportId;
        /// <summary>报表编码</summary>
        [DisplayName("报表编码")]
        [Description("报表编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("ReportId", "报表编码", "int")]
        public Int32 ReportId { get => _ReportId; set { if (OnPropertyChanging("ReportId", value)) { _ReportId = value; OnPropertyChanged("ReportId"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Name", "名称", "nvarchar(255)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _QueryId;
        /// <summary>查询编码</summary>
        [DisplayName("查询编码")]
        [Description("查询编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("QueryId", "查询编码", "nvarchar(255)")]
        public String QueryId { get => _QueryId; set { if (OnPropertyChanging("QueryId", value)) { _QueryId = value; OnPropertyChanged("QueryId"); } } }

        private String _Code;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Code", "编码", "nvarchar(255)")]
        public String Code { get => _Code; set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [DisplayName("拥有者")]
        [Description("拥有者")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Owner", "拥有者", "nvarchar(255)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }
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
                    case "ReportId": return _ReportId;
                    case "Name": return _Name;
                    case "QueryId": return _QueryId;
                    case "Code": return _Code;
                    case "CreateTime": return _CreateTime;
                    case "Deleted": return _Deleted;
                    case "Owner": return _Owner;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ReportId": _ReportId = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "QueryId": _QueryId = Convert.ToString(value); break;
                    case "Code": _Code = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得报表模型字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>报表编码</summary>
            public static readonly Field ReportId = FindByName("ReportId");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>查询编码</summary>
            public static readonly Field QueryId = FindByName("QueryId");

            /// <summary>编码</summary>
            public static readonly Field Code = FindByName("Code");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得报表模型字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>报表编码</summary>
            public const String ReportId = "ReportId";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>查询编码</summary>
            public const String QueryId = "QueryId";

            /// <summary>编码</summary>
            public const String Code = "Code";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";
        }
        #endregion
    }
}