namespace BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;

public class UpdateCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime UpdatedDate { get; set; }
} 