namespace Shared.DDD;

public interface IAggregate<T> : IAggregate, IEntity<T>
{
    // already inherits all necessary fields from IAggregate and IEntity<T>
}

public interface IAggregate : IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    IDomainEvent[] ClearDomainEvents();
}
