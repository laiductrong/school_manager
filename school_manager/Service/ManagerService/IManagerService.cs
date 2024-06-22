using school_manager.Controllers;
using school_manager.DTOs.ManagerDTO;
using school_manager.Models;

namespace school_manager.Service.ManagerService
{
    public interface IManagerService
    {
        Task<ServiceResponse<GetManager>> GetManager(int managerId);
        Task<ServiceResponse<List<GetManager>>> GetManagers();
        Task<ServiceResponse<List<GetManager>>> AddManager(AddManager manager);
        Task<ServiceResponse<List<GetManager>>> UpdateManager(UpdateManager manager);
        Task<ServiceResponse<List<GetManager>>> DeleteManager(int managerId);
    }
}
