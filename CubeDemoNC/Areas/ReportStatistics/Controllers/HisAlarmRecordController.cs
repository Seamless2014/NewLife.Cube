﻿using System.ComponentModel;
using GPSPlatform.ReportStatistics.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.ReportStatistics.Controllers
{
    [ReportStatisticsArea]
    [DisplayName("历史报警")]
    public class HisAlarmRecordController : EntityController<HisAlarmRecord>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}

