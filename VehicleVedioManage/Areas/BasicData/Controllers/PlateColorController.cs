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

        
        static PlateColorController()
        {
            LogOnChange = true;

            ListFields.RemoveField("ID", "CreateUserID", "UpdateUserID", "CreateIP", "UpdateIP");
            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=车牌颜色&linkId={ID}";
            }
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

