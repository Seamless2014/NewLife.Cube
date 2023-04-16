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
    /// <summary>燃料变化</summary>
    [Serializable]
    [DataObject]
    [Description("燃料变化")]
    [BindIndex("UQ__FuelChan__4A63C54DE23234F0", true, "EnclosureId")]
    [BindIndex("IX_FuelChangeRecord_PlateNo", false, "PlateNo")]
    [BindTable("FuelChangeRecord", Description = "燃料变化", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class FuelChangeRecord
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "编号", "")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("PlateNo", "车牌号", "")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private Double _Fuel;
        /// <summary>燃料</summary>
        [DisplayName("燃料")]
        [Description("燃料")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Fuel", "燃料", "")]
        public Double Fuel { get => _Fuel; set { if (OnPropertyChanging("Fuel", value)) { _Fuel = value; OnPropertyChanged("Fuel"); } } }

        private String _Type;
        /// <summary>燃料类型</summary>
        [DisplayName("燃料类型")]
        [Description("燃料类型")]
        [DataObjectField(false, false, true, 25)]
        [BindColumn("Type", "燃料类型", "")]
        public String Type { get => _Type; set { if (OnPropertyChanging("Type", value)) { _Type = value; OnPropertyChanged("Type"); } } }

        private DateTime _HappenTime;
        /// <summary>发生时间</summary>
        [DisplayName("发生时间")]
        [Description("发生时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("HappenTime", "发生时间", "", Precision = 0, Scale = 3)]
        public DateTime HappenTime { get => _HappenTime; set { if (OnPropertyChanging("HappenTime", value)) { _HappenTime = value; OnPropertyChanged("HappenTime"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _Manual;
        /// <summary>手动</summary>
        [DisplayName("手动")]
        [Description("手动")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("Manual", "手动", "")]
        public String Manual { get => _Manual; set { if (OnPropertyChanging("Manual", value)) { _Manual = value; OnPropertyChanged("Manual"); } } }

        private String _Location;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn("Location", "位置", "")]
        public String Location { get => _Location; set { if (OnPropertyChanging("Location", value)) { _Location = value; OnPropertyChanged("Location"); } } }

        private Double _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Latitude", "纬度", "")]
        public Double Latitude { get => _Latitude; set { if (OnPropertyChanging("Latitude", value)) { _Latitude = value; OnPropertyChanged("Latitude"); } } }

        private Double _Longitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Longitude", "经度", "")]
        public Double Longitude { get => _Longitude; set { if (OnPropertyChanging("Longitude", value)) { _Longitude = value; OnPropertyChanged("Longitude"); } } }

        private Double _Mileage;
        /// <summary>里程</summary>
        [DisplayName("里程")]
        [Description("里程")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Mileage", "里程", "")]
        public Double Mileage { get => _Mileage; set { if (OnPropertyChanging("Mileage", value)) { _Mileage = value; OnPropertyChanged("Mileage"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn("Owner", "物主", "")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Remark", "备注", "")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TenantId", "租户编码", "")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private Int32 _EnclosureId;
        /// <summary>围栏编码</summary>
        [DisplayName("围栏编码")]
        [Description("围栏编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("EnclosureId", "围栏编码", "")]
        public Int32 EnclosureId { get => _EnclosureId; set { if (OnPropertyChanging("EnclosureId", value)) { _EnclosureId = value; OnPropertyChanged("EnclosureId"); } } }
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
                    case "PlateNo": return _PlateNo;
                    case "Fuel": return _Fuel;
                    case "Type": return _Type;
                    case "HappenTime": return _HappenTime;
                    case "CreateTime": return _CreateTime;
                    case "Deleted": return _Deleted;
                    case "Manual": return _Manual;
                    case "Location": return _Location;
                    case "Latitude": return _Latitude;
                    case "Longitude": return _Longitude;
                    case "Mileage": return _Mileage;
                    case "Owner": return _Owner;
                    case "Remark": return _Remark;
                    case "TenantId": return _TenantId;
                    case "EnclosureId": return _EnclosureId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = value.ToInt(); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "Fuel": _Fuel = value.ToDouble(); break;
                    case "Type": _Type = Convert.ToString(value); break;
                    case "HappenTime": _HappenTime = value.ToDateTime(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Manual": _Manual = Convert.ToString(value); break;
                    case "Location": _Location = Convert.ToString(value); break;
                    case "Latitude": _Latitude = value.ToDouble(); break;
                    case "Longitude": _Longitude = value.ToDouble(); break;
                    case "Mileage": _Mileage = value.ToDouble(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "EnclosureId": _EnclosureId = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得燃料变化字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>燃料</summary>
            public static readonly Field Fuel = FindByName("Fuel");

            /// <summary>燃料类型</summary>
            public static readonly Field Type = FindByName("Type");

            /// <summary>发生时间</summary>
            public static readonly Field HappenTime = FindByName("HappenTime");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>手动</summary>
            public static readonly Field Manual = FindByName("Manual");

            /// <summary>位置</summary>
            public static readonly Field Location = FindByName("Location");

            /// <summary>纬度</summary>
            public static readonly Field Latitude = FindByName("Latitude");

            /// <summary>经度</summary>
            public static readonly Field Longitude = FindByName("Longitude");

            /// <summary>里程</summary>
            public static readonly Field Mileage = FindByName("Mileage");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>围栏编码</summary>
            public static readonly Field EnclosureId = FindByName("EnclosureId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得燃料变化字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String ID = "ID";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>燃料</summary>
            public const String Fuel = "Fuel";

            /// <summary>燃料类型</summary>
            public const String Type = "Type";

            /// <summary>发生时间</summary>
            public const String HappenTime = "HappenTime";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>手动</summary>
            public const String Manual = "Manual";

            /// <summary>位置</summary>
            public const String Location = "Location";

            /// <summary>纬度</summary>
            public const String Latitude = "Latitude";

            /// <summary>经度</summary>
            public const String Longitude = "Longitude";

            /// <summary>里程</summary>
            public const String Mileage = "Mileage";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>围栏编码</summary>
            public const String EnclosureId = "EnclosureId";
        }
        #endregion
    }
}