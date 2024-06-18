using school_manager.Controllers;
using school_manager.DTOs.TeacherDTO;

namespace school_manager.Service.TeacherService
{
    public interface ITeacherService
    {
        Task<ServiceReponse<GetTeacher>> GetById(int id);
        Task<ServiceReponse<List<GetTeacher>>> GetAll();
        Task<ServiceReponse<List<GetTeacher>>> AddTeacher(AddTeacher teacher);
        Task<ServiceReponse<List<GetTeacher>>> UpdateTeacher(UpdateTeacher teacher);
        Task<ServiceReponse<List<GetTeacher>>>  DeleteTeacher(int id);
        Task<ServiceReponse<List<GetTeacher>>> GetTeacherBySubject(int subjectId);
    }
}
