using school_manager.Controllers;
using school_manager.DTOs.UserAccountDTO;
using school_manager.Models;

namespace school_manager.Service.UserAccountService
{
    public interface IAccountService
    {
        Task<ServiceResponse<List<GetAccount>>> GetAccounts();
        Task<ServiceResponse<List<GetAccount>>> GetAccountStudents();
        Task<ServiceResponse<List<GetAccount>>> GetAccountTeachera();
        Task<ServiceResponse<List<GetAccount>>> GetAccountManagers();
        Task<ServiceResponse<string>> Login(AccountLogin account);
        Task<ServiceResponse<GetAccount>> Register(AddAccount addAccount);
        Task<ServiceResponse<List<GetAccount>>> Delete(string id);
    }
}
