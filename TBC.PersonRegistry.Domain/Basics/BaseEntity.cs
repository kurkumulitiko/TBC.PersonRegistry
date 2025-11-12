namespace TBC.PersonRegistry.Domain.Basics;
public abstract class BaseEntity<T>
{
    public virtual T Id { get; set; }

}

