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
    /// <summary>油箱</summary>
    [Serializable]
    [DataObject]
    [Description("油箱")]
    [BindTable("FuelTank", Description = "油箱", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class FuelTank
    {
        #region 属性
        private Int32 _TankId;
        /// <summary>油箱编码</summary>
        [DisplayName("油箱编码")]
        [Description("油箱编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("TankId", "油箱编码", "int")]
        public Int32 TankId { get => _TankId; set { if (OnPropertyChanging("TankId", value)) { _TankId = value; OnPropertyChanged("TankId"); } } }

        private String _TankType;
        /// <summary>油箱类型</summary>
        [DisplayName("油箱类型")]
        [Description("油箱类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("TankType", "油箱类型", "nvarchar(255)")]
        public String TankType { get => _TankType; set { if (OnPropertyChanging("TankType", value)) { _TankType = value; OnPropertyChanged("TankType"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VehicleId", "车辆编码", "int")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private Int32 _TankNo;
        /// <summary>油箱编号</summary>
        [DisplayName("油箱编号")]
        [Description("油箱编号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TankNo", "油箱编号", "int")]
        public Int32 TankNo { get => _TankNo; set { if (OnPropertyChanging("TankNo", value)) { _TankNo = value; OnPropertyChanged("TankNo"); } } }

        private Decimal _Width;
        /// <summary>宽</summary>
        [DisplayName("宽")]
        [Description("宽")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn("Width", "宽", "decimal(8, 2)", Precision = 0, Scale = 2)]
        public Decimal Width { get => _Width; set { if (OnPropertyChanging("Width", value)) { _Width = value; OnPropertyChanged("Width"); } } }

        private Decimal _Length;
        /// <summary>长</summary>
        [DisplayName("长")]
        [Description("长")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn("Length", "长", "decimal(8, 2)", Precision = 0, Scale = 2)]
        public Decimal Length { get => _Length; set { if (OnPropertyChanging("Length", value)) { _Length = value; OnPropertyChanged("Length"); } } }

        private Decimal _Height;
        /// <summary>高</summary>
        [DisplayName("高")]
        [Description("高")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn("Height", "高", "decimal(8, 2)", Precision = 0, Scale = 2)]
        public Decimal Height { get => _Height; set { if (OnPropertyChanging("Height", value)) { _Height = value; OnPropertyChanged("Height"); } } }

        private Decimal _SensorLength;
        /// <summary>传感器长度</summary>
        [DisplayName("传感器长度")]
        [Description("传感器长度")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn("SensorLength", "传感器长度", "decimal(8, 2)", Precision = 0, Scale = 2)]
        public Decimal SensorLength { get => _SensorLength; set { if (OnPropertyChanging("SensorLength", value)) { _SensorLength = value; OnPropertyChanged("SensorLength"); } } }

        private Decimal _Capacity;
        /// <summary>容量</summary>
        [DisplayName("容量")]
        [Description("容量")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn("Capacity", "容量", "decimal(8, 2)", Precision = 0, Scale = 2)]
        public Decimal Capacity { get => _Capacity; set { if (OnPropertyChanging("Capacity", value)) { _Capacity = value; OnPropertyChanged("Capacity"); } } }

        private Decimal _Radius;
        /// <summary>半径</summary>
        [DisplayName("半径")]
        [Description("半径")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn("Radius", "半径", "decimal(8, 2)", Precision = 0, Scale = 2)]
        public Decimal Radius { get => _Radius; set { if (OnPropertyChanging("Radius", value)) { _Radius = value; OnPropertyChanged("Radius"); } } }

        private Decimal _BlindHeight;
        /// <summary>盲板高度</summary>
        [DisplayName("盲板高度")]
        [Description("盲板高度")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn("BlindHeight", "盲板高度", "decimal(8, 2)", Precision = 0, Scale = 2)]
        public Decimal BlindHeight { get => _BlindHeight; set { if (OnPropertyChanging("BlindHeight", value)) { _BlindHeight = value; OnPropertyChanged("BlindHeight"); } } }

        private Decimal _NormalFuelConsum;
        /// <summary>正常燃料消耗</summary>
        [DisplayName("正常燃料消耗")]
        [Description("正常燃料消耗")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn("NormalFuelConsum", "正常燃料消耗", "decimal(8, 2)", Precision = 0, Scale = 2)]
        public Decimal NormalFuelConsum { get => _NormalFuelConsum; set { if (OnPropertyChanging("NormalFuelConsum", value)) { _NormalFuelConsum = value; OnPropertyChanged("NormalFuelConsum"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Remark", "备注", "nvarchar(255)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Owner", "物主", "nvarchar(255)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }
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
                    case "TankId": return _TankId;
                    case "TankType": return _TankType;
                    case "VehicleId": return _VehicleId;
                    case "TankNo": return _TankNo;
                    case "Width": return _Width;
                    case "Length": return _Length;
                    case "Height": return _Height;
                    case "SensorLength": return _SensorLength;
                    case "Capacity": return _Capacity;
                    case "Radius": return _Radius;
                    case "BlindHeight": return _BlindHeight;
                    case "NormalFuelConsum": return _NormalFuelConsum;
                    case "Remark": return _Remark;
                    case "Deleted": return _Deleted;
                    case "Owner": return _Owner;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "TankId": _TankId = value.ToInt(); break;
                    case "TankType": _TankType = Convert.ToString(value); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "TankNo": _TankNo = value.ToInt(); break;
                    case "Width": _Width = Convert.ToDecimal(value); break;
                    case "Length": _Length = Convert.ToDecimal(value); break;
                    case "Height": _Height = Convert.ToDecimal(value); break;
                    case "SensorLength": _SensorLength = Convert.ToDecimal(value); break;
                    case "Capacity": _Capacity = Convert.ToDecimal(value); break;
                    case "Radius": _Radius = Convert.ToDecimal(value); break;
                    case "BlindHeight": _BlindHeight = Convert.ToDecimal(value); break;
                    case "NormalFuelConsum": _NormalFuelConsum = Convert.ToDecimal(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得油箱字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>油箱编码</summary>
            public static readonly Field TankId = FindByName("TankId");

            /// <summary>油箱类型</summary>
            public static readonly Field TankType = FindByName("TankType");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>油箱编号</summary>
            public static readonly Field TankNo = FindByName("TankNo");

            /// <summary>宽</summary>
            public static readonly Field Width = FindByName("Width");

            /// <summary>长</summary>
            public static readonly Field Length = FindByName("Length");

            /// <summary>高</summary>
            public static readonly Field Height = FindByName("Height");

            /// <summary>传感器长度</summary>
            public static readonly Field SensorLength = FindByName("SensorLength");

            /// <summary>容量</summary>
            public static readonly Field Capacity = FindByName("Capacity");

            /// <summary>半径</summary>
            public static readonly Field Radius = FindByName("Radius");

            /// <summary>盲板高度</summary>
            public static readonly Field BlindHeight = FindByName("BlindHeight");

            /// <summary>正常燃料消耗</summary>
            public static readonly Field NormalFuelConsum = FindByName("NormalFuelConsum");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得油箱字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>油箱编码</summary>
            public const String TankId = "TankId";

            /// <summary>油箱类型</summary>
            public const String TankType = "TankType";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>油箱编号</summary>
            public const String TankNo = "TankNo";

            /// <summary>宽</summary>
            public const String Width = "Width";

            /// <summary>长</summary>
            public const String Length = "Length";

            /// <summary>高</summary>
            public const String Height = "Height";

            /// <summary>传感器长度</summary>
            public const String SensorLength = "SensorLength";

            /// <summary>容量</summary>
            public const String Capacity = "Capacity";

            /// <summary>半径</summary>
            public const String Radius = "Radius";

            /// <summary>盲板高度</summary>
            public const String BlindHeight = "BlindHeight";

            /// <summary>正常燃料消耗</summary>
            public const String NormalFuelConsum = "NormalFuelConsum";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>物主</summary>
            public const String Owner = "Owner";
        }
        #endregion
    }
}