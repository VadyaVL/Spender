using FreshTinyIoC;
using Spender.Logic.Services;

namespace Spender.Logic
{
    public static class IoCConfig
    {
        public static void RegisterDependencies(FreshTinyIoCContainer container)
        {
            container.Register<ITimerService, TimerService>();
        }
    }
}
