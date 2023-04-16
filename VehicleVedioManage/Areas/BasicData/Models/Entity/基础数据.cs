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
    /// <summary>基础数据</summary>
    [Serializable]
    [DataObject]
    [Description("基础数据")]
    [BindIndex("IU_BasicInfo_Name", true, "Name")]
    [BindTable("BasicInfo", Description = "基础数据", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class BasicInfo
    {
        #region 属性
        private Int32 _BaseId;
        /// <summary>基础数据编码</summary>
        [DisplayName("基础数据编码")]
        [Description("基础数据编码")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("BaseId", "基础数据编码", "")]
        public Int32 BaseId { get => _BaseId; set { if (OnPropertyChanging("BaseId", value)) { _BaseId = value; OnPropertyChanged("BaseId"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Name", "名称", "", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _Code;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Code", "编码", "")]
        public String Code { get => _Code; set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } } }

        private String _Parent;
        /// <summary>父编码</summary>
        [DisplayName("父编码")]
        [Description("父编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Parent", "父编码", "")]
        public String Parent { get => _Parent; set { if (OnPropertyChanging("Parent", value)) { _Parent = value; OnPropertyChanged("Parent"); } } }

        private String _MetaData;
        /// <summary>元数据</summary>
        [DisplayName("元数据")]
        [Description("元数据")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("MetaData", "元数据", "")]
        public String MetaData { get => _MetaData; set { if (OnPropertyChanging("MetaData", value)) { _MetaData = value; OnPropertyChanged("MetaData"); } } }

        private Boolean _Deleted;
        /// <summary>启用</summary>
        [DisplayName("启用")]
        [Description("启用")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "启用", "")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TenantId", "租户编码", "")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Remark", "备注", "")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "物主", "")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private Int32 _SN;
        /// <summary>序号</summary>
        [DisplayName("序号")]
        [Description("序号")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("SN", "序号", "")]
        public Int32 SN { get => _SN; set { if (OnPropertyChanging("SN", value)) { _SN = value; OnPropertyChanged("SN"); } } }
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
                    case "BaseId": return _BaseId;
                    case "Name": return _Name;
                    case "Code": return _Code;
                    case "Parent": return _Parent;
                    case "MetaData": return _MetaData;
                    case "Deleted": return _Deleted;
                    case "CreateTime": return _CreateTime;
                    case "TenantId": return _TenantId;
                    case "Remark": return _Remark;
                    case "Owner": return _Owner;
                    case "SN": return _SN;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "BaseId": _BaseId = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Code": _Code = Convert.ToString(value); break;
                    case "Parent": _Parent = Convert.ToString(value); break;
                    case "MetaData": _MetaData = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "SN": _SN = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得基础数据字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>基础数据编码</summary>
            public static readonly Field BaseId = FindByName("BaseId");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>编码</summary>
            public static readonly Field Code = FindByName("Code");

            /// <summary>父编码</summary>
            public static readonly Field Parent = FindByName("Parent");

            /// <summary>元数据</summary>
            public static readonly Field MetaData = FindByName("MetaData");

            /// <summary>启用</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>序号</summary>
            public static readonly Field SN = FindByName("SN");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得基础数据字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>基础数据编码</summary>
            public const String BaseId = "BaseId";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>编码</summary>
            public const String Code = "Code";

            /// <summary>父编码</summary>
            public const String Parent = "Parent";

            /// <summary>元数据</summary>
            public const String MetaData = "MetaData";

            /// <summary>启用</summary>
            public const String Deleted = "Deleted";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>序号</summary>
            public const String SN = "SN";
        }
        #endregion
    }
}