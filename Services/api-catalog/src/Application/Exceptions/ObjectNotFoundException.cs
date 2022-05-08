namespace Application.Exceptions;

/// <summary>
/// Represents errors that occur when an query does not brings any result.
/// </summary>
public sealed class ObjectNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the ObjectNotFoundException class with a specified error message.
    /// </summary>
    /// <param name="message">Error message.</param>
    public ObjectNotFoundException(string message) : base(message)
    {
    }
}
