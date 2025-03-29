using System.Linq.Expressions;
using HelloSioux.API.Base.Entity;
using HelloSioux.API.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HelloSioux.API.Base.Repository
{
  public class Repository<T>(DbContext dbContext) : IRepository<T> where T : class, IEntity
  {
    private readonly IMongoCollection<T> _collection = dbContext.GetCollection<T>();

    #region Query Building

    public FilterDefinition<T> GetAllFilter()
    {
      return Builders<T>.Filter.Empty;
    }

    public FilterDefinition<T> CreateFilter(Expression<Func<T, bool>> predicate)
    {
      return Builders<T>.Filter.Where(predicate);
    }

    #endregion

    #region Read Operations

    public async Task<IEnumerable<T>> GetPagedAsync(FilterDefinition<T> filter, int page, int pageSize,
    Expression<Func<T, object>>? sortBy = null, bool ascending = true,
    CancellationToken cancellationToken = default)
    {
      var findFluent = _collection.Find(filter)
          .Skip((page - 1) * pageSize)
          .Limit(pageSize);

      if (sortBy != null)
      {
        findFluent = ascending
            ? findFluent.SortBy(sortBy)
            : findFluent.SortByDescending(sortBy);
      }

      return await findFluent.ToListAsync(cancellationToken);
    }

    public async Task<T> FindOneAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = default)
    {
      return await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> FindManyAsync(FilterDefinition<T> filter,
        Expression<Func<T, object>>? sortBy = null, bool ascending = true,
        CancellationToken cancellationToken = default)
    {
      var findFluent = _collection.Find(filter);

      if (sortBy != null)
      {
        findFluent = ascending
          ? findFluent.SortBy(sortBy)
          : findFluent.SortByDescending(sortBy);
      }

      return await findFluent.ToListAsync(cancellationToken);
    }

    public async Task<T> FindByIdAsync(string id, CancellationToken cancellationToken = default)
    {
      var objectId = ObjectId.TryParse(id, out var parsedId)
        ? parsedId
        : ObjectId.Empty;

      var filter = Builders<T>.Filter.Eq("_id", objectId);
      return await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
    }

    #endregion

    #region Write Operations

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
      await _collection.InsertOneAsync(entity, null, cancellationToken);
    }

    public async Task AddManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
      await _collection.InsertManyAsync(entities, null, cancellationToken);
    }

    public async Task<bool> UpdateAsync(string id, T entity, CancellationToken cancellationToken = default)
    {
      var objectId = ObjectId.TryParse(id, out var parsedId)
        ? parsedId
        : ObjectId.Empty;

      var filter = Builders<T>.Filter.Eq("_id", objectId);
      var result = await _collection.ReplaceOneAsync(filter, entity,
        new ReplaceOptions { IsUpsert = false }, cancellationToken);

      return result.ModifiedCount > 0;
    }

    public async Task<long> UpdateManyAsync(FilterDefinition<T> filter, T entity, CancellationToken cancellationToken = default)
    {
      // For updating many, we need to create an update definition
      var updates = new List<UpdateDefinition<T>>();

      // Get properties to update, excluding Id
      var properties = typeof(T).GetProperties()
        .Where(p => p.Name != "Id" && p.CanWrite);

      foreach (var prop in properties)
      {
        var value = prop.GetValue(entity);
        if (value != null)
        {
          updates.Add(Builders<T>.Update.Set(prop.Name, value));
        }
      }

      if (updates.Count == 0)
      {
        return 0; // Nothing to update
      }

      var combinedUpdate = Builders<T>.Update.Combine(updates);
      var result = await _collection.UpdateManyAsync(
        filter, combinedUpdate, new UpdateOptions(), cancellationToken);

      return result.ModifiedCount;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
      var objectId = ObjectId.TryParse(id, out var parsedId)
        ? parsedId
        : ObjectId.Empty;

      var filter = Builders<T>.Filter.Eq("_id", objectId);
      var result = await _collection.DeleteOneAsync(filter, cancellationToken);

      return result.DeletedCount > 0;
    }

    public async Task<long> DeleteManyAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = default)
    {
      var result = await _collection.DeleteManyAsync(filter, cancellationToken);
      return result.DeletedCount;
    }

    #endregion

    #region Query Operations

    public async Task<bool> ExistsAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = default)
    {
      return await _collection.CountDocumentsAsync(filter,
        new CountOptions { Limit = 1 }, cancellationToken) > 0;
    }

    public async Task<long> CountAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = default)
    {
      return await _collection.CountDocumentsAsync(filter, null, cancellationToken);
    }

    #endregion
  }
}