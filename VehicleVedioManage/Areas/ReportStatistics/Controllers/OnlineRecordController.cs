using System.ComponentModel;
using VehicleVedioManage.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("上线记录")]
    public class OnlineRecordController : EntityController<OnlineRecord>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("AlarmId", "TenantId", "Deleted", "Owner", "VehicleId");
            return base.Index(p);
        }
    }
}

