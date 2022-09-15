using Domain;
using Domain.CatalogItems;
using Domain.ValueObject;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GetCatalogItemsByTypeAndBrand;

/// <summary>
/// GetCatalogItemsByTypeAndBrandUseCase.
/// </summary>
public class GetCatalogItemsByTypeAndBrandUseCase : IGetCatalogItemsByTypeAndBrandUseCase
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ILogger<GetCatalogItemsByTypeAndBrandUseCase> _logger;

    /// <summary>
    /// Initializes an instance of GetCatalogItemsByTypeAndBrandUseCase.
    /// </summary>
    /// <param name="catalogItemRepository"></param>
    /// <param name="logger"></param>
    public GetCatalogItemsByTypeAndBrandUseCase(
        ICatalogItemRepository catalogItemRepository, 
        ILogger<GetCatalogItemsByTypeAndBrandUseCase> logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<PaginatedItems<CatalogItem>> Execute(
        Guid typeId, 
        Guid brandId, 
        int pageSize = 10, 
        int pageIndex = 0)
    {
        _logger.LogInformation("Request items for parameters: TypeId: {typeId}, BrandId: {brandId}, PageSize: {pageSize}, PageIndex: {pageIndex}", typeId, brandId, pageSize, pageIndex);

        var catalogBrandId = new CatalogBrandId(brandId);
        var catalogTypeId = new CatalogTypeId(typeId);

        return await _catalogItemRepository
            .GetCatalogItemsByTypeAndBrand(
                catalogTypeId, 
                catalogBrandId, 
                Math.Min(pageSize, 5000), 
                pageIndex);
    }
}
