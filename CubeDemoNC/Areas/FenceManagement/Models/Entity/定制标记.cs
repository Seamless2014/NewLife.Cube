using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace GPSPlatform.FenceManagement.Entity
{
    /// <summary>定制标记</summary>
    [Serializable]
    [DataObject]
    [Description("定制标记")]
    [BindTable("CustomMarker", Description = "定制标记", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class CustomMarker
    {
        #region 属性
        private Int32 _MarkerId;
        /// <summary>标记编码</summary>
        [DisplayName("标记编码")]
        [Description("标记编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("MarkerId", "标记编码", "int")]
        public Int32 MarkerId { get => _MarkerId; set { if (OnPropertyChanging("MarkerId", value)) { _MarkerId = value; OnPropertyChanged("MarkerId"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Name", "名称", "nvarchar(255)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _Code;
        /// <summary>代码</summary>
        [DisplayName("代码")]
        [Description("代码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Code", "代码", "nvarchar(255)")]
        public String Code { get => _Code; set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Owner", "物主", "nvarchar(255)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Phone;
        /// <summary>电话</summary>
        [DisplayName("电话")]
        [Description("电话")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Phone", "电话", "nvarchar(255)")]
        public String Phone { get => _Phone; set { if (OnPropertyChanging("Phone", value)) { _Phone = value; OnPropertyChanged("Phone"); } } }

        private String _Mobile;
        /// <summary>手机号</summary>
        [DisplayName("手机号")]
        [Description("手机号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Mobile", "手机号", "nvarchar(255)")]
        public String Mobile { get => _Mobile; set { if (OnPropertyChanging("Mobile", value)) { _Mobile = value; OnPropertyChanged("Mobile"); } } }

        private String _Layer;
        /// <summary>层级</summary>
        [DisplayName("层级")]
        [Description("层级")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Layer", "层级", "nvarchar(255)")]
        public String Layer { get => _Layer; set { if (OnPropertyChanging("Layer", value)) { _Layer = value; OnPropertyChanged("Layer"); } } }

        private Int32 _DepId;
        /// <summary>部门编码</summary>
        [DisplayName("部门编码")]
        [Description("部门编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("DepId", "部门编码", "int")]
        public Int32 DepId { get => _DepId; set { if (OnPropertyChanging("DepId", value)) { _DepId = value; OnPropertyChanged("DepId"); } } }

        private String _Office;
        /// <summary>办公</summary>
        [DisplayName("办公")]
        [Description("办公")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Office", "办公", "nvarchar(255)")]
        public String Office { get => _Office; set { if (OnPropertyChanging("Office", value)) { _Office = value; OnPropertyChanged("Office"); } } }

        private Double _Longitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Longitude", "经度", "float")]
        public Double Longitude { get => _Longitude; set { if (OnPropertyChanging("Longitude", value)) { _Longitude = value; OnPropertyChanged("Longitude"); } } }

        private Double _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Latitude", "纬度", "float")]
        public Double Latitude { get => _Latitude; set { if (OnPropertyChanging("Latitude", value)) { _Latitude = value; OnPropertyChanged("Latitude"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

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

        private Boolean _IsEnclosure;
        /// <summary>是否封闭</summary>
        [DisplayName("是否封闭")]
        [Description("是否封闭")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("IsEnclosure", "是否封闭", "bit")]
        public Boolean IsEnclosure { get => _IsEnclosure; set { if (OnPropertyChanging("IsEnclosure", value)) { _IsEnclosure = value; OnPropertyChanged("IsEnclosure"); } } }

        private Int32 _Scope;
        /// <summary>范围</summary>
        [DisplayName("范围")]
        [Description("范围")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Scope", "范围", "int")]
        public Int32 Scope { get => _Scope; set { if (OnPropertyChanging("Scope", value)) { _Scope = value; OnPropertyChanged("Scope"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Remark", "备注", "nvarchar(255)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Boolean _Fixed;
        /// <summary>是否固定</summary>
        [DisplayName("是否固定")]
        [Description("是否固定")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Fixed", "是否固定", "bit")]
        public Boolean Fixed { get => _Fixed; set { if (OnPropertyChanging("Fixed", value)) { _Fixed = value; OnPropertyChanged("Fixed"); } } }
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
                    case "MarkerId": return _MarkerId;
                    case "Name": return _Name;
                    case "Code": return _Code;
                    case "Owner": return _Owner;
                    case "Phone": return _Phone;
                    case "Mobile": return _Mobile;
                    case "Layer": return _Layer;
                    case "DepId": return _DepId;
                    case "Office": return _Office;
                    case "Longitude": return _Longitude;
                    case "Latitude": return _Latitude;
                    case "Deleted": return _Deleted;
                    case "CreateTime": return _CreateTime;
                    case "TenantId": return _TenantId;
                    case "IsEnclosure": return _IsEnclosure;
                    case "Scope": return _Scope;
                    case "Remark": return _Remark;
                    case "Fixed": return _Fixed;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "MarkerId": _MarkerId = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Code": _Code = Convert.ToString(value); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Phone": _Phone = Convert.ToString(value); break;
                    case "Mobile": _Mobile = Convert.ToString(value); break;
                    case "Layer": _Layer = Convert.ToString(value); break;
                    case "DepId": _DepId = value.ToInt(); break;
                    case "Office": _Office = Convert.ToString(value); break;
                    case "Longitude": _Longitude = value.ToDouble(); break;
                    case "Latitude": _Latitude = value.ToDouble(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "IsEnclosure": _IsEnclosure = value.ToBoolean(); break;
                    case "Scope": _Scope = value.ToInt(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Fixed": _Fixed = value.ToBoolean(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得定制标记字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>标记编码</summary>
            public static readonly Field MarkerId = FindByName("MarkerId");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>代码</summary>
            public static readonly Field Code = FindByName("Code");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>电话</summary>
            public static readonly Field Phone = FindByName("Phone");

            /// <summary>手机号</summary>
            public static readonly Field Mobile = FindByName("Mobile");

            /// <summary>层级</summary>
            public static readonly Field Layer = FindByName("Layer");

            /// <summary>部门编码</summary>
            public static readonly Field DepId = FindByName("DepId");

            /// <summary>办公</summary>
            public static readonly Field Office = FindByName("Office");

            /// <summary>经度</summary>
            public static readonly Field Longitude = FindByName("Longitude");

            /// <summary>纬度</summary>
            public static readonly Field Latitude = FindByName("Latitude");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>是否封闭</summary>
            public static readonly Field IsEnclosure = FindByName("IsEnclosure");

            /// <summary>范围</summary>
            public static readonly Field Scope = FindByName("Scope");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>是否固定</summary>
            public static readonly Field Fixed = FindByName("Fixed");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得定制标记字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>标记编码</summary>
            public const String MarkerId = "MarkerId";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>代码</summary>
            public const String Code = "Code";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>电话</summary>
            public const String Phone = "Phone";

            /// <summary>手机号</summary>
            public const String Mobile = "Mobile";

            /// <summary>层级</summary>
            public const String Layer = "Layer";

            /// <summary>部门编码</summary>
            public const String DepId = "DepId";

            /// <summary>办公</summary>
            public const String Office = "Office";

            /// <summary>经度</summary>
            public const String Longitude = "Longitude";

            /// <summary>纬度</summary>
            public const String Latitude = "Latitude";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>是否封闭</summary>
            public const String IsEnclosure = "IsEnclosure";

            /// <summary>范围</summary>
            public const String Scope = "Scope";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>是否固定</summary>
            public const String Fixed = "Fixed";
        }
        #endregion
    }
}