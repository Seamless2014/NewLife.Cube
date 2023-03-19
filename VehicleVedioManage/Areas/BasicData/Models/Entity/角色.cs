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
    /// <summary>角色</summary>
    [Serializable]
    [DataObject]
    [Description("角色")]
    [BindTable("Role", Description = "角色", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class Role
    {
        #region 属性
        private Int32 _roleId;
        /// <summary></summary>
        [DisplayName("roleId")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("roleId", "", "int")]
        public Int32 roleId { get => _roleId; set { if (OnPropertyChanging("roleId", value)) { _roleId = value; OnPropertyChanged("roleId"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 64)]
        [BindColumn("name", "名称", "varchar(64)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private Int32 _Status;
        /// <summary></summary>
        [DisplayName("Status")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("status", "", "int")]
        public Int32 Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private Boolean _Deleted;
        /// <summary></summary>
        [DisplayName("Deleted")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("deleted", "", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private DateTime _createDate;
        /// <summary></summary>
        [DisplayName("createDate")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("createDate", "", "datetime", Precision = 0, Scale = 3)]
        public DateTime createDate { get => _createDate; set { if (OnPropertyChanging("createDate", value)) { _createDate = value; OnPropertyChanged("createDate"); } } }

        private String _Owner;
        /// <summary></summary>
        [DisplayName("Owner")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("owner", "", "nvarchar(50)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("remark", "备注", "nvarchar(50)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Int32 _tenantId;
        /// <summary></summary>
        [DisplayName("tenantId")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("tenantId", "", "int")]
        public Int32 tenantId { get => _tenantId; set { if (OnPropertyChanging("tenantId", value)) { _tenantId = value; OnPropertyChanged("tenantId"); } } }

        private String _Code;
        /// <summary></summary>
        [DisplayName("Code")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("code", "", "nvarchar(50)")]
        public String Code { get => _Code; set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } } }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Description", "", "nvarchar(255)")]
        public String Description { get => _Description; set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } } }

        private Boolean _Enable;
        /// <summary>启用</summary>
        [DisplayName("启用")]
        [Description("启用")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Enable", "启用", "bit")]
        public Boolean Enable { get => _Enable; set { if (OnPropertyChanging("Enable", value)) { _Enable = value; OnPropertyChanged("Enable"); } } }

        private Boolean _IsSystem;
        /// <summary>系统。用于业务系统开发使用，不受数据权限约束，禁止修改名称或删除</summary>
        [DisplayName("系统")]
        [Description("系统。用于业务系统开发使用，不受数据权限约束，禁止修改名称或删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("IsSystem", "系统。用于业务系统开发使用，不受数据权限约束，禁止修改名称或删除", "bit")]
        public Boolean IsSystem { get => _IsSystem; set { if (OnPropertyChanging("IsSystem", value)) { _IsSystem = value; OnPropertyChanged("IsSystem"); } } }

        private String _Permission;
        /// <summary>权限。对不同资源的权限，逗号分隔，每个资源的权限子项竖线分隔</summary>
        [DisplayName("权限")]
        [Description("权限。对不同资源的权限，逗号分隔，每个资源的权限子项竖线分隔")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn("Permission", "权限。对不同资源的权限，逗号分隔，每个资源的权限子项竖线分隔", "ntext")]
        public String Permission { get => _Permission; set { if (OnPropertyChanging("Permission", value)) { _Permission = value; OnPropertyChanged("Permission"); } } }

        private Int32 _Ex1;
        /// <summary>扩展1</summary>
        [DisplayName("扩展1")]
        [Description("扩展1")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Ex1", "扩展1", "int")]
        public Int32 Ex1 { get => _Ex1; set { if (OnPropertyChanging("Ex1", value)) { _Ex1 = value; OnPropertyChanged("Ex1"); } } }

        private Int32 _Ex2;
        /// <summary>扩展2</summary>
        [DisplayName("扩展2")]
        [Description("扩展2")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Ex2", "扩展2", "int")]
        public Int32 Ex2 { get => _Ex2; set { if (OnPropertyChanging("Ex2", value)) { _Ex2 = value; OnPropertyChanged("Ex2"); } } }

        private Double _Ex3;
        /// <summary>扩展3</summary>
        [DisplayName("扩展3")]
        [Description("扩展3")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Ex3", "扩展3", "float")]
        public Double Ex3 { get => _Ex3; set { if (OnPropertyChanging("Ex3", value)) { _Ex3 = value; OnPropertyChanged("Ex3"); } } }

        private String _Ex4;
        /// <summary>扩展4</summary>
        [DisplayName("扩展4")]
        [Description("扩展4")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Ex4", "扩展4", "nvarchar(50)")]
        public String Ex4 { get => _Ex4; set { if (OnPropertyChanging("Ex4", value)) { _Ex4 = value; OnPropertyChanged("Ex4"); } } }

        private String _Ex5;
        /// <summary>扩展5</summary>
        [DisplayName("扩展5")]
        [Description("扩展5")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Ex5", "扩展5", "nvarchar(50)")]
        public String Ex5 { get => _Ex5; set { if (OnPropertyChanging("Ex5", value)) { _Ex5 = value; OnPropertyChanged("Ex5"); } } }

        private String _Ex6;
        /// <summary>扩展6</summary>
        [DisplayName("扩展6")]
        [Description("扩展6")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Ex6", "扩展6", "nvarchar(50)")]
        public String Ex6 { get => _Ex6; set { if (OnPropertyChanging("Ex6", value)) { _Ex6 = value; OnPropertyChanged("Ex6"); } } }

        private String _CreateUser;
        /// <summary>创建者</summary>
        [DisplayName("创建者")]
        [Description("创建者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateUser", "创建者", "nvarchar(50)")]
        public String CreateUser { get => _CreateUser; set { if (OnPropertyChanging("CreateUser", value)) { _CreateUser = value; OnPropertyChanged("CreateUser"); } } }

        private Int32 _CreateUserID;
        /// <summary>创建用户</summary>
        [DisplayName("创建用户")]
        [Description("创建用户")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("CreateUserID", "创建用户", "int")]
        public Int32 CreateUserID { get => _CreateUserID; set { if (OnPropertyChanging("CreateUserID", value)) { _CreateUserID = value; OnPropertyChanged("CreateUserID"); } } }

        private String _CreateIP;
        /// <summary>创建地址</summary>
        [DisplayName("创建地址")]
        [Description("创建地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateIP", "创建地址", "nvarchar(50)")]
        public String CreateIP { get => _CreateIP; set { if (OnPropertyChanging("CreateIP", value)) { _CreateIP = value; OnPropertyChanged("CreateIP"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _UpdateUser;
        /// <summary>更新者</summary>
        [DisplayName("更新者")]
        [Description("更新者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateUser", "更新者", "nvarchar(50)")]
        public String UpdateUser { get => _UpdateUser; set { if (OnPropertyChanging("UpdateUser", value)) { _UpdateUser = value; OnPropertyChanged("UpdateUser"); } } }

        private Int32 _UpdateUserID;
        /// <summary>更新用户</summary>
        [DisplayName("更新用户")]
        [Description("更新用户")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("UpdateUserID", "更新用户", "int")]
        public Int32 UpdateUserID { get => _UpdateUserID; set { if (OnPropertyChanging("UpdateUserID", value)) { _UpdateUserID = value; OnPropertyChanged("UpdateUserID"); } } }

        private String _UpdateIP;
        /// <summary>更新地址</summary>
        [DisplayName("更新地址")]
        [Description("更新地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateIP", "更新地址", "nvarchar(50)")]
        public String UpdateIP { get => _UpdateIP; set { if (OnPropertyChanging("UpdateIP", value)) { _UpdateIP = value; OnPropertyChanged("UpdateIP"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateTime", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }
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
                    case "roleId": return _roleId;
                    case "Name": return _Name;
                    case "Status": return _Status;
                    case "Deleted": return _Deleted;
                    case "createDate": return _createDate;
                    case "Owner": return _Owner;
                    case "Remark": return _Remark;
                    case "tenantId": return _tenantId;
                    case "Code": return _Code;
                    case "Description": return _Description;
                    case "Enable": return _Enable;
                    case "IsSystem": return _IsSystem;
                    case "Permission": return _Permission;
                    case "Ex1": return _Ex1;
                    case "Ex2": return _Ex2;
                    case "Ex3": return _Ex3;
                    case "Ex4": return _Ex4;
                    case "Ex5": return _Ex5;
                    case "Ex6": return _Ex6;
                    case "CreateUser": return _CreateUser;
                    case "CreateUserID": return _CreateUserID;
                    case "CreateIP": return _CreateIP;
                    case "CreateTime": return _CreateTime;
                    case "UpdateUser": return _UpdateUser;
                    case "UpdateUserID": return _UpdateUserID;
                    case "UpdateIP": return _UpdateIP;
                    case "UpdateTime": return _UpdateTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "roleId": _roleId = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Status": _Status = value.ToInt(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "createDate": _createDate = value.ToDateTime(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "tenantId": _tenantId = value.ToInt(); break;
                    case "Code": _Code = Convert.ToString(value); break;
                    case "Description": _Description = Convert.ToString(value); break;
                    case "Enable": _Enable = value.ToBoolean(); break;
                    case "IsSystem": _IsSystem = value.ToBoolean(); break;
                    case "Permission": _Permission = Convert.ToString(value); break;
                    case "Ex1": _Ex1 = value.ToInt(); break;
                    case "Ex2": _Ex2 = value.ToInt(); break;
                    case "Ex3": _Ex3 = value.ToDouble(); break;
                    case "Ex4": _Ex4 = Convert.ToString(value); break;
                    case "Ex5": _Ex5 = Convert.ToString(value); break;
                    case "Ex6": _Ex6 = Convert.ToString(value); break;
                    case "CreateUser": _CreateUser = Convert.ToString(value); break;
                    case "CreateUserID": _CreateUserID = value.ToInt(); break;
                    case "CreateIP": _CreateIP = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "UpdateUser": _UpdateUser = Convert.ToString(value); break;
                    case "UpdateUserID": _UpdateUserID = value.ToInt(); break;
                    case "UpdateIP": _UpdateIP = Convert.ToString(value); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得角色字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field roleId = FindByName("roleId");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary></summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary></summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary></summary>
            public static readonly Field createDate = FindByName("createDate");

            /// <summary></summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary></summary>
            public static readonly Field tenantId = FindByName("tenantId");

            /// <summary></summary>
            public static readonly Field Code = FindByName("Code");

            /// <summary></summary>
            public static readonly Field Description = FindByName("Description");

            /// <summary>启用</summary>
            public static readonly Field Enable = FindByName("Enable");

            /// <summary>系统。用于业务系统开发使用，不受数据权限约束，禁止修改名称或删除</summary>
            public static readonly Field IsSystem = FindByName("IsSystem");

            /// <summary>权限。对不同资源的权限，逗号分隔，每个资源的权限子项竖线分隔</summary>
            public static readonly Field Permission = FindByName("Permission");

            /// <summary>扩展1</summary>
            public static readonly Field Ex1 = FindByName("Ex1");

            /// <summary>扩展2</summary>
            public static readonly Field Ex2 = FindByName("Ex2");

            /// <summary>扩展3</summary>
            public static readonly Field Ex3 = FindByName("Ex3");

            /// <summary>扩展4</summary>
            public static readonly Field Ex4 = FindByName("Ex4");

            /// <summary>扩展5</summary>
            public static readonly Field Ex5 = FindByName("Ex5");

            /// <summary>扩展6</summary>
            public static readonly Field Ex6 = FindByName("Ex6");

            /// <summary>创建者</summary>
            public static readonly Field CreateUser = FindByName("CreateUser");

            /// <summary>创建用户</summary>
            public static readonly Field CreateUserID = FindByName("CreateUserID");

            /// <summary>创建地址</summary>
            public static readonly Field CreateIP = FindByName("CreateIP");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>更新者</summary>
            public static readonly Field UpdateUser = FindByName("UpdateUser");

            /// <summary>更新用户</summary>
            public static readonly Field UpdateUserID = FindByName("UpdateUserID");

            /// <summary>更新地址</summary>
            public static readonly Field UpdateIP = FindByName("UpdateIP");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得角色字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String roleId = "roleId";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary></summary>
            public const String Status = "Status";

            /// <summary></summary>
            public const String Deleted = "Deleted";

            /// <summary></summary>
            public const String createDate = "createDate";

            /// <summary></summary>
            public const String Owner = "Owner";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary></summary>
            public const String tenantId = "tenantId";

            /// <summary></summary>
            public const String Code = "Code";

            /// <summary></summary>
            public const String Description = "Description";

            /// <summary>启用</summary>
            public const String Enable = "Enable";

            /// <summary>系统。用于业务系统开发使用，不受数据权限约束，禁止修改名称或删除</summary>
            public const String IsSystem = "IsSystem";

            /// <summary>权限。对不同资源的权限，逗号分隔，每个资源的权限子项竖线分隔</summary>
            public const String Permission = "Permission";

            /// <summary>扩展1</summary>
            public const String Ex1 = "Ex1";

            /// <summary>扩展2</summary>
            public const String Ex2 = "Ex2";

            /// <summary>扩展3</summary>
            public const String Ex3 = "Ex3";

            /// <summary>扩展4</summary>
            public const String Ex4 = "Ex4";

            /// <summary>扩展5</summary>
            public const String Ex5 = "Ex5";

            /// <summary>扩展6</summary>
            public const String Ex6 = "Ex6";

            /// <summary>创建者</summary>
            public const String CreateUser = "CreateUser";

            /// <summary>创建用户</summary>
            public const String CreateUserID = "CreateUserID";

            /// <summary>创建地址</summary>
            public const String CreateIP = "CreateIP";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>更新者</summary>
            public const String UpdateUser = "UpdateUser";

            /// <summary>更新用户</summary>
            public const String UpdateUserID = "UpdateUserID";

            /// <summary>更新地址</summary>
            public const String UpdateIP = "UpdateIP";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";
        }
        #endregion
    }
}