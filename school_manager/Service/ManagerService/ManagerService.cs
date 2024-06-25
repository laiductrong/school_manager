using AutoMapper;
using Microsoft.EntityFrameworkCore;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.ManagerDTO;
using school_manager.Models;

namespace school_manager.Service.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public ManagerService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetManager>>> AddManager(AddManager manager)
        {
            var response = new ServiceResponse<List<GetManager>>();

            try
            {
                var newManager = _mapper.Map<Manager>(manager);

                await _dataContext.Manager.AddAsync(newManager);
                await _dataContext.SaveChangesAsync();

                var managers = await _dataContext.Manager
                    .Include(m => m.Teacher) // Include related Teacher if needed
                        .ThenInclude(t => t.Subject)
                    .ToListAsync();

                response.Data = managers.Select(m => _mapper.Map<GetManager>(m)).ToList();
                response.Success = true;
                response.Message = "Add Manager Success";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error adding manager: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetManager>>> DeleteManager(int managerId)
        {
            var response = new ServiceResponse<List<GetManager>>();

            try
            {
                var managerToDelete = await _dataContext.Manager
                    .Include(m => m.Teacher) // Include related Teacher if needed
                    .FirstOrDefaultAsync(m => m.ManagerId == managerId);

                if (managerToDelete == null)
                {
                    response.Success = false;
                    response.Message = "Manager not found.";
                    return response;
                }

                _dataContext.Manager.Remove(managerToDelete);
                await _dataContext.SaveChangesAsync();

                var remainingManagers = await _dataContext.Manager
                    .Include(m => m.Teacher) // Include related Teacher if needed
                        .ThenInclude(t => t.Subject)
                    .ToListAsync();

                response.Data = remainingManagers.Select(m => _mapper.Map<GetManager>(m)).ToList();
                response.Success = true;
                response.Message = "Delete Manager Success";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error deleting manager: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<GetManager>> GetManager(int managerId)
        {
            var response = new ServiceResponse<GetManager>();

            try
            {
                var manager = await _dataContext.Manager
                    .Include(m => m.Teacher) // Include related Teacher if needed
                        .ThenInclude(t => t.Subject)
                    .FirstOrDefaultAsync(m => m.ManagerId == managerId);

                if (manager == null)
                {
                    response.Success = false;
                    response.Message = "Manager not found.";
                }
                else
                {
                    response.Data = _mapper.Map<GetManager>(manager);
                    response.Success = true;
                    response.Message = "Get Manager Success";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error retrieving manager: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetManager>>> GetManagers()
        {
            var response = new ServiceResponse<List<GetManager>>();

            try
            {
                var managers = await _dataContext.Manager
                    .Include(m => m.Teacher) // Include related Teacher if needed
                        .ThenInclude(t=>t.Subject)
                    .ToListAsync();

                response.Data = managers.Select(m => _mapper.Map<GetManager>(m)).ToList();
                response.Success = true;
                response.Message = "Get Managers Success";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error retrieving managers: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetManager>>> UpdateManager(UpdateManager manager)
        {
            var response = new ServiceResponse<List<GetManager>>();

            try
            {
                var managerToUpdate = await _dataContext.Manager
                    .FirstOrDefaultAsync(m => m.ManagerId == manager.ManagerId);

                if (managerToUpdate == null)
                {
                    response.Success = false;
                    response.Message = "Manager not found.";
                    return response;
                }

                managerToUpdate.TeacherId = manager.TeacherId;
                // Update other properties as needed

                _dataContext.Manager.Update(managerToUpdate);
                await _dataContext.SaveChangesAsync();

                var updatedManagers = await _dataContext.Manager
                    .Include(m => m.Teacher) // Include related Teacher if needed
                        .ThenInclude(t => t.Subject)
                    .ToListAsync();

                response.Data = updatedManagers.Select(m => _mapper.Map<GetManager>(m)).ToList();
                response.Success = true;
                response.Message = "Update Manager Success";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error updating manager: {ex.Message}";
            }

            return response;
        }
    }
}
