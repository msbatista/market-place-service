using Domain;
using Domain.CatalogBrands;
using Domain.CatalogItems;
using Domain.CatalogTypes;
using Domain.ValueObject;

namespace Infrastructure.DataAccess.Repositories;

public sealed class CatalogItemRepository : ICatalogItemRepository
{
    private readonly CatalogContext _context;

    public CatalogItemRepository(CatalogContext context) => _context = context;

    public async Task CreateCatalogItem(CatalogItem catalogItem)
    {
        await _context
            .CatalogItems
            .AddAsync(catalogItem);
    }

    public void DeleteCatalogItem(CatalogItem catalogItem)
    {
         _context
            .CatalogItems
            .Remove(catalogItem);
    }

    public Task<IList<CatalogBrand>> GetCatalogBrands()
    {
        throw new NotImplementedException();
    }

    public Task<ICatalogItem> GetCatalogItemById(CatalogItemId id)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedItems<CatalogItem>> GetCatalogItems(int pageSize = 10, int pageIndex = 0, CatalogItemId[]? ids = null)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedItems<CatalogItem>> GetCatalogItemsByBrand(CatalogBrandId brandId, int pageSize = 10, int pageIndex = 0)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedItems<CatalogItem>> GetCatalogItemsByType(CatalogTypeId typeId, int pageSize = 10, int pageIndex = 0)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedItems<CatalogItem>> GetCatalogItemsByTypeAndBrand(CatalogTypeId typeId, CatalogBrandId brandId, int pageSize = 10, int pageIndex = 0)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedItems<CatalogItem>> GetCatalogItemsWithName(string name, int pageSize = 10, int pageIndex = 0)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCatalogItem(CatalogItem old, CatalogItem newItem)
    {
        throw new NotImplementedException();
    }

    public Task<IList<CatalogType>> GetCatalogTypes()
    {
        throw new NotImplementedException();
    }
}
