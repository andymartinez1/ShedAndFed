using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShedAndFed.Data;
using ShedAndFed.Entities;
using ShedAndFed.ServiceContracts;
using ShedAndFed.ServiceContracts.DTOs.GrowthLogDTOs;

namespace ShedAndFed.Services;

public class GrowthLogService : IGrowthLogService
{
    private readonly ReptileDbContext _context;
    private readonly ILogger<GrowthLogService> _logger;

    public GrowthLogService(ReptileDbContext context, ILogger<GrowthLogService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<GrowthLogResponse> CreateAsync(CreateGrowthLogRequest request)
    {
        var growthLog = MapToGrowthLog(request);

        await _context.GrowthLogs.AddAsync(growthLog);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while adding growth log.");
            return MapToGrowthLogResponse(growthLog);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while adding growth log.");
            return MapToGrowthLogResponse(growthLog);
        }

        _logger.LogInformation("Growth log with ID: {id} added.", growthLog.LogId);
        return MapToGrowthLogResponse(growthLog);
    }

    public async Task<GrowthLogResponse?> GetByIdAsync(int id)
    {
        var growthLog = await _context.GrowthLogs.AsNoTracking().SingleOrDefaultAsync(g => g.LogId == id);

        if (growthLog is null) return null;

        return MapToGrowthLogResponse(growthLog);
    }

    public async Task<List<GrowthLogResponse>> GetAllByReptileIdAsync(int reptileId)
    {
        var growthLogs = await _context.GrowthLogs
            .AsNoTracking()
            .Where(g => g.ReptileId == reptileId)
            .ToListAsync();

        return growthLogs.Select(MapToGrowthLogResponse).ToList();
    }

    public async Task<GrowthLogResponse?> UpdateAsync(UpdateGrowthLogRequest request)
    {
        var growthLog = await _context.GrowthLogs.FindAsync(request.LogId);

        if (growthLog is null) return null;

        growthLog.Date = request.Date;
        growthLog.Notes = request.Notes;
        growthLog.ReptileId = request.ReptileId;
        growthLog.WeightGrams = request.WeightGrams;
        growthLog.LengthCm = request.LengthCm;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while updating growth log.");
            return MapToGrowthLogResponse(growthLog);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while updating growth log.");
            return MapToGrowthLogResponse(growthLog);
        }

        _logger.LogInformation("Growth log with ID: {id} updated.", growthLog.LogId);
        return MapToGrowthLogResponse(growthLog);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var growthLog = await _context.GrowthLogs.FindAsync(id);

        if (growthLog is null) return false;

        _context.GrowthLogs.Remove(growthLog);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while deleting growth log.");
            return false;
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while deleting growth log.");
            return false;
        }

        _logger.LogInformation("Growth log with ID: {id} deleted.", id);
        return true;
    }

    private GrowthLog MapToGrowthLog(CreateGrowthLogRequest request)
    {
        return new GrowthLog
        {
            Date = request.Date,
            Notes = request.Notes,
            ReptileId = request.ReptileId,
            WeightGrams = request.WeightGrams,
            LengthCm = request.LengthCm
        };
    }

    private GrowthLogResponse MapToGrowthLogResponse(GrowthLog growthLog)
    {
        return new GrowthLogResponse
        {
            LogId = growthLog.LogId,
            Date = growthLog.Date,
            Notes = growthLog.Notes,
            ReptileId = growthLog.ReptileId,
            WeightGrams = growthLog.WeightGrams,
            LengthCm = growthLog.LengthCm
        };
    }
}