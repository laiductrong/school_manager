using AutoMapper;
using Microsoft.EntityFrameworkCore;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.AcademicYearDTO;
using school_manager.DTOs.ClassDTO;
using school_manager.Models;

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
        public async Task<ServiceReponse<List<GetClass>>> AddClass(AddClass addClass)
        {
            var reponse = new ServiceReponse<List<GetClass>>(); ;
            try
            {
                Class addC = new Class();
                addC.ClassName = addClass.ClassName;
                addC.TeacherId = addClass.TeacherId;
                addC.YearId = addClass.YearId;
                await _dataContext.Class.AddAsync(addC);
            }
            catch (Exception) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Error add Class";
            }
            try
            {
                reponse.Data = (await _dataContext.Class.ToListAsync()).Select(x => _mapper.Map<GetClass>(x)).ToList();
                reponse.Success = true;
                reponse.Message = "Add success Class";
                return reponse;
            }
            catch (Exception) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Add Class Success but Error Get Class";
                return reponse;
            }
        }

        public async Task<ServiceReponse<List<GetClass>>> DeleteClass(int classID)
        {
            var reponse = new ServiceReponse<List<GetClass>>();
            var dataDelete = await _dataContext.Class.FirstOrDefaultAsync(x => x.ClassId == classID);
            if (dataDelete is null) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Can not find Class";
                return reponse;
            }
            try
            {
                _dataContext.Class.Remove(dataDelete);
                await _dataContext.SaveChangesAsync();
                try
                {
                    reponse.Data = (await _dataContext.Class.ToListAsync()).Select(x => _mapper.Map<GetClass>(x)).ToList();
                    reponse.Success = true;
                    reponse.Message = "Add success Class";
                    return reponse;
                }
                catch (Exception)
                {
                    reponse.Data = null;
                    reponse.Success = false;
                    reponse.Message = "Delete Class Success but Error Get Class";
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

        public async Task<ServiceReponse<GetClass>> GetClass(int classID)
        {
            var reponse = new ServiceReponse<GetClass>();
            var dataFind = await _dataContext.Class
            .Include(c => c.AcademicYear) // Bao gồm thực thể AcademicYear
            .FirstOrDefaultAsync(x => x.ClassId == classID);
            if (dataFind is null)
            {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Can not find Class";
                return reponse;
            }
            reponse.Data = _mapper.Map<GetClass>(dataFind);
            reponse.Success = true;
            reponse.Message = "Find Success";
            return reponse;
        }

        public async Task<ServiceReponse<List<GetClass>>> GetClasss()
        {
            var reponse = new ServiceReponse<List<GetClass>>();
            try
            {
                var data = await _dataContext.Class.ToListAsync();
                reponse.Data = data.Select(x => _mapper.Map<GetClass>(x)).ToList();
                reponse.Success = true;
                reponse.Message = "Get Class Success";
                return reponse;
            }
            catch (Exception)
            {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Error Get Class";
                return reponse;
            }    
        }

        public async Task<ServiceReponse<List<GetClass>>> UpdateClass(UpdateClass updateClass)
        {
            var reponse = new ServiceReponse<List<GetClass>>();
            try
            {
                var data = (await _dataContext.Class.FirstOrDefaultAsync(x => x.YearId == updateClass.ClassId));
                if (data == null)
                {
                    reponse.Data = null;
                    reponse.Success = false;
                    reponse.Message = "Can not find Class";
                    return reponse;
                }
                try
                {
                    data.ClassName = updateClass.ClassName;
                    data.YearId = updateClass.YearId;
                    data.TeacherId = updateClass.TeacherId;
                    await _dataContext.SaveChangesAsync();
                    try
                    {
                        reponse.Data = (await _dataContext.Class.ToListAsync()).Select(x => _mapper.Map<GetClass>(x)).ToList();
                        reponse.Success = true;
                        reponse.Message = "Update Success";
                        return reponse;
                    }
                    catch (Exception)
                    {
                        reponse.Data = null;
                        reponse.Success = false;
                        reponse.Message = "Update success but error Get List Class";
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
                reponse.Message = "Error Class by ID";
                return reponse;
            }
        }
    }
}
