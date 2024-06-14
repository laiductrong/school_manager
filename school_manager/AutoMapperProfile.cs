using AutoMapper;
using school_manager.DTOs.AcademicYearDTO;
using school_manager.DTOs.ClassDTO;
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
            CreateMap<Class, GetClass>()
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(dest => dest.YearId, opt => opt.MapFrom(src => src.YearId))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.AcademicYear, opt => opt.MapFrom(src => src.AcademicYear));

        }
    }
}
