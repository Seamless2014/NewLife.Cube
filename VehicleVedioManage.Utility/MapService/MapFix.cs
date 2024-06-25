using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLife.Log;

namespace VehicleVedioManage.Utility.MapService
{
    public class MapFix
    {
        private readonly ITracer tracer;
        public MapFix(ITracer tracer) => this.tracer = tracer;
        public MapFix()
        {

        }
        public PointLatLng Reverse(double lng, double lat, String mapType)
        {
            if (Constants.MAP_GPS == mapType)
            {
                return new PointLatLng(lat, lng);
            }
            else if (Constants.MAP_BAIDU == mapType)
            {
                BMapFix bMapFix = new BMapFix(tracer);
                PointLatLng pt = bMapFix.bdToGcj(lat, lng);
                pt = MapFix.gcjToWgs(pt.Lat, pt.Lng);
                return pt;
            }
            else
                return gcjToWgs(lat, lng);
        }

        public PointLatLng Fix(double lng, double lat, String mapType)
        {
            if (Constants.MAP_BAIDU == mapType)
            {
                PointLatLng pt = wgsToGcj(lat, lng);
                BMapFix bMapFix = new BMapFix(tracer);
                pt = bMapFix.gcjToBd(pt.Lat, pt.Lng);
                return pt;
                //return BMapFix.Fix(lng, lat, BMapFix.COORDINATE_WGS84);
            }
            else
                return wgsToGcj(lat, lng);
        }

        public static PointLatLng gcjToWgs(double wgLat, double wgLon)
        {
            PointLatLng pl = wgsToGcj(wgLat, wgLon);
            double offsetLat = pl.Lat - wgLat;
            double offsetLng = pl.Lng - wgLon;

            return new PointLatLng(wgLat - offsetLat, wgLon - offsetLng);
        }

        /// <summary>
        /// 加偏 wgs 坐标 转 火星坐标GCJ-02
        /// </summary>
        static double a = 6378245.0;
        static double ee = 0.00669342162296594323;
        private static PointLatLng wgsToGcj(double wgLat, double wgLon)
        {
            double mgLat = 0;
            double mgLon = 0;
            if (outOfChina(wgLat, wgLon))
            {
                mgLat = wgLat;
                mgLon = wgLon;
                return new PointLatLng(mgLat, mgLon);
            }
            double dLat = transformLat(wgLon - 105.0, wgLat - 35.0);
            double dLon = transformLon(wgLon - 105.0, wgLat - 35.0);
            double radLat = wgLat / 180.0 * Math.PI;
            double magic = Math.Sin(radLat);
            magic = 1 - ee * magic * magic;
            double sqrtMagic = Math.Sqrt(magic);
            dLat = (dLat * 180.0) / ((a * (1 - ee)) / (magic * sqrtMagic) * Math.PI);
            dLon = (dLon * 180.0) / (a / sqrtMagic * Math.Cos(radLat) * Math.PI);
            mgLat = wgLat + dLat;
            mgLon = wgLon + dLon;

            PointLatLng pl = new PointLatLng(mgLat, mgLon);
            return pl;

        }

        private static Boolean outOfChina(double lat, double lon)
        {
            if (lon < 72.004 || lon > 137.8347)
                return true;
            if (lat < 0.8293 || lat > 55.8271)
                return true;
            return false;
        }

        private static double transformLat(double x, double y)
        {
            double ret = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y
                    + 0.2 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * Math.PI) + 20.0 * Math.Sin(2.0 * x * Math.PI)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(y * Math.PI) + 40.0 * Math.Sin(y / 3.0 * Math.PI)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(y / 12.0 * Math.PI) + 320 * Math.Sin(y * Math.PI / 30.0)) * 2.0 / 3.0;
            return ret;
        }

        private static double transformLon(double x, double y)
        {
            double ret = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1
                    * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * Math.PI) + 20.0 * Math.Sin(2.0 * x * Math.PI)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(x * Math.PI) + 40.0 * Math.Sin(x / 3.0 * Math.PI)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(x / 12.0 * Math.PI) + 300.0 * Math.Sin(x / 30.0
                    * Math.PI)) * 2.0 / 3.0;
            return ret;
        }

        /// <summary>
        /// 根据坐标反向解析获得地址
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <returns></returns>
        public string GetLocation(double lng, double lat)
        {
            BMapFix bMapFix = new BMapFix(tracer);
            return bMapFix.getLocation(lng, lat);

        }

        /// <summary>
        /// 计算距离(按米算)
        /// </summary>
        /// <param name="lng1"></param>
        /// <param name="lat1"></param>
        /// <param name="lng2"></param>
        /// <param name="lat2"></param>
        /// <returns></returns>
        public static double GetDistanceByMeter(double lng1, double lat1, double lng2, double lat2)
        {
            double radLat1 = rad(lat1);
            double radLat2 = rad(lat2);
            double a = radLat1 - radLat2;
            double b = rad(lng1) - rad(lng2);

            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000 * 1000) / 10000;
            return s;
        }


        private const double EARTH_RADIUS = 6378.137;//地球半径
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        /// 点是否在矩形中
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <param name="lng1"></param>
        /// <param name="lat1"></param>
        /// <param name="lng2"></param>
        /// <param name="lat2"></param>
        /// <returns></returns>
        public static Boolean IsInRect(double lng, double lat,
            double lng1, double lat1, double lng2, double lat2)
        {
            return lng >= Math.Min(lng1, lng2) && lng <= Math.Max(lng1, lng2)
                && lat >= Math.Min(lat1, lat2) && lat <= Math.Max(lat1, lat2);
        }


        /// <summary>
        /// 点是否在圆形中
        /// </summary>
        /// <param name="p"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static bool IsInCircle(PointLatLng p, PointLatLng center, double radius)
        {
            double distance = MapFix.GetDistanceByMeter(center.Lng, center.Lat, p.Lng, p.Lat);

            return distance <= radius;
        }
        /// <summary>
        /// 点是否在多边形中
        /// </summary>
        /// <param name="p"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        public static Boolean IsInPolygon(PointLatLng p, List<PointLatLng> points)
        {
            int i, j = points.Count - 1;
            bool oddNodes = false;

            double ret;
            for (i = 0; i < points.Count; i++)
            {
                if (points[i].Lat < p.Lat && points[j].Lat >= p.Lat
                  || points[j].Lat < p.Lat && points[i].Lat >= p.Lat)
                {
                    ret = points[i].Lng + (p.Lat - points[i].Lat) / (points[j].Lat - points[i].Lat) * (points[j].Lng - points[i].Lng);
                    if (ret < p.Lng)
                    {
                        oddNodes = !oddNodes;
                    }
                }
                j = i;
            }
            return oddNodes;
        }

        // / <summary>
        // / 计算叉乘 |P0P1| × |P0P2|
        // / </summary>
        // / <param name="p1"></param>
        // / <param name="p2"></param>
        // / <param name="p0"></param>
        // / <returns></returns>
        private static double MultiplyPoint(PointLatLng p1, PointLatLng p2,PointLatLng p0)
        {
            return ((p1.Lng - p0.Lng) * (p2.Lat - p0.Lat) - (p2.Lng - p0.Lng)
                    * (p1.Lat - p0.Lat));
        }

        public static double ESP = 0.000001;// (1e-5)
        /// <summary>
        /// 点是否在线上
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p0"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static Boolean IsPointOnLine(PointLatLng p1, PointLatLng p2, PointLatLng p0, int offset)
        {
            if (Math.Abs(MultiplyPoint(p1, p2, p0)) >= ESP * offset)
                return false;
            if ((p0.Lng - p1.Lng) * (p0.Lng - p2.Lng) > 0)
                return false;
            if ((p0.Lat - p1.Lat) * (p0.Lat - p2.Lat) > 0)
                return false;
            return true;
        }
        /// <summary>
        /// 点是否在路线段上
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p0"></param>
        /// <param name="bufferLen"></param>
        /// <returns></returns>
        public static Boolean isPointOnRouteSegment(PointLatLng p1, PointLatLng p2,PointLatLng p0, double bufferLen)
        {
            double a = GetDistanceByMeter(p0.Lng, p0.Lat, p1.Lng, p1.Lat);
            double b = GetDistanceByMeter(p0.Lng, p0.Lat, p2.Lng, p2.Lat);
            double c = GetDistanceByMeter(p2.Lng, p2.Lat, p1.Lng, p1.Lat);
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            double h = 2 * s / c;
            if (h > bufferLen)
                return false;
            double t1 = b * b + c * c - a * a;
            double t2 = a * a + c * c - b * b;
            if (t1 < 0 || t2 < 0)
                return false;
            return true;
        }


    }
}
