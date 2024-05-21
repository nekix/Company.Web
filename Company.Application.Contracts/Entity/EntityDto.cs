namespace Company.Entity;

[Serializable]
public class EntityDto<TKey> : IEntityDto<TKey>
{
    /// <summary>
    /// Id of the entity.
    /// </summary>
    public TKey Id { get; set; } = default!;
}