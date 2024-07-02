using NewLife.Log;
using NewLife.Model;

namespace VehicleVedioManage.Data.Service
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
