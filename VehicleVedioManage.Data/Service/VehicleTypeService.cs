using NewLife.Log;
using NewLife.Model;

namespace VehicleVedioManage.Data.Service
{
    public class VehicleTypeService
    {
        private readonly ITracer _tracer;
        public VehicleTypeService(IServiceProvider provider) 
        {
            _tracer = provider?.GetService<ITracer>();
        }
    }
}
