using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("报警记录")]
    public class AlarmRecordController : EntityController<AlarmRecord>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("AlarmId", "Latitude1", "Longitude1", "Location1", "ValveState1", "Deleted", "TenantId", "Owner", "VehicleId");
            return base.Index(p);
        }
    }
}
