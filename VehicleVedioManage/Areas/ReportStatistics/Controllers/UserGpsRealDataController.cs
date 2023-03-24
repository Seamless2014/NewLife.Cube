using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("实时用户")]
    public class UserGpsRealDataController : EntityController<UserGpsRealData>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("ID", "UserId");
            return base.Index(p);
        }
    }
}
