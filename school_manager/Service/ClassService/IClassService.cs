using school_manager.Controllers;
using school_manager.DTOs.ClassDTO;

namespace school_manager.Service.ClassService
{
    public interface IClassService
    {
        Task<ServiceReponse<GetClass>> GetClass(int classID);
        Task<ServiceReponse<List<GetClass>>> GetClasss();
        Task<ServiceReponse<List<GetClass>>> AddClass(AddClass addClass);
        Task<ServiceReponse<List<GetClass>>> UpdateClass(UpdateClass updateClass);
        Task<ServiceReponse<List<GetClass>>> DeleteClass(int classID);
    }
}
