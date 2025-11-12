namespace TBC.PersonRegistry.Domain.Basics;

public abstract class  AuditableEntity : BaseEntity<int>
{
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime? UpdatedAt { get; set; }
    public virtual DateTime? DeletedAt { get; set; }
}
