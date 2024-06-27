using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_manager.DTOs.ClassDTO;
using school_manager.Models;
using school_manager.Service.ClassService;

namespace school_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet("GetById/{id}"), Authorize(Roles = "Teacher, Manager, Admin")]
        public async Task<ActionResult<ServiceResponse<GetClass>>> GetClassByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Class ID required and must be a valid value");
            }
            var response = await _classService.GetClass(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetClassByYear"), Authorize(Roles = "Teacher, Manager, Admin")]
        public async Task<ActionResult<ServiceResponse<List<GetClass>>>> GetClassByYear(int yearId)
        {
            if (yearId <= 0)
            {
                return BadRequest("Class ID required and must be a valid value");
            }
            var response = await _classService.GetClassByIdAY(yearId);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetClass"), Authorize(Roles = "Teacher, Manager, Admin")]
        public async Task<ActionResult<ServiceResponse<List<GetClass>>>> GetClass()
        {
            var response = await _classService.GetClasss();
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("AddClass"), Authorize(Roles = "Manager, Admin")]
        public async Task<ActionResult<ServiceResponse<List<GetClass>>>> AddClass(AddClass addClass)
        {
            if (addClass == null)
            {
                return BadRequest("AddClass object is null");
            }

            if (string.IsNullOrEmpty(addClass.ClassName))
            {
                return BadRequest("ClassName is required");
            }
            if (addClass.YearId <= 0)
            {
                return BadRequest("Year ID is required and must be a valid value.");
            }
            var response = await _classService.AddClass(addClass);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("UpdateClass"), Authorize(Roles = " Manager, Admin")]
        public async Task<ActionResult<ServiceResponse<List<GetClass>>>> UpdateClass(UpdateClass updateClass)
        {
            if (updateClass == null)
            {
                return BadRequest("AddClass object is null");
            }
            if(updateClass.ClassId <= 0)
            {
                return BadRequest("Class ID required and must be a valid value");
            }

            if (string.IsNullOrEmpty(updateClass.ClassName))
            {
                return BadRequest("ClassName is required");
            }
            if (updateClass.YearId <= 0)
            {
                return BadRequest("Year ID is required and must be a valid value.");
            }
            var response = await _classService.UpdateClass(updateClass);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("DeleteClass"), Authorize(Roles = "Manager, Admin")]
        public async Task<ActionResult<ServiceResponse<List<GetClass>>>> DeleteClass(int classID)
        {
            if (classID <= 0)
            {
                return BadRequest("Class ID required and must be a valid value");
            }
            var response = await _classService.DeleteClass(classID);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }

}
