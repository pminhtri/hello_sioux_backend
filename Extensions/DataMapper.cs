using AutoMapper;
using System.Reflection;

namespace HelloSioux.API.Extensions
{
  public static class DataMapperExtensions
  {
    public static IServiceCollection AddDataMappers(this IServiceCollection services)
    {
      services.AddAutoMapper(Assembly.GetExecutingAssembly());

      return services;
    }
  }
}
