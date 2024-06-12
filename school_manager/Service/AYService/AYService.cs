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

        public AYService( IMapper mapper, DataContext dataContext) {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<ServiceReponse<List<GetAY>>> DeleteAY(int year)
        {
            var reponse = new ServiceReponse<List<GetAY>>();
            var dataDelete = await _dataContext.AcademicYear.FirstOrDefaultAsync(x => x.YearId == year);
            if (dataDelete is null) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Cannot find ID year";
            }
            _dataContext.AcademicYear.Remove(dataDelete);
            await _dataContext.SaveChangesAsync();
            //get all data after delete
            reponse.Data = (await _dataContext.AcademicYear.ToListAsync()).Select(x => _mapper.Map<GetAY>(x)).ToList();
            reponse.Success = true;
            reponse.Message = "Delete Success";
            return reponse;
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
            catch (Exception ex) {
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
                var data = await _dataContext.AcademicYear.ToListAsync();

                // Ghi log dữ liệu
                foreach (var year in data)
                {
                    Console.WriteLine($"YearId: {year.YearId}, YearName: {year.YearName}");
                }
                reponse.Data = (await _dataContext.AcademicYear.ToListAsync()).Select(x => _mapper.Map<GetAY>(x)).ToList();
                reponse.Success = true;
                reponse.Message = "Get Success";
                return reponse;
            }
            catch (Exception ex) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = ex.Message;
                return reponse;
            }

        }

        public Task<ServiceReponse<List<GetAY>>> UpdateAY(UpdateAY updateAY)
        {
            throw new NotImplementedException();
        }
    }
}
