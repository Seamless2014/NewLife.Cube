using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.BasicData.Entity
{
    /// <summary>行业类型</summary>
    [Serializable]
    [DataObject]
    [Description("行业类型")]
    [BindIndex("PK_IndustryType", true, "Id")]
    [BindIndex("IX_IndustryType_Description", false, "Description")]
    [BindTable("IndustryType", Description = "行业类型", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class IndustryType
    {
        #region 属性
        private Int32 _Id;
        /// <summary>主键</summary>
        [DisplayName("主键")]
        [Description("主键")]
        [DataObjectField(true, false, false, 0)]
        [BindColumn("Id", "主键", "")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private Int32 _Code;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Code", "编码", "")]
        public Int32 Code { get => _Code; set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } } }

        private String _Description;
        /// <summary>描述</summary>
        [DisplayName("描述")]
        [Description("描述")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn("Description", "描述", "varchar(200)", Master = true)]
        public String Description { get => _Description; set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } } }

        private Int32 _ParentID;
        /// <summary>父级</summary>
        [DisplayName("父级")]
        [Description("父级")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("ParentID", "父级", "")]
        public Int32 ParentID { get => _ParentID; set { if (OnPropertyChanging("ParentID", value)) { _ParentID = value; OnPropertyChanged("ParentID"); } } }

        private String _IndustryType;
        /// <summary>行业类型</summary>
        [DisplayName("行业类型")]
        [Description("行业类型")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn("Industry_Type", "行业类型", "varchar(32)")]
        public String Industry_Type { get => _IndustryType; set { if (OnPropertyChanging("IndustryType", value)) { _IndustryType = value; OnPropertyChanged("IndustryType"); } } }
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
                    case "Id": return _Id;
                    case "Code": return _Code;
                    case "Description": return _Description;
                    case "ParentID": return _ParentID;
                    case "IndustryType": return _IndustryType;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "Code": _Code = value.ToInt(); break;
                    case "Description": _Description = Convert.ToString(value); break;
                    case "ParentID": _ParentID = value.ToInt(); break;
                    case "IndustryType": _IndustryType = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得行业类型字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>主键</summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary>编码</summary>
            public static readonly Field Code = FindByName("Code");

            /// <summary>描述</summary>
            public static readonly Field Description = FindByName("Description");

            /// <summary>父编码</summary>
            public static readonly Field ParentID = FindByName("ParentID");

            /// <summary>行业类型</summary>
            public static readonly Field Industry_Type = FindByName("Industry_Type");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得行业类型字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>主键</summary>
            public const String Id = "Id";

            /// <summary>编码</summary>
            public const String Code = "Code";

            /// <summary>描述</summary>
            public const String Description = "Description";

            /// <summary>父编码</summary>
            public const String ParentID = "ParentID";

            /// <summary>行业类型</summary>
            public const String Industry_Type = "Industry_Type";
        }
        #endregion
    }
}