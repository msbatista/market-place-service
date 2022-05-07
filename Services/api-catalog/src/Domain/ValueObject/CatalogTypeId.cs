namespace Domain.ValueObject;

/// <summary>
/// CatalogTypeId.
/// </summary>
public readonly struct CatalogTypeId
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
    public CatalogTypeId(Guid id) => Id = id;

    /// <summary>
    /// Returns a value indicating whether this instance and a specified Guid object represent the same value.
    /// </summary>
    /// <param name="obj">An object to compare to this instance.</param>
    /// <returns>true if g is equal to this instance; otherwise, false.</returns>
    public override bool Equals(object? obj) => obj is CatalogTypeId @base && Id.Equals(@base.Id);

    public override int GetHashCode() => HashCode.Combine(Id);

    public override string ToString() => this.Id.ToString();

    public static bool operator ==(CatalogTypeId left, CatalogTypeId right) => left.Equals(right);

    public static bool operator !=(CatalogTypeId left, CatalogTypeId right) => left.Equals(right);
}
