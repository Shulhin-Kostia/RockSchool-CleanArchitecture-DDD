namespace BuildingBlocks.Domain;

public abstract class Entity<T> : IEquatable<Entity<T>>
    where T : TypedIdValueBase
{
    public T Id { get; protected set; }

    private List<IDomainEvent>? _domainEvents;
    public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();

    protected Entity()
    {
        //For EF
    }

    protected Entity(T id)
    {
        Id = id;
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents ??= [];

        _domainEvents.Add(domainEvent);
    }

    protected void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }

    //---------------------------------------------------------------------------
    //                                  Utility
    //---------------------------------------------------------------------------

    public static bool operator ==(Entity<T> first, Entity<T> second) =>
        first is not null && second is not null && first.Equals(second);

    public static bool operator !=(Entity<T> first, Entity<T> second) =>
        !(first == second);

    public bool Equals(Entity<T>? entity)
    {
        if (entity is null || entity.GetType() != GetType())
            return false;

        return entity.Id == Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType() || obj is not Entity<T> entity)
            return false;

        return entity.Id == Id;
    }

    public override int GetHashCode() => Id.GetHashCode();
}
