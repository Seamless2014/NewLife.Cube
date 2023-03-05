using System.ComponentModel;
using GPSPlatform.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.BasicData.Entity;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("车辆信息修改记录")]
    public class VehicleInfoModifyRecordController : EntityController<VehicleInfoModifyRecord>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
