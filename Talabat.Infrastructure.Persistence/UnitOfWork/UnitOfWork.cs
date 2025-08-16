using System.Collections.Concurrent;
using Talabat.Core.Domain.Common;
using Talabat.Core.Domain.Contracts;
using Talabat.Infrastructure.Persistence.Data;
using Talabat.Infrastructure.Persistence.Repositories;

namespace Talabat.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _dbcontext;
        private readonly ConcurrentDictionary<string,object> _repository;
        public UnitOfWork(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
            _repository = new ConcurrentDictionary<string,object>();
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return (IGenericRepository<TEntity, TKey>) _repository.GetOrAdd(
                typeof(TEntity).Name, 
                new GenericRepository<TEntity, TKey>(_dbcontext)
                );

        }


        public async Task<int> CompleteAsync()
            => await _dbcontext.SaveChangesAsync();    

        public async ValueTask DisposeAsync()
            => await _dbcontext.DisposeAsync();

    }
}
