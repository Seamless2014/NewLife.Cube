using System.ComponentModel;
using VehicleVedioManage.FenceManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.FenceManagement.Controllers
{
    [FenceManagementArea]
    [DisplayName("路段管理")]
    public class RouteSegmentController : EntityController<RouteSegment>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("SegId", "Deleted", "Owner");
            return base.Index(p);
        }
    }
}
