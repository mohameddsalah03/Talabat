﻿namespace Talabat.Core.Domain.Contracts.Persistence
{
    public interface IGenericRepository<TEntity,TKey>  
        where TEntity : BaseEntity<TKey>    
        where TKey : IEquatable<TKey>
    {

        Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false);
        Task<IEnumerable<TEntity>> GetAllWithSpecAsync( ISpecifications<TEntity,TKey> spec, bool withTracking = false);
        Task<TEntity?> GetWithSpecAsync(ISpecifications<TEntity, TKey> spec);
        Task<int> GetCountAsync(ISpecifications<TEntity, TKey> spec);
        Task<TEntity?> GetAsync(TKey id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
