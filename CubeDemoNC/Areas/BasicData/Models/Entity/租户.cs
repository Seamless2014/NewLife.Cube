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
    /// <summary>租户</summary>
    [Serializable]
    [DataObject]
    [Description("租户")]
    [BindTable("TenantUser", Description = "租户用户", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class TenantUser
    {
        #region 属性
        private Int32 _UserId;
        /// <summary>用户编码</summary>
        [DisplayName("用户编码")]
        [Description("用户编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("UserId", "用户编码", "int")]
        public Int32 UserId { get => _UserId; set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Name", "名称", "nvarchar(255)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _UserType;
        /// <summary>使用类型</summary>
        [DisplayName("使用类型")]
        [Description("使用类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("UserType", "使用类型", "nvarchar(255)")]
        public String UserType { get => _UserType; set { if (OnPropertyChanging("UserType", value)) { _UserType = value; OnPropertyChanged("UserType"); } } }

        private String _Job;
        /// <summary>职位</summary>
        [DisplayName("职位")]
        [Description("职位")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Job", "职位", "nvarchar(255)")]
        public String Job { get => _Job; set { if (OnPropertyChanging("Job", value)) { _Job = value; OnPropertyChanged("Job"); } } }

        private Int32 _DepartmentID;
        /// <summary>部门编码</summary>
        [DisplayName("部门编码")]
        [Description("部门编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("DepartmentID", "部门编码", "int")]
        public Int32 DepartmentID { get => _DepartmentID; set { if (OnPropertyChanging("DepartmentID", value)) { _DepartmentID = value; OnPropertyChanged("DepartmentID"); } } }

        private String _Phone;
        /// <summary>电话</summary>
        [DisplayName("电话")]
        [Description("电话")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Phone", "电话", "nvarchar(255)")]
        public String Phone { get => _Phone; set { if (OnPropertyChanging("Phone", value)) { _Phone = value; OnPropertyChanged("Phone"); } } }

        private String _Mail;
        /// <summary>EMail</summary>
        [DisplayName("EMail")]
        [Description("EMail")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Mail", "EMail", "nvarchar(255)")]
        public String Mail { get => _Mail; set { if (OnPropertyChanging("Mail", value)) { _Mail = value; OnPropertyChanged("Mail"); } } }

        private String _LoginName;
        /// <summary>登录名</summary>
        [DisplayName("登录名")]
        [Description("登录名")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("LoginName", "登录名", "nvarchar(255)")]
        public String LoginName { get => _LoginName; set { if (OnPropertyChanging("LoginName", value)) { _LoginName = value; OnPropertyChanged("LoginName"); } } }

        private String _Password;
        /// <summary>密码</summary>
        [DisplayName("密码")]
        [Description("密码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Password", "密码", "nvarchar(255)")]
        public String Password { get => _Password; set { if (OnPropertyChanging("Password", value)) { _Password = value; OnPropertyChanged("Password"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Boolean _Admin;
        /// <summary>是否管理员</summary>
        [DisplayName("是否管理员")]
        [Description("是否管理员")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Admin", "是否管理员", "bit")]
        public Boolean Admin { get => _Admin; set { if (OnPropertyChanging("Admin", value)) { _Admin = value; OnPropertyChanged("Admin"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
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
                    case "UserId": return _UserId;
                    case "TenantId": return _TenantId;
                    case "Name": return _Name;
                    case "UserType": return _UserType;
                    case "Job": return _Job;
                    case "DepartmentID": return _DepartmentID;
                    case "Phone": return _Phone;
                    case "Mail": return _Mail;
                    case "LoginName": return _LoginName;
                    case "Password": return _Password;
                    case "CreateTime": return _CreateTime;
                    case "Admin": return _Admin;
                    case "Deleted": return _Deleted;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "UserId": _UserId = value.ToInt(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "UserType": _UserType = Convert.ToString(value); break;
                    case "Job": _Job = Convert.ToString(value); break;
                    case "DepartmentID": _DepartmentID = value.ToInt(); break;
                    case "Phone": _Phone = Convert.ToString(value); break;
                    case "Mail": _Mail = Convert.ToString(value); break;
                    case "LoginName": _LoginName = Convert.ToString(value); break;
                    case "Password": _Password = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Admin": _Admin = value.ToBoolean(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得租户字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>用户编码</summary>
            public static readonly Field UserId = FindByName("UserId");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>使用类型</summary>
            public static readonly Field UserType = FindByName("UserType");

            /// <summary>职位</summary>
            public static readonly Field Job = FindByName("Job");

            /// <summary>部门编码</summary>
            public static readonly Field DepartmentID = FindByName("DepartmentID");

            /// <summary>电话</summary>
            public static readonly Field Phone = FindByName("Phone");

            /// <summary>EMail</summary>
            public static readonly Field Mail = FindByName("Mail");

            /// <summary>登录名</summary>
            public static readonly Field LoginName = FindByName("LoginName");

            /// <summary>密码</summary>
            public static readonly Field Password = FindByName("Password");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>是否管理员</summary>
            public static readonly Field Admin = FindByName("Admin");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得租户字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>用户编码</summary>
            public const String UserId = "UserId";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>使用类型</summary>
            public const String UserType = "UserType";

            /// <summary>职位</summary>
            public const String Job = "Job";

            /// <summary>部门编码</summary>
            public const String DepartmentID = "DepartmentID";

            /// <summary>电话</summary>
            public const String Phone = "Phone";

            /// <summary>EMail</summary>
            public const String Mail = "Mail";

            /// <summary>登录名</summary>
            public const String LoginName = "LoginName";

            /// <summary>密码</summary>
            public const String Password = "Password";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>是否管理员</summary>
            public const String Admin = "Admin";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";
        }
        #endregion
    }
}