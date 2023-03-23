using System.ComponentModel;
using VehicleVedioManage.FenceManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.FenceManagement.Controllers
{
    [FenceManagementArea]
    [DisplayName("定制标记")]
    public class CustomMarkerController : EntityController<CustomMarker>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("MarkerId", "Owner", "TenantId", "Deleted");
            return base.Index(p);
        }
    }
}
