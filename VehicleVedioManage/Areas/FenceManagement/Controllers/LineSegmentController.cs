using System.ComponentModel;
using VehicleVedioManage.FenceManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.FenceManagement.Controllers
{
    [FenceManagementArea]
    [DisplayName("线段")]
    public class LineSegmentController : EntityController<LineSegment>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
