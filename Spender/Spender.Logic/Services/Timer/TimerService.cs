using System;
using AutoMapper;
using Spender.Dal;
using Spender.Logic.Models;
using Spender.Models;

namespace Spender.Logic.Services
{
    public class TimerService : BasicService, ITimerService
    {
        public TimerService(IUow uow) : base(uow)
        {

        }

        private Job ActiveJob()
        {
            return this.Unit.Jobs.AsQueryable.FirstOrDefault(j => j.End == null);
        }

        public JobModel GetActiveJob()
        {
            return Mapper.Map<JobModel>(this.ActiveJob());
        }

        public JobModel StartJob(int categoryId)
        {
            var job = new Job
            {
                CategoryId = categoryId,
                Start = DateTime.UtcNow
            };

            var id = this.Unit.Jobs.SaveItem(job);
            job.Id = id;

            return Mapper.Map<JobModel>(job);
        }

        public bool StopJob()
        {
            var job = this.ActiveJob();

            if(job != null)
            {
                job.End = DateTime.UtcNow;

                this.Unit.Jobs.SaveItem(job);

                return true;
            }

            return false;
        }
    }
}