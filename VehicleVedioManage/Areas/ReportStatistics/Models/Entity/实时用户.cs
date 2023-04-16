﻿using System;
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
    /// <summary>实时用户</summary>
    [Serializable]
    [DataObject]
    [Description("实时用户")]
    [BindIndex("IU_UserGpsRealData_UserName", true, "UserName")]
    [BindTable("UserGpsRealData", Description = "实时用户", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class UserGpsRealData
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "编号", "")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private Int32 _UserId;
        /// <summary>用户编码</summary>
        [DisplayName("用户编码")]
        [Description("用户编码")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("UserId", "用户编码", "")]
        public Int32 UserId { get => _UserId; set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } } }

        private Double _Accuracy;
        /// <summary>精确程度</summary>
        [DisplayName("精确程度")]
        [Description("精确程度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Accuracy", "精确程度", "")]
        public Double Accuracy { get => _Accuracy; set { if (OnPropertyChanging("Accuracy", value)) { _Accuracy = value; OnPropertyChanged("Accuracy"); } } }

        private String _Location;
        /// <summary>位置</summary>
        [DisplayName("位置")]
        [Description("位置")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn("Location", "位置", "")]
        public String Location { get => _Location; set { if (OnPropertyChanging("Location", value)) { _Location = value; OnPropertyChanged("Location"); } } }

        private Int32 _Direction;
        /// <summary>方向</summary>
        [DisplayName("方向")]
        [Description("方向")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Direction", "方向", "")]
        public Int32 Direction { get => _Direction; set { if (OnPropertyChanging("Direction", value)) { _Direction = value; OnPropertyChanged("Direction"); } } }

        private DateTime _SendTime;
        /// <summary>发送时间</summary>
        [DisplayName("发送时间")]
        [Description("发送时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("SendTime", "发送时间", "", Precision = 0, Scale = 3)]
        public DateTime SendTime { get => _SendTime; set { if (OnPropertyChanging("SendTime", value)) { _SendTime = value; OnPropertyChanged("SendTime"); } } }

        private Double _Longitude;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Longitude", "经度", "")]
        public Double Longitude { get => _Longitude; set { if (OnPropertyChanging("Longitude", value)) { _Longitude = value; OnPropertyChanged("Longitude"); } } }

        private Double _Latitude;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Latitude", "纬度", "")]
        public Double Latitude { get => _Latitude; set { if (OnPropertyChanging("Latitude", value)) { _Latitude = value; OnPropertyChanged("Latitude"); } } }

        private DateTime _CreateDate;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateDate", "创建时间", "", Precision = 0, Scale = 3)]
        public DateTime CreateDate { get => _CreateDate; set { if (OnPropertyChanging("CreateDate", value)) { _CreateDate = value; OnPropertyChanged("CreateDate"); } } }

        private Double _Velocity;
        /// <summary>速度</summary>
        [DisplayName("速度")]
        [Description("速度")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Velocity", "速度", "")]
        public Double Velocity { get => _Velocity; set { if (OnPropertyChanging("Velocity", value)) { _Velocity = value; OnPropertyChanged("Velocity"); } } }
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
                    case "UserId": return _UserId;
                    case "Accuracy": return _Accuracy;
                    case "Location": return _Location;
                    case "Direction": return _Direction;
                    case "SendTime": return _SendTime;
                    case "Longitude": return _Longitude;
                    case "Latitude": return _Latitude;
                    case "CreateDate": return _CreateDate;
                    case "Velocity": return _Velocity;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = value.ToInt(); break;
                    case "UserId": _UserId = value.ToInt(); break;
                    case "Accuracy": _Accuracy = value.ToDouble(); break;
                    case "Location": _Location = Convert.ToString(value); break;
                    case "Direction": _Direction = value.ToInt(); break;
                    case "SendTime": _SendTime = value.ToDateTime(); break;
                    case "Longitude": _Longitude = value.ToDouble(); break;
                    case "Latitude": _Latitude = value.ToDouble(); break;
                    case "CreateDate": _CreateDate = value.ToDateTime(); break;
                    case "Velocity": _Velocity = value.ToDouble(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得实时用户字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>用户编码</summary>
            public static readonly Field UserId = FindByName("UserId");

            /// <summary>用户名</summary>
            public static readonly Field UserName = FindByName("UserName");

            /// <summary>精确程度</summary>
            public static readonly Field Accuracy = FindByName("Accuracy");

            /// <summary>位置</summary>
            public static readonly Field Location = FindByName("Location");

            /// <summary>方向</summary>
            public static readonly Field Direction = FindByName("Direction");

            /// <summary>发送时间</summary>
            public static readonly Field SendTime = FindByName("SendTime");

            /// <summary>经度</summary>
            public static readonly Field Longitude = FindByName("Longitude");

            /// <summary>纬度</summary>
            public static readonly Field Latitude = FindByName("Latitude");

            /// <summary>创建时间</summary>
            public static readonly Field CreateDate = FindByName("CreateDate");

            /// <summary>速度</summary>
            public static readonly Field Velocity = FindByName("Velocity");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得实时用户字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String ID = "ID";

            /// <summary>用户编码</summary>
            public const String UserId = "UserId";

            /// <summary>用户名</summary>
            public const String UserName = "UserName";

            /// <summary>精确程度</summary>
            public const String Accuracy = "Accuracy";

            /// <summary>位置</summary>
            public const String Location = "Location";

            /// <summary>方向</summary>
            public const String Direction = "Direction";

            /// <summary>发送时间</summary>
            public const String SendTime = "SendTime";

            /// <summary>经度</summary>
            public const String Longitude = "Longitude";

            /// <summary>纬度</summary>
            public const String Latitude = "Latitude";

            /// <summary>创建时间</summary>
            public const String CreateDate = "CreateDate";

            /// <summary>速度</summary>
            public const String Velocity = "Velocity";
        }
        #endregion
    }
}