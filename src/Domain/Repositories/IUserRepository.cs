using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IReadOnlyCollection<User>> GetAllAsync();
        Task<IReadOnlyCollection<User>> GetAllByEmailsAsync(List<string> emails);
        Task<User> GetByEmailAsync(string email);
        Task InsertAsync(User user);
    }
}
