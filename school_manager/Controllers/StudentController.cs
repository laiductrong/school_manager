﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using school_manager.DTOs.StudentDTO;
using school_manager.Models;
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
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetStudent/{id}")]
        public async Task<ActionResult<ServiceResponse<GetStudent>>> GetStudentById(int id)
        {
            var response = await _studentService.GetById(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult<ServiceResponse<List<GetStudent>>>> AddStudent(AddStudent student)
        {
            var response = await _studentService.AddStudent(student);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<ServiceResponse<List<GetStudent>>>> UpdateStudent(UpdateStudent student)
        {
            var response = await _studentService.UpdateStudent(student);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetStudent>>>> DeleteStudent(int id)
        {
            var response = await _studentService.DeleteStudent(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpGet("GetStudentsByClass/{classId}")]
        public async Task<ActionResult<ServiceResponse<List<GetStudent>>>> GetStudentsByClass(int classId)
        {
            var response = await _studentService.GetStudentByClass(classId);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetStudentByPage")]
        public async Task<ActionResult<ServiceResponse<PaginatedList<GetStudent>>>> GetStudents(int pageIndex = 1, int pageSize = 10)
        {
            var response = await _studentService.GetAllByPage(pageIndex, pageSize);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet("FindByName")]
        public async Task<ActionResult< ServiceResponse<List<GetStudent>>>> GetByName(string name)
        {
            var reponse = await _studentService.GetByName(name);
            return reponse.Success ? Ok(reponse) : NotFound(reponse);
        }
        [HttpGet("export")]
        public async Task<ActionResult<ServiceResponse<string>>> ExportExcel()
        {
            var result = await _studentService.ExportStudentsToExcel();
            if (!result.Success)
            {
                return BadRequest();
            }
            return Ok(result);
            //var bytes = System.IO.File.ReadAllBytes(result.Data); // Đọc file Excel vừa xuất
            //return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Students.xlsx");
        }
    }

}
