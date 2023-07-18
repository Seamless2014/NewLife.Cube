using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;
using VehicleVedioManage.BackManagement.Entity;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("平台信息")]
    public class PlatformInfoController : EntityController<PlatformInfo>
    {
        static PlatformInfoController()
        {
            LogOnChange = true;
            ListFields.RemoveField("ID", "TenantId", "Password", "CheckQuestion");
            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=平台信息&linkId={ID}";
            }
        }
    }
}
