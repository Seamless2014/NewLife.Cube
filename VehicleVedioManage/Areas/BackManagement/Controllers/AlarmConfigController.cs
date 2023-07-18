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
        static AlarmConfigController()
        {
            LogOnChange=true;
            ListFields.RemoveField("ID");


            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=报警设置&linkId={ID}";
            }
        }

        /// <summary>批量启用</summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        [EntityAuthorize(PermissionFlags.Update)]
        public override ActionResult EnableSelect(String keys, String reason) => EnableOrDisableSelect(true, reason);

        /// <summary>批量禁用</summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        [EntityAuthorize(PermissionFlags.Update)]
        public override ActionResult DisableSelect(String keys, String reason) => EnableOrDisableSelect(false, reason);

        /// <summary>
        /// 批量启用或禁用
        /// </summary>
        /// <param name="isEnable">启用/禁用</param>
        /// <param name="reason">操作原因</param>
        /// <returns></returns>
        protected override ActionResult EnableOrDisableSelect(Boolean isEnable, String reason)
        {
            var count = 0;
            var ids = GetRequest("keys").SplitAsInt();
            if (ids.Length > 0)
            {
                foreach (var id in ids)
                {
                    var config = AlarmConfig.FindByID(id);
                    if (config != null && config.Enable != isEnable)
                    {
                        config.Enable = isEnable;
                        config.Update();
                        Interlocked.Increment(ref count);
                    }
                }
            }
            return JsonRefresh($"共{(isEnable ? "启用" : "禁用")}[{count}]个报警设置");
        }
    }
}
