using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("报表模型")]
    public class ReportModelController : EntityController<ReportModel>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("ReportId", "QueryId", "Code", "Deleted");
            return base.Index(p);
        }
    }
}
