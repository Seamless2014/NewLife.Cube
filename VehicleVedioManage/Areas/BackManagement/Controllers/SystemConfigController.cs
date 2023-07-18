using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("系统配置")]
    public class SystemConfigController : EntityController<SystemConfig>
    {
        static SystemConfigController()
        {
            LogOnChange = true;
            ListFields.RemoveField("ID", "TenantId");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=系统配置&linkId={ID}";
            }
        }
    }
}
