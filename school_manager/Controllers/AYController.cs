using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_manager.DTOs.AcademicYearDTO;
using school_manager.Service.AYService;

namespace school_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AYController : ControllerBase
    {
        private readonly IAYService _aYService;
        public AYController(IAYService aYService )
        {
            _aYService = aYService;
        }
        [HttpGet("GetAcademicYears"), Authorize(Roles = "Teacher, Manager, Admin")]
        public async Task<ActionResult<ServiceResponse<List<GetAY>>>> GetAYs() {
            var response  = await _aYService.GetAYs();
            return response.Success? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetAYById/{year}"), Authorize(Roles = "Teacher, Manager, Admin")]
        public async Task<ActionResult<ServiceResponse<GetAY>>> GetAY(int year)
        {
            var response = await _aYService.GetAYByID(year);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPost("AddAcademicYear"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<GetAY>>>> AddAY(AddAY addAY)
        {
            var response = await _aYService.AddAY(addAY);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpDelete("DeleteAcademicYear/{IdYear}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<GetAY>>>> DeleteAY(int IdYear)
        {
            var response = await _aYService.DeleteAY(IdYear);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPost("UpdateAY"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<GetAY>>>> UpdateAY(UpdateAY updateAY)
        {
            var response =await _aYService.UpdateAY(updateAY);
            return  Ok(response) ;
        }
    }
}
