using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("实时数据")]
    public class GPSRealDataController : EntityController<GPSRealData>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("ID", "TenantId", "Deleted", "Owner", "VehicleId", "EnclosureId", "OverSpeedAreaId", "RouteSegmentId", "AreaId", "PlatformId");
            return base.Index(p);
        }
    }
}
