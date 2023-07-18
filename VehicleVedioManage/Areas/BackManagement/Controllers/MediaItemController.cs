using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("多媒体")]
    public class MediaItemController : EntityController<MediaItem>
    {
        static MediaItemController()
        {
            LogOnChange=true;
            ListFields.RemoveField("ID", "TenantId", "Owner", "GPSId");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=多媒体&linkId={ID}";
            }
        }
    }
}
