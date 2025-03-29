using HelloSioux.API.Base.Repository;
using HelloSioux.API.Models.Entities;
using MongoDB.Driver;

namespace HelloSioux.API.Data.Repositories.Users
{
  public class UserRepository(DbContext dbContext) : Repository<User>(dbContext), IUserRepository
  {
    private readonly IMongoCollection<User> _usersCollection = dbContext.GetCollection<User>();

    public async Task<User> GetByEmailAsync(string email)
    {
      var filter = Builders<User>.Filter.Eq(u => u.Email, email);
      return await _usersCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<User>> GetManyByEmailsAsync(IEnumerable<string> emails)
    {
      var filter = Builders<User>.Filter.In(u => u.Email, emails);
      return await _usersCollection.Find(filter).ToListAsync();
    }
  }
}
