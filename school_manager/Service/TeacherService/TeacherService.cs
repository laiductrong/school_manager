using AutoMapper;
using Microsoft.EntityFrameworkCore;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.TeacherDTO;
using school_manager.Models;
using System.Security.Cryptography.Xml;

namespace school_manager.Service.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public TeacherService(IMapper mapper,DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetTeacher>>> AddTeacher(AddTeacher teacher)
        {
            var response = new ServiceResponse<List<GetTeacher>>();
            var teacherAdd = _mapper.Map<Teacher>(teacher);
            try
            {
                await _dataContext.Teacher.AddAsync(teacherAdd);
                await _dataContext.SaveChangesAsync();
                try
                {
                    var dataTeacher = await _dataContext.Teacher.Include(t => t.Subject).ToListAsync();
                    if (dataTeacher is null)
                    {
                        response.Data = null;
                        response.Success = true;
                        response.Message = "Get Teachers Fail";
                        return response;
                    }
                    response.Data = dataTeacher.Select(t => _mapper.Map<GetTeacher>(t)).ToList();
                    response.Success = true;
                    response.Message = "Get Success";
                    return response;
                }
                catch (Exception)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Add Success but Error Get Teacher";
                    return response;
                }
            }
            catch (Exception ex) {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetTeacher>>> DeleteTeacher(int id)
        {
            var response = new ServiceResponse<List<GetTeacher>>();
            try
            {
                var teacherDelete = await _dataContext.Teacher.Include(t => t.Subject).FirstOrDefaultAsync(t => t.TeacherId == id);
                if (teacherDelete is null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Can't find id";
                    return response;
                }
                _dataContext.Teacher.Remove(teacherDelete);
                _dataContext.SaveChanges();
                try
                {
                    var dataTeacher = await _dataContext.Teacher.Include(t => t.Subject).ToListAsync();
                    if (dataTeacher is null)
                    {
                        response.Data = null;
                        response.Success = true;
                        response.Message = "Get Teachers Fail";
                        return response ;
                    }
                    response.Data = dataTeacher.Select(t => _mapper.Map<GetTeacher>(t)).ToList();
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
            catch (Exception ex) {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetTeacher>>> GetAll()
        {
            var response = new ServiceResponse<List<GetTeacher>>();
            try {
                var dataTeacher = await _dataContext.Teacher.Include(t=>t.Subject).ToListAsync();
                if (dataTeacher is null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Get Teachers Fail";
                    return response;
                }
                response.Data = dataTeacher.Select(t => _mapper.Map<GetTeacher>(t)).ToList();
                response.Success = true;
                response.Message = "Get Success";
                return response;
            } catch (Exception ex) {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }              
        }

        public async Task<ServiceResponse<GetTeacher>> GetById(int id)
        {
            var response = new ServiceResponse<GetTeacher>();
            try
            {
                var dataTeacher = await _dataContext.Teacher
                    .Include(t => t.Subject)
                    .FirstOrDefaultAsync(t => t.TeacherId == id);
                if (dataTeacher is null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Can't find id";
                    return response;
                }
                response.Data = _mapper.Map<GetTeacher>(dataTeacher);
                response.Success = true;
                response.Message = "Find Teacher Success";
                return response;
            }
            catch (Exception ex) { 
                response.Data = null;
                response.Success= false;
                response.Message = ex.Message;
                return response ;
            }
        }

        public async Task<ServiceResponse<List<GetTeacher>>> GetTeacherBySubject(int subjectId)
        {
            var response = new ServiceResponse<List<GetTeacher>>();
            try
            {
                var dataTeacher =await _dataContext.Teacher
                    .Include(t => t.Subject)
                    .Where(t => t.SubjectId == subjectId).ToListAsync();
                if (dataTeacher is null || !dataTeacher.Any()) 
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Don't have Teacher";
                    return response;
                }
                response.Data= dataTeacher.Select(t => _mapper.Map<GetTeacher>(t)).ToList();
                response.Success = true;
                response.Message = "Find Success";
                return response;
            }
            catch (Exception) {
                response.Data = null; 
                response.Success = false;
                response.Message = "Error find Teacher";
                return response;
            }         
        }

        public async Task<ServiceResponse<List<GetTeacher>>> UpdateTeacher(UpdateTeacher teacher)
        {
            var response = new ServiceResponse<List <GetTeacher>>();
            try
            {
                var dataUpdate = await _dataContext.Teacher
                .Include(t => t.Subject)
                .FirstOrDefaultAsync(t => t.SubjectId == teacher.SubjectId);
                if (dataUpdate is null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Can't find id";
                    return response;
                }
                dataUpdate.SubjectId = teacher.SubjectId;
                dataUpdate.Name = teacher.Name;
                dataUpdate.BirthDate = teacher.BirthDate;
                dataUpdate.PhoneNumber = teacher.PhoneNumber;
                dataUpdate.Email = teacher.Email;
                dataUpdate.SubjectId = teacher.SubjectId;
                await _dataContext.SaveChangesAsync();
                try
                {
                    var dataTeacher = await _dataContext.Teacher.Include(t => t.Subject).ToListAsync();
                    if (dataTeacher is null)
                    {
                        response.Data = null;
                        response.Success = true;
                        response.Message = "Get Teachers Fail";
                        return response;
                    }
                    response.Data = dataTeacher.Select(t => _mapper.Map<GetTeacher>(t)).ToList();
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
            catch (Exception) {
                response.Data = null;
                response.Success = false;
                response.Message = "Error Update Teacher";
                return response;
            }
            
        }
    }
}
