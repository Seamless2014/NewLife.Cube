using VehicleVedioManage.BackManagement.Entity;

namespace VehicleVedioManage.Web.IService
{
    /// <summary>
    /// 终端服务
    /// </summary>
    public interface  ITerminalService
    {
        /// <summary>
        /// 发送指令
        /// </summary>
        /// <param name="tc"></param>
        void SendCommand(TerminalCommand tc);
        /// <summary>
        /// 发送平台指令
        /// </summary>
        /// <param name="tc"></param>
        void SendPlatformCommand(JT809Command tc);
    }
}
