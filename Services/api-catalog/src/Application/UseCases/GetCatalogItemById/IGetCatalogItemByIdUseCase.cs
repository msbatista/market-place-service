using Domain.CatalogItems;

namespace Application.UseCases.GetCatalogItemById;

/// <summary>
/// IGetCatalogItemByIdUseCase.
/// </summary>
public interface IGetCatalogItemByIdUseCase
{
    /// <summary>
    /// Gets an item by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The found CatalogItem.</returns>
    /// <exception cref="Application.Exceptions.ObjectNotFoundException">When the object is not found it throws an exception of ObjectNotFoundException.</exception>
    Task<CatalogItem> Execute(Guid id);
}
