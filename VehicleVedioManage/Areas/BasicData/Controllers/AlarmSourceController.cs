using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;
using VehicleVedioManage.Areas.BasicData;
using VehicleVedioManage.BasicData.Entity;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("报警源")]
    public class AlarmSourceController : EntityController<AlarmSource>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("ID");
            return base.Index(p);
        }
    }
}
