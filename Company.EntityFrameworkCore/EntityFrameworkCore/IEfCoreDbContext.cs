using Company.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Company.EntityFrameworkCore;

public interface IEfCoreDbContext<TEntity, TKey> : IDisposable
    where TEntity : class, IEntity<TKey>
{
    DbSet<TEntity> Set();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    EntityEntry<TEntity> Update(TEntity entity);
}
