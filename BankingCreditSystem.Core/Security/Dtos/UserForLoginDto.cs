namespace BankingCreditSystem.Core.Security.Dtos;

public class UserForLoginDto
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
} 