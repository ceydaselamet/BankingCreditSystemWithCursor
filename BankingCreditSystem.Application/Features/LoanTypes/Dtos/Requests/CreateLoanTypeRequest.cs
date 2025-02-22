

namespace BankingCreditSystem.Application.Features.LoanTypes.Dtos.Requests;

public class CreateLoanTypeRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public CustomerType CustomerType { get; set; }
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public int MinTerm { get; set; }
    public int MaxTerm { get; set; }
    public decimal BaseInterestRate { get; set; }
    public Guid? ParentLoanTypeId { get; set; }
} 