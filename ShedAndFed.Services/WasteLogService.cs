using ShedAndFed.ServiceContracts;
using ShedAndFed.ServiceContracts.DTOs.WasteLogDTOs;

namespace ShedAndFed.Services;

public class WasteLogService : IWasteLogService
{
    public async Task<WasteLogResponse> CreateAsync(CreateWasteLogRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<WasteLogResponse?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<WasteLogResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<WasteLogResponse?> UpdateAsync(UpdateWasteLogRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}