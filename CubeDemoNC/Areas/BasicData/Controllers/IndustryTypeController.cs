using System.ComponentModel;
using GPSPlatform.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("行业类型")]
    public class IndustryTypeController : EntityController<IndustryType>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}