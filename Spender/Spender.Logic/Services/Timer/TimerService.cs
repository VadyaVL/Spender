using System;
using AutoMapper;
using Spender.Dal;
using Spender.Logic.Models;
using Spender.Models;

namespace Spender.Logic.Services
{
    public class TimerService : BasicService, ITimerService
    {
        private ICategoryService CategoryService { get; set; }

        public TimerService(IUow uow, ICategoryService categoryService) : base(uow)
        {
            this.CategoryService = categoryService;
        }

        private Job ActiveJob()
        {
            var job = this.Unit.Jobs.AsQueryable.FirstOrDefault(j => j.End == null);

            if(job != null)
            {
                job.Category = this.CategoryService.Get(job.CategoryId);
            }

            return job;
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

            if (job != null)
            {
                job.Category = this.CategoryService.Get(categoryId);
            }

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