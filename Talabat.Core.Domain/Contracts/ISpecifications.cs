using System.Linq.Expressions;

namespace Talabat.Core.Domain.Contracts
{
    public interface ISpecifications<TEntity,TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {

        public Expression<Func<TEntity,bool>>? Criteria { get; set; } //For Where --> p => p.Id = 1
        public List<Expression<Func<TEntity , object>>> Includes { get; set; } // for Navgiational property
    }
}
