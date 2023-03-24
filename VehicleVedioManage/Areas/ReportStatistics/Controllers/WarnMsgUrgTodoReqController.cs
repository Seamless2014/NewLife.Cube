using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("报警响应")]
    public class WarnMsgUrgTodoReqController : EntityController<WarnMsgUrgTodoReq>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("ID", "Deleted", "Owner", "TenantId", "VehicleId");
            return base.Index(p);
        }
    }
}
