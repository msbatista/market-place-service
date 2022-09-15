using Domain;
using Domain.CatalogItems;
using Domain.ValueObject;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GetCatalogItems;

/// <summary>
/// Catalog controller.
/// </summary>
public class GetCatalogItemsUseCase : IGetCatalogItemsUseCase
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ILogger<GetCatalogItemsUseCase> _logger;

    /// <summary>
    /// Initializes an instance of GetCatalogItemsUseCase.
    /// </summary>
    /// <param name="catalogItemRepository"></param>
    /// <param name="logger"></param>
    public GetCatalogItemsUseCase(
        ICatalogItemRepository catalogItemRepository, 
        ILogger<GetCatalogItemsUseCase> logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<PaginatedItems<CatalogItem>> Execute(
        string? ids,
        int pageSize = 10,
        int pageIndex = 0)
    {
        _logger.LogInformation("Fetching inventory items.");

        var parsedIds = Array.Empty<CatalogItemId>();

        if (!string.IsNullOrWhiteSpace(ids))
        {
            _logger.LogInformation("Request items for list id: {ids}", ids);

            parsedIds = ids
                .Split(",")
                .Select(id => new CatalogItemId(Guid.Parse(id)))
                .ToArray();
        }

        return await _catalogItemRepository.GetCatalogItems(parsedIds, Math.Min(pageSize, 5000), pageIndex);
    }
}
