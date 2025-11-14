using System.Linq.Expressions;

namespace TBC.PersonRegistry.Application.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    void Create(TEntity entity);
    Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

    void Update(TEntity entity);
    void Delete(int id);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
}

