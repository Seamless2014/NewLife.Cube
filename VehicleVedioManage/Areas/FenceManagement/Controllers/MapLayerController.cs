using System.ComponentModel;
using VehicleVedioManage.FenceManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.FenceManagement.Controllers
{
    [FenceManagementArea]
    [DisplayName("图层")]
    public class MapLayerController : EntityController<MapLayer>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("LayerId", "TenantId", "Deleted");
            return base.Index(p);
        }
    }
}
