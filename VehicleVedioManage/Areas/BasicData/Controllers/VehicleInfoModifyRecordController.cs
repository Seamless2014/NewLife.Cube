using System.ComponentModel;
using VehicleVedioManage.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("改车记录")]
    public class VehicleInfoModifyRecordController : EntityController<VehicleInfoModifyRecord>
    {
        static VehicleInfoModifyRecordController()
        {
            LogOnChange = true;
            ListFields.RemoveField("ID", "Deleted", "Owner", "TenantId", "UpdateUserID", "CreateUserID", "CreateIP");
        }

        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
