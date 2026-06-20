using ShedAndFed.ServiceContracts.DTOs.GrowthLogDTOs;

namespace ShedAndFed.ServiceContracts;

public interface IGrowthLogService
    : ILogService<CreateGrowthLogRequest, UpdateGrowthLogRequest, GrowthLogResponse>
{
}