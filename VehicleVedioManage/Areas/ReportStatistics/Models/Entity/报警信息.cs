using System;
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
    /// <summary>报警信息</summary>
    [Serializable]
    [DataObject]
    [Description("报警信息")]
    [BindTable("WarnMsgInform", Description = "报警信息", ConnName = "VehicleGPSVideo", DbType = DatabaseType.SqlServer)]
    public partial class WarnMsgInform
    {
        #region 属性
        private Decimal _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn("ID", "编号", "numeric(19, 0)")]
        public Decimal ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private String _Addiinfo;
        /// <summary>附加信息</summary>
        [Category("扩展信息")]
        [DisplayName("附加信息")]
        [Description("附加信息")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Addiinfo", "附加信息", "varchar(255)")]
        public String Addiinfo { get => _Addiinfo; set { if (OnPropertyChanging("Addiinfo", value)) { _Addiinfo = value; OnPropertyChanged("Addiinfo"); } } }

        private Int32 _Angle;
        /// <summary>角度</summary>
        [DisplayName("角度")]
        [Description("角度")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Angle", "角度", "int")]
        public Int32 Angle { get => _Angle; set { if (OnPropertyChanging("Angle", value)) { _Angle = value; OnPropertyChanged("Angle"); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [Category("扩展信息")]
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("CreateTime", "创建时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private Int32 _DataType;
        /// <summary>数据类型</summary>
        [DisplayName("数据类型")]
        [Description("数据类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("DataType", "数据类型", "int")]
        public Int32 DataType { get => _DataType; set { if (OnPropertyChanging("DataType", value)) { _DataType = value; OnPropertyChanged("DataType"); } } }

        private String _DealResult;
        /// <summary>处理结果</summary>
        [Category("扩展信息")]
        [DisplayName("处理结果")]
        [Description("处理结果")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("DealResult", "处理结果", "varchar(255)")]
        public String DealResult { get => _DealResult; set { if (OnPropertyChanging("DealResult", value)) { _DealResult = value; OnPropertyChanged("DealResult"); } } }

        private DateTime _DealTime;
        /// <summary>处理时间</summary>
        [Category("扩展信息")]
        [DisplayName("处理时间")]
        [Description("处理时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("DealTime", "处理时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime DealTime { get => _DealTime; set { if (OnPropertyChanging("DealTime", value)) { _DealTime = value; OnPropertyChanged("DealTime"); } } }

        private String _ExtInfo;
        /// <summary>外部信息</summary>
        [Category("扩展信息")]
        [DisplayName("外部信息")]
        [Description("外部信息")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("ExtInfo", "外部信息", "varchar(255)")]
        public String ExtInfo { get => _ExtInfo; set { if (OnPropertyChanging("ExtInfo", value)) { _ExtInfo = value; OnPropertyChanged("ExtInfo"); } } }

        private Int32 _Height;
        /// <summary>高度</summary>
        [DisplayName("高度")]
        [Description("高度")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Height", "高度", "int")]
        public Int32 Height { get => _Height; set { if (OnPropertyChanging("Height", value)) { _Height = value; OnPropertyChanged("Height"); } } }

        private Int32 _InfoId;
        /// <summary>信息编码</summary>
        [DisplayName("信息编码")]
        [Description("信息编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("InfoId", "信息编码", "int")]
        public Int32 InfoId { get => _InfoId; set { if (OnPropertyChanging("InfoId", value)) { _InfoId = value; OnPropertyChanged("InfoId"); } } }

        private Double _Lat;
        /// <summary>纬度</summary>
        [DisplayName("纬度")]
        [Description("纬度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Lat", "纬度", "float")]
        public Double Lat { get => _Lat; set { if (OnPropertyChanging("Lat", value)) { _Lat = value; OnPropertyChanged("Lat"); } } }

        private Int32 _Loading;
        /// <summary>加载</summary>
        [Category("扩展信息")]
        [DisplayName("加载")]
        [Description("加载")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Loading", "加载", "int")]
        public Int32 Loading { get => _Loading; set { if (OnPropertyChanging("Loading", value)) { _Loading = value; OnPropertyChanged("Loading"); } } }

        private Double _Lon;
        /// <summary>经度</summary>
        [DisplayName("经度")]
        [Description("经度")]
        [DataObjectField(false, false, true, 53)]
        [BindColumn("Lon", "经度", "float")]
        public Double Lon { get => _Lon; set { if (OnPropertyChanging("Lon", value)) { _Lon = value; OnPropertyChanged("Lon"); } } }

        private Int32 _OrgWarnId;
        /// <summary>原始报警编码</summary>
        [DisplayName("原始报警编码")]
        [Description("原始报警编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("OrgWarnId", "原始报警编码", "int")]
        public Int32 OrgWarnId { get => _OrgWarnId; set { if (OnPropertyChanging("OrgWarnId", value)) { _OrgWarnId = value; OnPropertyChanged("OrgWarnId"); } } }

        private Int32 _Origin;
        /// <summary>原始</summary>
        [DisplayName("原始")]
        [Description("原始")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Origin", "原始", "int")]
        public Int32 Origin { get => _Origin; set { if (OnPropertyChanging("Origin", value)) { _Origin = value; OnPropertyChanged("Origin"); } } }

        private DateTime _RedoEndTime;
        /// <summary>重做结束时间</summary>
        [Category("扩展信息")]
        [DisplayName("重做结束时间")]
        [Description("重做结束时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("RedoEndTime", "重做结束时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime RedoEndTime { get => _RedoEndTime; set { if (OnPropertyChanging("RedoEndTime", value)) { _RedoEndTime = value; OnPropertyChanged("RedoEndTime"); } } }

        private Int32 _RedoFlag;
        /// <summary>重做标识</summary>
        [Category("扩展信息")]
        [DisplayName("重做标识")]
        [Description("重做标识")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("RedoFlag", "重做标识", "int")]
        public Int32 RedoFlag { get => _RedoFlag; set { if (OnPropertyChanging("RedoFlag", value)) { _RedoFlag = value; OnPropertyChanged("RedoFlag"); } } }

        private Decimal _RedoId;
        /// <summary>重做编码</summary>
        [Category("扩展信息")]
        [DisplayName("重做编码")]
        [Description("重做编码")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn("RedoId", "重做编码", "numeric(19, 0)")]
        public Decimal RedoId { get => _RedoId; set { if (OnPropertyChanging("RedoId", value)) { _RedoId = value; OnPropertyChanged("RedoId"); } } }

        private DateTime _RedoTime;
        /// <summary>重做时间</summary>
        [Category("扩展信息")]
        [DisplayName("重做时间")]
        [Description("重做时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("RedoTime", "重做时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime RedoTime { get => _RedoTime; set { if (OnPropertyChanging("RedoTime", value)) { _RedoTime = value; OnPropertyChanged("RedoTime"); } } }

        private Int32 _Result;
        /// <summary>结果</summary>
        [DisplayName("结果")]
        [Description("结果")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Result", "结果", "int")]
        public Int32 Result { get => _Result; set { if (OnPropertyChanging("Result", value)) { _Result = value; OnPropertyChanged("Result"); } } }

        private Int32 _Speed;
        /// <summary>速度</summary>
        [DisplayName("速度")]
        [Description("速度")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Speed", "速度", "int")]
        public Int32 Speed { get => _Speed; set { if (OnPropertyChanging("Speed", value)) { _Speed = value; OnPropertyChanged("Speed"); } } }

        private Int32 _Status1;
        /// <summary>状态1</summary>
        [DisplayName("状态1")]
        [Description("状态1")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Status1", "状态1", "int")]
        public Int32 Status1 { get => _Status1; set { if (OnPropertyChanging("Status1", value)) { _Status1 = value; OnPropertyChanged("Status1"); } } }

        private Int32 _Status2;
        /// <summary>状态2</summary>
        [Category("扩展信息")]
        [DisplayName("状态2")]
        [Description("状态2")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Status2", "状态2", "int")]
        public Int32 Status2 { get => _Status2; set { if (OnPropertyChanging("Status2", value)) { _Status2 = value; OnPropertyChanged("Status2"); } } }

        private Int32 _Status3;
        /// <summary>状态3</summary>
        [Category("扩展信息")]
        [DisplayName("状态3")]
        [Description("状态3")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Status3", "状态3", "int")]
        public Int32 Status3 { get => _Status3; set { if (OnPropertyChanging("Status3", value)) { _Status3 = value; OnPropertyChanged("Status3"); } } }

        private Int32 _SubType;
        /// <summary>子类型</summary>
        [DisplayName("子类型")]
        [Description("子类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("SubType", "子类型", "int")]
        public Int32 SubType { get => _SubType; set { if (OnPropertyChanging("SubType", value)) { _SubType = value; OnPropertyChanged("SubType"); } } }

        private String _Text;
        /// <summary>文本</summary>
        [Category("扩展信息")]
        [DisplayName("文本")]
        [Description("文本")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("Text", "文本", "varchar(255)")]
        public String Text { get => _Text; set { if (OnPropertyChanging("Text", value)) { _Text = value; OnPropertyChanged("Text"); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [Category("扩展信息")]
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("UpdateTime", "更新时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

        private Byte _Valid;
        /// <summary>有效</summary>
        [DisplayName("有效")]
        [Description("有效")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("IsValid", "有效", "tinyint")]
        public Byte IsValid { get => _Valid; set { if (OnPropertyChanging("IsValid", value)) { _Valid = value; OnPropertyChanged("IsValid"); } } }

        private Int32 _VehicleId;
        /// <summary>车辆编码</summary>
        [DisplayName("车辆编码")]
        [Description("车辆编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("VehicleId", "车辆编码", "int")]
        public Int32 VehicleId { get => _VehicleId; set { if (OnPropertyChanging("VehicleId", value)) { _VehicleId = value; OnPropertyChanged("VehicleId"); } } }

        private String _WarnContent;
        /// <summary>报警内容</summary>
        [DisplayName("报警内容")]
        [Description("报警内容")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("WarnContent", "报警内容", "varchar(255)")]
        public String WarnContent { get => _WarnContent; set { if (OnPropertyChanging("WarnContent", value)) { _WarnContent = value; OnPropertyChanged("WarnContent"); } } }

        private Int32 _WarnSrc;
        /// <summary>报警源</summary>
        [DisplayName("报警源")]
        [Description("报警源")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("WarnSrc", "报警源", "int")]
        public Int32 WarnSrc { get => _WarnSrc; set { if (OnPropertyChanging("WarnSrc", value)) { _WarnSrc = value; OnPropertyChanged("WarnSrc"); } } }

        private DateTime _WarnTime;
        /// <summary>报警时间</summary>
        [DisplayName("报警时间")]
        [Description("报警时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn("WarnTime", "报警时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime WarnTime { get => _WarnTime; set { if (OnPropertyChanging("WarnTime", value)) { _WarnTime = value; OnPropertyChanged("WarnTime"); } } }

        private Int32 _WarnType;
        /// <summary>报警类型</summary>
        [DisplayName("报警类型")]
        [Description("报警类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("WarnType", "报警类型", "int")]
        public Int32 WarnType { get => _WarnType; set { if (OnPropertyChanging("WarnType", value)) { _WarnType = value; OnPropertyChanged("WarnType"); } } }

        private String _DealUser;
        /// <summary>处理人</summary>
        [Category("扩展信息")]
        [DisplayName("处理人")]
        [Description("处理人")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("DealUser", "处理人", "varchar(50)")]
        public String DealUser { get => _DealUser; set { if (OnPropertyChanging("DealUser", value)) { _DealUser = value; OnPropertyChanged("DealUser"); } } }

        private Int32 _Mask;
        /// <summary>掩盖层</summary>
        [DisplayName("掩盖层")]
        [Description("掩盖层")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("Mask", "掩盖层", "int")]
        public Int32 Mask { get => _Mask; set { if (OnPropertyChanging("Mask", value)) { _Mask = value; OnPropertyChanged("Mask"); } } }

        private Int32 _ExtId;
        /// <summary>外部编码</summary>
        [DisplayName("外部编码")]
        [Description("外部编码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("ExtId", "外部编码", "int")]
        public Int32 ExtId { get => _ExtId; set { if (OnPropertyChanging("ExtId", value)) { _ExtId = value; OnPropertyChanged("ExtId"); } } }
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
                    case "Addiinfo": return _Addiinfo;
                    case "Angle": return _Angle;
                    case "CreateTime": return _CreateTime;
                    case "DataType": return _DataType;
                    case "DealResult": return _DealResult;
                    case "DealTime": return _DealTime;
                    case "ExtInfo": return _ExtInfo;
                    case "Height": return _Height;
                    case "InfoId": return _InfoId;
                    case "Lat": return _Lat;
                    case "Loading": return _Loading;
                    case "Lon": return _Lon;
                    case "OrgWarnId": return _OrgWarnId;
                    case "Origin": return _Origin;
                    case "RedoEndTime": return _RedoEndTime;
                    case "RedoFlag": return _RedoFlag;
                    case "RedoId": return _RedoId;
                    case "RedoTime": return _RedoTime;
                    case "Result": return _Result;
                    case "Speed": return _Speed;
                    case "Status1": return _Status1;
                    case "Status2": return _Status2;
                    case "Status3": return _Status3;
                    case "SubType": return _SubType;
                    case "Text": return _Text;
                    case "UpdateTime": return _UpdateTime;
                    case "IsValid": return _Valid;
                    case "VehicleId": return _VehicleId;
                    case "WarnContent": return _WarnContent;
                    case "WarnSrc": return _WarnSrc;
                    case "WarnTime": return _WarnTime;
                    case "WarnType": return _WarnType;
                    case "DealUser": return _DealUser;
                    case "Mask": return _Mask;
                    case "ExtId": return _ExtId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = Convert.ToDecimal(value); break;
                    case "Addiinfo": _Addiinfo = Convert.ToString(value); break;
                    case "Angle": _Angle = value.ToInt(); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "DataType": _DataType = value.ToInt(); break;
                    case "DealResult": _DealResult = Convert.ToString(value); break;
                    case "DealTime": _DealTime = value.ToDateTime(); break;
                    case "ExtInfo": _ExtInfo = Convert.ToString(value); break;
                    case "Height": _Height = value.ToInt(); break;
                    case "InfoId": _InfoId = value.ToInt(); break;
                    case "Lat": _Lat = value.ToDouble(); break;
                    case "Loading": _Loading = value.ToInt(); break;
                    case "Lon": _Lon = value.ToDouble(); break;
                    case "OrgWarnId": _OrgWarnId = value.ToInt(); break;
                    case "Origin": _Origin = value.ToInt(); break;
                    case "RedoEndTime": _RedoEndTime = value.ToDateTime(); break;
                    case "RedoFlag": _RedoFlag = value.ToInt(); break;
                    case "RedoId": _RedoId = Convert.ToDecimal(value); break;
                    case "RedoTime": _RedoTime = value.ToDateTime(); break;
                    case "Result": _Result = value.ToInt(); break;
                    case "Speed": _Speed = value.ToInt(); break;
                    case "Status1": _Status1 = value.ToInt(); break;
                    case "Status2": _Status2 = value.ToInt(); break;
                    case "Status3": _Status3 = value.ToInt(); break;
                    case "SubType": _SubType = value.ToInt(); break;
                    case "Text": _Text = Convert.ToString(value); break;
                    case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
                    case "IsValid": _Valid = Convert.ToByte(value); break;
                    case "VehicleId": _VehicleId = value.ToInt(); break;
                    case "WarnContent": _WarnContent = Convert.ToString(value); break;
                    case "WarnSrc": _WarnSrc = value.ToInt(); break;
                    case "WarnTime": _WarnTime = value.ToDateTime(); break;
                    case "WarnType": _WarnType = value.ToInt(); break;
                    case "DealUser": _DealUser = Convert.ToString(value); break;
                    case "Mask": _Mask = value.ToInt(); break;
                    case "ExtId": _ExtId = value.ToInt(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得报警信息字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>附加信息</summary>
            public static readonly Field Addiinfo = FindByName("Addiinfo");

            /// <summary>角度</summary>
            public static readonly Field Angle = FindByName("Angle");

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>数据类型</summary>
            public static readonly Field DataType = FindByName("DataType");

            /// <summary>处理结果</summary>
            public static readonly Field DealResult = FindByName("DealResult");

            /// <summary>处理时间</summary>
            public static readonly Field DealTime = FindByName("DealTime");

            /// <summary>外部信息</summary>
            public static readonly Field ExtInfo = FindByName("ExtInfo");

            /// <summary>高度</summary>
            public static readonly Field Height = FindByName("Height");

            /// <summary>信息编码</summary>
            public static readonly Field InfoId = FindByName("InfoId");

            /// <summary>纬度</summary>
            public static readonly Field Lat = FindByName("Lat");

            /// <summary>加载</summary>
            public static readonly Field Loading = FindByName("Loading");

            /// <summary>经度</summary>
            public static readonly Field Lon = FindByName("Lon");

            /// <summary>原始报警编码</summary>
            public static readonly Field OrgWarnId = FindByName("OrgWarnId");

            /// <summary>原始</summary>
            public static readonly Field Origin = FindByName("Origin");

            /// <summary>重做结束时间</summary>
            public static readonly Field RedoEndTime = FindByName("RedoEndTime");

            /// <summary>重做标识</summary>
            public static readonly Field RedoFlag = FindByName("RedoFlag");

            /// <summary>重做编码</summary>
            public static readonly Field RedoId = FindByName("RedoId");

            /// <summary>重做时间</summary>
            public static readonly Field RedoTime = FindByName("RedoTime");

            /// <summary>结果</summary>
            public static readonly Field Result = FindByName("Result");

            /// <summary>速度</summary>
            public static readonly Field Speed = FindByName("Speed");

            /// <summary>状态1</summary>
            public static readonly Field Status1 = FindByName("Status1");

            /// <summary>状态2</summary>
            public static readonly Field Status2 = FindByName("Status2");

            /// <summary>状态3</summary>
            public static readonly Field Status3 = FindByName("Status3");

            /// <summary>子类型</summary>
            public static readonly Field SubType = FindByName("SubType");

            /// <summary>文本</summary>
            public static readonly Field Text = FindByName("Text");

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            /// <summary>有效</summary>
            public static readonly Field IsValid = FindByName("IsValid");

            /// <summary>车辆编码</summary>
            public static readonly Field VehicleId = FindByName("VehicleId");

            /// <summary>报警内容</summary>
            public static readonly Field WarnContent = FindByName("WarnContent");

            /// <summary>报警源</summary>
            public static readonly Field WarnSrc = FindByName("WarnSrc");

            /// <summary>报警时间</summary>
            public static readonly Field WarnTime = FindByName("WarnTime");

            /// <summary>报警类型</summary>
            public static readonly Field WarnType = FindByName("WarnType");

            /// <summary>处理人</summary>
            public static readonly Field DealUser = FindByName("DealUser");

            /// <summary>掩盖层</summary>
            public static readonly Field Mask = FindByName("Mask");

            /// <summary>外部编码</summary>
            public static readonly Field ExtId = FindByName("ExtId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得报警信息字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String ID = "ID";

            /// <summary>附加信息</summary>
            public const String Addiinfo = "Addiinfo";

            /// <summary>角度</summary>
            public const String Angle = "Angle";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>数据类型</summary>
            public const String DataType = "DataType";

            /// <summary>处理结果</summary>
            public const String DealResult = "DealResult";

            /// <summary>处理时间</summary>
            public const String DealTime = "DealTime";

            /// <summary>外部信息</summary>
            public const String ExtInfo = "ExtInfo";

            /// <summary>高度</summary>
            public const String Height = "Height";

            /// <summary>信息编码</summary>
            public const String InfoId = "InfoId";

            /// <summary>纬度</summary>
            public const String Lat = "Lat";

            /// <summary>加载</summary>
            public const String Loading = "Loading";

            /// <summary>经度</summary>
            public const String Lon = "Lon";

            /// <summary>原始报警编码</summary>
            public const String OrgWarnId = "OrgWarnId";

            /// <summary>原始</summary>
            public const String Origin = "Origin";

            /// <summary>重做结束时间</summary>
            public const String RedoEndTime = "RedoEndTime";

            /// <summary>重做标识</summary>
            public const String RedoFlag = "RedoFlag";

            /// <summary>重做编码</summary>
            public const String RedoId = "RedoId";

            /// <summary>重做时间</summary>
            public const String RedoTime = "RedoTime";

            /// <summary>结果</summary>
            public const String Result = "Result";

            /// <summary>速度</summary>
            public const String Speed = "Speed";

            /// <summary>状态1</summary>
            public const String Status1 = "Status1";

            /// <summary>状态2</summary>
            public const String Status2 = "Status2";

            /// <summary>状态3</summary>
            public const String Status3 = "Status3";

            /// <summary>子类型</summary>
            public const String SubType = "SubType";

            /// <summary>文本</summary>
            public const String Text = "Text";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            /// <summary>有效</summary>
            public const String IsValid = "IsValid";

            /// <summary>车辆编码</summary>
            public const String VehicleId = "VehicleId";

            /// <summary>报警内容</summary>
            public const String WarnContent = "WarnContent";

            /// <summary>报警源</summary>
            public const String WarnSrc = "WarnSrc";

            /// <summary>报警时间</summary>
            public const String WarnTime = "WarnTime";

            /// <summary>报警类型</summary>
            public const String WarnType = "WarnType";

            /// <summary>处理人</summary>
            public const String DealUser = "DealUser";

            /// <summary>掩盖层</summary>
            public const String Mask = "Mask";

            /// <summary>外部编码</summary>
            public const String ExtId = "ExtId";
        }
        #endregion
    }
}