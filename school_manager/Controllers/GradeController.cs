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
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetGrade>>> GetGrade(int id)
    {
        var response = await _gradeService.GetGrade(id);
        if (!response.Success)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpGet("ByStudent/{studentId}")]
    public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> GetGradeByStudent(int studentId)
    {
        var response = await _gradeService.GetGradeByStudent(studentId);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet("ByTeacher/{teacherId}")]
    public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> GetGradeByTeacher(int teacherId)
    {
        var response = await _gradeService.GetGradeByTeacher(teacherId);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet("BySubject/{subjectId}")]
    public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> GetGradeBySubject(int subjectId)
    {
        var response = await _gradeService.GetGradeBySubject(subjectId);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPost("AddGrade")]
    public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> AddGrade(AddGrade addGrade)
    {
        var response = await _gradeService.AddGrade(addGrade);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPut("UpdateGrade")]
    public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> UpdateGrade(UpdateGrade updateGrade)
    {
        var response = await _gradeService.UpdateGrade(updateGrade);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpDelete("{gradeId}")]
    public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> DeleteGrade(int gradeId)
    {
        var response = await _gradeService.DeleteGrade(gradeId);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    }
}
