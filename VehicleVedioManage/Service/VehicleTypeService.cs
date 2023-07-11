using NewLife.Log;

namespace VehicleVedioManage.Web.Service
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
