using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("报表列")]
    public class ReportColumnController : EntityController<ReportColumn>
    {
        static ReportColumnController()
        {
            LogOnChange = true;
            ListFields.RemoveField("ID", "No");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=报表列&linkId={ID}";
            }
        }
    }
}
