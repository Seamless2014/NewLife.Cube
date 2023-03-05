using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace GPSPlatform.BasicData.Entity
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [BindTable("view_get_date", Description = "", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class ViewGetDate
    {
        #region 属性
        private DateTime _Today;
        /// <summary></summary>
        [DisplayName("Today")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn("Today", "", "datetime", Precision = 3, Scale = 0)]
        public DateTime Today { get => _Today; set { if (OnPropertyChanging("Today", value)) { _Today = value; OnPropertyChanged("Today"); } } }
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
                    case "Today": return _Today;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Today": _Today = value.ToDateTime(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得ViewGetDate字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Today = FindByName("Today");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得ViewGetDate字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Today = "Today";
        }
        #endregion
    }
}