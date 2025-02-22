namespace BankingCreditSystem.Application.Features.LoanApplications.Constants;

public static class LoanApplicationMessages
{
    public const string ApplicationNotFound = "Loan application not found";
    public const string AmountOutOfRange = "Requested amount is out of allowed range";
    public const string TermOutOfRange = "Requested term is out of allowed range";
    public const string InvalidCustomerType = "Customer type does not match with loan type";
    public const string ApplicationAlreadyProcessed = "Application has already been processed";
} 