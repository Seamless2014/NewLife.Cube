using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Log;
using NewLife.Web;
using VehicleVedioManage.BasicData.Entity;
using VehicleVedioManage.Web.Service;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("使用性质")]
    public class UseTypeController : EntityController<UseType>
    {
        public readonly UseTypeService useTypeService;
        static UseTypeController()
        {
            LogOnChange = true;

            ListFields.RemoveField("ID", "CreateUserID", "CreateIP", "UpdateUserID", "UpdateIP");
            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=使用性质&linkId={ID}";
            }
        }

        public UseTypeController()
        {

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
