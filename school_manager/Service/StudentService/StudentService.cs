using AutoMapper;
using Microsoft.EntityFrameworkCore;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.StudentDTO;
using school_manager.Models;

namespace school_manager.Service.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public StudentService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<GetStudent>>> AddStudent(AddStudent student)
        {
            var response = new ServiceResponse<List<GetStudent>>();
            var studentAdd = new Student
            {
                Name = student.Name,
                Address = student.Address,
                BirthDate = student.BirthDate,
                PhoneNumber = student.PhoneNumber,
                Email = student.Email,
                ClassId = student.ClassId
            };

            try
            {
                await _dataContext.Student.AddAsync(studentAdd);
                await _dataContext.SaveChangesAsync();

                try
                {
                    var dataStudent = await _dataContext.Student.Include(s=>s.Class).ToListAsync();
                    if (dataStudent is null)
                    {
                        response.Data = null;
                        response.Success = true;
                        response.Message = "Get Students Fail";
                        return response;
                    }
                    response.Data = dataStudent.Select(s => _mapper.Map<GetStudent>(s)).ToList();
                    response.Success = true;
                    response.Message = "Get Success";
                    return response;
                }
                catch (Exception)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Add Success but Error Get Students";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetStudent>>> DeleteStudent(int id)
        {
            var response = new ServiceResponse<List<GetStudent>>();
            try
            {
                var studentDelete = await _dataContext.Student.Include(s => s.Class).FirstOrDefaultAsync(s => s.StudentId == id);
                if (studentDelete is null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Can't find id";
                    return response;
                }
                _dataContext.Student.Remove(studentDelete);
                await _dataContext.SaveChangesAsync();

                try
                {
                    var dataStudent = await _dataContext.Student.Include(s => s.Class).ToListAsync();
                    if (dataStudent is null)
                    {
                        response.Data = null;
                        response.Success = true;
                        response.Message = "Get Students Fail";
                        return response;
                    }
                    response.Data = dataStudent.Select(s => _mapper.Map<GetStudent>(s)).ToList();
                    response.Success = true;
                    response.Message = "Delete Success";
                    return response;
                }
                catch (Exception ex)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = ex.Message;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetStudent>>> GetAll()
        {
            var response = new ServiceResponse<List<GetStudent>>();
            try
            {
                var dataStudent = await _dataContext.Student.Include(s => s.Class).ToListAsync();
                if (dataStudent is null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Get Students Fail";
                    return response;
                }
                response.Data = dataStudent.Select(s => _mapper.Map<GetStudent>(s)).ToList();
                response.Success = true;
                response.Message = "Get Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<GetStudent>> GetById(int id)
        {
            var response = new ServiceResponse<GetStudent>();
            try
            {
                var dataStudent = await _dataContext.Student
                    .Include(s => s.Class)
                    .FirstOrDefaultAsync(s => s.StudentId == id);
                if (dataStudent is null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Can't find id";
                    return response;
                }
                response.Data = _mapper.Map<GetStudent>(dataStudent);
                response.Success = true;
                response.Message = "Find Student Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetStudent>>> GetStudentByClass(int classId)
        {
            var response = new ServiceResponse<List<GetStudent>>();
            try
            {
                var dataStudent = await _dataContext.Student
                    .Include(s => s.Class)
                    .Where(s => s.ClassId == classId).ToListAsync();
                if (dataStudent is null || !dataStudent.Any())
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Don't have Students";
                    return response;
                }
                response.Data = dataStudent.Select(s => _mapper.Map<GetStudent>(s)).ToList();
                response.Success = true;
                response.Message = "Find Success";
                return response;
            }
            catch (Exception)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Error finding Students";
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetStudent>>> UpdateStudent(UpdateStudent student)
        {
            var response = new ServiceResponse<List<GetStudent>>();
            try
            {
                var dataUpdate = await _dataContext.Student
                    .Include(s => s.Class)
                    .FirstOrDefaultAsync(s => s.StudentId == student.StudentId);
                if (dataUpdate is null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Can't find id";
                    return response;
                }
                dataUpdate.Name = student.Name;
                dataUpdate.Address = student.Address;
                dataUpdate.BirthDate = student.BirthDate;
                dataUpdate.PhoneNumber = student.PhoneNumber;
                dataUpdate.Email = student.Email;
                dataUpdate.ClassId = student.ClassId;
                await _dataContext.SaveChangesAsync();

                try
                {
                    var dataStudent = await _dataContext.Student.Include(s => s.Class).ToListAsync();
                    if (dataStudent is null)
                    {
                        response.Data = null;
                        response.Success = true;
                        response.Message = "Get Students Fail";
                        return response;
                    }
                    response.Data = dataStudent.Select(s => _mapper.Map<GetStudent>(s)).ToList();
                    response.Success = true;
                    response.Message = "Get Success";
                    return response;
                }
                catch (Exception)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Update Success but Error Get";
                    return response;
                }
            }
            catch (Exception)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Error Update Student";
                return response;
            }
        }
    }

}
