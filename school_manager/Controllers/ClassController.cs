using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_manager.DTOs.ClassDTO;
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
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetClass>>> GetClassByID(int id)
        {
            return Ok(await _classService.GetClass(id));
        }
        [HttpGet("GetClassByYear")]
        public async Task<ActionResult<ServiceResponse<List<GetClass>>>> GetClassByYear(int yearId)
        {
            return Ok(await _classService.GetClassByIdAY(yearId));
        }

        [HttpGet("GetClass")]
        public async Task<ActionResult<ServiceResponse<List<GetClass>>>> GetClass()
        {
            return Ok(await _classService.GetClasss());
        }
        [HttpPost("AddClass")]
        public async Task<ActionResult<ServiceResponse<List<GetClass>>>> AddClass(AddClass addClass)
        {
            return Ok(await _classService.AddClass(addClass));
        }
        [HttpPost("UpdateClass")]
        public async Task<ActionResult<ServiceResponse<List<GetClass>>>> UpdateClass(UpdateClass updateClass)
        {
            return Ok(await _classService.UpdateClass(updateClass));
        }
        [HttpDelete("DeleteClass")]
        public async Task<ActionResult<ServiceResponse<List<GetClass>>>> DeleteClass(int classID) { 
            return Ok(await _classService.DeleteClass(classID));
        }

    }
}
