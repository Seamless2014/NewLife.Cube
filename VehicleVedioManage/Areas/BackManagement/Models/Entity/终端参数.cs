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
    /// <summary>终端参数</summary>
    [Serializable]
    [DataObject]
    [Description("终端参数")]
    [BindTable("TerminalParam", Description = "终端参数", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class TerminalParam
    {
        #region 属性
        private Int32 _ParamId;
        /// <summary>参数编码</summary>
        [Category("基本信息")]
        [DisplayName("参数编码")]
        [Description("参数编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("ParamId", "参数编码", "int")]
        public Int32 ParamId { get => _ParamId; set { if (OnPropertyChanging("ParamId", value)) { _ParamId = value; OnPropertyChanged("ParamId"); } } }

        private String _SimNo;
        /// <summary>Sim卡</summary>
        [Category("基本信息")]
        [DisplayName("Sim卡")]
        [Description("Sim卡")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("SimNo", "Sim卡", "nvarchar(255)")]
        public String SimNo { get => _SimNo; set { if (OnPropertyChanging("SimNo", value)) { _SimNo = value; OnPropertyChanged("SimNo"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [Category("基本信息")]
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(32)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private String _Code;
        /// <summary>代码</summary>
        [Category("基本信息")]
        [DisplayName("代码")]
        [Description("代码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Code", "代码", "nvarchar(255)")]
        public String Code { get => _Code; set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } } }

        private String _Value;
        /// <summary>值</summary>
        [Category("基本信息")]
        [DisplayName("值")]
        [Description("值")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Value", "值", "nvarchar(255)")]
        public String Value { get => _Value; set { if (OnPropertyChanging("Value", value)) { _Value = value; OnPropertyChanged("Value"); } } }

        private String _FieldType;
        /// <summary>字段类型</summary>
        [Category("基本信息")]
        [DisplayName("字段类型")]
        [Description("字段类型")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("FieldType", "字段类型", "nvarchar(20)")]
        public String FieldType { get => _FieldType; set { if (OnPropertyChanging("FieldType", value)) { _FieldType = value; OnPropertyChanged("FieldType"); } } }

        private DateTime _CreateDate;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateDate", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateDate { get => _CreateDate; set { if (OnPropertyChanging("CreateDate", value)) { _CreateDate = value; OnPropertyChanged("CreateDate"); } } }

        private DateTime _UpdateDate;
        /// <summary>更新时间</summary>
        [Category("基本信息")]
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateDate", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateDate { get => _UpdateDate; set { if (OnPropertyChanging("UpdateDate", value)) { _UpdateDate = value; OnPropertyChanged("UpdateDate"); } } }

        private String _Status;
        /// <summary>状态</summary>
        [Category("基本信息")]
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Status", "状态", "nvarchar(255)")]
        public String Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private Int32 _SN;
        /// <summary>序号</summary>
        [Category("基本信息")]
        [DisplayName("序号")]
        [Description("序号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("SN", "序号", "int")]
        public Int32 SN { get => _SN; set { if (OnPropertyChanging("SN", value)) { _SN = value; OnPropertyChanged("SN"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [Category("基本信息")]
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("基本信息")]
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [Category("基本信息")]
        [DisplayName("户主")]
        [Description("户主")]
        [DataObjectField(false, false, true, 55)]
        [BindColumn("Owner", "户主", "nvarchar(55)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 55)]
        [BindColumn("Remark", "备注", "nvarchar(55)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Int32 _CommandId;
        /// <summary>指令编码</summary>
        [Category("基本信息")]
        [DisplayName("指令编码")]
        [Description("指令编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("CommandId", "指令编码", "int")]
        public Int32 CommandId { get => _CommandId; set { if (OnPropertyChanging("CommandId", value)) { _CommandId = value; OnPropertyChanged("CommandId"); } } }

        private String _GPSId;
        /// <summary>GPS编码</summary>
        [Category("基本信息")]
        [DisplayName("GPS编码")]
        [Description("GPS编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("GPSId", "GPS编码", "nvarchar(255)")]
        public String GPSId { get => _GPSId; set { if (OnPropertyChanging("GPSId", value)) { _GPSId = value; OnPropertyChanged("GPSId"); } } }
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
                    case "ParamId": return _ParamId;
                    case "SimNo": return _SimNo;
                    case "PlateNo": return _PlateNo;
                    case "Code": return _Code;
                    case "Value": return _Value;
                    case "FieldType": return _FieldType;
                    case "CreateDate": return _CreateDate;
                    case "UpdateDate": return _UpdateDate;
                    case "Status": return _Status;
                    case "SN": return _SN;
                    case "TenantId": return _TenantId;
                    case "Deleted": return _Deleted;
                    case "Owner": return _Owner;
                    case "Remark": return _Remark;
                    case "CommandId": return _CommandId;
                    case "GPSId": return _GPSId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ParamId": _ParamId = value.ToInt(); break;
                    case "SimNo": _SimNo = Convert.ToString(value); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "Code": _Code = Convert.ToString(value); break;
                    case "Value": _Value = Convert.ToString(value); break;
                    case "FieldType": _FieldType = Convert.ToString(value); break;
                    case "CreateDate": _CreateDate = value.ToDateTime(); break;
                    case "UpdateDate": _UpdateDate = value.ToDateTime(); break;
                    case "Status": _Status = Convert.ToString(value); break;
                    case "SN": _SN = value.ToInt(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "CommandId": _CommandId = value.ToInt(); break;
                    case "GPSId": _GPSId = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得TerminalParam字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>参数编码</summary>
            public static readonly Field ParamId = FindByName("ParamId");

            /// <summary>Sim卡</summary>
            public static readonly Field SimNo = FindByName("SimNo");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>代码</summary>
            public static readonly Field Code = FindByName("Code");

            /// <summary>值</summary>
            public static readonly Field Value = FindByName("Value");

            /// <summary>字段类型</summary>
            public static readonly Field FieldType = FindByName("FieldType");

            /// <summary>创建时间</summary>
            public static readonly Field CreateDate = FindByName("CreateDate");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateDate = FindByName("UpdateDate");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>序号</summary>
            public static readonly Field SN = FindByName("SN");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>指令编码</summary>
            public static readonly Field CommandId = FindByName("CommandId");

            /// <summary>GPS编码</summary>
            public static readonly Field GPSId = FindByName("GPSId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得TerminalParam字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>参数编码</summary>
            public const String ParamId = "ParamId";

            /// <summary>Sim卡</summary>
            public const String SimNo = "SimNo";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>代码</summary>
            public const String Code = "Code";

            /// <summary>值</summary>
            public const String Value = "Value";

            /// <summary>字段类型</summary>
            public const String FieldType = "FieldType";

            /// <summary>创建时间</summary>
            public const String CreateDate = "CreateDate";

            /// <summary>更新时间</summary>
            public const String UpdateDate = "UpdateDate";

            /// <summary>状态</summary>
            public const String Status = "Status";

            /// <summary>序号</summary>
            public const String SN = "SN";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>指令编码</summary>
            public const String CommandId = "CommandId";

            /// <summary>GPS编码</summary>
            public const String GPSId = "GPSId";
        }
        #endregion
    }
}