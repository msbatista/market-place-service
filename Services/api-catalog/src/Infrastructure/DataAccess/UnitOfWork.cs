using System.Transactions;
using Application.Services;

namespace Infrastructure.DataAccess;

public sealed class UnitOfWork : IUnitOfWork
{
    public Transaction BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
