using NewLife.Log;

namespace VehicleVedioManage.Web.Service
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
