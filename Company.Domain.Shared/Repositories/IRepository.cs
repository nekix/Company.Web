using Company.Entity;

namespace Company.Repositories;

public interface IRepository<TEntity, TKey> 
    where TEntity : class, IEntity<TKey>
{
    /// <summary>
    /// Get not tracked entity.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get list of not tracked entities.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Find not tracked entity.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TEntity?> FindAsync(TKey id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Insert entity and save.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update entity and save
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete entity.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteAsync(TKey id, CancellationToken cancellationToken = default);
}
