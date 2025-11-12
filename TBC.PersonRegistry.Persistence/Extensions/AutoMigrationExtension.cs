using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TBC.PersonRegistry.Persistence.Extensions;

public static class AutoMigrationExtension
{
    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<DataContext>();

            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
                context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return app;
    }
}
