using LS.Kennel.Cloud.Models;
using LS.Kennel.Cloud.Models.Requests;

namespace LS.Kennel.Cloud.Services;

public interface IDogService
{
    Task<Guid> CreateAsync(CreateDogRequest request, Guid kennelId);
    Task<Dog?> GetByIdAsync(Guid dogId);
    Task<Guid> AddHeatAsync(CreateHeatRequest createHeatRequest);
}