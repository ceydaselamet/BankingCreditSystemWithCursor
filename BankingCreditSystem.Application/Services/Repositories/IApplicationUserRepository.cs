using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Services.Repositories;

public interface IApplicationUserRepository : IAsyncRepository<ApplicationUser, Guid>
{
} 