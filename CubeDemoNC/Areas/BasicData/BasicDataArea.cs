using NewLife;
using NewLife.Cube;
using System.ComponentModel;

namespace GPSPlatform.Areas.BasicData
{
    [DisplayName("基础数据")]
    public class BasicDataArea : AreaBase
    {
        public BasicDataArea() : base(nameof(BasicDataArea).TrimEnd("Area")) { }

        static BasicDataArea() => RegisterArea<BasicDataArea>();
    }
}
