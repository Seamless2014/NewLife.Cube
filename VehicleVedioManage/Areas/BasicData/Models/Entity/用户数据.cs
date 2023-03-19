using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace VehicleVedioManage.BasicData.Entity
{
    /// <summary>用户数据</summary>
    [Serializable]
    [DataObject]
    [Description("用户数据")]
    [BindTable("UserData", Description = "用户数据", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class UserData
    {
        #region 属性
        private Int32 _UserId;
        /// <summary>用户编码</summary>
        [DisplayName("用户编码")]
        [Description("用户编码")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("UserId", "用户编码", "int")]
        public Int32 UserId { get => _UserId; set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } } }

        private String _Uid;
        /// <summary>UID</summary>
        [DisplayName("UID")]
        [Description("UID")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UID", "UID", "nvarchar(50)")]
        public String Uid { get => _Uid; set { if (OnPropertyChanging("Uid", value)) { _Uid = value; OnPropertyChanged("Uid"); } } }

        private String _IP;
        /// <summary>IP</summary>
        [DisplayName("IP")]
        [Description("IP")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("IP", "IP", "nvarchar(50)")]
        public String IP { get => _IP; set { if (OnPropertyChanging("IP", value)) { _IP = value; OnPropertyChanged("IP"); } } }

        private Int32 _LoginTimes;
        /// <summary>登录次数</summary>
        [DisplayName("登录次数")]
        [Description("登录次数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("LoginTimes", "登录次数", "int")]
        public Int32 LoginTimes { get => _LoginTimes; set { if (OnPropertyChanging("LoginTimes", value)) { _LoginTimes = value; OnPropertyChanged("LoginTimes"); } } }

        private DateTime _CreateDate;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateDate", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateDate { get => _CreateDate; set { if (OnPropertyChanging("CreateDate", value)) { _CreateDate = value; OnPropertyChanged("CreateDate"); } } }

        private DateTime _UpdateDate;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateDate", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateDate { get => _UpdateDate; set { if (OnPropertyChanging("UpdateDate", value)) { _UpdateDate = value; OnPropertyChanged("UpdateDate"); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Name", "名称", "nvarchar(50)", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Status", "状态", "nvarchar(50)")]
        public String Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }
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
                    case "UserId": return _UserId;
                    case "Uid": return _Uid;
                    case "IP": return _IP;
                    case "LoginTimes": return _LoginTimes;
                    case "CreateDate": return _CreateDate;
                    case "UpdateDate": return _UpdateDate;
                    case "Name": return _Name;
                    case "Status": return _Status;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "UserId": _UserId = value.ToInt(); break;
                    case "Uid": _Uid = Convert.ToString(value); break;
                    case "IP": _IP = Convert.ToString(value); break;
                    case "LoginTimes": _LoginTimes = value.ToInt(); break;
                    case "CreateDate": _CreateDate = value.ToDateTime(); break;
                    case "UpdateDate": _UpdateDate = value.ToDateTime(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "Status": _Status = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得用户数据字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>用户编码</summary>
            public static readonly Field UserId = FindByName("UserId");

            /// <summary>UID</summary>
            public static readonly Field Uid = FindByName("Uid");

            /// <summary>IP</summary>
            public static readonly Field IP = FindByName("IP");

            /// <summary>登录次数</summary>
            public static readonly Field LoginTimes = FindByName("LoginTimes");

            /// <summary>创建时间</summary>
            public static readonly Field CreateDate = FindByName("CreateDate");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateDate = FindByName("UpdateDate");

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得用户数据字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>用户编码</summary>
            public const String UserId = "UserId";

            /// <summary>UID</summary>
            public const String Uid = "Uid";

            /// <summary>IP</summary>
            public const String IP = "IP";

            /// <summary>登录次数</summary>
            public const String LoginTimes = "LoginTimes";

            /// <summary>创建时间</summary>
            public const String CreateDate = "CreateDate";

            /// <summary>更新时间</summary>
            public const String UpdateDate = "UpdateDate";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>状态</summary>
            public const String Status = "Status";
        }
        #endregion
    }
}