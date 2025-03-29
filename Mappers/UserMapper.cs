using AutoMapper;
using HelloSioux.API.Models.DTOs;
using HelloSioux.API.Models.Entities;

namespace HelloSioux.API.Mappers
{
  public class UserMapper : Profile
  {
    public UserMapper()
    {
      CreateMap<User, UserDto>();
    }
  }
}