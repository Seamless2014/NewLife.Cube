using System.ComponentModel;
using VehicleVedioManage.FenceManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.FenceManagement.Controllers
{
    [FenceManagementArea]
    [DisplayName("围栏绑定")]
    public class ElectronicFenceBindingController : EntityController<ElectronicFenceBinding>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("BindId", "VehicleId", "TenantId", "Deleted", "Owner");
            return base.Index(p);
        }
    }
}
