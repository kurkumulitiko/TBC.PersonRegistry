using System.Linq.Expressions;

namespace TBC.PersonRegistry.Application.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task Create(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(int id);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
}

