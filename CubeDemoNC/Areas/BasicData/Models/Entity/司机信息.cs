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
    /// <summary>司机信息</summary>
    [Serializable]
    [DataObject]
    [Description("司机信息")]
    [BindTable("DriverInfo", Description = "司机信息", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class DriverInfo
    {
        #region 属性
        private Int32 _DriverId;
        /// <summary>驾驶员编码</summary>
        [DisplayName("驾驶员编码")]
        [Description("驾驶员编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("DriverId", "驾驶员编码", "int")]
        public Int32 DriverId { get => _DriverId; set { if (OnPropertyChanging("DriverId", value)) { _DriverId = value; OnPropertyChanged("DriverId"); } } }

        private String _CompanyNo;
        /// <summary>企业编码</summary>
        [DisplayName("企业编码")]
        [Description("企业编码")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("CompanyNo", "企业编码", "nvarchar(20)")]
        public String CompanyNo { get => _CompanyNo; set { if (OnPropertyChanging("CompanyNo", value)) { _CompanyNo = value; OnPropertyChanged("CompanyNo"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VehicleId", "车辆编码", "int")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private String _DriverCode;
        /// <summary>驾驶员编码</summary>
        [DisplayName("驾驶员编码")]
        [Description("驾驶员编码")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn("DriverCode", "驾驶员编码", "varchar(8)")]
        public String DriverCode { get => _DriverCode; set { if (OnPropertyChanging("DriverCode", value)) { _DriverCode = value; OnPropertyChanged("DriverCode"); } } }

        private String _DriverName;
        /// <summary>驾驶员姓名</summary>
        [DisplayName("驾驶员姓名")]
        [Description("驾驶员姓名")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn("DriverName", "驾驶员姓名", "nvarchar(32)")]
        public String DriverName { get => _DriverName; set { if (OnPropertyChanging("DriverName", value)) { _DriverName = value; OnPropertyChanged("DriverName"); } } }

        private String _Sex;
        /// <summary>性别</summary>
        [DisplayName("性别")]
        [Description("性别")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn("Sex", "性别", "nvarchar(8)")]
        public String Sex { get => _Sex; set { if (OnPropertyChanging("Sex", value)) { _Sex = value; OnPropertyChanged("Sex"); } } }

        private String _DriverLicence;
        /// <summary>驾驶执照</summary>
        [DisplayName("驾驶执照")]
        [Description("驾驶执照")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("DriverLicence", "驾驶执照", "nvarchar(50)")]
        public String DriverLicence { get => _DriverLicence; set { if (OnPropertyChanging("DriverLicence", value)) { _DriverLicence = value; OnPropertyChanged("DriverLicence"); } } }

        private String _IdentityCard;
        /// <summary>身份证</summary>
        [DisplayName("身份证")]
        [Description("身份证")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("IdentityCard", "身份证", "nvarchar(50)")]
        public String IdentityCard { get => _IdentityCard; set { if (OnPropertyChanging("IdentityCard", value)) { _IdentityCard = value; OnPropertyChanged("IdentityCard"); } } }

        private String _NativePlace;
        /// <summary>籍贯</summary>
        [DisplayName("籍贯")]
        [Description("籍贯")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("NativePlace", "籍贯", "nvarchar(50)")]
        public String NativePlace { get => _NativePlace; set { if (OnPropertyChanging("NativePlace", value)) { _NativePlace = value; OnPropertyChanged("NativePlace"); } } }

        private String _Address;
        /// <summary>地址</summary>
        [DisplayName("地址")]
        [Description("地址")]
        [DataObjectField(false, false, true, 64)]
        [BindColumn("Address", "地址", "nvarchar(64)")]
        public String Address { get => _Address; set { if (OnPropertyChanging("Address", value)) { _Address = value; OnPropertyChanged("Address"); } } }

        private String _Telephone;
        /// <summary>电话</summary>
        [DisplayName("电话")]
        [Description("电话")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn("Telephone", "电话", "varchar(32)")]
        public String Telephone { get => _Telephone; set { if (OnPropertyChanging("Telephone", value)) { _Telephone = value; OnPropertyChanged("Telephone"); } } }

        private String _MobilePhone;
        /// <summary>手机号</summary>
        [DisplayName("手机号")]
        [Description("手机号")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn("MobilePhone", "手机号", "varchar(32)")]
        public String MobilePhone { get => _MobilePhone; set { if (OnPropertyChanging("MobilePhone", value)) { _MobilePhone = value; OnPropertyChanged("MobilePhone"); } } }

        private DateTime _Birthday;
        /// <summary>生日</summary>
        [DisplayName("生日")]
        [Description("生日")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("Birthday", "生日", "datetime", Precision = 0, Scale = 3)]
        public DateTime Birthday { get => _Birthday; set { if (OnPropertyChanging("Birthday", value)) { _Birthday = value; OnPropertyChanged("Birthday"); } } }

        private String _DrivingType;
        /// <summary>驱动类型</summary>
        [DisplayName("驱动类型")]
        [Description("驱动类型")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn("DrivingType", "驱动类型", "nvarchar(8)")]
        public String DrivingType { get => _DrivingType; set { if (OnPropertyChanging("DrivingType", value)) { _DrivingType = value; OnPropertyChanged("DrivingType"); } } }

        private DateTime _ExamineYear;
        /// <summary>检查年份</summary>
        [DisplayName("检查年份")]
        [Description("检查年份")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("ExamineYear", "检查年份", "datetime", Precision = 0, Scale = 3)]
        public DateTime ExamineYear { get => _ExamineYear; set { if (OnPropertyChanging("ExamineYear", value)) { _ExamineYear = value; OnPropertyChanged("ExamineYear"); } } }

        private Byte _HarnessesAge;
        /// <summary></summary>
        [DisplayName("HarnessesAge")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("HarnessesAge", "", "tinyint")]
        public Byte HarnessesAge { get => _HarnessesAge; set { if (OnPropertyChanging("HarnessesAge", value)) { _HarnessesAge = value; OnPropertyChanged("HarnessesAge"); } } }

        private Int16 _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn("Status", "状态", "smallint")]
        public Int16 Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private DateTime _Appointment;
        /// <summary>预约时间</summary>
        [DisplayName("预约时间")]
        [Description("预约时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("Appointment", "预约时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime Appointment { get => _Appointment; set { if (OnPropertyChanging("Appointment", value)) { _Appointment = value; OnPropertyChanged("Appointment"); } } }

        private Single _BaseSalary;
        /// <summary>基本工资</summary>
        [DisplayName("基本工资")]
        [Description("基本工资")]
        [DataObjectField(false, false, true, 24)]
        [BindColumn("BaseSalary", "基本工资", "real")]
        public Single BaseSalary { get => _BaseSalary; set { if (OnPropertyChanging("BaseSalary", value)) { _BaseSalary = value; OnPropertyChanged("BaseSalary"); } } }

        private Single _RoyaltiesScale;
        /// <summary>使用规模</summary>
        [DisplayName("使用规模")]
        [Description("使用规模")]
        [DataObjectField(false, false, true, 24)]
        [BindColumn("RoyaltiesScale", "使用规模", "real")]
        public Single RoyaltiesScale { get => _RoyaltiesScale; set { if (OnPropertyChanging("RoyaltiesScale", value)) { _RoyaltiesScale = value; OnPropertyChanged("RoyaltiesScale"); } } }

        private Single _AppraisalIntegral;
        /// <summary>评估</summary>
        [DisplayName("评估")]
        [Description("评估")]
        [DataObjectField(false, false, true, 24)]
        [BindColumn("AppraisalIntegral", "评估", "real")]
        public Single AppraisalIntegral { get => _AppraisalIntegral; set { if (OnPropertyChanging("AppraisalIntegral", value)) { _AppraisalIntegral = value; OnPropertyChanged("AppraisalIntegral"); } } }

        private String _DriverRFID;
        /// <summary>驾驶员射频卡</summary>
        [DisplayName("驾驶员射频卡")]
        [Description("驾驶员射频卡")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn("DriverRFID", "驾驶员射频卡", "varchar(40)")]
        public String DriverRFID { get => _DriverRFID; set { if (OnPropertyChanging("DriverRFID", value)) { _DriverRFID = value; OnPropertyChanged("DriverRFID"); } } }

        private String _Password;
        /// <summary>密码</summary>
        [DisplayName("密码")]
        [Description("密码")]
        [DataObjectField(false, false, true, 16)]
        [BindColumn("Password", "密码", "varchar(16)")]
        public String Password { get => _Password; set { if (OnPropertyChanging("Password", value)) { _Password = value; OnPropertyChanged("Password"); } } }

        private Int32 _OperatorID;
        /// <summary>运营商编码</summary>
        [DisplayName("运营商编码")]
        [Description("运营商编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("OperatorID", "运营商编码", "int")]
        public Int32 OperatorID { get => _OperatorID; set { if (OnPropertyChanging("OperatorID", value)) { _OperatorID = value; OnPropertyChanged("OperatorID"); } } }

        private DateTime _Register;
        /// <summary>注册</summary>
        [DisplayName("注册")]
        [Description("注册")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("Register", "注册", "datetime", Precision = 0, Scale = 3)]
        public DateTime Register { get => _Register; set { if (OnPropertyChanging("Register", value)) { _Register = value; OnPropertyChanged("Register"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 256)]
        [BindColumn("Remark", "备注", "nvarchar(256)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateTime", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private String _LicenseAgency;
        /// <summary>许可证机构</summary>
        [DisplayName("许可证机构")]
        [Description("许可证机构")]
        [DataObjectField(false, false, true, 64)]
        [BindColumn("LicenseAgency", "许可证机构", "nvarchar(64)")]
        public String LicenseAgency { get => _LicenseAgency; set { if (OnPropertyChanging("LicenseAgency", value)) { _LicenseAgency = value; OnPropertyChanged("LicenseAgency"); } } }

        private DateTime _CertificationDate;
        /// <summary>认证日期</summary>
        [DisplayName("认证日期")]
        [Description("认证日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CertificationDate", "认证日期", "datetime", Precision = 0, Scale = 3)]
        public DateTime CertificationDate { get => _CertificationDate; set { if (OnPropertyChanging("CertificationDate", value)) { _CertificationDate = value; OnPropertyChanged("CertificationDate"); } } }

        private DateTime _InvalidDate;
        /// <summary>无效期</summary>
        [DisplayName("无效期")]
        [Description("无效期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("InvalidDate", "无效期", "datetime", Precision = 0, Scale = 3)]
        public DateTime InvalidDate { get => _InvalidDate; set { if (OnPropertyChanging("InvalidDate", value)) { _InvalidDate = value; OnPropertyChanged("InvalidDate"); } } }

        private String _Corp;
        /// <summary>公司</summary>
        [DisplayName("公司")]
        [Description("公司")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn("Corp", "公司", "varchar(32)")]
        public String Corp { get => _Corp; set { if (OnPropertyChanging("Corp", value)) { _Corp = value; OnPropertyChanged("Corp"); } } }

        private String _MonitorOrg;
        /// <summary>监控组织</summary>
        [DisplayName("监控组织")]
        [Description("监控组织")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn("MonitorOrg", "监控组织", "varchar(32)")]
        public String MonitorOrg { get => _MonitorOrg; set { if (OnPropertyChanging("MonitorOrg", value)) { _MonitorOrg = value; OnPropertyChanged("MonitorOrg"); } } }

        private String _MonitorPhone;
        /// <summary>监控电话</summary>
        [DisplayName("监控电话")]
        [Description("监控电话")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn("MonitorPhone", "监控电话", "varchar(32)")]
        public String MonitorPhone { get => _MonitorPhone; set { if (OnPropertyChanging("MonitorPhone", value)) { _MonitorPhone = value; OnPropertyChanged("MonitorPhone"); } } }

        private Int32 _ServiceLevel;
        /// <summary>服务层级</summary>
        [DisplayName("服务层级")]
        [Description("服务层级")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("ServiceLevel", "服务层级", "int")]
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
        [DataObjectField(false, false, true, 10)]
        [BindColumn("PhotoLength", "照片长度", "int")]
        public Int32 PhotoLength { get => _PhotoLength; set { if (OnPropertyChanging("PhotoLength", value)) { _PhotoLength = value; OnPropertyChanged("PhotoLength"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "物主", "nvarchar(50)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _JobCard;
        /// <summary>工作证</summary>
        [DisplayName("工作证")]
        [Description("工作证")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("JobCard", "工作证", "nvarchar(20)")]
        public String JobCard { get => _JobCard; set { if (OnPropertyChanging("JobCard", value)) { _JobCard = value; OnPropertyChanged("JobCard"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private Byte _MainDriver;
        /// <summary>主驾驶员</summary>
        [DisplayName("主驾驶员")]
        [Description("主驾驶员")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("MainDriver", "主驾驶员", "tinyint")]
        public Byte MainDriver { get => _MainDriver; set { if (OnPropertyChanging("MainDriver", value)) { _MainDriver = value; OnPropertyChanged("MainDriver"); } } }
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
                    case "DriverId": return _DriverId;
                    case "CompanyNo": return _CompanyNo;
                    case "VehicleId": return _VehicleId;
                    case "DriverCode": return _DriverCode;
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
                    case "HarnessesAge": return _HarnessesAge;
                    case "Status": return _Status;
                    case "Appointment": return _Appointment;
                    case "BaseSalary": return _BaseSalary;
                    case "RoyaltiesScale": return _RoyaltiesScale;
                    case "AppraisalIntegral": return _AppraisalIntegral;
                    case "DriverRFID": return _DriverRFID;
                    case "Password": return _Password;
                    case "OperatorID": return _OperatorID;
                    case "Register": return _Register;
                    case "Remark": return _Remark;
                    case "UpdateTime": return _UpdateTime;
                    case "LicenseAgency": return _LicenseAgency;
                    case "CertificationDate": return _CertificationDate;
                    case "InvalidDate": return _InvalidDate;
                    case "Corp": return _Corp;
                    case "MonitorOrg": return _MonitorOrg;
                    case "MonitorPhone": return _MonitorPhone;
                    case "ServiceLevel": return _ServiceLevel;
                    case "BgTitle": return _BgTitle;
                    case "Location": return _Location;
                    case "PhotoFormat": return _PhotoFormat;
                    case "PhotoLength": return _PhotoLength;
                    case "Owner": return _Owner;
                    case "JobCard": return _JobCard;
                    case "Deleted": return _Deleted;
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
                    case "DriverId": _DriverId = value.ToInt(); break;
                    case "CompanyNo": _CompanyNo = Convert.ToString(value); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "DriverCode": _DriverCode = Convert.ToString(value); break;
                    case "DriverName": _DriverName = Convert.ToString(value); break;
                    case "Sex": _Sex = Convert.ToString(value); break;
                    case "DriverLicence": _DriverLicence = Convert.ToString(value); break;
                    case "IdentityCard": _IdentityCard = Convert.ToString(value); break;
                    case "NativePlace": _NativePlace = Convert.ToString(value); break;
                    case "Address": _Address = Convert.ToString(value); break;
                    case "Telephone": _Telephone = Convert.ToString(value); break;
                    case "MobilePhone": _MobilePhone = Convert.ToString(value); break;
                    case "Birthday": _Birthday = value.ToDateTime(); break;
                    case "DrivingType": _DrivingType = Convert.ToString(value); break;
                    case "ExamineYear": _ExamineYear = value.ToDateTime(); break;
                    case "HarnessesAge": _HarnessesAge = Convert.ToByte(value); break;
                    case "Status": _Status = Convert.ToInt16(value); break;
                    case "Appointment": _Appointment = value.ToDateTime(); break;
                    case "BaseSalary": _BaseSalary = Convert.ToSingle(value); break;
                    case "RoyaltiesScale": _RoyaltiesScale = Convert.ToSingle(value); break;
                    case "AppraisalIntegral": _AppraisalIntegral = Convert.ToSingle(value); break;
                    case "DriverRFID": _DriverRFID = Convert.ToString(value); break;
                    case "Password": _Password = Convert.ToString(value); break;
                    case "OperatorID": _OperatorID = value.ToInt(); break;
                    case "Register": _Register = value.ToDateTime(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    case "LicenseAgency": _LicenseAgency = Convert.ToString(value); break;
                    case "CertificationDate": _CertificationDate = value.ToDateTime(); break;
                    case "InvalidDate": _InvalidDate = value.ToDateTime(); break;
                    case "Corp": _Corp = Convert.ToString(value); break;
                    case "MonitorOrg": _MonitorOrg = Convert.ToString(value); break;
                    case "MonitorPhone": _MonitorPhone = Convert.ToString(value); break;
                    case "ServiceLevel": _ServiceLevel = value.ToInt(); break;
                    case "BgTitle": _BgTitle = Convert.ToString(value); break;
                    case "Location": _Location = Convert.ToString(value); break;
                    case "PhotoFormat": _PhotoFormat = Convert.ToString(value); break;
                    case "PhotoLength": _PhotoLength = value.ToInt(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "JobCard": _JobCard = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
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
            public static readonly Field DriverId = FindByName("DriverId");

            /// <summary>企业编码</summary>
            public static readonly Field CompanyNo = FindByName("CompanyNo");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>驾驶员编码</summary>
            public static readonly Field DriverCode = FindByName("DriverCode");

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

            /// <summary>驱动类型</summary>
            public static readonly Field DrivingType = FindByName("DrivingType");

            /// <summary>检查年份</summary>
            public static readonly Field ExamineYear = FindByName("ExamineYear");

            /// <summary></summary>
            public static readonly Field HarnessesAge = FindByName("HarnessesAge");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>预约时间</summary>
            public static readonly Field Appointment = FindByName("Appointment");

            /// <summary>基本工资</summary>
            public static readonly Field BaseSalary = FindByName("BaseSalary");

            /// <summary>使用规模</summary>
            public static readonly Field RoyaltiesScale = FindByName("RoyaltiesScale");

            /// <summary>评估</summary>
            public static readonly Field AppraisalIntegral = FindByName("AppraisalIntegral");

            /// <summary>驾驶员射频卡</summary>
            public static readonly Field DriverRFID = FindByName("DriverRFID");

            /// <summary>密码</summary>
            public static readonly Field Password = FindByName("Password");

            /// <summary>运营商编码</summary>
            public static readonly Field OperatorID = FindByName("OperatorID");

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

            /// <summary>公司</summary>
            public static readonly Field Corp = FindByName("Corp");

            /// <summary>监控组织</summary>
            public static readonly Field MonitorOrg = FindByName("MonitorOrg");

            /// <summary>监控电话</summary>
            public static readonly Field MonitorPhone = FindByName("MonitorPhone");

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

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

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
            public const String DriverId = "DriverId";

            /// <summary>企业编码</summary>
            public const String CompanyNo = "CompanyNo";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>驾驶员编码</summary>
            public const String DriverCode = "DriverCode";

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

            /// <summary>驱动类型</summary>
            public const String DrivingType = "DrivingType";

            /// <summary>检查年份</summary>
            public const String ExamineYear = "ExamineYear";

            /// <summary></summary>
            public const String HarnessesAge = "HarnessesAge";

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

            /// <summary>驾驶员射频卡</summary>
            public const String DriverRFID = "DriverRFID";

            /// <summary>密码</summary>
            public const String Password = "Password";

            /// <summary>运营商编码</summary>
            public const String OperatorID = "OperatorID";

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

            /// <summary>公司</summary>
            public const String Corp = "Corp";

            /// <summary>监控组织</summary>
            public const String MonitorOrg = "MonitorOrg";

            /// <summary>监控电话</summary>
            public const String MonitorPhone = "MonitorPhone";

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

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

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