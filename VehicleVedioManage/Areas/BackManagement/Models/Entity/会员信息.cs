using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.BackManagement.Entity
{
    /// <summary>会员信息。涉及到租赁、充值时，会员享受一定的优惠</summary>
    [Serializable]
    [DataObject]
    [Description("会员信息。涉及到租赁、充值时，会员享受一定的优惠")]
    [BindIndex("IU_MemberInfo_Name", true, "Name")]
    [BindTable("MemberInfo", Description = "会员信息。涉及到租赁、充值时，会员享受一定的优惠", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class MemberInfo
    {
        #region 属性
        private Int32 _ID;
        /// <summary>会员编号</summary>
        [DisplayName("会员编号")]
        [Description("会员编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "会员编号", "")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private Int16 _MemberType;
        /// <summary>会员类型</summary>
        [DisplayName("会员类型")]
        [Description("会员类型")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("MemberType", "会员类型", "")]
        public Int16 MemberType { get => _MemberType; set { if (OnPropertyChanging("MemberType", value)) { _MemberType = value; OnPropertyChanged("MemberType"); } } }

        private String _MemberFormNo;
        /// <summary>会员表单编号</summary>
        [DisplayName("会员表单编号")]
        [Description("会员表单编号")]
        [DataObjectField(false, false, true, 16)]
        [BindColumn("MemberFormNo", "会员表单编号", "")]
        public String MemberFormNo { get => _MemberFormNo; set { if (OnPropertyChanging("MemberFormNo", value)) { _MemberFormNo = value; OnPropertyChanged("MemberFormNo"); } } }

        private DateTime _MemberTime;
        /// <summary>会员时间</summary>
        [DisplayName("会员时间")]
        [Description("会员时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("MemberTime", "会员时间", "", Precision = 0, Scale = 3)]
        public DateTime MemberTime { get => _MemberTime; set { if (OnPropertyChanging("MemberTime", value)) { _MemberTime = value; OnPropertyChanged("MemberTime"); } } }

        private String _Address;
        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, true, 16)]
        [BindColumn("Address", "地址", "")]
        public String Address { get => _Address; set { if (OnPropertyChanging("Address", value)) { _Address = value; OnPropertyChanged("Address"); } } }

        private String _LicenseNo;
        /// <summary>许可编码(许可证)</summary>
        [DisplayName("许可编码")]
        [Description("许可编码(许可证)")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("LicenseNo", "许可编码(许可证)", "")]
        public String LicenseNo { get => _LicenseNo; set { if (OnPropertyChanging("LicenseNo", value)) { _LicenseNo = value; OnPropertyChanged("LicenseNo"); } } }

        private String _DepartmentID;
        /// <summary>部门编码</summary>
        [DisplayName("部门编码")]
        [Description("部门编码")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("DepartmentID", "部门编码", "")]
        public String DepartmentID { get => _DepartmentID; set { if (OnPropertyChanging("DepartmentID", value)) { _DepartmentID = value; OnPropertyChanged("DepartmentID"); } } }

        private String _ContactPhone;
        /// <summary>联系电话</summary>
        [DisplayName("联系电话")]
        [Description("联系电话")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("ContactPhone", "联系电话", "")]
        public String ContactPhone { get => _ContactPhone; set { if (OnPropertyChanging("ContactPhone", value)) { _ContactPhone = value; OnPropertyChanged("ContactPhone"); } } }

        private String _Contact;
        /// <summary>联系人</summary>
        [DisplayName("联系人")]
        [Description("联系人")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Contact", "联系人", "")]
        public String Contact { get => _Contact; set { if (OnPropertyChanging("Contact", value)) { _Contact = value; OnPropertyChanged("Contact"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [Category("扩展信息")]
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "物主", "")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [Category("扩展信息")]
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TenantId", "租户编码", "")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("扩展信息")]
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _BankCode;
        /// <summary>银行代码</summary>
        [Category("扩展信息")]
        [DisplayName("银行代码")]
        [Description("银行代码")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("BankCode", "银行代码", "")]
        public String BankCode { get => _BankCode; set { if (OnPropertyChanging("BankCode", value)) { _BankCode = value; OnPropertyChanged("BankCode"); } } }

        private String _BusinessScope;
        /// <summary>业务范围</summary>
        [Category("扩展信息")]
        [DisplayName("业务范围")]
        [Description("业务范围")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn("BusinessScope", "业务范围", "")]
        public String BusinessScope { get => _BusinessScope; set { if (OnPropertyChanging("BusinessScope", value)) { _BusinessScope = value; OnPropertyChanged("BusinessScope"); } } }

        private String _BankName;
        /// <summary>银行名称</summary>
        [Category("扩展信息")]
        [DisplayName("银行名称")]
        [Description("银行名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("BankName", "银行名称", "")]
        public String BankName { get => _BankName; set { if (OnPropertyChanging("BankName", value)) { _BankName = value; OnPropertyChanged("BankName"); } } }

        private String _AccountName;
        /// <summary>账户名</summary>
        [Category("扩展信息")]
        [DisplayName("账户名")]
        [Description("账户名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("AccountName", "账户名", "")]
        public String AccountName { get => _AccountName; set { if (OnPropertyChanging("AccountName", value)) { _AccountName = value; OnPropertyChanged("AccountName"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Name", "名称", "", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Remark", "备注", "")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

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
                    case "MemberType": return _MemberType;
                    case "MemberFormNo": return _MemberFormNo;
                    case "MemberTime": return _MemberTime;
                    case "Address": return _Address;
                    case "LicenseNo": return _LicenseNo;
                    case "DepartmentID": return _DepartmentID;
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
                    case "ID": _ID = value.ToInt(); break;
                    case "MemberType": _MemberType = Convert.ToInt16(value); break;
                    case "MemberFormNo": _MemberFormNo = Convert.ToString(value); break;
                    case "MemberTime": _MemberTime = value.ToDateTime(); break;
                    case "Address": _Address = Convert.ToString(value); break;
                    case "LicenseNo": _LicenseNo = Convert.ToString(value); break;
                    case "DepartmentID": _DepartmentID = Convert.ToString(value); break;
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
            /// <summary>会员编号</summary>
            public static readonly Field ID = FindByName("ID");

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

            /// <summary>部门编码</summary>
            public static readonly Field DepartmentID = FindByName("DepartmentID");

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
            /// <summary>会员编号</summary>
            public const String ID = "ID";

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

            /// <summary>部门编码</summary>
            public const String DepartmentID = "DepartmentID";

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