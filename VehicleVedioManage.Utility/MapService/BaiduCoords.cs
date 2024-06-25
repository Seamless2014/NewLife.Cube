using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.MapService
{
    public class BaiduCoords
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 坐标
        /// </summary>
        public List<Coords> coords { get; set; }
    }
    public class Coords
    {
        public double x { get; set; }
        public double y { get; set; }
    }
}
