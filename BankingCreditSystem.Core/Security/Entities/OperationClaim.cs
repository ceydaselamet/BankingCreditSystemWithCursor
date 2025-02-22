using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Core.Security.Entities;

public class OperationClaim : Entity<Guid>
{
    public string Name { get; set; } = default!;
} 