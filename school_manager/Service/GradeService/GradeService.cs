using AutoMapper;
using Microsoft.EntityFrameworkCore;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.GradeDTO;

namespace school_manager.Service.GradeService
{
    public class GradeService : IGradeService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public GradeService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public Task<ServiceResponse<List<GetGrade>>> AddGrade(AddGrade addGrade)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetGrade>>> DeleteGrade(int GradeId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetGrade>> GetGrade(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetGrade>>> GetGradeBySubject(int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetGrade>>> GetGradeBySutdent(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetGrade>>> GetGradeByTeacher(int teacherId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetGrade>>> GetGrades()
        {
            var response = new ServiceResponse<List<GetGrade>>();
            try
            {
                var dataGrade = await _dataContext.Grade
                    .Include(g => g.Student)
                    .Include(g => g.Teacher)
                        .ThenInclude(t => t.Subject)
                    .ToListAsync();
                response.Data = dataGrade.Select(g => _mapper.Map<GetGrade>(g)).ToList();
                response.Success = true;
                response.Message = "Get Score success";

            }
            catch (Exception ex) {
                response.Data = null;
                response.Success = true;
                response.Message = ex.Message;
            }
            return response;
        }

        public Task<ServiceResponse<List<GetGrade>>> UpdateGrade(UpdateGrade updateGrade)
        {
            throw new NotImplementedException();
        }
    }
}
