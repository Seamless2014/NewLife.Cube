using System.ComponentModel;
using VehicleVedioManage.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("车辆信息修改记录")]
    public class VehicleInfoModifyRecordController : EntityController<VehicleInfoModifyRecord>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("ID", "Deleted", "Owner", "TenantId", "UpdateUserID", "CreateUserID", "CreateIP");
            return base.Index(p);
        }
    }
}
