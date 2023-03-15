using System.ComponentModel;
using GPSPlatform.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("用户角色")]
    public class UserRoleController : EntityController<UserRole>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
