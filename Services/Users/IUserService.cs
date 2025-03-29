using HelloSioux.API.Base.Service;
using HelloSioux.API.Models.Entities;

namespace HelloSioux.API.Services.Users
{
  public interface IUserService : IService<User>
  {
    Task<User> GetByEmailAsync(string email);

    Task<IEnumerable<User>> GetManyByEmailsAsync(IEnumerable<string> emails);
  }
}