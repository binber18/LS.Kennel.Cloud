namespace LS.Kennel.Cloud.Models;

public class KennelOwnership : Entity
{
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
    
    public Guid KennelId { get; set; }
    public Kennel? Kennel { get; set; }
}