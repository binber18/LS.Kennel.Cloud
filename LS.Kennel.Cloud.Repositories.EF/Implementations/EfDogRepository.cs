using LS.Kennel.Cloud.Models;
using Microsoft.EntityFrameworkCore;

namespace LS.Kennel.Cloud.Repositories.EF.Implementations;

public class EfDogRepository : IDogRepository
{
    private readonly ApplicationDbContext _context;

    public EfDogRepository(ApplicationDbContext context)
    {
        _context = context;

    }
    public async Task<Guid> CreateAsync(Dog dogToCreate)
    {
        var dog = await _context.Dogs.AddAsync(dogToCreate);
        await _context.SaveChangesAsync();
        return dog.Entity.Id;
    }
    public async Task<Dog?> GetByIdAsync(Guid dogId)
    {
        return await _context.Dogs
                             .Include(d => d.Heats)
                             .FirstOrDefaultAsync(d => d.Id == dogId);
    }
    public async Task<Guid> AddHeatAsync(Guid _, Heat heat)
    {
        _context.Heats.Add(heat);
        await _context.SaveChangesAsync();
        return heat.Id;
    }
}