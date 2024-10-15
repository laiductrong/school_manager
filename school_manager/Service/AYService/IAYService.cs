using school_manager.Controllers;
using school_manager.DTOs.AcademicYearDTO;

namespace school_manager.Service.AYService
{
    public interface IAYService
    {
        Task<ServiceResponse<GetAY>> GetAYByID(int year);
        Task<ServiceResponse<List<GetAY>>> GetAYs();
        Task<ServiceResponse<List<GetAY>>> UpdateAY(UpdateAY updateAY);
        Task<ServiceResponse<List<GetAY>>> DeleteAY(int year);
        Task<ServiceResponse<List<GetAY>>> AddAY(AddAY addAY);
        Task<ServiceResponse<List<GetAY>>> FindByYear(string nameYear);
    }
}
