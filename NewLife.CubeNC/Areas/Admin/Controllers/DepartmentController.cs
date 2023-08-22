﻿using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube.ViewModels;
using NewLife.Web;
using XCode.Membership;

namespace NewLife.Cube.Admin.Controllers;

/// <summary>部门</summary>
[DataPermission(null, "ManagerID={#userId}")]
[DisplayName("部门")]
[Area("Admin")]
[Menu(95, true, Icon = "fa-users", Mode = MenuModes.Admin | MenuModes.Tenant)]
public class DepartmentController : EntityController<Department>
{
    static DepartmentController()
    {
        LogOnChange = true;

        ListFields.RemoveField("Id", "TenantId", "Ex1", "Ex2", "Ex3", "Ex4", "Ex5", "Ex6");
        ListFields.RemoveUpdateField();
        ListFields.RemoveCreateField();
        ListFields.RemoveRemarkField();

        //// 创建表单不需要创建更新信息字段
        //AddFormFields.RemoveCreateField();
        //AddFormFields.RemoveUpdateField();
    }

    /// <summary>获取字段信息</summary>
    /// <param name="kind"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    protected override FieldCollection OnGetFields(ViewKinds kind, Object model)
    {
        var rs = base.OnGetFields(kind, model);
        switch (kind)
        {
            case ViewKinds.Detail:
            case ViewKinds.AddForm:
            case ViewKinds.EditForm:
                rs.RemoveField("TenantId", "TenantName");
                break;
            default:
                break;
        }

        return rs;
    }

    /// <summary>搜索数据集</summary>
    /// <param name="p"></param>
    /// <returns></returns>
    protected override IEnumerable<Department> Search(Pager p)
    {
        var id = p["id"].ToInt(-1);
        if (id > 0)
        {
            var list = new List<Department>();
            var entity = Department.FindByID(id);
            if (entity != null) list.Add(entity);
            return list;
        }

        var parentId = p["parentId"].ToInt(-1);
        var enable = p["enable"]?.ToBoolean();
        var visible = p["visible"]?.ToBoolean();

        return Department.Search(parentId, enable, visible, p["Q"], p);
    }
}