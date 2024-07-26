using AutoMapper;
using Microsoft.EntityFrameworkCore;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.GradeDTO;
using school_manager.Models;

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
        public async Task<ServiceResponse<List<GetGrade>>> AddGrade(AddGrade addGrade)
        {
            var response = new ServiceResponse<List<GetGrade>>();
            //check exits
            try
            {
                var dataCheck =await _dataContext.Grade
                    .Include(g => g.Student)
                    .Include(g => g.Year)
                    .Include(g => g.Teacher)
                        .ThenInclude(g => g.Subject)
                        .FirstOrDefaultAsync(
                            g => g.StudentId == addGrade.StudentId 
                            && g.YearId ==addGrade.YearId 
                            && g.TeacherId == addGrade.TeacherId
                            );
                if (dataCheck != null) {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Graden exits";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = true;
                response.Message = ex.Message;
                return response;
            }
            //
            try
            {
                var add = _mapper.Map<Grade>(addGrade);
                await _dataContext.Grade.AddAsync(add);
                await _dataContext.SaveChangesAsync();
                try
                {
                    var dataGrade = await _dataContext.Grade
                        .Include(g => g.Student)
                        .Include(g => g.Teacher)
                            .ThenInclude(t => t.Subject)
                        .Include(g => g.Year)
                        .ToListAsync();
                    if (dataGrade == null || !dataGrade.Any())
                    {
                        response.Data = new List<GetGrade>();
                        response.Success = true;
                        response.Message = "Empty list";
                        return response;
                    }
                    response.Data = dataGrade.Select(g => _mapper.Map<GetGrade>(g)).ToList();
                    response.Success = true;
                    response.Message = "Add Success";
                    return response;

                }
                catch (Exception ex)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "GET Error";
                    return response;
                }
            }
            catch (Exception ex) {
                response.Data = null;
                response.Success = false;
                response.Message = "Add Error";
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetGrade>>> DeleteGrade(int GradeId)
        {
            var response = new ServiceResponse<List<GetGrade>>();
            try
            {
                var dataDelete = await _dataContext.Grade
                    .Include(g => g.Student)
                    .Include(g => g.Teacher)
                        .ThenInclude(g => g.Subject)
                    .Include(g => g.Year)
                        .FirstOrDefaultAsync(g => g.GradeId == GradeId);
                if (dataDelete == null)
                {
                    response.Data = null; // Initialize with an empty list
                    response.Success = true;
                    response.Message = "Can't find id";
                    return response;
                }
                try
                {
                    //delete
                    _dataContext.Remove(dataDelete);
                    await _dataContext.SaveChangesAsync();
                    //get list
                    var dataGrade = await _dataContext.Grade
                        .Include(g => g.Student)
                        .Include(g => g.Teacher)
                            .ThenInclude(t => t.Subject)
                        .ToListAsync();
                    response.Data = dataGrade.Select(g => _mapper.Map<GetGrade>(g)).ToList();
                    response.Success = true;
                    response.Message = "Delete success";
                }
                catch (Exception ex)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = ex.Message;
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

        public async Task<ServiceResponse<GetGrade>> GetGrade(int id)
        {
            var response = new ServiceResponse<GetGrade>();
            try
            {
                var dataGrade = await _dataContext.Grade
                    .Include(g => g.Student)
                    .Include(g => g.Year)
                    .Include(g => g.Teacher)
                        .ThenInclude(g => g.Subject)
                        .FirstOrDefaultAsync(g => g.GradeId == id);
                if (dataGrade == null)
                {
                    response.Data = null; // Initialize with an empty list
                    response.Success = true;
                    response.Message = "Empty list";
                    return response;
                }
                response.Data = _mapper.Map<GetGrade>(dataGrade);
                response.Success = true;
                response.Message = "Get Score success";

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetGrade>>> GetGradeBySubject(int subjectId)
        {
            var response = new ServiceResponse<List<GetGrade>>();
            try
            {
                var dataGrade = await _dataContext.Grade
                    .Include(g => g.Student)
                    .Include(g => g.Year)
                    .Include(g => g.Teacher)
                        .ThenInclude(g => g.Subject)
                        .Where(g => g.Teacher.SubjectId == subjectId)
                    .ToListAsync();
                if (dataGrade == null || !dataGrade.Any())
                {
                    response.Data = new List<GetGrade>(); // Initialize with an empty list
                    response.Success = true;
                    response.Message = "Empty list";
                    return response;
                }
                response.Data = dataGrade.Select(g => _mapper.Map<GetGrade>(g)).ToList();
                response.Success = true;
                response.Message = "Get Score success";

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetGrade>>> GetGradeByStudent(int studentId)
        {
            var response = new ServiceResponse<List<GetGrade>>();
            try
            {
                var dataGrade = await _dataContext.Grade
                .Where(g => g.StudentId == studentId) // Apply filter for the specific teacher
                    .Include(g => g.Student)
                    .Include(g => g.Year)
                    .Include(g => g.Teacher)
                        .ThenInclude(g => g.Subject)
                    .ToListAsync();
                if (dataGrade == null || !dataGrade.Any())
                {
                    response.Data = new List<GetGrade>(); // Initialize with an empty list
                    response.Success = true;
                    response.Message = "Empty list";
                    return response;
                }
                response.Data = dataGrade.Select(g => _mapper.Map<GetGrade>(g)).ToList();
                response.Success = true;
                response.Message = "Get Score success";

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetGrade>>> GetGradeByTeacher(int teacherId)
        {
            var response = new ServiceResponse<List<GetGrade>>();
            try
            {
                var dataGrade = await _dataContext.Grade
                    .Where(g => g.TeacherId == teacherId) // Apply filter for the specific teacher
                    .Include(g => g.Student)
                    .Include(g => g.Year)
                    .Include(g => g.Teacher)
                        .ThenInclude(g => g.Subject)
                    .ToListAsync();
                if (dataGrade == null || !dataGrade.Any())
                {
                    response.Data = new List<GetGrade>(); // Initialize with an empty list
                    response.Success = true;
                    response.Message = "Empty list";
                    return response;
                }
                response.Data = dataGrade.Select(g => _mapper.Map<GetGrade>(g)).ToList();
                response.Success = true;
                response.Message = "Get Score success";

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
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
                    .Include(g => g.Year)
                    .ToListAsync();
                if (dataGrade == null || !dataGrade.Any())
                {
                    response.Data = new List<GetGrade>(); // Initialize with an empty list
                    response.Success = true;
                    response.Message = "Empty list";
                    return response;
                }
                response.Data = dataGrade.Select(g => _mapper.Map<GetGrade>(g)).ToList();
                response.Success = true;
                response.Message = "Get Score success";

            }
            catch (Exception ex) {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetGrade>>> UpdateGrade(UpdateGrade updateGrade)
        {
            var response = new ServiceResponse<List<GetGrade>>();
            //check exits
            try
            {
                var dataCheck = await _dataContext.Grade
                    .Include(g => g.Student)
                    .Include(g => g.Year)
                    .Include(g => g.Teacher)
                        .ThenInclude(g => g.Subject)
                        .FirstOrDefaultAsync(
                            g => g.StudentId == updateGrade.StudentId
                            && g.YearId == updateGrade.YearId
                            && g.TeacherId == updateGrade.TeacherId
                            );
                if (dataCheck != null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Graden exits";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = true;
                response.Message = ex.Message;
                return response;
            }
            try
            {
                // Retrieve the existing grade
                var grade = await _dataContext.Grade.FirstOrDefaultAsync(g => g.GradeId == updateGrade.GradeId);
                if (grade == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Grade not found.";
                    return response;
                }

                // Update the grade properties
                grade.TeacherId = updateGrade.TeacherId;
                grade.StudentId = updateGrade.StudentId;
                grade.Score = updateGrade.Score;
                grade.YearId = updateGrade.YearId;

                // Save changes to the database
                _dataContext.Grade.Update(grade);
                await _dataContext.SaveChangesAsync();

                // Retrieve the updated list of grades
                var dataGrade = await _dataContext.Grade
                    .Include(g => g.Student)
                    .Include(g => g.Year)
                    .Include(g => g.Teacher)
                        .ThenInclude(t => t.Subject)
                    .ToListAsync();

                if (dataGrade == null || !dataGrade.Any())
                {
                    response.Data = new List<GetGrade>();
                    response.Success = true;
                    response.Message = "Empty list";
                    return response;
                }

                response.Data = dataGrade.Select(g => _mapper.Map<GetGrade>(g)).ToList();
                response.Success = true;
                response.Message = "Update Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Update Error: " + ex.Message;
                return response;
            }
        }

    }
}
