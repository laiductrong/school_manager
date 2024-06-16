using school_manager.Controllers;
using school_manager.DTOs.SubjectDTO;

namespace school_manager.Service.SubjectService
{
    public interface ISubjectService
    {
        Task<ServiceReponse<GetSubject>> GetSubjectById(int id);
        Task<ServiceReponse<List<GetSubject>>> GetSubjects();
        Task<ServiceReponse<List<GetSubject>>> AddSubject(AddSubject subject);
        Task<ServiceReponse<List<GetSubject>>> UpdateSubject(UpdateSubject subject);
        Task<ServiceReponse<List<GetSubject>>> DeleteSubject(int id);
    }
}
