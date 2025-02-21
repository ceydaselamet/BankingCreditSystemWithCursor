namespace BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;

public class UpdateCorporateCustomerRequest
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    public decimal AnnualTurnover { get; set; }
    public string CompanyType { get; set; } = default!;
} 