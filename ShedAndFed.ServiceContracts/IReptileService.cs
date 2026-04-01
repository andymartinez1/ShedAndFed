using ShedAndFed.ServiceContracts.DTOs.ReptileDTOs;

namespace ShedAndFed.ServiceContracts;

public interface IReptileService : ICrudService<AddReptileRequest, UpdateReptileRequest, ReptileResponse, int>
{
}