using LS.Kennel.Cloud.Models;
using LS.Kennel.Cloud.Models.Requests;
using LS.Kennel.Cloud.Repositories;

namespace LS.Kennel.Cloud.Services.Implementations;

public class DogService : IDogService
{
    private readonly IDogRepository _dogRepository;
    public DogService(IDogRepository dogRepository)
    {
        _dogRepository = dogRepository;

    }

    public Task<Guid> CreateAsync(CreateDogRequest request, Guid kennelId)
    {
        var dogToCreate = new Dog
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CallName = request.CallName,
            BirthDay = request.BirthDay,
            KennelId = kennelId,
        };
        
        return _dogRepository.CreateAsync(dogToCreate);
    }
    public async Task<Dog?> GetByIdAsync(Guid dogId)
    {
        return await _dogRepository.GetByIdAsync(dogId);
    }
    public async Task<Guid> AddHeatAsync(CreateHeatRequest createHeatRequest)
    {
        var heat = new Heat
        {
            Id = Guid.NewGuid(),
            Start = createHeatRequest.Start,
            DogId = createHeatRequest.DogId,
        };
        return await _dogRepository.AddHeatAsync(createHeatRequest.DogId, heat);
    }
}
