using BuildingBlocks.Modules.Extensions;
using Domain;
using Domain.CatalogBrands;
using Domain.CatalogItems;
using Domain.CatalogTypes;
using Domain.ValueObject;

namespace Infrastructure.DataAccess;

public sealed class EntityFactory : IEntityFactory
{
    /// <inheritdoc />
    public CatalogBrand NewCatalogBrand(string brand) => new(new CatalogBrandId(Guid.NewGuid()), brand);

    /// <inheritdoc />
    public CatalogItem NewCatalogItem(
        string name, 
        string description, 
        decimal value, 
        string currency,
        int availableStock, 
        string pictureName, 
        string pictureUri, 
        int restockThreshold, 
        bool onReorder,
        int maxStockThreshold,
        string? pictureAsBase64,
        Guid catalogTypeId, 
        Guid catalogBrandId)
        => new(
            new CatalogItemId(Guid.NewGuid()),
            name,
            description,
            value,
            currency,
            availableStock,
            pictureName,
            pictureUri,
            restockThreshold,
            onReorder,
            maxStockThreshold,
            pictureAsBase64?.AsByteArray(),
            new(catalogTypeId),
            new(catalogBrandId));

    /// <inheritdoc />
    public CatalogType NewCatalogType(string type) => new(new CatalogTypeId(Guid.NewGuid()), type);
}
