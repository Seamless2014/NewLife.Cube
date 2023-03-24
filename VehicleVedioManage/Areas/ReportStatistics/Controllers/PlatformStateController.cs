using System.ComponentModel;
using VehicleVedioManage.BasicData.Entity;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("平台状态")]
    public class PlatformStateController : EntityController<PlatformState>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("StateId","Deleted", "Owner", "TenantId");
            return base.Index(p);
        }
    }
}
