using LS.Kennel.Cloud.Models;
using LS.Kennel.Cloud.Models.Requests;

namespace LS.Kennel.Cloud.Services;

public interface IHeatService
{
    Task<Heat?> GetByIdAsync(Guid heatId);
    Task<bool> AddProgesteroneTestAsync(Guid heatId, CreateProgesteroneTestRequest newTest);
    Task<bool> DeleteProgesteroneTestAsync(Guid heatId, Guid id);
}