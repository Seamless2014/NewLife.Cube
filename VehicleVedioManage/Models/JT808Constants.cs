using System.Collections;

namespace VehicleVedioManage.Web.Models
{
    /// <summary>
    /// JT808常量
    /// </summary>
    public class JT808Constants
    {
        /// <summary>
        /// 指令描述
        /// </summary>
        public static Hashtable CommandDescr = new Hashtable();
        /// <summary>
        /// 指令记录
        /// </summary>
        public static Hashtable recorderCmdMap = new Hashtable();
        /// <summary>
        /// 加载指令描述映射
        /// </summary>
        private static void loadMap()
        {
            CommandDescr["0x8804"] = "录音开始命令";
            CommandDescr["0x8201"] = "位置信息查询";// "点名";
            CommandDescr["0x8600"] = "设置圆形区域";
            CommandDescr["0x8601"] = "删除圆形区域";
            CommandDescr["0x8602"] = "设置矩形区域";
            CommandDescr["0x8603"] = "删除矩形区域";
            CommandDescr["0x8604"] = "设置多边形区域";
            CommandDescr["0x8605"] = "删除多边形区域";
            CommandDescr["0x8606"] = "设置线路";
            CommandDescr["0x8607"] = "删除线路";
            CommandDescr["0x8802"] = "媒体检索";
            CommandDescr["0x8803"] = "媒体上传";
            CommandDescr["0x8805"] = "单条存储多媒体上传命令";
            CommandDescr["0x8202"] = "临时位置跟踪控制";
            CommandDescr["0x8300"] = "文本信息下发";
            CommandDescr["0x8103"] = "设置终端参数";
            CommandDescr["0x8104"] = "查询终端参数";
            CommandDescr["0x8105"] = "终端控制";
            //CommandDescr["0x8801"] = "拍照";
            CommandDescr["0x8301"] = "设置事件";
            CommandDescr["0x8302"] = "提问下发";
            CommandDescr["0x8303"] = "信息点播菜单设置";
            CommandDescr["0x8304"] = "信息服务";
            CommandDescr["0x8400"] = "电话回拨";
            CommandDescr["0x8401"] = "电话本设置";
            CommandDescr["0x8500"] = "车辆控制";
            CommandDescr["0x8700"] = "行车记录仪采集";
            CommandDescr["0x8701"] = "行车记录参数下传命令";
            CommandDescr["0x8801"] = "摄像头立即拍摄命令";
            CommandDescr["0x8800"] = "多媒体数据上传应答";
            CommandDescr["0x8900"] = "数据下行透传";


            CommandDescr["0x0200"] = "位置信息汇报";
            CommandDescr["0x8001"] = "平台通用应答";
            CommandDescr["0x0002"] = "终端心跳";
            CommandDescr["0x8003"] = "补传分包请求";
            CommandDescr["0x8100"] = "终端注册应答";
            CommandDescr["0x0003"] = "终端注销";
            CommandDescr["0x8106"] = "查询指定终端参数";
            CommandDescr["0x8107"] = "查询终端属性";
            CommandDescr["0x0107"] = "查询终端属性应答";
            CommandDescr["0x8108"] = "下发终端升级包";
            CommandDescr["0x0108"] = "终端升级结果通知";
            CommandDescr["0x0700"] = "行驶记录仪数据上传";
            CommandDescr["0x8702"] = "上报驾驶员身份信息请求";
            CommandDescr["0x0900"] = "数据上行透传";
            CommandDescr["0x0901"] = "数据压缩上报";
            CommandDescr["0x8A00"] = "平台 RSA 公钥";
            CommandDescr["0x0A00"] = "终端 RSA 公钥";

            CommandDescr["0x0001"] = "终端通用应答";
            CommandDescr["0x0101"] = "终端注销";
            CommandDescr["0x0102"] = "终端鉴权";
            CommandDescr["0x0100"] = "终端注册";
            CommandDescr["0x0800"] = "多媒体事件信息上传";
            CommandDescr["0x0801"] = "多媒体数据包上传";
            CommandDescr["0x0802"] = "存储多媒体数据检索应答";
            CommandDescr["0x0805"] = "摄像头立即拍摄命令应答";
            CommandDescr["0x0104"] = "查询终端参数应答";
            CommandDescr["0x0201"] = "位置信息查询应答";// "点名应答";

            CommandDescr["0x0301"] = "事件报告";
            CommandDescr["0x0302"] = "提问应答";
            CommandDescr["0x0303"] = "终端信息点播";
            CommandDescr["0x0702"] = "驾驶员身份采集上报";
            CommandDescr["0x0701"] = "电子运单上报";
            CommandDescr["0x0704"] = "定位数据补报";

            recorderCmdMap.Add("driverInfo", 0x01);
            recorderCmdMap.Add("clock", 0x02);
            recorderCmdMap.Add("mileageIn360h", 0x03);
            recorderCmdMap.Add("feature", 0x04);
            recorderCmdMap.Add("speedIn360h", 0x05);
            recorderCmdMap.Add("vehicleInfo", 0x06);
            recorderCmdMap.Add("accident", 0x07);
            recorderCmdMap.Add("mileageIn2d", 0x08);
            recorderCmdMap.Add("speedIn2d", 0x09);
            recorderCmdMap.Add("overdrive", 0x11);
            recorderCmdMap.Add("setdriverInfo", 0x81);
            recorderCmdMap.Add("setvehicleInfo", 0x82);
            recorderCmdMap.Add("setclock", 0xC2);
            recorderCmdMap.Add("setfeature", 0xC3);

        }

        /// <summary>
        /// 获取指令记录
        /// </summary>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static int getRecorderCmd(String cmdType)
        {
            if (recorderCmdMap.Count == 0)
            {
                loadMap();
            }
            if (recorderCmdMap.ContainsKey(cmdType))
                return (int)recorderCmdMap[cmdType];
            return 0;
        }
        /// <summary>
        /// 获取指令描述
        /// </summary>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static string GetDescr(string cmdType)
        {
            if (CommandDescr.Count == 0)
                loadMap();
            return "" + CommandDescr[cmdType];
        }
        /// <summary>
        /// 录音命令
        /// </summary>
        public const int CMD_AUDIO_RECORDER = 0x8804;
        /// <summary>
        /// (点名)位置信息查询
        /// </summary>
        public const int CMD_REAL_MONITOR = 0x8201;
        /// <summary>
        /// 设置圆形区域
        /// </summary>
        public const int CMD_CIRCLE_CONFIG = 0x8600;
        /// <summary>
        /// 删除圆形区域
        /// </summary>
        public static int CMD_DELETE_CIRCLE = 0x8601;
        /// <summary>
        /// 设置矩形区域
        /// </summary>
        public const int CMD_RECT_CONFIG = 0x8602;
        /// <summary>
        /// 删除矩形区域
        /// </summary>
        public static int CMD_DELETE_RECT = 0x8603;
        /// <summary>
        /// 设置多边形区域
        /// </summary>
        public const int CMD_POLYGON_CONFIG = 0x8604;
        /// <summary>
        /// 删除多边形区域
        /// </summary>
        public static int CMD_DELETE_POLYGON = 0x8605;
        /// <summary>
        /// 设置线路
        /// </summary>
        public const int CMD_ROUTE_CONFIG = 0x8606;
        /// <summary>
        /// 删除线路
        /// </summary>
        public static int CMD_DELETE_ROUTE = 0x8607;
        /// <summary>
        /// 临时位置跟踪控制
        /// </summary>
	    public static int CMD_TEMP_TRACK = 0x8202;
        /// <summary>
        /// 存储多媒体数据检索
        /// </summary>
        public const int CMD_MEDIA_SEARCH = 0x8802;
        /// <summary>
        /// 媒体上传
        /// </summary>
        public const int CMD_MEDIA_UPLOAD = 0x8803;
        /// <summary>
        /// 单条存储多媒体上传命令
        /// </summary>
        public const int CMD_MEDIA_UPLOAD_SINGLE = 0x8805;
        /// <summary>
        /// 位置信息汇报
        /// </summary>
        public const int CMD_LOCATION_MONITOR = 0x0200;
        /// <summary>
        /// 文本信息下发
        /// </summary>
        public const int CMD_SEND_TEXT = 0x8300;
        /// <summary>
        /// 设置终端参数
        /// </summary>
        public const int CMD_CONFIG_PARAM = 0x8103;
        /// <summary>
        /// 查询终端参数
        /// </summary>
        public const int CMD_QUERY_PARAM = 0x8104;
        /// <summary>
        /// 终端控制
        /// </summary>
        public const int CMD_CONTROL_TERMINAL = 0x8105;
        /// <summary>
        /// 拍照（摄像头立即拍摄命令）
        /// </summary>
        public const int CMD_TAKE_PHOTO = 0x8801;
        /// <summary>
        /// 设置事件
        /// </summary>
        public const int CMD_EVENT_SET = 0x8301;
        /// <summary>
        /// 提问下发
        /// </summary>
        public const int CMD_QUESTION = 0x8302;
        /// <summary>
        /// 菜单设置
        /// </summary>
        public const int CMD_SET_MENU = 0x8303;
        /// <summary>
        /// 信息服务
        /// </summary>
        public const int CMD_INFORMATION = 0x8304;
        /// <summary>
        ///电话回拨
        /// </summary>
        public const int CMD_DIAL_BACK = 0x8400;
        /// <summary>
        /// 电话本设置
        /// </summary>
        public const int CMD_PHONE_BOOK = 0x8401;
        /// <summary>
        /// 车辆控制
        /// </summary>
        public const int CMD_CONTROL_VEHICLE = 0x8500;
        /// <summary>
        /// 数据下行透传
        /// </summary>
	    public static int CMD_TRANS = 0x8900;
        /// <summary>
        /// 行车记录仪采集
        /// </summary>
        public const int CMD_VEHICLE_RECORDER = 0x8700;
        /// <summary>
        /// 行车记录参数下传命令
        /// </summary>
        public const int CMD_VEHICLE_RECORDER_CONFIG = 0x8701;
        /// <summary>
        /// 多媒体数据上传应答
        /// </summary>
        public const int CMD_MEDIA_ACK = 0x8800;
        /// <summary>
        /// 平台通用应答
        /// </summary>
        public const int CMD_RES_PLATFORM = 0x8001;
        /// <summary>
        /// 人工确认报警消息
        /// </summary>
	    public static int CMD_MANUALLY_ACK_ALARM = 0x8203;
        /// <summary>
        /// 终端心跳
        /// </summary>
        public static int CMD_TERMINAL_HEARTHBEAT = 0x0002;
        /// <summary>
        /// 补传分包请求
        /// </summary>
        public static int CMD_SUPPLEMENT_SUBCONTRACT_REQ = 0x8003;
        /// <summary>
        /// 终端注册应答
        /// </summary>
        public static int CMD_TERMINAL_REG_RES = 0x8100;
        /// <summary>
        /// 终端注销
        /// </summary>
        public static int CMD_TERMINAL_LOGOUT = 0x0003;
        /// <summary>
        /// 查询指定终端参数
        /// </summary>
        public static int CMD_QUERY_SPE_TERMINAL_PARAM = 0x8106;
        /// <summary>
        /// 查询终端属性
        /// </summary>
        public static int CMD_QUERY_TERMINAL_PROPERTY = 0x8107;
        /// <summary>
        /// 查询终端属性应答
        /// </summary>
        public static int CMD_QUERY_TERMINAL_PROPERTY_RES = 0x0107;
        /// <summary>
        /// 下发终端升级包
        /// </summary>
        public static int CMD_TERMINAL_UPGRADE_PACKAGE = 0x8108;
        /// <summary>
        /// 终端升级结果通知
        /// </summary>
        public static int CMD_TERMINAL_UPGRADE_RES = 0x0108;
        /// <summary>
        /// 位置信息查询应答
        /// </summary>
        public static int CMD_LOCATION_QUERY_RES = 0x0201;
        /// <summary>
        /// 事件报告
        /// </summary>
        public static int CMD_EVENT_REPORT = 0x0301;
        /// <summary>
        /// 行驶记录仪数据上传
        /// </summary>
        public static int CMD_VEHICLE_RECORDER_UPLOAD = 0x0700;
        /// <summary>
        /// 上报驾驶员身份信息请求
        /// </summary>
        public static int CMD_DRIVER_INFO_REQ = 0x8702;
        /// <summary>
        /// CAN 总线数据上传
        /// </summary>
        public static int CMD_CAN_UPLOAD = 0x0705;
        /// <summary>
        ///  确认清除报警
        /// </summary>
        public static int CMD_CLEAR_ALARM = 0x8001;
        /// <summary>
        ///  确认清除报警
        /// </summary>
        public static int CMD_CLEAR_ALARM_2 = 0x8203;
    }
}
