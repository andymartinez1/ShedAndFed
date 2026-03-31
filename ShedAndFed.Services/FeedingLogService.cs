using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShedAndFed.Data;
using ShedAndFed.Entities;
using ShedAndFed.ServiceContracts;
using ShedAndFed.ServiceContracts.DTOs.FeedingLogDTOs;

namespace ShedAndFed.Services;

public class FeedingLogService : IFeedingLogService
{
    private readonly ReptileDbContext _context;
    private readonly ILogger<FeedingLogService> _logger;

    public FeedingLogService(ReptileDbContext context, ILogger<FeedingLogService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<FeedingLogResponse> CreateAsync(CreateFeedingLogRequest request)
    {
        var feedingLog = MapToFeedingLog(request);

        await _context.FeedingLogs.AddAsync(feedingLog);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while adding feeding log.");
            return MapToFeedingLogResponse(feedingLog);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while adding feeding log.");
            return MapToFeedingLogResponse(feedingLog);
        }

        _logger.LogInformation("Feeding log with ID: {id} added.", feedingLog.LogId);
        return MapToFeedingLogResponse(feedingLog);
    }

    public async Task<FeedingLogResponse?> GetByIdAsync(int id)
    {
        var feedingLog = await _context.FeedingLogs.AsNoTracking().SingleOrDefaultAsync(f => f.LogId == id);

        if (feedingLog is null) return null;

        return MapToFeedingLogResponse(feedingLog);
    }

    public async Task<List<FeedingLogResponse>> GetAllByReptileIdAsync(int reptileId)
    {
        var feedingLogs = await _context.FeedingLogs
            .AsNoTracking()
            .Where(f => f.ReptileId == reptileId)
            .ToListAsync();

        return feedingLogs.Select(MapToFeedingLogResponse).ToList();
    }

    public async Task<FeedingLogResponse?> UpdateAsync(UpdateFeedingLogRequest request)
    {
        var feedingLog = await _context.FeedingLogs.FindAsync(request.LogId);

        if (feedingLog is null) return null;

        feedingLog.Date = request.Date;
        feedingLog.Notes = request.Notes;
        feedingLog.ReptileId = request.ReptileId;
        feedingLog.FoodType = request.FoodType;
        feedingLog.Size = request.Size;
        feedingLog.WasEaten = request.WasEaten;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while updating feeding log.");
            return MapToFeedingLogResponse(feedingLog);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while updating feeding log.");
            return MapToFeedingLogResponse(feedingLog);
        }

        _logger.LogInformation("Feeding log with ID: {id} updated.", feedingLog.LogId);
        return MapToFeedingLogResponse(feedingLog);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var feedingLog = await _context.FeedingLogs.FindAsync(id);

        if (feedingLog is null) return false;

        _context.FeedingLogs.Remove(feedingLog);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while deleting feeding log.");
            return false;
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while deleting feeding log.");
            return false;
        }

        _logger.LogInformation("Feeding log with ID: {id} deleted.", id);
        return true;
    }

    private FeedingLog MapToFeedingLog(CreateFeedingLogRequest request)
    {
        return new FeedingLog
        {
            Date = request.Date,
            Notes = request.Notes,
            ReptileId = request.ReptileId,
            FoodType = request.FoodType,
            Size = request.Size,
            WasEaten = request.WasEaten
        };
    }

    private FeedingLogResponse MapToFeedingLogResponse(FeedingLog feedingLog)
    {
        return new FeedingLogResponse
        {
            LogId = feedingLog.LogId,
            Date = feedingLog.Date,
            Notes = feedingLog.Notes,
            ReptileId = feedingLog.ReptileId,
            FoodType = feedingLog.FoodType,
            Size = feedingLog.Size,
            WasEaten = feedingLog.WasEaten
        };
    }
}