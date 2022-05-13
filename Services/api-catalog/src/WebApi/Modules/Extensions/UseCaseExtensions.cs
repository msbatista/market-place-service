using Application.UseCases.CreateCatalogItems;
using Application.UseCases.DeleteCatalogItem;
using Application.UseCases.GetCatalogBrands;
using Application.UseCases.GetCatalogItemById;
using Application.UseCases.GetCatalogItems;
using Application.UseCases.GetCatalogItemsByBrand;
using Application.UseCases.GetCatalogItemsByType;
using Application.UseCases.GetCatalogItemsByTypeAndBrand;
using Application.UseCases.GetCatalogItemsWithName;
using Application.UseCases.GetCatalogTypes;
using Application.UseCases.UpdateItem;

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
        services.AddScoped<IGetCatalogItemByIdUseCase, GetCatalogItemByIdUseCase>();
        services.AddScoped<IGetCatalogItemsByTypeAndBrandUseCase, GetCatalogItemsByTypeAndBrandUseCase>();
        services.AddScoped<IGetCatalogItemsWithNameUseCase, GetCatalogItemsWithNameUseCase>();
        services.AddScoped<IDeleteItemUseCase, DeleteItemUseCase>();
        services.AddScoped<IUpdateItemUseCase, UpdateItemUseCase>();
        services.AddScoped<IGetCatalogItemsUseCase, GetCatalogItemsUseCase>();
        services.AddScoped<IGetCatalogTypesUseCase, GetCatalogTypesUseCase>();
        services.AddScoped<IGetCatalogBrandsUseCase, GetCatalogBrandsUseCase>();
        services.AddScoped<IGetCatalogItemsByTypeUseCase, GetCatalogItemsByTypeUseCase>();
        services.AddScoped<IGetCatalogItemsByBrandUseCase, GetCatalogItemsByBrandUseCase>();

        return services;
    }
}
