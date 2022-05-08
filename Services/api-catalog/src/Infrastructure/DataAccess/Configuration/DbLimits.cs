namespace Infrastructure.DataAccess.Configuration;

/// <summary>
/// Defines size limits for database text columns.
/// </summary>
public static class DbLimits
{
    /// <summary>
    /// Represents a text of 5 characters.
    /// </summary>
    public static readonly int TINIER_TEXT = 5;
    /// <summary>
    /// Represents a text of 32 characters.
    /// </summary>
    public static readonly int TINY_TEXT = 32;
    /// <summary>
    /// Represents a text of 3072 characters.
    /// </summary>
    public static readonly int MEDIUM_TEXT = 3072;
}
