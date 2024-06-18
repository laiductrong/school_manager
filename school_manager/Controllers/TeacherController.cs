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
            var response = await _teacherService.GetAll();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("GetTeacher/{id}")]
        public async Task<ActionResult<ServiceReponse<GetTeacher>>> GetTeacherById(int id)
        {
            var response = await _teacherService.GetById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("AddTeacher")]
        public async Task<ActionResult<ServiceReponse<List<GetTeacher>>>> AddTeacher(AddTeacher teacher)
        {
            var response = await _teacherService.AddTeacher(teacher);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("UpdateTeacher")]
        public async Task<ActionResult<ServiceReponse<List<GetTeacher>>>> UpdateTeacher(UpdateTeacher teacher)
        {
            var response = await _teacherService.UpdateTeacher(teacher);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("DeleteTeacher/{id}")]
        public async Task<ActionResult<ServiceReponse<List<GetTeacher>>>> DeleteTeacher(int id)
        {
            var response = await _teacherService.DeleteTeacher(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetTeachersBySubject/{subjectId}")]
        public async Task<ActionResult<ServiceReponse<List<GetTeacher>>>> GetTeachersBySubject(int subjectId)
        {
            var response = await _teacherService.GetTeacherBySubject(subjectId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
