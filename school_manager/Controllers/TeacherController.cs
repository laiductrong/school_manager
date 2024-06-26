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
        public async Task<ActionResult<ServiceResponse<List<GetTeacher>>>> GetTeachers()
        {
            var response = await _teacherService.GetAll();
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetTeacher/{id}")]
        public async Task<ActionResult<ServiceResponse<GetTeacher>>> GetTeacherById(int id)
        {
            var response = await _teacherService.GetById(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPost("AddTeacher")]
        public async Task<ActionResult<ServiceResponse<List<GetTeacher>>>> AddTeacher(AddTeacher teacher)
        {
            var response = await _teacherService.AddTeacher(teacher);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("UpdateTeacher")]
        public async Task<ActionResult<ServiceResponse<List<GetTeacher>>>> UpdateTeacher(UpdateTeacher teacher)
        {
            var response = await _teacherService.UpdateTeacher(teacher);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("DeleteTeacher/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetTeacher>>>> DeleteTeacher(int id)
        {
            var response = await _teacherService.DeleteTeacher(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpGet("GetTeachersBySubject/{subjectId}")]
        public async Task<ActionResult<ServiceResponse<List<GetTeacher>>>> GetTeachersBySubject(int subjectId)
        {
            var response = await _teacherService.GetTeacherBySubject(subjectId);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
