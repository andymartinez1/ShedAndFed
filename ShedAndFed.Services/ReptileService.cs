using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShedAndFed.Data;
using ShedAndFed.Entities;
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

    public async Task<ReptileResponse> CreateAsync(AddReptileRequest request)
    {
        var reptile = MapToReptile(request);

        await _context.Reptiles.AddAsync(reptile);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while adding reptile.");
            return MapToReptileResponse(reptile);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while adding reptile.");
            return MapToReptileResponse(reptile);
        }

        _logger.LogInformation("Reptile with ID: {id} added.", reptile.ReptileId);
        return MapToReptileResponse(reptile);
    }

    public async Task<ReptileResponse?> GetByIdAsync(int id)
    {
        var reptile = await _context.Reptiles.AsNoTracking().SingleOrDefaultAsync(r => r.ReptileId == id);

        if (reptile is null) return null;

        return MapToReptileResponse(reptile);
    }

    public async Task<List<ReptileResponse>> GetAllAsync()
    {
        var reptiles = await _context.Reptiles.AsNoTracking().ToListAsync();

        return reptiles.Select(MapToReptileResponse).ToList();
    }

    public async Task<ReptileResponse?> UpdateAsync(UpdateReptileRequest request)
    {
        var reptile = await _context.Reptiles.FindAsync(request.ReptileId);

        if (reptile is null) return null;

        reptile.Name = request.Name;
        reptile.Species = request.Species;
        reptile.Morph = request.Morph;
        reptile.Sex = request.Sex;
        reptile.DateOfBirth = request.DateOfBirth;
        reptile.AcquiredDate = request.AcquiredDate;
        reptile.WeightGrams = request.WeightGrams;
        reptile.LengthCm = request.LengthCm;
        reptile.IsAlive = request.IsAlive;
        reptile.Notes = request.Notes;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while updating reptile.");
            return MapToReptileResponse(reptile);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while updating reptile.");
            return MapToReptileResponse(reptile);
        }

        _logger.LogInformation("Reptile with ID: {id} updated.", reptile.ReptileId);
        return MapToReptileResponse(reptile);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var reptile = await _context.Reptiles.FindAsync(id);

        if (reptile is null) return false;

        _context.Reptiles.Remove(reptile);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogWarning(e, "Concurrency conflict while updating reptile.");
            return false;
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Database update failed while updating reptile.");
            return false;
        }

        _logger.LogInformation("Reptile with ID: {id} deleted.", reptile.ReptileId);
        return true;
    }

    private Reptile MapToReptile(AddReptileRequest reptileRequest)
    {
        return new Reptile
        {
            Name = reptileRequest.Name,
            Species = reptileRequest.Species,
            Morph = reptileRequest.Morph,
            Sex = reptileRequest.Sex,
            DateOfBirth = reptileRequest.DateOfBirth,
            AcquiredDate = reptileRequest.AcquiredDate,
            WeightGrams = reptileRequest.WeightGrams,
            LengthCm = reptileRequest.LengthCm,
            IsAlive = reptileRequest.IsAlive,
            Notes = reptileRequest.Notes
        };
    }

    private ReptileResponse MapToReptileResponse(Reptile reptile)
    {
        return new ReptileResponse
        {
            ReptileId = reptile.ReptileId,
            Name = reptile.Name,
            Species = reptile.Species,
            Morph = reptile.Morph,
            Sex = reptile.Sex,
            DateOfBirth = reptile.DateOfBirth,
            AcquiredDate = reptile.AcquiredDate,
            WeightGrams = reptile.WeightGrams,
            LengthCm = reptile.LengthCm,
            IsAlive = reptile.IsAlive,
            Notes = reptile.Notes
        };
    }
}