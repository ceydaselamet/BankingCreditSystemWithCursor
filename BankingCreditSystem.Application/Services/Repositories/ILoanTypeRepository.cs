using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Services.Repositories;

public interface ILoanTypeRepository : IAsyncRepository<LoanType, Guid>
{
} 