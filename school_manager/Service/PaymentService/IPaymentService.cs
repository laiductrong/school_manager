using school_manager.Controllers;
using school_manager.DTOs.PaymentDTO;

namespace school_manager.Service.PaymentService
{
    public interface IPaymentService
    {
        Task<ServiceResponse<List<GetPayment>>> GetAll();
        Task<ServiceResponse<List<GetPayment>>> GetByStudent(int studentId);
        Task<ServiceResponse<GetPayment>> GetById(int id);
        Task<ServiceResponse<List<GetPayment>>> GetByAcademic(int academicId);
        Task<ServiceResponse<string>> Pay(UpdatePayment updatePayment);
    }
}
