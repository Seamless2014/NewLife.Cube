using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("系统配置")]
    public class SystemConfigController : EntityController<SystemConfig>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
