using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("报警信息")]
    public class WarnMsgInformController : EntityController<WarnMsgInform>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("ID");
            return base.Index(p);
        }
    }
}
