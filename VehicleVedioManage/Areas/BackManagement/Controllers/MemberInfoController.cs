using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("会员信息")]
    public class MemberInfoController : EntityController<MemberInfo>
    {
        static MemberInfoController()
        {
            LogOnChange = true;
            ListFields.RemoveField("ID", "Owner", "TenantId");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=会员信息&linkId={ID}";
            }
        }
    }
}

