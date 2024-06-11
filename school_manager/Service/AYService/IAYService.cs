using school_manager.Controllers;
using school_manager.DTOs.AcademicYearDTO;

namespace school_manager.Service.AYService
{
    public interface IAYService
    {
        Task<ServiceReponse<GetAY>> GetAYByID(int year);
        Task<ServiceReponse<List<GetAY>>> GetAYs();
        Task<ServiceReponse<List<GetAY>>> UpdateAY(UpdateAY updateAY);
        Task<ServiceReponse<List<GetAY>>> DeleteAY(int year);
    }
}
