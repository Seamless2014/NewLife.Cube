using System.ComponentModel;
using VehicleVedioManage.BasicData.Entity;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("租户")]
    public class TenantUserController : EntityController<TenantUser>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}