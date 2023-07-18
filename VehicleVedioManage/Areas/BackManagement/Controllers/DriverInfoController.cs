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
       
        static DriverInfoController()
        {
            LogOnChange = true;
            ListFields.RemoveField("ID", "Birthday", "DrivingType", "ExamineYear", "HarnessesAge", "Appointment", "BaseSalary",
                "RoyaltiesScale", "AppraisalIntegral", "Password", "Register", "BgTitle", "PhotoFormat", "PhotoLength", "Deleted", "CreateTime",
                "TenantId", "JobCard", "BgTitle", "UpdateTime", "DepartmentID");
            {
                var df = ListFields.AddListField("Log", "UpdateUser");
                df.DisplayName = "日志";
                df.Url = "/Admin/Log?category=司机信息&linkId={ID}";
            }
        }

        protected override IEnumerable<DriverInfo> Search(Pager p)
        {
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
