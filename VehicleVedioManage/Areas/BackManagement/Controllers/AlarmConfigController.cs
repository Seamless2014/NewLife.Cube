using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("报警设置")]
    public class AlarmConfigController : EntityController<AlarmConfig>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("id");
            return base.Index(p);
        }
    }
}
