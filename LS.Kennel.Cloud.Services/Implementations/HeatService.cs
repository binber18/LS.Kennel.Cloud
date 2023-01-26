using LS.Kennel.Cloud.Models;
using LS.Kennel.Cloud.Models.Requests;
using LS.Kennel.Cloud.Repositories;

namespace LS.Kennel.Cloud.Services.Implementations;

public class HeatService : IHeatService
{
    private readonly IHeatRepository _heatRepository;
    public HeatService(IHeatRepository heatRepository)
    {
        _heatRepository = heatRepository;

    }
    
    public Task<Heat?> GetByIdAsync(Guid heatId)
    {
        return _heatRepository.GetByIdAsync(heatId);
    }
    public async Task<bool> AddProgesteroneTestAsync(Guid heatId, CreateProgesteroneTestRequest newTest)
    {
        var testToCreate = new ProgesteroneTest
        {
            TestTime = newTest.TestTime,
            Value = newTest.Value,
        };
        
        return await _heatRepository.AddProgesteroneTestAsync(heatId, testToCreate);
    }
    public async Task<bool> DeleteProgesteroneTestAsync(Guid heatId, Guid id)
    {
        return await _heatRepository.DeleteProgesteroneTestAsync(heatId, id);
    }
}
