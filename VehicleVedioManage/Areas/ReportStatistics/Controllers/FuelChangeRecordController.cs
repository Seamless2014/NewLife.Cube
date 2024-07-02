using System.ComponentModel;
using VehicleVedioManage.Data.Entity;
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
            ListFields.RemoveField("ID", "Deleted", "Owner", "TenantId", "EnclosureId");
            return base.Index(p);
        }
    }
}
