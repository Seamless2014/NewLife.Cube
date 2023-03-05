using System.ComponentModel;
using GPSPlatform.FenceManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.FenceManagement.Controllers
{
    [FenceManagementArea]
    [DisplayName("图层")]
    public class MapLayerController : EntityController<MapLayer>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
