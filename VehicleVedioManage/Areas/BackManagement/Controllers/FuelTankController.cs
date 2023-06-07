using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("油箱")]
    public class FuelTankController : EntityController<FuelTank>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("TankId", "Deleted", "VehicleId");
            return base.Index(p);
        }
    }
}
