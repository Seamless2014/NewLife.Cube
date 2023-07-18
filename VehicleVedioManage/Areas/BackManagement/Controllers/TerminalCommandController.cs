using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("终端指令")]
    public class TerminalCommandController : EntityController<TerminalCommand>
    {
        static TerminalCommandController()
        {
            LogOnChange = true;
            ListFields.RemoveField("ID", "Owner", "UserId", "TenantId", "VehicleId");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=终端指令&linkId={ID}";
            }
        }
    }
}
