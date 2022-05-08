using Application.Services;
using Domain;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Modules.Extensions;

/// <summary>
/// Register database services.
/// </summary>
public static class SqlServerExtensions
{
    /// <summary>
    /// Register Sql Server context and related services.
    /// </summary>
    /// <param name="services">Services collection.</param>
    /// <param name="configuration">SRepresents a set of key/value application configuration properties.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CatalogContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("CatalogDb");
            options.UseSqlServer(connectionString, options =>
            {
                options.EnableRetryOnFailure();
            });
            options.EnableSensitiveDataLogging(true);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICatalogItemRepository, CatalogItemRepository>();
        services.AddScoped<IEntityFactory, EntityFactory>();

        return services;
    }
}
