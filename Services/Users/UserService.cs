using HelloSioux.API.Base.Service;
using HelloSioux.API.Data.Repositories.Users;
using HelloSioux.API.Models.Entities;

namespace HelloSioux.API.Services.Users
{
  public class UserService(IUserRepository userRepository) : Service<User>(userRepository), IUserService
  {
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User> GetByEmailAsync(string email)
    {
      var user = await _userRepository.GetByEmailAsync(email)
                  ?? throw new Exception($"User with email {email} not found.");
      return user;
    }

    public async Task<IEnumerable<User>> GetManyByEmailsAsync(IEnumerable<string> emails)
    {
      if (emails == null || !emails.Any())
        throw new ArgumentNullException(nameof(emails), "Emails cannot be null or empty.");

      var users = await _userRepository.GetManyByEmailsAsync(emails);
      if (users == null || !users.Any())
        throw new Exception($"No users found for the provided emails.");

      return users;
    }
  }
}