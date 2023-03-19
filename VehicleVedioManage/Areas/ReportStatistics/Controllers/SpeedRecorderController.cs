using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("速度记录")]
    public class SpeedRecorderController : EntityController<SpeedRecorder>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}

