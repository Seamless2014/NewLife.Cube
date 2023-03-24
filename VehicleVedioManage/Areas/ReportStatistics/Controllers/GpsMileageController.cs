using VehicleVedioManage.Areas.FenceManagement;
using System.ComponentModel;
using VehicleVedioManage.FenceManagement.Entity;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("GPS里程")]
    public class GpsMileageController : EntityController<GpsMileage>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("Id", "TenantId", "Deleted", "Owner");
            return base.Index(p);
        }
    }
}
