using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Persistence.Contexts;

namespace BankingCreditSystem.Persistence.Repositories;

public class ApplicationUserRepository : EfRepositoryBase<ApplicationUser, Guid, BankingCreditSystemDbContext>, IApplicationUserRepository
{
    public ApplicationUserRepository(BankingCreditSystemDbContext context) : base(context)
    {
    }
} 