using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("终端报警")]
    public class TerminalAlarmController : EntityController<TerminalAlarm>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}

