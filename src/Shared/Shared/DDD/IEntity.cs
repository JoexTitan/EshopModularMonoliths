namespace Shared.DDD;

public interface IEntity<T> : IEntity
{
    public T Id { get; set; }
}

public interface IEntity
{
    public string CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}

