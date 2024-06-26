using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_manager.DTOs.ManagerDTO;
using school_manager.Service.ManagerService;

namespace school_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet("GetManager/{managerId}")]
        public async Task<ActionResult<ServiceResponse<GetManager>>> GetManager(int managerId)
        {
            var response = await _managerService.GetManager(managerId);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetManagers")]
        public async Task<ActionResult<ServiceResponse<List<GetManager>>>> GetManagers()
        {
            var response = await _managerService.GetManagers();
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("AddManager")]
        public async Task<ActionResult<ServiceResponse<List<GetManager>>>> AddManager(AddManager manager)
        {
            var response = await _managerService.AddManager(manager);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetManager>>>> UpdateManager(int id, UpdateManager manager)
        {
            if (id != manager.ManagerId)
            {
                return BadRequest("ID mismatch between route parameter and payload.");
            }

            var response = await _managerService.UpdateManager(manager);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetManager>>>> DeleteManager(int id)
        {
            var response = await _managerService.DeleteManager(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
