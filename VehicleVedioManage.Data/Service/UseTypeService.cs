using NewLife.Log;
using NewLife.Model;

namespace VehicleVedioManage.Data.Service
{

    public class UseTypeService
    {
        private readonly ITracer _tracer;
        public UseTypeService(IServiceProvider provider)
        {
            _tracer = provider?.GetService<ITracer>();
        }
    }
}
