using NewLife;
using NewLife.Cube;
using System.ComponentModel;

namespace GPSPlatform.Areas.RuleManagement
{
    [DisplayName("报表统计")]
    public class RuleManagementArea : AreaBase
    {
        public RuleManagementArea() : base(nameof(RuleManagementArea).TrimEnd("Area")) { }

        static RuleManagementArea() => RegisterArea<RuleManagementArea>();
    }
}
