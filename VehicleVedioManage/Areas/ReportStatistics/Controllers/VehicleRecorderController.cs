using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;
using VehicleVedioManage.Areas.ReportStatistics;
using VehicleVedioManage.Data.Entity;

namespace VehicleVedioManage.Web.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("行车记录仪")]
    public class VehicleRecorderController : EntityController<VehicleRecord>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("RecorderID", "Deleted", "TenantID", "Owner", "VehicleId");
            return base.Index(p);
        }
    }
}
