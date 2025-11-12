using Mapster;
using Microsoft.Extensions.DependencyInjection;


namespace TBC.PersonRegistry.Application.Commons.Mappings;

public static class MapperConfig
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Default.MapToConstructor(true);

       

    }
}

