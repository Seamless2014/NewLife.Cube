using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Log;
using NewLife.Web;
using VehicleVedioManage.BasicData.Entity;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("车辆类型")]
    public class UseTypeController : EntityController<UseType>
    {

        private readonly ITracer _tracer;
        public UseTypeController(IServiceProvider provider)
        {

            PageSetting.EnableTableDoubleClick = true;
            _tracer = provider?.GetService<ITracer>();
            ListFields.RemoveField("ID");
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
        protected override Int32 OnInsert(UseType entity)
        {
            var rs = -1;
            if (!UseType.isExistCode(entity.Code.Trim()))
            {
                rs = base.OnInsert(entity);
            }
            else
            {
                throw new InvalidOperationException("编码已经存在！请重新输入");
            }
            return rs;
        }

        protected override Int32 OnUpdate(UseType entity)
        {
            var rs = -1;
            if (!UseType.isExistCode(entity.Code.Trim()))
            {
                rs = base.OnUpdate(entity);
            }
            else
            {
                throw new InvalidOperationException("编码已经存在！请重新输入");
            }
            return rs;
        }
    }
}
