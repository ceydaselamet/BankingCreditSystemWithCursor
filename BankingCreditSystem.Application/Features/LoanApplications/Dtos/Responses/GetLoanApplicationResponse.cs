namespace BankingCreditSystem.Application.Features.LoanApplications.Dtos.Responses;

public class GetLoanApplicationResponse
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; } = default!;
    public string LoanTypeName { get; set; } = default!;
    public decimal RequestedAmount { get; set; }
    public int RequestedTerm { get; set; }
    public decimal InterestRate { get; set; }
    public decimal MonthlyPayment { get; set; }
    public decimal TotalPayment { get; set; }
    public LoanApplicationStatus Status { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime CreatedDate { get; set; }
} 