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
    /// <summary>行业类型</summary>
    [Serializable]
    [DataObject]
    [Description("行业类型")]
    [BindIndex("PK_IndustryType", true, "ID")]
    [BindTable("IndustryType", Description = "行业类型", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class IndustryType
    {
        #region 属性
        private Int32 _ID;
        /// <summary>行业类型</summary>
        [DisplayName("行业类型")]
        [Description("行业类型")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("ID", "行业类型", "int")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private Int32 _Amount;
        /// <summary>数量</summary>
        [DisplayName("数量")]
        [Description("数量")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Amount", "数量", "int")]
        public Int32 Amount { get => _Amount; set { if (OnPropertyChanging("Amount", value)) { _Amount = value; OnPropertyChanged("Amount"); } } }

        private Int32 _Code;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Code", "编码", "int")]
        public Int32 Code { get => _Code; set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } } }

        private String _Description;
        /// <summary>描述</summary>
        [DisplayName("描述")]
        [Description("描述")]
        [DataObjectField(false, false, true, 64)]
        [BindColumn("Description", "描述", "varchar(64)")]
        public String Description { get => _Description; set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } } }

        private Int32 _ParentCode;
        /// <summary>上级编码</summary>
        [DisplayName("上级编码")]
        [Description("上级编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("ParentCode", "上级编码", "int")]
        public Int32 ParentCode { get => _ParentCode; set { if (OnPropertyChanging("ParentCode", value)) { _ParentCode = value; OnPropertyChanged("ParentCode"); } } }

        private String _name;
        /// <summary>行业类型</summary>
        [DisplayName("行业类型名称")]
        [Description("行业类型名称")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn("Name", "行业类型名称", "varchar(32)", Master = true)]
        public String Name { get => _name; set { if (OnPropertyChanging("Name", value)) { _name = value; OnPropertyChanged("Name"); } } }
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
                    case "Amount": return _Amount;
                    case "Code": return _Code;
                    case "Description": return _Description;
                    case "ParentCode": return _ParentCode;
                    case "Name": return _name;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = value.ToInt(); break;
                    case "Amount": _Amount = value.ToInt(); break;
                    case "Code": _Code = value.ToInt(); break;
                    case "Description": _Description = Convert.ToString(value); break;
                    case "ParentCode": _ParentCode = value.ToInt(); break;
                    case "Name": _name = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得行业类型字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>行业类型</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>数量</summary>
            public static readonly Field Amount = FindByName("Amount");

            /// <summary>编码</summary>
            public static readonly Field Code = FindByName("Code");

            /// <summary>描述</summary>
            public static readonly Field Description = FindByName("Description");

            /// <summary>上级编码</summary>
            public static readonly Field ParentCode = FindByName("ParentCode");

            /// <summary>行业类型</summary>
            public static readonly Field Name = FindByName("Name");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得行业类型字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>行业类型</summary>
            public const String ID = "ID";

            /// <summary>数量</summary>
            public const String Amount = "Amount";

            /// <summary>编码</summary>
            public const String Code = "Code";

            /// <summary>描述</summary>
            public const String Description = "Description";

            /// <summary>上级编码</summary>
            public const String ParentCode = "ParentCode";

            /// <summary>行业类型</summary>
            public const String Name = "Name";
        }
        #endregion
    }
}