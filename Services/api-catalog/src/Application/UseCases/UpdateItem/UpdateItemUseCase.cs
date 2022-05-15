using Application.Exceptions;
using Application.Services;
using Application.UseCases.Model;
using BuildingBlocks.Modules.Extensions;
using Domain;
using Domain.CatalogItems;
using Domain.ValueObject;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.UpdateItem;

/// <summary>
/// Update a catalog item into the inventory.
/// </summary>
public sealed class UpdateItemUseCase : IUpdateItemUseCase
{
    private readonly IUnitOfWork _uow;
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ILogger<UpdateItemUseCase> _logger;

    /// <summary>
    /// Initializes an instance of UpdateItemUseCase.
    /// </summary>
    /// <param name="uow">Unit of work.</param>
    /// <param name="catalogItemRepository">Catalog repository.</param>
    /// <param name="logger">Logger.</param>
    public UpdateItemUseCase(
        IUnitOfWork uow,
        ICatalogItemRepository catalogItemRepository,
        ILogger<UpdateItemUseCase> logger)
    {
        _uow = uow;
        _catalogItemRepository = catalogItemRepository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task Execute(Guid id, CatalogItemModel catalogItem)
    {
        _logger.LogInformation("Updating catalog item.");

        ICatalogItem? foundItem = await _catalogItemRepository.GetCatalogItemById(new CatalogItemId(id));

        if (foundItem is not CatalogItem)
        {
            _logger.LogError("Not able to find item with {id}", id);

            throw new ObjectNotFoundException($"Not able to find item with {id}");
        }

        var item = (CatalogItem)foundItem;

        var newItem = this.createItemCatalog(id, catalogItem);

        // TODO: If price is different publish the item into a queue and database by using atomic transaction strategy.

        _catalogItemRepository.UpdateCatalogItem(item, newItem);

        var affectedRows = await _uow.SaveChangesAsync();

        _logger.LogInformation("Item with Id: '{id}'. Affected rows: {affectedRows}", id, affectedRows);
    }

    private CatalogItem createItemCatalog(Guid id, CatalogItemModel catalogItem)
    {
        return new CatalogItem(
            new(id),
            catalogItem.Name,
            catalogItem.Description,
            catalogItem.Value,
            catalogItem.Currency,
            catalogItem.AvailableStock,
            catalogItem.PictureName,
            catalogItem.PictureUri,
            catalogItem.RestockThreshold,
            catalogItem.OnReorder,
            catalogItem.MaxStockThreshold,
            catalogItem.PictureAsBase64?.AsByteArray(),
            new(catalogItem.CatalogTypeId),
            new(catalogItem.CatalogBrandId)
        );
    }
}
