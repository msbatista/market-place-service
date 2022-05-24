using Application.Services;
using Domain;
using Domain.CatalogItems;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.CreateCatalogItems;

/// <summary>
/// Persists a catalog item into the inventory.
/// </summary>
public sealed class CreateCatalogItemUseCase : ICreateCatalogItemUseCase
{
    private readonly IUnitOfWork _uow;
    private readonly IEntityFactory _entityFactory;
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ILogger<CreateCatalogItemUseCase> _logger;

    /// <summary>
    /// Initializes an instance of CreateCatalogItemUseCase.
    /// </summary>
    /// <param name="uow">Unit of work.</param>
    /// <param name="entityFactory">Factory of objects.</param>
    /// <param name="catalogItemRepository">Catalog repository.</param>
    /// <param name="logger">Logger.</param>
    public CreateCatalogItemUseCase(
        IUnitOfWork uow, 
        IEntityFactory entityFactory,
        ICatalogItemRepository catalogItemRepository, 
        ILogger<CreateCatalogItemUseCase> logger)
    {
        _uow = uow;
        _entityFactory = entityFactory;
        _catalogItemRepository = catalogItemRepository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<CatalogItem> Execute(CreateCatalogItemModel catalogItem)
    {
        _logger.LogInformation("Inserting product into database.");

        var item = createItemCatalog(catalogItem);

        await _catalogItemRepository.CreateCatalogItem(item);

        var affectedRows = await _uow.SaveChangesAsync();

        _logger.LogInformation("Created item with id '{CatalogItemId}'. Affected rows: {affectedRows}", item.CatalogItemId, affectedRows);

        return item;
    }

    private CatalogItem createItemCatalog(CreateCatalogItemModel catalogItem)
    {
        return _entityFactory.NewCatalogItem(
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
            catalogItem.CatalogTypeId,
            catalogItem.CatalogBrandId
        );
    }
}
