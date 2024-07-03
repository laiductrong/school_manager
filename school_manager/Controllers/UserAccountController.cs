using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_manager.DTOs.UserAccountDTO;
using school_manager.Models;
using school_manager.Service.UserAccountService;

namespace school_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private IAccountService _accountService;
        public UserAccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet("Accounts")]
        public async Task<ActionResult<ServiceResponse<List<GetAccount>>>> GetAccounts()
        {
            var response = await _accountService.GetAccounts();
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("StudentAccounts")]
        public async Task<ActionResult<ServiceResponse<List<GetAccount>>>> GetStudentAccounts()
        {
            var response = await _accountService.GetAccountStudents();
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(AccountLogin account)
        {
            var response = await _accountService.Login(account);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
