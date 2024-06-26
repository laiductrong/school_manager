using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_manager.DTOs.SubjectDTO;
using school_manager.Service.SubjectService;

namespace school_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetSubject>>> GetSubjectById(int id)
        {
            var response = await _subjectService.GetSubjectById(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpGet("GetSubjects")]
        public async Task<ActionResult<ServiceResponse<List<GetSubject>>>> GetSubjects()
        {
            var response = await _subjectService.GetSubjects();
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("AddSubject")]
        public async Task<ActionResult<ServiceResponse<List<GetSubject>>>> AddSubject(AddSubject addSubject)
        {
            var response = await _subjectService.AddSubject(addSubject);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<ServiceResponse<List<GetSubject>>>> UpdateSubject(UpdateSubject updateSubject)
        {
            var response = await _subjectService.UpdateSubject(updateSubject);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("Delete/{subjectId}")]
        public async Task<ActionResult<ServiceResponse<List<GetSubject>>>> DeleteSubject(int subjectId)
        {
            var response = await _subjectService.DeleteSubject(subjectId);
            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}
