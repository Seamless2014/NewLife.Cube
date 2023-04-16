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
    /// <summary>线段。一条线路有多条线段组成，班车一般按照固定线路运营</summary>
    [Serializable]
    [DataObject]
    [Description("线段。一条线路有多条线段组成，班车一般按照固定线路运营")]
    [BindIndex("IU_LineSegment_Name", true, "Name")]
    [BindTable("LineSegment", Description = "线段。一条线路有多条线段组成，班车一般按照固定线路运营", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class LineSegment
    {
        #region 属性
        private Int32 _SegId;
        /// <summary>线段编码</summary>
        [DisplayName("线段编码")]
        [Description("线段编码")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("SegId", "线段编码", "")]
        public Int32 SegId { get => _SegId; set { if (OnPropertyChanging("SegId", value)) { _SegId = value; OnPropertyChanged("SegId"); } } }

        private Int32 _EnclosureId;
        /// <summary>围栏编码</summary>
        [DisplayName("围栏编码")]
        [Description("围栏编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("EnclosureId", "围栏编码", "")]
        public Int32 EnclosureId { get => _EnclosureId; set { if (OnPropertyChanging("EnclosureId", value)) { _EnclosureId = value; OnPropertyChanged("EnclosureId"); } } }

        private Int32 _PointId;
        /// <summary>点位编码</summary>
        [DisplayName("点位编码")]
        [Description("点位编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("PointId", "点位编码", "")]
        public Int32 PointId { get => _PointId; set { if (OnPropertyChanging("PointId", value)) { _PointId = value; OnPropertyChanged("PointId"); } } }

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

        private Int32 _LineWidth;
        /// <summary>线宽</summary>
        [DisplayName("线宽")]
        [Description("线宽")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("LineWidth", "线宽", "")]
        public Int32 LineWidth { get => _LineWidth; set { if (OnPropertyChanging("LineWidth", value)) { _LineWidth = value; OnPropertyChanged("LineWidth"); } } }

        private Boolean _IsStation;
        /// <summary>是否站点</summary>
        [DisplayName("是否站点")]
        [Description("是否站点")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("IsStation", "是否站点", "")]
        public Boolean IsStation { get => _IsStation; set { if (OnPropertyChanging("IsStation", value)) { _IsStation = value; OnPropertyChanged("IsStation"); } } }

        private Boolean _LimitSpeed;
        /// <summary>限速</summary>
        [DisplayName("限速")]
        [Description("限速")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("LimitSpeed", "限速", "")]
        public Boolean LimitSpeed { get => _LimitSpeed; set { if (OnPropertyChanging("LimitSpeed", value)) { _LimitSpeed = value; OnPropertyChanged("LimitSpeed"); } } }

        private Boolean _ByTime;
        /// <summary>按时间</summary>
        [DisplayName("按时间")]
        [Description("按时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("ByTime", "按时间", "")]
        public Boolean ByTime { get => _ByTime; set { if (OnPropertyChanging("ByTime", value)) { _ByTime = value; OnPropertyChanged("ByTime"); } } }

        private Int32 _MaxSpeed;
        /// <summary>最大速度</summary>
        [DisplayName("最大速度")]
        [Description("最大速度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("MaxSpeed", "最大速度", "")]
        public Int32 MaxSpeed { get => _MaxSpeed; set { if (OnPropertyChanging("MaxSpeed", value)) { _MaxSpeed = value; OnPropertyChanged("MaxSpeed"); } } }

        private Int32 _OverSpeedTime;
        /// <summary>超速时间</summary>
        [DisplayName("超速时间")]
        [Description("超速时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("OverSpeedTime", "超速时间", "")]
        public Int32 OverSpeedTime { get => _OverSpeedTime; set { if (OnPropertyChanging("OverSpeedTime", value)) { _OverSpeedTime = value; OnPropertyChanged("OverSpeedTime"); } } }

        private Int32 _MaxTimeLimit;
        /// <summary>最大限制时间</summary>
        [DisplayName("最大限制时间")]
        [Description("最大限制时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("MaxTimeLimit", "最大限制时间", "")]
        public Int32 MaxTimeLimit { get => _MaxTimeLimit; set { if (OnPropertyChanging("MaxTimeLimit", value)) { _MaxTimeLimit = value; OnPropertyChanged("MaxTimeLimit"); } } }

        private Int32 _MinTimeLimit;
        /// <summary>最小限制时间</summary>
        [DisplayName("最小限制时间")]
        [Description("最小限制时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("MinTimeLimit", "最小限制时间", "")]
        public Int32 MinTimeLimit { get => _MinTimeLimit; set { if (OnPropertyChanging("MinTimeLimit", value)) { _MinTimeLimit = value; OnPropertyChanged("MinTimeLimit"); } } }

        private String _AlarmType;
        /// <summary>报警类型</summary>
        [DisplayName("报警类型")]
        [Description("报警类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("AlarmType", "报警类型", "")]
        public String AlarmType { get => _AlarmType; set { if (OnPropertyChanging("AlarmType", value)) { _AlarmType = value; OnPropertyChanged("AlarmType"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("扩展信息")]
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private Double _Latitude1;
        /// <summary>纬度1</summary>
        [DisplayName("纬度1")]
        [Description("纬度1")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Latitude1", "纬度1", "")]
        public Double Latitude1 { get => _Latitude1; set { if (OnPropertyChanging("Latitude1", value)) { _Latitude1 = value; OnPropertyChanged("Latitude1"); } } }

        private Double _Longitude1;
        /// <summary>经度1</summary>
        [DisplayName("经度1")]
        [Description("经度1")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Longitude1", "经度1", "")]
        public Double Longitude1 { get => _Longitude1; set { if (OnPropertyChanging("Longitude1", value)) { _Longitude1 = value; OnPropertyChanged("Longitude1"); } } }

        private Double _Latitude2;
        /// <summary>纬度2</summary>
        [DisplayName("纬度2")]
        [Description("纬度2")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Latitude2", "纬度2", "")]
        public Double Latitude2 { get => _Latitude2; set { if (OnPropertyChanging("Latitude2", value)) { _Latitude2 = value; OnPropertyChanged("Latitude2"); } } }

        private Double _Longitude2;
        /// <summary>经度2</summary>
        [DisplayName("经度2")]
        [Description("经度2")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Longitude2", "经度2", "")]
        public Double Longitude2 { get => _Longitude2; set { if (OnPropertyChanging("Longitude2", value)) { _Longitude2 = value; OnPropertyChanged("Longitude2"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Name", "名称", "", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Remark", "备注", "")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private String _Owner;
        /// <summary>物主</summary>
        [Category("扩展信息")]
        [DisplayName("物主")]
        [Description("物主")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn("Owner", "物主", "")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [Category("扩展信息")]
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TenantId", "租户编码", "")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private Boolean _Station;
        /// <summary>站点</summary>
        [DisplayName("站点")]
        [Description("站点")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Station", "站点", "")]
        public Boolean Station { get => _Station; set { if (OnPropertyChanging("Station", value)) { _Station = value; OnPropertyChanged("Station"); } } }

        private Int32 _AreaInfoId;
        /// <summary>区域信息编码</summary>
        [DisplayName("区域信息编码")]
        [Description("区域信息编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AreaInfoId", "区域信息编码", "")]
        public Int32 AreaInfoId { get => _AreaInfoId; set { if (OnPropertyChanging("AreaInfoId", value)) { _AreaInfoId = value; OnPropertyChanged("AreaInfoId"); } } }

        private Boolean _InDriver;
        /// <summary>进区域报警给驾驶员</summary>
        [DisplayName("进区域报警给驾驶员")]
        [Description("进区域报警给驾驶员")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("InDriver", "进区域报警给驾驶员", "")]
        public Boolean InDriver { get => _InDriver; set { if (OnPropertyChanging("InDriver", value)) { _InDriver = value; OnPropertyChanged("InDriver"); } } }

        private Boolean _InPlatform;
        /// <summary>进区域报警给平台</summary>
        [DisplayName("进区域报警给平台")]
        [Description("进区域报警给平台")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("InPlatform", "进区域报警给平台", "")]
        public Boolean InPlatform { get => _InPlatform; set { if (OnPropertyChanging("InPlatform", value)) { _InPlatform = value; OnPropertyChanged("InPlatform"); } } }

        private Boolean _OutDriver;
        /// <summary>出区域报警给驾驶员</summary>
        [DisplayName("出区域报警给驾驶员")]
        [Description("出区域报警给驾驶员")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("OutDriver", "出区域报警给驾驶员", "")]
        public Boolean OutDriver { get => _OutDriver; set { if (OnPropertyChanging("OutDriver", value)) { _OutDriver = value; OnPropertyChanged("OutDriver"); } } }

        private Boolean _OutPlatform;
        /// <summary>出区域报警给平台</summary>
        [DisplayName("出区域报警给平台")]
        [Description("出区域报警给平台")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("OutPlatform", "出区域报警给平台", "")]
        public Boolean OutPlatform { get => _OutPlatform; set { if (OnPropertyChanging("OutPlatform", value)) { _OutPlatform = value; OnPropertyChanged("OutPlatform"); } } }

        private Int32 _RouteId;
        /// <summary>路线编码</summary>
        [DisplayName("路线编码")]
        [Description("路线编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("RouteId", "路线编码", "")]
        public Int32 RouteId { get => _RouteId; set { if (OnPropertyChanging("RouteId", value)) { _RouteId = value; OnPropertyChanged("RouteId"); } } }
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
                    case "SegId": return _SegId;
                    case "EnclosureId": return _EnclosureId;
                    case "PointId": return _PointId;
                    case "Latitude": return _Latitude;
                    case "Longitude": return _Longitude;
                    case "LineWidth": return _LineWidth;
                    case "IsStation": return _IsStation;
                    case "LimitSpeed": return _LimitSpeed;
                    case "ByTime": return _ByTime;
                    case "MaxSpeed": return _MaxSpeed;
                    case "OverSpeedTime": return _OverSpeedTime;
                    case "MaxTimeLimit": return _MaxTimeLimit;
                    case "MinTimeLimit": return _MinTimeLimit;
                    case "AlarmType": return _AlarmType;
                    case "CreateTime": return _CreateTime;
                    case "Deleted": return _Deleted;
                    case "Latitude1": return _Latitude1;
                    case "Longitude1": return _Longitude1;
                    case "Latitude2": return _Latitude2;
                    case "Longitude2": return _Longitude2;
                    case "Name": return _Name;
                    case "Remark": return _Remark;
                    case "Owner": return _Owner;
                    case "TenantId": return _TenantId;
                    case "Station": return _Station;
                    case "AreaInfoId": return _AreaInfoId;
                    case "InDriver": return _InDriver;
                    case "InPlatform": return _InPlatform;
                    case "OutDriver": return _OutDriver;
                    case "OutPlatform": return _OutPlatform;
                    case "RouteId": return _RouteId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "SegId": _SegId = value.ToInt(); break;
                    case "EnclosureId": _EnclosureId = value.ToInt(); break;
                    case "PointId": _PointId = value.ToInt(); break;
                    case "Latitude": _Latitude = value.ToDouble(); break;
                    case "Longitude": _Longitude = value.ToDouble(); break;
                    case "LineWidth": _LineWidth = value.ToInt(); break;
                    case "IsStation": _IsStation = value.ToBoolean(); break;
                    case "LimitSpeed": _LimitSpeed = value.ToBoolean(); break;
                    case "ByTime": _ByTime = value.ToBoolean(); break;
                    case "MaxSpeed": _MaxSpeed = value.ToInt(); break;
                    case "OverSpeedTime": _OverSpeedTime = value.ToInt(); break;
                    case "MaxTimeLimit": _MaxTimeLimit = value.ToInt(); break;
                    case "MinTimeLimit": _MinTimeLimit = value.ToInt(); break;
                    case "AlarmType": _AlarmType = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "Latitude1": _Latitude1 = value.ToDouble(); break;
                    case "Longitude1": _Longitude1 = value.ToDouble(); break;
                    case "Latitude2": _Latitude2 = value.ToDouble(); break;
                    case "Longitude2": _Longitude2 = value.ToDouble(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Station": _Station = value.ToBoolean(); break;
                    case "AreaInfoId": _AreaInfoId = value.ToInt(); break;
                    case "InDriver": _InDriver = value.ToBoolean(); break;
                    case "InPlatform": _InPlatform = value.ToBoolean(); break;
                    case "OutDriver": _OutDriver = value.ToBoolean(); break;
                    case "OutPlatform": _OutPlatform = value.ToBoolean(); break;
                    case "RouteId": _RouteId = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得线段字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>线段编码</summary>
            public static readonly Field SegId = FindByName("SegId");

            /// <summary>围栏编码</summary>
            public static readonly Field EnclosureId = FindByName("EnclosureId");

            /// <summary>点位编码</summary>
            public static readonly Field PointId = FindByName("PointId");

            /// <summary>纬度</summary>
            public static readonly Field Latitude = FindByName("Latitude");

            /// <summary>经度</summary>
            public static readonly Field Longitude = FindByName("Longitude");

            /// <summary>线宽</summary>
            public static readonly Field LineWidth = FindByName("LineWidth");

            /// <summary>是否站点</summary>
            public static readonly Field IsStation = FindByName("IsStation");

            /// <summary>限速</summary>
            public static readonly Field LimitSpeed = FindByName("LimitSpeed");

            /// <summary>按时间</summary>
            public static readonly Field ByTime = FindByName("ByTime");

            /// <summary>最大速度</summary>
            public static readonly Field MaxSpeed = FindByName("MaxSpeed");

            /// <summary>超速时间</summary>
            public static readonly Field OverSpeedTime = FindByName("OverSpeedTime");

            /// <summary>最大限制时间</summary>
            public static readonly Field MaxTimeLimit = FindByName("MaxTimeLimit");

            /// <summary>最小限制时间</summary>
            public static readonly Field MinTimeLimit = FindByName("MinTimeLimit");

            /// <summary>报警类型</summary>
            public static readonly Field AlarmType = FindByName("AlarmType");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>纬度1</summary>
            public static readonly Field Latitude1 = FindByName("Latitude1");

            /// <summary>经度1</summary>
            public static readonly Field Longitude1 = FindByName("Longitude1");

            /// <summary>纬度2</summary>
            public static readonly Field Latitude2 = FindByName("Latitude2");

            /// <summary>经度2</summary>
            public static readonly Field Longitude2 = FindByName("Longitude2");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>物主</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>站点</summary>
            public static readonly Field Station = FindByName("Station");

            /// <summary>区域信息编码</summary>
            public static readonly Field AreaInfoId = FindByName("AreaInfoId");

            /// <summary>进区域报警给驾驶员</summary>
            public static readonly Field InDriver = FindByName("InDriver");

            /// <summary>进区域报警给平台</summary>
            public static readonly Field InPlatform = FindByName("InPlatform");

            /// <summary>出区域报警给驾驶员</summary>
            public static readonly Field OutDriver = FindByName("OutDriver");

            /// <summary>出区域报警给平台</summary>
            public static readonly Field OutPlatform = FindByName("OutPlatform");

            /// <summary>路线编码</summary>
            public static readonly Field RouteId = FindByName("RouteId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得线段字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>线段编码</summary>
            public const String SegId = "SegId";

            /// <summary>围栏编码</summary>
            public const String EnclosureId = "EnclosureId";

            /// <summary>点位编码</summary>
            public const String PointId = "PointId";

            /// <summary>纬度</summary>
            public const String Latitude = "Latitude";

            /// <summary>经度</summary>
            public const String Longitude = "Longitude";

            /// <summary>线宽</summary>
            public const String LineWidth = "LineWidth";

            /// <summary>是否站点</summary>
            public const String IsStation = "IsStation";

            /// <summary>限速</summary>
            public const String LimitSpeed = "LimitSpeed";

            /// <summary>按时间</summary>
            public const String ByTime = "ByTime";

            /// <summary>最大速度</summary>
            public const String MaxSpeed = "MaxSpeed";

            /// <summary>超速时间</summary>
            public const String OverSpeedTime = "OverSpeedTime";

            /// <summary>最大限制时间</summary>
            public const String MaxTimeLimit = "MaxTimeLimit";

            /// <summary>最小限制时间</summary>
            public const String MinTimeLimit = "MinTimeLimit";

            /// <summary>报警类型</summary>
            public const String AlarmType = "AlarmType";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>纬度1</summary>
            public const String Latitude1 = "Latitude1";

            /// <summary>经度1</summary>
            public const String Longitude1 = "Longitude1";

            /// <summary>纬度2</summary>
            public const String Latitude2 = "Latitude2";

            /// <summary>经度2</summary>
            public const String Longitude2 = "Longitude2";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>物主</summary>
            public const String Owner = "Owner";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>站点</summary>
            public const String Station = "Station";

            /// <summary>区域信息编码</summary>
            public const String AreaInfoId = "AreaInfoId";

            /// <summary>进区域报警给驾驶员</summary>
            public const String InDriver = "InDriver";

            /// <summary>进区域报警给平台</summary>
            public const String InPlatform = "InPlatform";

            /// <summary>出区域报警给驾驶员</summary>
            public const String OutDriver = "OutDriver";

            /// <summary>出区域报警给平台</summary>
            public const String OutPlatform = "OutPlatform";

            /// <summary>路线编码</summary>
            public const String RouteId = "RouteId";
        }
        #endregion
    }
}