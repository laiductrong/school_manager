using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_manager.DTOs.UserAccountDTO;
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
        public async Task<ActionResult<ServiceResponse< List<GetAccount>>>> GetAccounts()
        {
            var response = await _accountService.GetAccounts();
            if (!response.Success) { 
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("StudentAccounts")]
        public async Task<ActionResult<ServiceResponse<List<GetAccount>>>> GetStudentAccounts()
        {
            var response = await _accountService.GetAccountStudents();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(string username, string password)
        {
            var response = await _accountService.Login(username,password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
