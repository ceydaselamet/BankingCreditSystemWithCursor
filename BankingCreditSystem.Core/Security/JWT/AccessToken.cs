namespace BankingCreditSystem.Core.Security.JWT;

public class AccessToken
{
    public string Token { get; set; } = default!;
    public DateTime Expiration { get; set; }
} 