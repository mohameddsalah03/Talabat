using System.Linq.Expressions;
using Talabat.Core.Domain.Contracts;

namespace Talabat.Core.Domain.Specifications
{
    public abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; set; } = null;
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new(); 
        public Expression<Func<TEntity, object>>? OrderBy { get ; set; }
        public Expression<Func<TEntity, object>>? OrderByDesc { get  ; set ; }
        public int Skip { get ; set; }
        public int Take { get ; set; }
        public bool IsPaginationEnabled { get ; set; }

        protected BaseSpecifications()
        {
            
        }

        //For Where()
        protected BaseSpecifications(Expression<Func<TEntity, bool>> CriteriaExpression)
        {
            Criteria = CriteriaExpression;
        }

        // For GetProduct , So Criteria exit
        protected BaseSpecifications(TKey id)
        {
            Criteria = E => E.Id.Equals(id);
        }


        /// Methods To Using in Child classes like[ProductWithBrandAndCategorySpec]
        private protected virtual void AddIncludes()
        { }
        private protected virtual void AddOrderBy(Expression<Func<TEntity, object>>? OrderByExpression) 
        {
            OrderBy = OrderByExpression;
        }
        private protected virtual void AddOrderByDesc(Expression<Func<TEntity, object>>? OrderByDescExpression) 
        {
            OrderByDesc = OrderByDescExpression;
        }

        private protected void AddPagination(int skip, int take)
        {
            IsPaginationEnabled = true;
            Skip = skip;
            Take = take;
        }
        
    }
}
