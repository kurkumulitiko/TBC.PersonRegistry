using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TBC.PersonRegistry.Application.Interfaces;
using TBC.PersonRegistry.Persistence.Implementations;

namespace TBC.PersonRegistry.Persistence;

public static class DependencyInjection
{
    public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("PersonDbConnection")));
    }
}

