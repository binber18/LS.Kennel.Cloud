using LS.Kennel.Cloud.Models;

namespace LS.Kennel.Cloud.Repositories;

public interface IHeatRepository
{
    Task<Heat?> GetByIdAsync(Guid heatId);
    Task<bool> AddProgesteroneTestAsync(Guid heatId, ProgesteroneTest newTest);
    Task<bool> DeleteProgesteroneTestAsync(Guid heatId, Guid id);
}