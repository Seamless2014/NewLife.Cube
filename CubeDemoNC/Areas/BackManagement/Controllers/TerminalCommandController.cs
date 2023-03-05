using System.ComponentModel;
using GPSPlatform.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("终端指令")]
    public class TerminalCommandController : EntityController<TerminalCommand>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
