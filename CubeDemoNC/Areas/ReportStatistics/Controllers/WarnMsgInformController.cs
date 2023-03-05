﻿using System.ComponentModel;
using GPSPlatform.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("报警信息")]
    public class WarnMsgInformController : EntityController<WarnMsgInform>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
