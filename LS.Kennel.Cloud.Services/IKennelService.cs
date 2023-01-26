using LS.Kennel.Cloud.Models.Requests;

namespace LS.Kennel.Cloud.Services;

public interface IKennelService
{
    Task<IEnumerable<Models.Kennel>> GetForUserAsync(string userId);
    Task<Guid> CreateAsync(CreateKennelRequest request, string ownerId);
    Task<Models.Kennel?> GetByIdAsync(Guid kennelId);
    Task<bool> AddOwnerAsync(Guid kennelId, string ownerId);
}