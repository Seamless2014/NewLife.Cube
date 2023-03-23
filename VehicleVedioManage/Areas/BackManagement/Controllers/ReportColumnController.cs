using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("报表列")]
    public class ReportColumnController : EntityController<ReportColumn>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("ReportColumnId", "No", "Deleted");
            return base.Index(p);
        }
    }
}
