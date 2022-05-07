namespace Domain.ValueObject;

/// <inheritdoc />
public class ValueOutOfRangeException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the ValueOutOfRangeException class with a specified error message.
    /// </summary>
    /// <param name="message">Error message.</param>
    public ValueOutOfRangeException(string? message) : base(message)
    {
    }
}
