using TBC.PersonRegistry.Application.Interfaces;
using TBC.PersonRegistry.Application.Interfaces.Repositories;
using TBC.PersonRegistry.Persistence.Implementations.Repositories;

namespace TBC.PersonRegistry.Persistence.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private ICityRepository cityRepository;
    private IPersonRepository personRepository;

    private DataContext context;
    public UnitOfWork(DataContext context) => this.context = context;

    public ICityRepository CityRepository => cityRepository ??= new CityRepository(context);
    public IPersonRepository PersonRepository => personRepository ??= new PersonRepository(context);

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}

