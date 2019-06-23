using AutoMapper;
using Domain.Models;

namespace Domain.Dtos.AutomapperConfig
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => // Discount do 2 miejsc po przecinku
            {
                cfg.CreateMap<Customer, CustomerListDto>()
                .ForMember(dest => dest.AccountOpenedDate,
                        opt => opt.MapFrom(src => src.AccountOpenedDate.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.CustomerCategoryName,
                        opt => opt.MapFrom(src => src.CustomerCategory.CustomerCategoryName));
            });

            //var mapper = config.CreateMapper();


        }
    }
}
