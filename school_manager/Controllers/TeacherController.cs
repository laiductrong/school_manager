using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_manager.DTOs.TeacherDTO;
using school_manager.Service.TeacherService;

namespace school_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet("GetTeachers")]
        public async Task<ActionResult<ServiceReponse<List<GetTeacher>>>> GetTeachers()
        {
            return Ok(await _teacherService.GetAll());
        }
    }
}
