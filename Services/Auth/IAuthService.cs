namespace HelloSioux.API.Services.Auth
{
  public interface IAuthService
  {
    Task AuthenticateAsync(string email, string password);
  }
}