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
        public async Task<ActionResult<ServiceReponse<GetClass>>> GetClassByID(int id)
        {
            return Ok(await _classService.GetClass(id));
        }

    }
}
