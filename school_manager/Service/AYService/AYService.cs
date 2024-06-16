using AutoMapper;
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

        public async Task<ServiceReponse<List<GetAY>>> AddAY(AddAY addAY)
        {
            var reponse = new ServiceReponse<List<GetAY>>();
            try
            {
                AcademicYear academicYear = new AcademicYear();
                academicYear.YearName = addAY.YearName;
                await _dataContext.AcademicYear.AddAsync(academicYear);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Error add Academic Year";
                return reponse;
            }
            try
            {
                reponse.Data = (await _dataContext.AcademicYear.ToListAsync()).Select(x => _mapper.Map<GetAY>(x)).ToList();
                reponse.Success = true;
                reponse.Message = "Add success";
                return reponse;
            }
            catch (Exception)
            {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Add success but Error get Academic Year";
                return reponse;
            }
        }
        public async Task<ServiceReponse<List<GetAY>>> DeleteAY(int IdYear)
        {
            var reponse = new ServiceReponse<List<GetAY>>();
            var dataDelete = await _dataContext.AcademicYear.FirstOrDefaultAsync(x => x.YearId == IdYear);
            if (dataDelete is null)
            {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Cannot find ID year";
                return reponse;
            }
            _dataContext.AcademicYear.Remove(dataDelete);
            await _dataContext.SaveChangesAsync();
            try
            {
                reponse.Data = (await _dataContext.AcademicYear.ToListAsync()).Select(x => _mapper.Map<GetAY>(x)).ToList();
                reponse.Success = true;
                reponse.Message = "Delete Success";
                return reponse;
            }
            catch (Exception)
            {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Delete Success but Error Academic Year";
                return reponse;
            }
        }

        public async Task<ServiceReponse<GetAY>> GetAYByID(int year)
        {
            var reponse = new ServiceReponse<GetAY>();
            try
            {
                reponse.Data = _mapper.Map<GetAY>(await _dataContext.AcademicYear.FirstOrDefaultAsync(x => x.YearId == year));
                reponse.Success = true;
                reponse.Message = "Success";
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

        public async Task<ServiceReponse<List<GetAY>>> GetAYs()
        {
            var reponse = new ServiceReponse<List<GetAY>>();
            try
            {
                reponse.Data = (await _dataContext.AcademicYear.ToListAsync()).Select(x => _mapper.Map<GetAY>(x)).ToList();
                reponse.Success = true;
                reponse.Message = "Get Success";
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

        public async Task<ServiceReponse<List<GetAY>>> UpdateAY(UpdateAY updateAY)
        {
            var reponse = new ServiceReponse<List<GetAY>>();
            try
            {
                var academicUpdate = (await _dataContext.AcademicYear.FirstOrDefaultAsync(x => x.YearId == updateAY.YearId));
                if (academicUpdate == null)
                {
                    reponse.Data = null;
                    reponse.Success = false;
                    reponse.Message = "Can not find Academic Year";
                    return reponse;
                }
                try
                {
                    academicUpdate.YearName = updateAY.YearName;
                    await _dataContext.SaveChangesAsync();
                    try
                    {
                        reponse.Data = (await _dataContext.AcademicYear.ToListAsync()).Select(x => _mapper.Map<GetAY>(x)).ToList();
                        reponse.Success = true;
                        reponse.Message = "Update Success";
                        return reponse;
                    }
                    catch (Exception)
                    {
                        reponse.Data = null;
                        reponse.Success = false;
                        reponse.Message = "Update success but error get List Academic Year";
                        return reponse;
                    }
                }
                catch (Exception)
                {
                    reponse.Data = null;
                    reponse.Success = false;
                    reponse.Message = "Error Update";
                    return reponse;
                }
            }
            catch (Exception)
            {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Error Academic by ID";
                return reponse;
            }
        }
    }
}
