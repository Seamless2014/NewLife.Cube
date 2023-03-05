using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace GPSPlatform.FenceManagement.Entity
{
    /// <summary>区域</summary>
    [Serializable]
    [DataObject]
    [Description("区域")]
    [BindIndex("PK_Region", true, "Id")]
    [BindTable("Region", Description = "区域", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class Region
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("Id", "编号", "int")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private String _CenterLatLng;
        /// <summary>中心经纬度</summary>
        [DisplayName("中心经纬度")]
        [Description("中心经纬度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CenterLatLng", "中心经纬度", "varchar(50)")]
        public String CenterLatLng { get => _CenterLatLng; set { if (OnPropertyChanging("CenterLatLng", value)) { _CenterLatLng = value; OnPropertyChanged("CenterLatLng"); } } }

        private String _Code;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Code", "编码", "varchar(10)")]
        public String Code { get => _Code; set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } } }

        private String _LatLons;
        /// <summary>经纬度</summary>
        [DisplayName("经纬度")]
        [Description("经纬度")]
        [DataObjectField(false, false, true, 5000)]
        [BindColumn("LatLons", "经纬度", "varchar(5000)")]
        public String LatLons { get => _LatLons; set { if (OnPropertyChanging("LatLons", value)) { _LatLons = value; OnPropertyChanged("LatLons"); } } }

        private Int32 _Level;
        /// <summary>层级</summary>
        [DisplayName("层级")]
        [Description("层级")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Level", "层级", "int")]
        public Int32 Level { get => _Level; set { if (OnPropertyChanging("Level", value)) { _Level = value; OnPropertyChanged("Level"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Name", "名称", "nvarchar(50)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private Int32 _Parent;
        /// <summary>上级</summary>
        [DisplayName("上级")]
        [Description("上级")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Parent", "上级", "int")]
        public Int32 Parent { get => _Parent; set { if (OnPropertyChanging("Parent", value)) { _Parent = value; OnPropertyChanged("Parent"); } } }

        private String _FullName;
        /// <summary>全称</summary>
        [DisplayName("全称")]
        [Description("全称")]
        [DataObjectField(false, false, true, 250)]
        [BindColumn("FullName", "全称", "nvarchar(250)")]
        public String FullName { get => _FullName; set { if (OnPropertyChanging("FullName", value)) { _FullName = value; OnPropertyChanged("FullName"); } } }
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
                    case "CenterLatLng": return _CenterLatLng;
                    case "Code": return _Code;
                    case "LatLons": return _LatLons;
                    case "Level": return _Level;
                    case "Name": return _Name;
                    case "Parent": return _Parent;
                    case "FullName": return _FullName;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "CenterLatLng": _CenterLatLng = Convert.ToString(value); break;
                    case "Code": _Code = Convert.ToString(value); break;
                    case "LatLons": _LatLons = Convert.ToString(value); break;
                    case "Level": _Level = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Parent": _Parent = value.ToInt(); break;
                    case "FullName": _FullName = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得区域字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary>中心经纬度</summary>
            public static readonly Field CenterLatLng = FindByName("CenterLatLng");

            /// <summary>编码</summary>
            public static readonly Field Code = FindByName("Code");

            /// <summary>经纬度</summary>
            public static readonly Field LatLons = FindByName("LatLons");

            /// <summary>层级</summary>
            public static readonly Field Level = FindByName("Level");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>上级</summary>
            public static readonly Field Parent = FindByName("Parent");

            /// <summary>全称</summary>
            public static readonly Field FullName = FindByName("FullName");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得区域字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String Id = "Id";

            /// <summary>中心经纬度</summary>
            public const String CenterLatLng = "CenterLatLng";

            /// <summary>编码</summary>
            public const String Code = "Code";

            /// <summary>经纬度</summary>
            public const String LatLons = "LatLons";

            /// <summary>层级</summary>
            public const String Level = "Level";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>上级</summary>
            public const String Parent = "Parent";

            /// <summary>全称</summary>
            public const String FullName = "FullName";
        }
        #endregion
    }
}