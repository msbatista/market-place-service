using Domain;
using Domain.CatalogItems;
using Domain.ValueObject;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GetCatalogItemsByType;

/// <summary>
/// GetCatalogItemsByTypeUseCase.
/// </summary>
public class GetCatalogItemsByTypeUseCase : IGetCatalogItemsByTypeUseCase
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ILogger<GetCatalogItemsByTypeUseCase> _logger;

    /// <summary>
    /// Initializes an instance of GetCatalogItemsByTypeUseCase.
    /// </summary>
    /// <param name="catalogItemRepository"></param>
    /// <param name="logger"></param>
    public GetCatalogItemsByTypeUseCase(
        ICatalogItemRepository catalogItemRepository, 
        ILogger<GetCatalogItemsByTypeUseCase> logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<PaginatedItems<CatalogItem>> Execute(
        Guid typeId, 
        int pageSize = 10, 
        int pageIndex = 0)
    {
        _logger.LogInformation("Request items for parameters: TypeId: {typeId}, PageSize: {pageSize}, PageIndex: {pageIndex}", typeId, pageSize, pageIndex);

        var catalogTypeId = new CatalogTypeId(typeId);

        return await _catalogItemRepository
            .GetCatalogItemsByType(
                catalogTypeId, 
                Math.Min(pageSize, 5000), 
                pageIndex);
    }
}
