using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;
using NewLife;
using XCode.Membership;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("报警设置")]
    public class AlarmConfigController : EntityController<AlarmConfig>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("id");
            return base.Index(p);
        }

        ///// <summary>批量启用</summary>
        ///// <param name="keys"></param>
        ///// <returns></returns>
        //[EntityAuthorize(PermissionFlags.Update)]
        //public ActionResult EnableSelect(String keys) => EnableOrDisableSelect();

        ///// <summary>批量禁用</summary>
        ///// <param name="keys"></param>
        ///// <returns></returns>
        //[EntityAuthorize(PermissionFlags.Update)]
        //public ActionResult DisableSelect(String keys) => EnableOrDisableSelect(false);

        //private ActionResult EnableOrDisableSelect(Boolean isEnable = true)
        //{
        //    var count = 0;
        //    var ids = GetRequest("keys").SplitAsInt();
        //    if (ids.Length > 0)
        //    {
        //        foreach (var id in ids)
        //        {
        //            var config = AlarmConfig.FindByID(id);
        //            if (config != null && config.Enabled != isEnable)
        //            {
        //                config.Enabled = isEnable;
        //                config.Update();
        //                Interlocked.Increment(ref count);
        //            }
        //        }
        //    }

        //    return JsonRefresh($"共{(isEnable ? "启用" : "禁用")}[{count}]个报警设置");
        //}
    }
}
