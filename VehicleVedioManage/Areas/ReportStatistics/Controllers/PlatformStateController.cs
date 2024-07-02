using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;
using VehicleVedioManage.Data.Entity;

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
