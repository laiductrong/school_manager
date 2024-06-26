using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.UserAccountDTO;
using school_manager.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace school_manager.Service.UserAccountService
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AccountService(DataContext dataContext, IMapper mapper, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _configuration = configuration;
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
                response.Success = false;
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
                response.Success = false;
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
                response.Success = false;
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
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> Login(AccountLogin account)
        {
            string username = account.UserName;
            string password = account.Password;
            var response = new ServiceResponse<string>();
            var user = await _dataContext.UserAccount.Include(a=>a.Role).FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                response.Data = null;
                response.Success = true;
                response.Message = "not found username";
                return response;
            }
            var userSuccess = _mapper.Map<GetAccount>(user);
            response.Data = CreateToken(userSuccess);
            response.Success = true;
            response.Message = "Success";
            return response;
        }

        public async Task<ServiceResponse<GetAccount>> Register(AddAccount addAccount)
        {
            var response = new ServiceResponse<GetAccount>();
            var add = _mapper.Map<UserAccount>(addAccount);
            try
            {
                await _dataContext.UserAccount.AddAsync(add);
                await _dataContext.SaveChangesAsync();
                try
                {
                    var data = await _dataContext.UserAccount.Include(a => a.Role)
                        .FirstOrDefaultAsync(a =>
                            a.Username == addAccount.Username &&
                            a.Password == addAccount.Password &&
                            a.RoleId == addAccount.RoleId
                        );
                    if (data == null) {
                        response.Data = null;
                        response.Success = true;
                        response.Message = "Register Fail";
                        return response;
                    }
                    response.Data = _mapper.Map<GetAccount>(data);
                    response.Success = true;
                    response.Message = "Register Success";
                }
                catch (Exception)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Register Fail";
                }
            }
            catch (Exception ex) { 
                response.Data = null;
                response.Success= false;
                response.Message = ex.Message;
            }
            return response;

        }
        private string CreateToken(GetAccount user)
        {
            // Lấy ID nào không null đầu tiên
            var id = user.StudentId ?? user.TeacherId ?? user.ManagerId;

            // Nếu id vẫn null, là ADMIN
            if (id == null)
            {
                id = null;
            }

            // Tạo danh sách các claims
            var claims = new List<Claim>
            {
                new Claim("username", user.Username),
                new Claim(ClaimTypes.Role, user.RoleName),
                new Claim("id", id.Value.ToString()) // id.Value vì id là nullable int
            };

            // Lấy khóa bí mật từ cấu hình
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            // Tạo thông tin ký
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Tạo token
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            // Tạo chuỗi JWT từ token
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
