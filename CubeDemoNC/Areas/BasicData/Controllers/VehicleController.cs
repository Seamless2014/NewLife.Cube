using CubeDemo.Areas.School;
using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using NewLife.School.Entity;
using XCode.Membership;
using NewLife.Cube;
using NewLife.BasicData.Entity;
using NewLife.Web;

namespace CubeDemo.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("车辆")]
    public class VehicleController : EntityController<Vehicle>
    {
        static VehicleController()
        {
            //ListFields.RemoveField("CreateUserID");
            //ListFields.RemoveField("UpdateUserID");
            //FormFields
        }

        protected override Vehicle Find(Object key)
        {
            return base.Find(key);
        }

        protected override IEnumerable<Vehicle> Search(Pager p)
        {
            return base.Search(p);
            var classid = p["vehicleId"].ToInt();
            return Vehicle.Search(null, p);
        }

        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
