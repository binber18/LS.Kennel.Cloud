using LS.Kennel.Cloud.Models;
using Microsoft.EntityFrameworkCore;

namespace LS.Kennel.Cloud.Repositories.EF.Implementations;

public class EfKennelRepository : IKennelRepository
{
    private readonly ApplicationDbContext _context;
    public EfKennelRepository(ApplicationDbContext context)
    {
        _context = context;

    }

    public async Task<IEnumerable<Models.Kennel>> GetAllAsync()
    {
        return await _context.Kennels.AsNoTracking().ToListAsync();
    }
    public async Task<Models.Kennel?> GetByIdAsync(Guid id)
    {
        return await _context.Kennels
                             .Include(k => k.Dogs)
                             .FirstOrDefaultAsync(k => k.Id == id);
    }
    public async Task<Models.Kennel> AddAsync(Models.Kennel entity)
    {
        _context.Kennels.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task<Models.Kennel> UpdateAsync(Models.Kennel entity)
    {
        _context.Kennels.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var kennelToDelete = await _context.Kennels.FindAsync(id);
        if (kennelToDelete is null)
            return false;

        _context.Kennels.Remove(kennelToDelete);
        var changedEntities = await _context.SaveChangesAsync();
        return changedEntities > 0;
    }
    public async Task<IEnumerable<Models.Kennel>> GetForUserAsync(string userId)
    {
        return await _context.KennelOwnerships
                             .Include(k => k.Kennel)
                             .Where(k => k.UserId == userId)
                             .Where(k => k.Kennel != null)
                             .Select(k => k.Kennel!)
                             .ToListAsync();
    }
    public async Task<bool> AddOwnerAsync(Guid kennelId, string ownerId)
    {
        var kennel = await _context.Kennels.FindAsync(kennelId);
        if (kennel is null)
            return false;
        kennel.Owners.Add(new KennelOwnership
        {
            KennelId = kennelId,
            UserId = ownerId,
        });
        await _context.SaveChangesAsync();

        return true;
    }
}