using GPSPlatform.Areas.FenceManagement;
using System.ComponentModel;
using GPSPlatform.FenceManagement.Entity;
using GPSPlatform.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("GPS里程")]
    public class GpsMileageController : EntityController<GpsMileage>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
