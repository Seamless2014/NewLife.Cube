using VehicleVedioManage.Areas.BasicData;
using System.ComponentModel;
using VehicleVedioManage.BackManagement.Entity;
using VehicleVedioManage.BasicData.Entity;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.Web;

namespace VehicleVedioManage.Areas.BackManagement.Controllers
{
    [BackManagementArea]
    [DisplayName("司机信息")]
    public class DriverInfoController : EntityController<DriverInfo>
    {
        public override ActionResult Index(Pager p = null)
        {
            ListFields.RemoveField("DriverId", "Birthday", "DrivingType", "ExamineYear", "HarnessesAge", "Appointment", "BaseSalary", 
                "RoyaltiesScale", "AppraisalIntegral", "Password", "Register", "BgTitle", "PhotoFormat", "PhotoLength", "Deleted", "CreateTime", 
                "TenantId", "JobCard", "BgTitle", "UpdateTime", "DepartmentID");
            return base.Index(p);
        }
    }
}
