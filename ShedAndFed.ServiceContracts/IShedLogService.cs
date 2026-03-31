using ShedAndFed.ServiceContracts.DTOs.ShedLogDTOs;

namespace ShedAndFed.ServiceContracts;

public interface IShedLogService
    : ILogService<CreateShedLogRequest, UpdateShedLogRequest, ShedLogResponse>
{
}