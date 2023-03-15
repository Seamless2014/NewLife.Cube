using GPSPlatform.Areas.BasicData;
using System.ComponentModel;
using GPSPlatform.BackManagement.Entity;
using GPSPlatform.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("司机信息")]
    public class DriverInfoController : EntityController<DriverInfo>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
