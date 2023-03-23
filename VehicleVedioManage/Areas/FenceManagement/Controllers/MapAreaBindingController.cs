using System.ComponentModel;
using VehicleVedioManage.FenceManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.FenceManagement.Controllers
{
    [FenceManagementArea]
    [DisplayName("区域绑定")]
    public class MapAreaBindingController : EntityController<MapAreaBinding>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("BindId","TenantId", "Deleted", "Owner");
            return base.Index(p);
        }
    }
}
