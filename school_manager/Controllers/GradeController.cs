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
        [HttpGet("GetGrades")]
        public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> GetGrades()
        {
            var response = await _gradeService.GetGrades();
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetGrade>>> GetGrade(int id)
        {
            var response = await _gradeService.GetGrade(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpGet("ByStudent/{studentId}")]
        public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> GetGradeByStudent(int studentId)
        {
            var response = await _gradeService.GetGradeByStudent(studentId);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("ByTeacher/{teacherId}")]
        public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> GetGradeByTeacher(int teacherId)
        {
            var response = await _gradeService.GetGradeByTeacher(teacherId);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("BySubject/{subjectId}")]
        public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> GetGradeBySubject(int subjectId)
        {
            var response = await _gradeService.GetGradeBySubject(subjectId);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("AddGrade")]
        public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> AddGrade(AddGrade addGrade)
        {
            var response = await _gradeService.AddGrade(addGrade);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("UpdateGrade")]
        public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> UpdateGrade(UpdateGrade updateGrade)
        {
            var response = await _gradeService.UpdateGrade(updateGrade);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{gradeId}")]
        public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> DeleteGrade(int gradeId)
        {
            var response = await _gradeService.DeleteGrade(gradeId);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
    }
