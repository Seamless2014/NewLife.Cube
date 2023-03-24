using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("历史报警")]
    public class HisAlarmRecordController : EntityController<HisAlarmRecord>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("AlarmId", "TenantId", "Deleted", "Owner", "VehicleId");
            return base.Index(p);
        }
    }
}

