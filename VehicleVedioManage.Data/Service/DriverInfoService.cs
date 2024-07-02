using NewLife.Log;
using NewLife.Model;

namespace VehicleVedioManage.Data.Service
{
    public class DriverInfoService
    {
        private readonly ITracer _tracer;
        public DriverInfoService(IServiceProvider provider) 
        {
            _tracer = provider?.GetService<ITracer>();
        }
    }
}
