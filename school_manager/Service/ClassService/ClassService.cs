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
        public async Task<ServiceResponse<List<GetClass>>> AddClass(AddClass addClass)
        {
            var reponse = new ServiceResponse<List<GetClass>>(); ;
            try
            {
                Class addC = new Class();
                addC.ClassName = addClass.ClassName;
                addC.TeacherId = addClass.TeacherId;
                addC.AcademicYearYearId = addClass.YearId;
                await _dataContext.Class.AddAsync(addC);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception) {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Error add Class";
                return reponse ;
            }
            try
            {
                var dataClass = await _dataContext.Class.Include(x => x.AcademicYear).ToListAsync();
                reponse.Data = dataClass.Select(x => _mapper.Map<GetClass>(x)).ToList();
                reponse.Success = true;
                reponse.Message = "Add success Class";
                return reponse;
            }
            catch (Exception)
            {
                reponse.Data = null;
                reponse.Success = false;
                reponse.Message = "Add Class Success but Error Get Class";
                return reponse;
            }

        }

        public async Task<ServiceResponse<List<GetClass>>> DeleteClass(int classID)
        {
            var reponse = new ServiceResponse<List<GetClass>>();
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
                    var dataClass = await _dataContext.Class.Include(x => x.AcademicYear).ToListAsync();
                    reponse.Data = dataClass.Select(x => _mapper.Map<GetClass>(x)).ToList();
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

        public async Task<ServiceResponse<GetClass>> GetClass(int classID)
        {
            var reponse = new ServiceResponse<GetClass>();
            var dataFind = await _dataContext.Class
            .Include(x => x.AcademicYear)
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

        public async Task<ServiceResponse<List<GetClass>>> GetClasss()
        {
            var reponse = new ServiceResponse<List<GetClass>>();
            try
            {
                var data = await _dataContext.Class.Include(x=>x.AcademicYear).ToListAsync();
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
        public async Task<ServiceResponse<List<GetClass>>> GetClassByIdAY (int idAY)
        {
            var reponse = new ServiceResponse<List<GetClass>>();
            try
            {
                var classes = await _dataContext.Class.Include(c => c.AcademicYear).Where(x => x.AcademicYearYearId == idAY).ToListAsync();
                reponse.Data = classes.Select(c => _mapper.Map<GetClass>(c)).ToList();
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

        public async Task<ServiceResponse<List<GetClass>>> UpdateClass(UpdateClass updateClass)
        {
            var reponse = new ServiceResponse<List<GetClass>>();
            try
            {
                var data = (await _dataContext.Class.FirstOrDefaultAsync(x => x.ClassId == updateClass.ClassId));
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
                    data.AcademicYearYearId = updateClass.YearId;
                    data.TeacherId = updateClass.TeacherId;
                    await _dataContext.SaveChangesAsync();
                    try
                    {
                        var dataClass = await _dataContext.Class.Include(x => x.AcademicYear).ToListAsync();
                        reponse.Data = dataClass.Select(x => _mapper.Map<GetClass>(x)).ToList();
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
