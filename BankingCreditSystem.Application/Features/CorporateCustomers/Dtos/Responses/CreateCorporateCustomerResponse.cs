namespace BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;

public class CreateCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = default!;
    public string TaxNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
} 