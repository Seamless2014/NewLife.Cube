using NewLife.Log;

namespace VehicleVedioManage.Web.Service
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
