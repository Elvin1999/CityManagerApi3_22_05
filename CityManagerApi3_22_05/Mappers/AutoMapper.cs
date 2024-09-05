using AutoMapper;
using CityManagerApi3_22_05.Dtos;
using CityManagerApi3_22_05.Entities;

namespace CityManagerApi3_22_05.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<City, CityForListDto>()
                .ForMember(dest => dest.PhotoUrl, option =>
                {
                    option.MapFrom(src => src.CityImages.FirstOrDefault(c => c.IsMain).Url);
                });

            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
