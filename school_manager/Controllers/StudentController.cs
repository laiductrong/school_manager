using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_manager.DTOs.StudentDTO;
using school_manager.Service.StudentService;

namespace school_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetStudents")]
        public async Task<ActionResult<ServiceResponse<List<GetStudent>>>> GetStudents()
        {
            var response = await _studentService.GetAll();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("GetStudent/{id}")]
        public async Task<ActionResult<ServiceResponse<GetStudent>>> GetStudentById(int id)
        {
            var response = await _studentService.GetById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult<ServiceResponse<List<GetStudent>>>> AddStudent(AddStudent student)
        {
            var response = await _studentService.AddStudent(student);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<ServiceResponse<List<GetStudent>>>> UpdateStudent(UpdateStudent student)
        {
            var response = await _studentService.UpdateStudent(student);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetStudent>>>> DeleteStudent(int id)
        {
            var response = await _studentService.DeleteStudent(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetStudentsByClass/{classId}")]
        public async Task<ActionResult<ServiceResponse<List<GetStudent>>>> GetStudentsByClass(int classId)
        {
            var response = await _studentService.GetStudentByClass(classId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }

}
