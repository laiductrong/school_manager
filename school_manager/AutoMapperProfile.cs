using AutoMapper;
using school_manager.DTOs.AcademicYearDTO;
using school_manager.Models;
namespace school_manager
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AcademicYear, GetAY>()
                .ForMember(dest => dest.YearId, opt => opt.MapFrom(src => src.YearId))
                .ForMember(dest => dest.YearName, opt => opt.MapFrom(src => src.YearName));
        }
    }
}
