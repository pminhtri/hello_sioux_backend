using HelloSioux.API.Services.Users;

namespace HelloSioux.API.Installations
{
    public static partial class DependencyInstaller
    {
        public static void InstallServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
