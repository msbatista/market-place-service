namespace Application.Services;

/// <summary>
/// Unit Of Work definitions.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Save changes asynchronously.
    /// </summary>
    /// <returns>The amount of affected rows.</returns>
    Task<int> SaveChangesAsync();

    /// <summary>
    /// Save changes.
    /// </summary>
    /// <returns>The amount of affected rows.</returns>
    int SaveChanges();
}
