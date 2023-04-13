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
    /// <summary>电子围栏</summary>
    [Serializable]
    [DataObject]
    [Description("电子围栏")]
    [BindTable("ElectronicFence", Description = "电子围栏", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class ElectronicFence
    {
        #region 属性
        private Int32 _EnclosureId;
        /// <summary>围栏编码</summary>
        [DisplayName("围栏编码")]
        [Description("围栏编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("EnclosureId", "围栏编码", "int")]
        public Int32 EnclosureId { get => _EnclosureId; set { if (OnPropertyChanging("EnclosureId", value)) { _EnclosureId = value; OnPropertyChanged("EnclosureId"); } } }

        private String _MapType;
        /// <summary>地图类型</summary>
        [DisplayName("地图类型")]
        [Description("地图类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("MapType", "地图类型", "nvarchar(255)")]
        public String MapType { get => _MapType; set { if (OnPropertyChanging("MapType", value)) { _MapType = value; OnPropertyChanged("MapType"); } } }

        private String _PlateNo;
        /// <summary>车牌号</summary>
        [DisplayName("车牌号")]
        [Description("车牌号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("PlateNo", "车牌号", "nvarchar(255)")]
        public String PlateNo { get => _PlateNo; set { if (OnPropertyChanging("PlateNo", value)) { _PlateNo = value; OnPropertyChanged("PlateNo"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Name", "名称", "nvarchar(255)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _Points;
        /// <summary>点位</summary>
        [DisplayName("点位")]
        [Description("点位")]
        [DataObjectField(false, false, true, 2500)]
        [BindColumn("Points", "点位", "nvarchar(2500)")]
        public String Points { get => _Points; set { if (OnPropertyChanging("Points", value)) { _Points = value; OnPropertyChanged("Points"); } } }

        private String _EnclosureType;
        /// <summary>围栏类型</summary>
        [DisplayName("围栏类型")]
        [Description("围栏类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("EnclosureType", "围栏类型", "nvarchar(255)")]
        public String EnclosureType { get => _EnclosureType; set { if (OnPropertyChanging("EnclosureType", value)) { _EnclosureType = value; OnPropertyChanged("EnclosureType"); } } }

        private Int32 _KeyPoint;
        /// <summary>关键点</summary>
        [DisplayName("关键点")]
        [Description("关键点")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("KeyPoint", "关键点", "int")]
        public Int32 KeyPoint { get => _KeyPoint; set { if (OnPropertyChanging("KeyPoint", value)) { _KeyPoint = value; OnPropertyChanged("KeyPoint"); } } }

        private String _AlarmType;
        /// <summary>报警类型</summary>
        [DisplayName("报警类型")]
        [Description("报警类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("AlarmType", "报警类型", "nvarchar(255)")]
        public String AlarmType { get => _AlarmType; set { if (OnPropertyChanging("AlarmType", value)) { _AlarmType = value; OnPropertyChanged("AlarmType"); } } }

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

        private Double _Radius;
        /// <summary>半径</summary>
        [DisplayName("半径")]
        [Description("半径")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Radius", "半径", "float")]
        public Double Radius { get => _Radius; set { if (OnPropertyChanging("Radius", value)) { _Radius = value; OnPropertyChanged("Radius"); } } }

        private Boolean _ByTime;
        /// <summary>根据时间</summary>
        [DisplayName("根据时间")]
        [Description("根据时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("ByTime", "根据时间", "bit")]
        public Boolean ByTime { get => _ByTime; set { if (OnPropertyChanging("ByTime", value)) { _ByTime = value; OnPropertyChanged("ByTime"); } } }

        private Boolean _LimitSpeed;
        /// <summary>限速</summary>
        [DisplayName("限速")]
        [Description("限速")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("LimitSpeed", "限速", "bit")]
        public Boolean LimitSpeed { get => _LimitSpeed; set { if (OnPropertyChanging("LimitSpeed", value)) { _LimitSpeed = value; OnPropertyChanged("LimitSpeed"); } } }

        private Int32 _OffsetDelay;
        /// <summary>偏移延迟</summary>
        [DisplayName("偏移延迟")]
        [Description("偏移延迟")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("OffsetDelay", "偏移延迟", "int")]
        public Int32 OffsetDelay { get => _OffsetDelay; set { if (OnPropertyChanging("OffsetDelay", value)) { _OffsetDelay = value; OnPropertyChanged("OffsetDelay"); } } }

        private Int32 _Delay;
        /// <summary>延迟</summary>
        [DisplayName("延迟")]
        [Description("延迟")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Delay", "延迟", "int")]
        public Int32 Delay { get => _Delay; set { if (OnPropertyChanging("Delay", value)) { _Delay = value; OnPropertyChanged("Delay"); } } }

        private Double _MaxSpeed;
        /// <summary>最大速度</summary>
        [DisplayName("最大速度")]
        [Description("最大速度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("MaxSpeed", "最大速度", "float")]
        public Double MaxSpeed { get => _MaxSpeed; set { if (OnPropertyChanging("MaxSpeed", value)) { _MaxSpeed = value; OnPropertyChanged("MaxSpeed"); } } }

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
        [BindColumn("Icon", "图标", "nvarchar(255)")]
        public String Icon { get => _Icon; set { if (OnPropertyChanging("Icon", value)) { _Icon = value; OnPropertyChanged("Icon"); } } }

        private String _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Status", "状态", "nvarchar(255)")]
        public String Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private Double _LineWidth;
        /// <summary>线宽</summary>
        [DisplayName("线宽")]
        [Description("线宽")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("LineWidth", "线宽", "float")]
        public Double LineWidth { get => _LineWidth; set { if (OnPropertyChanging("LineWidth", value)) { _LineWidth = value; OnPropertyChanged("LineWidth"); } } }

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

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Remark", "备注", "nvarchar(500)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("扩展信息")]
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "bit")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [Category("扩展信息")]
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 25)]
        [BindColumn("Owner", "物主", "nvarchar(25)")]
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
                    case "EnclosureId": return _EnclosureId;
                    case "MapType": return _MapType;
                    case "PlateNo": return _PlateNo;
                    case "Name": return _Name;
                    case "Points": return _Points;
                    case "EnclosureType": return _EnclosureType;
                    case "KeyPoint": return _KeyPoint;
                    case "AlarmType": return _AlarmType;
                    case "StartDate": return _StartDate;
                    case "EndDate": return _EndDate;
                    case "Radius": return _Radius;
                    case "ByTime": return _ByTime;
                    case "LimitSpeed": return _LimitSpeed;
                    case "OffsetDelay": return _OffsetDelay;
                    case "Delay": return _Delay;
                    case "MaxSpeed": return _MaxSpeed;
                    case "DepId": return _DepId;
                    case "Icon": return _Icon;
                    case "Status": return _Status;
                    case "LineWidth": return _LineWidth;
                    case "CenterLat": return _CenterLat;
                    case "CenterLng": return _CenterLng;
                    case "TenantId": return _TenantId;
                    case "CreateTime": return _CreateTime;
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
                    case "EnclosureId": _EnclosureId = value.ToInt(); break;
                    case "MapType": _MapType = Convert.ToString(value); break;
                    case "PlateNo": _PlateNo = Convert.ToString(value); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Points": _Points = Convert.ToString(value); break;
                    case "EnclosureType": _EnclosureType = Convert.ToString(value); break;
                    case "KeyPoint": _KeyPoint = value.ToInt(); break;
                    case "AlarmType": _AlarmType = Convert.ToString(value); break;
                    case "StartDate": _StartDate = value.ToDateTime(); break;
                    case "EndDate": _EndDate = value.ToDateTime(); break;
                    case "Radius": _Radius = value.ToDouble(); break;
                    case "ByTime": _ByTime = value.ToBoolean(); break;
                    case "LimitSpeed": _LimitSpeed = value.ToBoolean(); break;
                    case "OffsetDelay": _OffsetDelay = value.ToInt(); break;
                    case "Delay": _Delay = value.ToInt(); break;
                    case "MaxSpeed": _MaxSpeed = value.ToDouble(); break;
                    case "DepId": _DepId = value.ToInt(); break;
                    case "Icon": _Icon = Convert.ToString(value); break;
                    case "Status": _Status = Convert.ToString(value); break;
                    case "LineWidth": _LineWidth = value.ToDouble(); break;
                    case "CenterLat": _CenterLat = value.ToDouble(); break;
                    case "CenterLng": _CenterLng = value.ToDouble(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得电子围栏字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>围栏编码</summary>
            public static readonly Field EnclosureId = FindByName("EnclosureId");

            /// <summary>地图类型</summary>
            public static readonly Field MapType = FindByName("MapType");

            /// <summary>车牌号</summary>
            public static readonly Field PlateNo = FindByName("PlateNo");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>点位</summary>
            public static readonly Field Points = FindByName("Points");

            /// <summary>围栏类型</summary>
            public static readonly Field EnclosureType = FindByName("EnclosureType");

            /// <summary>关键点</summary>
            public static readonly Field KeyPoint = FindByName("KeyPoint");

            /// <summary>报警类型</summary>
            public static readonly Field AlarmType = FindByName("AlarmType");

            /// <summary>开始时间</summary>
            public static readonly Field StartDate = FindByName("StartDate");

            /// <summary>结束时间</summary>
            public static readonly Field EndDate = FindByName("EndDate");

            /// <summary>半径</summary>
            public static readonly Field Radius = FindByName("Radius");

            /// <summary>根据时间</summary>
            public static readonly Field ByTime = FindByName("ByTime");

            /// <summary>限速</summary>
            public static readonly Field LimitSpeed = FindByName("LimitSpeed");

            /// <summary>偏移延迟</summary>
            public static readonly Field OffsetDelay = FindByName("OffsetDelay");

            /// <summary>延迟</summary>
            public static readonly Field Delay = FindByName("Delay");

            /// <summary>最大速度</summary>
            public static readonly Field MaxSpeed = FindByName("MaxSpeed");

            /// <summary>部门编码</summary>
            public static readonly Field DepId = FindByName("DepId");

            /// <summary>图标</summary>
            public static readonly Field Icon = FindByName("Icon");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>线宽</summary>
            public static readonly Field LineWidth = FindByName("LineWidth");

            /// <summary>中心纬度</summary>
            public static readonly Field CenterLat = FindByName("CenterLat");

            /// <summary>中心经度</summary>
            public static readonly Field CenterLng = FindByName("CenterLng");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得电子围栏字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>围栏编码</summary>
            public const String EnclosureId = "EnclosureId";

            /// <summary>地图类型</summary>
            public const String MapType = "MapType";

            /// <summary>车牌号</summary>
            public const String PlateNo = "PlateNo";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>点位</summary>
            public const String Points = "Points";

            /// <summary>围栏类型</summary>
            public const String EnclosureType = "EnclosureType";

            /// <summary>关键点</summary>
            public const String KeyPoint = "KeyPoint";

            /// <summary>报警类型</summary>
            public const String AlarmType = "AlarmType";

            /// <summary>开始时间</summary>
            public const String StartDate = "StartDate";

            /// <summary>结束时间</summary>
            public const String EndDate = "EndDate";

            /// <summary>半径</summary>
            public const String Radius = "Radius";

            /// <summary>根据时间</summary>
            public const String ByTime = "ByTime";

            /// <summary>限速</summary>
            public const String LimitSpeed = "LimitSpeed";

            /// <summary>偏移延迟</summary>
            public const String OffsetDelay = "OffsetDelay";

            /// <summary>延迟</summary>
            public const String Delay = "Delay";

            /// <summary>最大速度</summary>
            public const String MaxSpeed = "MaxSpeed";

            /// <summary>部门编码</summary>
            public const String DepId = "DepId";

            /// <summary>图标</summary>
            public const String Icon = "Icon";

            /// <summary>状态</summary>
            public const String Status = "Status";

            /// <summary>线宽</summary>
            public const String LineWidth = "LineWidth";

            /// <summary>中心纬度</summary>
            public const String CenterLat = "CenterLat";

            /// <summary>中心经度</summary>
            public const String CenterLng = "CenterLng";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

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