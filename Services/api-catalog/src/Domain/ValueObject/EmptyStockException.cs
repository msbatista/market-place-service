namespace Domain.ValueObject;

/// <inheritdoc />
public sealed class EmptyStockException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the EmptyStockException class with a specified error message.
    /// </summary>
    /// <param name="message">Error message.</param>
    public EmptyStockException(string? message) : base(message)
    {
    }
}
