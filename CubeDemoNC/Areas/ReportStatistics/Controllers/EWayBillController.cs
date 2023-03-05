﻿using System.ComponentModel;
using GPSPlatform.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("电子运单")]
    public class EWayBillController : EntityController<EWayBill>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
