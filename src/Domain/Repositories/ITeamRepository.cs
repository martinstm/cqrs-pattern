using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITeamRepository
    {
        Task<IReadOnlyCollection<Team>> GetAllAsync();
        Task<IReadOnlyCollection<Team>> GetByUserIdAsync(Guid userId);
        Task InsertAsync(Team team);
    }
}
