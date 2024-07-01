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
    /// <summary>司机信息。驾驶员基本信息</summary>
    [Serializable]
    [DataObject]
    [Description("司机信息。驾驶员基本信息")]
    [BindIndex("IU_DriverInfo_DriverName", true, "DriverName")]
    [BindIndex("IX_DriverInfo_DepartmentName", false, "DepartmentName")]
    [BindTable("DriverInfo", Description = "司机信息。驾驶员基本信息", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class DriverInfo
    {
        #region 属性
        private Int32 _ID;
        /// <summary>驾驶员编码</summary>
        [DisplayName("驾驶员编码")]
        [Description("驾驶员编码")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "驾驶员编码", "")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private Int32 _DepartmentID;
        /// <summary>企业编码</summary>
        [DisplayName("企业编码")]
        [Description("企业编码")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn("DepartmentID", "企业编码", "")]
        public Int32 DepartmentID { get => _DepartmentID; set { if (OnPropertyChanging("DepartmentID", value)) { _DepartmentID = value; OnPropertyChanged("DepartmentID"); } } }

        private String _DriverName;
        /// <summary>司机姓名</summary>
        [DisplayName("司机姓名")]
        [Description("司机姓名")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn("DriverName", "司机姓名", "")]
        public String DriverName { get => _DriverName; set { if (OnPropertyChanging("DriverName", value)) { _DriverName = value; OnPropertyChanged("DriverName"); } } }

        private Int32 _Sex;
        /// <summary>性别</summary>
        [DisplayName("性别")]
        [Description("性别")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn("Sex", "性别", "")]
        public Int32 Sex { get => _Sex; set { if (OnPropertyChanging("Sex", value)) { _Sex = value; OnPropertyChanged("Sex"); } } }

        private String _DriverLicence;
        /// <summary>驾驶执照</summary>
        [DisplayName("驾驶执照")]
        [Description("驾驶执照")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("DriverLicence", "驾驶执照", "")]
        public String DriverLicence { get => _DriverLicence; set { if (OnPropertyChanging("DriverLicence", value)) { _DriverLicence = value; OnPropertyChanged("DriverLicence"); } } }

        private String _IdentityCard;
        /// <summary>身份证</summary>
        [DisplayName("身份证")]
        [Description("身份证")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("IdentityCard", "身份证", "")]
        public String IdentityCard { get => _IdentityCard; set { if (OnPropertyChanging("IdentityCard", value)) { _IdentityCard = value; OnPropertyChanged("IdentityCard"); } } }

        private String _NativePlace;
        /// <summary>籍贯</summary>
        [DisplayName("籍贯")]
        [Description("籍贯")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("NativePlace", "籍贯", "")]
        public String NativePlace { get => _NativePlace; set { if (OnPropertyChanging("NativePlace", value)) { _NativePlace = value; OnPropertyChanged("NativePlace"); } } }

        private String _Address;
        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn("Address", "地址", "")]
        public String Address { get => _Address; set { if (OnPropertyChanging("Address", value)) { _Address = value; OnPropertyChanged("Address"); } } }

        private Int32 _Telephone;
        /// <summary>电话</summary>
        [DisplayName("电话")]
        [Description("电话")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("Telephone", "电话", "")]
        public Int32 Telephone { get => _Telephone; set { if (OnPropertyChanging("Telephone", value)) { _Telephone = value; OnPropertyChanged("Telephone"); } } }

        private Int32 _MobilePhone;
        /// <summary>手机号</summary>
        [DisplayName("手机号")]
        [Description("手机号")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("MobilePhone", "手机号", "varchar(20)")]
        public Int32 MobilePhone { get => _MobilePhone; set { if (OnPropertyChanging("MobilePhone", value)) { _MobilePhone = value; OnPropertyChanged("MobilePhone"); } } }

        private DateTime _Birthday;
        /// <summary>生日</summary>
        [DisplayName("生日")]
        [Description("生日")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Birthday", "生日", "", Precision = 0, Scale = 3)]
        public DateTime Birthday { get => _Birthday; set { if (OnPropertyChanging("Birthday", value)) { _Birthday = value; OnPropertyChanged("Birthday"); } } }

        private String _DrivingType;
        /// <summary>驾驶类型</summary>
        [DisplayName("驾驶类型")]
        [Description("驾驶类型")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn("DrivingType", "驾驶类型", "")]
        public String DrivingType { get => _DrivingType; set { if (OnPropertyChanging("DrivingType", value)) { _DrivingType = value; OnPropertyChanged("DrivingType"); } } }

        private DateTime _ExamineYear;
        /// <summary>检查年份</summary>
        [DisplayName("检查年份")]
        [Description("检查年份")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("ExamineYear", "检查年份", "", Precision = 0, Scale = 3)]
        public DateTime ExamineYear { get => _ExamineYear; set { if (OnPropertyChanging("ExamineYear", value)) { _ExamineYear = value; OnPropertyChanged("ExamineYear"); } } }

        private Int16 _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Status", "状态", "")]
        public Int16 Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private DateTime _Appointment;
        /// <summary>预约时间</summary>
        [DisplayName("预约时间")]
        [Description("预约时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Appointment", "预约时间", "", Precision = 0, Scale = 3)]
        public DateTime Appointment { get => _Appointment; set { if (OnPropertyChanging("Appointment", value)) { _Appointment = value; OnPropertyChanged("Appointment"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VehicleId", "车辆编码", "int")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private Single _RoyaltiesScale;
        /// <summary>使用规模</summary>
        [Category("扩展信息")]
        [DisplayName("使用规模")]
        [Description("使用规模")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("RoyaltiesScale", "使用规模", "")]
        public Single RoyaltiesScale { get => _RoyaltiesScale; set { if (OnPropertyChanging("RoyaltiesScale", value)) { _RoyaltiesScale = value; OnPropertyChanged("RoyaltiesScale"); } } }

        private Single _AppraisalIntegral;
        /// <summary>评估</summary>
        [Category("扩展信息")]
        [DisplayName("评估")]
        [Description("评估")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AppraisalIntegral", "评估", "")]
        public Single AppraisalIntegral { get => _AppraisalIntegral; set { if (OnPropertyChanging("AppraisalIntegral", value)) { _AppraisalIntegral = value; OnPropertyChanged("AppraisalIntegral"); } } }

        private String _DriverRFID;
        /// <summary>Sim卡</summary>
        [DisplayName("Sim卡")]
        [Description("Sim卡")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn("DriverRFID", "Sim卡", "varchar(40)")]
        public String DriverRFID { get => _DriverRFID; set { if (OnPropertyChanging("DriverRFID", value)) { _DriverRFID = value; OnPropertyChanged("DriverRFID"); } } }

        private String _Password;
        /// <summary>密码</summary>
        [DisplayName("密码")]
        [Description("密码")]
        [DataObjectField(false, false, true, 16)]
        [BindColumn("Password", "密码", "varchar(16)")]
        public String Password { get => _Password; set { if (OnPropertyChanging("Password", value)) { _Password = value; OnPropertyChanged("Password"); } } }

        private DateTime _Register;
        /// <summary>注册</summary>
        [Category("扩展信息")]
        [DisplayName("注册")]
        [Description("注册")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Register", "注册", "", Precision = 0, Scale = 3)]
        public DateTime Register { get => _Register; set { if (OnPropertyChanging("Register", value)) { _Register = value; OnPropertyChanged("Register"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [Category("扩展信息")]
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("UpdateTime", "更新时间", "", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private String _LicenseAgency;
        /// <summary>许可证机构</summary>
        [Category("扩展信息")]
        [DisplayName("许可证机构")]
        [Description("许可证机构")]
        [DataObjectField(false, false, true, 64)]
        [BindColumn("LicenseAgency", "许可证机构", "")]
        public String LicenseAgency { get => _LicenseAgency; set { if (OnPropertyChanging("LicenseAgency", value)) { _LicenseAgency = value; OnPropertyChanged("LicenseAgency"); } } }

        private DateTime _CertificationDate;
        /// <summary>认证日期</summary>
        [Category("扩展信息")]
        [DisplayName("认证日期")]
        [Description("认证日期")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CertificationDate", "认证日期", "", Precision = 0, Scale = 3)]
        public DateTime CertificationDate { get => _CertificationDate; set { if (OnPropertyChanging("CertificationDate", value)) { _CertificationDate = value; OnPropertyChanged("CertificationDate"); } } }

        private DateTime _InvalidDate;
        /// <summary>无效期</summary>
        [Category("扩展信息")]
        [DisplayName("无效期")]
        [Description("无效期")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("InvalidDate", "无效期", "", Precision = 0, Scale = 3)]
        public DateTime InvalidDate { get => _InvalidDate; set { if (OnPropertyChanging("InvalidDate", value)) { _InvalidDate = value; OnPropertyChanged("InvalidDate"); } } }

        private Int32 _ServiceLevel;
        /// <summary>服务层级</summary>
        [DisplayName("服务层级")]
        [Description("服务层级")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("ServiceLevel", "服务层级", "")]
        public Int32 ServiceLevel { get => _ServiceLevel; set { if (OnPropertyChanging("ServiceLevel", value)) { _ServiceLevel = value; OnPropertyChanged("ServiceLevel"); } } }

        private String _BgTitle;
        /// <summary>背景标题</summary>
        [DisplayName("背景标题")]
        [Description("背景标题")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn("BgTitle", "背景标题", "varchar(32)")]
        public String BgTitle { get => _BgTitle; set { if (OnPropertyChanging("BgTitle", value)) { _BgTitle = value; OnPropertyChanged("BgTitle"); } } }

        private String _Location;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn("Location", "位置", "varchar(32)")]
        public String Location { get => _Location; set { if (OnPropertyChanging("Location", value)) { _Location = value; OnPropertyChanged("Location"); } } }

        private String _PhotoFormat;
        /// <summary>照片格式</summary>
        [DisplayName("照片格式")]
        [Description("照片格式")]
        [DataObjectField(false, false, true, 4)]
        [BindColumn("PhotoFormat", "照片格式", "varchar(4)")]
        public String PhotoFormat { get => _PhotoFormat; set { if (OnPropertyChanging("PhotoFormat", value)) { _PhotoFormat = value; OnPropertyChanged("PhotoFormat"); } } }

        private Int32 _PhotoLength;
        /// <summary>照片长度</summary>
        [DisplayName("照片长度")]
        [Description("照片长度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("PhotoLength", "照片长度", "")]
        public Int32 PhotoLength { get => _PhotoLength; set { if (OnPropertyChanging("PhotoLength", value)) { _PhotoLength = value; OnPropertyChanged("PhotoLength"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [Category("扩展信息")]
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "物主", "")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _JobCard;
        /// <summary>工作证</summary>
        [DisplayName("工作证")]
        [Description("工作证")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("JobCard", "工作证", "")]
        public String JobCard { get => _JobCard; set { if (OnPropertyChanging("JobCard", value)) { _JobCard = value; OnPropertyChanged("JobCard"); } } }

        private Boolean _Enable;
        /// <summary>启用</summary>
        [Category("扩展信息")]
        [DisplayName("启用")]
        [Description("启用")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Enable", "启用", "")]
        public Boolean Enable { get => _Enable; set { if (OnPropertyChanging("Enable", value)) { _Enable = value; OnPropertyChanged("Enable"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [Category("扩展信息")]
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TenantId", "租户编码", "")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private Byte _MainDriver;
        /// <summary>主驾驶员</summary>
        [DisplayName("主驾驶员")]
        [Description("主驾驶员")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("MainDriver", "主驾驶员", "")]
        public Byte MainDriver { get => _MainDriver; set { if (OnPropertyChanging("MainDriver", value)) { _MainDriver = value; OnPropertyChanged("MainDriver"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Remark", "备注", "varchar(500)")]
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
                    case "DepartmentID": return _DepartmentID;
                    case "DriverName": return _DriverName;
                    case "Sex": return _Sex;
                    case "DriverLicence": return _DriverLicence;
                    case "IdentityCard": return _IdentityCard;
                    case "NativePlace": return _NativePlace;
                    case "Address": return _Address;
                    case "Telephone": return _Telephone;
                    case "MobilePhone": return _MobilePhone;
                    case "Birthday": return _Birthday;
                    case "DrivingType": return _DrivingType;
                    case "ExamineYear": return _ExamineYear;
                    case "Status": return _Status;
                    case "Appointment": return _Appointment;
                    case "RoyaltiesScale": return _RoyaltiesScale;
                    case "AppraisalIntegral": return _AppraisalIntegral;
                    case "DriverRFID": return _DriverRFID;
                    case "Password": return _Password;
                    case "Register": return _Register;
                    case "Remark": return _Remark;
                    case "UpdateTime": return _UpdateTime;
                    case "LicenseAgency": return _LicenseAgency;
                    case "CertificationDate": return _CertificationDate;
                    case "InvalidDate": return _InvalidDate;
                    case "ServiceLevel": return _ServiceLevel;
                    case "BgTitle": return _BgTitle;
                    case "Location": return _Location;
                    case "PhotoFormat": return _PhotoFormat;
                    case "PhotoLength": return _PhotoLength;
                    case "Owner": return _Owner;
                    case "JobCard": return _JobCard;
                    case "Enable": return _Enable;
                    case "VehicleId": return _VehicleId;
                    case "CreateTime": return _CreateTime;
                    case "TenantId": return _TenantId;
                    case "MainDriver": return _MainDriver;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = value.ToInt(); break;
                    case "DepartmentID": _DepartmentID = value.ToInt(); break;
                    case "DriverName": _DriverName = Convert.ToString(value); break;
                    case "Sex": _Sex = value.ToInt(); break;
                    case "DriverLicence": _DriverLicence = Convert.ToString(value); break;
                    case "IdentityCard": _IdentityCard = Convert.ToString(value); break;
                    case "NativePlace": _NativePlace = Convert.ToString(value); break;
                    case "Address": _Address = Convert.ToString(value); break;
                    case "Telephone": _Telephone = value.ToInt(); break;
                    case "MobilePhone": _MobilePhone = value.ToInt(); break;
                    case "Birthday": _Birthday = value.ToDateTime(); break;
                    case "DrivingType": _DrivingType = Convert.ToString(value); break;
                    case "ExamineYear": _ExamineYear = value.ToDateTime(); break;
                    case "Status": _Status = Convert.ToInt16(value); break;
                    case "Appointment": _Appointment = value.ToDateTime(); break;
                    case "RoyaltiesScale": _RoyaltiesScale = Convert.ToSingle(value); break;
                    case "AppraisalIntegral": _AppraisalIntegral = Convert.ToSingle(value); break;
                    case "DriverRFID": _DriverRFID = Convert.ToString(value); break;
                    case "Password": _Password = Convert.ToString(value); break;
                    case "Register": _Register = value.ToDateTime(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    case "LicenseAgency": _LicenseAgency = Convert.ToString(value); break;
                    case "CertificationDate": _CertificationDate = value.ToDateTime(); break;
                    case "InvalidDate": _InvalidDate = value.ToDateTime(); break;
                    case "ServiceLevel": _ServiceLevel = value.ToInt(); break;
                    case "BgTitle": _BgTitle = Convert.ToString(value); break;
                    case "Location": _Location = Convert.ToString(value); break;
                    case "PhotoFormat": _PhotoFormat = Convert.ToString(value); break;
                    case "PhotoLength": _PhotoLength = value.ToInt(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "JobCard": _JobCard = Convert.ToString(value); break;
                    case "Enable": _Enable = value.ToBoolean(); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "MainDriver": _MainDriver = Convert.ToByte(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得司机信息字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>驾驶员编码</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>部门编码</summary>
            public static readonly Field DepartmentID = FindByName("DepartmentID");

            /// <summary>部门名称</summary>
            public static readonly Field DepartmentName = FindByName("DepartmentName");

            /// <summary>驾驶员姓名</summary>
            public static readonly Field DriverName = FindByName("DriverName");

            /// <summary>性别</summary>
            public static readonly Field Sex = FindByName("Sex");

            /// <summary>驾驶执照</summary>
            public static readonly Field DriverLicence = FindByName("DriverLicence");

            /// <summary>身份证</summary>
            public static readonly Field IdentityCard = FindByName("IdentityCard");

            /// <summary>籍贯</summary>
            public static readonly Field NativePlace = FindByName("NativePlace");

            /// <summary>地址</summary>
            public static readonly Field Address = FindByName("Address");

            /// <summary>电话</summary>
            public static readonly Field Telephone = FindByName("Telephone");

            /// <summary>手机号</summary>
            public static readonly Field MobilePhone = FindByName("MobilePhone");

            /// <summary>生日</summary>
            public static readonly Field Birthday = FindByName("Birthday");

            /// <summary>驾驶类型</summary>
            public static readonly Field DrivingType = FindByName("DrivingType");

            /// <summary>检查年份</summary>
            public static readonly Field ExamineYear = FindByName("ExamineYear");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>预约时间</summary>
            public static readonly Field Appointment = FindByName("Appointment");

            /// <summary>使用规模</summary>
            public static readonly Field RoyaltiesScale = FindByName("RoyaltiesScale");

            /// <summary>评估</summary>
            public static readonly Field AppraisalIntegral = FindByName("AppraisalIntegral");

            /// <summary>Sim卡</summary>
            public static readonly Field DriverRFID = FindByName("DriverRFID");

            /// <summary>密码</summary>
            public static readonly Field Password = FindByName("Password");

            /// <summary>注册</summary>
            public static readonly Field Register = FindByName("Register");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            /// <summary>许可证机构</summary>
            public static readonly Field LicenseAgency = FindByName("LicenseAgency");

            /// <summary>认证日期</summary>
            public static readonly Field CertificationDate = FindByName("CertificationDate");

            /// <summary>无效期</summary>
            public static readonly Field InvalidDate = FindByName("InvalidDate");

            /// <summary>服务层级</summary>
            public static readonly Field ServiceLevel = FindByName("ServiceLevel");

            /// <summary>背景标题</summary>
            public static readonly Field BgTitle = FindByName("BgTitle");

            /// <summary>位置</summary>
            public static readonly Field Location = FindByName("Location");

            /// <summary>照片格式</summary>
            public static readonly Field PhotoFormat = FindByName("PhotoFormat");

            /// <summary>照片长度</summary>
            public static readonly Field PhotoLength = FindByName("PhotoLength");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>工作证</summary>
            public static readonly Field JobCard = FindByName("JobCard");

            /// <summary>启用</summary>
            public static readonly Field Enable = FindByName("Enable");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>主驾驶员</summary>
            public static readonly Field MainDriver = FindByName("MainDriver");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得司机信息字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>驾驶员编码</summary>
            public const String ID = "ID";

            /// <summary>部门编码</summary>
            public const String DepartmentID = "DepartmentID";

            /// <summary>部门名称</summary>
            public const String DepartmentName = "DepartmentName";

            /// <summary>驾驶员姓名</summary>
            public const String DriverName = "DriverName";

            /// <summary>性别</summary>
            public const String Sex = "Sex";

            /// <summary>驾驶执照</summary>
            public const String DriverLicence = "DriverLicence";

            /// <summary>身份证</summary>
            public const String IdentityCard = "IdentityCard";

            /// <summary>籍贯</summary>
            public const String NativePlace = "NativePlace";

            /// <summary>地址</summary>
            public const String Address = "Address";

            /// <summary>电话</summary>
            public const String Telephone = "Telephone";

            /// <summary>手机号</summary>
            public const String MobilePhone = "MobilePhone";

            /// <summary>生日</summary>
            public const String Birthday = "Birthday";

            /// <summary>驾驶类型</summary>
            public const String DrivingType = "DrivingType";

            /// <summary>检查年份</summary>
            public const String ExamineYear = "ExamineYear";

            /// <summary>状态</summary>
            public const String Status = "Status";

            /// <summary>预约时间</summary>
            public const String Appointment = "Appointment";

            /// <summary>基本工资</summary>
            public const String BaseSalary = "BaseSalary";

            /// <summary>使用规模</summary>
            public const String RoyaltiesScale = "RoyaltiesScale";

            /// <summary>评估</summary>
            public const String AppraisalIntegral = "AppraisalIntegral";

            /// <summary>Sim卡</summary>
            public const String DriverRFID = "DriverRFID";

            /// <summary>密码</summary>
            public const String Password = "Password";

            /// <summary>注册</summary>
            public const String Register = "Register";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            /// <summary>许可证机构</summary>
            public const String LicenseAgency = "LicenseAgency";

            /// <summary>认证日期</summary>
            public const String CertificationDate = "CertificationDate";

            /// <summary>无效期</summary>
            public const String InvalidDate = "InvalidDate";

            /// <summary>服务层级</summary>
            public const String ServiceLevel = "ServiceLevel";

            /// <summary>背景标题</summary>
            public const String BgTitle = "BgTitle";

            /// <summary>位置</summary>
            public const String Location = "Location";

            /// <summary>照片格式</summary>
            public const String PhotoFormat = "PhotoFormat";

            /// <summary>照片长度</summary>
            public const String PhotoLength = "PhotoLength";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>工作证</summary>
            public const String JobCard = "JobCard";

            /// <summary>启用</summary>
            public const String Enable = "Enable";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>主驾驶员</summary>
            public const String MainDriver = "MainDriver";
        }
        #endregion
    }
}