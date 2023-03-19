using System.ComponentModel;
using VehicleVedioManage.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("运营状态")]
    public class RunStatusController : EntityController<RunStatus>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}