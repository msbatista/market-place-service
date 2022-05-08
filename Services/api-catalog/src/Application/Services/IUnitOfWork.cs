namespace Application.Services;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();
}
