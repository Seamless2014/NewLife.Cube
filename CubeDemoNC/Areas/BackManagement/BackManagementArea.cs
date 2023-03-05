using NewLife;
using NewLife.Cube;
using System.ComponentModel;

namespace GPSPlatform.Areas.BackManagement
{

    [DisplayName("后台管理")]
    public class BackManagementArea : AreaBase
    {
        public BackManagementArea() : base(nameof(BackManagementArea).TrimEnd("Area")) { }

        static BackManagementArea() => RegisterArea<BackManagementArea>();
    }
}
