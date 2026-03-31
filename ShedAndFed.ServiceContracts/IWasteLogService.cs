using ShedAndFed.ServiceContracts.DTOs.WasteLogDTOs;

namespace ShedAndFed.ServiceContracts;

public interface IWasteLogService
    : ILogService<CreateWasteLogRequest, UpdateWasteLogRequest, WasteLogResponse>
{
}