using Company.Repositories;
using Company.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Company.Entity;

namespace Company;

public class EfCoreRepository<TDbContext, TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TDbContext : IEfCoreDbContext<TEntity, TKey>
{
    protected TDbContext DbContext { get; }
    protected DbSet<TEntity> EntityDbSet { get; }

    public EfCoreRepository(TDbContext context)
    {
        DbContext = context;
        EntityDbSet = context.Set();
    }

    /// <inheritdoc />
    public Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var entity = FindAsync(id, cancellationToken);

        if (entity == null)
        {
            throw new EntityNotFoundException(typeof(TEntity), id);
        }

        return entity!;
    }

    /// <inheritdoc />
    public Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return EntityDbSet.ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TEntity?> FindAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await EntityDbSet.FindAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var savedEntity = (await EntityDbSet.AddAsync(entity, cancellationToken: cancellationToken)).Entity;

        await DbContext.SaveChangesAsync(cancellationToken);

        return savedEntity;
    }

    /// <inheritdoc />
    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (EntityDbSet.Local.All(e => e != entity))
        {
            EntityDbSet.Attach(entity);
            DbContext.Update(entity);
        }

        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    /// <inheritdoc />
    public async Task DeleteAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var entity = await FindAsync(id, cancellationToken);
        if (entity == null)
        {
            return;
        }

        EntityDbSet.Remove(entity);

        await DbContext.SaveChangesAsync(cancellationToken);
    }
}