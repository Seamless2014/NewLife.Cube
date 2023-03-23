using VehicleVedioManage.BasicData.Entity;

namespace VehicleVedioManage.Web.Models
{
    /// <summary>
    /// 功能模型
    /// </summary>
    [Serializable]
    public class FuncModel : TenantEntity
    {
        public static int LEVEL_GROUT = 1;

        public static int LEVEL_ITEM = 2;
        /// <summary>
        /// 非功能菜单，用于对功能进行分类，不用于权限判断
        /// </summary>
        public static int FUNC_TYPE_NONE = 0;
        /// <summary>
        /// 主功能菜单
        /// </summary>
        public static int FUNC_TYPE_MAIN_MENU = 1;
        /// <summary>
        /// 右键功能菜单
        /// </summary>
        public static int FUNC_TYPE_RIGHT_MENU = 2;
        /// <summary>
        /// 地图图形工具
        /// </summary>
        public static int FUNC_TYPE_MAP_TOOL = 3;
        /// <summary>
        /// 手机
        /// </summary>
        public static int FUNC_TYPE_MOBILE = 4;
        /// <summary>
        /// 指令工具
        /// </summary>
        public static int FUNC_TYPE_COMMAND_TOOL = 5;

        public static int FUNC_TYPE_MAIN_SHORT_CURT = 6;
        /// <summary>
        /// web  功能
        /// </summary>
        public static int FUNC_TYPE_WEB_FUNC = 7;

        /// <summary>
        /// 功能分组id
        /// </summary>
        public static int CARCONTROL_FUNC_GROUPID = 900000;
        /// <summary>
        /// 连接标识
        /// </summary>
        public static int REPORT_FLAG_LINK = 0;
        /// <summary>
        /// 自我标识
        /// </summary>
        public static int REPORT_FLAG_SELF = 1;
        /// <summary>
        /// 临时标识
        /// </summary>
        public static int REPORT_FLAG_TEMPLATE = 2;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Descr { get; set; }
        /// <summary>
        /// 功能类型
        /// </summary>
        public int FuncType { get; set; }
        /// <summary>
        /// 父节点id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 菜单顺序
        /// </summary>
        public int MenuSort { get; set; }
    }
}
