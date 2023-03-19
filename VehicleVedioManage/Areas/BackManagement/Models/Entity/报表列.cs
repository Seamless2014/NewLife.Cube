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
    /// <summary>报表列</summary>
    [Serializable]
    [DataObject]
    [Description("报表列")]
    [BindTable("ReportColumn", Description = "报表列", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class ReportColumn
    {
        #region 属性
        private Int32 _ReportColumnId;
        /// <summary>报表列编码</summary>
        [DisplayName("报表列编码")]
        [Description("报表列编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("ReportColumnId", "报表列编码", "int")]
        public Int32 ReportColumnId { get => _ReportColumnId; set { if (OnPropertyChanging("ReportColumnId", value)) { _ReportColumnId = value; OnPropertyChanged("ReportColumnId"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Name", "名称", "nvarchar(255)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private Int32 _Width;
        /// <summary>宽度</summary>
        [DisplayName("宽度")]
        [Description("宽度")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Width", "宽度", "int")]
        public Int32 Width { get => _Width; set { if (OnPropertyChanging("Width", value)) { _Width = value; OnPropertyChanged("Width"); } } }

        private String _Code;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Code", "编码", "nvarchar(255)")]
        public String Code { get => _Code; set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } } }

        private Int32 _No;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("No", "编号", "int")]
        public Int32 No { get => _No; set { if (OnPropertyChanging("No", value)) { _No = value; OnPropertyChanged("No"); } } }

        private String _ColType;
        /// <summary>列类型</summary>
        [DisplayName("列类型")]
        [Description("列类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("ColType", "列类型", "nvarchar(255)")]
        public String ColType { get => _ColType; set { if (OnPropertyChanging("ColType", value)) { _ColType = value; OnPropertyChanged("ColType"); } } }

        private String _BasicDataCode;
        /// <summary>基础数据编码</summary>
        [DisplayName("基础数据编码")]
        [Description("基础数据编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("BasicDataCode", "基础数据编码", "nvarchar(255)")]
        public String BasicDataCode { get => _BasicDataCode; set { if (OnPropertyChanging("BasicDataCode", value)) { _BasicDataCode = value; OnPropertyChanged("BasicDataCode"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Boolean _Visible;
        /// <summary>显示</summary>
        [DisplayName("显示")]
        [Description("显示")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Visible", "显示", "bit")]
        public Boolean Visible { get => _Visible; set { if (OnPropertyChanging("Visible", value)) { _Visible = value; OnPropertyChanged("Visible"); } } }

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

        private Int32 _ReportId;
        /// <summary>报表编码</summary>
        [DisplayName("报表编码")]
        [Description("报表编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("ReportId", "报表编码", "int")]
        public Int32 ReportId { get => _ReportId; set { if (OnPropertyChanging("ReportId", value)) { _ReportId = value; OnPropertyChanged("ReportId"); } } }
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
                    case "ReportColumnId": return _ReportColumnId;
                    case "Name": return _Name;
                    case "Width": return _Width;
                    case "Code": return _Code;
                    case "No": return _No;
                    case "ColType": return _ColType;
                    case "BasicDataCode": return _BasicDataCode;
                    case "CreateTime": return _CreateTime;
                    case "Visible": return _Visible;
                    case "Deleted": return _Deleted;
                    case "Owner": return _Owner;
                    case "ReportId": return _ReportId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ReportColumnId": _ReportColumnId = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Width": _Width = value.ToInt(); break;
                    case "Code": _Code = Convert.ToString(value); break;
                    case "No": _No = value.ToInt(); break;
                    case "ColType": _ColType = Convert.ToString(value); break;
                    case "BasicDataCode": _BasicDataCode = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Visible": _Visible = value.ToBoolean(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "ReportId": _ReportId = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得报表列字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>报表列编码</summary>
            public static readonly Field ReportColumnId = FindByName("ReportColumnId");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>宽度</summary>
            public static readonly Field Width = FindByName("Width");

            /// <summary>编码</summary>
            public static readonly Field Code = FindByName("Code");

            /// <summary>编号</summary>
            public static readonly Field No = FindByName("No");

            /// <summary>列类型</summary>
            public static readonly Field ColType = FindByName("ColType");

            /// <summary>基础数据编码</summary>
            public static readonly Field BasicDataCode = FindByName("BasicDataCode");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>显示</summary>
            public static readonly Field Visible = FindByName("Visible");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>报表编码</summary>
            public static readonly Field ReportId = FindByName("ReportId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得报表列字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>报表列编码</summary>
            public const String ReportColumnId = "ReportColumnId";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>宽度</summary>
            public const String Width = "Width";

            /// <summary>编码</summary>
            public const String Code = "Code";

            /// <summary>编号</summary>
            public const String No = "No";

            /// <summary>列类型</summary>
            public const String ColType = "ColType";

            /// <summary>基础数据编码</summary>
            public const String BasicDataCode = "BasicDataCode";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>显示</summary>
            public const String Visible = "Visible";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";

            /// <summary>报表编码</summary>
            public const String ReportId = "ReportId";
        }
        #endregion
    }
}