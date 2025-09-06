namespace Talabat.Core.Domain.Common
{
    public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {

        // For Adminstration
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; } 
        public  string LastModifiedBy { get; set; } = null!;
        public DateTime LastModifiedOn { get; set; } 


    }
}
