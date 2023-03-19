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
    /// <summary>用户信息</summary>
    [Serializable]
    [DataObject]
    [Description("用户信息")]
    [BindTable("UserInfo", Description = "用户信息", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class UserInfo
    {
        #region 属性
        private Int32 _userId;
        /// <summary></summary>
        [DisplayName("userId")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("userId", "", "int")]
        public Int32 userId { get => _userId; set { if (OnPropertyChanging("userId", value)) { _userId = value; OnPropertyChanged("userId"); } } }

        private String _Name;
        /// <summary></summary>
        [DisplayName("Name")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("name", "", "nvarchar(50)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _loginName;
        /// <summary></summary>
        [DisplayName("loginName")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("loginName", "", "nvarchar(50)")]
        public String loginName { get => _loginName; set { if (OnPropertyChanging("loginName", value)) { _loginName = value; OnPropertyChanged("loginName"); } } }

        private String _Password;
        /// <summary></summary>
        [DisplayName("Password")]
        [DataObjectField(false, false, false, 150)]
        [BindColumn("password", "", "nvarchar(150)")]
        public String Password { get => _Password; set { if (OnPropertyChanging("Password", value)) { _Password = value; OnPropertyChanged("Password"); } } }

        private String _Remark;
        /// <summary></summary>
        [DisplayName("Remark")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("remark", "", "nvarchar(255)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private String _userState;
        /// <summary></summary>
        [DisplayName("userState")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("userState", "", "nvarchar(50)")]
        public String userState { get => _userState; set { if (OnPropertyChanging("userState", value)) { _userState = value; OnPropertyChanged("userState"); } } }

        private Double _mapCenterLat;
        /// <summary></summary>
        [DisplayName("mapCenterLat")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("mapCenterLat", "", "float")]
        public Double mapCenterLat { get => _mapCenterLat; set { if (OnPropertyChanging("mapCenterLat", value)) { _mapCenterLat = value; OnPropertyChanged("mapCenterLat"); } } }

        private Double _mapCenterLng;
        /// <summary></summary>
        [DisplayName("mapCenterLng")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("mapCenterLng", "", "float")]
        public Double mapCenterLng { get => _mapCenterLng; set { if (OnPropertyChanging("mapCenterLng", value)) { _mapCenterLng = value; OnPropertyChanged("mapCenterLng"); } } }

        private Int32 _mapLevel;
        /// <summary></summary>
        [DisplayName("mapLevel")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("mapLevel", "", "int")]
        public Int32 mapLevel { get => _mapLevel; set { if (OnPropertyChanging("mapLevel", value)) { _mapLevel = value; OnPropertyChanged("mapLevel"); } } }

        private String _mapType;
        /// <summary></summary>
        [DisplayName("mapType")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("mapType", "", "nvarchar(50)")]
        public String mapType { get => _mapType; set { if (OnPropertyChanging("mapType", value)) { _mapType = value; OnPropertyChanged("mapType"); } } }

        private DateTime _updateTime;
        /// <summary></summary>
        [DisplayName("updateTime")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("updateTime", "", "datetime", Precision = 0, Scale = 3)]
        public DateTime updateTime { get => _updateTime; set { if (OnPropertyChanging("updateTime", value)) { _updateTime = value; OnPropertyChanged("updateTime"); } } }

        private Int32 _userFlag;
        /// <summary></summary>
        [DisplayName("userFlag")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("userFlag", "", "int")]
        public Int32 userFlag { get => _userFlag; set { if (OnPropertyChanging("userFlag", value)) { _userFlag = value; OnPropertyChanged("userFlag"); } } }

        private DateTime _createDate;
        /// <summary></summary>
        [DisplayName("createDate")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("createDate", "", "datetime", Precision = 0, Scale = 3)]
        public DateTime createDate { get => _createDate; set { if (OnPropertyChanging("createDate", value)) { _createDate = value; OnPropertyChanged("createDate"); } } }

        private Boolean _Deleted;
        /// <summary></summary>
        [DisplayName("Deleted")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("deleted", "", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private Int32 _tenantId;
        /// <summary></summary>
        [DisplayName("tenantId")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("tenantId", "", "int")]
        public Int32 tenantId { get => _tenantId; set { if (OnPropertyChanging("tenantId", value)) { _tenantId = value; OnPropertyChanged("tenantId"); } } }

        private String _Owner;
        /// <summary></summary>
        [DisplayName("Owner")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("owner", "", "nvarchar(50)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _UserType;
        /// <summary></summary>
        [DisplayName("UserType")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("UserType", "", "nvarchar(255)")]
        public String UserType { get => _UserType; set { if (OnPropertyChanging("UserType", value)) { _UserType = value; OnPropertyChanged("UserType"); } } }

        private String _Job;
        /// <summary></summary>
        [DisplayName("Job")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Job", "", "nvarchar(255)")]
        public String Job { get => _Job; set { if (OnPropertyChanging("Job", value)) { _Job = value; OnPropertyChanged("Job"); } } }

        private Int32 _Department;
        /// <summary></summary>
        [DisplayName("Department")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Department", "", "int")]
        public Int32 Department { get => _Department; set { if (OnPropertyChanging("Department", value)) { _Department = value; OnPropertyChanged("Department"); } } }

        private String _Phone;
        /// <summary></summary>
        [DisplayName("Phone")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Phone", "", "nvarchar(255)")]
        public String Phone { get => _Phone; set { if (OnPropertyChanging("Phone", value)) { _Phone = value; OnPropertyChanged("Phone"); } } }

        private String _Mail;
        /// <summary></summary>
        [DisplayName("Mail")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Mail", "", "nvarchar(255)")]
        public String Mail { get => _Mail; set { if (OnPropertyChanging("Mail", value)) { _Mail = value; OnPropertyChanged("Mail"); } } }

        private Int32 _regionId;
        /// <summary></summary>
        [DisplayName("regionId")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("regionId", "", "int")]
        public Int32 regionId { get => _regionId; set { if (OnPropertyChanging("regionId", value)) { _regionId = value; OnPropertyChanged("regionId"); } } }

        private DateTime _loginTime;
        /// <summary></summary>
        [DisplayName("loginTime")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("loginTime", "", "datetime", Precision = 0, Scale = 3)]
        public DateTime loginTime { get => _loginTime; set { if (OnPropertyChanging("loginTime", value)) { _loginTime = value; OnPropertyChanged("loginTime"); } } }

        private String _phoneNo;
        /// <summary></summary>
        [DisplayName("phoneNo")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("phoneNo", "", "nvarchar(50)")]
        public String phoneNo { get => _phoneNo; set { if (OnPropertyChanging("phoneNo", value)) { _phoneNo = value; OnPropertyChanged("phoneNo"); } } }
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
                    case "Name": return _Name;
                    case "loginName": return _loginName;
                    case "Password": return _Password;
                    case "Remark": return _Remark;
                    case "userState": return _userState;
                    case "mapCenterLat": return _mapCenterLat;
                    case "mapCenterLng": return _mapCenterLng;
                    case "mapLevel": return _mapLevel;
                    case "mapType": return _mapType;
                    case "updateTime": return _updateTime;
                    case "userFlag": return _userFlag;
                    case "createDate": return _createDate;
                    case "Deleted": return _Deleted;
                    case "tenantId": return _tenantId;
                    case "Owner": return _Owner;
                    case "UserType": return _UserType;
                    case "Job": return _Job;
                    case "Department": return _Department;
                    case "Phone": return _Phone;
                    case "Mail": return _Mail;
                    case "regionId": return _regionId;
                    case "loginTime": return _loginTime;
                    case "phoneNo": return _phoneNo;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "userId": _userId = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "loginName": _loginName = Convert.ToString(value); break;
                    case "Password": _Password = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "userState": _userState = Convert.ToString(value); break;
                    case "mapCenterLat": _mapCenterLat = value.ToDouble(); break;
                    case "mapCenterLng": _mapCenterLng = value.ToDouble(); break;
                    case "mapLevel": _mapLevel = value.ToInt(); break;
                    case "mapType": _mapType = Convert.ToString(value); break;
                    case "updateTime": _updateTime = value.ToDateTime(); break;
                    case "userFlag": _userFlag = value.ToInt(); break;
                    case "createDate": _createDate = value.ToDateTime(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "tenantId": _tenantId = value.ToInt(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "UserType": _UserType = Convert.ToString(value); break;
                    case "Job": _Job = Convert.ToString(value); break;
                    case "Department": _Department = value.ToInt(); break;
                    case "Phone": _Phone = Convert.ToString(value); break;
                    case "Mail": _Mail = Convert.ToString(value); break;
                    case "regionId": _regionId = value.ToInt(); break;
                    case "loginTime": _loginTime = value.ToDateTime(); break;
                    case "phoneNo": _phoneNo = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得用户信息字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field userId = FindByName("userId");

            /// <summary></summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary></summary>
            public static readonly Field loginName = FindByName("loginName");

            /// <summary></summary>
            public static readonly Field Password = FindByName("Password");

            /// <summary></summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary></summary>
            public static readonly Field userState = FindByName("userState");

            /// <summary></summary>
            public static readonly Field mapCenterLat = FindByName("mapCenterLat");

            /// <summary></summary>
            public static readonly Field mapCenterLng = FindByName("mapCenterLng");

            /// <summary></summary>
            public static readonly Field mapLevel = FindByName("mapLevel");

            /// <summary></summary>
            public static readonly Field mapType = FindByName("mapType");

            /// <summary></summary>
            public static readonly Field updateTime = FindByName("updateTime");

            /// <summary></summary>
            public static readonly Field userFlag = FindByName("userFlag");

            /// <summary></summary>
            public static readonly Field createDate = FindByName("createDate");

            /// <summary></summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary></summary>
            public static readonly Field tenantId = FindByName("tenantId");

            /// <summary></summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary></summary>
            public static readonly Field UserType = FindByName("UserType");

            /// <summary></summary>
            public static readonly Field Job = FindByName("Job");

            /// <summary></summary>
            public static readonly Field Department = FindByName("Department");

            /// <summary></summary>
            public static readonly Field Phone = FindByName("Phone");

            /// <summary></summary>
            public static readonly Field Mail = FindByName("Mail");

            /// <summary></summary>
            public static readonly Field regionId = FindByName("regionId");

            /// <summary></summary>
            public static readonly Field loginTime = FindByName("loginTime");

            /// <summary></summary>
            public static readonly Field phoneNo = FindByName("phoneNo");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得用户信息字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String userId = "userId";

            /// <summary></summary>
            public const String Name = "Name";

            /// <summary></summary>
            public const String loginName = "loginName";

            /// <summary></summary>
            public const String Password = "Password";

            /// <summary></summary>
            public const String Remark = "Remark";

            /// <summary></summary>
            public const String userState = "userState";

            /// <summary></summary>
            public const String mapCenterLat = "mapCenterLat";

            /// <summary></summary>
            public const String mapCenterLng = "mapCenterLng";

            /// <summary></summary>
            public const String mapLevel = "mapLevel";

            /// <summary></summary>
            public const String mapType = "mapType";

            /// <summary></summary>
            public const String updateTime = "updateTime";

            /// <summary></summary>
            public const String userFlag = "userFlag";

            /// <summary></summary>
            public const String createDate = "createDate";

            /// <summary></summary>
            public const String Deleted = "Deleted";

            /// <summary></summary>
            public const String tenantId = "tenantId";

            /// <summary></summary>
            public const String Owner = "Owner";

            /// <summary></summary>
            public const String UserType = "UserType";

            /// <summary></summary>
            public const String Job = "Job";

            /// <summary></summary>
            public const String Department = "Department";

            /// <summary></summary>
            public const String Phone = "Phone";

            /// <summary></summary>
            public const String Mail = "Mail";

            /// <summary></summary>
            public const String regionId = "regionId";

            /// <summary></summary>
            public const String loginTime = "loginTime";

            /// <summary></summary>
            public const String phoneNo = "phoneNo";
        }
        #endregion
    }
}