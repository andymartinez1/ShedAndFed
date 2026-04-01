using ShedAndFed.ServiceContracts.DTOs.ShedLogDTOs;

namespace ShedAndFed.ServiceContracts;

public interface IShedLogService : ICrudService<CreateShedLogRequest, UpdateShedLogRequest, ShedLogResponse, int>
{
}