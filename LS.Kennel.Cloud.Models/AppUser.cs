using Microsoft.AspNetCore.Identity;

namespace LS.Kennel.Cloud.Models;

public class AppUser : IdentityUser
{
    public List<KennelOwnership> KennelOwnerships { get; set; } = new();
}