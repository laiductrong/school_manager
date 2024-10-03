using school_manager.Controllers;
using school_manager.DTOs.StudentDTO;
using school_manager.Models;

namespace school_manager.Service.StudentService
{
    public interface IStudentService
    {

        Task<ServiceResponse<GetStudent>> GetById(int id);
        Task<ServiceResponse<List<GetStudent>>> GetAll();
        Task<ServiceResponse<List<GetStudent>>> AddStudent(AddStudent student);
        Task<ServiceResponse<List<GetStudent>>> UpdateStudent(UpdateStudent student);
        Task<ServiceResponse<List<GetStudent>>>  DeleteStudent(int id);
        Task<ServiceResponse<List<GetStudent>>> GetStudentByClass(int classId);
        Task<ServiceResponse<PaginatedList<GetStudent>>> GetAllByPage(int pageIndex, int pageSize);
        Task<ServiceResponse<List<GetStudent>>> GetByName(string name);


    }
}
