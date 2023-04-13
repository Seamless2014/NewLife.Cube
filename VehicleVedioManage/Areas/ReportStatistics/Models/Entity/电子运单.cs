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
    /// <summary>电子运单</summary>
    [Serializable]
    [DataObject]
    [Description("电子运单")]
    [BindTable("EWayBill", Description = "电子运单", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class EWayBill
    {
        #region 属性
        private Int32 _BillId;
        /// <summary>电子运单编码</summary>
        [DisplayName("电子运单编码")]
        [Description("电子运单编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("BillId", "电子运单编码", "int")]
        public Int32 BillId { get => _BillId; set { if (OnPropertyChanging("BillId", value)) { _BillId = value; OnPropertyChanged("BillId"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(50)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private Int32 _PlateColor;
        /// <summary>车牌颜色</summary>
        [DisplayName("车牌颜色")]
        [Description("车牌颜色")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("PlateColor", "车牌颜色", "int")]
        public Int32 PlateColor { get => _PlateColor; set { if (OnPropertyChanging("PlateColor", value)) { _PlateColor = value; OnPropertyChanged("PlateColor"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VehicleId", "车辆编码", "int")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private String _EBContent;
        /// <summary>电子运单内容</summary>
        [DisplayName("电子运单内容")]
        [Description("电子运单内容")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("EBContent", "电子运单内容", "nvarchar(500)")]
        public String EBContent { get => _EBContent; set { if (OnPropertyChanging("EBContent", value)) { _EBContent = value; OnPropertyChanged("EBContent"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [Category("扩展信息")]
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [Category("扩展信息")]
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "物主", "nvarchar(50)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("扩展信息")]
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Remark", "备注", "nvarchar(50)")]
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
                    case "BillId": return _BillId;
                    case "PlateNo": return _PlateNo;
                    case "PlateColor": return _PlateColor;
                    case "VehicleId": return _VehicleId;
                    case "EBContent": return _EBContent;
                    case "TenantId": return _TenantId;
                    case "CreateTime": return _CreateTime;
                    case "Owner": return _Owner;
                    case "Deleted": return _Deleted;
                    case "Remark": return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "BillId": _BillId = value.ToInt(); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "PlateColor": _PlateColor = value.ToInt(); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "EBContent": _EBContent = Convert.ToString(value); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得电子运单字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>电子运单编码</summary>
            public static readonly Field BillId = FindByName("BillId");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>车牌颜色</summary>
            public static readonly Field PlateColor = FindByName("PlateColor");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>电子运单内容</summary>
            public static readonly Field EBContent = FindByName("EBContent");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得电子运单字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>电子运单编码</summary>
            public const String BillId = "BillId";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>车牌颜色</summary>
            public const String PlateColor = "PlateColor";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>电子运单内容</summary>
            public const String EBContent = "EBContent";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>备注</summary>
            public const String Remark = "Remark";
        }
        #endregion
    }
}