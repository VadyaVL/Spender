using System;

namespace Spender.Logic.Services
{
    public interface ITimerService
    {
        void Start(ref DateTime dateTime);

        void Stop(ref DateTime dateTime);
    }
}
