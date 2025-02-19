namespace BankingCreditSystem.Domain.Entities;

public class CorporateCustomer : Customer
{
    public string CompanyName { get; set; } = default!;
    public string TaxNumber { get; set; } = default!;
    public string CompanyRegistrationNumber { get; set; } = default!;
    public DateTime EstablishmentDate { get; set; }
    public decimal AnnualTurnover { get; set; }
    public string CompanyType { get; set; } = default!;  // Limited, Corporation, etc.
    public string? TradeRegistryNumber { get; set; }
} 