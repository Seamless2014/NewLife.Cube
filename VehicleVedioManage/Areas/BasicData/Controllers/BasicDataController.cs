using System.ComponentModel;
using VehicleVedioManage.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;
using NewLife;
using XCode.Membership;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("基础信息")]
    public class BasicInfoController : EntityController<BasicInfo>
    {
        static BasicInfoController()
        {
            LogOnChange = true;
            ListFields.RemoveField("BaseId", "Deleted", "Owner", "TenantId");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=基础信息&linkId={ID}";
            }
        }

        /// <summary>批量删除</summary>
        /// <returns></returns>
        [EntityAuthorize(PermissionFlags.Update)]
        public ActionResult RefreshStock()
        {
            var count = 0;
            var ids = GetRequest("keys").SplitAsInt();
            if (ids.Length > 0)
            {
                foreach (var id in ids)
                {
                    var entity = BasicInfo.FindByKey(id);
                    if (entity != null)
                    {
                        entity.Enable = true;
                        count += entity.Update();
                    }
                }
            }

            return JsonRefresh($"共删除[{count}]个");
        }
    }
}