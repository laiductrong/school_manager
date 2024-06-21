﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.AcademicYearDTO;
using school_manager.Models;

namespace school_manager.Service.AYService
{
    public class AYService : IAYService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public AYService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<GetAY>>> AddAY(AddAY addAY)
        {
            var response = new ServiceResponse<List<GetAY>>();
            try
            {
                AcademicYear academicYear = new AcademicYear();
                academicYear.YearName = addAY.YearName;
                await _dataContext.AcademicYear.AddAsync(academicYear);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Error add Academic Year";
                return response;
            }
            try
            {
                response.Data = (await _dataContext.AcademicYear.ToListAsync()).Select(x => _mapper.Map<GetAY>(x)).ToList();
                response.Success = true;
                response.Message = "Add success";
                return response;
            }
            catch (Exception)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Add success but Error get Academic Year";
                return response;
            }
        }
        public async Task<ServiceResponse<List<GetAY>>> DeleteAY(int IdYear)
        {
            var response = new ServiceResponse<List<GetAY>>();
            var dataDelete = await _dataContext.AcademicYear.FirstOrDefaultAsync(x => x.YearId == IdYear);
            if (dataDelete is null)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Cannot find ID year";
                return response;
            }
            _dataContext.AcademicYear.Remove(dataDelete);
            await _dataContext.SaveChangesAsync();
            try
            {
                response.Data = (await _dataContext.AcademicYear.ToListAsync()).Select(x => _mapper.Map<GetAY>(x)).ToList();
                response.Success = true;
                response.Message = "Delete Success";
                return response;
            }
            catch (Exception)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Delete Success but Error Academic Year";
                return response;
            }
        }

        public async Task<ServiceResponse<GetAY>> GetAYByID(int year)
        {
            var response = new ServiceResponse<GetAY>();
            try
            {
                response.Data = _mapper.Map<GetAY>(await _dataContext.AcademicYear.FirstOrDefaultAsync(x => x.YearId == year));
                response.Success = true;
                response.Message = "Success";
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

        public async Task<ServiceResponse<List<GetAY>>> GetAYs()
        {
            var response = new ServiceResponse<List<GetAY>>();
            try
            {
                response.Data = (await _dataContext.AcademicYear.ToListAsync()).Select(x => _mapper.Map<GetAY>(x)).ToList();
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

        public async Task<ServiceResponse<List<GetAY>>> UpdateAY(UpdateAY updateAY)
        {
            var response = new ServiceResponse<List<GetAY>>();
            try
            {
                var academicUpdate = (await _dataContext.AcademicYear.FirstOrDefaultAsync(x => x.YearId == updateAY.YearId));
                if (academicUpdate == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Can not find Academic Year";
                    return response;
                }
                try
                {
                    academicUpdate.YearName = updateAY.YearName;
                    await _dataContext.SaveChangesAsync();
                    try
                    {
                        response.Data = (await _dataContext.AcademicYear.ToListAsync()).Select(x => _mapper.Map<GetAY>(x)).ToList();
                        response.Success = true;
                        response.Message = "Update Success";
                        return response;
                    }
                    catch (Exception)
                    {
                        response.Data = null;
                        response.Success = false;
                        response.Message = "Update success but error get List Academic Year";
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
                response.Message = "Error Academic by ID";
                return response;
            }
        }
    }
}
