using AutoMapper;
using Spender.Logic.Models;
using Spender.Models;

namespace Spender.Logic
{
    public static class MapperConfig
    {
        public static void RegisterMappers(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Job, JobModel>();
            cfg.CreateMap<JobModel, Job>();

            cfg.CreateMap<Category, CategoryModel>();
            cfg.CreateMap<CategoryModel, Category>();

        }
    }
}