using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.FenceManagement.Entity
{
    /// <summary>地图区域</summary>
    [Serializable]
    [DataObject]
    [Description("地图区域")]
    [BindTable("MapArea", Description = "地图区域", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class MapArea
    {
        #region 属性
        private Int32 _AreaId;
        /// <summary>区域编码</summary>
        [DisplayName("区域编码")]
        [Description("区域编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("AreaId", "区域编码", "int")]
        public Int32 AreaId { get => _AreaId; set { if (OnPropertyChanging("AreaId", value)) { _AreaId = value; OnPropertyChanged("AreaId"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [Category("扩展信息")]
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("TenantId", "租户编码", "int")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(255)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private String _GPSId;
        /// <summary>GPS编码</summary>
        [Category("扩展信息")]
        [DisplayName("GPS编码")]
        [Description("GPS编码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("GPSId", "GPS编码", "nvarchar(255)")]
        public String GPSId { get => _GPSId; set { if (OnPropertyChanging("GPSId", value)) { _GPSId = value; OnPropertyChanged("GPSId"); } } }

        private String _Points;
        /// <summary>点位</summary>
        [DisplayName("点位")]
        [Description("点位")]
        [DataObjectField(false, false, true, 2550)]
        [BindColumn("Points", "点位", "nvarchar(2550)")]
        public String Points { get => _Points; set { if (OnPropertyChanging("Points", value)) { _Points = value; OnPropertyChanged("Points"); } } }

        private String _Name;
        /// <summary>名字</summary>
        [DisplayName("名字")]
        [Description("名字")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Name", "名字", "nvarchar(255)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private Int32 _Radius;
        /// <summary>半径</summary>
        [DisplayName("半径")]
        [Description("半径")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Radius", "半径", "int")]
        public Int32 Radius { get => _Radius; set { if (OnPropertyChanging("Radius", value)) { _Radius = value; OnPropertyChanged("Radius"); } } }

        private Int32 _Delay;
        /// <summary>延时</summary>
        [DisplayName("延时")]
        [Description("延时")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Delay", "延时", "int")]
        public Int32 Delay { get => _Delay; set { if (OnPropertyChanging("Delay", value)) { _Delay = value; OnPropertyChanged("Delay"); } } }

        private Int32 _OffsetDelay;
        /// <summary>偏移延迟</summary>
        [DisplayName("偏移延迟")]
        [Description("偏移延迟")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("OffsetDelay", "偏移延迟", "int")]
        public Int32 OffsetDelay { get => _OffsetDelay; set { if (OnPropertyChanging("OffsetDelay", value)) { _OffsetDelay = value; OnPropertyChanged("OffsetDelay"); } } }

        private Int32 _SN;
        /// <summary>序号</summary>
        [Category("扩展信息")]
        [DisplayName("序号")]
        [Description("序号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("SN", "序号", "int")]
        public Int32 SN { get => _SN; set { if (OnPropertyChanging("SN", value)) { _SN = value; OnPropertyChanged("SN"); } } }

        private String _AreaType;
        /// <summary>区域类型</summary>
        [DisplayName("区域类型")]
        [Description("区域类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("AreaType", "区域类型", "nvarchar(255)")]
        public String AreaType { get => _AreaType; set { if (OnPropertyChanging("AreaType", value)) { _AreaType = value; OnPropertyChanged("AreaType"); } } }

        private String _AlarmType;
        /// <summary>报警类型</summary>
        [DisplayName("报警类型")]
        [Description("报警类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("AlarmType", "报警类型", "nvarchar(255)")]
        public String AlarmType { get => _AlarmType; set { if (OnPropertyChanging("AlarmType", value)) { _AlarmType = value; OnPropertyChanged("AlarmType"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private DateTime _StartDate;
        /// <summary>开始时间</summary>
        [DisplayName("开始时间")]
        [Description("开始时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("StartDate", "开始时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime StartDate { get => _StartDate; set { if (OnPropertyChanging("StartDate", value)) { _StartDate = value; OnPropertyChanged("StartDate"); } } }

        private DateTime _EndDate;
        /// <summary>结束时间</summary>
        [DisplayName("结束时间")]
        [Description("结束时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("EndDate", "结束时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime EndDate { get => _EndDate; set { if (OnPropertyChanging("EndDate", value)) { _EndDate = value; OnPropertyChanged("EndDate"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("扩展信息")]
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private Boolean _LimitSpeed;
        /// <summary>限速</summary>
        [DisplayName("限速")]
        [Description("限速")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("LimitSpeed", "限速", "bit")]
        public Boolean LimitSpeed { get => _LimitSpeed; set { if (OnPropertyChanging("LimitSpeed", value)) { _LimitSpeed = value; OnPropertyChanged("LimitSpeed"); } } }

        private Double _MaxSpeed;
        /// <summary>最大速度</summary>
        [DisplayName("最大速度")]
        [Description("最大速度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("MaxSpeed", "最大速度", "float")]
        public Double MaxSpeed { get => _MaxSpeed; set { if (OnPropertyChanging("MaxSpeed", value)) { _MaxSpeed = value; OnPropertyChanged("MaxSpeed"); } } }

        private Boolean _ByTime;
        /// <summary>按时间</summary>
        [DisplayName("按时间")]
        [Description("按时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("ByTime", "按时间", "bit")]
        public Boolean ByTime { get => _ByTime; set { if (OnPropertyChanging("ByTime", value)) { _ByTime = value; OnPropertyChanged("ByTime"); } } }

        private Boolean _GatherRegion;
        /// <summary>聚集区</summary>
        [DisplayName("聚集区")]
        [Description("聚集区")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("GatherRegion", "聚集区", "bit")]
        public Boolean GatherRegion { get => _GatherRegion; set { if (OnPropertyChanging("GatherRegion", value)) { _GatherRegion = value; OnPropertyChanged("GatherRegion"); } } }

        private Boolean _SensitiveRegion;
        /// <summary>敏感区</summary>
        [DisplayName("敏感区")]
        [Description("敏感区")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("SensitiveRegion", "敏感区", "bit")]
        public Boolean SensitiveRegion { get => _SensitiveRegion; set { if (OnPropertyChanging("SensitiveRegion", value)) { _SensitiveRegion = value; OnPropertyChanged("SensitiveRegion"); } } }

        private Int32 _GatherNum;
        /// <summary>聚集数</summary>
        [DisplayName("聚集数")]
        [Description("聚集数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("GatherNum", "聚集数", "int")]
        public Int32 GatherNum { get => _GatherNum; set { if (OnPropertyChanging("GatherNum", value)) { _GatherNum = value; OnPropertyChanged("GatherNum"); } } }

        private Double _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Latitude", "纬度", "float")]
        public Double Latitude { get => _Latitude; set { if (OnPropertyChanging("Latitude", value)) { _Latitude = value; OnPropertyChanged("Latitude"); } } }

        private Double _Longitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Longitude", "经度", "float")]
        public Double Longitude { get => _Longitude; set { if (OnPropertyChanging("Longitude", value)) { _Longitude = value; OnPropertyChanged("Longitude"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [Category("扩展信息")]
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 45)]
        [BindColumn("Owner", "物主", "nvarchar(45)")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Remark", "备注", "nvarchar(500)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Double _LineWidth;
        /// <summary>线宽</summary>
        [DisplayName("线宽")]
        [Description("线宽")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("LineWidth", "线宽", "float")]
        public Double LineWidth { get => _LineWidth; set { if (OnPropertyChanging("LineWidth", value)) { _LineWidth = value; OnPropertyChanged("LineWidth"); } } }

        private String _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Status", "状态", "nvarchar(50)")]
        public String Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private Double _CenterLat;
        /// <summary>中心纬度</summary>
        [DisplayName("中心纬度")]
        [Description("中心纬度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("CenterLat", "中心纬度", "float")]
        public Double CenterLat { get => _CenterLat; set { if (OnPropertyChanging("CenterLat", value)) { _CenterLat = value; OnPropertyChanged("CenterLat"); } } }

        private Double _CenterLng;
        /// <summary>中心经度</summary>
        [DisplayName("中心经度")]
        [Description("中心经度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("CenterLng", "中心经度", "float")]
        public Double CenterLng { get => _CenterLng; set { if (OnPropertyChanging("CenterLng", value)) { _CenterLng = value; OnPropertyChanged("CenterLng"); } } }

        private Int32 _keyPoint;
        /// <summary>关键点</summary>
        [DisplayName("关键点")]
        [Description("关键点")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("keyPoint", "关键点", "int")]
        public Int32 keyPoint { get => _keyPoint; set { if (OnPropertyChanging("keyPoint", value)) { _keyPoint = value; OnPropertyChanged("keyPoint"); } } }

        private String _MapType;
        /// <summary>地图类型</summary>
        [DisplayName("地图类型")]
        [Description("地图类型")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("MapType", "地图类型", "nvarchar(50)")]
        public String MapType { get => _MapType; set { if (OnPropertyChanging("MapType", value)) { _MapType = value; OnPropertyChanged("MapType"); } } }

        private Int32 _DepId;
        /// <summary>部门编码</summary>
        [DisplayName("部门编码")]
        [Description("部门编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("DepId", "部门编码", "int")]
        public Int32 DepId { get => _DepId; set { if (OnPropertyChanging("DepId", value)) { _DepId = value; OnPropertyChanged("DepId"); } } }

        private String _Icon;
        /// <summary>图标</summary>
        [DisplayName("图标")]
        [Description("图标")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Icon", "图标", "varchar(255)")]
        public String Icon { get => _Icon; set { if (OnPropertyChanging("Icon", value)) { _Icon = value; OnPropertyChanged("Icon"); } } }

        private String _BusinessType;
        /// <summary>业务类型</summary>
        [DisplayName("业务类型")]
        [Description("业务类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("BusinessType", "业务类型", "nvarchar(255)")]
        public String BusinessType { get => _BusinessType; set { if (OnPropertyChanging("BusinessType", value)) { _BusinessType = value; OnPropertyChanged("BusinessType"); } } }
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
                    case "AreaId": return _AreaId;
                    case "TenantId": return _TenantId;
                    case "PlateNo": return _PlateNo;
                    case "GPSId": return _GPSId;
                    case "Points": return _Points;
                    case "Name": return _Name;
                    case "Radius": return _Radius;
                    case "Delay": return _Delay;
                    case "OffsetDelay": return _OffsetDelay;
                    case "SN": return _SN;
                    case "AreaType": return _AreaType;
                    case "AlarmType": return _AlarmType;
                    case "CreateTime": return _CreateTime;
                    case "StartDate": return _StartDate;
                    case "EndDate": return _EndDate;
                    case "Deleted": return _Deleted;
                    case "LimitSpeed": return _LimitSpeed;
                    case "MaxSpeed": return _MaxSpeed;
                    case "ByTime": return _ByTime;
                    case "GatherRegion": return _GatherRegion;
                    case "SensitiveRegion": return _SensitiveRegion;
                    case "GatherNum": return _GatherNum;
                    case "Latitude": return _Latitude;
                    case "Longitude": return _Longitude;
                    case "Owner": return _Owner;
                    case "Remark": return _Remark;
                    case "LineWidth": return _LineWidth;
                    case "Status": return _Status;
                    case "CenterLat": return _CenterLat;
                    case "CenterLng": return _CenterLng;
                    case "keyPoint": return _keyPoint;
                    case "MapType": return _MapType;
                    case "DepId": return _DepId;
                    case "Icon": return _Icon;
                    case "BusinessType": return _BusinessType;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "AreaId": _AreaId = value.ToInt(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "GPSId": _GPSId = Convert.ToString(value); break;
                    case "Points": _Points = Convert.ToString(value); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Radius": _Radius = value.ToInt(); break;
                    case "Delay": _Delay = value.ToInt(); break;
                    case "OffsetDelay": _OffsetDelay = value.ToInt(); break;
                    case "SN": _SN = value.ToInt(); break;
                    case "AreaType": _AreaType = Convert.ToString(value); break;
                    case "AlarmType": _AlarmType = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "StartDate": _StartDate = value.ToDateTime(); break;
                    case "EndDate": _EndDate = value.ToDateTime(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "LimitSpeed": _LimitSpeed = value.ToBoolean(); break;
                    case "MaxSpeed": _MaxSpeed = value.ToDouble(); break;
                    case "ByTime": _ByTime = value.ToBoolean(); break;
                    case "GatherRegion": _GatherRegion = value.ToBoolean(); break;
                    case "SensitiveRegion": _SensitiveRegion = value.ToBoolean(); break;
                    case "GatherNum": _GatherNum = value.ToInt(); break;
                    case "Latitude": _Latitude = value.ToDouble(); break;
                    case "Longitude": _Longitude = value.ToDouble(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "LineWidth": _LineWidth = value.ToDouble(); break;
                    case "Status": _Status = Convert.ToString(value); break;
                    case "CenterLat": _CenterLat = value.ToDouble(); break;
                    case "CenterLng": _CenterLng = value.ToDouble(); break;
                    case "keyPoint": _keyPoint = value.ToInt(); break;
                    case "MapType": _MapType = Convert.ToString(value); break;
                    case "DepId": _DepId = value.ToInt(); break;
                    case "Icon": _Icon = Convert.ToString(value); break;
                    case "BusinessType": _BusinessType = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得地图区域字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>区域编码</summary>
            public static readonly Field AreaId = FindByName("AreaId");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>GPS编码</summary>
            public static readonly Field GPSId = FindByName("GPSId");

            /// <summary>点位</summary>
            public static readonly Field Points = FindByName("Points");

            /// <summary>名字</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>半径</summary>
            public static readonly Field Radius = FindByName("Radius");

            /// <summary>延时</summary>
            public static readonly Field Delay = FindByName("Delay");

            /// <summary>偏移延迟</summary>
            public static readonly Field OffsetDelay = FindByName("OffsetDelay");

            /// <summary>序号</summary>
            public static readonly Field SN = FindByName("SN");

            /// <summary>区域类型</summary>
            public static readonly Field AreaType = FindByName("AreaType");

            /// <summary>报警类型</summary>
            public static readonly Field AlarmType = FindByName("AlarmType");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>开始时间</summary>
            public static readonly Field StartDate = FindByName("StartDate");

            /// <summary>结束时间</summary>
            public static readonly Field EndDate = FindByName("EndDate");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>限速</summary>
            public static readonly Field LimitSpeed = FindByName("LimitSpeed");

            /// <summary>最大速度</summary>
            public static readonly Field MaxSpeed = FindByName("MaxSpeed");

            /// <summary>按时间</summary>
            public static readonly Field ByTime = FindByName("ByTime");

            /// <summary>聚集区</summary>
            public static readonly Field GatherRegion = FindByName("GatherRegion");

            /// <summary>敏感区</summary>
            public static readonly Field SensitiveRegion = FindByName("SensitiveRegion");

            /// <summary>聚集数</summary>
            public static readonly Field GatherNum = FindByName("GatherNum");

            /// <summary>纬度</summary>
            public static readonly Field Latitude = FindByName("Latitude");

            /// <summary>经度</summary>
            public static readonly Field Longitude = FindByName("Longitude");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>线宽</summary>
            public static readonly Field LineWidth = FindByName("LineWidth");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>中心纬度</summary>
            public static readonly Field CenterLat = FindByName("CenterLat");

            /// <summary>中心经度</summary>
            public static readonly Field CenterLng = FindByName("CenterLng");

            /// <summary>关键点</summary>
            public static readonly Field keyPoint = FindByName("keyPoint");

            /// <summary>地图类型</summary>
            public static readonly Field MapType = FindByName("MapType");

            /// <summary>部门编码</summary>
            public static readonly Field DepId = FindByName("DepId");

            /// <summary>图标</summary>
            public static readonly Field Icon = FindByName("Icon");

            /// <summary>业务类型</summary>
            public static readonly Field BusinessType = FindByName("BusinessType");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得地图区域字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>区域编码</summary>
            public const String AreaId = "AreaId";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>GPS编码</summary>
            public const String GPSId = "GPSId";

            /// <summary>点位</summary>
            public const String Points = "Points";

            /// <summary>名字</summary>
            public const String Name = "Name";

            /// <summary>半径</summary>
            public const String Radius = "Radius";

            /// <summary>延时</summary>
            public const String Delay = "Delay";

            /// <summary>偏移延迟</summary>
            public const String OffsetDelay = "OffsetDelay";

            /// <summary>序号</summary>
            public const String SN = "SN";

            /// <summary>区域类型</summary>
            public const String AreaType = "AreaType";

            /// <summary>报警类型</summary>
            public const String AlarmType = "AlarmType";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>开始时间</summary>
            public const String StartDate = "StartDate";

            /// <summary>结束时间</summary>
            public const String EndDate = "EndDate";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>限速</summary>
            public const String LimitSpeed = "LimitSpeed";

            /// <summary>最大速度</summary>
            public const String MaxSpeed = "MaxSpeed";

            /// <summary>按时间</summary>
            public const String ByTime = "ByTime";

            /// <summary>聚集区</summary>
            public const String GatherRegion = "GatherRegion";

            /// <summary>敏感区</summary>
            public const String SensitiveRegion = "SensitiveRegion";

            /// <summary>聚集数</summary>
            public const String GatherNum = "GatherNum";

            /// <summary>纬度</summary>
            public const String Latitude = "Latitude";

            /// <summary>经度</summary>
            public const String Longitude = "Longitude";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>线宽</summary>
            public const String LineWidth = "LineWidth";

            /// <summary>状态</summary>
            public const String Status = "Status";

            /// <summary>中心纬度</summary>
            public const String CenterLat = "CenterLat";

            /// <summary>中心经度</summary>
            public const String CenterLng = "CenterLng";

            /// <summary>关键点</summary>
            public const String keyPoint = "keyPoint";

            /// <summary>地图类型</summary>
            public const String MapType = "MapType";

            /// <summary>部门编码</summary>
            public const String DepId = "DepId";

            /// <summary>图标</summary>
            public const String Icon = "Icon";

            /// <summary>业务类型</summary>
            public const String BusinessType = "BusinessType";
        }
        #endregion
    }
}