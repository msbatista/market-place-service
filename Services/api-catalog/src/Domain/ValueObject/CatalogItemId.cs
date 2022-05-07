namespace Domain.ValueObject;

/// <summary>
/// CatalogItemId.
/// </summary>
public readonly struct CatalogItemId
{
    /// <summary>
    /// Entity id.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Id { get; }

    /// <summary>
    /// Entity base constructor.
    /// </summary>
    /// <param name="id">Entity identity.</param>
    public CatalogItemId(Guid id) => Id = id;

    /// <summary>
    /// Returns a value indicating whether this instance and a specified Guid object represent the same value.
    /// </summary>
    /// <param name="obj">An object to compare to this instance.</param>
    /// <returns>true if g is equal to this instance; otherwise, false.</returns>
    public override bool Equals(object? obj) => obj is CatalogItemId @base && Id.Equals(@base.Id);

    public override int GetHashCode() => HashCode.Combine(Id);

    public override string ToString() => this.Id.ToString();

    public static bool operator ==(CatalogItemId left, CatalogItemId right) => left.Equals(right);

    public static bool operator !=(CatalogItemId left, CatalogItemId right) => left.Equals(right);
}
