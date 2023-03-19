using NewLife;
using NewLife.Cube;
using System.ComponentModel;

namespace VehicleVedioManage.Areas.FenceManagement
{
    [DisplayName("围栏管理")]
    public class FenceManagementArea : AreaBase
    {
        public FenceManagementArea() : base(nameof(FenceManagementArea).TrimEnd("Area")) { }

        static FenceManagementArea() => RegisterArea<FenceManagementArea>();
    }
}
