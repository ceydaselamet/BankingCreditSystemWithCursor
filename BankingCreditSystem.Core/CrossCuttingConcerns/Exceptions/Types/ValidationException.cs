namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

public class ValidationException : Exception
{
    public IEnumerable<ValidationExceptionModel> Errors { get; }

    public ValidationException(IEnumerable<ValidationExceptionModel> errors) : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }

    private static string BuildErrorMessage(IEnumerable<ValidationExceptionModel> errors)
    {
        return $"Validation failed: {string.Join(", ", errors.Select(x => x.Message))}";
    }
}

public class ValidationExceptionModel
{
    public string Property { get; set; }
    public string Message { get; set; }

    public ValidationExceptionModel(string property, string message)
    {
        Property = property;
        Message = message;
    }
} 