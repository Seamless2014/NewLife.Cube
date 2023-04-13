using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.ReportStatistics.Entity
{
    /// <summary>驾驶记录</summary>
    [Serializable]
    [DataObject]
    [Description("驾驶记录")]
    [BindTable("DriverRecord", Description = "驾驶记录", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class DriverRecord
    {
        #region 属性
        private Int32 _DriverId;
        /// <summary>驾驶员编码</summary>
        [DisplayName("驾驶员编码")]
        [Description("驾驶员编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("DriverId", "驾驶员编码", "int")]
        public Int32 DriverId { get => _DriverId; set { if (OnPropertyChanging("DriverId", value)) { _DriverId = value; OnPropertyChanged("DriverId"); } } }

        private Int32 _CardState;
        /// <summary>卡片状态</summary>
        [DisplayName("卡片状态")]
        [Description("卡片状态")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("CardState", "卡片状态", "int")]
        public Int32 CardState { get => _CardState; set { if (OnPropertyChanging("CardState", value)) { _CardState = value; OnPropertyChanged("CardState"); } } }

        private DateTime _OperTime;
        /// <summary>运营时间</summary>
        [DisplayName("运营时间")]
        [Description("运营时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("OperTime", "运营时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime OperTime { get => _OperTime; set { if (OnPropertyChanging("OperTime", value)) { _OperTime = value; OnPropertyChanged("OperTime"); } } }

        private Int32 _ReadResult;
        /// <summary>读取结果</summary>
        [DisplayName("读取结果")]
        [Description("读取结果")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("ReadResult", "读取结果", "int")]
        public Int32 ReadResult { get => _ReadResult; set { if (OnPropertyChanging("ReadResult", value)) { _ReadResult = value; OnPropertyChanged("ReadResult"); } } }

        private String _DriverName;
        /// <summary>驾驶员姓名</summary>
        [DisplayName("驾驶员姓名")]
        [Description("驾驶员姓名")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("DriverName", "驾驶员姓名", "nvarchar(255)")]
        public String DriverName { get => _DriverName; set { if (OnPropertyChanging("DriverName", value)) { _DriverName = value; OnPropertyChanged("DriverName"); } } }

        private String _CertificationCode;
        /// <summary>认证代码</summary>
        [DisplayName("认证代码")]
        [Description("认证代码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("CertificationCode", "认证代码", "nvarchar(255)")]
        public String CertificationCode { get => _CertificationCode; set { if (OnPropertyChanging("CertificationCode", value)) { _CertificationCode = value; OnPropertyChanged("CertificationCode"); } } }

        private String _AgencyName;
        /// <summary>机构名称</summary>
        [DisplayName("机构名称")]
        [Description("机构名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("AgencyName", "机构名称", "nvarchar(255)")]
        public String AgencyName { get => _AgencyName; set { if (OnPropertyChanging("AgencyName", value)) { _AgencyName = value; OnPropertyChanged("AgencyName"); } } }

        private String _ValidateDate;
        /// <summary>验证日期</summary>
        [DisplayName("验证日期")]
        [Description("验证日期")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("ValidateDate", "验证日期", "nvarchar(255)")]
        public String ValidateDate { get => _ValidateDate; set { if (OnPropertyChanging("ValidateDate", value)) { _ValidateDate = value; OnPropertyChanged("ValidateDate"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VehicleId", "车辆编码", "int")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Remark", "备注", "nvarchar(255)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("扩展信息")]
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
                    case "DriverId": return _DriverId;
                    case "CardState": return _CardState;
                    case "OperTime": return _OperTime;
                    case "ReadResult": return _ReadResult;
                    case "DriverName": return _DriverName;
                    case "CertificationCode": return _CertificationCode;
                    case "AgencyName": return _AgencyName;
                    case "ValidateDate": return _ValidateDate;
                    case "VehicleId": return _VehicleId;
                    case "CreateTime": return _CreateTime;
                    case "Remark": return _Remark;
                    case "Deleted": return _Deleted;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "DriverId": _DriverId = value.ToInt(); break;
                    case "CardState": _CardState = value.ToInt(); break;
                    case "OperTime": _OperTime = value.ToDateTime(); break;
                    case "ReadResult": _ReadResult = value.ToInt(); break;
                    case "DriverName": _DriverName = Convert.ToString(value); break;
                    case "CertificationCode": _CertificationCode = Convert.ToString(value); break;
                    case "AgencyName": _AgencyName = Convert.ToString(value); break;
                    case "ValidateDate": _ValidateDate = Convert.ToString(value); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得驾驶记录字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>驾驶员编码</summary>
            public static readonly Field DriverId = FindByName("DriverId");

            /// <summary>卡片状态</summary>
            public static readonly Field CardState = FindByName("CardState");

            /// <summary>运营时间</summary>
            public static readonly Field OperTime = FindByName("OperTime");

            /// <summary>读取结果</summary>
            public static readonly Field ReadResult = FindByName("ReadResult");

            /// <summary>驾驶员姓名</summary>
            public static readonly Field DriverName = FindByName("DriverName");

            /// <summary>认证代码</summary>
            public static readonly Field CertificationCode = FindByName("CertificationCode");

            /// <summary>机构名称</summary>
            public static readonly Field AgencyName = FindByName("AgencyName");

            /// <summary>验证日期</summary>
            public static readonly Field ValidateDate = FindByName("ValidateDate");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得驾驶记录字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>驾驶员编码</summary>
            public const String DriverId = "DriverId";

            /// <summary>卡片状态</summary>
            public const String CardState = "CardState";

            /// <summary>运营时间</summary>
            public const String OperTime = "OperTime";

            /// <summary>读取结果</summary>
            public const String ReadResult = "ReadResult";

            /// <summary>驾驶员姓名</summary>
            public const String DriverName = "DriverName";

            /// <summary>认证代码</summary>
            public const String CertificationCode = "CertificationCode";

            /// <summary>机构名称</summary>
            public const String AgencyName = "AgencyName";

            /// <summary>验证日期</summary>
            public const String ValidateDate = "ValidateDate";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";
        }
        #endregion
    }
}