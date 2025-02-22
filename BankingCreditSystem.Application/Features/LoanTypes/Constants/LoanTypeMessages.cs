namespace BankingCreditSystem.Application.Features.LoanTypes.Constants;

public static class LoanTypeMessages
{
    public const string LoanTypeNotFound = "Loan type not found";
    public const string LoanTypeAlreadyExists = "A loan type with this name already exists";
    public const string InvalidAmountRange = "Invalid amount range. Maximum amount must be greater than minimum amount";
    public const string InvalidTermRange = "Invalid term range. Maximum term must be greater than minimum term";
} 