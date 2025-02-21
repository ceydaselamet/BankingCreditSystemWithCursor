namespace BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;

public class GetCorporateCustomerListResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public string CompanyRegistrationNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime EstablishmentDate { get; set; }
    public decimal AnnualTurnover { get; set; }
} 