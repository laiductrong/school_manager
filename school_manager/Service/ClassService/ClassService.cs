﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.AcademicYearDTO;
using school_manager.DTOs.ClassDTO;
using school_manager.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace school_manager.Service.ClassService
{
    public class ClassService : IClassService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public ClassService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<ServiceResponse<List<GetClass>>> AddClass(AddClass addClass)
        {
            var response = new ServiceResponse<List<GetClass>>(); ;
            try
            {
                Class addC = _mapper.Map<Class>(addClass);
                await _dataContext.Class.AddAsync(addC);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception) {
                response.Data = null;
                response.Success = true;
                response.Message = "Error add Class";
                return response ;
            }
            try
            {
                var dataClass = await _dataContext.Class
                    .Include(x => x.AcademicYear)
                    .Include(c => c.Teacher)
                    .ToListAsync();
                response.Data = dataClass.Select(x => _mapper.Map<GetClass>(x)).ToList();
                response.Success = true;
                response.Message = "Add success Class";
                return response;
            }
            catch (Exception)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Add Class Success but Error Get Class";
                return response;
            }

        }

        public async Task<ServiceResponse<List<GetClass>>> DeleteClass(int classID)
        {
            var response = new ServiceResponse<List<GetClass>>();
            var dataDelete = await _dataContext.Class.FirstOrDefaultAsync(x => x.ClassId == classID);
            if (dataDelete is null) {
                response.Data = null;
                response.Success = true;
                response.Message = "Can not find Class";
                return response;
            }
            try
            {
                _dataContext.Class.Remove(dataDelete);
                await _dataContext.SaveChangesAsync();
                try
                {
                    var dataClass = await _dataContext.Class
                        .Include(x => x.AcademicYear)
                        .Include(c => c.Teacher)
                        .ToListAsync();
                    response.Data = dataClass.Select(x => _mapper.Map<GetClass>(x)).ToList();
                    response.Success = true;
                    response.Message = "Add success Class";
                    return response;
                }
                catch (Exception)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Delete Class Success but Error Get Class";
                    return response;
                }
            }
            catch (Exception) {
                response.Data = null;
                response.Success = false;
                response.Message = "Error Delete";
                return response;
            }
        }

        public async Task<ServiceResponse<GetClass>> GetClass(int classID)
        {
            var response = new ServiceResponse<GetClass>();
            var dataFind = await _dataContext.Class
            .Include(x => x.AcademicYear)
            .Include(c => c.Teacher)
            .FirstOrDefaultAsync(x => x.ClassId == classID);
            if (dataFind is null)
            {
                response.Data = null;
                response.Success = true;
                response.Message = "Can not find Class";
                return response;
            }
            response.Data = _mapper.Map<GetClass>(dataFind);
            response.Success = true;
            response.Message = "Find Success";
            return response;
        }

        public async Task<ServiceResponse<List<GetClass>>> GetClasss()
        {
            var response = new ServiceResponse<List<GetClass>>();
            try
            {
                var data = await _dataContext.Class
                    .Include(x=>x.AcademicYear)
                    .Include(c => c.Teacher)
                    .ToListAsync();
                response.Data = data.Select(x => _mapper.Map<GetClass>(x)).ToList();
                response.Success = true;
                response.Message = "Get Class Success";
                return response;
            }
            catch (Exception)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Error Get Class";
                return response;
            }    
        }
        public async Task<ServiceResponse<List<GetClass>>> GetClassByIdAY (int idAY)
        {
            var response = new ServiceResponse<List<GetClass>>();
            try
            {
                var classes = await _dataContext.Class
                    .Include(c => c.AcademicYear)
                    .Include(c => c.Teacher)
                    .Where(x => x.AcademicYearYearId == idAY).ToListAsync();
                response.Data = classes.Select(x => _mapper.Map<GetClass>(x)).ToList();
                response.Success = true;
                response.Message = "Get Class Success";
                return response;
            }
            catch (Exception)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Error Get Class";
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetClass>>> UpdateClass(UpdateClass updateClass)
        {
            var response = new ServiceResponse<List<GetClass>>();
            try
            {
                var data = (await _dataContext.Class.FirstOrDefaultAsync(x => x.ClassId == updateClass.ClassId));
                if (data == null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Can not find Class";
                    return response;
                }
                try
                {
                    data.ClassName = updateClass.ClassName;
                    data.AcademicYearYearId = updateClass.YearId;
                    data.TeacherId = updateClass.TeacherId;
                    await _dataContext.SaveChangesAsync();
                    try
                    {
                        var dataClass = await _dataContext.Class
                            .Include(x => x.AcademicYear)
                            .Include(c => c.Teacher)
                            .ToListAsync();
                        response.Data = dataClass.Select(x => _mapper.Map<GetClass>(x)).ToList();
                        response.Success = true;
                        response.Message = "Update Success";
                        return response;
                    }
                    catch (Exception)
                    {
                        response.Data = null;
                        response.Success = true;
                        response.Message = "Update success but error Get List Class";
                        return response;
                    }
                }
                catch (Exception)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Error Update";
                    return response;
                }
            }
            catch (Exception)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Error Class by ID";
                return response;
            }
        }
    }
}
