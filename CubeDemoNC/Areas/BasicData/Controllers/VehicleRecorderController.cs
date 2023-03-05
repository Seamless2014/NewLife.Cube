using GPSPlatform.Areas.ReportStatistics;
using System.ComponentModel;
using GPSPlatform.BasicData.Entity;
using GPSPlatform.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("车辆记录")]
    public class VehicleRecorderController : EntityController<VehicleRecorder>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
