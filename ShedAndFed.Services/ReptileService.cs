using Microsoft.Extensions.Logging;
using ShedAndFed.Data;
using ShedAndFed.ServiceContracts;
using ShedAndFed.ServiceContracts.DTOs.ReptileDTOs;

namespace ShedAndFed.Services;

public class ReptileService : IReptileService
{
    private readonly ReptileDbContext _context;
    private readonly ILogger<ReptileService> _logger;

    public ReptileService(ReptileDbContext context, ILogger<ReptileService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ReptileResponse> AddReptileAsync(AddReptileRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<ReptileResponse> GetReptileByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ReptileResponse>> GetAllReptilesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ReptileResponse> UpdateReptileAsync(UpdateReptileRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteReptileAsync(int id)
    {
        throw new NotImplementedException();
    }
}
