using Talabat.Core.Domain.Contracts.Persistence;

namespace Talabat.Core.Domain.Contracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {

        IGenericRepository<TEntity,TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseAuditableEntity<TKey>
            where TKey : IEquatable<TKey>;

        Task<int> CompleteAsync();

    }
}
