using HelloSioux.API.Data.Repositories.Users;

namespace HelloSioux.API.Installations
{
    public static partial class DependencyInstaller
    {
        public static void InstallRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
