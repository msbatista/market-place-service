namespace WebApi.Modules.Extensions;

/// <summary>
/// Configure api versioning strategies.
/// </summary>
public static class ApiVersioningExtensions
{
    /// <summary>
    /// Registers API versioning strategy.
    /// </summary>
    /// <param name="services">Services collection.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddApiVersionStrategy(this IServiceCollection services)
    {   
        services.AddApiVersioning(options => 
        {
            options.ReportApiVersions = true;
        });

        services.AddVersionedApiExplorer(options => 
        {
            options.GroupNameFormat = "v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
}
