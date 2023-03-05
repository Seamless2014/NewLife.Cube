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
    /// <summary>终端指令</summary>
    [Serializable]
    [DataObject]
    [Description("终端指令")]
    [BindTable("TerminalCommand", Description = "终端指令", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class TerminalCommand
    {
        #region 属性
        private Int32 _CmdId;
        /// <summary>指令编码</summary>
        [DisplayName("指令编码")]
        [Description("指令编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("CmdId", "指令编码", "int")]
        public Int32 CmdId { get => _CmdId; set { if (OnPropertyChanging("CmdId", value)) { _CmdId = value; OnPropertyChanged("CmdId"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(50)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private Int32 _CmdType;
        /// <summary>指令类型</summary>
        [DisplayName("指令类型")]
        [Description("指令类型")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("CmdType", "指令类型", "int")]
        public Int32 CmdType { get => _CmdType; set { if (OnPropertyChanging("CmdType", value)) { _CmdType = value; OnPropertyChanged("CmdType"); } } }

        private String _Cmd;
        /// <summary>指令</summary>
        [DisplayName("指令")]
        [Description("指令")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CMD", "指令", "nvarchar(50)")]
        public String Cmd { get => _Cmd; set { if (OnPropertyChanging("Cmd", value)) { _Cmd = value; OnPropertyChanged("Cmd"); } } }

        private String _CmdData;
        /// <summary>指令数据</summary>
        [DisplayName("指令数据")]
        [Description("指令数据")]
        [DataObjectField(false, false, true, 2500)]
        [BindColumn("CmdData", "指令数据", "nvarchar(2500)")]
        public String CmdData { get => _CmdData; set { if (OnPropertyChanging("CmdData", value)) { _CmdData = value; OnPropertyChanged("CmdData"); } } }

        private DateTime _CreateDate;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateDate", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateDate { get => _CreateDate; set { if (OnPropertyChanging("CreateDate", value)) { _CreateDate = value; OnPropertyChanged("CreateDate"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _SimNo;
        /// <summary>Sim卡</summary>
        [DisplayName("Sim卡")]
        [Description("Sim卡")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("SimNo", "Sim卡", "nvarchar(50)")]
        public String SimNo { get => _SimNo; set { if (OnPropertyChanging("SimNo", value)) { _SimNo = value; OnPropertyChanged("SimNo"); } } }

        private String _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Status", "状态", "nvarchar(50)")]
        public String Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn("Remark", "备注", "nvarchar(100)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [DisplayName("拥有者")]
        [Description("拥有者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "拥有者", "nvarchar(50)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private Int32 _UserId;
        /// <summary>用户编码</summary>
        [DisplayName("用户编码")]
        [Description("用户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("UserId", "用户编码", "int")]
        public Int32 UserId { get => _UserId; set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } } }

        private Int32 _SN;
        /// <summary>序号</summary>
        [DisplayName("序号")]
        [Description("序号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("SN", "序号", "int")]
        public Int32 SN { get => _SN; set { if (OnPropertyChanging("SN", value)) { _SN = value; OnPropertyChanged("SN"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private DateTime _UpdateDate;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateDate", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateDate { get => _UpdateDate; set { if (OnPropertyChanging("UpdateDate", value)) { _UpdateDate = value; OnPropertyChanged("UpdateDate"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("VehicleId", "车辆编码", "int")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private String _Data;
        /// <summary>数据</summary>
        [DisplayName("数据")]
        [Description("数据")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Data", "数据", "nvarchar(255)")]
        public String Data { get => _Data; set { if (OnPropertyChanging("Data", value)) { _Data = value; OnPropertyChanged("Data"); } } }
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
                    case "CmdId": return _CmdId;
                    case "PlateNo": return _PlateNo;
                    case "CmdType": return _CmdType;
                    case "Cmd": return _Cmd;
                    case "CmdData": return _CmdData;
                    case "CreateDate": return _CreateDate;
                    case "Deleted": return _Deleted;
                    case "SimNo": return _SimNo;
                    case "Status": return _Status;
                    case "Remark": return _Remark;
                    case "Owner": return _Owner;
                    case "UserId": return _UserId;
                    case "SN": return _SN;
                    case "TenantId": return _TenantId;
                    case "UpdateDate": return _UpdateDate;
                    case "VehicleId": return _VehicleId;
                    case "Data": return _Data;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "CmdId": _CmdId = value.ToInt(); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "CmdType": _CmdType = value.ToInt(); break;
                    case "Cmd": _Cmd = Convert.ToString(value); break;
                    case "CmdData": _CmdData = Convert.ToString(value); break;
                    case "CreateDate": _CreateDate = value.ToDateTime(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "SimNo": _SimNo = Convert.ToString(value); break;
                    case "Status": _Status = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "UserId": _UserId = value.ToInt(); break;
                    case "SN": _SN = value.ToInt(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "UpdateDate": _UpdateDate = value.ToDateTime(); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "Data": _Data = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得终端指令字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>指令编码</summary>
            public static readonly Field CmdId = FindByName("CmdId");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>指令类型</summary>
            public static readonly Field CmdType = FindByName("CmdType");

            /// <summary>指令</summary>
            public static readonly Field Cmd = FindByName("Cmd");

            /// <summary>指令数据</summary>
            public static readonly Field CmdData = FindByName("CmdData");

            /// <summary>创建时间</summary>
            public static readonly Field CreateDate = FindByName("CreateDate");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>Sim卡</summary>
            public static readonly Field SimNo = FindByName("SimNo");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>用户编码</summary>
            public static readonly Field UserId = FindByName("UserId");

            /// <summary>序号</summary>
            public static readonly Field SN = FindByName("SN");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateDate = FindByName("UpdateDate");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>数据</summary>
            public static readonly Field Data = FindByName("Data");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得终端指令字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>指令编码</summary>
            public const String CmdId = "CmdId";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>指令类型</summary>
            public const String CmdType = "CmdType";

            /// <summary>指令</summary>
            public const String Cmd = "Cmd";

            /// <summary>指令数据</summary>
            public const String CmdData = "CmdData";

            /// <summary>创建时间</summary>
            public const String CreateDate = "CreateDate";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>Sim卡</summary>
            public const String SimNo = "SimNo";

            /// <summary>状态</summary>
            public const String Status = "Status";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";

            /// <summary>用户编码</summary>
            public const String UserId = "UserId";

            /// <summary>序号</summary>
            public const String SN = "SN";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>更新时间</summary>
            public const String UpdateDate = "UpdateDate";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>数据</summary>
            public const String Data = "Data";
        }
        #endregion
    }
}