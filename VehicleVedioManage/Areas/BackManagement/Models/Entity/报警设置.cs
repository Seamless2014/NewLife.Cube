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
    /// <summary>报警设置.报警类型设置，报警是否启用以及声音、弹窗提醒等</summary>
    [Serializable]
    [DataObject]
    [Description("报警设置.报警类型设置，报警是否启用以及声音、弹窗提醒等")]
    [BindIndex("IU_AlarmConfig_Name", true, "Name")]
    [BindTable("AlarmConfig", Description = "报警设置.报警类型设置，报警是否启用以及声音、弹窗提醒等", ConnName = "VehicleGPSVideo", DbType = DatabaseType.None)]
    public partial class AlarmConfig
    {
        #region 属性
        private Int32 _ID;
        /// <summary>报警设置主键</summary>
        [DisplayName("报警设置主键")]
        [Description("报警设置主键")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "报警设置主键", "")]
        public Int32 ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private String _Code;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Code", "编码", "")]
        public String Code { get => _Code; set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Name", "名称", "", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _alarmType;
        /// <summary>报警类型</summary>
        [DisplayName("报警类型")]
        [Description("报警类型")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn("alarmType", "报警类型", "")]
        public String alarmType { get => _alarmType; set { if (OnPropertyChanging("alarmType", value)) { _alarmType = value; OnPropertyChanged("alarmType"); } } }

        private Boolean _Enabled;
        /// <summary>启用</summary>
        [DisplayName("启用")]
        [Description("启用")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Enabled", "启用", "")]
        public Boolean Enabled { get => _Enabled; set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } } }

        private Boolean _soundEnabled;
        /// <summary>声音</summary>
        [DisplayName("声音")]
        [Description("声音")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("soundEnabled", "声音", "")]
        public Boolean soundEnabled { get => _soundEnabled; set { if (OnPropertyChanging("soundEnabled", value)) { _soundEnabled = value; OnPropertyChanged("soundEnabled"); } } }

        private Boolean _popupEnabled;
        /// <summary>弹窗</summary>
        [DisplayName("弹窗")]
        [Description("弹窗")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("popupEnabled", "弹窗", "")]
        public Boolean popupEnabled { get => _popupEnabled; set { if (OnPropertyChanging("popupEnabled", value)) { _popupEnabled = value; OnPropertyChanged("popupEnabled"); } } }

        private String _alarmSource;
        /// <summary>报警源</summary>
        [DisplayName("报警源")]
        [Description("报警源")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("alarmSource", "报警源", "")]
        public String alarmSource { get => _alarmSource; set { if (OnPropertyChanging("alarmSource", value)) { _alarmSource = value; OnPropertyChanged("alarmSource"); } } }

        private Boolean _statisticEnabled;
        /// <summary>统计</summary>
        [DisplayName("统计")]
        [Description("统计")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("statisticEnabled", "统计", "")]
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
                    case "ID": return _ID;
                    case "Code": return _Code;
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
                    case "ID": _ID = value.ToInt(); break;
                    case "Code": _Code = Convert.ToString(value); break;
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
            /// <summary>报警设置主键</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>编码</summary>
            public static readonly Field Code = FindByName("Code");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>报警类型</summary>
            public static readonly Field alarmType = FindByName("alarmType");

            /// <summary>启用</summary>
            public static readonly Field Enabled = FindByName("Enabled");

            /// <summary>声音</summary>
            public static readonly Field soundEnabled = FindByName("soundEnabled");

            /// <summary>弹窗</summary>
            public static readonly Field popupEnabled = FindByName("popupEnabled");

            /// <summary>报警源</summary>
            public static readonly Field alarmSource = FindByName("alarmSource");

            /// <summary>统计</summary>
            public static readonly Field statisticEnabled = FindByName("statisticEnabled");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得报警设置字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>报警设置主键</summary>
            public const String ID = "ID";

            /// <summary>编码</summary>
            public const String Code = "Code";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>报警类型</summary>
            public const String alarmType = "alarmType";

            /// <summary>启用</summary>
            public const String Enabled = "Enabled";

            /// <summary>声音</summary>
            public const String soundEnabled = "soundEnabled";

            /// <summary>弹窗</summary>
            public const String popupEnabled = "popupEnabled";

            /// <summary>报警源</summary>
            public const String alarmSource = "alarmSource";

            /// <summary>统计</summary>
            public const String statisticEnabled = "statisticEnabled";
        }
        #endregion
    }
}