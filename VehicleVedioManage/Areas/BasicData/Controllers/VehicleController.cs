using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;
using NewLife.Log;
using NewLife.Cube.Extensions;
using NewLife;
using VehicleVedioManage.BasicData.Entity;
using NewLife.Data;
using System.Text;
using VehicleVedioManage.Web.ViewModels;
using XCode.Membership;
using NewLife.Serialization;
using NewLife.Configuration;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("车辆信息")]
    public class VehicleController : EntityController<Vehicle>
    {
       
        static VehicleController()
        {
            LogOnChange = true;

            ListFields.RemoveField("ID", "Deleted","CreateUserID","UpdateUserID", "TenantID", "UpdateIP", "CreateIP", "Owner");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=车辆信息&linkId={ID}";
            }
        }

        protected override IEnumerable<Vehicle> Search(Pager p)
        {
            //var id = p["Deleted"].ToBoolean();
            //p["PlateColor"],p["RunStatus"],p["VehicleType"]
            //if (!id)
            //{
            //    var entity = Vehicle.FindByDeleted(id);
            //    return entity.Count == 0 ? new List<Vehicle>() : entity;
            //}
            var key = p["q"];
            return Vehicle.Search(p["vehicleId"], p["PlateColor"], p["RunStatus"], p["VehicleType"], p["AreaID"], key, p);
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

        public virtual string GetFilterWhere() { return ""; }

        /// <summary>
        /// 树形导航的数据
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ActionResult Tree(string pid="1")
        {
            IList<Vehicle> vehicles = Vehicle.FindAll();
            List<Entity> list = new List<Entity>();
            foreach (var item in vehicles)
            {
                Entity root = new Entity();
                root.Add("id", item.ID);
                root.Add("name", item.PlateNo);
                root.Add("title", item.PlateColorName);
                root.Add("isParent", 1);
                list.Add(root);
            }
            return Content(list.ToJson());
        }

        public override ActionResult Index(Pager p = null)
        {
            ActionResult contentResult = Tree();
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

        protected override Int32 OnUpdate(Vehicle entity)
        {
            var rs = -1;
            rs = base.OnUpdate(entity);
            if (rs > 0)
            {
                VehicleInfoModifyRecord vehicleInfoModifyRecord = new VehicleInfoModifyRecord();
                vehicleInfoModifyRecord.VehicleId = entity.ID;
                vehicleInfoModifyRecord.Owner = entity.Owner;
                vehicleInfoModifyRecord.Detail = "修改更新";
                vehicleInfoModifyRecord.CreateUserID = ManageProvider.User.ID;
                vehicleInfoModifyRecord.CreateTime = DateTime.Now;
                vehicleInfoModifyRecord.CreateIP = entity.CreateIP;
                vehicleInfoModifyRecord.TenantId = entity.TenantId;
                vehicleInfoModifyRecord.Type = "Edit";
                vehicleInfoModifyRecord.Insert();
            }
            return rs;
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
                    var entity = Vehicle.FindByKey(id);
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
