using Application.Services;

namespace Infrastructure.DataAccess;

/// <summary>
/// UoW.
/// </summary>
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly CatalogContext _context;
    private bool _disposed;

    /// <summary>
    /// Initialize an instance of UnitOfWork.
    /// </summary>
    /// <param name="context"></param>
    public UnitOfWork(CatalogContext context) => _context = context;

    public async Task<int> SaveChangesAsync()
    {
        var affectedRows = await _context.SaveChangesAsync();

        return affectedRows;
    }

    public int SaveChanges()
    {
        var affectedRows = _context.SaveChanges();

        return affectedRows;
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            if (_context is not null)
            {
                _context.Dispose();
            }
        }

        _disposed = true;
    }


    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
