using Application.UseCases.CreateCatalogItems;

namespace WebApi.Modules.Extensions;

/// <summary>
/// Use case extensions.
/// </summary>
public static class UseCaseExtensions
{
    /// <summary>
    /// Registers use cases as scoped services.
    /// </summary>
    /// <param name="services">Services collection.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICreateCatalogItemUseCase, CreateCatalogItemUseCase>();

        return services;
    }
}
