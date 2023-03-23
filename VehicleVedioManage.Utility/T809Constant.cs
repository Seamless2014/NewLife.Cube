using System.Collections;

namespace VehicleVedioManage.Utility
{
    /// <summary>
    /// 809常量
    /// </summary>
    public class T809Constant
    {
        /// <summary>
        /// 主链路登录请求消息
        /// </summary>
        public const int UP_CONNECT_REQ = 0x1001;
        /// <summary>
        /// 主链路登录应答消息
        /// </summary>
        public const int UP_CONNECT_REP = 0x1002;
        /// <summary>
        /// 主链路注销请求消息
        /// </summary>
        public const int UP_DICONNECE_REQ = 0x1003;
        /// <summary>
        /// 主链路注销应答消息
        /// </summary>
        public const int UP_DISCONNECT_RSP = 0x1004;
        /// <summary>
        /// 主链路连接保持请求消息
        /// </summary>
        public const int UP_LINKETEST_REQ = 0x1005;
        /// <summary>
        /// 主链路连接保持应答消息
        /// </summary>
        public const int UP_LINKTEST_RSP = 0x1006;
        /// <summary>
        /// 主链路断开通知消息
        /// </summary>
        public const int UP_DISCONNECT_INFORM = 0x1007;
        /// <summary>
        /// 下级平台主动关闭链路通知消息
        /// </summary>
        public const int UP_CLOSELINK_INFORM = 0x1008;
        /// <summary>
        /// 从链路连接请求消息
        /// </summary>
        public const int DOWN_CONNECT_REQ = 0x9001;
        /// <summary>
        /// 从链路连接应答消息
        /// </summary>
        public const int DOWN_CONNECT_RSP = 0x9002;
        /// <summary>
        /// 从链路注销请求消息
        /// </summary>
        public const int DOWN_DISCONNECT_REQ = 0x9003;
        /// <summary>
        /// 从链路注销应答消息
        /// </summary>
        public const int DOWN_DICONNECT_RSP = 0x9004;
        /// <summary>
        /// 从链路连接请求保持消息
        /// </summary>
        public const int DOWN_LINKTEST_REQ = 0x9005;
        /// <summary>
        /// 从链路连接保持应答消息
        /// </summary>
        public const int DOWN_LINKTEST_RSP = 0x9006;
        /// <summary>
        /// 从链路断开通知消息
        /// </summary>
        public const int DOWN_DISCONNECT_INFORM = 0x9007;
        /// <summary>
        /// 上级平台主动关闭链路通知消息
        /// </summary>
        public const int DOWN_CLOSELINK_INFORM = 0x9008;
        /// <summary>
        /// 接收定位信息数量通知消息
        /// </summary>
        public const int DOWN_TOTAL_RECY_BACK_MSG = 0x9101;
        /// <summary>
        /// 主链路动态信息交互消息
        /// </summary>
        public const int UP_EXG_MSG = 0x1200;
        /// <summary>
        /// 从链路动态信息交互消息
        /// </summary>
        public const int DOWN_EXG_MSG = 0x9200;
        /// <summary>
        /// 主链路平台间信息交互消息
        /// </summary>
        public const int UP_PLAFORM_MSG = 0x1300;
        /// <summary>
        /// 从链路平台间信息交互消息
        /// </summary>
        public const int DOWN_PLATFORM_MSG = 0x9300;
        /// <summary>
        /// 主链路报警消息交互消息
        /// </summary>
        public const int UP_WARN_MSG = 0x1400;
        /// <summary>
        /// 从链路报警消息交互消息
        /// </summary>
        public const int DOWN_WARN_MSG = 0x9400;
        /// <summary>
        /// 主链路车辆监管消息
        /// </summary>
        public const int UP_CTRL_MSG = 0x1500;
        /// <summary>
        /// 从链路车辆监管消息
        /// </summary>
        public const int DOWN_CTRL_MSG = 0x9500;
        /// <summary>
        /// 主链路静态信息交互消息
        /// </summary>
        public const int UP_BASE_MSG = 0x1600;
        /// <summary>
        /// 从链路静态信息交互消息
        /// </summary>
        public const int DOWN_BASE_MSG = 0x9600;

        /// <summary>
        /// 上传车辆注册消息
        /// </summary>
        public const int UP_EXG_MSG_REGISTER = 0x1201; 
        /// <summary>
        /// 实时上传车辆定位消息
        /// </summary>
        public const int UP_EXG_MSG_REAL_LOCATION = 0x1202;
        /// <summary>
        /// 车辆定位信息自动补报
        /// </summary>
        public const int UP_EXG_MSG_HISTORY_LOCATION = 0x1203; 
        /// <summary>
        /// 启动车辆定位信息交换应答
        /// </summary>
        public const int UP_EXG_MSG_RETURN_STARTUP_ACK = 0x1205;
        /// <summary>
        /// 结束车辆定位信息交换应答
        /// </summary>
        public const int UP_EXG_MSG_RETURN_END_ACK = 0x1206;
        /// <summary>
        /// 申请交换指定车辆定位信息请求
        /// </summary>
        public const int UP_EXG_MSG_APPLY_FOR_MONITOR_STARTUP = 0x1207;
        /// <summary>
        /// 取消交换指定车辆定位信息请求
        /// </summary>
        public const int UP_EXG_MSG_APPLY_FOR_MONITOR_END = 0x1208;
        /// <summary>
        /// 补发车辆定位信息请求
        /// </summary>
        public const int UP_EXG_MSG_APPLY_HISGNSSDATA_REQ = 0x1209; 
        /// <summary>
        /// 上报车辆驾驶员身份识别信息应答
        /// </summary>
        public const int UP_EXG_MSG_REPORT_DRIVER_INFO_ACK = 0x120A; 
        /// <summary>
        /// 上报车辆电子运单应答
        /// </summary>
        public const int UP_EXG_MSG_TAKE_EWAYBILL_ACK = 0x120B; 
        /// <summary>
        /// 交换车辆定位信息
        /// </summary>
        public const int DOWN_EXG_MSG_CAR_LOCATION = 0x9202;
        /// <summary>
        /// 车辆定位信息交换补发
        /// </summary>
        public const int DOWN_EXG_MSG_HISTORY_ARCOSSAREA = 0x9203; 
        /// <summary>
        /// 交换车辆静态信息
        /// </summary>
        public const int DOWN_EXG_MSG_CAR_INFO = 0x9204; 
        /// <summary>
        /// 启动车辆定位信息交换请求
        /// </summary>
        public const int DOWN_EXG_MSG_RETURN_STARTUP = 0x9205;
        /// <summary>
        /// 结束车辆定位信息交换请求
        /// </summary>
        public const int DOWN_EXG_MSG_RETURN_END = 0x9206; 
        /// <summary>
        /// 申请交换指定车辆定位信息应答
        /// </summary>
        public const int DOWN_EXG_MSG_APPLY_FOR_MONITOR_SARTUP_ACK = 0x9207;
        /// <summary>
        /// 取消交换指定车辆定位信息应答
        /// </summary>
        public const int DOWN_EXG_MSG_APPLY_FOR_MONITOR_END_ACK = 0x9208; 
        /// <summary>
        /// 补发车辆定位信息应答
        /// </summary>
        public const int DOWN_EXG_MSG_APPLY_HISGNSSDATA_ACK = 0x9209; 
        /// <summary>
        /// 上报车辆驾驶员身份识别信息请求
        /// </summary>
        public const int DOWN_EXG_MSG_REPORT_DRIVER_INFO = 0x920A;
        /// <summary>
        /// 上报车辆电子运单请求
        /// </summary>
        public const int DOWN_EXG_MSG_TAKE_EWAYBILL_REQ = 0x920B; 
        /// <summary>
        /// 平台查岗
        /// </summary>
        public const int UP_PLATFORM_MSG_POST_QUERY_ACK = 0x1301;
        /// <summary>
        /// 下发平台间报文应答
        /// </summary>
        public const int UP_PLATFORM_MSG_INFO_ACK = 0x1302; 
        /// <summary>
        /// 平台查岗请求
        /// </summary>
        public const int DOWN_PLATFORM_MSG_POST_QUERY_REQ = 0x9301; 
        /// <summary>
        /// 下发平台间报文请求
        /// </summary>
        public const int DOWN_PLATFORM_MSG_INFO_REQ = 0x9302; 
        /// <summary>
        /// 报文督办应答
        /// </summary>
        public const int UP_WARN_MSG_URGE_TODO_ACK = 0x1401; 
        /// <summary>
        /// 上报报警信息
        /// </summary>
        public const int UP_WARN_MSG_ADPT_INFO = 0x1402; 
        /// <summary>
        /// 报警督办请求
        /// </summary>
        public const int DOWN_WARN_MSG_URGE_TODO_REQ = 0x9401;
        /// <summary>
        /// 报警预警
        /// </summary>
        public const int DOWN_WARN_MSG_INFORM_TIPS = 0x9402; 
        /// <summary>
        /// 实时交互报警信息
        /// </summary>
        public const int DOWN_WARN_MSG_EXG_INFORM = 0x9403; 
        /// <summary>
        /// 车辆单向监听应答
        /// </summary>
        public const int UP_CTRL_MSG_MONITOR_VEHICLE_ACK = 0x1501; 
        /// <summary>
        /// 车辆拍照应答
        /// </summary>
        public const int UP_CTRL_MSG_TAKE_PHOTO_ACK = 0x1502; 
        /// <summary>
        /// 下发车辆报文应答
        /// </summary>
        public const int UP_CTRL_MSG_TEXT_INFO_ACK = 0x1503; 
        /// <summary>
        /// 上报车辆行驶记录应答
        /// </summary>
        public const int UP_CTRL_MSG__TAKE_TRAVEL_ACK = 0x1504;
        /// <summary>
        /// 车辆应急接入监管平台应答消息
        /// </summary>
        public const int UP_CTRL_MSG_EMERGENCY_MONITORING_ACK = 0x1505; 
        /// <summary>
        /// 车辆单向接入请求
        /// </summary>
        public const int DOWN_CTRL_MSG_MONITOR_VEHICLE_REQ = 0x9501;
        /// <summary>
        /// 车辆拍照请求
        /// </summary>
        public const int DOWN_CTRL_MSG_TAKE_PHOTO_REQ = 0x9502; 
        /// <summary>
        /// 下发车辆报文请求
        /// </summary>
        public const int DOWN_CTRL_MSG_TEXT_INFO_ACK = 0x9503; 
        /// <summary>
        /// 上报车辆行驶记录请求
        /// </summary>
        public const int DOWN_CTRL_MSG_TAKE_TRAVEL_REQ = 0x9504;
        /// <summary>
        /// 车辆应急接入监管平台应答消息
        /// </summary>
        public const int DOWN_CTRL_MSG_EMERGENCY_MONITORING_REQ = 0x9505; 
        /// <summary>
        /// 补报车辆静态信息应答
        /// </summary>
        public const int UP_BASE_MSG_VEHICLE_ADDED_ACK = 0x1601; 
        /// <summary>
        /// 补报车辆静态信息请求
        /// </summary>
        public const int DOWN_BASE_MSG_VEHICLE_ADDED = 0x9601; 

        public const int UP_EXG_MSG_CORP_CENTER_INFO = 0x0201;

        public const int DOWN_EXG_MSG_CORP_CENTER_INFO_ACK = 0xF201; 


        public static Hashtable msgMap = new Hashtable();

        public static string getMsgDescr(int msgId)
        {
            return "";
        }


    }
}
