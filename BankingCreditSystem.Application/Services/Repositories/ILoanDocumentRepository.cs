using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Services.Repositories;

public interface ILoanDocumentRepository : IAsyncRepository<LoanDocument, Guid>
{
} 