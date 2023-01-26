using LS.Kennel.Cloud.Models;
using LS.Kennel.Cloud.Models.Requests;
using LS.Kennel.Cloud.Repositories;

namespace LS.Kennel.Cloud.Services.Implementations;

public class KennelService : IKennelService
{
    private readonly IKennelRepository _kennelRepository;
    public KennelService(IKennelRepository kennelRepository)
    {
        _kennelRepository = kennelRepository;
    }

    public async Task<Guid> CreateAsync(CreateKennelRequest entity, string ownerId)
    {
        var kennelId = Guid.NewGuid();
        var kennel = new Models.Kennel
        {
            Id = kennelId,
            Name = entity.Name,
            Owners =
            {
                new KennelOwnership
                {
                    KennelId = kennelId,
                    UserId = ownerId,
                },
            },
        };

        var created = await _kennelRepository.AddAsync(kennel);

        return created.Id;
    }
    public async Task<bool> AddOwnerAsync(Guid kennelId, string ownerId)
    {
        return await _kennelRepository.AddOwnerAsync(kennelId, ownerId);
    }
    public async Task<Models.Kennel?> GetByIdAsync(Guid id)
    {
        return await _kennelRepository.GetByIdAsync(id);
    }
    public async Task<Models.Kennel?> UpdateAsync(Guid id, Models.Kennel entity)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty", nameof(id));
        if (id != entity.Id)
            throw new ArgumentException("Ids do not match");

        return await _kennelRepository.UpdateAsync(entity);
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _kennelRepository.DeleteAsync(id);
    }
    public async Task<IEnumerable<Models.Kennel>> GetForUserAsync(string userId)
    {
        return await _kennelRepository.GetForUserAsync(userId);
    }
}