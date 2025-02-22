namespace BankingCreditSystem.Application.Features.LoanTypes.Dtos.Requests;

public class UpdateLoanTypeRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public int MinTerm { get; set; }
    public int MaxTerm { get; set; }
    public decimal BaseInterestRate { get; set; }
    public bool IsActive { get; set; }
} 