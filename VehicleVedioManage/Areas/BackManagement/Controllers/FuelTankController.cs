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
        static FuelTankController()
        {
            LogOnChange = true;
            ListFields.RemoveField("ID", "VehicleId");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=油箱&linkId={ID}";
            }
        }
    }
}
