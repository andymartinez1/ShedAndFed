using ShedAndFed.ServiceContracts.DTOs.ReptileDTOs;

namespace ShedAndFed.ServiceContracts;

public interface IReptileService : ICrudService<CreateReptileRequest, UpdateReptileRequest, ReptileResponse, int>
{
    Task<List<ReptileResponse>> GetAllAsync();
}