using System.ComponentModel;
using VehicleVedioManage.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("行业类型")]
    public class IndustryTypeController : EntityController<IndustryType>
    {

        static IndustryTypeController()
        {
            LogOnChange = true;

            ListFields.RemoveField("ID", "CreateUserID", "UpdateUserID", "CreateIP", "UpdateIP","Code");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=行业类型&linkId={ID}";
            }
        }
    }
}