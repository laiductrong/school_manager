using school_manager.Controllers;
using school_manager.DTOs.ClassDTO;

namespace school_manager.Service.ClassService
{
    public interface IClassService
    {
        Task<ServiceResponse<GetClass>> GetClass(int classID);
        Task<ServiceResponse<List<GetClass>>> GetClasss();
        Task<ServiceResponse<List<GetClass>>> GetClassByIdAY(int idAY);
        Task<ServiceResponse<List<GetClass>>> AddClass(AddClass addClass);
        Task<ServiceResponse<List<GetClass>>> UpdateClass(UpdateClass updateClass);
        Task<ServiceResponse<List<GetClass>>> DeleteClass(int classID);
    }
}
