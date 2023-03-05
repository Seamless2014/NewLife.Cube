using System.ComponentModel;
using GPSPlatform.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("车辆注册信息")]
    public class VehicleRegisterInfoController : EntityController<VehicleRegisterInfo>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
