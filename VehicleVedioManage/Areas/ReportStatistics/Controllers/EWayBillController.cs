using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("电子运单")]
    public class EWayBillController : EntityController<EWayBill>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("BillId", "VehicleId", "TenantId", "Deleted");
            return base.Index(p);
        }
    }
}
