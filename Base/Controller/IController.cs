using HelloSioux.API.Base.Service;

namespace HelloSioux.API.Base.Controller
{
    public interface IController<T, TService> where T : class where TService : IService<T>
    {
    }
}