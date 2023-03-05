using System.ComponentModel;
using GPSPlatform.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.BasicData.Entity;
using NewLife;
using NewLife.Cube;
using NewLife.Cube.Extensions;
using NewLife.Log;
using NewLife.Web;
using GPSPlatform.BackManagement.Entity;

namespace GPSPlatform.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("终端信息")]
    public class TerminalController : EntityController<Terminal>
    {
        private readonly ITracer _tracer;
        public TerminalController(IServiceProvider provider)
        {

            PageSetting.EnableTableDoubleClick = true;
            _tracer = provider?.GetService<ITracer>();
        }

        protected override Terminal Find(Object key)
        {
            return base.Find(key);
        }

        protected override IEnumerable<Terminal> Search(Pager p)
        {
            using var span = _tracer?.NewSpan(nameof(Search), p);
            var id = p["Deleted"].ToBoolean();
            if (!id)
            {
                var entity = Terminal.FindByDeleted(id);
                return entity.Count == 0 ? new List<Terminal>() : entity;
            }
            return Terminal.Search(p["Deleted"], p);
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
                    entity.Deleted = true;
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

