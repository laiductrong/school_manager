using school_manager.Controllers;
using school_manager.DTOs.SubjectDTO;

namespace school_manager.Service.SubjectService
{
    public interface ISubjectService
    {
        Task<ServiceResponse<GetSubject>> GetSubjectById(int id);
        Task<ServiceResponse<List<GetSubject>>> GetSubjects();
        Task<ServiceResponse<List<GetSubject>>> AddSubject(AddSubject subject);
        Task<ServiceResponse<List<GetSubject>>> UpdateSubject(UpdateSubject subject);
        Task<ServiceResponse<List<GetSubject>>> DeleteSubject(int id);
    }
}
