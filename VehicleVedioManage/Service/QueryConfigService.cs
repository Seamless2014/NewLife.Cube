//using System.Collections;
//using System.Reflection;
//using System.Text;
//using System.Xml;
//using NewLife.Log;
//using VehicleVedioManage.BasicData.Entity;
//using XCode.Membership;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 查询配置服务
//    /// </summary>
//    public class QueryConfigService : IQueryConfigService
//    {
//        /// <summary>
//        /// 查询配置映射
//        /// </summary>
//        public IDictionary queryConfigMap { get; set; }
//        /// <summary>
//        /// 查询条件对应的字段名称的映射，写入到Excel报表中
//        /// </summary>
//        public IDictionary queryConditionMap { get; set; }
//        /// <summary>
//        /// 列字典
//        /// </summary>
//        public IDictionary columnMap { get; set; }
//        /// <summary>
//        /// 测试名称
//        /// </summary>
//        public String testName { get; set; }

//        /// <summary>
//        /// 基础数据服务
//        /// </summary>
//        public IBasicDataService BasicDataService { get; set; }
//        /// <summary>
//        /// 车辆服务
//        /// </summary>
//        public IVehicleService VehicleService { get; set; }
//        /// <summary>
//        /// 获取查询条件
//        /// </summary>
//        /// <param name="queryId"></param>
//        /// <returns></returns>
//        public IList getQueryCondition(String queryId)
//        {
//            if (this.queryConditionMap == null || queryConditionMap.Contains(queryId) == false)
//                return new ArrayList();

//            return (IList)queryConditionMap[queryId];
//        }
//        /// <summary>
//        /// 获取查询列
//        /// </summary>
//        /// <param name="queryId"></param>
//        /// <returns></returns>
//        public IList getQueryColumn(String queryId)
//        {
//            if (this.columnMap == null || columnMap.Contains(queryId) == false)
//                return new ArrayList();

//            return (IList)columnMap[queryId];
//        }
//        /// <summary>
//        /// 转换
//        /// </summary>
//        /// <param name="rowData"></param>
//        /// <param name="queryId"></param>
//        public void convert(Hashtable rowData, String queryId)
//        {
//            if (queryConditionMap == null || queryConditionMap.Count == 0)
//                loadConfig();

//            if (queryConfigMap.Contains(queryId) == false)
//            {
//                return;
//            }

//            IDictionary fieldConfig = (IDictionary)queryConfigMap[queryId];
//            if (fieldConfig != null)
//            {
//                ICollection fields = fieldConfig.Keys;
//                foreach (String field in fields)
//                {
//                    String parentCode = (String)fieldConfig[field];
//                    String fieldValue = "" + rowData[field];

//                    if (field.Equals("plateNo") && parentCode.Equals("depName"))
//                    {
//                        // 根据车辆转换成部门
//                        String depName = "";
//                        Department dep = VehicleService
//                                .getDepartmentByPlateNo(fieldValue);
//                        if (dep != null)
//                            depName = dep.Name;
//                        rowData["depName"] = depName;
//                    }
//                    else if (parentCode.Equals("timeSpan"))
//                    {
//                        Double timeSpan = Double.Parse(""
//                                + rowData[field]);
//                        if (timeSpan > 0)
//                        {
//                            rowData[field] = getIntervalDescr(timeSpan);
//                        }
//                    }
//                    else if (parentCode.Equals("GpsStatus"))
//                    {
//                        String status = getStatusDescr(fieldValue);
//                        rowData[field] = status;
//                    }
//                    else if (parentCode.Equals("DirectionDescr"))
//                    {
//                        int direction = int.Parse(fieldValue);
//                        String strDirection = this.getDirectionDescr(direction);
//                        rowData["directionDescr"] = strDirection;
//                    }
//                    else if (parentCode.Equals("AlarmStateDescr"))
//                    {
//                        int alarmState = int.Parse(fieldValue);
//                        String strAlarmState = this.getAlarmDescr(alarmState);
//                        rowData["alarmStateDescr"] = strAlarmState;
//                    }
//                    else if (parentCode.Equals("808CmdType"))
//                    {
//                        try
//                        {
//                            int cmdType = (int)rowData[field];
//                            String strCmd = cmdType.ToString("X");
//                            if (strCmd.Length < 4)
//                                strCmd = "0" + strCmd;
//                            strCmd = "0x" + strCmd;
//                            String descr = JT808Constants.GetDescr(strCmd);
//                            rowData[field] = descr;
//                        }
//                        catch (Exception e)
//                        {
//                            XTrace.WriteException(e);
//                        }
//                    }
//                    else if (parentCode.Equals("809CmdType"))
//                    {
//                        try
//                        {
//                            int cmdType = (int)rowData["cmd"];
//                            int subType = (int)rowData["subCmd"];
//                            subType = subType == 0 ? cmdType : subType;
//                            String subDescr = T809Constant.getMsgDescr(subType);
//                            subDescr = "[" + "0x" + subType.ToString("X").PadLeft(0) + "]" + subDescr;
//                            rowData["cmdType"] = "0x" + cmdType.ToString("X").PadLeft(0);
//                            rowData["subDescr"] = subDescr;
//                        }
//                        catch (Exception e)
//                        {
//                            XTrace.WriteException(e);
//                        }
//                    }
//                    else
//                    {
//                        convert(rowData, field, parentCode);
//                    }
//                }
//            }

//        }
//        /// <summary>
//        /// 基础数据转换，将数据表中标志字段转换为文字描述
//        /// </summary>
//        /// <param name="rowData"></param>
//        /// <param name="field"></param>
//        /// <param name="parentCode"></param>
//        /// <returns></returns>
//        protected String convert(Hashtable rowData, String field, String parentCode)
//        {
//            String fieldValue = "" + rowData[field];
//            BasicInfo bd = BasicDataService.getBasicDataByCode(fieldValue,
//                    parentCode);
//            if (bd != null)
//            {
//                rowData[field] = bd.Name;
//                return bd.Name;
//            }
//            return "";
//        }
//        /// <summary>
//        /// 转换
//        /// </summary>
//        /// <param name="fieldValue"></param>
//        /// <param name="parentCode"></param>
//        /// <returns></returns>
//        protected String convert(String fieldValue, String parentCode)
//        {
//            BasicInfo bd = BasicDataService.getBasicDataByCode(fieldValue,
//                    parentCode);
//            if (bd != null)
//            {
//                return bd.Name;
//            }
//            return "";
//        }
//        /// <summary>
//        /// 获取状态描述
//        /// </summary>
//        /// <param name="strStatus"></param>
//        /// <returns></returns>
//        protected String getStatusDescr(String strStatus)
//        {

//            int status = int.Parse(strStatus);
//            strStatus = status.ToString("");
//            strStatus = strStatus.PadLeft(32, '0');
//            //strStatus = getStatusDescr(strStatus);

//            StringBuilder sb = new StringBuilder();

//            if (String.IsNullOrEmpty(strStatus) == false)
//            {
//                char[] ch = strStatus.ToCharArray();
//                if (ch.Length == 32)
//                {
//                    int m = 31;
//                    int c = ch[m - 0] - 48;
//                    sb.Append(c == 1 ? "ACC开" : "ACC关").Append(",");
//                    c = ch[m - 1] - 48;
//                    sb.Append(c == 1 ? "定位" : "未定位").Append(",");
//                    c = ch[m - 4] - 48;
//                    sb.Append(c == 1 ? "停运" : "运营").Append(",");
//                    c = ch[m - 10] - 48;
//                    sb.Append(c == 1 ? "油路断开" : "油路正常").Append(",");
//                    c = ch[m - 11] - 48;
//                    sb.Append(c == 1 ? "电路断开" : "电路正常").Append(",");
//                    c = ch[m - 12] - 48;
//                    sb.Append(c == 1 ? "车门加锁" : "车门解锁").Append(",");
//                }
//            }

//            return sb.ToString();
//        }
//        /// <summary>
//        /// 获取方向描述
//        /// </summary>
//        /// <param name="direction"></param>
//        /// <returns></returns>
//        protected String getDirectionDescr(int direction)
//        {
//            Hashtable directionMap = new Hashtable();
//            String descr = "";
//            if (direction == 0)
//            {
//                descr = "正东";
//            }
//            else if (direction == 90)
//            {
//                descr = "正北";
//            }
//            else if (direction == 180)
//            {
//                descr = "正西";
//            }
//            else if (direction == 270)
//            {
//                descr = "正南";
//            }
//            else if (direction == 45)
//            {
//                descr = "东北";
//            }
//            else if (direction == 135)
//            {
//                descr = "西北";
//            }
//            else if (direction == 225)
//            {
//                descr = "西南";
//            }
//            else if (direction == 315)
//            {
//                descr = "东南";
//            }
//            else if (direction < 90)
//            {
//                descr = "东偏北" + direction + "度";
//            }
//            else if (direction > 90 && direction < 180)
//            {
//                descr = "西偏北" + (180 - direction) + "度";
//            }
//            else if (direction > 180 && direction < 270)
//            {
//                descr = "西偏南" + (direction - 180) + "度";
//            }
//            else if (direction > 270 && direction < 360)
//            {
//                descr = "东偏南" + (360 - direction) + "度";
//            }
//            return descr;
//        }


//        /// <summary>
//        /// 报警描述
//        /// </summary>
//        /// <param name="alarmState"></param>
//        /// <returns></returns>
//        protected String getAlarmDescr(int alarmState)
//        {
//            StringBuilder sb = new StringBuilder();
//            String alarm = Convert.ToString(alarmState, 2);
//            alarm = alarm.PadLeft(32, '0');
//            if (String.IsNullOrEmpty(alarm) == false)
//            {
//                char[] ch = alarm.ToCharArray();
//                for (int m = 0; m < ch.Length; m++)
//                {
//                    int tag = int.Parse("" + ch[m]);
//                    if (tag == 1)
//                    {
//                        int alarmId = 31 - m; // 倒序，转换为部标的报警序号
//                        BasicInfo bd = BasicDataService.getBasicDataByCode(""
//                                + alarmId, "AlarmType");
//                        if (bd != null)
//                        {
//                            sb.Append(bd.Name).Append(",");
//                        }
//                    }
//                }
//            }

//            return sb.ToString();
//        }


//        /// <summary>
//        /// 间隔描述
//        /// </summary>
//        /// <param name="minutes"></param>
//        /// <returns></returns>
//        private String getIntervalDescr(double minutes)
//        {
//            StringBuilder descr = new StringBuilder();

//            if (minutes > 1440)
//            {
//                descr.Append(((int)minutes) / 1440 + "天");
//                minutes -= ((int)minutes / 1440) * 1440;
//            }
//            if (minutes > 60)
//            {
//                descr.Append(((int)minutes) / 60 + "小时");
//                minutes -= ((int)minutes / 60) * 60;
//            }
//            if (minutes >= 1)
//            {
//                descr.Append((int)minutes + "分");
//                minutes -= (int)minutes;
//            }
//            if (minutes > 0)
//            {
//                descr.Append((int)(minutes * 60) + "秒");
//            }
//            return descr.ToString();
//        }
//        /// <summary>
//        /// 加载配置
//        /// </summary>
//        public void loadConfig()
//        {
//            Assembly assembly = GetType().Assembly;
//            System.IO.Stream streamSmall = assembly.GetManifestResourceStream("GpsNET.Config.QueryConfig.xml");
//            XmlReader sr = new XmlTextReader(streamSmall);
//            XmlDocument doc = new XmlDocument();
//            doc.Load(sr);

//            XmlNode queryConfigRoot = doc.SelectSingleNode("/configs/queryConfigMap");
//            XmlNode root = queryConfigRoot.ChildNodes[0];
//            queryConfigMap = new Dictionary<String, Hashtable>();
//            foreach (XmlNode n in root.ChildNodes)
//            {
//                XmlElement xe = (XmlElement)n;
//                String key = "" + xe.GetAttribute("key");

//                XmlNode xn = n.ChildNodes[0];
//                XmlNodeList ls = xn.ChildNodes;
//                Hashtable ht = new Hashtable();
//                if (n.GetType() == typeof(XmlComment))
//                    continue;
//                foreach (XmlNode ch in ls)
//                {
//                    //XmlNode ch = cd.ChildNodes[0];
//                    XmlElement ce = (XmlElement)ch;
//                    String chKey = "" + ce.GetAttribute("key");
//                    ht[chKey] = "" + ce.GetAttribute("value");
//                }

//                queryConfigMap[key] = ht;

//            }

//            XmlNode columnMapRoot = doc.SelectSingleNode("/configs/columnMap");
//            root = columnMapRoot.ChildNodes[0];
//            columnMap = new Dictionary<String, IList>();
//            foreach (XmlNode n in root.ChildNodes)
//            {
//                if (n.GetType() == typeof(XmlComment))
//                    continue;
//                XmlElement xe = (XmlElement)n;
//                String key = "" + xe.GetAttribute("key");

//                XmlNode xn = n.ChildNodes[0];
//                XmlNodeList ls = xn.ChildNodes;
//                ArrayList ht = new ArrayList();
//                foreach (XmlNode ch in ls)
//                {
//                    //XmlNode ch = cd.ChildNodes[0];
//                    ht.Add(ch.InnerText);
//                }

//                this.columnMap[key] = ht;

//            }

//            XmlNode conditionMapRoot = doc.SelectSingleNode("/configs/queryConditionMap");
//            root = conditionMapRoot.ChildNodes[0];
//            this.queryConditionMap = new Dictionary<String, IList>();
//            foreach (XmlNode n in root.ChildNodes)
//            {
//                if (n.GetType() == typeof(XmlComment))
//                    continue;
//                XmlElement xe = (XmlElement)n;
//                String key = "" + xe.GetAttribute("key");

//                XmlNode xn = n.ChildNodes[0];
//                XmlNodeList ls = xn.ChildNodes;
//                ArrayList ht = new ArrayList();
//                foreach (XmlNode cd in ls)
//                {
//                    //XmlNode ch = cd.ChildNodes[0];
//                    ht.Add(cd.InnerText);
//                }
//                queryConditionMap[key] = ht;
//            }
//        }
//    }
//}
