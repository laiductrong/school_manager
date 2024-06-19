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
            var reponse = new ServiceResponse<List<GetTeacher>>();
            var teacherAdd = new Teacher();
            teacherAdd.Name = teacher.Name;
            teacherAdd.Address = teacher.Address;
            teacherAdd.BirthDate = teacher.BirthDate;
            teacherAdd.PhoneNumber = teacher.PhoneNumber;
            teacherAdd.Email = teacher.Email;
            teacherAdd.SubjectId = teacher.SubjectId;
            try
            {
                await _dataContext.Teacher.AddAsync(teacherAdd);
                await _dataContext.SaveChangesAsync();
                try
                {
                    var dataTeacher = await _dataContext.Teacher.Include(t => t.Subject).ToListAsync();
                    if (dataTeacher is null)
                    {
                        reponse.Data = null;
                        reponse.Success = true;
                        reponse.Message = "Get Teachers Fail";
                        return reponse;
                    }
                    reponse.Data = dataTeacher.Select(t => _mapper.Map<GetTeacher>(t)).ToList();
                    reponse.Success = true;
                    reponse.Message = "Get Success";
                    return reponse;
                }
                catch (Exception)
                {
                    reponse.Data = null;
                    reponse.Success = false;
                    reponse.Message = "Add Success but Error Get Teacher";
                    return reponse;
                }
            }
            catch (Exception ex) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = ex.Message;
                return reponse;
            }
        }

        public async Task<ServiceResponse<List<GetTeacher>>> DeleteTeacher(int id)
        {
            var reponse = new ServiceResponse<List<GetTeacher>>();
            try
            {
                var teacherDelete = await _dataContext.Teacher.Include(t => t.Subject).FirstOrDefaultAsync(t => t.TeacherId == id);
                if (teacherDelete is null)
                {
                    reponse.Data = null;
                    reponse.Success = true;
                    reponse.Message = "Can't find id";
                    return reponse;
                }
                _dataContext.Teacher.Remove(teacherDelete);
                _dataContext.SaveChanges();
                try
                {
                    var dataTeacher = await _dataContext.Teacher.Include(t => t.Subject).ToListAsync();
                    if (dataTeacher is null)
                    {
                        reponse.Data = null;
                        reponse.Success = true;
                        reponse.Message = "Get Teachers Fail";
                        return reponse ;
                    }
                    reponse.Data = dataTeacher.Select(t => _mapper.Map<GetTeacher>(t)).ToList();
                    reponse.Success = true;
                    reponse.Message = "Delete Success";
                    return reponse;
                }
                catch (Exception ex)
                {
                    reponse.Data = null;
                    reponse.Success = false;
                    reponse.Message = ex.Message;
                    return reponse;
                }
            }
            catch (Exception ex) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = ex.Message;
                return reponse;
            }
        }

        public async Task<ServiceResponse<List<GetTeacher>>> GetAll()
        {
            var reponse = new ServiceResponse<List<GetTeacher>>();
            try {
                var dataTeacher = await _dataContext.Teacher.Include(t=>t.Subject).ToListAsync();
                if (dataTeacher is null)
                {
                    reponse.Data = null;
                    reponse.Success = true;
                    reponse.Message = "Get Teachers Fail";
                    return reponse;
                }
                reponse.Data = dataTeacher.Select(t => _mapper.Map<GetTeacher>(t)).ToList();
                reponse.Success = true;
                reponse.Message = "Get Success";
                return reponse;
            } catch (Exception ex) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = ex.Message;
                return reponse;
            }              
        }

        public async Task<ServiceResponse<GetTeacher>> GetById(int id)
        {
            var reponse = new ServiceResponse<GetTeacher>();
            try
            {
                var dataTeacher = await _dataContext.Teacher
                    .Include(t => t.Subject)
                    .FirstOrDefaultAsync(t => t.TeacherId == id);
                if (dataTeacher is null)
                {
                    reponse.Data = null;
                    reponse.Success = true;
                    reponse.Message = "Can't find id";
                    return reponse;
                }
                reponse.Data = _mapper.Map<GetTeacher>(dataTeacher);
                reponse.Success = true;
                reponse.Message = "Find Teacher Success";
                return reponse;
            }
            catch (Exception ex) { 
                reponse.Data = null;
                reponse.Success= false;
                reponse.Message = ex.Message;
                return reponse ;
            }
        }

        public async Task<ServiceResponse<List<GetTeacher>>> GetTeacherBySubject(int subjectId)
        {
            var reponse = new ServiceResponse<List<GetTeacher>>();
            try
            {
                var dataTeacher =await _dataContext.Teacher
                    .Include(t => t.Subject)
                    .Where(t => t.SubjectId == subjectId).ToListAsync();
                if (dataTeacher is null || !dataTeacher.Any()) 
                {
                    reponse.Data = null;
                    reponse.Success = true;
                    reponse.Message = "Don't have Teacher";
                    return reponse;
                }
                reponse.Data= dataTeacher.Select(t => _mapper.Map<GetTeacher>(t)).ToList();
                reponse.Success = true;
                reponse.Message = "Find Success";
                return reponse;
            }
            catch (Exception) {
                reponse.Data = null; 
                reponse.Success = false;
                reponse.Message = "Error find Teacher";
                return reponse;
            }         
        }

        public async Task<ServiceResponse<List<GetTeacher>>> UpdateTeacher(UpdateTeacher teacher)
        {
            var reponse = new ServiceResponse<List <GetTeacher>>();
            try
            {
                var dataUpdate = await _dataContext.Teacher
                .Include(t => t.Subject)
                .FirstOrDefaultAsync(t => t.SubjectId == teacher.SubjectId);
                if (dataUpdate is null)
                {
                    reponse.Data = null;
                    reponse.Success = true;
                    reponse.Message = "Can't find id";
                    return reponse;
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
                        reponse.Data = null;
                        reponse.Success = true;
                        reponse.Message = "Get Teachers Fail";
                        return reponse;
                    }
                    reponse.Data = dataTeacher.Select(t => _mapper.Map<GetTeacher>(t)).ToList();
                    reponse.Success = true;
                    reponse.Message = "Get Success";
                    return reponse;
                }
                catch (Exception)
                {
                    reponse.Data = null;
                    reponse.Success = false;
                    reponse.Message = "Update Success but Error Get";
                    return reponse;
                }
            }
            catch (Exception) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Error Update Teacher";
                return reponse;
            }
            
        }
    }
}
