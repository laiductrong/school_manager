using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_manager.DTOs.GradeDTO;
using school_manager.DTOs.PaymentDTO;
using school_manager.Service.PaymentService;

namespace school_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentController)
        {
            _paymentService = paymentController;
        }
        [HttpGet("/getAll")]
        public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> getAll()
        {
            var response =await _paymentService.GetAll();
            return Ok(response);
        }
        [HttpGet("/getByStudent/{{studentId}}")]
        public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> GetByIdStudent(int studentId)
        {
            var response = await _paymentService.GetByStudent(studentId);
            return Ok(response);
        }
        [HttpGet("/getByAcademic/{{id}}")]
        public async Task<ActionResult<ServiceResponse<List<GetGrade>>>> GetByAcademic(int academicId)
        {
            var response = await _paymentService.GetByAcademic(academicId);
            return Ok(response);
        }
        [HttpPut("/Pay")]
        public async Task<ActionResult<ServiceResponse<string>>> Pay(UpdatePayment updatePayment)
        {
            var response = await _paymentService.Pay(updatePayment);
            return Ok(response);
        }
    }
}
