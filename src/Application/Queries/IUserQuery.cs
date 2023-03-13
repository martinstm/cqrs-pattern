using Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface IUserQuery
    {
        Task<IReadOnlyCollection<UserReadDto>> GetAllAsync();
    }
}
