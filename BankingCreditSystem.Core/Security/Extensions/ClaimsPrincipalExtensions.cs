using System.Security.Claims;

namespace BankingCreditSystem.Core.Security.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
        return result;
    }

    public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims(ClaimTypes.Role);
    }

    public static string? GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault();
    }
} 