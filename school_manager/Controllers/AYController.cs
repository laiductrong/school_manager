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
            return Ok(await _aYService.GetAYs());
        }
        [HttpGet("GetAYById/{year}")]
        public async Task<ActionResult<ServiceResponse<GetAY>>> GetAY(int year)
        {
            return Ok(await _aYService.GetAYByID(year));
        }
        [HttpPost("AddAcademicYear")]
        public async Task<ActionResult<ServiceResponse<List<GetAY>>>> AddAY(AddAY addAY)
        {
            return Ok(await _aYService.AddAY(addAY));
        }
        [HttpDelete("DeleteAcademicYear/{IdYear}")]
        public async Task<ActionResult<ServiceResponse<List<GetAY>>>> DeleteAY(int IdYear)
        {
            return Ok(await _aYService.DeleteAY(IdYear));
        }
        [HttpPost("UpdateAY")]
        public async Task<ActionResult<ServiceResponse<List<GetAY>>>> UpdateAY(UpdateAY updateAY)
        {
            return Ok(await _aYService.UpdateAY(updateAY));
        }
    }
}
