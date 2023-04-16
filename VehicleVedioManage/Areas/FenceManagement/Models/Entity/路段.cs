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
    /// <summary>路段</summary>
    [Serializable]
    [DataObject]
    [Description("路段")]
    [BindIndex("IU_RouteSegment_Name", true, "Name")]
    [BindTable("RouteSegment", Description = "路段", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class RouteSegment
    {
        #region 属性
        private Int32 _SegId;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("SegId", "编码", "")]
        public Int32 SegId { get => _SegId; set { if (OnPropertyChanging("SegId", value)) { _SegId = value; OnPropertyChanged("SegId"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Name", "名称", "", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private Int32 _RouteId;
        /// <summary>路线编码</summary>
        [DisplayName("路线编码")]
        [Description("路线编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("RouteId", "路线编码", "")]
        public Int32 RouteId { get => _RouteId; set { if (OnPropertyChanging("RouteId", value)) { _RouteId = value; OnPropertyChanged("RouteId"); } } }

        private String _StrPoints;
        /// <summary>点位</summary>
        [DisplayName("点位")]
        [Description("点位")]
        [DataObjectField(false, false, true, 2550)]
        [BindColumn("StrPoints", "点位", "")]
        public String StrPoints { get => _StrPoints; set { if (OnPropertyChanging("StrPoints", value)) { _StrPoints = value; OnPropertyChanged("StrPoints"); } } }

        private Int32 _StartSegId;
        /// <summary>起始路段编码</summary>
        [DisplayName("起始路段编码")]
        [Description("起始路段编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("StartSegId", "起始路段编码", "")]
        public Int32 StartSegId { get => _StartSegId; set { if (OnPropertyChanging("StartSegId", value)) { _StartSegId = value; OnPropertyChanged("StartSegId"); } } }

        private Int32 _EndSegId;
        /// <summary>结束路段编码</summary>
        [DisplayName("结束路段编码")]
        [Description("结束路段编码")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("EndSegId", "结束路段编码", "")]
        public Int32 EndSegId { get => _EndSegId; set { if (OnPropertyChanging("EndSegId", value)) { _EndSegId = value; OnPropertyChanged("EndSegId"); } } }

        private Double _MaxSpeed;
        /// <summary>最大速度</summary>
        [DisplayName("最大速度")]
        [Description("最大速度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("MaxSpeed", "最大速度", "")]
        public Double MaxSpeed { get => _MaxSpeed; set { if (OnPropertyChanging("MaxSpeed", value)) { _MaxSpeed = value; OnPropertyChanged("MaxSpeed"); } } }

        private Int32 _Delay;
        /// <summary>延时多久</summary>
        [DisplayName("延时多久")]
        [Description("延时多久")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Delay", "延时多久", "")]
        public Int32 Delay { get => _Delay; set { if (OnPropertyChanging("Delay", value)) { _Delay = value; OnPropertyChanged("Delay"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Remark", "备注", "")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }

        private Boolean _Deleted;
        /// <summary>删除</summary>
        [DisplayName("删除")]
        [Description("删除")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Deleted", "删除", "")]
        public Boolean Deleted { get => _Deleted; set { if (OnPropertyChanging("Deleted", value)) { _Deleted = value; OnPropertyChanged("Deleted"); } } }

        private String _Owner;
        /// <summary>拥有者</summary>
        [DisplayName("拥有者")]
        [Description("拥有者")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Owner", "拥有者", "")]
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
                    case "SegId": return _SegId;
                    case "Name": return _Name;
                    case "RouteId": return _RouteId;
                    case "StrPoints": return _StrPoints;
                    case "StartSegId": return _StartSegId;
                    case "EndSegId": return _EndSegId;
                    case "MaxSpeed": return _MaxSpeed;
                    case "Delay": return _Delay;
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
                    case "SegId": _SegId = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "RouteId": _RouteId = value.ToInt(); break;
                    case "StrPoints": _StrPoints = Convert.ToString(value); break;
                    case "StartSegId": _StartSegId = value.ToInt(); break;
                    case "EndSegId": _EndSegId = value.ToInt(); break;
                    case "MaxSpeed": _MaxSpeed = value.ToDouble(); break;
                    case "Delay": _Delay = value.ToInt(); break;
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
        /// <summary>取得路段字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编码</summary>
            public static readonly Field SegId = FindByName("SegId");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>路线编码</summary>
            public static readonly Field RouteId = FindByName("RouteId");

            /// <summary>点位</summary>
            public static readonly Field StrPoints = FindByName("StrPoints");

            /// <summary>起始路段编码</summary>
            public static readonly Field StartSegId = FindByName("StartSegId");

            /// <summary>结束路段编码</summary>
            public static readonly Field EndSegId = FindByName("EndSegId");

            /// <summary>最大速度</summary>
            public static readonly Field MaxSpeed = FindByName("MaxSpeed");

            /// <summary>延时多久</summary>
            public static readonly Field Delay = FindByName("Delay");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            /// <summary>删除</summary>
            public static readonly Field Deleted = FindByName("Deleted");

            /// <summary>拥有者</summary>
            public static readonly Field Owner = FindByName("Owner");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得路段字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编码</summary>
            public const String SegId = "SegId";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>路线编码</summary>
            public const String RouteId = "RouteId";

            /// <summary>点位</summary>
            public const String StrPoints = "StrPoints";

            /// <summary>起始路段编码</summary>
            public const String StartSegId = "StartSegId";

            /// <summary>结束路段编码</summary>
            public const String EndSegId = "EndSegId";

            /// <summary>最大速度</summary>
            public const String MaxSpeed = "MaxSpeed";

            /// <summary>延时多久</summary>
            public const String Delay = "Delay";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>删除</summary>
            public const String Deleted = "Deleted";

            /// <summary>拥有者</summary>
            public const String Owner = "Owner";
        }
        #endregion
    }
}