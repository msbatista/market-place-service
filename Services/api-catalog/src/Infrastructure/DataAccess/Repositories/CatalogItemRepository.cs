using Domain;
using Domain.CatalogBrands;
using Domain.CatalogItems;
using Domain.CatalogTypes;
using Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories;

/// <summary>
/// CatalogItemRepository.
/// </summary>
public sealed class CatalogItemRepository : ICatalogItemRepository
{
    private readonly CatalogContext _context;

    /// <summary>
    /// Initializes an instance of CatalogItemRepository.
    /// </summary>
    /// <param name="context"></param>
    public CatalogItemRepository(CatalogContext context) => _context = context;

    /// <inheritdoc />
    public async Task CreateCatalogItem(CatalogItem catalogItem)
    {
        await _context
            .CatalogItems
            .AddAsync(catalogItem);
    }

    /// <inheritdoc />
    public void DeleteCatalogItem(CatalogItem catalogItem)
    {
        _context
           .CatalogItems
           .Remove(catalogItem);
    }

    /// <inheritdoc />
    public async Task<IList<CatalogBrand>> GetCatalogBrands()
    {
        return await _context
            .CatalogBrands
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<ICatalogItem> GetCatalogItemById(CatalogItemId id)
    {
        var foundItem = await _context
            .CatalogItems
            .SingleOrDefaultAsync(x => x.CatalogItemId == id);

        if (foundItem is CatalogItem catalogItem)
        {
            return catalogItem;
        }

        return CatalogItemNull.Instance;
    }

    /// <inheritdoc />
    public async Task<List<CatalogItem>> GetCatalogItems(CatalogItemId[] ids)
    {

        return await _context
            .CatalogItems
            .Where(c => ids.Contains(c.CatalogItemId))
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<PaginatedItems<CatalogItem>> GetCatalogItemsByTypeAndBrand(
        CatalogTypeId? typeId = null,
        CatalogBrandId? brandId = null,
        int pageSize = 10,
        int pageIndex = 0)
    {
        var baseQuery = _context.CatalogItems.AsQueryable();

        if (typeId is CatalogTypeId itemType)
        {
            baseQuery = baseQuery.Where(c => c.CatalogTypeId == itemType);
        }

        if (brandId is CatalogBrandId itemBrand)
        {
            baseQuery = baseQuery.Where(c => c.CatalogBrandId == itemBrand);
        }

        var count = await baseQuery.LongCountAsync();

        var items = await baseQuery
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>(pageSize, pageIndex, count, items);
    }

    /// <inheritdoc />
    public async Task<PaginatedItems<CatalogItem>> GetCatalogItemsWithName(string name, int pageSize = 10, int pageIndex = 0)
    {
        var baseQuery = _context
            .CatalogItems
            .Where(c => c.Name.StartsWith(name));

        var count = await _context
            .CatalogItems
            .LongCountAsync();

        var items = await _context
            .CatalogItems
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>(pageSize, pageIndex, count, items);
    }

    /// <inheritdoc />
    public void UpdateCatalogItem(CatalogItem newItem)
    {
        _context.CatalogItems.Update(newItem);
    }

    /// <inheritdoc />
    public async Task<IList<CatalogType>> GetCatalogTypes()
    {
        return await _context
            .CatalogTypes
            .ToListAsync();
    }
}
