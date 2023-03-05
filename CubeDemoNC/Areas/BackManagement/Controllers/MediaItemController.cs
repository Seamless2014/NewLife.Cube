using System.ComponentModel;
using GPSPlatform.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("多媒体")]
    public class MediaItemController : EntityController<MediaItem>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
