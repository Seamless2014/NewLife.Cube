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
    /// <summary>角色功能</summary>
    [Serializable]
    [DataObject]
    [Description("角色功能")]
    [BindIndex("PK_GossRoleSysFunc", true, "Role_Id,sys_func_id")]
    [BindTable("RoleFunc", Description = "角色功能", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class RoleFunc
    {
        #region 属性
        private Int32 _RoleId;
        /// <summary>角色编码</summary>
        [DisplayName("角色编码")]
        [Description("角色编码")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("Role_Id", "角色编码", "int")]
        public Int32 RoleId { get => _RoleId; set { if (OnPropertyChanging("RoleId", value)) { _RoleId = value; OnPropertyChanged("RoleId"); } } }

        private Int32 _SysFuncId;
        /// <summary>功能编码</summary>
        [DisplayName("功能编码")]
        [Description("功能编码")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("sys_func_id", "功能编码", "int")]
        public Int32 SysFuncId { get => _SysFuncId; set { if (OnPropertyChanging("SysFuncId", value)) { _SysFuncId = value; OnPropertyChanged("SysFuncId"); } } }
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
                    case "RoleId": return _RoleId;
                    case "SysFuncId": return _SysFuncId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "RoleId": _RoleId = value.ToInt(); break;
                    case "SysFuncId": _SysFuncId = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得角色功能字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>角色编码</summary>
            public static readonly Field RoleId = FindByName("RoleId");

            /// <summary>功能编码</summary>
            public static readonly Field SysFuncId = FindByName("SysFuncId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得角色功能字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>角色编码</summary>
            public const String RoleId = "RoleId";

            /// <summary>功能编码</summary>
            public const String SysFuncId = "SysFuncId";
        }
        #endregion
    }
}