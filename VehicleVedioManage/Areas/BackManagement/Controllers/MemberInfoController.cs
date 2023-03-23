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
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("Id", "Owner", "TenantId", "Deleted");
            return base.Index(p);
        }
    }
}

