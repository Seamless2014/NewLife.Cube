using System.ComponentModel;
using VehicleVedioManage.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife;
using NewLife.Cube;
using NewLife.Cube.Extensions;
using NewLife.Log;
using NewLife.Web;
using VehicleVedioManage.BackManagement.Entity;
using VehicleVedioManage.Areas.BackManagement;

namespace VehicleVedioManage.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("终端信息")]
    public class TerminalInfoController : EntityController<TerminalInfo>
    {
        static TerminalInfoController()
        {
            LogOnChange = true;

            ListFields.RemoveField("ID", "Reserve", "TenantId", "Owner", "CertPassword", "Deleted");
            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=终端信息&linkId={ID}";
            }
        }

        protected override TerminalInfo Find(Object key)
        {
            return base.Find(key);
        }

        protected override IEnumerable<TerminalInfo> Search(Pager p)
        {
            var key = p["q"];
            return TerminalInfo.Search(key, p);
        }

        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }

        public override ActionResult Delete(String id)
        {

            var url = Request.GetReferer();

            var entity = FindData(id);
            var rs = false;
            var err = "";
            try
            {
                if (Valid(entity, DataObjectMethodType.Delete, true))
                {
                    entity.Enable = true;
                    OnUpdate(entity);
                    rs = true;
                }
                else
                    err = "验证失败";
            }
            catch (Exception ex)
            {
                err = ex.GetTrue().Message;
                WriteLog("Delete", false, err);
                if (Request.IsAjaxRequest())
                    return JsonRefresh("删除失败！" + err);

                throw;
            }

            if (Request.IsAjaxRequest())
                return JsonRefresh(rs ? "删除成功！" : "删除失败！" + err);
            else if (!url.IsNullOrEmpty())
                return Redirect(url);
            else
                return RedirectToAction("Index");
        }
    }
}

