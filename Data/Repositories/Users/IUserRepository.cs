using HelloSioux.API.Base.Repository;
using HelloSioux.API.Models.Entities;

namespace HelloSioux.API.Data.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);

        Task<IEnumerable<User>> GetManyByEmailsAsync(IEnumerable<string> emails);
    }
}
