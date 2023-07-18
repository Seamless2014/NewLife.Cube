using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("报表模型")]
    public class ReportModelController : EntityController<ReportModel>
    {
        static ReportModelController()
        {
            LogOnChange = true;
            ListFields.RemoveField("ID");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=报表模型&linkId={ID}";
            }
        }
    }
}
