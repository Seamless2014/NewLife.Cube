using NewLife.Log;

namespace VehicleVedioManage.Web.Service
{
    public class TerminalInfoService
    {
        private readonly ITracer _tracer;
        public TerminalInfoService(IServiceProvider provider) 
        {
            _tracer = provider?.GetService<ITracer>();
        }
    }
}
