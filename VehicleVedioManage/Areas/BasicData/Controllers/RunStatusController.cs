using System.ComponentModel;
using VehicleVedioManage.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;
using XCode.Membership;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("运营状态")]
    public class RunStatusController : EntityController<RunStatus>
    {
        static RunStatusController()
        {
            LogOnChange = true;

            ListFields.RemoveField("ID", "CreateUserID", "UpdateUserID", "CreateIP", "UpdateIP");

            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=运营状态&linkId={ID}";
            }
        }

        /// <summary>
        /// 检验数据的有效性
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="type"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        //protected override Boolean Valid(RunStatus entity, DataObjectMethodType type, Boolean post)
        //{
        //    if (post)
        //    {
        //        if (type != DataObjectMethodType.Delete)
        //        {
        //            if (RunStatus.isExistCode(entity.Code.Trim()))
        //            {
        //                throw new InvalidOperationException("编码已经存在！请重新输入");
        //            }
        //        }
        //        //// 新建时使用产品价格，但是后面可以修改为0价格
        //        //if (type == DataObjectMethodType.Insert)
        //        //{
        //        //    if (entity.Price <= 0 && entity.Product != null) entity.Price = entity.Product.Price;
        //        //}
        //    }

        //    return base.Valid(entity, type, post);
        //}

        //protected override Int32 OnInsert(RunStatus entity)
        //{
        //    var rs = -1;
        //    if (!RunStatus.isExistCode(entity.Name))
        //    {
        //        rs = base.OnInsert(entity);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("已经存在！请重新输入");
        //    }
        //    return rs;
        //}

        //protected override Int32 OnUpdate(RunStatus entity)
        //{
        //    var rs = -1;
        //    if (!RunStatus.isExistCode(entity.Name))
        //    {
        //        rs = base.OnUpdate(entity);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("已经存在！请重新输入");
        //    }
        //    return rs;
        //}

    }
}