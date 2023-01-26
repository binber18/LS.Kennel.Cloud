namespace LS.Kennel.Cloud.Repositories;

public interface IKennelRepository : IBaseRepository<Models.Kennel>
{
    Task<IEnumerable<Models.Kennel>> GetForUserAsync(string userId);
    Task<bool> AddOwnerAsync(Guid kennelId, string ownerId);
}