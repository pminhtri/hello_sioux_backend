namespace HelloSioux.API.Base.Service
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task CreateAsync(T entity);
        Task CreateManyAsync(IEnumerable<T> entities);
        Task UpdateAsync(string id, T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(string id);
    }
}