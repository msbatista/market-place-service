using Domain.ValueObject;

namespace Domain.CatalogItems;

public interface ICatalogItem
{
    /// <summary>
    /// Catalog item identity.
    /// </summary>
    /// <value>CatalogItemId.</value>
    CatalogItemId CatalogItemId { get; }

    /// <summary>
    /// Decrements the quantity of a particular item from the inventory. If the value solicited is greater than available stock is decreased by itself.
    /// </summary>
    /// <param name="quantityToBeRemoved">Quantity to be removed.</param>
    /// <returns>An in representing the removed quantity.</returns>
    /// <exception cref="Domain.ValueObject.EmptyStockException">Throws an exception if stock is empty.</exception>
    /// <exception cref="Domain.ValueObject.ValueOutOfRangeException">Throws an exception if one's try to remove a negative value from the stock.</exception>
    int RemoveStock(int quantityToBeRemoved);

    /// <summary>
    /// Increase the amount of items available on inventory.
    /// </summary>
    /// <param name="quantityToBeAdded"></param>
    /// <returns>An int that represents the quantity added to the inventory.</returns>
    /// <exception cref="Domain.ValueObject.ValueOutOfRangeException">Throws an exception if one's try to ad negative value into the inventory.</exception>
    int AddStock(int quantityToBeAdded);
}
