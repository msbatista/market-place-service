using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataAccess;

/// <summary>
/// ContextFactory.
/// </summary>
public sealed class ContextFactory : IDesignTimeDbContextFactory<CatalogContext>
{
    /// <summary>
    /// Initialize an instance of CatalogContext.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    /// <returns>CatalogContext.</returns>
    public CatalogContext CreateDbContext(string[] args)
    {
        string connectionString = ReadDefaultConnectionStringFromAppSettings();

        DbContextOptionsBuilder<CatalogContext> builder = new DbContextOptionsBuilder<CatalogContext>();

        builder.UseSqlServer(connectionString);
        builder.EnableSensitiveDataLogging();

        return new CatalogContext(builder.Options);
    }

    private static string ReadDefaultConnectionStringFromAppSettings()
    {
        string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json", true)
            .AddJsonFile($"appsettings.{environment}.json", true)
            .AddEnvironmentVariables()
            .Build();

        string connectionString = configuration.GetConnectionString("CatalogDb");
        
        return connectionString;
    }
}
