namespace Talabat.Core.Domain.Common
{
    public abstract class BaseEntity<TKey> where TKey :  IEquatable<TKey>
    {
        public required TKey Id { get; set; }

        // For Adminstration
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow; // Instead Of This will using Interceptor
        public required string LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; } = DateTime.UtcNow; // Instead Of This will using Interceptor


    }
}
