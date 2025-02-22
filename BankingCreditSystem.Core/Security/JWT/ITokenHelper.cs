using BankingCreditSystem.Core.Security.Entities;

namespace BankingCreditSystem.Core.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);
} 