using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("检查记录")]
    public class CheckRecordController : EntityController<CheckRecord>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}

