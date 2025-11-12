using Microsoft.EntityFrameworkCore;
using TBC.PersonRegistry.Application.Commons;


namespace TBC.PersonRegistry.Persistence.Extensions;

internal static class EfCoreExtensions
{
    public static async Task<Pagination<TEntity>> ToPaginatedAsync<TEntity>(this IQueryable<TEntity> source,
           int pageIndex,int pageSize,
           CancellationToken cancellationToken = default)
           where TEntity : class
    {
        var totalCount = await source.CountAsync(cancellationToken);

        var items = await source.Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync(cancellationToken);

        return new Pagination<TEntity>(items, totalCount, pageIndex, pageSize);
    }
}
