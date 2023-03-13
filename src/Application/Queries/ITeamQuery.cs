using Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface ITeamQuery
    {
        Task<IReadOnlyCollection<TeamReadDto>> GetAllAsync();
    }
}
