using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.MapService
{
    public class PointLatLng
    {
        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Lng { get; set; }

        public PointLatLng(double _lat, double _lng)
        {
            Lat = _lat;
            Lng = _lng;
        }
    }
}
