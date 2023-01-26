using LS.Kennel.Cloud.Models;

namespace LS.Kennel.Cloud.Repositories;

public interface IDogRepository
{
    Task<Guid> CreateAsync(Dog dogToCreate);
    Task<Dog?> GetByIdAsync(Guid dogId);
    Task<Guid> AddHeatAsync(Guid dogId, Heat heat);
}