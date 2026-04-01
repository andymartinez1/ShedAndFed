using ShedAndFed.ServiceContracts.DTOs.WasteLogDTOs;

namespace ShedAndFed.ServiceContracts;

public interface IWasteLogService : ICrudService<CreateWasteLogRequest, UpdateWasteLogRequest, WasteLogResponse, int>
{
}