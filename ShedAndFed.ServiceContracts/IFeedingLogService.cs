using ShedAndFed.ServiceContracts.DTOs.FeedingLogDTOs;

namespace ShedAndFed.ServiceContracts;

public interface IFeedingLogService
    : ILogService<CreateFeedingLogRequest, UpdateFeedingLogRequest, FeedingLogResponse>
{
}