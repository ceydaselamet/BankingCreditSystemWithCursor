public class CreateLoanApplicationRequest
{
    public Guid CustomerId { get; set; }
    public Guid LoanTypeId { get; set; }
    public decimal RequestedAmount { get; set; }
    public int RequestedTerm { get; set; }
} 