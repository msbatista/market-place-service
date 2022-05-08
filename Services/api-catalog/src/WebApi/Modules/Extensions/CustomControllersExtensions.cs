using WebApi.Modules.Filters;

namespace WebApi.Modules.Extensions;

/// <summary>
/// Controllers extensions.
/// </summary>
public static class CustomControllersExtensions
{
    /// <summary>
    /// Register controllers and its configurations.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCustomControllers(this IServiceCollection services)
    {
        services
            .AddMvcCore(options => 
            {
                options.Filters.Add(typeof(DomainExceptionFilter));
                options.Filters.Add(typeof(InternalExceptionFilter));
                options.Filters.Add(typeof(ObjectNotFoundExceptionFilter));
            })
            .AddJsonOptions(options => 
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.AllowInputFormatterExceptionMessages = true;
            });

        services.Configure<RouteOptions>(options => 
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });

        return services;
    }
}
