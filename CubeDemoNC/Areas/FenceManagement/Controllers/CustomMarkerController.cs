﻿using System.ComponentModel;
using GPSPlatform.FenceManagement.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace GPSPlatform.Areas.FenceManagement.Controllers
{
    [FenceManagementArea]
    [DisplayName("定制标记")]
    public class CustomMarkerController : EntityController<CustomMarker>
    {
        public override ActionResult Index(Pager p = null)
        {
            return base.Index(p);
        }
    }
}