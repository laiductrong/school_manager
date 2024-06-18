using AutoMapper;
using Microsoft.EntityFrameworkCore;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.TeacherDTO;
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
        public Task<ServiceReponse<List<GetTeacher>>> AddTeacher(AddTeacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceReponse<List<GetTeacher>>> DeleteTeacher(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceReponse<List<GetTeacher>>> GetAll()
        {

            //var dataSubject = await _dataContext.Subject.ToListAsync();
            //reponse.Data = dataSubject.Select(s => _mapper.Map<GetSubject>(s)).ToList();
            var reponse = new ServiceReponse<List<GetTeacher>>();
            try {
                var dataTeacher = await _dataContext.Teacher.ToListAsync();
                if (dataTeacher is null)
                {
                    reponse.Data = null;
                    reponse.Success = false;
                    reponse.Message = "Get Teachers Fail";
                }
                reponse.Data = dataTeacher.Select(t => _mapper.Map<GetTeacher>(t)).ToList();
                reponse.Success = true;
                reponse.Message = dataTeacher.Count().ToString();
                return reponse;
            } catch (Exception ex) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = ex.Message;
                return reponse;
            }
            
            
           
        }

        public Task<ServiceReponse<GetTeacher>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceReponse<List<GetTeacher>>> GetTeacherBySubject(int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceReponse<List<GetTeacher>>> UpdateTeacher(UpdateTeacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
