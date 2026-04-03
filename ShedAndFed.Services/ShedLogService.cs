using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShedAndFed.Data;
using ShedAndFed.Entities;
using ShedAndFed.ServiceContracts;
using ShedAndFed.ServiceContracts.DTOs.ShedLogDTOs;

namespace ShedAndFed.Services;

public class ShedLogService : IShedLogService
{
    private readonly ReptileDbContext _context;
    private readonly ILogger<ShedLogService> _logger;

    public ShedLogService(ReptileDbContext context, ILogger<ShedLogService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ShedLogResponse> CreateAsync(CreateShedLogRequest request)
    {
        var shedLog = MapToShedLog(request);

        await _context.ShedLogs.AddAsync(shedLog);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while adding shed log.");
            return MapToShedLogResponse(shedLog);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while adding shed log.");
            return MapToShedLogResponse(shedLog);
        }

        _logger.LogInformation("Shed log with ID: {id} added.", shedLog.LogId);
        return MapToShedLogResponse(shedLog);
    }

    public async Task<ShedLogResponse?> GetByIdAsync(int id)
    {
        var shedLog = await _context
            .ShedLogs.AsNoTracking()
            .SingleOrDefaultAsync(s => s.LogId == id);

        if (shedLog is null)
            return null;

        return MapToShedLogResponse(shedLog);
    }

    public async Task<List<ShedLogResponse>> GetAllByReptileIdAsync(int reptileId)
    {
        var shedLogs = await _context
            .ShedLogs.AsNoTracking()
            .Where(s => s.ReptileId == reptileId)
            .ToListAsync();

        return shedLogs.Select(MapToShedLogResponse).ToList();
    }

    public async Task<ShedLogResponse?> UpdateAsync(UpdateShedLogRequest request)
    {
        var shedLog = await _context.ShedLogs.FindAsync(request.LogId);

        if (shedLog is null)
            return null;

        shedLog.Date = request.Date;
        shedLog.Notes = request.Notes;
        shedLog.ReptileId = request.ReptileId;
        shedLog.FullShed = request.CompleteShed;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while updating shed log.");
            return MapToShedLogResponse(shedLog);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while updating shed log.");
            return MapToShedLogResponse(shedLog);
        }

        _logger.LogInformation("Shed log with ID: {id} updated.", shedLog.LogId);
        return MapToShedLogResponse(shedLog);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var shedLog = await _context.ShedLogs.FindAsync(id);

        if (shedLog is null)
            return false;

        _context.ShedLogs.Remove(shedLog);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while deleting shed log.");
            return false;
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while deleting shed log.");
            return false;
        }

        _logger.LogInformation("Shed log with ID: {id} deleted.", id);
        return true;
    }

    private ShedLog MapToShedLog(CreateShedLogRequest request)
    {
        return new ShedLog
        {
            Date = request.Date,
            Notes = request.Notes,
            ReptileId = request.ReptileId,
            FullShed = request.CompleteShed,
        };
    }

    private ShedLogResponse MapToShedLogResponse(ShedLog shedLog)
    {
        return new ShedLogResponse
        {
            LogId = shedLog.LogId,
            Date = shedLog.Date,
            Notes = shedLog.Notes,
            ReptileId = shedLog.ReptileId,
            CompleteShed = shedLog.FullShed,
        };
    }
}
