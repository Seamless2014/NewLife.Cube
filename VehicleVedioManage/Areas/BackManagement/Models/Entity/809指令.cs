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
    /// <summary>809指令</summary>
    [Serializable]
    [DataObject]
    [Description("809指令")]
    [BindTable("JT809Command", Description = "809指令", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class JT809Command
    {
        #region 属性
        private Int32 _CmdId;
        /// <summary>指令编码</summary>
        [DisplayName("指令编码")]
        [Description("指令编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("CmdId", "指令编码", "int")]
        public Int32 CmdId { get => _CmdId; set { if (OnPropertyChanging("CmdId", value)) { _CmdId = value; OnPropertyChanged("CmdId"); } } }

        private String _SimNo;
        /// <summary>Sim卡</summary>
        [DisplayName("Sim卡")]
        [Description("Sim卡")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("SimNo", "Sim卡", "nvarchar(255)")]
        public String SimNo { get => _SimNo; set { if (OnPropertyChanging("SimNo", value)) { _SimNo = value; OnPropertyChanged("SimNo"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(255)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private String _Descr;
        /// <summary>描述</summary>
        [DisplayName("描述")]
        [Description("描述")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Descr", "描述", "nvarchar(255)")]
        public String Descr { get => _Descr; set { if (OnPropertyChanging("Descr", value)) { _Descr = value; OnPropertyChanged("Descr"); } } }

        private Int32 _Cmd;
        /// <summary>指令</summary>
        [DisplayName("指令")]
        [Description("指令")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Cmd", "指令", "int")]
        public Int32 Cmd { get => _Cmd; set { if (OnPropertyChanging("Cmd", value)) { _Cmd = value; OnPropertyChanged("Cmd"); } } }

        private String _CmdData;
        /// <summary>指令数据</summary>
        [DisplayName("指令数据")]
        [Description("指令数据")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("CmdData", "指令数据", "nvarchar(255)")]
        public String CmdData { get => _CmdData; set { if (OnPropertyChanging("CmdData", value)) { _CmdData = value; OnPropertyChanged("CmdData"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Owner", "物主", "nvarchar(255)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Status;
        /// <summary></summary>
        [DisplayName("Status")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Status", "", "nvarchar(255)")]
        public String Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Remark", "备注", "nvarchar(255)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Int32 _SN;
        /// <summary>序号</summary>
        [DisplayName("序号")]
        [Description("序号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("SN", "序号", "int")]
        public Int32 SN { get => _SN; set { if (OnPropertyChanging("SN", value)) { _SN = value; OnPropertyChanged("SN"); } } }

        private Int32 _UserId;
        /// <summary>用户编码</summary>
        [DisplayName("用户编码")]
        [Description("用户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("UserId", "用户编码", "int")]
        public Int32 UserId { get => _UserId; set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private Byte _PlateColor;
        /// <summary>车牌颜色</summary>
        [DisplayName("车牌颜色")]
        [Description("车牌颜色")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("PlateColor", "车牌颜色", "tinyint")]
        public Byte PlateColor { get => _PlateColor; set { if (OnPropertyChanging("PlateColor", value)) { _PlateColor = value; OnPropertyChanged("PlateColor"); } } }

        private Int32 _SubCmd;
        /// <summary>子指令</summary>
        [DisplayName("子指令")]
        [Description("子指令")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("SubCmd", "子指令", "int")]
        public Int32 SubCmd { get => _SubCmd; set { if (OnPropertyChanging("SubCmd", value)) { _SubCmd = value; OnPropertyChanged("SubCmd"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private String _Source;
        /// <summary>源</summary>
        [DisplayName("源")]
        [Description("源")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Source", "源", "nvarchar(50)")]
        public String Source { get => _Source; set { if (OnPropertyChanging("Source", value)) { _Source = value; OnPropertyChanged("Source"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateTime", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private String _GpsId;
        /// <summary>GPS编码</summary>
        [DisplayName("GPS编码")]
        [Description("GPS编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("GpsId", "GPS编码", "nvarchar(255)")]
        public String GpsId { get => _GpsId; set { if (OnPropertyChanging("GpsId", value)) { _GpsId = value; OnPropertyChanged("GpsId"); } } }

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
                    case "SimNo": return _SimNo;
                    case "PlateNo": return _PlateNo;
                    case "Descr": return _Descr;
                    case "Cmd": return _Cmd;
                    case "CmdData": return _CmdData;
                    case "CreateTime": return _CreateTime;
                    case "Owner": return _Owner;
                    case "Status": return _Status;
                    case "Remark": return _Remark;
                    case "SN": return _SN;
                    case "UserId": return _UserId;
                    case "Deleted": return _Deleted;
                    case "PlateColor": return _PlateColor;
                    case "SubCmd": return _SubCmd;
                    case "TenantId": return _TenantId;
                    case "Source": return _Source;
                    case "UpdateTime": return _UpdateTime;
                    case "GpsId": return _GpsId;
                    case "Data": return _Data;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "CmdId": _CmdId = value.ToInt(); break;
                    case "SimNo": _SimNo = Convert.ToString(value); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "Descr": _Descr = Convert.ToString(value); break;
                    case "Cmd": _Cmd = value.ToInt(); break;
                    case "CmdData": _CmdData = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Status": _Status = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "SN": _SN = value.ToInt(); break;
                    case "UserId": _UserId = value.ToInt(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "PlateColor": _PlateColor = Convert.ToByte(value); break;
                    case "SubCmd": _SubCmd = value.ToInt(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Source": _Source = Convert.ToString(value); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    case "GpsId": _GpsId = Convert.ToString(value); break;
                    case "Data": _Data = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得809指令字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>指令编码</summary>
            public static readonly Field CmdId = FindByName("CmdId");

            /// <summary>Sim卡</summary>
            public static readonly Field SimNo = FindByName("SimNo");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>描述</summary>
            public static readonly Field Descr = FindByName("Descr");

            /// <summary>指令</summary>
            public static readonly Field Cmd = FindByName("Cmd");

            /// <summary>指令数据</summary>
            public static readonly Field CmdData = FindByName("CmdData");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary></summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>序号</summary>
            public static readonly Field SN = FindByName("SN");

            /// <summary>用户编码</summary>
            public static readonly Field UserId = FindByName("UserId");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>车牌颜色</summary>
            public static readonly Field PlateColor = FindByName("PlateColor");

            /// <summary>子指令</summary>
            public static readonly Field SubCmd = FindByName("SubCmd");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>源</summary>
            public static readonly Field Source = FindByName("Source");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            /// <summary>GPS编码</summary>
            public static readonly Field GpsId = FindByName("GpsId");

            /// <summary>数据</summary>
            public static readonly Field Data = FindByName("Data");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得809指令字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>指令编码</summary>
            public const String CmdId = "CmdId";

            /// <summary>Sim卡</summary>
            public const String SimNo = "SimNo";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>描述</summary>
            public const String Descr = "Descr";

            /// <summary>指令</summary>
            public const String Cmd = "Cmd";

            /// <summary>指令数据</summary>
            public const String CmdData = "CmdData";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary></summary>
            public const String Status = "Status";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>序号</summary>
            public const String SN = "SN";

            /// <summary>用户编码</summary>
            public const String UserId = "UserId";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>车牌颜色</summary>
            public const String PlateColor = "PlateColor";

            /// <summary>子指令</summary>
            public const String SubCmd = "SubCmd";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>源</summary>
            public const String Source = "Source";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            /// <summary>GPS编码</summary>
            public const String GpsId = "GpsId";

            /// <summary>数据</summary>
            public const String Data = "Data";
        }
        #endregion
    }
}