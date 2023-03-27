﻿using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("终端指令")]
    public class TerminalCommandController : EntityController<TerminalCommand>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("CmdId", "Owner", "UserId", "TenantId", "VehicleId", "Deleted");
            return base.Index(p);
        }
    }
}