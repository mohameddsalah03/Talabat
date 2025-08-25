using Talabat.Core.Domain.Common;
using Talabat.Core.Domain.Contracts;

namespace Talabat.Infrastructure.Persistence.Repositories.GenericRepository
{
    public static class SpecificationsEvaluator<TEntity, TKey> 
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
      
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> dbset , ISpecifications<TEntity,TKey> spec)
        {
            var query = dbset; // _dbContext.Set<Product>();

            if(spec.Criteria is not null) // P => P.Id.Equals(1)
            {
                query = query.Where(spec.Criteria); // _dbContext.Set<Product>().Where(P => P.Id.Equals(1))
            }

            ///
            //Include Expressions
            // 1. P => P.Brand
            // 2. P => P.Category
            // ...

            query = spec.Includes.Aggregate(query, (CurrentQuery, IncludeExpression) =>
                CurrentQuery.Include(IncludeExpression)
            );

            //Final Result 
            // _dbContext.Set<Product>().Where(P => P.Id.Equals(1)).Include(P => P.Brand).Include(P => P.Category)

            return query;
        }
    }
}
