using System.ComponentModel;
using VehicleVedioManage.FenceManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.FenceManagement.Controllers
{
    [FenceManagementArea]
    [DisplayName("电子围栏")]
    public class ElectronicFenceController : EntityController<ElectronicFence>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("EnclosureId", "TenantId", "Deleted", "Owner");
            return base.Index(p);
        }
    }
}
