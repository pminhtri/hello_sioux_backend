using HelloSioux.API.Base.Repository;
using HelloSioux.API.Data;
using HelloSioux.API.Models.Entities;

namespace HelloSioux.API.Services.UserJobInformations
{
  public class UserJobInformationService(DbContext dbContext) : Repository<UserJobInformation>(dbContext), IUserJobInformationService
  {
  }
}