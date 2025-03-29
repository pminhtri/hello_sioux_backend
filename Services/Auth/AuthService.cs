using HelloSioux.API.Base.Repository;
using HelloSioux.API.Data;
using HelloSioux.API.Models.Entities;

namespace HelloSioux.API.Services.Auth
{
  public class AuthService(DbContext dbContext) : Repository<UserGeneralInformation>(dbContext), IAuthService
  {
    public Task AuthenticateAsync(string email, string password)
    {
      throw new NotImplementedException();
    }
  }
}