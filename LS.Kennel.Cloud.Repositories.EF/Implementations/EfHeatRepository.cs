using LS.Kennel.Cloud.Models;
using Microsoft.EntityFrameworkCore;

namespace LS.Kennel.Cloud.Repositories.EF.Implementations;

public class EfHeatRepository : IHeatRepository
{
    private readonly ApplicationDbContext _context;
    public EfHeatRepository(ApplicationDbContext context)
    {
        _context = context;

    }
    public async Task<Heat?> GetByIdAsync(Guid heatId)
    {
        return await _context.Heats
                             .Include(h => h.Dog)
                             .Include(h => h.ProgesteroneTests)
                             .FirstOrDefaultAsync(h => h.Id == heatId);
    }
    public async Task<bool> AddProgesteroneTestAsync(Guid heatId, ProgesteroneTest newTest)
    {
        var heat = await _context.Heats
                                 .Include(h => h.ProgesteroneTests)
                                 .FirstOrDefaultAsync(h => h.Id == heatId);
        if (heat is null)
            return false;
        heat.ProgesteroneTests.Add(newTest);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteProgesteroneTestAsync(Guid heatId, Guid id)
    {
        var testToDelete = await _context.ProgesteroneTests
                                         .FirstOrDefaultAsync(x => x.HeatId == heatId && x.Id == id);
        if (testToDelete is null)
            return false;

        _context.ProgesteroneTests.Remove(testToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}