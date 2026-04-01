using ShedAndFed.ServiceContracts;
using ShedAndFed.ServiceContracts.DTOs.FeedingLogDTOs;

namespace ShedAndFed.Services;

public class FeedingLogService : IFeedingLogService
{
    public async Task<FeedingLogResponse> CreateAsync(CreateFeedingLogRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<FeedingLogResponse?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<FeedingLogResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<FeedingLogResponse?> UpdateAsync(UpdateFeedingLogRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}