using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{

    [BackManagementArea]
    [DisplayName("809指令")]
    public class JT809CommandController : EntityController<JT809Command>
    {
        static JT809CommandController()
        {
            LogOnChange = true;
            ListFields.RemoveField("ID", "Owner", "SN", "UserId", "TenantId", "GpsId");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=809指令&linkId={ID}";
            }
        }
    }
}
