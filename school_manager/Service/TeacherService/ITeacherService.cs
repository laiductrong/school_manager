using school_manager.Controllers;
using school_manager.DTOs.TeacherDTO;

namespace school_manager.Service.TeacherService
{
    public interface ITeacherService
    {
        Task<ServiceResponse<GetTeacher>> GetById(int id);
        Task<ServiceResponse<List<GetTeacher>>> GetAll();
        Task<ServiceResponse<List<GetTeacher>>> AddTeacher(AddTeacher teacher);
        Task<ServiceResponse<List<GetTeacher>>> UpdateTeacher(UpdateTeacher teacher);
        Task<ServiceResponse<List<GetTeacher>>>  DeleteTeacher(int id);
        Task<ServiceResponse<List<GetTeacher>>> GetTeacherBySubject(int subjectId);
    }
}
