using Application.Exceptions;
using Domain;
using Domain.CatalogItems;
using Domain.ValueObject;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GetCatalogItemById;

/// <summary>
/// GetCatalogItemByIdUseCase
/// </summary>
public sealed class GetCatalogItemByIdUseCase : IGetCatalogItemByIdUseCase
{

    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ILogger<GetCatalogItemByIdUseCase> _logger;

    /// <summary>
    /// Initializes an instance of GetCatalogItemByIdUseCase.
    /// </summary>
    /// <param name="catalogItemRepository"></param>
    /// <param name="logger"></param>
    public GetCatalogItemByIdUseCase(
        ICatalogItemRepository catalogItemRepository,
        ILogger<GetCatalogItemByIdUseCase> logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _logger = logger;
    }


    /// <inheritdoc />
    public async Task<CatalogItem> Execute(Guid id)
    {
        _logger.LogInformation("Trying to retrieve item with id {id}", id);

        ICatalogItem? foundItem = await _catalogItemRepository
             .GetCatalogItemById(new CatalogItemId(id));

        if (foundItem is CatalogItem item)
        {
            return item;
        }

        _logger.LogInformation("Not able to find item with {id}", id);

        throw new ObjectNotFoundException($"Not able to find item with {id}");
    }
}
