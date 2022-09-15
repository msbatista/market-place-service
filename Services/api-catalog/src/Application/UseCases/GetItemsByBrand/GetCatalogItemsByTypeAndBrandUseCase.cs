using Domain;
using Domain.CatalogItems;
using Domain.ValueObject;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GetCatalogItemsByBrand;

/// <summary>
/// GetCatalogItemsByBrandUseCase.
/// </summary>
public class GetCatalogItemsByBrandUseCase : IGetCatalogItemsByBrandUseCase
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ILogger<GetCatalogItemsByBrandUseCase> _logger;

    /// <summary>
    /// Initializes an instance of GetCatalogItemsByBrandUseCase.
    /// </summary>
    /// <param name="catalogItemRepository"></param>
    /// <param name="logger"></param>
    public GetCatalogItemsByBrandUseCase(
        ICatalogItemRepository catalogItemRepository, 
        ILogger<GetCatalogItemsByBrandUseCase> logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<PaginatedItems<CatalogItem>> Execute(
        Guid brandId, 
        int pageSize = 10, 
        int pageIndex = 0)
    {
        _logger.LogInformation("Request items for parameters: BrandId: {brandId}, PageSize: {pageSize}, PageIndex: {pageIndex}", brandId, pageSize, pageIndex);

        var catalogBrandId = new CatalogBrandId(brandId);

        return await _catalogItemRepository
            .GetCatalogItemsByBrand(
                catalogBrandId, 
                Math.Min(pageSize, 5000), 
                pageIndex);
    }
}
