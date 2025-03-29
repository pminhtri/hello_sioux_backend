using System.Linq.Expressions;
using HelloSioux.API.Base.Repository;
using HelloSioux.API.Models.Entities;
using MongoDB.Driver;

namespace HelloSioux.API.Data.Repositories.Roles
{
  public class RoleRepository(DbContext dbContext) : Repository<Role>(dbContext), IRoleRepository
  {
  }
}