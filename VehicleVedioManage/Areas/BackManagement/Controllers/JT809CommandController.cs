using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{

    [BackManagementArea]
    [DisplayName("809指令")]
    public class JT809CommandController : EntityController<JT809Command>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("CmdId", "Owner", "SN", "UserId", "TenantId", "GpsId", "Deleted");
            return base.Index(p);
        }
    }
}
