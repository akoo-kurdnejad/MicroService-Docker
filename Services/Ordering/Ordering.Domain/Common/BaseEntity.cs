namespace Ordering.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CreatedByUserId { get; set; }
        public string CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? LastModifiedByUserId { get; set; }
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
