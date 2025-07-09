namespace codePuls.Domain.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
