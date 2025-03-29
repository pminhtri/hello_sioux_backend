using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HelloSioux.API.Models.DTOs;
using HelloSioux.API.Services.Users;

namespace HelloSioux.API.Controllers
{
  [ApiController]
  [Route("api/users")]
  public class UserController(IUserService _userService, IMapper _mapper) : ControllerBase
  {
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
      var users = await _userService.GetAllAsync();

      var res = new List<UserDto>();

      foreach (var user in users)
      {
        var userDto = _mapper.Map<UserDto>(user);
        res.Add(userDto);
      }

      return Ok(res);
    }
  }
}