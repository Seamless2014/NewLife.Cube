using CubeDemo.Areas.School;
using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using NewLife.School.Entity;
using XCode.Membership;
using NewLife.Cube;
using NewLife.BasicData.Entity;
using NewLife.Web;
using NewLife.Log;
using System;
using XCode;
using NewLife.Cube.Extensions;
using NewLife;

namespace CubeDemo.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("车辆")]
    public class VehicleController : EntityController<Vehicle>
    {
        private readonly ITracer _tracer;
        public VehicleController(IServiceProvider provider)
        {

            PageSetting.EnableTableDoubleClick = true;

            _tracer = provider?.GetService<ITracer>();
            ListFields.RemoveField("Deleted");
            ListFields.RemoveField("DepartmentID");
            //ListFields.RemoveField("UpdateUserID");
            //FormFields
        }

        protected override Vehicle Find(Object key)
        {
            return base.Find(key);
        }

        protected override IEnumerable<Vehicle> Search(Pager p)
        {
            using var span = _tracer?.NewSpan(nameof(Search), p);

            var id = p["Deleted"].ToBoolean();
            if (!id)
            {
                var entity = Vehicle.FindByDeleted(id);
                return entity.Count == 0 ? new List<Vehicle>() : entity;
            }
            return Vehicle.Search(p["Deleted"], p);
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
