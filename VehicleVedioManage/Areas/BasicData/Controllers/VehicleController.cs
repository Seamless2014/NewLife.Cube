using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;
using NewLife.Log;
using NewLife.Cube.Extensions;
using NewLife;
using VehicleVedioManage.BasicData.Entity;
using NewLife.Data;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("车辆信息")]
    public class VehicleController : EntityController<Vehicle>
    {
        private readonly ITracer _tracer;
        public VehicleController(IServiceProvider provider)
        {

            PageSetting.EnableTableDoubleClick = true;
            _tracer = provider?.GetService<ITracer>();
            ListFields.RemoveField("ID", "Deleted", "DepartmentID","CreateUserID","UpdateUserID", "TenantID");
        }

        protected override Vehicle Find(Object key)
        {
            return base.Find(key);
        }

        protected override IEnumerable<Vehicle> Search(Pager p)
        {
            using var span = _tracer?.NewSpan(nameof(Search), p);
            //var id = p["Deleted"].ToBoolean();
            //p["PlateColor"],p["RunStatus"],p["VehicleType"]
            //if (!id)
            //{
            //    var entity = Vehicle.FindByDeleted(id);
            //    return entity.Count == 0 ? new List<Vehicle>() : entity;
            //}
            return Vehicle.Search(null, p["PlateColor"], p["RunStatus"], p["VehicleType"],"", p);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public ActionResult Search(Int32 departmentId, String key = null)
        {
            var cids = departmentId > 0 ? new[] { departmentId } : Array.Empty<Int32>();

            var page = new PageParameter { PageSize = 20 };
            var list = Vehicle.Search(cids,false, DateTime.MinValue, DateTime.MinValue, key, page);
            return Json(0, null, list.Select(e => new
            {
                e.ID,
                e.PlateNo,
                e.PlateColorName,
                e.DepartmentName,
            }).ToArray());
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

        protected override Int32 OnUpdate(Vehicle entity)
        {
            var rs = -1;
            rs = base.OnUpdate(entity);
            return rs;
        }
    }
}
