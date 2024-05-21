namespace Company;

/// <summary>
/// This exception is thrown if an entity is expected to be found but not found.
/// </summary>
[Serializable]
internal class EntityNotFoundException : Exception
{
    /// <summary>
    /// Type of the entity.
    /// </summary>
    public Type? EntityType { get; set; }

    /// <summary>
    /// Id of the Entity.
    /// </summary>
    public object? Id { get; set; }

    /// <summary>
    /// Creates a new <see cref="EntityNotFoundException"/> object.
    /// </summary>
    public EntityNotFoundException(Type type, object? id)
        : this(type, id, null)
    {

    }

    /// <summary>
    /// Creates a new <see cref="EntityNotFoundException"/> object.
    /// </summary>
    public EntityNotFoundException(Type type, object? id, Exception? innerException) : 
        base(id == null
                ? $"There is no such an entity given id. Entity type: {type.FullName}"
                : $"There is no such an entity. Entity type: {type.FullName}, id: {id}",
            innerException)
    {
        EntityType = type;
        Id = id;
    }
}