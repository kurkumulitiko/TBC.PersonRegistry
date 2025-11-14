using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TBC.PersonRegistry.Application.Interfaces.Repositories;

namespace TBC.PersonRegistry.Persistence.Implementations;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{

    protected readonly DataContext context;
    public Repository(DataContext context) => this.context = context;


    public void Create(TEntity entity)
    {
        context.Add(entity);
    }
    public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(entity, cancellationToken).ConfigureAwait(false);
    }
    public virtual void Update(TEntity entity)
    {
        context.Update(entity);
    }
    public virtual void Delete(int id)
    {
        var entity = context.Set<TEntity>().Find(id);
        if (entity != null)
            context.Set<TEntity>().Remove(entity);
    }
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
    {
        return await context.Set<TEntity>().AnyAsync(where, cancellationToken).ConfigureAwait(false);
    }
}

