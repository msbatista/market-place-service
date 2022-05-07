namespace Domain;

/// <summary>
/// Represents errors that occur when a request violates domain rules.
/// </summary>
public abstract class DomainException : Exception
{
    /// <summary>
    /// Initializes a new instance of the DomainException class with a specified error message.
    /// </summary>
    /// <param name="message">Error message.</param>
    protected DomainException(string? message) : base(message)
    {
    }
}
