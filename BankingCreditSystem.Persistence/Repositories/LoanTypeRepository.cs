using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Persistence.Contexts;

namespace BankingCreditSystem.Persistence.Repositories;

public class LoanTypeRepository : EfRepositoryBase<LoanType, Guid, BankingCreditSystemDbContext>, ILoanTypeRepository
{
    public LoanTypeRepository(BankingCreditSystemDbContext context) : base(context)
    {
    }
} 