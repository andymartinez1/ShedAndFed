using ShedAndFed.ServiceContracts.DTOs.ReptileDTOs;

namespace ShedAndFed.ServiceContracts;

public interface IReptileService
{
    Task<ReptileResponse> AddReptileAsync(AddReptileRequest request);

    Task<ReptileResponse> GetReptileByIdAsync(int id);

    Task<List<ReptileResponse>> GetAllReptilesAsync();

    Task<ReptileResponse> UpdateReptileAsync(UpdateReptileRequest request);

    Task<bool> DeleteReptileAsync(int id);
}
