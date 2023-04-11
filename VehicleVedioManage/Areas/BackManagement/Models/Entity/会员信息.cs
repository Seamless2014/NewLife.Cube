using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.BackManagement.Entity
{
    /// <summary>会员信息</summary>
    [Serializable]
    [DataObject]
    [Description("会员信息")]
    [BindTable("MemberInfo", Description = "会员信息", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class MemberInfo
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("Id", "编号", "int")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private String _MemberNo;
        /// <summary>会员编码</summary>
        [DisplayName("会员编码")]
        [Description("会员编码")]
        [DataObjectField(false, false, true, 16)]
        [BindColumn("MemberNo", "会员编码", "nvarchar(16)")]
        public String MemberNo { get => _MemberNo; set { if (OnPropertyChanging("MemberNo", value)) { _MemberNo = value; OnPropertyChanged("MemberNo"); } } }

        private Int16 _MemberType;
        /// <summary>会员类型</summary>
        [DisplayName("会员类型")]
        [Description("会员类型")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn("MemberType", "会员类型", "smallint")]
        public Int16 MemberType { get => _MemberType; set { if (OnPropertyChanging("MemberType", value)) { _MemberType = value; OnPropertyChanged("MemberType"); } } }

        private String _MemberFormNo;
        /// <summary>会员表单编号</summary>
        [DisplayName("会员表单编号")]
        [Description("会员表单编号")]
        [DataObjectField(false, false, true, 16)]
        [BindColumn("MemberFormNo", "会员表单编号", "nvarchar(16)")]
        public String MemberFormNo { get => _MemberFormNo; set { if (OnPropertyChanging("MemberFormNo", value)) { _MemberFormNo = value; OnPropertyChanged("MemberFormNo"); } } }

        private DateTime _MemberTime;
        /// <summary>会员时间</summary>
        [DisplayName("会员时间")]
        [Description("会员时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("MemberTime", "会员时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime MemberTime { get => _MemberTime; set { if (OnPropertyChanging("MemberTime", value)) { _MemberTime = value; OnPropertyChanged("MemberTime"); } } }

        private String _Address;
        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, true, 16)]
        [BindColumn("Address", "地址", "nvarchar(16)")]
        public String Address { get => _Address; set { if (OnPropertyChanging("Address", value)) { _Address = value; OnPropertyChanged("Address"); } } }

        private String _LicenseNo;
        /// <summary>许可编码(许可证)</summary>
        [DisplayName("许可编码")]
        [Description("许可编码(许可证)")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("LicenseNo", "许可编码(许可证)", "nvarchar(30)")]
        public String LicenseNo { get => _LicenseNo; set { if (OnPropertyChanging("LicenseNo", value)) { _LicenseNo = value; OnPropertyChanged("LicenseNo"); } } }

        private String _OrgNo;
        /// <summary>组织编码</summary>
        [DisplayName("组织编码")]
        [Description("组织编码")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("OrgNo", "组织编码", "nvarchar(30)")]
        public String OrgNo { get => _OrgNo; set { if (OnPropertyChanging("OrgNo", value)) { _OrgNo = value; OnPropertyChanged("OrgNo"); } } }

        private String _ContactPhone;
        /// <summary>联系电话</summary>
        [DisplayName("联系电话")]
        [Description("联系电话")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("ContactPhone", "联系电话", "nvarchar(30)")]
        public String ContactPhone { get => _ContactPhone; set { if (OnPropertyChanging("ContactPhone", value)) { _ContactPhone = value; OnPropertyChanged("ContactPhone"); } } }

        private String _Contact;
        /// <summary>联系人</summary>
        [DisplayName("联系人")]
        [Description("联系人")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Contact", "联系人", "nvarchar(50)")]
        public String Contact { get => _Contact; set { if (OnPropertyChanging("Contact", value)) { _Contact = value; OnPropertyChanged("Contact"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [Category("扩展信息")]
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "物主", "nvarchar(50)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [Category("扩展信息")]
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("扩展信息")]
        [DisplayName("启用")]
        [Description("启用")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "启用", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _BankCode;
        /// <summary>银行代码</summary>
        [Category("扩展信息")]
        [DisplayName("银行代码")]
        [Description("银行代码")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("BankCode", "银行代码", "nvarchar(30)")]
        public String BankCode { get => _BankCode; set { if (OnPropertyChanging("BankCode", value)) { _BankCode = value; OnPropertyChanged("BankCode"); } } }

        private String _BusinessScope;
        /// <summary>业务范围</summary>
        [DisplayName("业务范围")]
        [Description("业务范围")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn("BusinessScope", "业务范围", "nvarchar(40)")]
        public String BusinessScope { get => _BusinessScope; set { if (OnPropertyChanging("BusinessScope", value)) { _BusinessScope = value; OnPropertyChanged("BusinessScope"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Remark", "备注", "nvarchar(255)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private String _BankName;
        /// <summary>银行名称</summary>
        [Category("扩展信息")]
        [DisplayName("银行名称")]
        [Description("银行名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("BankName", "银行名称", "nvarchar(50)")]
        public String BankName { get => _BankName; set { if (OnPropertyChanging("BankName", value)) { _BankName = value; OnPropertyChanged("BankName"); } } }

        private String _AccountName;
        /// <summary>账户名</summary>
        [DisplayName("账户名")]
        [Description("账户名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("AccountName", "账户名", "nvarchar(50)")]
        public String AccountName { get => _AccountName; set { if (OnPropertyChanging("AccountName", value)) { _AccountName = value; OnPropertyChanged("AccountName"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Name", "名称", "nvarchar(50)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }
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
                    case "MemberNo": return _MemberNo;
                    case "MemberType": return _MemberType;
                    case "MemberFormNo": return _MemberFormNo;
                    case "MemberTime": return _MemberTime;
                    case "Address": return _Address;
                    case "LicenseNo": return _LicenseNo;
                    case "OrgNo": return _OrgNo;
                    case "ContactPhone": return _ContactPhone;
                    case "Contact": return _Contact;
                    case "Owner": return _Owner;
                    case "TenantId": return _TenantId;
                    case "Deleted": return _Deleted;
                    case "BankCode": return _BankCode;
                    case "BusinessScope": return _BusinessScope;
                    case "Remark": return _Remark;
                    case "BankName": return _BankName;
                    case "AccountName": return _AccountName;
                    case "Name": return _Name;
                    case "CreateTime": return _CreateTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "MemberNo": _MemberNo = Convert.ToString(value); break;
                    case "MemberType": _MemberType = Convert.ToInt16(value); break;
                    case "MemberFormNo": _MemberFormNo = Convert.ToString(value); break;
                    case "MemberTime": _MemberTime = value.ToDateTime(); break;
                    case "Address": _Address = Convert.ToString(value); break;
                    case "LicenseNo": _LicenseNo = Convert.ToString(value); break;
                    case "OrgNo": _OrgNo = Convert.ToString(value); break;
                    case "ContactPhone": _ContactPhone = Convert.ToString(value); break;
                    case "Contact": _Contact = Convert.ToString(value); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "BankCode": _BankCode = Convert.ToString(value); break;
                    case "BusinessScope": _BusinessScope = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "BankName": _BankName = Convert.ToString(value); break;
                    case "AccountName": _AccountName = Convert.ToString(value); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得会员信息字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary>会员编码</summary>
            public static readonly Field MemberNo = FindByName("MemberNo");

            /// <summary>会员类型</summary>
            public static readonly Field MemberType = FindByName("MemberType");

            /// <summary>会员表单编号</summary>
            public static readonly Field MemberFormNo = FindByName("MemberFormNo");

            /// <summary>会员时间</summary>
            public static readonly Field MemberTime = FindByName("MemberTime");

            /// <summary>地址</summary>
            public static readonly Field Address = FindByName("Address");

            /// <summary>许可编码(许可证)</summary>
            public static readonly Field LicenseNo = FindByName("LicenseNo");

            /// <summary>组织编码</summary>
            public static readonly Field OrgNo = FindByName("OrgNo");

            /// <summary>联系电话</summary>
            public static readonly Field ContactPhone = FindByName("ContactPhone");

            /// <summary>联系人</summary>
            public static readonly Field Contact = FindByName("Contact");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>银行代码</summary>
            public static readonly Field BankCode = FindByName("BankCode");

            /// <summary>业务范围</summary>
            public static readonly Field BusinessScope = FindByName("BusinessScope");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>银行名称</summary>
            public static readonly Field BankName = FindByName("BankName");

            /// <summary>账户名</summary>
            public static readonly Field AccountName = FindByName("AccountName");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得会员信息字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String Id = "Id";

            /// <summary>会员编码</summary>
            public const String MemberNo = "MemberNo";

            /// <summary>会员类型</summary>
            public const String MemberType = "MemberType";

            /// <summary>会员表单编号</summary>
            public const String MemberFormNo = "MemberFormNo";

            /// <summary>会员时间</summary>
            public const String MemberTime = "MemberTime";

            /// <summary>地址</summary>
            public const String Address = "Address";

            /// <summary>许可编码(许可证)</summary>
            public const String LicenseNo = "LicenseNo";

            /// <summary>组织编码</summary>
            public const String OrgNo = "OrgNo";

            /// <summary>联系电话</summary>
            public const String ContactPhone = "ContactPhone";

            /// <summary>联系人</summary>
            public const String Contact = "Contact";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>银行代码</summary>
            public const String BankCode = "BankCode";

            /// <summary>业务范围</summary>
            public const String BusinessScope = "BusinessScope";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>银行名称</summary>
            public const String BankName = "BankName";

            /// <summary>账户名</summary>
            public const String AccountName = "AccountName";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";
        }
        #endregion
    }
}