using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace GPSPlatform.BackManagement.Entity
{
    /// <summary>部门。组织机构，多级树状结构</summary>
    [Serializable]
    [DataObject]
    [Description("部门。组织机构，多级树状结构")]
    [BindTable("Department", Description = "部门。组织机构，多级树状结构", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class Department
    {
        #region 属性
        private Int32 _DepId;
        /// <summary>部门编码</summary>
        [DisplayName("部门编码")]
        [Description("部门编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("DepId", "部门编码", "int")]
        public Int32 DepId { get => _DepId; set { if (OnPropertyChanging("DepId", value)) { _DepId = value; OnPropertyChanged("DepId"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Remark", "备注", "nvarchar(255)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private String _Type;
        /// <summary>类型</summary>
        [DisplayName("类型")]
        [Description("类型")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Type", "类型", "nvarchar(50)")]
        public String Type { get => _Type; set { if (OnPropertyChanging("Type", value)) { _Type = value; OnPropertyChanged("Type"); } } }

        private String _MemberNo;
        /// <summary>会员编号</summary>
        [DisplayName("会员编号")]
        [Description("会员编号")]
        [DataObjectField(false, false, true, 16)]
        [BindColumn("MemberNo", "会员编号", "nvarchar(16)")]
        public String MemberNo { get => _MemberNo; set { if (OnPropertyChanging("MemberNo", value)) { _MemberNo = value; OnPropertyChanged("MemberNo"); } } }

        private String _AssoMan;
        /// <summary>联系人</summary>
        [DisplayName("联系人")]
        [Description("联系人")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("AssoMan", "联系人", "varchar(255)")]
        public String AssoMan { get => _AssoMan; set { if (OnPropertyChanging("AssoMan", value)) { _AssoMan = value; OnPropertyChanged("AssoMan"); } } }

        private String _AssoTel;
        /// <summary>联系电话</summary>
        [DisplayName("联系电话")]
        [Description("联系电话")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("AssoTel", "联系电话", "varchar(255)")]
        public String AssoTel { get => _AssoTel; set { if (OnPropertyChanging("AssoTel", value)) { _AssoTel = value; OnPropertyChanged("AssoTel"); } } }

        private String _BusinessScope;
        /// <summary>业务范围</summary>
        [DisplayName("业务范围")]
        [Description("业务范围")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("BusinessScope", "业务范围", "varchar(255)")]
        public String BusinessScope { get => _BusinessScope; set { if (OnPropertyChanging("BusinessScope", value)) { _BusinessScope = value; OnPropertyChanged("BusinessScope"); } } }

        private String _Region;
        /// <summary>区域</summary>
        [DisplayName("区域")]
        [Description("区域")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Region", "区域", "nvarchar(50)")]
        public String Region { get => _Region; set { if (OnPropertyChanging("Region", value)) { _Region = value; OnPropertyChanged("Region"); } } }

        private String _RoadPermitNo;
        /// <summary>道路许可证编码</summary>
        [DisplayName("道路许可证编码")]
        [Description("道路许可证编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("RoadPermitNo", "道路许可证编码", "varchar(255)")]
        public String RoadPermitNo { get => _RoadPermitNo; set { if (OnPropertyChanging("RoadPermitNo", value)) { _RoadPermitNo = value; OnPropertyChanged("RoadPermitNo"); } } }

        private String _RoadPermitWord;
        /// <summary>道路许可字</summary>
        [DisplayName("道路许可字")]
        [Description("道路许可字")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("RoadPermitWord", "道路许可字", "varchar(255)")]
        public String RoadPermitWord { get => _RoadPermitWord; set { if (OnPropertyChanging("RoadPermitWord", value)) { _RoadPermitWord = value; OnPropertyChanged("RoadPermitWord"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateTime", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private Int32 _ParentId;
        /// <summary>上级编码</summary>
        [DisplayName("上级编码")]
        [Description("上级编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("ParentId", "上级编码", "int")]
        public Int32 ParentId { get => _ParentId; set { if (OnPropertyChanging("ParentId", value)) { _ParentId = value; OnPropertyChanged("ParentId"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Name", "名称", "nvarchar(50)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "物主", "nvarchar(50)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Memo;
        /// <summary>备忘录</summary>
        [DisplayName("备忘录")]
        [Description("备忘录")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Memo", "备忘录", "nvarchar(255)")]
        public String Memo { get => _Memo; set { if (OnPropertyChanging("Memo", value)) { _Memo = value; OnPropertyChanged("Memo"); } } }

        private String _Category;
        /// <summary>类别</summary>
        [DisplayName("类别")]
        [Description("类别")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Category", "类别", "nvarchar(255)")]
        public String Category { get => _Category; set { if (OnPropertyChanging("Category", value)) { _Category = value; OnPropertyChanged("Category"); } } }

        private String _Code;
        /// <summary>代码</summary>
        [DisplayName("代码")]
        [Description("代码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Code", "代码", "nvarchar(50)")]
        public String Code { get => _Code; set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } } }

        private String _FullName;
        /// <summary>全名</summary>
        [DisplayName("全名")]
        [Description("全名")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn("FullName", "全名", "nvarchar(200)")]
        public String FullName { get => _FullName; set { if (OnPropertyChanging("FullName", value)) { _FullName = value; OnPropertyChanged("FullName"); } } }

        private Int32 _Level;
        /// <summary>层级。树状结构的层级</summary>
        [DisplayName("层级")]
        [Description("层级。树状结构的层级")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Level", "层级。树状结构的层级", "int")]
        public Int32 Level { get => _Level; set { if (OnPropertyChanging("Level", value)) { _Level = value; OnPropertyChanged("Level"); } } }

        private Int32 _Sort;
        /// <summary>排序。同级内排序</summary>
        [DisplayName("排序")]
        [Description("排序。同级内排序")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Sort", "排序。同级内排序", "int")]
        public Int32 Sort { get => _Sort; set { if (OnPropertyChanging("Sort", value)) { _Sort = value; OnPropertyChanged("Sort"); } } }

        private Boolean _Enable;
        /// <summary>启用</summary>
        [DisplayName("启用")]
        [Description("启用")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Enable", "启用", "bit")]
        public Boolean Enable { get => _Enable; set { if (OnPropertyChanging("Enable", value)) { _Enable = value; OnPropertyChanged("Enable"); } } }

        private Boolean _Visible;
        /// <summary>可见</summary>
        [DisplayName("可见")]
        [Description("可见")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Visible", "可见", "bit")]
        public Boolean Visible { get => _Visible; set { if (OnPropertyChanging("Visible", value)) { _Visible = value; OnPropertyChanged("Visible"); } } }

        private Int32 _ManagerID;
        /// <summary>管理者编码</summary>
        [DisplayName("管理者编码")]
        [Description("管理者编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("ManagerID", "管理者编码", "int")]
        public Int32 ManagerID { get => _ManagerID; set { if (OnPropertyChanging("ManagerID", value)) { _ManagerID = value; OnPropertyChanged("ManagerID"); } } }

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
                    case "DepId": return _DepId;
                    case "Remark": return _Remark;
                    case "Type": return _Type;
                    case "MemberNo": return _MemberNo;
                    case "AssoMan": return _AssoMan;
                    case "AssoTel": return _AssoTel;
                    case "BusinessScope": return _BusinessScope;
                    case "Region": return _Region;
                    case "RoadPermitNo": return _RoadPermitNo;
                    case "RoadPermitWord": return _RoadPermitWord;
                    case "UpdateTime": return _UpdateTime;
                    case "ParentId": return _ParentId;
                    case "Name": return _Name;
                    case "Deleted": return _Deleted;
                    case "TenantId": return _TenantId;
                    case "Owner": return _Owner;
                    case "Memo": return _Memo;
                    case "Category": return _Category;
                    case "Code": return _Code;
                    case "FullName": return _FullName;
                    case "Level": return _Level;
                    case "Sort": return _Sort;
                    case "Enable": return _Enable;
                    case "Visible": return _Visible;
                    case "ManagerID": return _ManagerID;
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
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "DepId": _DepId = value.ToInt(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Type": _Type = Convert.ToString(value); break;
                    case "MemberNo": _MemberNo = Convert.ToString(value); break;
                    case "AssoMan": _AssoMan = Convert.ToString(value); break;
                    case "AssoTel": _AssoTel = Convert.ToString(value); break;
                    case "BusinessScope": _BusinessScope = Convert.ToString(value); break;
                    case "Region": _Region = Convert.ToString(value); break;
                    case "RoadPermitNo": _RoadPermitNo = Convert.ToString(value); break;
                    case "RoadPermitWord": _RoadPermitWord = Convert.ToString(value); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    case "ParentId": _ParentId = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Memo": _Memo = Convert.ToString(value); break;
                    case "Category": _Category = Convert.ToString(value); break;
                    case "Code": _Code = Convert.ToString(value); break;
                    case "FullName": _FullName = Convert.ToString(value); break;
                    case "Level": _Level = value.ToInt(); break;
                    case "Sort": _Sort = value.ToInt(); break;
                    case "Enable": _Enable = value.ToBoolean(); break;
                    case "Visible": _Visible = value.ToBoolean(); break;
                    case "ManagerID": _ManagerID = value.ToInt(); break;
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
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得部门字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>部门编码</summary>
            public static readonly Field DepId = FindByName("DepId");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>类型</summary>
            public static readonly Field Type = FindByName("Type");

            /// <summary>会员编号</summary>
            public static readonly Field MemberNo = FindByName("MemberNo");

            /// <summary>联系人</summary>
            public static readonly Field AssoMan = FindByName("AssoMan");

            /// <summary>联系电话</summary>
            public static readonly Field AssoTel = FindByName("AssoTel");

            /// <summary>业务范围</summary>
            public static readonly Field BusinessScope = FindByName("BusinessScope");

            /// <summary>区域</summary>
            public static readonly Field Region = FindByName("Region");

            /// <summary>道路许可证编码</summary>
            public static readonly Field RoadPermitNo = FindByName("RoadPermitNo");

            /// <summary>道路许可字</summary>
            public static readonly Field RoadPermitWord = FindByName("RoadPermitWord");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            /// <summary>上级编码</summary>
            public static readonly Field ParentId = FindByName("ParentId");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>备忘录</summary>
            public static readonly Field Memo = FindByName("Memo");

            /// <summary>类别</summary>
            public static readonly Field Category = FindByName("Category");

            /// <summary>代码</summary>
            public static readonly Field Code = FindByName("Code");

            /// <summary>全名</summary>
            public static readonly Field FullName = FindByName("FullName");

            /// <summary>层级。树状结构的层级</summary>
            public static readonly Field Level = FindByName("Level");

            /// <summary>排序。同级内排序</summary>
            public static readonly Field Sort = FindByName("Sort");

            /// <summary>启用</summary>
            public static readonly Field Enable = FindByName("Enable");

            /// <summary>可见</summary>
            public static readonly Field Visible = FindByName("Visible");

            /// <summary>管理者编码</summary>
            public static readonly Field ManagerID = FindByName("ManagerID");

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

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得部门字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>部门编码</summary>
            public const String DepId = "DepId";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>类型</summary>
            public const String Type = "Type";

            /// <summary>会员编号</summary>
            public const String MemberNo = "MemberNo";

            /// <summary>联系人</summary>
            public const String AssoMan = "AssoMan";

            /// <summary>联系电话</summary>
            public const String AssoTel = "AssoTel";

            /// <summary>业务范围</summary>
            public const String BusinessScope = "BusinessScope";

            /// <summary>区域</summary>
            public const String Region = "Region";

            /// <summary>道路许可证编码</summary>
            public const String RoadPermitNo = "RoadPermitNo";

            /// <summary>道路许可字</summary>
            public const String RoadPermitWord = "RoadPermitWord";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            /// <summary>上级编码</summary>
            public const String ParentId = "ParentId";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>备忘录</summary>
            public const String Memo = "Memo";

            /// <summary>类别</summary>
            public const String Category = "Category";

            /// <summary>代码</summary>
            public const String Code = "Code";

            /// <summary>全名</summary>
            public const String FullName = "FullName";

            /// <summary>层级。树状结构的层级</summary>
            public const String Level = "Level";

            /// <summary>排序。同级内排序</summary>
            public const String Sort = "Sort";

            /// <summary>启用</summary>
            public const String Enable = "Enable";

            /// <summary>可见</summary>
            public const String Visible = "Visible";

            /// <summary>管理者编码</summary>
            public const String ManagerID = "ManagerID";

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
        }
        #endregion
    }
}