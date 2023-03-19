using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.BasicData.Entity
{
    /// <summary>功能模型</summary>
    [Serializable]
    [DataObject]
    [Description("功能模型")]
    [BindTable("FunctionModel", Description = "功能模型", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class FunctionModel
    {
        #region 属性
        private Int32 _FuncId;
        /// <summary>功能编码</summary>
        [DisplayName("功能编码")]
        [Description("功能编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("FuncId", "功能编码", "int")]
        public Int32 FuncId { get => _FuncId; set { if (OnPropertyChanging("FuncId", value)) { _FuncId = value; OnPropertyChanged("FuncId"); } } }

        private String _Descr;
        /// <summary>功能描述</summary>
        [DisplayName("功能描述")]
        [Description("功能描述")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Descr", "功能描述", "varchar(255)")]
        public String Descr { get => _Descr; set { if (OnPropertyChanging("Descr", value)) { _Descr = value; OnPropertyChanged("Descr"); } } }

        private Int32 _FuncType;
        /// <summary>功能类型</summary>
        [DisplayName("功能类型")]
        [Description("功能类型")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("FuncType", "功能类型", "int")]
        public Int32 FuncType { get => _FuncType; set { if (OnPropertyChanging("FuncType", value)) { _FuncType = value; OnPropertyChanged("FuncType"); } } }

        private Int32 _ParentId;
        /// <summary>上级编码</summary>
        [DisplayName("上级编码")]
        [Description("上级编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("ParentId", "上级编码", "int")]
        public Int32 ParentId { get => _ParentId; set { if (OnPropertyChanging("ParentId", value)) { _ParentId = value; OnPropertyChanged("ParentId"); } } }

        private String _Url;
        /// <summary>URL</summary>
        [DisplayName("URL")]
        [Description("URL")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("URL", "URL", "varchar(50)")]
        public String Url { get => _Url; set { if (OnPropertyChanging("Url", value)) { _Url = value; OnPropertyChanged("Url"); } } }

        private String _Icon;
        /// <summary>图标</summary>
        [DisplayName("图标")]
        [Description("图标")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Icon", "图标", "nvarchar(50)")]
        public String Icon { get => _Icon; set { if (OnPropertyChanging("Icon", value)) { _Icon = value; OnPropertyChanged("Icon"); } } }

        private Int32 _MenuSort;
        /// <summary>菜单排序</summary>
        [DisplayName("菜单排序")]
        [Description("菜单排序")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("MenuSort", "菜单排序", "int")]
        public Int32 MenuSort { get => _MenuSort; set { if (OnPropertyChanging("MenuSort", value)) { _MenuSort = value; OnPropertyChanged("MenuSort"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Name", "名称", "nvarchar(50)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

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
        /// <summary>物主</summary>
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "物主", "nvarchar(50)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Remark", "备注", "nvarchar(50)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Int32 _Flag;
        /// <summary>标志</summary>
        [DisplayName("标志")]
        [Description("标志")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Flag", "标志", "int")]
        public Int32 Flag { get => _Flag; set { if (OnPropertyChanging("Flag", value)) { _Flag = value; OnPropertyChanged("Flag"); } } }
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
                    case "FuncId": return _FuncId;
                    case "Descr": return _Descr;
                    case "FuncType": return _FuncType;
                    case "ParentId": return _ParentId;
                    case "Url": return _Url;
                    case "Icon": return _Icon;
                    case "MenuSort": return _MenuSort;
                    case "Name": return _Name;
                    case "CreateTime": return _CreateTime;
                    case "Deleted": return _Deleted;
                    case "Owner": return _Owner;
                    case "TenantId": return _TenantId;
                    case "Remark": return _Remark;
                    case "Flag": return _Flag;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "FuncId": _FuncId = value.ToInt(); break;
                    case "Descr": _Descr = Convert.ToString(value); break;
                    case "FuncType": _FuncType = value.ToInt(); break;
                    case "ParentId": _ParentId = value.ToInt(); break;
                    case "Url": _Url = Convert.ToString(value); break;
                    case "Icon": _Icon = Convert.ToString(value); break;
                    case "MenuSort": _MenuSort = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Flag": _Flag = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得功能模型字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>功能编码</summary>
            public static readonly Field FuncId = FindByName("FuncId");

            /// <summary>功能描述</summary>
            public static readonly Field Descr = FindByName("Descr");

            /// <summary>功能类型</summary>
            public static readonly Field FuncType = FindByName("FuncType");

            /// <summary>上级编码</summary>
            public static readonly Field ParentId = FindByName("ParentId");

            /// <summary>URL</summary>
            public static readonly Field Url = FindByName("Url");

            /// <summary>图标</summary>
            public static readonly Field Icon = FindByName("Icon");

            /// <summary>菜单排序</summary>
            public static readonly Field MenuSort = FindByName("MenuSort");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>标志</summary>
            public static readonly Field Flag = FindByName("Flag");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得功能模型字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>功能编码</summary>
            public const String FuncId = "FuncId";

            /// <summary>功能描述</summary>
            public const String Descr = "Descr";

            /// <summary>功能类型</summary>
            public const String FuncType = "FuncType";

            /// <summary>上级编码</summary>
            public const String ParentId = "ParentId";

            /// <summary>URL</summary>
            public const String Url = "Url";

            /// <summary>图标</summary>
            public const String Icon = "Icon";

            /// <summary>菜单排序</summary>
            public const String MenuSort = "MenuSort";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>标志</summary>
            public const String Flag = "Flag";
        }
        #endregion
    }
}