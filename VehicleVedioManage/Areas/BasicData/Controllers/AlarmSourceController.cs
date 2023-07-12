using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;
using VehicleVedioManage.Areas.BasicData;
using VehicleVedioManage.BasicData.Entity;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("报警源")]
    public class AlarmSourceController : EntityController<AlarmSource>
    {
        static AlarmSourceController()
        {
            LogOnChange = true;

            ListFields.RemoveField("ID");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=报警源&linkId={ID}";
            }
        }
    }
}
