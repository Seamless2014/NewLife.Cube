using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Log;
using NewLife.Web;
using VehicleVedioManage.BasicData.Entity;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("车牌颜色")]
    public class PlateColorController : EntityController<PlateColor>
    {

        private readonly ITracer _tracer;
        public PlateColorController(IServiceProvider provider)
        {

            PageSetting.EnableTableDoubleClick = true;
            _tracer = provider?.GetService<ITracer>();
            ListFields.RemoveField("ID", "CreateUserID", "UpdateUserID", "CreateIP", "UpdateIP");
        }

        protected override PlateColor Find(Object key)
        {
            return base.Find(key);
        }

        protected override IEnumerable<PlateColor> Search(Pager p)
        {
            return base.Search(p);
        }


        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}

