namespace Company.Entity;

public interface IEntityDto<TKey>
{
    TKey Id { get; set; }
}