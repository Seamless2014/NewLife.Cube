﻿using System.ComponentModel;
using VehicleVedioManage.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BasicData.Controllers
{
    [BasicDataArea]
    [DisplayName("行业类型")]
    public class IndustryTypeController : EntityController<IndustryType>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("Id");
            return base.Index(p);
        }
    }
}