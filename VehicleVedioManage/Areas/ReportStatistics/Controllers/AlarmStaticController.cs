using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("报警统计")]
    public class AlarmStaticController : EntityController<AlarmStatic>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("StatisticsId");
            return base.Index(p);
        }
    }
}
