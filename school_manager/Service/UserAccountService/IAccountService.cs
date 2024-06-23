using school_manager.Controllers;
using school_manager.DTOs.UserAccountDTO;

namespace school_manager.Service.UserAccountService
{
    public interface IAccountService
    {
        Task<ServiceResponse<List<GetAccount>>> GetAccounts();
        Task<ServiceResponse<List<GetAccount>>> GetAccountStudents();
        Task<ServiceResponse<List<GetAccount>>> GetAccountTeachera();
        Task<ServiceResponse<List<GetAccount>>> GetAccountManagers();
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<ServiceResponse<List<GetAccount>>> Register(AddAccount addAccount);
        Task<ServiceResponse<List<GetAccount>>> Delete(string id);
    }
}
