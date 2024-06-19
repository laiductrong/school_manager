using AutoMapper;
using Microsoft.EntityFrameworkCore;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.SubjectDTO;
using school_manager.Models;
using System.Security.Cryptography.Xml;

namespace school_manager.Service.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public SubjectService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<ServiceResponse<List<GetSubject>>> AddSubject(AddSubject subject)
        {
            var reponse = new ServiceResponse<List<GetSubject>>();
            Subject addSubject = new Subject();
            addSubject.Name = subject.Name;
            try
            {
                await _dataContext.AddAsync(addSubject);
                await _dataContext.SaveChangesAsync();
                try
                {
                    var dataSubject = await _dataContext.Subject.ToListAsync();
                    reponse.Data = dataSubject.Select(s => _mapper.Map<GetSubject>(s)).ToList();
                    reponse.Success = true;
                    reponse.Message = "Add Success";
                }
                catch (Exception) {
                    reponse.Data = null;
                    reponse.Success = false;
                    reponse.Message = "Add Success but Error Get Subject";
                }
                return reponse;
            }
            catch (Exception) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Add Subject Fail";
                return reponse;
            }
        }

        public async Task<ServiceResponse<List<GetSubject>>> DeleteSubject(int id)
        {
            var reponse = new ServiceResponse<List<GetSubject>>();
            var dataSubject = await _dataContext.Subject.FirstOrDefaultAsync(s => s.SubjectId == id);
            if (dataSubject is null)
            {
                reponse.Data = null;
                reponse.Success = true;
                reponse.Message = "Can't find subject";
                return reponse;
            }
            try
            {
                _dataContext.Subject.Remove(dataSubject);
                _dataContext.SaveChanges();
                try
                {
                    var dataSubjects = await _dataContext.Subject.ToListAsync();
                    reponse.Data = dataSubjects.Select(s => _mapper.Map<GetSubject>(s)).ToList();
                    reponse.Success = true;
                    reponse.Message = "DeleteSucess";
                    return reponse;
                }
                catch (Exception)
                {
                    reponse.Data = null;
                    reponse.Success = false;
                    reponse.Message = "Delete success but Error Get Subjects";
                    return reponse;
                }
            }
            catch (Exception) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Error Delete";
                return reponse;
            }
        }

        public async Task<ServiceResponse<List<GetSubject>>> GetSubjects()
        {
           var reponse = new ServiceResponse<List<GetSubject>>();
            try
            {
                var dataSubject = await _dataContext.Subject.ToListAsync();
                reponse.Data = dataSubject.Select(s=> _mapper.Map<GetSubject>(s)).ToList();
                reponse.Success = true;
                reponse.Message = "Get Success";
            }
            catch (Exception) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Get Subject Fail";
            }
            return reponse;
        }

        public async Task<ServiceResponse<GetSubject>> GetSubjectById(int id)
        {
            var reponse = new ServiceResponse<GetSubject>();
            var dataSubject = await _dataContext.Subject.FirstOrDefaultAsync(s => s.SubjectId == id);
            if (dataSubject is null) {
                reponse.Data = null;
                reponse.Success = true;
                reponse.Message = "Can't find subject";
                return reponse;
            }
            reponse.Data = _mapper.Map<GetSubject>(dataSubject);
            reponse.Success = true;
            reponse.Message = "Find Subject success";
            return reponse;
        }

        public async Task<ServiceResponse<List<GetSubject>>> UpdateSubject(UpdateSubject subject)
        {
            var reponse = new ServiceResponse<List<GetSubject>>();
            try
            {
                var dataUpdate = await _dataContext.Subject.FirstOrDefaultAsync(s => s.SubjectId == subject.SubjectId);
                if (dataUpdate is null)
                {
                    reponse.Data = null;
                    reponse.Success = true;
                    reponse.Message = "Can't find subject";
                    return reponse;
                }
                try
                {
                    dataUpdate.Name = subject.Name;
                    await _dataContext.SaveChangesAsync();
                    try
                    {
                        var dataSubject = await _dataContext.Subject.ToListAsync();
                        reponse.Data = dataSubject.Select(s => _mapper.Map<GetSubject>(s)).ToList();
                        reponse.Success = true;
                        reponse.Message = "Update Success";
                    }
                    catch (Exception) {
                        reponse.Data = null;
                        reponse.Success= false;
                        reponse.Message = "Error Get Subject";
                    }
                } catch (Exception) {
                    reponse.Data = null;
                    reponse.Success = false;
                    reponse.Message = "Error Update";
                }
            }
            catch (Exception) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Error Find Subject";
            }
            return reponse;
        }
    }
}
