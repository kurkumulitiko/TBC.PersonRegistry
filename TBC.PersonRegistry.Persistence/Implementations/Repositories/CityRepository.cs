using TBC.PersonRegistry.Application.Interfaces.Repositories;
using TBC.PersonRegistry.Domain.Models;

namespace TBC.PersonRegistry.Persistence.Implementations.Repositories;

public class CityRepository : Repository<City>, ICityRepository
{
    public CityRepository(DataContext context) : base(context) { }
}

