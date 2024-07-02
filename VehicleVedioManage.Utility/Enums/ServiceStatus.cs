using System.ComponentModel;

namespace VehicleVedioManage.Utility.Enums
{
    public enum ServiceStatus
    {
        [Description("服务中")]
        服务中 =1,
        [Description("已过期")]
        已过期 =2,
        [Description("即将过期")]
        即将过期 =3,
        [Description("试用中")]
        试用中 =4
    }
}
