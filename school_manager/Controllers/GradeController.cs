using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_manager.Data;
using school_manager.DTOs.GradeDTO;
using school_manager.Service.GradeService;

namespace school_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        [HttpGet("GetGrade")]
        public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> GetGrade()
        {
            var response = await _gradeService.GetGrades();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
