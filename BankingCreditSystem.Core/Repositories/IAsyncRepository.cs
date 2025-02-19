using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace BankingCreditSystem.Core.Repositories;

public interface IAsyncRepository<T, TId> where T : Entity<TId>
{
    Task<T?> GetAsync(TId id, CancellationToken cancellationToken = default);
    
    Task<IPaginate<T>> GetListAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        PaginationParams? pagination = null,
        CancellationToken cancellationToken = default
    );

    Task<bool> AnyAsync(
        Expression<Func<T, bool>>? predicate = null,
        CancellationToken cancellationToken = default
    );

    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    
    Task<ICollection<T>> AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken = default);
    
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    
    Task<ICollection<T>> UpdateRangeAsync(ICollection<T> entities, CancellationToken cancellationToken = default);
    
    Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);
    
    Task<ICollection<T>> DeleteRangeAsync(ICollection<T> entities, CancellationToken cancellationToken = default);
} 