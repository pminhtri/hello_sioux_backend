using HelloSioux.API.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HelloSioux.API.Data
{
  public class DbContext
  {
    private readonly IMongoDatabase _database;

    public DbContext(IOptions<DbSettings> dbSettings)
    {
      if (string.IsNullOrEmpty(dbSettings.Value.ConnectionString))
        throw new ArgumentException("MongoDB connection string is missing!");

      var client = new MongoClient(dbSettings.Value.ConnectionString);
      _database = client.GetDatabase(dbSettings.Value.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>()
    {
      string collectionName = typeof(T).Name.ToLower() + "s";
      var collection = _database.GetCollection<T>(collectionName);

      return collection;
    }

    public async Task<List<string>> GetAllCollectionNamesAsync()
    {
      var collections = await _database.ListCollectionNamesAsync();
      return await collections.ToListAsync();
    }
  }
}
