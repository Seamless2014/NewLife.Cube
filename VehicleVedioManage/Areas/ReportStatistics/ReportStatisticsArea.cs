using NewLife;
using NewLife.Cube;
using System.ComponentModel;

namespace VehicleVedioManage.Areas.ReportStatistics
{
    [DisplayName("报表统计")]
    public class ReportStatisticsArea : AreaBase
    {
        public ReportStatisticsArea() : base(nameof(ReportStatisticsArea).TrimEnd("Area")) { }

        static ReportStatisticsArea() => RegisterArea<ReportStatisticsArea>();
    }
}
