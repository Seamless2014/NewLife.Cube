using VehicleVedioManage.BackManagement.Entity;
using VehicleVedioManage.Web.IService;
using XCode;

namespace VehicleVedioManage.Web.Service
{
    /// <summary>
    /// 终端服务
    /// </summary>
    public class TerminalService : ITerminalService
    {
        /// <summary>
        /// 发送指令
        /// </summary>
        /// <param name="tc"></param>
        public void SendCommand(TerminalCommand tc)
        {
            tc.Upsert();
        }

        /// <summary>
        /// 发送平台指令
        /// </summary>
        /// <param name="tc"></param>
        public void SendPlatformCommand(JT809Command tc)
        {
            tc.Insert();
        }
    }
}
