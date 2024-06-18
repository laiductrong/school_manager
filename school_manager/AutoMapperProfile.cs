using AutoMapper;
using school_manager.DTOs.AcademicYearDTO;
using school_manager.DTOs.ClassDTO;
using school_manager.DTOs.SubjectDTO;
using school_manager.DTOs.TeacherDTO;
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
                .ForMember(dest => dest.YearId, opt => opt.MapFrom(src => src.AcademicYearYearId))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.YearName, opt => opt.MapFrom(src => src.AcademicYear.YearName));
            CreateMap<Subject, GetSubject>()
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Teacher, GetTeacher>()
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name));

        }
    }
}
