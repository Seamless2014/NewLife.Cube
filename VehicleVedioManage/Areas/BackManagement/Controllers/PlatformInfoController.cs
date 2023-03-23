using System.ComponentModel;
using VehicleVedioManage.BackManagementArea.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("平台信息")]
    public class PlatformInfoController : EntityController<PlatformInfo>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("ID", "TenantId", "Password", "CheckQuestion", "Deleted");
            return base.Index(p);
        }
    }
}
