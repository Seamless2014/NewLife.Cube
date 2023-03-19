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
    /// <summary>用户角色</summary>
    [Serializable]
    [DataObject]
    [Description("用户角色")]
    [BindIndex("PK_GossUserRole", true, "userId,roleId")]
    [BindTable("UserRole", Description = "用户角色", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class UserRole
    {
        #region 属性
        private Int32 _userId;
        /// <summary></summary>
        [DisplayName("userId")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("userId", "", "int")]
        public Int32 userId { get => _userId; set { if (OnPropertyChanging("userId", value)) { _userId = value; OnPropertyChanged("userId"); } } }

        private Int32 _roleId;
        /// <summary></summary>
        [DisplayName("roleId")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("roleId", "", "int")]
        public Int32 roleId { get => _roleId; set { if (OnPropertyChanging("roleId", value)) { _roleId = value; OnPropertyChanged("roleId"); } } }
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
                    case "userId": return _userId;
                    case "roleId": return _roleId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "userId": _userId = value.ToInt(); break;
                    case "roleId": _roleId = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得用户角色字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field userId = FindByName("userId");

            /// <summary></summary>
            public static readonly Field roleId = FindByName("roleId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得用户角色字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String userId = "userId";

            /// <summary></summary>
            public const String roleId = "roleId";
        }
        #endregion
    }
}