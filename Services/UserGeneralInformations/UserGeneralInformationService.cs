using HelloSioux.API.Base.Repository;
using HelloSioux.API.Data;
using HelloSioux.API.Models.Entities;

namespace HelloSioux.API.Services.UserGeneralInformations
{
  public class UserGeneralInformationService(DbContext dbContext) : Repository<UserGeneralInformation>(dbContext), IUserGeneralInformationService
  {
  }
}