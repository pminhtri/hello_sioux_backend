using HelloSioux.API.Base.Entity;
using HelloSioux.API.Base.Repository;

namespace HelloSioux.API.Base.Service
{
  public class Service<T>(IRepository<T> repository) : IService<T> where T : class, IEntity
  {
    private readonly IRepository<T> _repository = repository;

    public async Task CreateAsync(T entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

      try
      {
        await _repository.AddAsync(entity);
      }
      catch (Exception ex)
      {
        throw new Exception($"Error creating entity: {ex.Message}", ex);
      }
    }

    public async Task CreateManyAsync(IEnumerable<T> entities)
    {
      if (entities == null || !entities.Any())
        throw new ArgumentNullException(nameof(entities), "Entities cannot be null or empty.");

      try
      {
        await _repository.AddManyAsync(entities);
      }
      catch (Exception ex)
      {
        throw new Exception($"Error creating entities: {ex.Message}", ex);
      }
    }

    public async Task DeleteAsync(string id)
    {
      if (string.IsNullOrEmpty(id))
        throw new ArgumentNullException(nameof(id), "ID cannot be null or empty.");

      try
      {
        await _repository.DeleteAsync(id);
      }
      catch (Exception ex)
      {
        throw new Exception($"Error deleting entity with ID {id}: {ex.Message}", ex);
      }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      try
      {
        var filter = _repository.GetAllFilter();
        var entities = await _repository.GetPagedAsync(filter, 1, 1000, null, true);
        return [.. entities];
      }
      catch (Exception ex)
      {
        throw new Exception($"Error retrieving all entities: {ex.Message}", ex);
      }
    }

    public async Task<T> GetByIdAsync(string id)
    {
      if (string.IsNullOrEmpty(id))
        throw new ArgumentNullException(nameof(id), "ID cannot be null or empty.");

      try
      {
        return await _repository.FindByIdAsync(id);
      }
      catch (Exception ex)
      {
        throw new Exception($"Error retrieving entity with ID {id}: {ex.Message}", ex);
      }
    }

    public async Task UpdateAsync(string id, T entity, CancellationToken cancellationToken = default)
    {
      if (string.IsNullOrEmpty(id))
        throw new ArgumentNullException(nameof(id), "ID cannot be null or empty.");

      if (entity == null)
        throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

      try
      {
        await _repository.UpdateAsync(id, entity, cancellationToken);
      }
      catch (Exception ex)
      {
        throw new Exception($"Error updating entity with ID {id}: {ex.Message}", ex);
      }
    }
  }
}