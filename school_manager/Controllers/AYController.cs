using Azure;
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
        [HttpGet("GetAcademicYears")]
        public async Task<ActionResult<ServiceResponse<List<GetAY>>>> GetAYs() {
            var response  = await _aYService.GetAYs();
            return response.Success? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetAYById/{year}")]
        public async Task<ActionResult<ServiceResponse<GetAY>>> GetAY(int year)
        {
            var response = await _aYService.GetAYByID(year);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPost("AddAcademicYear")]
        public async Task<ActionResult<ServiceResponse<List<GetAY>>>> AddAY(AddAY addAY)
        {
            var response = await _aYService.AddAY(addAY);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpDelete("DeleteAcademicYear/{IdYear}")]
        public async Task<ActionResult<ServiceResponse<List<GetAY>>>> DeleteAY(int IdYear)
        {
            var response = await _aYService.DeleteAY(IdYear);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPost("UpdateAY")]
        public async Task<ActionResult<ServiceResponse<List<GetAY>>>> UpdateAY(UpdateAY updateAY)
        {
            var response =await _aYService.UpdateAY(updateAY);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
