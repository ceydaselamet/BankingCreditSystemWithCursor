namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

public class AuthenticationException : Exception
{
    public AuthenticationException(string message) : base(message) { }
} 