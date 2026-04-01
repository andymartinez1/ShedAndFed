using ShedAndFed.ServiceContracts.DTOs.FeedingLogDTOs;

namespace ShedAndFed.ServiceContracts;

public interface
    IFeedingLogService : ICrudService<CreateFeedingLogRequest, UpdateFeedingLogRequest, FeedingLogResponse, int>
{
}