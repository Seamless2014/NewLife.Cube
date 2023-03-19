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
    /// <summary>围栏绑定</summary>
    [Serializable]
    [DataObject]
    [Description("围栏绑定")]
    [BindTable("ElectronicFenceBinding", Description = "围栏绑定", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class ElectronicFenceBinding
    {
        #region 属性
        private Int32 _BindId;
        /// <summary>绑定编码</summary>
        [DisplayName("绑定编码")]
        [Description("绑定编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("BindId", "绑定编码", "int")]
        public Int32 BindId { get => _BindId; set { if (OnPropertyChanging("BindId", value)) { _BindId = value; OnPropertyChanged("BindId"); } } }

        private Int32 _EnclosureId;
        /// <summary>围栏编码</summary>
        [DisplayName("围栏编码")]
        [Description("围栏编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("EnclosureId", "围栏编码", "int")]
        public Int32 EnclosureId { get => _EnclosureId; set { if (OnPropertyChanging("EnclosureId", value)) { _EnclosureId = value; OnPropertyChanged("EnclosureId"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VehicleId", "车辆编码", "int")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private String _BindType;
        /// <summary>绑定类型</summary>
        [DisplayName("绑定类型")]
        [Description("绑定类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("BindType", "绑定类型", "nvarchar(255)")]
        public String BindType { get => _BindType; set { if (OnPropertyChanging("BindType", value)) { _BindType = value; OnPropertyChanged("BindType"); } } }

        private Int32 _CommandId;
        /// <summary>指令编码</summary>
        [DisplayName("指令编码")]
        [Description("指令编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("CommandId", "指令编码", "int")]
        public Int32 CommandId { get => _CommandId; set { if (OnPropertyChanging("CommandId", value)) { _CommandId = value; OnPropertyChanged("CommandId"); } } }

        private Int32 _ConfigType;
        /// <summary>配置类型</summary>
        [DisplayName("配置类型")]
        [Description("配置类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("ConfigType", "配置类型", "int")]
        public Int32 ConfigType { get => _ConfigType; set { if (OnPropertyChanging("ConfigType", value)) { _ConfigType = value; OnPropertyChanged("ConfigType"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Remark", "备注", "nvarchar(255)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

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
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Owner", "物主", "nvarchar(255)")]
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
                    case "BindId": return _BindId;
                    case "EnclosureId": return _EnclosureId;
                    case "VehicleId": return _VehicleId;
                    case "BindType": return _BindType;
                    case "CommandId": return _CommandId;
                    case "ConfigType": return _ConfigType;
                    case "TenantId": return _TenantId;
                    case "CreateTime": return _CreateTime;
                    case "Remark": return _Remark;
                    case "Deleted": return _Deleted;
                    case "Owner": return _Owner;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "BindId": _BindId = value.ToInt(); break;
                    case "EnclosureId": _EnclosureId = value.ToInt(); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "BindType": _BindType = Convert.ToString(value); break;
                    case "CommandId": _CommandId = value.ToInt(); break;
                    case "ConfigType": _ConfigType = value.ToInt(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得围栏绑定字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>绑定编码</summary>
            public static readonly Field BindId = FindByName("BindId");

            /// <summary>围栏编码</summary>
            public static readonly Field EnclosureId = FindByName("EnclosureId");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>绑定类型</summary>
            public static readonly Field BindType = FindByName("BindType");

            /// <summary>指令编码</summary>
            public static readonly Field CommandId = FindByName("CommandId");

            /// <summary>配置类型</summary>
            public static readonly Field ConfigType = FindByName("ConfigType");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得围栏绑定字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>绑定编码</summary>
            public const String BindId = "BindId";

            /// <summary>围栏编码</summary>
            public const String EnclosureId = "EnclosureId";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>绑定类型</summary>
            public const String BindType = "BindType";

            /// <summary>指令编码</summary>
            public const String CommandId = "CommandId";

            /// <summary>配置类型</summary>
            public const String ConfigType = "ConfigType";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>物主</summary>
            public const String Owner = "Owner";
        }
        #endregion
    }
}