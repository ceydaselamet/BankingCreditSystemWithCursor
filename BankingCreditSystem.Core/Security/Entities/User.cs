using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Core.Security.Entities;

public class User : Entity<Guid>
{
    public string Email { get; set; } = default!;
    public byte[] PasswordSalt { get; set; } = default!;
    public byte[] PasswordHash { get; set; } = default!;
    public bool IsActive { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

    public User()
    {
        UserOperationClaims = new HashSet<UserOperationClaim>();
    }
} 