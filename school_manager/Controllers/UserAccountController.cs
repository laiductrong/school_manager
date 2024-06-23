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
        public async Task<ActionResult<List<GetAccount>>> GetAccounts()
        {
            var response = await _accountService.GetAccounts();
            if (!response.Success) { 
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
