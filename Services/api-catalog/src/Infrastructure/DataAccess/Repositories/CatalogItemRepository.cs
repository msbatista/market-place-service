using Domain;
using Domain.CatalogBrands;
using Domain.CatalogItems;
using Domain.CatalogTypes;
using Domain.ValueObject;

namespace Infrastructure.DataAccess.Repositories;

public sealed class CatalogItemRepository : ICatalogItemRepository
{
    public Task CreateCatalogItem(CatalogItem catalogItem)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCatalogItem(CatalogItemId itemId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<CatalogBrand>> GetCatalogBrands()
    {
        throw new NotImplementedException();
    }

    public Task<ICatalogItem> GetCatalogItemById(CatalogItemId id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<CatalogItem>> GetCatalogItems(int pageSize = 10, int pageIndex = 0, CatalogItemId[]? ids = null)
    {
        throw new NotImplementedException();
    }

    public Task<IList<CatalogItem>> GetCatalogItemsByBrand(CatalogBrandId brandId, int pageSize = 10, int pageIndex = 0)
    {
        throw new NotImplementedException();
    }

    public Task<IList<CatalogItem>> GetCatalogItemsByType(CatalogTypeId typeId, int pageSize = 10, int pageIndex = 0)
    {
        throw new NotImplementedException();
    }

    public Task<IList<CatalogItem>> GetCatalogItemsByTypeAndBrand(CatalogTypeId typeId, CatalogBrandId brandId, int pageSize = 10, int pageIndex = 0)
    {
        throw new NotImplementedException();
    }

    public Task<IList<CatalogItem>> GetCatalogItemsWithName(string name, int pageSize = 10, int pageIndex = 0)
    {
        throw new NotImplementedException();
    }

    public Task<IList<CatalogType>> GetCatalogTypes()
    {
        throw new NotImplementedException();
    }

    public Task UpdateCatalogItem(CatalogItem old, CatalogItem newItem)
    {
        throw new NotImplementedException();
    }
}
