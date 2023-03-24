﻿using System.ComponentModel;
using VehicleVedioManage.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("用户数据")]
    public class UserDataController : EntityController<UserData>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("UserId");
            return base.Index(p);
        }
    }
}