namespace BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;

public class CreateCorporateCustomerRequest
{
    public string CompanyName { get; set; } = default!;
    public string TaxNumber { get; set; } = default!;
    public string CompanyRegistrationNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    public DateTime EstablishmentDate { get; set; }
    public decimal AnnualTurnover { get; set; }
    public string CompanyType { get; set; } = default!;
    public string? TradeRegistryNumber { get; set; }
} 