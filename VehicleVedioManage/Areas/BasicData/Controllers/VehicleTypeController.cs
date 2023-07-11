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

       
        static VehicleTypeController()
        {
            LogOnChange = true;

            ListFields.RemoveField("ID","CreateUserID","UpdateUserID", "UpdateIP", "CreateIP");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=车辆类型&linkId={ID}";
            }
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
