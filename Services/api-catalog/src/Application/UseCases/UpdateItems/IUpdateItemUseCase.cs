namespace Application.UseCases.UpdateItems;

/// <summary>
/// IUpdateItemUseCase.
/// </summary>
public interface IUpdateItemUseCase
{
    /// <summary>
    /// Updates catalog item into the inventory.
    /// </summary>
    /// <param name="catalogItem">Item new content.</param>
    /// <returns>Task.</returns>
    Task Execute(UpdateCatalogItemModel catalogItem);
}
