using System.ComponentModel;
using VehicleVedioManage.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("用户实时数据")]
    public class UserGpsRealDataController : EntityController<UserGpsRealData>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
