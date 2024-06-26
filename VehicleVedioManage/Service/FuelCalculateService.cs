using VehicleVedioManage.BackManagement.Entity;
using VehicleVedioManage.Utility.Extends;
using VehicleVedioManage.Web.IService;
using XCode;

namespace VehicleVedioManage.Web.Service
{
    /// <summary>
    /// 燃料计算服务
    /// </summary>
    public class FuelCalculateService : IFuelCalculateService
    { 
        /// <summary>
        /// 获取燃料
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="tankNo"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public double getFuel(int vehicleId, int tankNo, double level)
        {
            FuelTank ft = this.getFuelTank(vehicleId, tankNo);
            return getFuel(ft, level);
        }
        /// <summary>
        /// 获取燃料箱
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="tankNo"></param>
        /// <returns></returns>
        public FuelTank getFuelTank(int vehicleId, int tankNo)
        {
            var exp = new WhereExpression();
            exp &=FuelTank._.VehicleId == vehicleId;
            exp &=FuelTank._.TankNo == tankNo;
            var ft = FuelTank.FindByWhereExpress(exp);
            return ft;
        }
        /// <summary>
        /// 根据油箱和油位，计算当前的油量
        /// </summary>
        /// <param name="t"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public double getFuel(FuelTank t, double level)
        {
            double v = 0;
            level = level / 10000;
            double levelHeight = t.SensorLength * level + t.BlindHeight;//油位高度
            if (t.TankType == FuelTankExtend.TYPE_RECT)
            {
                //长方形油箱
                v = t.Height * t.Width * levelHeight;
            }
            else if (t.TankType == FuelTankExtend.TYPE_CIRCLE)
            {
                //double levelHeight = t.SensorLength * level + t.BlindHeight;
                if (levelHeight > t.Radius)
                {
                    double h1 = levelHeight - t.Radius;
                    double w1 = Math.Sqrt(t.Radius * t.Radius - h1 * h1);
                    double angle = Math.Abs(180 * Math.Asin(w1 / t.Radius)) / Math.PI;
                    v = t.Length * (Math.PI * t.Radius * t.Radius * (360 - angle * 2) / 360 + w1 * h1);
                }
                else if (levelHeight < t.Radius)
                {
                    double h1 = t.Radius - levelHeight;
                    double w1 = Math.Sqrt(t.Radius * t.Radius - h1 * h1);
                    double angle = Math.Abs(180 * Math.Asin(w1 / t.Radius)) / Math.PI;
                    v = t.Length * (Math.PI * t.Radius * t.Radius * angle * 2 / 360 - w1 * h1);
                }
                else
                {
                    v = t.Length * Math.PI * t.Radius * t.Radius / 2;
                }
            }
            v = v / 1000; //立方厘米转成升
            return v;
        }
    }
}
