﻿using System;
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
    /// <summary>报警源</summary>
    [Serializable]
    [DataObject]
    [Description("报警源")]
    [BindIndex("IU_AlarmSource_Name", true, "Name")]
    [BindTable("AlarmSource", Description = "报警源", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class AlarmSource
    {
        #region 属性
        private Int32 _ID;
        /// <summary>主键</summary>
        [DisplayName("主键")]
        [Description("主键")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "主键", "")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private String _Code;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn("Code", "编码", "")]
        public String Code { get => _Code; set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("Name", "名称", "", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private Boolean _Enable;
        /// <summary>启用</summary>
        [DisplayName("启用")]
        [Description("启用")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Enable", "启用", "")]
        public Boolean Enable { get => _Enable; set { if (OnPropertyChanging("Enable", value)) { _Enable = value; OnPropertyChanged("Enable"); } } }

        private DateTime _CreateDate;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("CreateDate", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateDate { get => _CreateDate; set { if (OnPropertyChanging("CreateDate", value)) { _CreateDate = value; OnPropertyChanged("CreateDate"); } } }

        private Int32 _CreateUserId;
        /// <summary>更新人</summary>
        [DisplayName("更新人")]
        [Description("更新人")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateUserId", "更新人", "")]
        public Int32 CreateUserId { get => _CreateUserId; set { if (OnPropertyChanging("CreateUserId", value)) { _CreateUserId = value; OnPropertyChanged("CreateUserId"); } } }

        private DateTime _UpdateDate;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("UpdateDate", "更新时间", "", Precision = 0, Scale = 3)]
        public DateTime UpdateDate { get => _UpdateDate; set { if (OnPropertyChanging("UpdateDate", value)) { _UpdateDate = value; OnPropertyChanged("UpdateDate"); } } }

        private Int32 _UpdateUserId;
        /// <summary>更新人</summary>
        [DisplayName("更新人")]
        [Description("更新人")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("UpdateUserId", "更新人", "")]
        public Int32 UpdateUserId { get => _UpdateUserId; set { if (OnPropertyChanging("UpdateUserId", value)) { _UpdateUserId = value; OnPropertyChanged("UpdateUserId"); } } }
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
                    case "Code": return _Code;
                    case "Name": return _Name;
                    case "Enable": return _Enable;
                    case "CreateDate": return _CreateDate;
                    case "CreateUserId": return _CreateUserId;
                    case "UpdateDate": return _UpdateDate;
                    case "UpdateUserId": return _UpdateUserId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = value.ToInt(); break;
                    case "Code": _Code = Convert.ToString(value); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Enable": _Enable = value.ToBoolean(); break;
                    case "CreateDate": _CreateDate = value.ToDateTime(); break;
                    case "CreateUserId": _CreateUserId = value.ToInt(); break;
                    case "UpdateDate": _UpdateDate = value.ToDateTime(); break;
                    case "UpdateUserId": _UpdateUserId = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得报警源字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>主键</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>编码</summary>
            public static readonly Field Code = FindByName("Code");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>启用</summary>
            public static readonly Field Enable = FindByName("Enable");

            /// <summary>创建时间</summary>
            public static readonly Field CreateDate = FindByName("CreateDate");

            /// <summary>更新人</summary>
            public static readonly Field CreateUserId = FindByName("CreateUserId");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateDate = FindByName("UpdateDate");

            /// <summary>更新人</summary>
            public static readonly Field UpdateUserId = FindByName("UpdateUserId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得报警源字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>主键</summary>
            public const String ID = "ID";

            /// <summary>编码</summary>
            public const String Code = "Code";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>启用</summary>
            public const String Enable = "Enable";

            /// <summary>创建时间</summary>
            public const String CreateDate = "CreateDate";

            /// <summary>更新人</summary>
            public const String CreateUserId = "CreateUserId";

            /// <summary>更新时间</summary>
            public const String UpdateDate = "UpdateDate";

            /// <summary>更新人</summary>
            public const String UpdateUserId = "UpdateUserId";
        }
        #endregion
    }
}