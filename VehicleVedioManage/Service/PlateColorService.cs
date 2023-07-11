using NewLife.Log;

namespace VehicleVedioManage.Web.Service
{
    public class PlateColorService
    {
        private readonly ITracer _tracer;
        public PlateColorService(IServiceProvider provider) 
        {
            _tracer = provider?.GetService<ITracer>();
        }
    }
}
