﻿using FreshTinyIoC;
using Spender.Dal;
using Spender.Logic.Services;

namespace Spender.Logic
{
    public static class IoCConfig
    {
        public static void RegisterDependencies(FreshTinyIoCContainer container)
        {
            container.Register<ITimerService, TimerService>();

            container.Register<ICategoryService, CategoryService>();
            container.Register<IJobService, JobService>();

            container.Register<IUow, Uow>();
        }
    }
}