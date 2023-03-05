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
    /// <summary>报警设置</summary>
    [Serializable]
    [DataObject]
    [Description("报警设置")]
    [BindTable("AlarmConfig", Description = "报警设置", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class AlarmConfig
    {
        #region 属性
        private Int32 _id;
        /// <summary></summary>
        [DisplayName("id")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("id", "", "int")]
        public Int32 id { get => _id; set { if (OnPropertyChanging("id", value)) { _id = value; OnPropertyChanged("id"); } } }

        private String _Name;
        /// <summary></summary>
        [DisplayName("Name")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("name", "", "nvarchar(255)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _alarmType;
        /// <summary></summary>
        [DisplayName("alarmType")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("alarmType", "", "nvarchar(255)")]
        public String alarmType { get => _alarmType; set { if (OnPropertyChanging("alarmType", value)) { _alarmType = value; OnPropertyChanged("alarmType"); } } }

        private Boolean _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Enabled", "", "bit")]
        public Boolean Enabled { get => _Enabled; set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } } }

        private Boolean _soundEnabled;
        /// <summary></summary>
        [DisplayName("soundEnabled")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("soundEnabled", "", "bit")]
        public Boolean soundEnabled { get => _soundEnabled; set { if (OnPropertyChanging("soundEnabled", value)) { _soundEnabled = value; OnPropertyChanged("soundEnabled"); } } }

        private Boolean _popupEnabled;
        /// <summary></summary>
        [DisplayName("popupEnabled")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("popupEnabled", "", "bit")]
        public Boolean popupEnabled { get => _popupEnabled; set { if (OnPropertyChanging("popupEnabled", value)) { _popupEnabled = value; OnPropertyChanged("popupEnabled"); } } }

        private String _alarmSource;
        /// <summary></summary>
        [DisplayName("alarmSource")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("alarmSource", "", "nvarchar(50)")]
        public String alarmSource { get => _alarmSource; set { if (OnPropertyChanging("alarmSource", value)) { _alarmSource = value; OnPropertyChanged("alarmSource"); } } }

        private Boolean _statisticEnabled;
        /// <summary></summary>
        [DisplayName("statisticEnabled")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("statisticEnabled", "", "bit")]
        public Boolean statisticEnabled { get => _statisticEnabled; set { if (OnPropertyChanging("statisticEnabled", value)) { _statisticEnabled = value; OnPropertyChanged("statisticEnabled"); } } }
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
                    case "id": return _id;
                    case "Name": return _Name;
                    case "alarmType": return _alarmType;
                    case "Enabled": return _Enabled;
                    case "soundEnabled": return _soundEnabled;
                    case "popupEnabled": return _popupEnabled;
                    case "alarmSource": return _alarmSource;
                    case "statisticEnabled": return _statisticEnabled;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "id": _id = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "alarmType": _alarmType = Convert.ToString(value); break;
                    case "Enabled": _Enabled = value.ToBoolean(); break;
                    case "soundEnabled": _soundEnabled = value.ToBoolean(); break;
                    case "popupEnabled": _popupEnabled = value.ToBoolean(); break;
                    case "alarmSource": _alarmSource = Convert.ToString(value); break;
                    case "statisticEnabled": _statisticEnabled = value.ToBoolean(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得报警设置字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field id = FindByName("id");

            /// <summary></summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary></summary>
            public static readonly Field alarmType = FindByName("alarmType");

            /// <summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

            /// <summary></summary>
            public static readonly Field soundEnabled = FindByName("soundEnabled");

            /// <summary></summary>
            public static readonly Field popupEnabled = FindByName("popupEnabled");

            /// <summary></summary>
            public static readonly Field alarmSource = FindByName("alarmSource");

            /// <summary></summary>
            public static readonly Field statisticEnabled = FindByName("statisticEnabled");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得报警设置字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String id = "id";

            /// <summary></summary>
            public const String Name = "Name";

            /// <summary></summary>
            public const String alarmType = "alarmType";

            /// <summary></summary>
            public const String Enabled = "Enabled";

            /// <summary></summary>
            public const String soundEnabled = "soundEnabled";

            /// <summary></summary>
            public const String popupEnabled = "popupEnabled";

            /// <summary></summary>
            public const String alarmSource = "alarmSource";

            /// <summary></summary>
            public const String statisticEnabled = "statisticEnabled";
        }
        #endregion
    }
}