using VehicleVedioManage.Areas.BackManagement;
using System.ComponentModel;
using VehicleVedioManage.FenceManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.FenceManagement.Controllers
{
    [FenceManagementArea]
    [DisplayName("地图区域")]
    public class MapAreaController : EntityController<MapArea>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("AreaId", "TenantId", "Deleted", "GPSId", "Owner");
            return base.Index(p);
        }
    }
}
