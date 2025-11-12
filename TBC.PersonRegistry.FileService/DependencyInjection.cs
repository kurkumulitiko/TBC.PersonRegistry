using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TBC.PersonRegistry.Application.Interfaces.Services;
namespace TBC.PersonRegistry.FileService.Implementations;


public static class DependencyInjection
{
    public static IServiceCollection AddFileServiceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFileService, FileService>(option => new FileService(configuration["Files:Address"]));

        return services;
    }
}



