using NewLife;
using NewLife.Cube;
using System.ComponentModel;

namespace VehicleVedioManage.Areas.RuleManagement
{
    [DisplayName("规则管理")]
    public class RuleManagementArea : AreaBase
    {
        public RuleManagementArea() : base(nameof(RuleManagementArea).TrimEnd("Area")) { }

        static RuleManagementArea() => RegisterArea<RuleManagementArea>();
    }
}
