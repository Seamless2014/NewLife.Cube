using VehicleVedioManage.Areas.BasicData;
using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using VehicleVedioManage.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;
using NewLife.Log;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("司机信息")]
    public class DriverInfoController : EntityController<DriverInfo>
    {
        private readonly ITracer _tracer;
        public DriverInfoController(IServiceProvider provider)
        {
            PageSetting.EnableTableDoubleClick = true;
            _tracer = provider?.GetService<ITracer>();
        }
        public override ActionResult Index(Pager p = null)
        {
            
            ListFields.RemoveField("ID", "Birthday", "DrivingType", "ExamineYear", "HarnessesAge", "Appointment", "BaseSalary", 
                "RoyaltiesScale", "AppraisalIntegral", "Password", "Register", "BgTitle", "PhotoFormat", "PhotoLength", "Deleted", "CreateTime", 
                "TenantId", "JobCard", "BgTitle", "UpdateTime", "DepartmentID");
            return base.Index(p);
        }

        protected override IEnumerable<DriverInfo> Search(Pager p)
        {
            using var span = _tracer?.NewSpan(nameof(Search), p);
            var key = p["q"];
            int _depID = 0;
            if (p["Department"] != null)
            {
                _depID = int.Parse(p["Department"]);
            }
            return DriverInfo.Search(_depID, key, p);
        }
    }
}
