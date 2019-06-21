using AutoMapper;
using Domain.Models;

namespace Domain.Dtos.AutomapperConfig
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustumerListDto>()
                        .ForMember(dest => dest.CustomerCategoryName,
                        opt => opt.MapFrom(src => src.CustomerCategory.CustomerCategoryName));
            });

            //var mapper = config.CreateMapper();

            
        }
    }
}
