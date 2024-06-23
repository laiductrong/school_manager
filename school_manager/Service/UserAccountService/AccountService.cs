using AutoMapper;
using Microsoft.EntityFrameworkCore;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.UserAccountDTO;

namespace school_manager.Service.UserAccountService
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public AccountService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public Task<ServiceResponse<List<GetAccount>>> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetAccount>>> GetAccountManagers()
        {
            var response = new ServiceResponse<List<GetAccount>>();
            try
            {
                var accounts = await _dataContext.UserAccount.Include(a => a.Role).Where(a => a.ManagerId != null).ToListAsync();
                if (accounts is null || !accounts.Any())
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Account Emty";
                }
                response.Data = accounts.Select(a => _mapper.Map<GetAccount>(a)).ToList();
                response.Success = true;
                response.Message = "Get Success";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = true;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetAccount>>> GetAccounts()
        {
            var response = new ServiceResponse<List<GetAccount>>();
            try
            {
                var accounts = await _dataContext.UserAccount.Include(a => a.Role).ToListAsync();
                if (accounts is null || !accounts.Any())
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Account Emty";
                }
                response.Data = accounts.Select(a => _mapper.Map<GetAccount>(a)).ToList();
                response.Success = true;
                response.Message = "Get Success";
            }
            catch (Exception ex) { 
                response.Data = null;
                response.Success = true;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetAccount>>> GetAccountStudents()
        {
            var response = new ServiceResponse<List<GetAccount>>();
            try
            {
                var accounts = await _dataContext.UserAccount.Include(a => a.Role).Where(a=> a.StudentId!= null).ToListAsync();
                if (accounts is null || !accounts.Any())
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Account Emty";
                }
                response.Data = accounts.Select(a => _mapper.Map<GetAccount>(a)).ToList();
                response.Success = true;
                response.Message = "Get Success";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = true;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetAccount>>> GetAccountTeachera()
        {
            var response = new ServiceResponse<List<GetAccount>>();
            try
            {
                var accounts = await _dataContext.UserAccount.Include(a => a.Role).Where(a => a.TeacherId != null).ToListAsync();
                if (accounts is null || !accounts.Any())
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Account Emty";
                }
                response.Data = accounts.Select(a => _mapper.Map<GetAccount>(a)).ToList();
                response.Success = true;
                response.Message = "Get Success";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = true;
                response.Message = ex.Message;
            }
            return response;
        }

        public Task<ServiceResponse<GetAccount>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetAccount>>> Register(AddAccount addAccount)
        {
            throw new NotImplementedException();
        }
    }
}
