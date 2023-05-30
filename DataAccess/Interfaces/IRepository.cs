namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(int id);
        Task UpdateAsync(T item);
        Task CreateAsync(T item);
        Task DeleteAsync(int id);
        Task<T?> FindAsync(int id);
    }
}
