using Application.Exceptions;
using Application.Services;
using Domain;
using Domain.CatalogItems;
using Domain.ValueObject;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.DeleteCatalogItem;

/// <summary>
/// Catalog controller.
/// </summary>
public class DeleteItemUseCase : IDeleteItemUseCase
{
    private readonly IUnitOfWork _uow;
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ILogger<DeleteItemUseCase> _logger;

    /// <summary>
    /// Initializes an instance of DeleteItemUseCase.
    /// </summary>
    /// <param name="catalogItemRepository"></param>
    /// <param name="uow"></param>
    /// <param name="logger"></param>
    public DeleteItemUseCase(ICatalogItemRepository catalogItemRepository, IUnitOfWork uow, ILogger<DeleteItemUseCase> logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _uow = uow;
        _logger = logger;
    }

    public async Task Execute(Guid itemId)
    {
        _logger.LogWarning("Deleting item with id: {itemId}", itemId);

        var id = new CatalogItemId(itemId);

        ICatalogItem? foundItem = await _catalogItemRepository.GetCatalogItemById(id);

        if (foundItem is CatalogItem catalogItem)
        {
            _catalogItemRepository.DeleteCatalogItem(catalogItem);
            
            var affectedRows = await _uow.SaveChangesAsync();

            _logger.LogInformation("A total of {affectedRows} where affected.", affectedRows);

            return;
        }

        throw new ObjectNotFoundException($"Not able to find item with id: {id}");
    }
}
