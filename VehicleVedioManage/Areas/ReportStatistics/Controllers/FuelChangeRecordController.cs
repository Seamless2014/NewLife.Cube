using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("燃料变化")]
    public class FuelChangeRecordController : EntityController<FuelChangeRecord>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
