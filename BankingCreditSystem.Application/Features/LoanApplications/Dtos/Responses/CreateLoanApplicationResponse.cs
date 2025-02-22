public class CreateLoanApplicationResponse
{
    public Guid Id { get; set; }
    public decimal RequestedAmount { get; set; }
    public int RequestedTerm { get; set; }
    public decimal InterestRate { get; set; }
    public decimal MonthlyPayment { get; set; }
    public decimal TotalPayment { get; set; }
    public LoanApplicationStatus Status { get; set; }
} 