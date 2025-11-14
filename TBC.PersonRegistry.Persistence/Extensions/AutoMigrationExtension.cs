using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TBC.PersonRegistry.Persistence.Extensions;

public static class AutoMigrationExtension
{
    /// <summary>
    /// auto migrate database
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;

        var logger = services.GetRequiredService<ILogger<DataContext>>();


        try
        {
            logger.LogInformation("Starting database migration...");

            var context = services.GetRequiredService<DataContext>();

            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
                context.SaveChanges();
            }

            logger.LogInformation("Database migration completed successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred during database migration.");
            throw;
        }

        return app;
    }
}
