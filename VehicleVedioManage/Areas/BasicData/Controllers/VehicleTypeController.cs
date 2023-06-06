using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;
using NewLife.Log;
using VehicleVedioManage.BasicData.Entity;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("车辆类型")]
    public class VehicleTypeController : EntityController<VehicleType>
    {

        private readonly ITracer _tracer;
        public VehicleTypeController(IServiceProvider provider)
        {
            PageSetting.EnableTableDoubleClick = true;
            _tracer = provider?.GetService<ITracer>();
            ListFields.RemoveField("ID","CreateUserID","UpdateUserID", "UpdateIP", "CreateIP");
        }

        protected override VehicleType Find(Object key)
        {
            return base.Find(key);
        }

        protected override IEnumerable<VehicleType> Search(Pager p)
        {
            return base.Search(p);
        }


        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
