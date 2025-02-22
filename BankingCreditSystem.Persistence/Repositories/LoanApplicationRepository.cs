using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Persistence.Contexts;

namespace BankingCreditSystem.Persistence.Repositories;

public class LoanApplicationRepository : EfRepositoryBase<LoanApplication, Guid, BankingCreditSystemDbContext>, ILoanApplicationRepository
{
    public LoanApplicationRepository(BankingCreditSystemDbContext context) : base(context)
    {
    }
} 