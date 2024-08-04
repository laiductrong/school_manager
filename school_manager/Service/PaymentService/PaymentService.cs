using AutoMapper;
using Microsoft.EntityFrameworkCore;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.PaymentDTO;

namespace school_manager.Service.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public PaymentService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<ServiceResponse<List<GetPayment>>> GetAll()
        {
            var response = new ServiceResponse<List<GetPayment>>();
            try
            {
                var data = await _dataContext.Payment
                    .Include(p => p.AcademicYear)
                    .Include(p=> p.Student).ToListAsync();
                if (data != null)
                {
                    response.Data = data.Select(p => _mapper.Map<GetPayment>(p)).ToList();
                    response.Success = true;
                    response.Message = "Get Payment success";
                }
                else {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Fails";
                }
            }
            catch (Exception ex) {
                response.Data = null;
                response.Success = true;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetPayment>>> GetByAcademic(int academicId)
        {
            var response = new ServiceResponse<List<GetPayment>>();
            try
            {
                var data =await _dataContext.Payment
                    .Include (p => p.AcademicYear)
                    .Include (p=> p.Student)
                    .Where(p => p.AcademicYearYearId == academicId)
                    .ToListAsync();
                if (data != null)
                {
                    response.Data = data.Select(p => _mapper.Map<GetPayment>(p)).ToList();
                    response.Success = true;
                    response.Message = "Get Payment success";
                }
                else {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Get Payment success";
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = true;
                response.Message = ex.Message;
            }
            return response;
        }

        public Task<ServiceResponse<GetPayment>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetPayment>>> GetByStudent(int studentId)
        {
            var response = new ServiceResponse<List<GetPayment>>();
            try
            {
                var data = await _dataContext.Payment
                    .Include(p => p.AcademicYear)
                    .Include(p => p.Student)
                    .Where(p => p.StudentId == studentId)
                    .ToListAsync();
                if (data != null)
                {
                    response.Data = data.Select(p => _mapper.Map<GetPayment>(p)).ToList();
                    response.Success = true;
                    response.Message = "Get Payment success";
                }
                else
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Get Payment success";
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = true;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ServiceResponse<string>> Pay(UpdatePayment updatePayment) {
            var response = new ServiceResponse<string>();
            try
            {
                var data = await _dataContext.Payment
                    .Include(p => p.AcademicYear)
                    .Include(p => p.Student)
                    .FirstOrDefaultAsync(p => p.PaymentId == updatePayment.PaymentId);

                if (data != null)
                {
                    var sodu = data.Amount - updatePayment.Amount;
                    data.Amount = sodu;
                    if (sodu <= 0)
                    {
                        data.Status = "Unpaid";
                    }
                    await _dataContext.SaveChangesAsync();
                }
                else
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Can't find pay";
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
