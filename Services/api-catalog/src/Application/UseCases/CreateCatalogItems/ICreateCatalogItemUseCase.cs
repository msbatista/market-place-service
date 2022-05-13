using Application.UseCases.Model;
using Domain.CatalogItems;

namespace Application.UseCases.CreateCatalogItems;

/// <summary>
/// ICreateCatalogItemUseCase.
/// </summary>
public interface ICreateCatalogItemUseCase
{
    /// <summary>
    /// Add catalog item into the inventory.
    /// </summary>
    /// <param name="catalogItem">Item to be inserted.</param>
    /// <returns>The created product.</returns>
    Task<CatalogItem> Execute(CatalogItemModel catalogItem);
}
