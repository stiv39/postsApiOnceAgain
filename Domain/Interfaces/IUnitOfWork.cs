namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
