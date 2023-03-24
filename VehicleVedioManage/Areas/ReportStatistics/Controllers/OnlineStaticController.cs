using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("上线统计")]
    public class OnlineStaticController : EntityController<OnlineStatic>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("Id", "DepId", "Deleted", "Owner", "TenantId");
            return base.Index(p);
        }
    }
}

