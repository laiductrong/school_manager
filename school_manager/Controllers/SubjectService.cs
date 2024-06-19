using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_manager.DTOs.SubjectDTO;
using school_manager.Service.SubjectService;

namespace school_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectService : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectService(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetSubject>>> GetSubjectById(int id) { 
            return Ok(await _subjectService.GetSubjectById(id));
        }
        [HttpGet("GetSubjects")]
        public async Task<ActionResult<ServiceResponse<List<GetSubject>>>> GetSubjects()
        {
            return Ok(await _subjectService.GetSubjects());
        }
        [HttpPost("AddSubject")]
        public async Task<ActionResult<ServiceResponse<List<GetSubject>>>> AddSubject(AddSubject addSubject)
        {
            return Ok(await _subjectService.AddSubject(addSubject));
        }
        [HttpPost("Update")]
        public async Task<ActionResult<ServiceResponse<List<GetSubject>>>> UpdateSubject(UpdateSubject updateSubject)
        {
            return Ok(await _subjectService.UpdateSubject(updateSubject));
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<ServiceResponse<List<GetSubject>>>> DeleteSubject(int subjectId)
        {
            return Ok(await (_subjectService.DeleteSubject(subjectId)));
        }
        
    }
}
