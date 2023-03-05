using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace GPSPlatform.BasicData.Entity
{
    /// <summary>用户部门</summary>
    [Serializable]
    [DataObject]
    [Description("用户部门")]
    [BindIndex("PK_GossUserVehicleGroup", true, "UserId,DepId")]
    [BindTable("UserDepartment", Description = "用户部门", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class UserDepartment
    {
        #region 属性
        private Int32 _UserId;
        /// <summary>用户编码</summary>
        [DisplayName("用户编码")]
        [Description("用户编码")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("UserId", "用户编码", "int")]
        public Int32 UserId { get => _UserId; set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } } }

        private Int32 _DepId;
        /// <summary>部门编码</summary>
        [DisplayName("部门编码")]
        [Description("部门编码")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("DepId", "部门编码", "int")]
        public Int32 DepId { get => _DepId; set { if (OnPropertyChanging("DepId", value)) { _DepId = value; OnPropertyChanged("DepId"); } } }
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
                    case "UserId": return _UserId;
                    case "DepId": return _DepId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "UserId": _UserId = value.ToInt(); break;
                    case "DepId": _DepId = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得用户部门字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>用户编码</summary>
            public static readonly Field UserId = FindByName("UserId");

            /// <summary>部门编码</summary>
            public static readonly Field DepId = FindByName("DepId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得用户部门字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>用户编码</summary>
            public const String UserId = "UserId";

            /// <summary>部门编码</summary>
            public const String DepId = "DepId";
        }
        #endregion
    }
}