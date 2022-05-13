using Application.UseCases.Model;
using Domain.ValueObject;

namespace Application.UseCases.UpdateItem;

/// <summary>
/// IUpdateItemUseCase.
/// </summary>
public interface IUpdateItemUseCase
{
    /// <summary>
    /// Updates catalog item into the inventory.
    /// </summary>
    /// <param name="id">Item to be updated.</param>
    /// <param name="catalogItem">Item new content.</param>
    /// <returns>Task.</returns>
    Task Execute(Guid id, CatalogItemModel catalogItem);
}
