using System.Linq.Expressions;
using Talabat.Core.Domain.Contracts;

namespace Talabat.Core.Domain.Specifications
{
    public abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; set; } = null;
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new(); // Instead Of Write It In Every ctor


        // For GetAllProducts , So Criteria null
        public BaseSpecifications()
        {
            // Criteria = null;
        }

        // For GetProduct , So Criteria exit
        public BaseSpecifications(TKey id)
        {
            Criteria = E => E.Id.Equals(id);
        }



    }
}
