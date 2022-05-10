namespace Application.UseCases.DeleteCatalogItem;

/// <summary>
/// IDeleteItemUseCase.
/// </summary>
public interface IDeleteItemUseCase
{
    /// <summary>
    /// Delete an item.
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns>Task.</returns>
    Task Execute(Guid itemId);
}
