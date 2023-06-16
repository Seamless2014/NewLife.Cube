using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("在线率")]
    public class VehicleOnlineRateController : EntityController<VehicleOnlineRate>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("ID", "Owner", "TenantId");
            return base.Index(p);
        }
    }
}
