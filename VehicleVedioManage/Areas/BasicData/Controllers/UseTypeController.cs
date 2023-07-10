using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Log;
using NewLife.Web;
using VehicleVedioManage.BasicData.Entity;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("使用性质")]
    public class UseTypeController : EntityController<UseType>
    {

        private readonly ITracer _tracer;
        public UseTypeController(IServiceProvider provider)
        {

            PageSetting.EnableTableDoubleClick = true;
            _tracer = provider?.GetService<ITracer>();
            ListFields.RemoveField("ID", "CreateUserID", "CreateIP", "UpdateUserID", "UpdateIP");
        }

        protected override UseType Find(Object key)
        {
            return base.Find(key);
        }

        protected override IEnumerable<UseType> Search(Pager p)
        {
            return base.Search(p);
        }


        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
