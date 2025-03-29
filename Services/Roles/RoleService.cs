using HelloSioux.API.Base.Service;
using HelloSioux.API.Data.Repositories.Roles;
using HelloSioux.API.Models.Entities;

namespace HelloSioux.API.Services.Roles
{
  public class RoleService(IRoleRepository _roleRepository) : Service<Role>(_roleRepository), IRoleService
  {
   
  }
}