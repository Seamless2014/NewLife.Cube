using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("里程统计")]
    public class MileageStatisticController : EntityController<MileageStatistic>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("FunctionId", "TenantId", "Deleted", "Owner");
            return base.Index(p);
        }
    }
}
