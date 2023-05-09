using System.ComponentModel;
using VehicleVedioManage.FenceManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.FenceManagement.Controllers
{
    [FenceManagementArea]
    [DisplayName("线段管理")]
    public class LineSegmentController : EntityController<LineSegment>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("SegId","Deleted", "Owner", "TenantId");
            return base.Index(p);
        }
    }
}
