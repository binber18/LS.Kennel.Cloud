using System.Security.Claims;

namespace LS.Kennel.Cloud.Helpers;

public static class ClaimsHelper
{
    public static string? GetUserId(this ClaimsPrincipal? user)
    {
        return user?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
    }
}