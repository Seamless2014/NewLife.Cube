﻿using System.ComponentModel;
using GPSPlatform.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("驾驶记录")]
    public class DriverRecordController : EntityController<DriverRecord>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}
