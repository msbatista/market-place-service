using Domain;
using Domain.CatalogItems;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GetCatalogItemsWithName;

/// <summary>
/// Catalog controller.
/// </summary>
public sealed class GetCatalogItemsWithNameUseCase : IGetCatalogItemsWithNameUseCase
{
    private readonly ILogger<GetCatalogItemsWithNameUseCase> _logger;
    private readonly ICatalogItemRepository _catalogItemRepository;

    /// <summary>
    /// Initializes an instance of GetCatalogItemsWithNameUseCase.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="catalogItemRepository"></param>
    public GetCatalogItemsWithNameUseCase(ILogger<GetCatalogItemsWithNameUseCase> logger, ICatalogItemRepository catalogItemRepository)
    {
        _logger = logger;
        _catalogItemRepository = catalogItemRepository;
    }

    /// <inheritdoc />
    public async Task<PaginatedItems<CatalogItem>> Execute(string name, int pageSize = 10, int pageIndex = 0)
    {
        _logger.LogInformation("Requesting items for name: {name}", name);

        return await _catalogItemRepository.GetCatalogItemsWithName(name, pageSize, pageIndex);
    }
}
