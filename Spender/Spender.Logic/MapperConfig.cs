using AutoMapper;
using Spender.Logic.Models;
using Spender.Models;

namespace Spender.Logic
{
    public static class MapperConfig
    {
        public static void RegisterMappers(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Category, CategoryModel>();
            cfg.CreateMap<CategoryModel, Category>();

            cfg.CreateMap<Job, JobModel>()
                .ForMember(
                    dest => dest.End,
                    opt => opt.MapFrom(src => src.End)
                );
            cfg.CreateMap<JobModel, Job>()
                .ForMember(
                    dest => dest.End,
                    opt => opt.MapFrom(src => src.End)
                );
        }
    }
}