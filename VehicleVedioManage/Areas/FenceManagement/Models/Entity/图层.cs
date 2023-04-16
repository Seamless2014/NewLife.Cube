using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.FenceManagement.Entity
{
    /// <summary>图层</summary>
    [Serializable]
    [DataObject]
    [Description("图层")]
    [BindIndex("IU_MapLayer_Name", true, "Name")]
    [BindTable("MapLayer", Description = "图层", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class MapLayer
    {
        #region 属性
        private Int32 _LayerId;
        /// <summary>图层编码</summary>
        [DisplayName("图层编码")]
        [Description("图层编码")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("LayerId", "图层编码", "")]
        public Int32 LayerId { get => _LayerId; set { if (OnPropertyChanging("LayerId", value)) { _LayerId = value; OnPropertyChanged("LayerId"); } } }

        private String _Name;
        /// <summary>图层名称</summary>
        [DisplayName("图层名称")]
        [Description("图层名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Name", "图层名称", "", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private Boolean _Visible;
        /// <summary>可视</summary>
        [DisplayName("可视")]
        [Description("可视")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Visible", "可视", "")]
        public Boolean Visible { get => _Visible; set { if (OnPropertyChanging("Visible", value)) { _Visible = value; OnPropertyChanged("Visible"); } } }

        private Boolean _Animated;
        /// <summary>动画</summary>
        [DisplayName("动画")]
        [Description("动画")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Animated", "动画", "")]
        public Boolean Animated { get => _Animated; set { if (OnPropertyChanging("Animated", value)) { _Animated = value; OnPropertyChanged("Animated"); } } }

        private String _Icon;
        /// <summary>图标</summary>
        [DisplayName("图标")]
        [Description("图标")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Icon", "图标", "")]
        public String Icon { get => _Icon; set { if (OnPropertyChanging("Icon", value)) { _Icon = value; OnPropertyChanged("Icon"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TenantId", "租户编码", "")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private Int32 _MaxIconZoom;
        /// <summary>最大缩放图标</summary>
        [DisplayName("最大缩放图标")]
        [Description("最大缩放图标")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("MaxIconZoom", "最大缩放图标", "")]
        public Int32 MaxIconZoom { get => _MaxIconZoom; set { if (OnPropertyChanging("MaxIconZoom", value)) { _MaxIconZoom = value; OnPropertyChanged("MaxIconZoom"); } } }

        private Int32 _MaxLabelZoom;
        /// <summary>最大缩放标签</summary>
        [DisplayName("最大缩放标签")]
        [Description("最大缩放标签")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("MaxLabelZoom", "最大缩放标签", "")]
        public Int32 MaxLabelZoom { get => _MaxLabelZoom; set { if (OnPropertyChanging("MaxLabelZoom", value)) { _MaxLabelZoom = value; OnPropertyChanged("MaxLabelZoom"); } } }

        private Int32 _MinIconZoom;
        /// <summary>最小缩放图标</summary>
        [DisplayName("最小缩放图标")]
        [Description("最小缩放图标")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("MinIconZoom", "最小缩放图标", "")]
        public Int32 MinIconZoom { get => _MinIconZoom; set { if (OnPropertyChanging("MinIconZoom", value)) { _MinIconZoom = value; OnPropertyChanged("MinIconZoom"); } } }

        private Int32 _MinLabelZoom;
        /// <summary>最小缩放标签</summary>
        [DisplayName("最小缩放标签")]
        [Description("最小缩放标签")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("MinLabelZoom", "最小缩放标签", "")]
        public Int32 MinLabelZoom { get => _MinLabelZoom; set { if (OnPropertyChanging("MinLabelZoom", value)) { _MinLabelZoom = value; OnPropertyChanged("MinLabelZoom"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _Creator;
        /// <summary>创建者</summary>
        [DisplayName("创建者")]
        [Description("创建者")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Creator", "创建者", "")]
        public String Creator { get => _Creator; set { if (OnPropertyChanging("Creator", value)) { _Creator = value; OnPropertyChanged("Creator"); } } }

        private String _ForeColor;
        /// <summary>前景色</summary>
        [DisplayName("前景色")]
        [Description("前景色")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("ForeColor", "前景色", "")]
        public String ForeColor { get => _ForeColor; set { if (OnPropertyChanging("ForeColor", value)) { _ForeColor = value; OnPropertyChanged("ForeColor"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }
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
                    case "LayerId": return _LayerId;
                    case "Name": return _Name;
                    case "Visible": return _Visible;
                    case "Animated": return _Animated;
                    case "Icon": return _Icon;
                    case "TenantId": return _TenantId;
                    case "MaxIconZoom": return _MaxIconZoom;
                    case "MaxLabelZoom": return _MaxLabelZoom;
                    case "MinIconZoom": return _MinIconZoom;
                    case "MinLabelZoom": return _MinLabelZoom;
                    case "CreateTime": return _CreateTime;
                    case "Creator": return _Creator;
                    case "ForeColor": return _ForeColor;
                    case "Deleted": return _Deleted;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "LayerId": _LayerId = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Visible": _Visible = value.ToBoolean(); break;
                    case "Animated": _Animated = value.ToBoolean(); break;
                    case "Icon": _Icon = Convert.ToString(value); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "MaxIconZoom": _MaxIconZoom = value.ToInt(); break;
                    case "MaxLabelZoom": _MaxLabelZoom = value.ToInt(); break;
                    case "MinIconZoom": _MinIconZoom = value.ToInt(); break;
                    case "MinLabelZoom": _MinLabelZoom = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Creator": _Creator = Convert.ToString(value); break;
                    case "ForeColor": _ForeColor = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得图层字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>图层编码</summary>
            public static readonly Field LayerId = FindByName("LayerId");

            /// <summary>图层名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>可视</summary>
            public static readonly Field Visible = FindByName("Visible");

            /// <summary>动画</summary>
            public static readonly Field Animated = FindByName("Animated");

            /// <summary>图标</summary>
            public static readonly Field Icon = FindByName("Icon");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>最大缩放图标</summary>
            public static readonly Field MaxIconZoom = FindByName("MaxIconZoom");

            /// <summary>最大缩放标签</summary>
            public static readonly Field MaxLabelZoom = FindByName("MaxLabelZoom");

            /// <summary>最小缩放图标</summary>
            public static readonly Field MinIconZoom = FindByName("MinIconZoom");

            /// <summary>最小缩放标签</summary>
            public static readonly Field MinLabelZoom = FindByName("MinLabelZoom");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>创建者</summary>
            public static readonly Field Creator = FindByName("Creator");

            /// <summary>前景色</summary>
            public static readonly Field ForeColor = FindByName("ForeColor");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得图层字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>图层编码</summary>
            public const String LayerId = "LayerId";

            /// <summary>图层名称</summary>
            public const String Name = "Name";

            /// <summary>可视</summary>
            public const String Visible = "Visible";

            /// <summary>动画</summary>
            public const String Animated = "Animated";

            /// <summary>图标</summary>
            public const String Icon = "Icon";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>最大缩放图标</summary>
            public const String MaxIconZoom = "MaxIconZoom";

            /// <summary>最大缩放标签</summary>
            public const String MaxLabelZoom = "MaxLabelZoom";

            /// <summary>最小缩放图标</summary>
            public const String MinIconZoom = "MinIconZoom";

            /// <summary>最小缩放标签</summary>
            public const String MinLabelZoom = "MinLabelZoom";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>创建者</summary>
            public const String Creator = "Creator";

            /// <summary>前景色</summary>
            public const String ForeColor = "ForeColor";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";
        }
        #endregion
    }
}