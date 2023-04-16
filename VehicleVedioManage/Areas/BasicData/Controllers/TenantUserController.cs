using System.ComponentModel;
using VehicleVedioManage.BasicData.Entity;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("租户用户")]
    public class TenantUserController : EntityController<TenantUser>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("UserId", "TenantId", "Deleted");
            return base.Index(p);
        }
    }
}