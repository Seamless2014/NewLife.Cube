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
    /// <summary>系统配置</summary>
    [Serializable]
    [DataObject]
    [Description("系统配置")]
    [BindTable("SystemConfig", Description = "系统配置", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class SystemConfig
    {
        #region 属性
        private Decimal _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "编号", "numeric(19, 0)")]
        public Decimal Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private String _SubTitle;
        /// <summary>副标题</summary>
        [DisplayName("副标题")]
        [Description("副标题")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("SubTitle", "副标题", "varchar(255)")]
        public String SubTitle { get => _SubTitle; set { if (OnPropertyChanging("SubTitle", value)) { _SubTitle = value; OnPropertyChanged("SubTitle"); } } }

        private Double _InitLat;
        /// <summary>初始纬度</summary>
        [DisplayName("初始纬度")]
        [Description("初始纬度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("InitLat", "初始纬度", "")]
        public Double InitLat { get => _InitLat; set { if (OnPropertyChanging("InitLat", value)) { _InitLat = value; OnPropertyChanged("InitLat"); } } }

        private Double _InitLng;
        /// <summary>初始经度</summary>
        [DisplayName("初始经度")]
        [Description("初始经度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("InitLng", "初始经度", "")]
        public Double InitLng { get => _InitLng; set { if (OnPropertyChanging("InitLng", value)) { _InitLng = value; OnPropertyChanged("InitLng"); } } }

        private Int32 _InitZoomLevel;
        /// <summary>初始层级</summary>
        [DisplayName("初始层级")]
        [Description("初始层级")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("InitZoomLevel", "初始层级", "")]
        public Int32 InitZoomLevel { get => _InitZoomLevel; set { if (OnPropertyChanging("InitZoomLevel", value)) { _InitZoomLevel = value; OnPropertyChanged("InitZoomLevel"); } } }

        private String _MapType;
        /// <summary>图商类型</summary>
        [DisplayName("图商类型")]
        [Description("图商类型")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("MapType", "图商类型", "")]
        public String MapType { get => _MapType; set { if (OnPropertyChanging("MapType", value)) { _MapType = value; OnPropertyChanged("MapType"); } } }

        private String _SmartKey;
        /// <summary>图商密钥</summary>
        [DisplayName("图商密钥")]
        [Description("图商密钥")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("SmartKey", "图商密钥", "varchar(50)")]
        public String SmartKey { get => _SmartKey; set { if (OnPropertyChanging("SmartKey", value)) { _SmartKey = value; OnPropertyChanged("SmartKey"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [Category("扩展信息")]
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private Int32 _TenantId;
        /// <summary>租户编码</summary>
        [Category("扩展信息")]
        [DisplayName("租户编码")]
        [Description("租户编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("TenantId", "租户编码", "")]
        public Int32 TenantId { get => _TenantId; set { if (OnPropertyChanging("TenantId", value)) { _TenantId = value; OnPropertyChanged("TenantId"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [Category("扩展信息")]
        [DisplayName("拥有者")]
        [Description("拥有者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Owner", "拥有者", "")]
        public String Owner { get => _Owner; set { if (OnPropertyChanging("Owner", value)) { _Owner = value; OnPropertyChanged("Owner"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [Category("扩展信息")]
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Remark", "备注", "")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Int32 _MaxOfflineDays;
        /// <summary>最大离线天数</summary>
        [DisplayName("最大离线天数")]
        [Description("最大离线天数")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("MaxOfflineDays", "最大离线天数", "")]
        public Int32 MaxOfflineDays { get => _MaxOfflineDays; set { if (OnPropertyChanging("MaxOfflineDays", value)) { _MaxOfflineDays = value; OnPropertyChanged("MaxOfflineDays"); } } }

        private String _DisplayStateType;
        /// <summary>显示状态类型</summary>
        [DisplayName("显示状态类型")]
        [Description("显示状态类型")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("DisplayStateType", "显示状态类型", "")]
        public String DisplayStateType { get => _DisplayStateType; set { if (OnPropertyChanging("DisplayStateType", value)) { _DisplayStateType = value; OnPropertyChanged("DisplayStateType"); } } }

        private String _SystemTitle;
        /// <summary>系统标题</summary>
        [DisplayName("系统标题")]
        [Description("系统标题")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("SystemTitle", "系统标题", "varchar(255)")]
        public String SystemTitle { get => _SystemTitle; set { if (OnPropertyChanging("SystemTitle", value)) { _SystemTitle = value; OnPropertyChanged("SystemTitle"); } } }

        private String _CheckValidateCode;
        /// <summary>有效码</summary>
        [DisplayName("有效码")]
        [Description("有效码")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("CheckValidateCode", "有效码", "varchar(255)")]
        public String CheckValidateCode { get => _CheckValidateCode; set { if (OnPropertyChanging("CheckValidateCode", value)) { _CheckValidateCode = value; OnPropertyChanged("CheckValidateCode"); } } }

        private String _BaiduKey;
        /// <summary>百度Key</summary>
        [DisplayName("百度Key")]
        [Description("百度Key")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("BaiduKey", "百度Key", "")]
        public String BaiduKey { get => _BaiduKey; set { if (OnPropertyChanging("BaiduKey", value)) { _BaiduKey = value; OnPropertyChanged("BaiduKey"); } } }

        private String _AmapKey;
        /// <summary>阿里Key</summary>
        [DisplayName("阿里Key")]
        [Description("阿里Key")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("AmapKey", "阿里Key", "")]
        public String AmapKey { get => _AmapKey; set { if (OnPropertyChanging("AmapKey", value)) { _AmapKey = value; OnPropertyChanged("AmapKey"); } } }

        private String _AmapWebServiceKey;
        /// <summary>阿里Web服务Key</summary>
        [DisplayName("阿里Web服务Key")]
        [Description("阿里Web服务Key")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("AmapWebServiceKey", "阿里Web服务Key", "")]
        public String AmapWebServiceKey { get => _AmapWebServiceKey; set { if (OnPropertyChanging("AmapWebServiceKey", value)) { _AmapWebServiceKey = value; OnPropertyChanged("AmapWebServiceKey"); } } }

        private Int32 _RefreshInterval;
        /// <summary>刷新间隔</summary>
        [DisplayName("刷新间隔")]
        [Description("刷新间隔")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("RefreshInterval", "刷新间隔", "")]
        public Int32 RefreshInterval { get => _RefreshInterval; set { if (OnPropertyChanging("RefreshInterval", value)) { _RefreshInterval = value; OnPropertyChanged("RefreshInterval"); } } }

        private Int32 _AlarmInterval;
        /// <summary>报警间隔</summary>
        [DisplayName("报警间隔")]
        [Description("报警间隔")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AlarmInterval", "报警间隔", "")]
        public Int32 AlarmInterval { get => _AlarmInterval; set { if (OnPropertyChanging("AlarmInterval", value)) { _AlarmInterval = value; OnPropertyChanged("AlarmInterval"); } } }

        private Boolean _ShowVehicleOnMap;
        /// <summary>在地图上显示车辆</summary>
        [DisplayName("在地图上显示车辆")]
        [Description("在地图上显示车辆")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ShowVehicleOnMap", "在地图上显示车辆", "")]
        public Boolean ShowVehicleOnMap { get => _ShowVehicleOnMap; set { if (OnPropertyChanging("ShowVehicleOnMap", value)) { _ShowVehicleOnMap = value; OnPropertyChanged("ShowVehicleOnMap"); } } }

        private Boolean _ShowDepNameOnMap;
        /// <summary>在地图上显示部门</summary>
        [DisplayName("在地图上显示部门")]
        [Description("在地图上显示部门")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ShowDepNameOnMap", "在地图上显示部门", "")]
        public Boolean ShowDepNameOnMap { get => _ShowDepNameOnMap; set { if (OnPropertyChanging("ShowDepNameOnMap", value)) { _ShowDepNameOnMap = value; OnPropertyChanged("ShowDepNameOnMap"); } } }

        private String _BaiduWebServiceKey;
        /// <summary>百度Web服务Key</summary>
        [DisplayName("百度Web服务Key")]
        [Description("百度Web服务Key")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("BaiduWebServiceKey", "百度Web服务Key", "")]
        public String BaiduWebServiceKey { get => _BaiduWebServiceKey; set { if (OnPropertyChanging("BaiduWebServiceKey", value)) { _BaiduWebServiceKey = value; OnPropertyChanged("BaiduWebServiceKey"); } } }
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
                    case "Id": return _Id;
                    case "SubTitle": return _SubTitle;
                    case "InitLat": return _InitLat;
                    case "InitLng": return _InitLng;
                    case "InitZoomLevel": return _InitZoomLevel;
                    case "MapType": return _MapType;
                    case "SmartKey": return _SmartKey;
                    case "Deleted": return _Deleted;
                    case "TenantId": return _TenantId;
                    case "Owner": return _Owner;
                    case "Remark": return _Remark;
                    case "CreateTime": return _CreateTime;
                    case "MaxOfflineDays": return _MaxOfflineDays;
                    case "DisplayStateType": return _DisplayStateType;
                    case "SystemTitle": return _SystemTitle;
                    case "CheckValidateCode": return _CheckValidateCode;
                    case "BaiduKey": return _BaiduKey;
                    case "AmapKey": return _AmapKey;
                    case "AmapWebServiceKey": return _AmapWebServiceKey;
                    case "RefreshInterval": return _RefreshInterval;
                    case "AlarmInterval": return _AlarmInterval;
                    case "ShowVehicleOnMap": return _ShowVehicleOnMap;
                    case "ShowDepNameOnMap": return _ShowDepNameOnMap;
                    case "BaiduWebServiceKey": return _BaiduWebServiceKey;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = Convert.ToDecimal(value); break;
                    case "SubTitle": _SubTitle = Convert.ToString(value); break;
                    case "InitLat": _InitLat = value.ToDouble(); break;
                    case "InitLng": _InitLng = value.ToDouble(); break;
                    case "InitZoomLevel": _InitZoomLevel = value.ToInt(); break;
                    case "MapType": _MapType = Convert.ToString(value); break;
                    case "SmartKey": _SmartKey = Convert.ToString(value); break;
                    case "Deleted": _Deleted = value.ToBoolean(); break;
                    case "TenantId": _TenantId = value.ToInt(); break;
                    case "Owner": _Owner = Convert.ToString(value); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "MaxOfflineDays": _MaxOfflineDays = value.ToInt(); break;
                    case "DisplayStateType": _DisplayStateType = Convert.ToString(value); break;
                    case "SystemTitle": _SystemTitle = Convert.ToString(value); break;
                    case "CheckValidateCode": _CheckValidateCode = Convert.ToString(value); break;
                    case "BaiduKey": _BaiduKey = Convert.ToString(value); break;
                    case "AmapKey": _AmapKey = Convert.ToString(value); break;
                    case "AmapWebServiceKey": _AmapWebServiceKey = Convert.ToString(value); break;
                    case "RefreshInterval": _RefreshInterval = value.ToInt(); break;
                    case "AlarmInterval": _AlarmInterval = value.ToInt(); break;
                    case "ShowVehicleOnMap": _ShowVehicleOnMap = value.ToBoolean(); break;
                    case "ShowDepNameOnMap": _ShowDepNameOnMap = value.ToBoolean(); break;
                    case "BaiduWebServiceKey": _BaiduWebServiceKey = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得系统配置字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary>副标题</summary>
            public static readonly Field SubTitle = FindByName("SubTitle");

            /// <summary>初始纬度</summary>
            public static readonly Field InitLat = FindByName("InitLat");

            /// <summary>初始经度</summary>
            public static readonly Field InitLng = FindByName("InitLng");

            /// <summary>初始层级</summary>
            public static readonly Field InitZoomLevel = FindByName("InitZoomLevel");

            /// <summary>图商类型</summary>
            public static readonly Field MapType = FindByName("MapType");

            /// <summary>图商密钥</summary>
            public static readonly Field SmartKey = FindByName("SmartKey");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>租户编码</summary>
            public static readonly Field TenantId = FindByName("TenantId");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>最大离线天数</summary>
            public static readonly Field MaxOfflineDays = FindByName("MaxOfflineDays");

            /// <summary>显示状态类型</summary>
            public static readonly Field DisplayStateType = FindByName("DisplayStateType");

            /// <summary>系统标题</summary>
            public static readonly Field SystemTitle = FindByName("SystemTitle");

            /// <summary>有效码</summary>
            public static readonly Field CheckValidateCode = FindByName("CheckValidateCode");

            /// <summary>百度Key</summary>
            public static readonly Field BaiduKey = FindByName("BaiduKey");

            /// <summary>阿里Key</summary>
            public static readonly Field AmapKey = FindByName("AmapKey");

            /// <summary>阿里Web服务Key</summary>
            public static readonly Field AmapWebServiceKey = FindByName("AmapWebServiceKey");

            /// <summary>刷新间隔</summary>
            public static readonly Field RefreshInterval = FindByName("RefreshInterval");

            /// <summary>报警间隔</summary>
            public static readonly Field AlarmInterval = FindByName("AlarmInterval");

            /// <summary>在地图上显示车辆</summary>
            public static readonly Field ShowVehicleOnMap = FindByName("ShowVehicleOnMap");

            /// <summary>在地图上显示部门</summary>
            public static readonly Field ShowDepNameOnMap = FindByName("ShowDepNameOnMap");

            /// <summary>百度Web服务Key</summary>
            public static readonly Field BaiduWebServiceKey = FindByName("BaiduWebServiceKey");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得系统配置字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String Id = "Id";

            /// <summary>副标题</summary>
            public const String SubTitle = "SubTitle";

            /// <summary>初始纬度</summary>
            public const String InitLat = "InitLat";

            /// <summary>初始经度</summary>
            public const String InitLng = "InitLng";

            /// <summary>初始层级</summary>
            public const String InitZoomLevel = "InitZoomLevel";

            /// <summary>图商类型</summary>
            public const String MapType = "MapType";

            /// <summary>图商密钥</summary>
            public const String SmartKey = "SmartKey";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>租户编码</summary>
            public const String TenantId = "TenantId";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>最大离线天数</summary>
            public const String MaxOfflineDays = "MaxOfflineDays";

            /// <summary>显示状态类型</summary>
            public const String DisplayStateType = "DisplayStateType";

            /// <summary>系统标题</summary>
            public const String SystemTitle = "SystemTitle";

            /// <summary>有效码</summary>
            public const String CheckValidateCode = "CheckValidateCode";

            /// <summary>百度Key</summary>
            public const String BaiduKey = "BaiduKey";

            /// <summary>阿里Key</summary>
            public const String AmapKey = "AmapKey";

            /// <summary>阿里Web服务Key</summary>
            public const String AmapWebServiceKey = "AmapWebServiceKey";

            /// <summary>刷新间隔</summary>
            public const String RefreshInterval = "RefreshInterval";

            /// <summary>报警间隔</summary>
            public const String AlarmInterval = "AlarmInterval";

            /// <summary>在地图上显示车辆</summary>
            public const String ShowVehicleOnMap = "ShowVehicleOnMap";

            /// <summary>在地图上显示部门</summary>
            public const String ShowDepNameOnMap = "ShowDepNameOnMap";

            /// <summary>百度Web服务Key</summary>
            public const String BaiduWebServiceKey = "BaiduWebServiceKey";
        }
        #endregion
    }
}