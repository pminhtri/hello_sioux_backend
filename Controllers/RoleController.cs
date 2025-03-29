using HelloSioux.API.Base.Controller;
using HelloSioux.API.Models.Entities;
using HelloSioux.API.Services.Roles;
using Microsoft.AspNetCore.Mvc;

namespace HelloSioux.API.Controllers
{
  public class RoleController(IRoleService roleService) : ControllerBase, IController<Role, IRoleService>
  {
    private readonly IRoleService _roleService = roleService;
  }
}