using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("燃料消耗")]
    public class FuelConsumptionController : EntityController<FuelConsumption>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("ID", "Deleted", "TenantId", "Owner");
            return base.Index(p);
        }
    }
}

