using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Persistence.Contexts;

namespace BankingCreditSystem.Persistence.Repositories;

public class LoanDocumentRepository : EfRepositoryBase<LoanDocument, Guid, BankingCreditSystemDbContext>, ILoanDocumentRepository
{
    public LoanDocumentRepository(BankingCreditSystemDbContext context) : base(context)
    {
    }
} 