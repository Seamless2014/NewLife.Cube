using System.ComponentModel;
using VehicleVedioManage.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("基础信息")]
    public class BasicInfoController : EntityController<BasicInfo>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("BaseId", "Deleted", "Owner", "TenantId");
            return base.Index(p);
        }
    }
}