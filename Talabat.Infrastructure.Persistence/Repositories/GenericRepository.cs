using Talabat.Core.Domain.Common;
using Talabat.Core.Domain.Contracts;
using Talabat.Infrastructure.Persistence.Data;

namespace Talabat.Infrastructure.Persistence.Repositories
{
    internal class GenericRepository<TEntity, TKey>(StoreContext _dbContext) : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false)
            => withTracking? await _dbContext.Set<TEntity>().ToListAsync() 
            : await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<TEntity?> GetAsync(TKey id)
            => await _dbContext.Set<TEntity>().FindAsync(id);


        public async Task AddAsync(TEntity entity)
            => await _dbContext.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity)
            =>  _dbContext.Set<TEntity>().Remove(entity);


        public void Update(TEntity entity)
            =>  _dbContext.Set<TEntity>().Update(entity);

    }
}
