namespace BankingCreditSystem.Core.Security.Dtos;

public class UserForRegisterDto
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
} 