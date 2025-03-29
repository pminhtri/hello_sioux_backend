using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using HelloSioux.API.Base.Entity;
using MongoDB.Driver;

namespace HelloSioux.API.Base.Repository
{
  /// <summary>
  /// Generic repository interface for MongoDB data access.
  /// </summary>
  /// <typeparam name="T">Entity type that implements IEntity</typeparam>
  public interface IRepository<T> where T : class, IEntity
  {
    #region Query Building

    /// <summary>
    /// Get a filter that matches all entities.
    /// </summary>
    FilterDefinition<T> GetAllFilter();

    /// <summary>
    /// Create a filter from a LINQ expression.
    /// </summary>
    /// <param name="predicate">The LINQ expression to convert to MongoDB filter</param>
    FilterDefinition<T> CreateFilter(Expression<Func<T, bool>> predicate);

    #endregion

    #region Read Operations

    /// <summary>
    /// Get paginated entities that match the filter.
    /// </summary>
    /// <param name="filter">The MongoDB filter definition</param>
    /// <param name="page">Page number (1-based)</param>
    /// <param name="pageSize">Number of items per page</param>
    /// <param name="sortBy">Optional expression to sort results by</param>
    /// <param name="ascending">Sort direction</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task<IEnumerable<T>> GetPagedAsync(FilterDefinition<T> filter, int page, int pageSize,
        Expression<Func<T, object>>? sortBy = null, bool ascending = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Find a single entity matching the filter.
    /// </summary>
    /// <param name="filter">The MongoDB filter definition</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task<T> FindOneAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = default);

    /// <summary>
    /// Find all entities matching the filter.
    /// </summary>
    /// <param name="filter">The MongoDB filter definition</param>
    /// <param name="sortBy">Optional expression to sort results by</param>
    /// <param name="ascending">Sort direction</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task<IEnumerable<T>> FindManyAsync(FilterDefinition<T> filter,
        Expression<Func<T, object>>? sortBy = null, bool ascending = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get an entity by its ID.
    /// </summary>
    /// <param name="id">The entity ID</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task<T> FindByIdAsync(string id, CancellationToken cancellationToken = default);

    #endregion

    #region Write Operations

    /// <summary>
    /// Add a new entity.
    /// </summary>
    /// <param name="entity">Entity to add</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add multiple entities.
    /// </summary>
    /// <param name="entities">Entities to add</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task AddManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update an entity by ID.
    /// </summary>
    /// <param name="id">Entity ID</param>
    /// <param name="entity">Updated entity data</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if entity was found and updated</returns>
    Task<bool> UpdateAsync(string id, T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update multiple entities using a filter.
    /// </summary>
    /// <param name="filter">Filter to select entities to update</param>
    /// <param name="entity">Entity with updated values</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Number of documents updated</returns>
    Task<long> UpdateManyAsync(FilterDefinition<T> filter, T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete an entity by ID.
    /// </summary>
    /// <param name="id">Entity ID to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if entity was found and deleted</returns>
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete multiple entities using a filter.
    /// </summary>
    /// <param name="filter">Filter to select entities to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Number of documents deleted</returns>
    Task<long> DeleteManyAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = default);

    #endregion

    #region Query Operations

    /// <summary>
    /// Check if any entity exists based on a filter.
    /// </summary>
    /// <param name="filter">Filter criteria</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if at least one matching document exists</returns>
    Task<bool> ExistsAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = default);

    /// <summary>
    /// Count the number of entities matching a filter.
    /// </summary>
    /// <param name="filter">Filter criteria</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Count of matching documents</returns>
    Task<long> CountAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = default);

    #endregion
  }
}