using System.Transactions;
namespace Application.Services;

public interface IUnitOfWork : IDisposable
{
    Transaction BeginTransaction();
    Task<int> SaveChangesAsync();
}
