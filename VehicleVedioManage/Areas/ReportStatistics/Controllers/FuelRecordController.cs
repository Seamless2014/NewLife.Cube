using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("燃料记录")]
    public class FuelRecordController : EntityController<FuelRecord>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("ID", "TenantId", "Deleted", "Owner");
            return base.Index(p);
        }
    }
}
