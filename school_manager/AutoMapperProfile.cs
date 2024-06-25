using AutoMapper;
using school_manager.DTOs.AcademicYearDTO;
using school_manager.DTOs.ClassDTO;
using school_manager.DTOs.GradeDTO;
using school_manager.DTOs.ManagerDTO;
using school_manager.DTOs.PaymentDTO;
using school_manager.DTOs.SalaryDTO;
using school_manager.DTOs.StudentDTO;
using school_manager.DTOs.SubjectDTO;
using school_manager.DTOs.TeacherDTO;
using school_manager.DTOs.UserAccountDTO;
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
            CreateMap<Student, GetStudent>()
               .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
               .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.ClassName));
            CreateMap<Grade, GetGrade>()
                .ForMember(dest => dest.GradeId, opt => opt.MapFrom(src => src.GradeId))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.Name))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.Name))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Teacher.Subject.Name));
            CreateMap<Manager, GetManager>()
                .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Teacher.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Teacher.Address))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Teacher.BirthDate))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Teacher.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Teacher.Email))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.Teacher.SubjectId))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Teacher.Subject.Name));
            CreateMap<UserAccount, GetAccount>()
                  .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                  .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                  .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                  .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role != null ? src.Role.RoleName : "N/A"))
                  .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                  .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                  .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId));

            //Mapper for function Add
            CreateMap<AddAccount, UserAccount>()
                //.ForMember(dest => dest.UserId , null)
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId ));
            CreateMap<AddTeacher, Teacher>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId));
            CreateMap<AddSubject, Subject>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<AddStudent, Student>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId));
            CreateMap<AddSalary, Salary>()
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.BaseRate, opt => opt.MapFrom(src => src.BaseRate))
                .ForMember(dest => dest.TeachingHours, opt => opt.MapFrom(src => src.TeachingHours))
                .ForMember(dest => dest.Bonus, opt => opt.MapFrom(src => src.Bonus));
            CreateMap<AddPayment, Payment>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            CreateMap<AddManager, Manager>()
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId));
            CreateMap<AddGrade, Grade>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score));
            CreateMap<AddClass, Class>()
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(dest => dest.AcademicYearYearId, opt => opt.MapFrom(src => src.YearId))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId));
            CreateMap<AddAY, AcademicYear>()
                .ForMember(dest => dest.YearName, opt => opt.MapFrom(src => src.YearName));
                


        }
    }
}
