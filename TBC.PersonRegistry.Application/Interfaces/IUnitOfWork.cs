using TBC.PersonRegistry.Application.Interfaces.Repositories;

namespace TBC.PersonRegistry.Application.Interfaces;

public interface IUnitOfWork
{
    public IPersonRepository PersonRepository { get; }
    public ICityRepository CityRepository { get; }


    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}

