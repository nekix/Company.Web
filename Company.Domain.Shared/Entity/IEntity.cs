namespace Company.Entity;

/// <summary>
/// Defines an entity with a single primary key with "Id" property.
/// </summary>
/// <typeparam name="TKey"></typeparam>
public interface IEntity<TKey>
{
    /// <summary>
    /// Unique identifier for this entity.
    /// </summary>
    TKey Id { get; }
}
