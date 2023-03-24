using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("驾驶记录")]
    public class DriverRecordController : EntityController<DriverRecord>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("DriverId", "VehicleId", "Deleted");
            return base.Index(p);
        }
    }
}
