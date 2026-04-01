using ShedAndFed.ServiceContracts;
using ShedAndFed.ServiceContracts.DTOs.ShedLogDTOs;

namespace ShedAndFed.Services;

public class ShedLogService : IShedLogService
{
    public async Task<ShedLogResponse> CreateAsync(CreateShedLogRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<ShedLogResponse?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ShedLogResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ShedLogResponse?> UpdateAsync(UpdateShedLogRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}