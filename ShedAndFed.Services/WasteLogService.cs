using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShedAndFed.Data;
using ShedAndFed.Entities;
using ShedAndFed.ServiceContracts;
using ShedAndFed.ServiceContracts.DTOs.WasteLogDTOs;

namespace ShedAndFed.Services;

public class WasteLogService : IWasteLogService
{
    private readonly ReptileDbContext _context;
    private readonly ILogger<WasteLogService> _logger;

    public WasteLogService(ReptileDbContext context, ILogger<WasteLogService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<WasteLogResponse> CreateAsync(CreateWasteLogRequest request)
    {
        var wasteLog = MapToWasteLog(request);

        await _context.WasteLogs.AddAsync(wasteLog);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while adding waste log.");
            return MapToWasteLogResponse(wasteLog);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while adding waste log.");
            return MapToWasteLogResponse(wasteLog);
        }

        _logger.LogInformation("Waste log with ID: {id} added.", wasteLog.LogId);
        return MapToWasteLogResponse(wasteLog);
    }

    public async Task<WasteLogResponse?> GetByIdAsync(int id)
    {
        var wasteLog = await _context.WasteLogs.AsNoTracking().SingleOrDefaultAsync(w => w.LogId == id);

        if (wasteLog is null) return null;

        return MapToWasteLogResponse(wasteLog);
    }

    public async Task<List<WasteLogResponse>> GetAllByReptileIdAsync(int reptileId)
    {
        var wasteLogs = await _context.WasteLogs
            .AsNoTracking()
            .Where(w => w.ReptileId == reptileId)
            .ToListAsync();

        return wasteLogs.Select(MapToWasteLogResponse).ToList();
    }

    public async Task<WasteLogResponse?> UpdateAsync(UpdateWasteLogRequest request)
    {
        var wasteLog = await _context.WasteLogs.FindAsync(request.LogId);

        if (wasteLog is null) return null;

        wasteLog.Date = request.Date;
        wasteLog.Notes = request.Notes;
        wasteLog.ReptileId = request.ReptileId;
        wasteLog.Type = request.Type.ToString();

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while updating waste log.");
            return MapToWasteLogResponse(wasteLog);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while updating waste log.");
            return MapToWasteLogResponse(wasteLog);
        }

        _logger.LogInformation("Waste log with ID: {id} updated.", wasteLog.LogId);
        return MapToWasteLogResponse(wasteLog);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var wasteLog = await _context.WasteLogs.FindAsync(id);

        if (wasteLog is null) return false;

        _context.WasteLogs.Remove(wasteLog);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while deleting waste log.");
            return false;
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while deleting waste log.");
            return false;
        }

        _logger.LogInformation("Waste log with ID: {id} deleted.", id);
        return true;
    }

    private WasteLog MapToWasteLog(CreateWasteLogRequest request)
    {
        return new WasteLog
        {
            Date = request.Date,
            Notes = request.Notes,
            ReptileId = request.ReptileId,
            Type = request.Type.ToString()
        };
    }

    private WasteLogResponse MapToWasteLogResponse(WasteLog wasteLog)
    {
        return new WasteLogResponse
        {
            LogId = wasteLog.LogId,
            Date = wasteLog.Date,
            Notes = wasteLog.Notes,
            ReptileId = wasteLog.ReptileId,
            Type = wasteLog.Type
        };
    }
}