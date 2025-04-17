namespace VKX_API01.Help.Reponse
{
    public interface IReponsitory
    {
        Task<List<T>> GetAllAsync<T>() where T : class;
        Task<T?> GetByIdAsync<T>(object id) where T : class;
        Task<T?> AddAsync<T>(T entity) where T : class;
        Task<bool> UpdateAsync<T>(object id, T entity) where T : class;
        Task<bool> DeleteAsync<T>(object id) where T : class;
        Task SaveAsync();
        // Thêm phương thức Query để lấy IQueryable<TEntity>
        IQueryable<T> Query<T>() where T : class;

    }
}
