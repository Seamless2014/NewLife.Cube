using NewLife.Log;
using NewLife.Model;

namespace VehicleVedioManage.Data.Service
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
